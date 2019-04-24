using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class FrmMainWindow : Form
    {
        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();
        private int _employeeID;
        public FrmMainWindow(int id)
        {
            _employeeID = id;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            CheckPermission();
            fillMonthComboBox();
            fillDGV();

        }
        /// <summary>
        /// checks if the loged user is regular (1) supervisor(2) or admin (3) 
        /// </summary>
        private void CheckPermission()
        {
            if (_mainWindowViewModel.GetEmployeeByID(_employeeID).Permision >= 2)
            {
                btnUpdateEmployee.Visible = true;
                labelChoosePerson.Visible = true;
                comboBoxPerson.Visible = true;
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox(_employeeID);
            }
            if (_mainWindowViewModel.GetEmployeeByID(_employeeID).Permision >= 3)
            {
                comboBoxPerson.DataSource = _mainWindowViewModel.FillComboBox();
                btnNewEmployee.Visible = true;
                btnDeleteEmployee.Visible = true;
            }



        }

        private void fillMonthComboBox()
        {
            Dictionary<string, int> monthRecords = new Dictionary<string, int>(_mainWindowViewModel.GetMonthWithNumberOfRecords(_employeeID));
            foreach (var month in monthRecords.Keys)
            {
                comboBoxMonth.Items.Add($"{month.ToString()}: {monthRecords[month]}");
            }
        }

        private void fillDGV()
        {
            DateTime today = DateTime.Now;
            Dictionary<string, List<string>> myAprilDictionary=new Dictionary<string, List<string>>( _mainWindowViewModel.getApril(_employeeID));
            
            dGVOverview.Columns.Add("Datum", "Datum");
            dGVOverview.Columns.Add("WorkStart", "WorkStart");
            dGVOverview.Columns.Add("WorkFinish", "WorkFinish");
            dGVOverview.Columns.Add("LunchBreakStart", "LunchBreakStart");
            dGVOverview.Columns.Add("LunchBreakFinish", "LunchBreakFinish");
            int nieco = 0;
            foreach (var key in myAprilDictionary.Keys)
            {
                nieco++;

                Debug.WriteLine(key+" WTF:"+nieco);
                dGVOverview.Rows.Add();
                for (int i = 0; i < 4; i++)
                {
                    Debug.WriteLine(myAprilDictionary[key][i]);
                    dGVOverview[nieco, i].Value = myAprilDictionary[key][i].Count() == 0 ? "": myAprilDictionary[key][i];
                    //dGVOverview.Rows[nieco].Cells[i].Value = myAprilDictionary[key][i].ToString();
                }
            }

        }

        private void btnDeleteEmployee_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you serious?", "Delete faggot", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
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
        }

        private void btnShowMonth_Click_1(object sender, EventArgs e)
        {
            frmMonthOverview monthOverview = new frmMonthOverview();
            monthOverview.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
