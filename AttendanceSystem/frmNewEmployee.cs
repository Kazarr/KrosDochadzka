using Data.Model;
using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceSystem
{

    public partial class FrmNewEmployee : Form
    {
        private NewEmployeeViewModel _newEmployeeViewModel;
        private LogicSystem _logic;

        public FrmNewEmployee(LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _newEmployeeViewModel = new NewEmployeeViewModel();
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions();
            _newEmployeeViewModel = new NewEmployeeViewModel();
        }

        public FrmNewEmployee(Person person, Employee empolyee, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _newEmployeeViewModel = new NewEmployeeViewModel(person, empolyee);
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbSupervisors.SelectedIndex = cmbSupervisors.FindStringExact(_newEmployeeViewModel.GetSupervisor(empolyee.IdSupervisor).ToString());
            textBoxFirstName.Text = _newEmployeeViewModel.Person.FirstName;
            textBoxLastName.Text = _newEmployeeViewModel.Person.LastName;
            textBoxPhoneNumber.Text = _newEmployeeViewModel.Person.PhoneNumber;
            textAdress.Text = _newEmployeeViewModel.Person.Adress;
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions();
            cmbPermissions.SelectedItem = _newEmployeeViewModel.EmployeePermission(empolyee);
            textBoxPassword.Visible = false;
            /// <summary>
            /// in case this form is used on updating info, we need to hide "Password" line, thats why this line is here and not in designer
            /// </summary>
            panel2.Height=296;

        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            int permision = _newEmployeeViewModel.EmployeePermissionId((string)cmbPermissions.SelectedItem);
            
            if (_newEmployeeViewModel.Employee.Id == 0)
            {
                _newEmployeeViewModel.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                _newEmployeeViewModel.UpdateEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, permision, (Person)cmbSupervisors.SelectedItem);
                DialogResult = DialogResult.OK;
            }
            
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmNewEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
