using com.rusanu.dataconnectiondialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            if (Data.Shared.CheckConnection())
            {
                if (_loginViewModel.CheckLogin(Convert.ToInt32(textBoxLogin.Text), textBoxPassword.Text))
                {
                    FrmMainWindow frmMainWindow = new FrmMainWindow(Convert.ToInt32(textBoxLogin.Text));
                    frmMainWindow.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }
            else
            {
                MessageBox.Show("Connection not established");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseServer_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            // Set desired properties on the connection
            scsb.IntegratedSecurity = true;
            scsb.InitialCatalog = "master";
            // Display the connection dialog
            DataConnectionDialog dlg = new DataConnectionDialog(scsb);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //Data.Properties.Settings.Default.ConnectionString = dlg.ConnectionStringBuilder.ConnectionString;
                //Use the connection properties
                using (SqlConnection conn = new SqlConnection(dlg.ConnectionStringBuilder.ConnectionString))
                {
                    Data.Properties.Settings.Default.ConnectionString = conn.ConnectionString;
                    Data.Properties.Settings.Default.Save();
                    //...
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
