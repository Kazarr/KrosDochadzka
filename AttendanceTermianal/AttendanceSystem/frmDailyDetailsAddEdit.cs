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
    public partial class frmDailyDetailsAddEdit : Form
    {
        private DailyDetailsAddEditViewModel _dailyDetailsAddEditViewModel = new DailyDetailsAddEditViewModel();
        private int _selectedEmployeeId;
        private DateTime _date;

        public frmDailyDetailsAddEdit(int selectedEmployeeID, DateTime date)
        {
            _selectedEmployeeId = selectedEmployeeID;
            _date = date;

            InitializeComponent();
            FormatTimePickers();
            FillComboBox();

        }

        private void FormatTimePickers()
        {
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = "HH:mm:ss ";
            dateTimePickerStart.Value = _date;
            dateTimePickerFinish.Format = DateTimePickerFormat.Custom;
            dateTimePickerFinish.CustomFormat = "HH:mm:ss ";
            dateTimePickerFinish.Value = _date.AddHours(1);
        }

        private void FillComboBox()
        {
            comboBoxWorkTypes.Items.AddRange(_dailyDetailsAddEditViewModel.GetWorkTypes().ToArray());
            comboBoxWorkTypes.SelectedIndex = 0;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
                                          
            if (_dailyDetailsAddEditViewModel.CreateNewDailyResult(_selectedEmployeeId, dateTimePickerStart.Value,
                dateTimePickerFinish.Value, Convert.ToInt32(comboBoxWorkTypes.Text.Split(' ')[0])))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBoxWorkTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
