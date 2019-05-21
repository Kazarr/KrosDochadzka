using com.rusanu.dataconnectiondialog;
using Logic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class FrmLogin : Form
    {
        private LoginViewModel _loginViewModel;
        private LogicSystem _logic;

        public FrmLogin(LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _loginViewModel = new LoginViewModel(_logic);
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
                    FrmMainWindow frmMainWindow = new FrmMainWindow(Convert.ToInt32(textBoxLogin.Text), _logic);
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseServer_Click(object sender, EventArgs e)
        {
            DataConnectionDialog dlg = new DataConnectionDialog(_loginViewModel.GetSqlConnectionStringBuilder());
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //Use the connection properties
                using (SqlConnection conn = new SqlConnection(dlg.ConnectionStringBuilder.ConnectionString))
                {
                    _loginViewModel.SaveConnectionString(conn.ConnectionString);
                    if (!_loginViewModel.HasDatabase())
                    {
                        _loginViewModel.SaveConnectionString(conn.ConnectionString);
                        dlg.ConnectionStringBuilder.InitialCatalog = _loginViewModel.GenerateDb();
                        _loginViewModel.SaveConnectionString(dlg.ConnectionStringBuilder.ConnectionString);
                        _loginViewModel.GenerateTables();
                    }
                    dlg.ConnectionStringBuilder.InitialCatalog = _loginViewModel.GenerateDb();
                    _loginViewModel.SaveConnectionString(dlg.ConnectionStringBuilder.ConnectionString);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
