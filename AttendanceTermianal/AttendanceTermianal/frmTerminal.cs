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
        private TerminalViewModel _terminalViewModel = new TerminalViewModel();
        private int _tick;

        public frmTerminal()
        {
            InitializeComponent();

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
                    lblName.Text= ShowError();
                    timerClear.Start();
                }
            }
            return false;
        }

        private string ShowError()
        {
            return ("This Id does not exist");
        }
        private void ChangeWorkType(EWorkType type)
        {            
            if (!string.IsNullOrEmpty(txtEmpId.Text))
            {
                if (CorrectEmp(txtEmpId.Text))
                {
                    _tick = 0;
                    int employeeId = int.Parse(txtEmpId.Text);
                    _terminalViewModel.ChangeWorkType(employeeId, type);
                    lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
                    lblDateNow.Text = _terminalViewModel.DescriptionDate();
                    lblWorkType.Text = _terminalViewModel.DescriptionWorkType(type.ToString());
                    txtEmpId.Clear();
                    timerClear.Start();
                }
            }
            else
            {
                lblName.Text = ShowError();
                timerClear.Start();
            }
        }
        private void timerClear_Tick(object sender, EventArgs e)
        {
            _tick++;
            if (_tick == 25)
            {
                lblDateNow.Text = _terminalViewModel.DescriptionDate();
                lblWorkType.Text="";
                lblName.Text = "";
                txtEmpId.Clear();
            }
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Lunch);
        }

        private void btnBTrip_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.BusinessTrip);
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Doctor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Private);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Work);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmpId.Text))
            {
                if (CorrectEmp(txtEmpId.Text))
                {
                    _tick = 0;
                    int employeeId = int.Parse(txtEmpId.Text);
                    _terminalViewModel.FinishWork(employeeId, EWorkType.Exit);
                    lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
                    lblDateNow.Text = _terminalViewModel.DescriptionDate();
                    lblWorkType.Text = _terminalViewModel.DescriptionWorkType(nameof(EWorkType.Exit));
                    txtEmpId.Clear();
                    timerClear.Start();
                }
            }
            else
            {
                lblName.Text = ShowError();
                timerClear.Start();
                txtEmpId.Clear();
            }
        }
    }
}
