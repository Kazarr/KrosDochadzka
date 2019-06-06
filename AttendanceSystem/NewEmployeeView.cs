using Data.Model;
using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceSystem
{

    public partial class NewEmployeeView : Form
    {
        private NewEmployeeViewModel _newEmployeeViewModel;
        private LogicSystem _logic;

        public NewEmployeeView(LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _newEmployeeViewModel = new NewEmployeeViewModel(_logic);
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions(EnumPermissions.Admin);
            _newEmployeeViewModel = new NewEmployeeViewModel(_logic);
        }

        public NewEmployeeView(Person person, Employee employee, LogicSystem logic, EnumPermissions permissions)
        {

            InitializeComponent();
            _logic = logic;
            _newEmployeeViewModel = new NewEmployeeViewModel(person, employee, _logic);
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbSupervisors.SelectedIndex = cmbSupervisors.FindStringExact(_newEmployeeViewModel.GetSupervisor(employee.IdSupervisor).ToString());
            textBoxFirstName.Text = _newEmployeeViewModel.Person.FirstName;
            textBoxLastName.Text = _newEmployeeViewModel.Person.LastName;
            textBoxPhoneNumber.Text = _newEmployeeViewModel.Person.PhoneNumber;
            textAdress.Text = _newEmployeeViewModel.Person.Adress;
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions(permissions);
            cmbPermissions.SelectedItem = _newEmployeeViewModel.EmployeePermission(employee);
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
                _newEmployeeViewModel.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, 
                    textAdress.Text, permision, cmbSupervisors.Enabled==true?(Person)cmbSupervisors.SelectedItem : null, 
                    textBoxPassword.Text);
            }
            else
            {
                _newEmployeeViewModel.UpdateEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text,
                    textAdress.Text, permision, cmbSupervisors.Enabled == true ? (Person)cmbSupervisors.SelectedItem : null);
            }


                
                DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbPermissions_SelectedValueChanged(object sender, EventArgs e)
        {
  
        }

        private void cmbPermissions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPermissions.SelectedIndex == (int)EnumPermissions.Employee - 1)
            {
                cmbSupervisors.Enabled = true;
                cmbSupervisors.SelectedIndex = 0;

            }
            else
            {
                cmbSupervisors.Text = String.Empty;
                cmbSupervisors.Enabled = false;
            }
        }
    }
}
