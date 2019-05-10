using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class frmMonthOverview : Form
    {
        private MonthOverviewViewModel _monthOverviewView;

        public frmMonthOverview(List<DaySummary> daySummaries)
        {
            InitializeComponent();
            _monthOverviewView = new MonthOverviewViewModel(daySummaries);
            labelHours.Text = _monthOverviewView.GetTotalHours();
            labelOvertime.Text = _monthOverviewView.GetOverTime();
            labelBussinessTrip.Text = _monthOverviewView.GetBSTripTime();
            labelHoliday.Text = _monthOverviewView.GetHolidayTime();
            labelSickDays.Text = _monthOverviewView.GetSickTime();
            labelHomeOffice.Text = _monthOverviewView.GetHomeOfficeTime();

                
                }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


    }
}
