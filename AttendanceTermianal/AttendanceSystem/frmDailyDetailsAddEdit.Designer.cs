namespace AttendanceSystem
{
    partial class frmDailyDetailsAddEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxWorkTypes = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFinish = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(44, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Finish time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(45, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Work Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(299, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 54);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.Location = new System.Drawing.Point(49, 199);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(167, 54);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "HH:mm:ss";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStart.Location = new System.Drawing.Point(203, 56);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(269, 20);
            this.dateTimePickerStart.TabIndex = 8;
            // 
            // comboBoxWorkTypes
            // 
            this.comboBoxWorkTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkTypes.Location = new System.Drawing.Point(203, 147);
            this.comboBoxWorkTypes.Name = "comboBoxWorkTypes";
            this.comboBoxWorkTypes.Size = new System.Drawing.Size(269, 21);
            this.comboBoxWorkTypes.TabIndex = 9;
            this.comboBoxWorkTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorkTypes_SelectedIndexChanged);
            // 
            // dateTimePickerFinish
            // 
            this.dateTimePickerFinish.CustomFormat = "";
            this.dateTimePickerFinish.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFinish.Location = new System.Drawing.Point(203, 98);
            this.dateTimePickerFinish.Name = "dateTimePickerFinish";
            this.dateTimePickerFinish.ShowUpDown = true;
            this.dateTimePickerFinish.Size = new System.Drawing.Size(269, 20);
            this.dateTimePickerFinish.TabIndex = 10;
            // 
            // frmDailyDetailsAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 280);
            this.Controls.Add(this.dateTimePickerFinish);
            this.Controls.Add(this.comboBoxWorkTypes);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDailyDetailsAddEdit";
            this.Text = "frmDailyDetailsAddEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.ComboBox comboBoxWorkTypes;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinish;
    }
}