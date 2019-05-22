using Data.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class MonthOverviewView : Form
    {
        private MonthOverviewViewModel _monthOverviewView;

        public MonthOverviewView(List<DaySummary> daySummaries)
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
