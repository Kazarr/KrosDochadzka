namespace AttendanceSystem
{
    partial class frmNewEmployee
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
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textAdress = new System.Windows.Forms.TextBox();
            this.textBoxPermisions = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSupervisor = new System.Windows.Forms.Label();
            this.labelPermission = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.cmbSupervisors = new System.Windows.Forms.ComboBox();
            this.cmbPermissions = new System.Windows.Forms.ComboBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUserConfirmPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonConfirm.Location = new System.Drawing.Point(243, 553);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(186, 38);
            this.buttonConfirm.TabIndex = 7;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click_1);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 553);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(165, 38);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // textAdress
            // 
            this.textAdress.Location = new System.Drawing.Point(197, 312);
            this.textAdress.Name = "textAdress";
            this.textAdress.Size = new System.Drawing.Size(196, 20);
            this.textAdress.TabIndex = 6;
            // 
            // textBoxPermisions
            // 
            this.textBoxPermisions.Location = new System.Drawing.Point(197, 204);
            this.textBoxPermisions.Name = "textBoxPermisions";
            this.textBoxPermisions.Size = new System.Drawing.Size(196, 20);
            this.textBoxPermisions.TabIndex = 46;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(197, 150);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(196, 20);
            this.textBoxPhoneNumber.TabIndex = 2;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(197, 97);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(196, 20);
            this.textBoxLastName.TabIndex = 1;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(197, 47);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(196, 20);
            this.textBoxFirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(34, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "Phone Number:";
            // 
            // labelSupervisor
            // 
            this.labelSupervisor.AutoSize = true;
            this.labelSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSupervisor.Location = new System.Drawing.Point(72, 256);
            this.labelSupervisor.Name = "labelSupervisor";
            this.labelSupervisor.Size = new System.Drawing.Size(105, 24);
            this.labelSupervisor.TabIndex = 36;
            this.labelSupervisor.Text = "Supervisor:";
            // 
            // labelPermission
            // 
            this.labelPermission.AutoSize = true;
            this.labelPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPermission.Location = new System.Drawing.Point(62, 204);
            this.labelPermission.Name = "labelPermission";
            this.labelPermission.Size = new System.Drawing.Size(117, 24);
            this.labelPermission.TabIndex = 35;
            this.labelPermission.Text = "Permissions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(103, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Adress:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLastName.Location = new System.Drawing.Point(73, 97);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(104, 24);
            this.labelLastName.TabIndex = 30;
            this.labelLastName.Text = "Last Name:";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFirstName.Location = new System.Drawing.Point(73, 42);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(106, 24);
            this.labelFirstName.TabIndex = 10;
            this.labelFirstName.Text = "First Name:";
            // 
            // cmbSupervisors
            // 
            this.cmbSupervisors.FormattingEnabled = true;
            this.cmbSupervisors.Location = new System.Drawing.Point(197, 256);
            this.cmbSupervisors.Name = "cmbSupervisors";
            this.cmbSupervisors.Size = new System.Drawing.Size(196, 21);
            this.cmbSupervisors.TabIndex = 5;
            // 
            // cmbPermissions
            // 
            this.cmbPermissions.FormattingEnabled = true;
            this.cmbPermissions.Location = new System.Drawing.Point(197, 203);
            this.cmbPermissions.Name = "cmbPermissions";
            this.cmbPermissions.Size = new System.Drawing.Size(196, 21);
            this.cmbPermissions.TabIndex = 4;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(197, 424);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(196, 20);
            this.textBoxConfirmPassword.TabIndex = 54;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(197, 372);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(196, 20);
            this.textBoxPassword.TabIndex = 45;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserPassword.Location = new System.Drawing.Point(84, 372);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(97, 24);
            this.lblUserPassword.TabIndex = 32;
            this.lblUserPassword.Text = "Password:";
            // 
            // lblUserConfirmPassword
            // 
            this.lblUserConfirmPassword.AutoSize = true;
            this.lblUserConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUserConfirmPassword.Location = new System.Drawing.Point(14, 424);
            this.lblUserConfirmPassword.Name = "lblUserConfirmPassword";
            this.lblUserConfirmPassword.Size = new System.Drawing.Size(167, 24);
            this.lblUserConfirmPassword.TabIndex = 53;
            this.lblUserConfirmPassword.Text = "Confirm Password:";
            // 
            // frmNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 603);
            this.Controls.Add(this.cmbPermissions);
            this.Controls.Add(this.cmbSupervisors);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.lblUserConfirmPassword);
            this.Controls.Add(this.textAdress);
            this.Controls.Add(this.textBoxPermisions);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSupervisor);
            this.Controls.Add(this.labelPermission);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.MaximumSize = new System.Drawing.Size(457, 642);
            this.MinimumSize = new System.Drawing.Size(457, 642);
            this.Name = "frmNewEmployee";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmNewEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textAdress;
        private System.Windows.Forms.TextBox textBoxPermisions;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSupervisor;
        private System.Windows.Forms.Label labelPermission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.ComboBox cmbSupervisors;
        private System.Windows.Forms.ComboBox cmbPermissions;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUserConfirmPassword;
    }
}