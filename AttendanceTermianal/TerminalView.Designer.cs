namespace AttendanceTermianal
{
    partial class TerminalView
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
            this.timerCurrentDateTime = new System.Windows.Forms.Timer(this.components);
            this.panelBtnsAndTxtBox = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEntry = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLunch = new System.Windows.Forms.Button();
            this.btnBTrip = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWorkType = new System.Windows.Forms.Label();
            this.lblDateNow = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timerClearDisplay = new System.Windows.Forms.Timer(this.components);
            this.panelBtnsAndTxtBox.SuspendLayout();
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
            this.txtEmpId.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Bold);
            this.txtEmpId.ForeColor = System.Drawing.Color.Black;
            this.txtEmpId.Location = new System.Drawing.Point(95, 18);
            this.txtEmpId.MaxLength = 8;
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(439, 38);
            this.txtEmpId.TabIndex = 0;
            this.txtEmpId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(519, 40);
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
            // timerCurrentDateTime
            // 
            this.timerCurrentDateTime.Interval = 1000;
            this.timerCurrentDateTime.Tick += new System.EventHandler(this.timerCurrentDateTime_Tick);
            // 
            // panelBtnsAndTxtBox
            // 
            this.panelBtnsAndTxtBox.Controls.Add(this.btnExit);
            this.panelBtnsAndTxtBox.Controls.Add(this.btnEntry);
            this.panelBtnsAndTxtBox.Controls.Add(this.button1);
            this.panelBtnsAndTxtBox.Controls.Add(this.btnLunch);
            this.panelBtnsAndTxtBox.Controls.Add(this.btnBTrip);
            this.panelBtnsAndTxtBox.Controls.Add(this.btnDoctor);
            this.panelBtnsAndTxtBox.Controls.Add(this.txtEmpId);
            this.panelBtnsAndTxtBox.Controls.Add(this.pictureBox7);
            this.panelBtnsAndTxtBox.ForeColor = System.Drawing.Color.White;
            this.panelBtnsAndTxtBox.Location = new System.Drawing.Point(5, 205);
            this.panelBtnsAndTxtBox.Name = "panelBtnsAndTxtBox";
            this.panelBtnsAndTxtBox.Size = new System.Drawing.Size(545, 345);
            this.panelBtnsAndTxtBox.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::AttendanceTermianal.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(275, 207);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(264, 130);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEntry
            // 
            this.btnEntry.Image = global::AttendanceTermianal.Properties.Resources.entry;
            this.btnEntry.Location = new System.Drawing.Point(10, 207);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(264, 130);
            this.btnEntry.TabIndex = 1;
            this.btnEntry.UseVisualStyleBackColor = true;
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // button1
            // 
            this.button1.Image = global::AttendanceTermianal.Properties.Resources._private;
            this.button1.Location = new System.Drawing.Point(409, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 130);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLunch
            // 
            this.btnLunch.Image = global::AttendanceTermianal.Properties.Resources.lunch;
            this.btnLunch.Location = new System.Drawing.Point(10, 74);
            this.btnLunch.Name = "btnLunch";
            this.btnLunch.Size = new System.Drawing.Size(130, 130);
            this.btnLunch.TabIndex = 2;
            this.btnLunch.UseVisualStyleBackColor = true;
            this.btnLunch.Click += new System.EventHandler(this.btnLunch_Click);
            // 
            // btnBTrip
            // 
            this.btnBTrip.Image = global::AttendanceTermianal.Properties.Resources.BS_TRIP;
            this.btnBTrip.Location = new System.Drawing.Point(143, 74);
            this.btnBTrip.Name = "btnBTrip";
            this.btnBTrip.Size = new System.Drawing.Size(130, 130);
            this.btnBTrip.TabIndex = 3;
            this.btnBTrip.UseVisualStyleBackColor = true;
            this.btnBTrip.Click += new System.EventHandler(this.btnBTrip_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Image = global::AttendanceTermianal.Properties.Resources.doctor;
            this.btnDoctor.Location = new System.Drawing.Point(276, 74);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(130, 130);
            this.btnDoctor.TabIndex = 4;
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.Image = global::AttendanceTermianal.Properties.Resources.ID;
            this.pictureBox7.Location = new System.Drawing.Point(-7, 7);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(563, 62);
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
            this.panel2.Location = new System.Drawing.Point(15, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 111);
            this.panel2.TabIndex = 23;
            // 
            // lblWorkType
            // 
            this.lblWorkType.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWorkType.Location = new System.Drawing.Point(3, 70);
            this.lblWorkType.Name = "lblWorkType";
            this.lblWorkType.Size = new System.Drawing.Size(519, 37);
            this.lblWorkType.TabIndex = 11;
            this.lblWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateNow
            // 
            this.lblDateNow.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateNow.Location = new System.Drawing.Point(3, 38);
            this.lblDateNow.Name = "lblDateNow";
            this.lblDateNow.Size = new System.Drawing.Size(519, 30);
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
            this.panel4.Controls.Add(this.panelBtnsAndTxtBox);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(555, 555);
            this.panel4.TabIndex = 1;
            // 
            // timerClearDisplay
            // 
            this.timerClearDisplay.Interval = 2500;
            this.timerClearDisplay.Tick += new System.EventHandler(this.TimerClear_Tick);
            // 
            // TerminalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 565);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TerminalView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal";
            this.panelBtnsAndTxtBox.ResumeLayout(false);
            this.panelBtnsAndTxtBox.PerformLayout();
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
        private System.Windows.Forms.Timer timerCurrentDateTime;
        private System.Windows.Forms.Panel panelBtnsAndTxtBox;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.Label lblDateNow;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timerClearDisplay;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLunch;
        private System.Windows.Forms.Button btnBTrip;
    }
}

