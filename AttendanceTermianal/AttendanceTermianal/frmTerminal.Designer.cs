namespace AttendanceTermianal
{
    partial class frmTerminal
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
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.picEntry = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picLunch = new System.Windows.Forms.PictureBox();
            this.picDoctor = new System.Windows.Forms.PictureBox();
            this.picPrivate = new System.Windows.Forms.PictureBox();
            this.picTrip = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWorkType = new System.Windows.Forms.Label();
            this.lblDateNow = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrip)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmpId
            // 
            this.txtEmpId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmpId.BackColor = System.Drawing.Color.White;
            this.txtEmpId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpId.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.txtEmpId.ForeColor = System.Drawing.Color.Black;
            this.txtEmpId.Location = new System.Drawing.Point(84, 21);
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(439, 36);
            this.txtEmpId.TabIndex = 2;
            this.txtEmpId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(498, 40);
            this.lblName.TabIndex = 9;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Century Gothic", 47.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHour.Location = new System.Drawing.Point(299, 3);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(155, 74);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "9:27";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.lblSec.Location = new System.Drawing.Point(491, 46);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(32, 22);
            this.lblSec.TabIndex = 11;
            this.lblSec.Text = "30";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.lblDate.Location = new System.Drawing.Point(14, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(151, 30);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "18.19";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay
            // 
            this.lblDay.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDay.Location = new System.Drawing.Point(14, 45);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(151, 28);
            this.lblDay.TabIndex = 13;
            this.lblDay.Text = "Piatok";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // picEntry
            // 
            this.picEntry.Image = global::AttendanceTermianal.Properties.Resources.entry;
            this.picEntry.Location = new System.Drawing.Point(4, 207);
            this.picEntry.Name = "picEntry";
            this.picEntry.Size = new System.Drawing.Size(268, 130);
            this.picEntry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEntry.TabIndex = 15;
            this.picEntry.TabStop = false;
            this.picEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picEntry_MouseClick);
            // 
            // picExit
            // 
            this.picExit.Image = global::AttendanceTermianal.Properties.Resources.exit;
            this.picExit.Location = new System.Drawing.Point(272, 207);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(268, 130);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExit.TabIndex = 16;
            this.picExit.TabStop = false;
            this.picExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picExit_MouseClick);
            // 
            // picLunch
            // 
            this.picLunch.Image = global::AttendanceTermianal.Properties.Resources.lunch;
            this.picLunch.Location = new System.Drawing.Point(10, 74);
            this.picLunch.Margin = new System.Windows.Forms.Padding(0);
            this.picLunch.Name = "picLunch";
            this.picLunch.Size = new System.Drawing.Size(130, 130);
            this.picLunch.TabIndex = 17;
            this.picLunch.TabStop = false;
            this.picLunch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picLunch_MouseClick);
            // 
            // picDoctor
            // 
            this.picDoctor.Image = global::AttendanceTermianal.Properties.Resources.doctor;
            this.picDoctor.Location = new System.Drawing.Point(272, 74);
            this.picDoctor.Margin = new System.Windows.Forms.Padding(0);
            this.picDoctor.Name = "picDoctor";
            this.picDoctor.Size = new System.Drawing.Size(130, 130);
            this.picDoctor.TabIndex = 19;
            this.picDoctor.TabStop = false;
            this.picDoctor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDoctor_MouseClick);
            // 
            // picPrivate
            // 
            this.picPrivate.Image = global::AttendanceTermianal.Properties.Resources._private;
            this.picPrivate.Location = new System.Drawing.Point(402, 74);
            this.picPrivate.Margin = new System.Windows.Forms.Padding(0);
            this.picPrivate.Name = "picPrivate";
            this.picPrivate.Size = new System.Drawing.Size(130, 130);
            this.picPrivate.TabIndex = 20;
            this.picPrivate.TabStop = false;
            this.picPrivate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPrivate_MouseClick);
            // 
            // picTrip
            // 
            this.picTrip.Image = global::AttendanceTermianal.Properties.Resources.BS_TRIP;
            this.picTrip.Location = new System.Drawing.Point(140, 74);
            this.picTrip.Margin = new System.Windows.Forms.Padding(0);
            this.picTrip.Name = "picTrip";
            this.picTrip.Size = new System.Drawing.Size(130, 130);
            this.picTrip.TabIndex = 21;
            this.picTrip.TabStop = false;
            this.picTrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTrip_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEmpId);
            this.panel1.Controls.Add(this.picLunch);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.picTrip);
            this.panel1.Controls.Add(this.picEntry);
            this.panel1.Controls.Add(this.picPrivate);
            this.panel1.Controls.Add(this.picExit);
            this.panel1.Controls.Add(this.picDoctor);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(5, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 345);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.Image = global::AttendanceTermianal.Properties.Resources.ID;
            this.pictureBox7.Location = new System.Drawing.Point(0, 7);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(543, 67);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblWorkType);
            this.panel2.Controls.Add(this.lblDateNow);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Location = new System.Drawing.Point(22, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 111);
            this.panel2.TabIndex = 23;
            // 
            // lblWorkType
            // 
            this.lblWorkType.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWorkType.Location = new System.Drawing.Point(3, 70);
            this.lblWorkType.Name = "lblWorkType";
            this.lblWorkType.Size = new System.Drawing.Size(498, 37);
            this.lblWorkType.TabIndex = 11;
            this.lblWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateNow
            // 
            this.lblDateNow.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateNow.Location = new System.Drawing.Point(3, 38);
            this.lblDateNow.Name = "lblDateNow";
            this.lblDateNow.Size = new System.Drawing.Size(498, 30);
            this.lblDateNow.TabIndex = 10;
            this.lblDateNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDate);
            this.panel3.Controls.Add(this.lblDay);
            this.panel3.Controls.Add(this.lblHour);
            this.panel3.Controls.Add(this.lblSec);
            this.panel3.Location = new System.Drawing.Point(5, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(545, 82);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(555, 555);
            this.panel4.TabIndex = 25;
            // 
            // timerClear
            // 
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // frmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 565);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTerminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendence Terminal";
            ((System.ComponentModel.ISupportInitialize)(this.picEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrip)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox picEntry;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picLunch;
        private System.Windows.Forms.PictureBox picDoctor;
        private System.Windows.Forms.PictureBox picPrivate;
        private System.Windows.Forms.PictureBox picTrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.Label lblDateNow;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timerClear;
    }
}

