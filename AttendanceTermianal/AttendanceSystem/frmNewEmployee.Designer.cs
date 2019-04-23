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
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxHomeNumber = new System.Windows.Forms.TextBox();
            this.textBoxStreetName = new System.Windows.Forms.TextBox();
            this.textBoxPermisions = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPostalCode = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelHomeNumber = new System.Windows.Forms.Label();
            this.labelSupervisor = new System.Windows.Forms.Label();
            this.labelPermission = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelSalary = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.cmbSupervisors = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonConfirm.Location = new System.Drawing.Point(441, 454);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(186, 38);
            this.buttonConfirm.TabIndex = 56;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click_1);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(146, 454);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(165, 38);
            this.buttonCancel.TabIndex = 55;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(550, 400);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(196, 20);
            this.textBoxConfirmPassword.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(357, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 24);
            this.label5.TabIndex = 53;
            this.label5.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(574, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 52;
            this.label4.Text = "Password";
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.Location = new System.Drawing.Point(550, 243);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(196, 20);
            this.textBoxPostalCode.TabIndex = 51;
            this.textBoxPostalCode.Visible = false;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(550, 190);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(196, 20);
            this.textBoxCity.TabIndex = 50;
            this.textBoxCity.Visible = false;
            // 
            // textBoxHomeNumber
            // 
            this.textBoxHomeNumber.Location = new System.Drawing.Point(550, 137);
            this.textBoxHomeNumber.Name = "textBoxHomeNumber";
            this.textBoxHomeNumber.Size = new System.Drawing.Size(196, 20);
            this.textBoxHomeNumber.TabIndex = 49;
            // 
            // textBoxStreetName
            // 
            this.textBoxStreetName.Location = new System.Drawing.Point(550, 91);
            this.textBoxStreetName.Name = "textBoxStreetName";
            this.textBoxStreetName.Size = new System.Drawing.Size(196, 20);
            this.textBoxStreetName.TabIndex = 48;
            // 
            // textBoxPermisions
            // 
            this.textBoxPermisions.Location = new System.Drawing.Point(178, 267);
            this.textBoxPermisions.Name = "textBoxPermisions";
            this.textBoxPermisions.Size = new System.Drawing.Size(196, 20);
            this.textBoxPermisions.TabIndex = 46;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(550, 344);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(196, 20);
            this.textBoxPassword.TabIndex = 45;
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(178, 210);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(196, 20);
            this.textBoxSalary.TabIndex = 44;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(178, 149);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(196, 20);
            this.textBoxPhoneNumber.TabIndex = 43;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(178, 96);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(196, 20);
            this.textBoxLastName.TabIndex = 42;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(178, 46);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(196, 20);
            this.textBoxFirstName.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "Phone Number:";
            // 
            // labelPostalCode
            // 
            this.labelPostalCode.AutoSize = true;
            this.labelPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPostalCode.Location = new System.Drawing.Point(408, 243);
            this.labelPostalCode.Name = "labelPostalCode";
            this.labelPostalCode.Size = new System.Drawing.Size(116, 24);
            this.labelPostalCode.TabIndex = 39;
            this.labelPostalCode.Text = "Postal Code:";
            this.labelPostalCode.Visible = false;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCity.Location = new System.Drawing.Point(479, 190);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(45, 24);
            this.labelCity.TabIndex = 38;
            this.labelCity.Text = "City:";
            this.labelCity.Visible = false;
            // 
            // labelHomeNumber
            // 
            this.labelHomeNumber.AutoSize = true;
            this.labelHomeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHomeNumber.Location = new System.Drawing.Point(383, 137);
            this.labelHomeNumber.Name = "labelHomeNumber";
            this.labelHomeNumber.Size = new System.Drawing.Size(141, 24);
            this.labelHomeNumber.TabIndex = 37;
            this.labelHomeNumber.Text = "Home Number:";
            // 
            // labelSupervisor
            // 
            this.labelSupervisor.AutoSize = true;
            this.labelSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSupervisor.Location = new System.Drawing.Point(53, 319);
            this.labelSupervisor.Name = "labelSupervisor";
            this.labelSupervisor.Size = new System.Drawing.Size(105, 24);
            this.labelSupervisor.TabIndex = 36;
            this.labelSupervisor.Text = "Supervisor:";
            // 
            // labelPermission
            // 
            this.labelPermission.AutoSize = true;
            this.labelPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPermission.Location = new System.Drawing.Point(43, 267);
            this.labelPermission.Name = "labelPermission";
            this.labelPermission.Size = new System.Drawing.Size(117, 24);
            this.labelPermission.TabIndex = 35;
            this.labelPermission.Text = "Permissions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(408, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Street name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(574, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "Address";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPassword.Location = new System.Drawing.Point(427, 344);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(97, 24);
            this.labelPassword.TabIndex = 32;
            this.labelPassword.Text = "Password:";
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSalary.Location = new System.Drawing.Point(92, 210);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Size = new System.Drawing.Size(66, 24);
            this.labelSalary.TabIndex = 31;
            this.labelSalary.Text = "Salary:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLastName.Location = new System.Drawing.Point(54, 96);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(104, 24);
            this.labelLastName.TabIndex = 30;
            this.labelLastName.Text = "Last Name:";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFirstName.Location = new System.Drawing.Point(54, 41);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(106, 24);
            this.labelFirstName.TabIndex = 29;
            this.labelFirstName.Text = "First Name:";
            // 
            // cmbSupervisors
            // 
            this.cmbSupervisors.FormattingEnabled = true;
            this.cmbSupervisors.Location = new System.Drawing.Point(178, 324);
            this.cmbSupervisors.Name = "cmbSupervisors";
            this.cmbSupervisors.Size = new System.Drawing.Size(196, 21);
            this.cmbSupervisors.TabIndex = 57;
            // 
            // frmNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 522);
            this.Controls.Add(this.cmbSupervisors);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPostalCode);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxHomeNumber);
            this.Controls.Add(this.textBoxStreetName);
            this.Controls.Add(this.textBoxPermisions);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxSalary);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPostalCode);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelHomeNumber);
            this.Controls.Add(this.labelSupervisor);
            this.Controls.Add(this.labelPermission);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelSalary);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Name = "frmNewEmployee";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxHomeNumber;
        private System.Windows.Forms.TextBox textBoxStreetName;
        private System.Windows.Forms.TextBox textBoxPermisions;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPostalCode;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelHomeNumber;
        private System.Windows.Forms.Label labelSupervisor;
        private System.Windows.Forms.Label labelPermission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelSalary;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.ComboBox cmbSupervisors;
    }
}