using Logic;
using System;
using System.Windows.Forms;

namespace AttendanceSystem
{
    public partial class FrmDailyDetails : Form
    {
        private int _loggedEmployeeId;
        private int _selectedEmployeeId;
        private DateTime _thisDate;
        private DailyDetailsViewModel _dailyDetailsViewModel = new DailyDetailsViewModel();
        private LogicSystem _logic;

        public FrmDailyDetails(int loggedEmployeeId, DateTime date, int selectedEmployeeId, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _loggedEmployeeId = loggedEmployeeId;
            _thisDate = date;
            _selectedEmployeeId = selectedEmployeeId;
            FillDataGridView();
            CheckPermission();
        }

        /// <summary>
        /// checks if the logged person got rights to edit
        /// </summary>
        private void CheckPermission()
        {
            if (_dailyDetailsViewModel.GetEmpolyeeById(_loggedEmployeeId).Permision > 1)
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
        }

        private void FillDataGridView()
        {
            bindingSource1.DataSource = _dailyDetailsViewModel.GetDailyResultWithWorkTypes(_selectedEmployeeId, _thisDate);
        }




        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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
        }



        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FrmDailyDetailsAddEdit frmDailyDetailsAdd = new FrmDailyDetailsAddEdit(_selectedEmployeeId, _thisDate, _logic);
            frmDailyDetailsAdd.ShowDialog();
            FillDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmDailyDetailsAddEdit frmDailyDetailsEdit = new FrmDailyDetailsAddEdit(
                _selectedEmployeeId, 
                _thisDate, 
                _dailyDetailsViewModel.GetDailyResultById(Convert.ToInt32(dGVDailyResultsOverview.Rows[dGVDailyResultsOverview.CurrentCell.RowIndex].Cells[0].Value)),
                _logic);
            frmDailyDetailsEdit.ShowDialog();
            FillDataGridView();
        }

    }
}
