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
    public partial class frmDailyDetails : Form
    {
        private int _loggedEmployeeId;
        private DateTime _thisDate;
        private DailyDetailsViewModel _dailyDetailsViewModel = new DailyDetailsViewModel();

        public frmDailyDetails(int id,DateTime date)
        {
            _loggedEmployeeId = id;
            _thisDate = date;          
            InitializeComponent();
            fillDataGridView();
        }

        private void fillDataGridView()
        {
            dGVDailyResultsOverview.DataSource = _dailyDetailsViewModel.GetDailyResultWithWorkTypes(_loggedEmployeeId, _thisDate);
            dGVDailyResultsOverview.Columns["DailyResultID"].Visible = false;
        }


        private void frmDailyDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult  = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you serious?", "Delete faggot", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dGVDailyResultsOverview.SelectedRows.Count > 0)
                {
                    
                    int selectedID = Convert.ToInt32(dGVDailyResultsOverview.Rows[dGVDailyResultsOverview.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    if (_dailyDetailsViewModel.DeleteDailyResultByID(selectedID))
                    {
                        MessageBox.Show("Record succesfully deleted");
                    }
                    else
                    {
                        MessageBox.Show("Error happend during process\n" +
                            "try tu restart the program, check connection\n" +
                            "if problem persists contact tech support");
                    }
                    fillDataGridView();

                }
                else
                {
                    MessageBox.Show("Select record first");
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
