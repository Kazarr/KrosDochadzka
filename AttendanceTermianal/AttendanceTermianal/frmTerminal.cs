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
        enum WorkType
        {
            Work = 1,
            Lunch = 2,
            Holiday =3,
            HomeOffice =4,
            BusinessTrip=5,
            Doctor = 6,
            Private =7,
            Other =8,
            Exit =9
        }
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
            if (CorrectEmp(txtEmpId.Text))
            {
                _terminalViewModel.FinishWork(CorrectId(txtEmpId.Text));
                _terminalViewModel.StartWork(CorrectId(txtEmpId.Text), (int)WorkType.Work);
                label3.Text = _terminalViewModel.EmployeeDescription(CorrectId(txtEmpId.Text), nameof(WorkType.Work));
            }
        }

        public int CorrectId(string input)
        {
            bool test = false;
            while (!test)
            {
                if (_terminalViewModel.IsCorrectId(input).Item1)
                {
                    test = _terminalViewModel.IsCorrectId(input).Item1;
                    return _terminalViewModel.IsCorrectId(input).Item2;
                }
                else
                {
                    MessageBox.Show("Incorrect Id");
                }
            }
            return _terminalViewModel.IsCorrectId(input).Item2;
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
                    MessageBox.Show("napiču");
                }                
            }return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _terminalViewModel.FinishWork(CorrectId(txtEmpId.Text));
            label3.Text = _terminalViewModel.EmployeeDescription(CorrectId(txtEmpId.Text),nameof(WorkType.Exit));
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            if (CorrectEmp(txtEmpId.Text))
            {
                _terminalViewModel.FinishWork(CorrectId(txtEmpId.Text));
                _terminalViewModel.StartWork(CorrectId(txtEmpId.Text), (int)WorkType.Lunch);
                label3.Text = _terminalViewModel.EmployeeDescription(CorrectId(txtEmpId.Text), nameof(WorkType.Lunch));
            }

        }
    }
}
