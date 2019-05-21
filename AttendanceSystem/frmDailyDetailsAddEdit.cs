using Data.Model;
using Logic;
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
    public partial class frmDailyDetailsAddEdit : Form
    {
        private DailyDetailsAddEditViewModel _dailyDetailsAddEditViewModel;
        private LogicSystem _logic;
        private int _selectedEmployeeId;
        private DailyRecord _dailyResultToUpdate =null;
        private DateTime _date;

        public frmDailyDetailsAddEdit(int selectedEmployeeID, DateTime date, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _dailyDetailsAddEditViewModel = new DailyDetailsAddEditViewModel(_logic);
            _selectedEmployeeId = selectedEmployeeID;
            _date = date;
            dateTimePickerFinish.BringToFront();
            comboBoxWorkTypes.BringToFront();
            FormatTimePickers();
            FillComboBox();

        }

        public frmDailyDetailsAddEdit(int selectedEmployeeID, DateTime date, DailyRecord dailyResultToUpdate, LogicSystem logic)
        {
            InitializeComponent();
            _logic = logic;
            _selectedEmployeeId = selectedEmployeeID;
            _date = date;
            _dailyResultToUpdate = dailyResultToUpdate;

            
            FormatTimePickers();
            FillComboBox();

        }

        private void FormatTimePickers()
        {
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm:ss ";
            dateTimePickerFinish.Format = DateTimePickerFormat.Custom;
            dateTimePickerFinish.CustomFormat = "HH:mm:ss ";
            if (_dailyResultToUpdate == null)
            {
                dateTimePickerStart.Value =  _date ;
                dateTimePickerFinish.Value = _date.AddHours(1);
            }
            else
            {
                dateTimePickerStart.Value = _dailyResultToUpdate.Start;
                dateTimePickerFinish.Value = (_dailyResultToUpdate.Finish == null) ? _dailyResultToUpdate.Start.AddHours(1) : (DateTime)_dailyResultToUpdate.Finish;
            }
        }

        private void FillComboBox()
        {
            comboBoxWorkTypes.Items.AddRange(_dailyDetailsAddEditViewModel.GetWorkTypes().ToArray());
            comboBoxWorkTypes.SelectedIndex = (_dailyResultToUpdate == null) ? 0 : _dailyResultToUpdate.IdWorktype-1;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_dailyResultToUpdate == null)
            {
                if (_dailyDetailsAddEditViewModel.CreateNewDailyResult(_selectedEmployeeId, dateTimePickerStart.Value,
                    dateTimePickerFinish.Value, comboBoxWorkTypes.SelectedIndex+1))
                {
                    MessageBox.Show("Record added succesfully");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error happend during process\n" +
                                "try tu restart the program, check connection\n" +
                                "if problem persists contact tech support");
                }
            }
            else
            {
                _dailyResultToUpdate.Start = dateTimePickerStart.Value;
                _dailyResultToUpdate.Finish = dateTimePickerFinish.Value;
                _dailyResultToUpdate.IdWorktype = comboBoxWorkTypes.SelectedIndex+1;

                if (_dailyDetailsAddEditViewModel.UpdateDailyResult(_dailyResultToUpdate))
                {

                    MessageBox.Show("Record updated succesfully");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error happend during process\n" +
                                "try tu restart the program, check connection\n" +
                                "if problem persists contact tech support");
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBoxWorkTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
