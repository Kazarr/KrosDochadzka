using Data.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceTermianal
{
    public partial class frmTerminal : Form
    {
        private TerminalViewModel _terminalViewModel;
        private LogicTerminal _logic;
        public frmTerminal(LogicTerminal logic)
        {
            InitializeComponent();
            _logic = logic;
            _terminalViewModel = new TerminalViewModel(_logic);
            timer.Start();
        }

        private void CheckInternetConnection()
        {
            if (!Data.Shared.CheckConnection())
            {
                lblName.Text = "Connection not established";
                foreach (Control item in panelMain.Controls)
                {
                    item.Enabled = false;
                }
            }
            else
            {
                foreach (Control item in panelMain.Controls)
                {
                    item.Enabled = true;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = _terminalViewModel.CurrentDate();
            lblDay.Text = _terminalViewModel.CurrentDay();
            lblHour.Text = _terminalViewModel.CurrentHourmin();
            lblSec.Text = _terminalViewModel.CurrentSec();
            lblDateNow.Text = _terminalViewModel.DescriptionDate();
            CheckInternetConnection();
        }

        public bool CorrectEmp(string input)
        {
            bool test = false;
            if (!test)
            {
                if (_terminalViewModel.CorrectEmp(input))
                {
                    test = true;
                    return test;
                }
                else
                {
                    lblName.Text = ShowError();
                    timerClear.Start();
                }
            }
            return false;
        }

        private string ShowError()
        {
            return ("This Id does not exist");
        }

        private void timerClear_Tick(object sender, EventArgs e)
        {
            lblDateNow.Text = _terminalViewModel.DescriptionDate();
            lblWorkType.Text = "";
            lblName.Text = "";
            txtEmpId.Clear();
            timerClear.Stop();
        }       

        private void DescribeAndCreateDailyResult(EnumWorkType type)
        {
            if (!string.IsNullOrEmpty(txtEmpId.Text))
            {
                if (CorrectEmp(txtEmpId.Text))
                {
                    int employeeId = int.Parse(txtEmpId.Text);
                    if (type == EnumWorkType.Exit)
                    {
                        _terminalViewModel.ExitDailyResult(employeeId);
                    }
                    else
                    {
                        _terminalViewModel.CreateNewDailyResult(employeeId, type);
                    }
                    Describe(employeeId, type);
                    timerClear.Start();
                }
            }
            else
            {
                lblName.Text = ShowError();
                timerClear.Start();
            }
        }

        private void Describe(int employeeId, EnumWorkType type)
        {
            lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
            lblDateNow.Text = _terminalViewModel.DescriptionDate();
            lblWorkType.Text = _terminalViewModel.DescriptionWorkType(type);
        }
        
        #region Buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.Exit);
        }
        private void btnLunch_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.Lunch);
        }

        private void btnBTrip_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.BusinessTrip);
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.Doctor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.Private);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            DescribeAndCreateDailyResult(EnumWorkType.Work);
        }
        #endregion
    }
}
