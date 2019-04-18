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
    public partial class FrmMainWindow : Form
    {
        public FrmMainWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmNewEmployee newEmployee = new frmNewEmployee();
            newEmployee.ShowDialog();
        }

        private void btnShowMonth_Click(object sender, EventArgs e)
        {
            frmMonthOverview monthOverview = new frmMonthOverview();
            monthOverview.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you serious?", "Delete faggot", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
