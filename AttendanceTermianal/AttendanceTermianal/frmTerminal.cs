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
                    return true;
                }
                else
                {
                    MessageBox.Show("This Id does not exist");
                }
            }
            return false;
        }
        private void ChangeWorkType(EWorkType type)
        {
            if (CorrectEmp(txtEmpId.Text))
            {
                int employeeId = int.Parse(txtEmpId.Text);
                _terminalViewModel.ChangeWorkType(employeeId, type);
                lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
                lblDateNow.Text = _terminalViewModel.DescriptionDate();
                lblWorkType.Text = _terminalViewModel.DescriptionWorkType(type.ToString());
            }
        }
        private void btnArrival_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Work);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            int employeeId = int.Parse(txtEmpId.Text);
            _terminalViewModel.FinishWork(employeeId, EWorkType.Exit);
            lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
            lblDateNow.Text = _terminalViewModel.DescriptionDate();
            lblWorkType.Text = _terminalViewModel.DescriptionWorkType(nameof(EWorkType.Exit));
        }
        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    ChangeWorkType(EWorkType.Exit);
        //}
        private void btnLunch_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Lunch);
        }
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Doctor);
        }
        private void btnBusinessTrip_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.BusinessTrip);
        }
        private void btnPrivate_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Private);
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            ChangeWorkType(EWorkType.Other);
        }

        private void picEntry_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeWorkType(EWorkType.Work);
        }

        private void picExit_MouseClick(object sender, MouseEventArgs e)
        {
            int employeeId = int.Parse(txtEmpId.Text);

            _terminalViewModel.FinishWork(employeeId, EWorkType.Exit);
            lblName.Text = _terminalViewModel.DescriptionFullname(employeeId);
            lblDateNow.Text = _terminalViewModel.DescriptionDate();
            lblWorkType.Text = _terminalViewModel.DescriptionWorkType(nameof(EWorkType.Exit));
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
    }
}
