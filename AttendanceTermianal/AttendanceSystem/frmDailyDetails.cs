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
    public partial class frmDailyDetails : Form
    {
        private int _loggedEmployeeId;
        private int _selectedEmployeeId;
        private DateTime _thisDate;
        private DailyDetailsViewModel _dailyDetailsViewModel = new DailyDetailsViewModel();

        public frmDailyDetails(int loggedEmployeeId,DateTime date,int selectedEmployeeId)
        {
            _loggedEmployeeId = loggedEmployeeId;
            _thisDate = date;
            _selectedEmployeeId = selectedEmployeeId;
            InitializeComponent();
            FillDataGridView();
            CheckPermission();
        }
        /// <summary>
        /// checks if the logged person got rights to edit
        /// </summary>
        private void CheckPermission()
        {
            if (_dailyDetailsViewModel.GetEmpolyeeById(_loggedEmployeeId).Permision>1)
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
        }

        private void FillDataGridView()
        {
            dGVDailyResultsOverview.DataSource = _dailyDetailsViewModel.GetDailyResultWithWorkTypes(_selectedEmployeeId, _thisDate);
            dGVDailyResultsOverview.Columns["DailyResultID"].Visible = false;
            dGVDailyResultsOverview.Columns["IdEmployee"].Visible = false;
        }


 

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult  = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This action will permanently delete record are you serious?", "Delete Record", MessageBoxButtons.YesNo);
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
                    FillDataGridView();

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

   

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmDailyDetailsAddEdit frmDailyDetailsAdd = new frmDailyDetailsAddEdit(_selectedEmployeeId,_thisDate);
            frmDailyDetailsAdd.ShowDialog();
            FillDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmDailyDetailsAddEdit frmDailyDetailsEdit = new frmDailyDetailsAddEdit(_selectedEmployeeId,_thisDate,_dailyDetailsViewModel.GetDailyResultById(Convert.ToInt32(dGVDailyResultsOverview.Rows[dGVDailyResultsOverview.CurrentCell.RowIndex].Cells[0].Value)));
            frmDailyDetailsEdit.ShowDialog();
            FillDataGridView();

        }
    }
}
