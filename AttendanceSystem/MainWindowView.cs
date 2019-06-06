using AttendanceSystem.Properties;
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
        }

        /// <summary>
        /// checks if the loged user is regular (1) supervisor(2) or admin (3) 
        /// </summary>
        private void CheckPermission()
        {
            int permssion = _mainWindowViewModel.GetEmployeeByID(_loggedEmployeeID).IdPermission;

            if (permssion == (int)EnumPermissions.Employee)
            {
                btnDeleteEmployee.Visible = false;
                btnNewEmployee.Visible = false;
                btnUpdateEmployee.Visible = false;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
            }
            else if (permssion == (int)EnumPermissions.Supervisor)
            {

                btnDeleteEmployee.Visible = false;
                btnNewEmployee.Visible = false;
                btnReset.Visible = true;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox(_loggedEmployeeID);
            }
            else if (permssion == (int)EnumPermissions.Admin)
            {
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
                btnReset.Visible = true;
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
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(buttonExit, Resources.logout1);
        }

        private void btnChangePassword_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnChangePassword, Resources.change1Red);
        }

        private void btnChangePassword_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnChangePassword, Resources.change1);
        }

        private void btnDetails_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnDetails, Resources.detailsRed);
        }

        private void btnDetails_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnDetails, Resources.details);
        }

        private void btnShowMonth_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnShowMonth, Resources.overviewRed);
        }

        private void btnShowMonth_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnShowMonth, Resources.overview);
        }

        private void btnUpdateEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnUpdateEmployee, Resources.updateRed);
        }

        private void btnUpdateEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnUpdateEmployee, Resources.update);
        }

        private void btnNewEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnNewEmployee, Resources.newRed);
        }

        private void btnNewEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnNewEmployee, Resources._new);
        }

        private void btnDeleteEmployee_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnDeleteEmployee, Resources.deleteRed);
        }

        private void btnDeleteEmployee_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnDeleteEmployee, Resources.deleteEmp);
        }

        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            ChangeImage(btnReset, Resources.resetRed);
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            ChangeImage(btnReset, Resources.reset);
        }
        #endregion
    }
}
