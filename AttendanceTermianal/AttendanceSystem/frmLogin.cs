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
    public partial class frmLogin : Form
    {
        LoginViewModel _loginViewModel = new LoginViewModel();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (_loginViewModel.CheckLogin(Convert.ToInt32(textBoxLogin.Text), textBoxPassword.Text))
                {
                FrmMainWindow frmMainWindow = new FrmMainWindow(Convert.ToInt32(textBoxLogin.Text));
                frmMainWindow.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong Password","Retard");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
