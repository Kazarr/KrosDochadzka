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
        private MonthOverviewViewModel _monthOverviewView = new MonthOverviewViewModel();
        public frmMonthOverview()
        {
            InitializeComponent();

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
