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
            textBoxFirstName.Text = _newEmployeeViewModel.Pperson.FirstName;
            textBoxLastName.Text = _newEmployeeViewModel.Pperson.LastName;
            textBoxPhoneNumber.Text = _newEmployeeViewModel.Pperson.PhoneNumber;
            textBoxAddress.Text = _newEmployeeViewModel.Pperson.Adress;
            textBoxPermisions.Text = _newEmployeeViewModel.Eempolyee.Permision.ToString();
            cmbPermissions.DataSource = _newEmployeeViewModel.FillPermissions();
            cmbPermissions.SelectedItem = _newEmployeeViewModel.EmployeePermission(empolyee);
            textBoxPassword.Visible = false;
            textBoxConfirmPassword.Visible = false;
            lblUserConfirmPassword.Visible = false;
            lblUserPassword.Visible = false;
        }

        private void BindData()
        {
            textBoxFirstName.DataBindings.Add(nameof(textBoxFirstName.Text), _newEmployeeViewModel,
                nameof(_newEmployeeViewModel.Pperson.FirstName),
                true,
                DataSourceUpdateMode.OnValidation);

            textBoxLastName.DataBindings.Add(nameof(textBoxLastName.Text), _newEmployeeViewModel,
                nameof(_newEmployeeViewModel.Pperson.LastName),
                true,
                DataSourceUpdateMode.OnValidation);

            textBoxPhoneNumber.DataBindings.Add(nameof(textBoxPhoneNumber.Text), _newEmployeeViewModel,
                nameof(_newEmployeeViewModel.Pperson.PhoneNumber),
                true,
                DataSourceUpdateMode.OnValidation);

            .DataBindings.Add(nameof(textBoxFirstName.Text), _newEmployeeViewModel,
                nameof(_newEmployeeViewModel.Pperson.FirstName),
                true,
                DataSourceUpdateMode.OnValidation);

            cmbPermissions.DataBindings.Add(nameof(cmbPermissions.SelectedIndex), _newEmployeeViewModel,
                nameof(_newEmployeeViewModel.Eempolyee.Permision),
                true,
                DataSourceUpdateMode.OnValidation);


        }



        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            int permision = _newEmployeeViewModel.EmployeePermissionId((string)cmbPermissions.SelectedItem);
            
            if (_newEmployeeViewModel.Eempolyee.Id == 0)
            {
                _newEmployeeViewModel.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textBoxAddress.Text, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                _newEmployeeViewModel.UpdateEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textBoxAddress.Text, permision, (Person)cmbSupervisors.SelectedItem);
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
