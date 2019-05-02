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
        private void timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = _terminalViewModel.CurrentDate();
            lblDay.Text = _terminalViewModel.CurrentDay();
            lblHour.Text = _terminalViewModel.CurrentHourmin();
            lblSec.Text = _terminalViewModel.CurrentSec();
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
                    ShowError();
                }
            }
            return false;
        }

        private void ShowError()
        {
            MessageBox.Show("This Id does not exist");
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
                ShowError();
            }
        }


        private void picEntry_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.Work);
        }

        private void picExit_MouseClick(object sender, MouseEventArgs e)
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
                ShowError();
            }
        }

        private void picLunch_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.Lunch);
        }

        private void picTrip_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.BusinessTrip);
        }

        private void picDoctor_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.Doctor);
        }

        private void picPrivate_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.Private);
        }

        private void timerClear_Tick(object sender, EventArgs e)
        {
            _tick++;
            if (_tick == 25)
            {
                lblName.Text = "Kros";
                lblDateNow.Text = _terminalViewModel.DescriptionDate();
                lblWorkType.Text="";
            }
        }
    }
}
