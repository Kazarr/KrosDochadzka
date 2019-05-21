using Data.Model;
using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceTermianal
{
    public partial class FrmTerminal : Form
    {
        private TerminalViewModel _terminalViewModel;
        private LogicTerminal _logic;
        public FrmTerminal(LogicTerminal logic)
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
                panelBtnsAndTxtBox.Enabled = false;
            }
            else
            {
                panelBtnsAndTxtBox.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.DateFormat();
            lblDay.Text = DateTime.Now.DayFormat();
            lblHour.Text = DateTime.Now.HourMinFormat();
            lblSec.Text = DateTime.Now.SecondsFormat();
            lblDateNow.Text = DateTime.Now.DateDescription();
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

        private void TimerClear_Tick(object sender, EventArgs e)
        {
            lblDateNow.Text = DateTime.Now.DateDescription();
            lblWorkType.Text = "";
            lblName.Text = "";
            txtEmpId.Clear();
            timerClear.Stop();
        }       

        private void DescribeAndProcessAction(EnumWorkType type)
        {
            if (!string.IsNullOrEmpty(txtEmpId.Text))
            {
                if (CorrectEmp(txtEmpId.Text))
                {
                    int employeeId = int.Parse(txtEmpId.Text);
                    if (type == EnumWorkType.Exit)
                    {
                        _terminalViewModel.ExitDailyRecord(employeeId);
                    }
                    else
                    {
                        _terminalViewModel.CreateNewAndFinishPreviousRecord(employeeId, type);
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
            lblDateNow.Text = DateTime.Now.DateDescription();
            lblWorkType.Text = type.ToString();
        }
        
        #region Buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.Exit);
        }
        private void btnLunch_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.Lunch);
        }

        private void btnBTrip_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.BusinessTrip);
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.Doctor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.Private);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            DescribeAndProcessAction(EnumWorkType.Work);
        }
        #endregion
    }
}
