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
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.btnArrival = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLunch = new System.Windows.Forms.Button();
            this.btnBusinessTrip = new System.Windows.Forms.Button();
            this.btnPrivate = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee ID";
            // 
            // txtEmpId
            // 
            this.txtEmpId.Location = new System.Drawing.Point(114, 96);
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(67, 20);
            this.txtEmpId.TabIndex = 2;
            // 
            // btnArrival
            // 
            this.btnArrival.BackColor = System.Drawing.Color.Blue;
            this.btnArrival.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnArrival.ForeColor = System.Drawing.Color.White;
            this.btnArrival.Location = new System.Drawing.Point(216, 90);
            this.btnArrival.Name = "btnArrival";
            this.btnArrival.Size = new System.Drawing.Size(95, 30);
            this.btnArrival.TabIndex = 3;
            this.btnArrival.Text = "Arrival";
            this.btnArrival.UseVisualStyleBackColor = false;
            this.btnArrival.Click += new System.EventHandler(this.btnArrival_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Blue;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(317, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLunch
            // 
            this.btnLunch.BackColor = System.Drawing.Color.Blue;
            this.btnLunch.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLunch.ForeColor = System.Drawing.Color.White;
            this.btnLunch.Location = new System.Drawing.Point(266, 126);
            this.btnLunch.Name = "btnLunch";
            this.btnLunch.Size = new System.Drawing.Size(111, 30);
            this.btnLunch.TabIndex = 5;
            this.btnLunch.Text = "Lunch";
            this.btnLunch.UseVisualStyleBackColor = false;
            // 
            // btnBusinessTrip
            // 
            this.btnBusinessTrip.BackColor = System.Drawing.Color.Blue;
            this.btnBusinessTrip.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBusinessTrip.ForeColor = System.Drawing.Color.White;
            this.btnBusinessTrip.Location = new System.Drawing.Point(266, 162);
            this.btnBusinessTrip.Name = "btnBusinessTrip";
            this.btnBusinessTrip.Size = new System.Drawing.Size(111, 30);
            this.btnBusinessTrip.TabIndex = 6;
            this.btnBusinessTrip.Text = "Business Trip";
            this.btnBusinessTrip.UseVisualStyleBackColor = false;
            // 
            // btnPrivate
            // 
            this.btnPrivate.BackColor = System.Drawing.Color.Blue;
            this.btnPrivate.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrivate.ForeColor = System.Drawing.Color.White;
            this.btnPrivate.Location = new System.Drawing.Point(266, 198);
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.Size = new System.Drawing.Size(111, 30);
            this.btnPrivate.TabIndex = 7;
            this.btnPrivate.Text = "Private";
            this.btnPrivate.UseVisualStyleBackColor = false;
            // 
            // btnDoctor
            // 
            this.btnDoctor.BackColor = System.Drawing.Color.Blue;
            this.btnDoctor.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDoctor.ForeColor = System.Drawing.Color.White;
            this.btnDoctor.Location = new System.Drawing.Point(266, 234);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(111, 30);
            this.btnDoctor.TabIndex = 8;
            this.btnDoctor.Text = "Doctor";
            this.btnDoctor.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(231, 11);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(41, 21);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "9:27";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(278, 19);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(19, 13);
            this.lblSec.TabIndex = 11;
            this.lblSec.Text = "30";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDate.Location = new System.Drawing.Point(13, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(55, 22);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "18.19";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDay.Location = new System.Drawing.Point(123, 13);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(63, 22);
            this.lblDay.TabIndex = 13;
            this.lblDay.Text = "Piatok";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(451, 281);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnPrivate);
            this.Controls.Add(this.btnBusinessTrip);
            this.Controls.Add(this.btnLunch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnArrival);
            this.Controls.Add(this.txtEmpId);
            this.Controls.Add(this.label2);
            this.Name = "frmTerminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendence Terminal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.Button btnArrival;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLunch;
        private System.Windows.Forms.Button btnBusinessTrip;
        private System.Windows.Forms.Button btnPrivate;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Timer timer;
    }
}

