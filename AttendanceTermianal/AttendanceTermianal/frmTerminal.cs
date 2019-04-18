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

        private void btnArrival_Click(object sender, EventArgs e)
        {
            _terminalViewModel.StartWork(CorrectId(txtEmpId.Text), 1);
            label3.Text = _terminalViewModel.EmployeeDescription(CorrectId(txtEmpId.Text));
        }
        public int CorrectId(string input)
        {
            if (_terminalViewModel.IsCorrectId(input).Item1)
            {
                return _terminalViewModel.IsCorrectId(input).Item2;
            }
            else
            {
                MessageBox.Show("Insert number!!!");
            }
            return _terminalViewModel.IsCorrectId(input).Item2;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _terminalViewModel.FinishWork(CorrectId(txtEmpId.Text));
            label3.Text = _terminalViewModel.EmployeeDescription(CorrectId(txtEmpId.Text));
        }
    }
}
