﻿using System;
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
        }      

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
