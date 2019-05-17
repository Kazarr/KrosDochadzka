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
    public partial class frmPasswordChange : Form
    {
        private int _employeeId;
        private PasswordChangeViewModel _passwordChangeViewModel = new PasswordChangeViewModel();
        public frmPasswordChange(int id)
        {
            InitializeComponent();
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
