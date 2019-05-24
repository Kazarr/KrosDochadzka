using Data.Model;
using Logic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AttendanceTermianal
{
    public partial class TerminalView : Form
    {
        private TerminalViewModel _terminalViewModel;
        private LogicTerminal _logic;
        public TerminalView(LogicTerminal logic)
        {
            InitializeComponent();
            _logic = logic;
            _terminalViewModel = new TerminalViewModel(_logic);
            timerCurrentDateTime.Start();
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

        private void timerCurrentDateTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.DateFormat();
            lblDay.Text = DateTime.Now.DayFormat();
            lblHour.Text = DateTime.Now.HourMinFormat();
            lblSec.Text = DateTime.Now.SecondsFormat();
            lblDateNow.Text = DateTime.Now.DateDescription();
            CheckInternetConnection();
        }

        private string ShowError()
        {
            return ("This Id does not exist");
        }

        private void TimerClear_Tick(object sender, EventArgs e)
        {
            lblDateNow.Text = DateTime.Now.DateDescription();
            lblWorkType.Text = string.Empty;
            lblName.Text = string.Empty;
            txtEmpIdNum.Text = string.Empty;
            timerClearDisplay.Stop();
        }

        private void DescribeAndProcessAction(EnumWorkType type)
        {
            if (string.IsNullOrWhiteSpace(txtEmpIdNum.Text))
            {
                lblName.Text = ShowError();
                timerClearDisplay.Start();
            }
            else
            {
                int employeeId = Convert.ToInt32(txtEmpIdNum.Text);

                if (_terminalViewModel.IsCorrectEmp(employeeId))
                {
                    _terminalViewModel.ProcessAction(employeeId, type);
                    Describe(employeeId, type);
                    timerClearDisplay.Start();
                }
                else
                {
                    lblName.Text = ShowError();
                    timerClearDisplay.Start();
                }
            }        }

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

        private void txtEmpIdNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
