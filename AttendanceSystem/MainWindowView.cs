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
            int permssion = _mainWindowViewModel.GetEmployeeByID(_loggedEmployeeID).Permision;

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
            comboBoxYear.DataSource = _mainWindowViewModel.FillYears(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem));
            comboBoxMonth.SelectedIndex = int.Parse(DateTime.Now.Month.ToString()) - 1;
            comboBoxYear.SelectedIndex = 0;
        }

        private void FillDataGridView()
        {
            //get name of the month from the combobox
            _selected = $"{comboBoxMonth.GetItemText(comboBoxMonth.SelectedItem)} {comboBoxYear.GetItemText(comboBoxYear.SelectedItem)}";
            bindingSource1.DataSource = _mainWindowViewModel.FillDataGridViewOverview(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _selected);

        }

        private void btnDeleteEmployee_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This action will permanently delete employee and all his records are you sure you want to continue?", "Delete Employee", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _mainWindowViewModel.DeleteEmployeePerson((Person)comboBoxPerson.SelectedItem);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
            }

        }

        private void btnNewEmployee_Click_1(object sender, EventArgs e)
        {
            NewEmployeeView newEmployee = new NewEmployeeView(_logic);
            newEmployee.ShowDialog();

            if (newEmployee.DialogResult == DialogResult.OK)
            {
                CheckPermission();
            }
        }

        private void btnShowMonth_Click_1(object sender, EventArgs e)
        {
            List<DaySummary> daySummaries = new List<DaySummary>(
            _mainWindowViewModel.FillDataGridViewOverview(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _selected));

            MonthOverviewView monthOverview = new MonthOverviewView(daySummaries);
            monthOverview.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            NewEmployeeView newEmployee = new NewEmployeeView(_mainWindowViewModel.Person, _mainWindowViewModel.Employee, _logic);
            newEmployee.ShowDialog();
            if (newEmployee.DialogResult == DialogResult.OK)
            {
                CheckPermission();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
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
            _mainWindowViewModel.ResetPassword();
        }

        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            CheckPermission();
            FillComboBoxes();
            FillDataGridView();
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
            else if (dGVOverview.Rows[e.RowIndex].Cells["WorkArrivalTime"].Value != null && dGVOverview.Rows[e.RowIndex].Cells["WorkLeavingTime"].Value == null)
            {

                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
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
            FillDataGridView();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
