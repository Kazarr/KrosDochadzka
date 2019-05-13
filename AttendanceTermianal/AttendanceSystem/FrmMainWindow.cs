using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class FrmMainWindow : Form
    {
        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();
        private int _loggedEmployeeID;
        private string _selected = "";

        public FrmMainWindow(int id)
        {
            _loggedEmployeeID = id;
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

        }

        /// <summary>
        /// checks if the loged user is regular (1) supervisor(2) or admin (3) 
        /// </summary>
        private void CheckPermission()
        {
            int permssion = _mainWindowViewModel.GetEmployeeByID(_loggedEmployeeID).Permision;

            if (permssion == 1)
            {
                btnDeleteEmployee.Visible = false;
                btnNewEmployee.Visible = false;
                btnUpdateEmployee.Visible = false;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
            }
            else if (permssion == 2)
            {

                btnDeleteEmployee.Visible = false;
                btnNewEmployee.Visible = false;
                btnReset.Visible = true;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillPlebPerson(_loggedEmployeeID);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox(_loggedEmployeeID);
            }
            else if (permssion == 3)
            {
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
                btnReset.Visible = true;
            }





        }


        private void fillComboBoxes()
        {
            comboBoxMonth.DataSource = DateTimeFormatInfo.CurrentInfo.MonthNames;
            comboBoxYear.DataSource = _mainWindowViewModel.FillYears(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem));
            comboBoxMonth.SelectedIndex = int.Parse(DateTime.Now.Month.ToString()) - 1;
            comboBoxYear.SelectedIndex = 0;
        }


        private void fillDataGridView()
        {
            //get name of the month from the combobox
            _selected = $"{comboBoxMonth.GetItemText(comboBoxMonth.SelectedItem)} {comboBoxYear.GetItemText(comboBoxYear.SelectedItem)}";
            dGVOverview.DataSource = _mainWindowViewModel.FillDataGridViewOverview(_mainWindowViewModel.GetEmployeeIdByPerson((Person)comboBoxPerson.SelectedItem), _selected);

        }
               

        private void btnDeleteEmployee_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This action will permanently delete employee and all his records are you sure you want to continue?", "Delete Employee", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _mainWindowViewModel.DeleteEmployeePerson((Person)comboBoxPerson.SelectedItem);
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }


        private void btnNewEmployee_Click_1(object sender, EventArgs e)
        {
            frmNewEmployee newEmployee = new frmNewEmployee();
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

            frmMonthOverview monthOverview = new frmMonthOverview(daySummaries);
            monthOverview.ShowDialog();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            frmNewEmployee newEmployee = new frmNewEmployee(_mainWindowViewModel.Person, _mainWindowViewModel.Employee);
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
                DateTime selectedDate = Convert.ToDateTime(dGVOverview.Rows[dGVOverview.CurrentCell.RowIndex].Cells[0].Value.ToString());
                frmDailyDetails dailyDetails = new frmDailyDetails(_loggedEmployeeID, selectedDate, _mainWindowViewModel.GetEmployeeIdByPerson((Data.Model.Person)comboBoxPerson.SelectedItem));
                dailyDetails.ShowDialog();
                fillDataGridView();
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            _mainWindowViewModel.ResetPassword();
        }


        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            CheckPermission();
            fillComboBoxes();
            fillDataGridView();

            dGVOverview.Columns[1].DefaultCellStyle.Format = "HH:mm:ss ";
            dGVOverview.Columns[2].DefaultCellStyle.Format = "HH:mm:ss ";
        }

        /// <summary>
        /// Method for painting data grid view 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGVOverview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToDateTime(dGVOverview.Rows[e.RowIndex].Cells[0].Value).DayOfWeek.ToString().Equals("Sunday") ||
                Convert.ToDateTime(dGVOverview.Rows[e.RowIndex].Cells[0].Value).DayOfWeek.ToString().Equals("Saturday"))
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            else if (dGVOverview.Rows[e.RowIndex].Cells[1].Value != null && dGVOverview.Rows[e.RowIndex].Cells[2].Value == null)
            {

                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
            }

            else if (dGVOverview.Rows[e.RowIndex].Cells[10].Value == null)
            {

            }


            else if ((TimeSpan)(dGVOverview.Rows[e.RowIndex].Cells[10].Value) > TimeSpan.FromHours(10))
            {
                dGVOverview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
            }

            else if ((TimeSpan)(dGVOverview.Rows[e.RowIndex].Cells[10].Value) < TimeSpan.FromHours(6))
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
            frmPasswordChange passwordChange = new frmPasswordChange(_loggedEmployeeID);
            passwordChange.ShowDialog();
        }
                

        private void comboBoxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillDataGridView();
        }


        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }


        private void comboBoxPerson_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _mainWindowViewModel.Person = (Person)comboBoxPerson.SelectedItem;
            btnReset.Enabled = true;
            fillDataGridView();
        }
    }
}
