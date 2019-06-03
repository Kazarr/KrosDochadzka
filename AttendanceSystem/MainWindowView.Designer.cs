namespace AttendanceSystem
{
    partial class MainWindowView
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
            this.components = new System.ComponentModel.Container();
            this.btnShowMonth = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.labelChoosePerson = new System.Windows.Forms.Label();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dGVOverview = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowMonth
            // 
            this.btnShowMonth.Location = new System.Drawing.Point(195, 265);
            this.btnShowMonth.Name = "btnShowMonth";
            this.btnShowMonth.Size = new System.Drawing.Size(162, 23);
            this.btnShowMonth.TabIndex = 20;
            this.btnShowMonth.Text = "Month Overview";
            this.btnShowMonth.UseVisualStyleBackColor = true;
            this.btnShowMonth.Click += new System.EventHandler(this.btnShowMonth_Click_1);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateEmployee.Location = new System.Drawing.Point(997, 41);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(162, 23);
            this.btnUpdateEmployee.TabIndex = 17;
            this.btnUpdateEmployee.Text = "Update Employee";
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteEmployee.Location = new System.Drawing.Point(811, 12);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(162, 23);
            this.btnDeleteEmployee.TabIndex = 16;
            this.btnDeleteEmployee.Text = "Delete Employee";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click_1);
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewEmployee.Location = new System.Drawing.Point(997, 12);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(162, 23);
            this.btnNewEmployee.TabIndex = 15;
            this.btnNewEmployee.Text = "New Employee";
            this.btnNewEmployee.UseVisualStyleBackColor = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click_1);
            // 
            // labelChoosePerson
            // 
            this.labelChoosePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChoosePerson.AutoSize = true;
            this.labelChoosePerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelChoosePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelChoosePerson.Location = new System.Drawing.Point(657, 243);
            this.labelChoosePerson.Name = "labelChoosePerson";
            this.labelChoosePerson.Size = new System.Drawing.Size(108, 18);
            this.labelChoosePerson.TabIndex = 14;
            this.labelChoosePerson.Text = "Choose  person ";
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(771, 240);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(395, 21);
            this.comboBoxPerson.TabIndex = 13;
            this.comboBoxPerson.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPerson_SelectionChangeCommitted);
            // 
            // labelMonth
            // 
            this.labelMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMonth.AutoSize = true;
            this.labelMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMonth.Location = new System.Drawing.Point(669, 270);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(96, 18);
            this.labelMonth.TabIndex = 12;
            this.labelMonth.Text = "Choose month";
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(771, 267);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(395, 21);
            this.comboBoxMonth.TabIndex = 11;
            this.comboBoxMonth.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMonth_SelectionChangeCommitted);
            // 
            // dGVOverview
            // 
            this.dGVOverview.AllowUserToAddRows = false;
            this.dGVOverview.AllowUserToDeleteRows = false;
            this.dGVOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVOverview.AutoGenerateColumns = false;
            this.dGVOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOverview.DataSource = this.bindingSource1;
            this.dGVOverview.Location = new System.Drawing.Point(15, 294);
            this.dGVOverview.MultiSelect = false;
            this.dGVOverview.Name = "dGVOverview";
            this.dGVOverview.ReadOnly = true;
            this.dGVOverview.RowHeadersVisible = false;
            this.dGVOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVOverview.Size = new System.Drawing.Size(1151, 225);
            this.dGVOverview.TabIndex = 21;
            this.dGVOverview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dGVOverview_RowPrePaint);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(15, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(162, 23);
            this.buttonExit.TabIndex = 22;
            this.buttonExit.Text = "Logout";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(15, 265);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(174, 23);
            this.btnDetails.TabIndex = 23;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(997, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(162, 23);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset Employee Password";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(15, 41);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(162, 23);
            this.btnChangePassword.TabIndex = 25;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(771, 213);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(395, 21);
            this.comboBoxYear.TabIndex = 26;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(670, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Choose  Year ";
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 531);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dGVOverview);
            this.Controls.Add(this.btnShowMonth);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.labelChoosePerson);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.comboBoxMonth);
            this.Name = "MainWindowView";
            this.Text = "Overview";
            this.Load += new System.EventHandler(this.FrmMainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowMonth;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Label labelChoosePerson;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DataGridView dGVOverview;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkLeavingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunchBreakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn holidayTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeOfficeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn privateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTimeWorked;
    }
}

