namespace AttendanceSystem
{
    partial class FrmDailyDetailsAddEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxWorkTypes = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFinish = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Image = global::AttendanceSystem.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(303, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(220, 73);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.Image = global::AttendanceSystem.Properties.Resources.confirm;
            this.btnConfirm.Location = new System.Drawing.Point(27, 177);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(245, 73);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePickerStart.CalendarTitleBackColor = System.Drawing.Color.White;
            this.dateTimePickerStart.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.dateTimePickerStart.CustomFormat = "HH:mm:ss";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStart.Location = new System.Drawing.Point(172, 10);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(339, 38);
            this.dateTimePickerStart.TabIndex = 8;
            // 
            // comboBoxWorkTypes
            // 
            this.comboBoxWorkTypes.BackColor = System.Drawing.Color.White;
            this.comboBoxWorkTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxWorkTypes.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxWorkTypes.Location = new System.Drawing.Point(172, 110);
            this.comboBoxWorkTypes.Name = "comboBoxWorkTypes";
            this.comboBoxWorkTypes.Size = new System.Drawing.Size(339, 36);
            this.comboBoxWorkTypes.TabIndex = 9;
            this.comboBoxWorkTypes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWorkTypes_SelectedIndexChanged);
            // 
            // dateTimePickerFinish
            // 
            this.dateTimePickerFinish.CustomFormat = "";
            this.dateTimePickerFinish.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerFinish.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFinish.Location = new System.Drawing.Point(172, 59);
            this.dateTimePickerFinish.Name = "dateTimePickerFinish";
            this.dateTimePickerFinish.ShowUpDown = true;
            this.dateTimePickerFinish.Size = new System.Drawing.Size(339, 38);
            this.dateTimePickerFinish.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::AttendanceSystem.Properties.Resources.updateResult;
            this.panel1.Controls.Add(this.dateTimePickerStart);
            this.panel1.Controls.Add(this.dateTimePickerFinish);
            this.panel1.Controls.Add(this.comboBoxWorkTypes);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 159);
            this.panel1.TabIndex = 15;
            // 
            // frmDailyDetailsAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 274);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDailyDetailsAddEdit";
            this.Text = "frmDailyDetailsAddEdit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.ComboBox comboBoxWorkTypes;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinish;
        private System.Windows.Forms.Panel panel1;
    }
}