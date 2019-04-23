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
        private void ChangeType(EWorkType type)
        {
            if (CorrectEmp(txtEmpId.Text))
            {
                int employeeId = int.Parse(txtEmpId.Text);
                _terminalViewModel.ChangeWorkType(type, employeeId);
                label3.Text = _terminalViewModel.EmployeeDescription(employeeId, type.ToString());
            }
        }
        private void btnArrival_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.Work);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            int employeeId = int.Parse(txtEmpId.Text);
            _terminalViewModel.FinishWork(employeeId);
            label3.Text = _terminalViewModel.EmployeeDescription(employeeId, nameof(EWorkType.Exit));
        }
        private void btnLunch_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.Lunch);
        }
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.Doctor);
        }
        private void btnBusinessTrip_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.BusinessTrip);
        }
        private void btnPrivate_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.Private);
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            ChangeType(EWorkType.Other);
        }
    }
}
