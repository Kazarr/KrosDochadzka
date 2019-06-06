using com.rusanu.dataconnectiondialog;
using Logic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class LoginView : Form
    {
        private LoginViewModel _loginViewModel;
        private LogicSystem _logic;

        public LoginView(LogicSystem logic)
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
                    MainWindowView frmMainWindow = new MainWindowView(Convert.ToInt32(textBoxLogin.Text), _logic);
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

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
