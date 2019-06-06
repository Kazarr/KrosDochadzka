using AttendanceSystem.Properties;
using Data.Generator;
using Data.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class MainWindowView : Form
    {
        private MainWindowViewModel _mainWindowViewModel;
        private LogicSystem _logic;
        private int _loggedEmployeeID;
        private string _selected = "";

        public MainWindowView(int id, LogicSystem logic)
        {
            InitializeComponent();
            dGVOverview.AutoGenerateColumns = true;
            _loggedEmployeeID = id;
            _logic = logic;
            _mainWindowViewModel = new MainWindowViewModel(_logic);
            WindowState = FormWindowState.Maximized;
            progressBar1.Visible = false;
            lblGenerating.Visible = false;
        }

        /// <summary>
        /// checks if the loged user is regular (1) supervisor(2) or admin (3) 
        /// </summary>
        private void CheckPermission()
        {
            int permssion = _mainWindowViewModel.GetEmployeeByID(_loggedEmployeeID).IdPermission;

            if (permssion == (int)EnumPermissions.Employee)
            {
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
            }
            if (permssion == (int)EnumPermissions.Supervisor)
            {
                btnReset.Visible = true;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox(_loggedEmployeeID);
            }
            else if (permssion == (int)EnumPermissions.Admin)
            {
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
                btnDeleteEmployee.Visible = true;
                btnNewEmployee.Visible = true;
                btnUpdateEmployee.Visible = true;
                btnReset.Visible = true;
                pictureBox1.Enabled = true;
            }

        }

        private void FillComboBoxes()
        {
            comboBoxMonth.DataSource = DateTimeFormatInfo.CurrentInfo.MonthNames;
            comboBoxMonth.SelectedIndex = int.Parse(DateTime.Now.Month.ToString()) - 1;
            comboBoxYear.DataSource = _mainWindowViewModel.FillYears(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem));

            comboBoxYear.SelectedIndex = 0;
        }

        private void FillDataGridView()
        {
            //get name of the month from the combobox
            _selected = $"{comboBoxMonth.GetItemText(comboBoxMonth.SelectedItem)} {comboBoxYear.GetItemText(comboBoxYear.SelectedItem)}";
            bindingSource1.DataSource = _mainWindowViewModel.FillDataGridViewOverview(
                _mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _selected);

        }

        private void btnDeleteEmployee_Click_1(object sender, EventArgs e)
        {
            MarkedButton(btnDeleteEmployee);
            DialogResult dialogResult = MessageBox.Show($@"This action will permanently delete {_mainWindowViewModel.Person.ToString()} 
and all his records are you sure you want to continue?", "Delete Employee", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes && _mainWindowViewModel.Employee.Id != _loggedEmployeeID)
            {
                _mainWindowViewModel.DeleteEmployeePerson((Person)comboBoxPerson.SelectedItem,_loggedEmployeeID);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
                MessageBox.Show("Delete Succesfull");
            }
            else if (dialogResult ==DialogResult.Yes)
            {
                MessageBox.Show("You cant delete yourself. Ask your supervisor or admin to do so.", "Delete Employee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void btnNewEmployee_Click_1(object sender, EventArgs e)
        {
            MarkedButton(btnNewEmployee);
            NewEmployeeView newEmployee = new NewEmployeeView(_logic);
            newEmployee.ShowDialog();

            if (newEmployee.DialogResult == DialogResult.OK)
            {
                CheckPermission();
            }            
        }

        private void btnShowMonth_Click_1(object sender, EventArgs e)
        {
            MarkedButton(btnShowMonth);
            List<DaySummary> daySummaries = new List<DaySummary>(
            _mainWindowViewModel.FillDataGridViewOverview(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _selected));

            MonthOverviewView monthOverview = new MonthOverviewView(daySummaries);
            monthOverview.ShowDialog();           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MarkedButton(buttonExit);
            DialogResult = DialogResult.OK;           
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            MarkedButton(btnUpdateEmployee);
            NewEmployeeView newEmployee = new NewEmployeeView(_mainWindowViewModel.Person, _mainWindowViewModel.Employee, _logic, (EnumPermissions) _mainWindowViewModel.GetEmployeeByID(_loggedEmployeeID).IdPermission );
            newEmployee.ShowDialog();
            if (newEmployee.DialogResult == DialogResult.OK)
            {
                CheckPermission();
            }           
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            MarkedButton(btnDetails);
            //checks if something is selected
            if (dGVOverview.SelectedRows.Count > 0)
            {
                //gets date from selectedRow
                DateTime selectedDate = Convert.ToDateTime(dGVOverview.Rows[dGVOverview.CurrentCell.RowIndex].Cells["Date"].Value.ToString());
                FrmDailyDetails dailyDetails = new FrmDailyDetails(
                    _loggedEmployeeID, selectedDate, _mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _logic);
                dailyDetails.ShowDialog();
                FillDataGridView();
            }            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MarkedButton(btnReset);
            DialogResult dialogResult = MessageBox.Show($"You are going to Reset Password for {_mainWindowViewModel.Person.FirstName} " +
                $"{_mainWindowViewModel.Person.LastName} ", "Password Reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _mainWindowViewModel.ResetPassword();
            }           
        }

        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            CheckPermission();
            FillComboBoxes();
            FillDataGridView();
            lblUserName.Text = $"{_logic.GetPersonByIdEmployee(_loggedEmployeeID).FirstName} {_logic.GetPersonByIdEmployee(_loggedEmployeeID).LastName}";
            dGVOverview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Method for painting data grid view 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGVOverview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToDateTime(dGVOverview.Rows[e.RowIndex].Cells["Date"].Value).DayOfWeek.ToString().Equals("Sunday") ||
                Convert.ToDateTime(dGVOverview.Rows[e.RowIndex].Cells["Date"].Value).DayOfWeek.ToString().Equals("Saturday"))
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }

            else if (dGVOverview.Rows[e.RowIndex].Cells[10].Value == null)
            {
                //nic sa nestane if je tu len preto aby dalsie nepadli
            }

            else if ((TimeSpan)(dGVOverview.Rows[e.RowIndex].Cells["TotalTimeWorked"].Value) > TimeSpan.FromHours(10))
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
            }

            else if ((TimeSpan)(dGVOverview.Rows[e.RowIndex].Cells["TotalTimeWorked"].Value) < TimeSpan.FromHours(6))
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }

            else
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
            }

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MarkedButton(btnChangePassword);
            PasswordChangeView passwordChange = new PasswordChangeView(_loggedEmployeeID, _logic);
            passwordChange.ShowDialog();            
        }

        private void comboBoxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void comboBoxPerson_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _mainWindowViewModel.Person = (Person)comboBoxPerson.SelectedItem;
            btnReset.Enabled = true;
            FillComboBoxes();
            FillDataGridView();
            lblEmpId.Text = _mainWindowViewModel.Employee.Id.ToString();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        #region Change buttons color
        private void ChangeImage(Button button, Image image)
        {
            button.Image = image;
        }
        private void MarkedButton(Button button)
        {
            panel1.Top = button.Top;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(buttonExit, Resources.logout1Red);
            MarkedButton(buttonExit);
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(buttonExit, Resources.logout1);
        }

        private void btnChangePassword_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnChangePassword, Resources.change1Red);
            MarkedButton(btnChangePassword);
        }

        private void btnChangePassword_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnChangePassword, Resources.change1);
        }

        private void btnDetails_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnDetails, Resources.detailsRed);
            MarkedButton(btnDetails);
        }

        private void btnDetails_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnDetails, Resources.details);
        }

        private void btnShowMonth_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnShowMonth, Resources.overviewRed);
            MarkedButton(btnShowMonth);
        }

        private void btnShowMonth_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnShowMonth, Resources.overview);
        }

        private void btnUpdateEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnUpdateEmployee, Resources.updateRed);
            MarkedButton(btnUpdateEmployee);
        }

        private void btnUpdateEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnUpdateEmployee, Resources.update);
        }

        private void btnNewEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnNewEmployee, Resources.newRed);
            MarkedButton(btnNewEmployee);
        }

        private void btnNewEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnNewEmployee, Resources._new);
        }

        private void btnDeleteEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnDeleteEmployee, Resources.deleteRed);
            MarkedButton(btnDeleteEmployee);
        }

        private void btnDeleteEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnDeleteEmployee, Resources.deleteEmp);
        }

        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnReset, Resources.resetRed);
            MarkedButton(btnReset);
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnReset, Resources.reset);
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GenerateDataView generate = new GenerateDataView(_mainWindowViewModel);
            generate.ShowDialog();
            if (generate.DialogResult == DialogResult.OK)
            {
                progressBar1.Visible = true;
                lblGenerating.Visible = true;
                btnCancel.Visible = true;
                buttonExit.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
            generate.Dispose();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            EmployeeGenerator employeeGenerator = new EmployeeGenerator(_mainWindowViewModel.EmployeeToGenerate);

            e.Result = employeeGenerator.Generate(backgroundWorker1.ReportProgress, CheckCancellation);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            MethodInvoker invoker = () => progressBar1.Value = e.ProgressPercentage;
            progressBar1.BeginInvoke(invoker);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                MessageBox.Show("Random data was successfully generated", "Generator", MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblGenerating.Visible = false;
                progressBar1.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                MessageBox.Show("There was an error generating data", "Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblGenerating.Visible = false;
                progressBar1.Visible = false;
                btnCancel.Visible = false;
            }
            buttonExit.Enabled = true;
            CheckPermission();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private bool CheckCancellation() => backgroundWorker1.CancellationPending;
    }
}
