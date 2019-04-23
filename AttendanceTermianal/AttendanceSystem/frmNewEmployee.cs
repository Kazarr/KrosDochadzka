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
        private NewEmployeeViewModel _newEmployee = new NewEmployeeViewModel();

        public frmNewEmployee()
        {
            InitializeComponent();
            cmbSupervisors.DataSource = _newEmployee.FillSupervisors();
        }      

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            decimal salary;
            int permision;
            if(decimal.TryParse(textBoxSalary.Text, out salary)) { }
            if(int.TryParse(textBoxPermisions.Text, out permision))
            DialogResult = DialogResult.OK;

            _newEmployee.AddNewEmployee(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textBoxStreetName.Text, textBoxHomeNumber.Text, salary, permision, (Person)cmbSupervisors.SelectedItem,textBoxPassword.Text);
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
