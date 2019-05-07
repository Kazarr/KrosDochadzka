using Data.Model;
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

    public partial class frmNewEmployee : Form
    {
        private NewEmployeeViewModel _newEmployeeViewModel;


        public frmNewEmployee()
        {
            InitializeComponent();
            _newEmployeeViewModel = new NewEmployeeViewModel();
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions();
            _newEmployeeViewModel = new NewEmployeeViewModel();
        }

        public frmNewEmployee(Person person, Empolyee empolyee)
        {
            InitializeComponent();
            _newEmployeeViewModel = new NewEmployeeViewModel(person, empolyee);
            cmbSupervisors.DataSource = _newEmployeeViewModel.FillSupervisors();
            cmbSupervisors.SelectedIndex = cmbSupervisors.FindStringExact(_newEmployeeViewModel.GetSupervisor(empolyee.IdSupervisor).ToString());
            textBoxFirstName.Text = _newEmployeeViewModel.Person.FirstName;
            textBoxLastName.Text = _newEmployeeViewModel.Person.LastName;
            textBoxPhoneNumber.Text = _newEmployeeViewModel.Person.PhoneNumber;
            textAdress.Text = _newEmployeeViewModel.Person.Adress;
            //textBoxPermisions.Text = _newEmployeeViewModel.Empolyee.Permision.ToString();
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions();
            cmbPermissions.SelectedItem = _newEmployeeViewModel.EmployeePermission(empolyee);
            textBoxPassword.Visible = false;
            //textBoxConfirmPassword.Visible = false;
            //lblUserConfirmPassword.Visible = false;
            //lblUserPassword.Visible = false;
        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            int permision = _newEmployeeViewModel.EmployeePermissionId((string)cmbPermissions.SelectedItem);
            
            if (_newEmployeeViewModel.Empolyee.Id == 0)
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

        private void frmNewEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
