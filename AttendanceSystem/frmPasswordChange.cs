using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class frmPasswordChange : Form
    {
        private int _employeeId;
        private PasswordChangeViewModel _passwordChangeViewModel;
        private LogicSystem _logic;
        public frmPasswordChange(int id, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _passwordChangeViewModel = new PasswordChangeViewModel(_logic);
            _employeeId = id;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ChangePass(_employeeId,txtOldPass.Text,txtNewPass.Text,txtConfirmPass.Text);
        }

        private bool CheckCurrentPass(int idEmploye, string oldPass)
        {
            if (_passwordChangeViewModel.CheckOldPass(idEmploye,oldPass))
            {
                return true;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = MessageWrongOldPass();
                return false;
            }
        }

        private bool CompareNewPass(string newPass, string confirmPass)
        {
            if (_passwordChangeViewModel.CompareNewPass(newPass,confirmPass))
            {
                return true;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = MessageNewPassDontMatch();
                return false;
            }
        }

        private void ChangePass(int idEmploye, string oldPass, string newPass, string confirmPass)
        {
            if (CheckCurrentPass(idEmploye, oldPass) && CompareNewPass(newPass, confirmPass))
            {
                _passwordChangeViewModel.ChangePassword(idEmploye, newPass);
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text= MessageChangedSuccessfully();
            }
        }

        private string MessageWrongOldPass()
        {
            return ("Current password is wrong");
        }

        private string MessageNewPassDontMatch()
        {
            return ("The new password does not match");
        }

        private string MessageChangedSuccessfully()
        {
            return ("Password has been changed successfully");
        }
    }
}
