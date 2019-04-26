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
            textBoxSalary.Text = _newEmployeeViewModel.Empolyee.Salary.ToString();
            textBoxPermisions.Text = _newEmployeeViewModel.Empolyee.Permision.ToString();
            textBoxPassword.Text = _newEmployeeViewModel.Empolyee.Password;
            textBoxConfirmPassword.Text = _newEmployeeViewModel.Empolyee.Password;
        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            decimal salary;
            int permision;
            if (decimal.TryParse(textBoxSalary.Text, out salary)) { }
            if (int.TryParse(textBoxPermisions.Text, out permision)) { }
            if (_newEmployeeViewModel.Empolyee.Id == 0)
            {
                _newEmployeeViewModel.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, salary, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                _newEmployeeViewModel.UpdateEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, salary, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
                DialogResult = DialogResult.OK;
            }
            
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
