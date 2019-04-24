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
        private NewEmployeeViewModel _newEmployee;
        //private int _employeeID;

        public frmNewEmployee()
        {
            InitializeComponent();
            cmbSupervisors.DataSource = _newEmployee.FillSupervisors();
            _newEmployee = new NewEmployeeViewModel();
        }

        public frmNewEmployee(int employeeID)
        {
            InitializeComponent();
            //_newEmployee = new NewEmployeeViewModel();
            _newEmployee = new NewEmployeeViewModel(employeeID);

            //_newEmployee.Empolyee = _newEmployee.ge
            cmbSupervisors.DataSource = _newEmployee.FillSupervisors();
            cmbSupervisors.SelectedIndex = cmbSupervisors.Items.IndexOf(_newEmployee.GetPersonByEmployeeId(employeeID));
            textBoxFirstName.Text = _newEmployee.Person.FirstName;
            textBoxLastName.Text = _newEmployee.Person.LastName;
            textBoxPhoneNumber.Text = _newEmployee.Person.PhoneNumber;
            textAdress.Text = _newEmployee.Person.Adress;

        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            decimal salary;
            int permision;
            if (decimal.TryParse(textBoxSalary.Text, out salary)) { }
            if (int.TryParse(textBoxPermisions.Text, out permision)) { }
            //DialogResult = DialogResult.OK;
            if (_newEmployee.Empolyee.Id != 0)
            {
                _newEmployee.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, salary, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
            }
            else
            {
                _newEmployee.UpdateEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textAdress.Text, salary, permision, (Person)cmbSupervisors.SelectedItem, textBoxPassword.Text);
            }
            
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
