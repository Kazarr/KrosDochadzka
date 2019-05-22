using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class PasswordChangeView : Form
    {
        private int _employeeId;
        private PasswordChangeViewModel _passwordChangeViewModel;
        private LogicSystem _logic;

        public PasswordChangeView(int employeeId, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _passwordChangeViewModel = new PasswordChangeViewModel(_logic, employeeId);
            _employeeId = employeeId;
            BindControls();
        }

        private void BindControls()
        {
            lblMessage.DataBindings.Add
                (nameof(lblMessage.Text),
                _passwordChangeViewModel,
                nameof(_passwordChangeViewModel.UserMessage),
                false,
                DataSourceUpdateMode.OnValidation);

            txtOldPass.DataBindings.Add
                (nameof(txtOldPass.Text),
                _passwordChangeViewModel,
                nameof(_passwordChangeViewModel.OldPass),
                false, DataSourceUpdateMode.OnValidation);

            txtNewPass.DataBindings.Add
                (nameof(txtNewPass.Text),
                _passwordChangeViewModel,
                nameof(_passwordChangeViewModel.NewPass),
                false, DataSourceUpdateMode.OnValidation);

            txtConfirmPass.DataBindings.Add
                (nameof(txtConfirmPass.Text),
                _passwordChangeViewModel,
                nameof(_passwordChangeViewModel.ConfirmPass),
                false, DataSourceUpdateMode.OnValidation);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _passwordChangeViewModel.ChangePassword();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
