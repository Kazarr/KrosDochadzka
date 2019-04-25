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
    public partial class frmDailyDetails : Form
    {
        private int _loggedEmployeeId;
        private DailyResultViewModel _dailyResultViewModel = new DailyResultViewModel();

        public frmDailyDetails(int id)
        {
            _loggedEmployeeId = id;
            InitializeComponent();
        }

        private void frmDailyDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult  = DialogResult.OK;
        }
    }
}
