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
    public partial class GenerateDataView : Form
    {
        //public int EmployeeCount { get; set; }
        private MainWindowViewModel _mainWindowViewModel;
        public GenerateDataView(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            _mainWindowViewModel = mainWindowViewModel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _mainWindowViewModel.EmployeeToGenerate = int.Parse(txtEmployeeCount.Text);
        }

        private void txtEmployeeCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
