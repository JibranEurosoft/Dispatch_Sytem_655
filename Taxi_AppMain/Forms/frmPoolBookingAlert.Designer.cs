namespace Taxi_AppMain
{
    partial class frmPoolBookingAlert
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
            this.txtheader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txttime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtPickup = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtJobsCount = new System.Windows.Forms.Label();
            this.btnclose2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtheader
            // 
            this.txtheader.BackColor = System.Drawing.Color.Crimson;
            this.txtheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtheader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtheader.ForeColor = System.Drawing.Color.White;
            this.txtheader.Location = new System.Drawing.Point(0, 0);
            this.txtheader.Name = "txtheader";
            this.txtheader.Size = new System.Drawing.Size(321, 24);
            this.txtheader.TabIndex = 1;
            this.txtheader.Text = "New Job Available In Pool";
            this.txtheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DimGray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(196, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "IGNORE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txttime
            // 
            this.txttime.AutoSize = true;
            this.txttime.Dock = System.Windows.Forms.DockStyle.Top;
            this.txttime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txttime.ForeColor = System.Drawing.Color.Red;
            this.txttime.Location = new System.Drawing.Point(0, 24);
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(0, 17);
            this.txttime.TabIndex = 6;
            this.txttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtPickup
            // 
            this.txtPickup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPickup.ForeColor = System.Drawing.Color.Blue;
            this.txtPickup.Location = new System.Drawing.Point(5, 53);
            this.txtPickup.Name = "txtPickup";
            this.txtPickup.Size = new System.Drawing.Size(313, 33);
            this.txtPickup.TabIndex = 9;
            this.txtPickup.Text = "PICKUP :";
            // 
            // txtDriver
            // 
            this.txtDriver.AutoSize = true;
            this.txtDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriver.Location = new System.Drawing.Point(8, 90);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(47, 15);
            this.txtDriver.TabIndex = 10;
            this.txtDriver.Text = "label2";
            this.txtDriver.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Green;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(0, 108);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(122, 23);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "ACCEPT";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtJobsCount
            // 
            this.txtJobsCount.AutoSize = true;
            this.txtJobsCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobsCount.ForeColor = System.Drawing.Color.Blue;
            this.txtJobsCount.Location = new System.Drawing.Point(49, 50);
            this.txtJobsCount.Name = "txtJobsCount";
            this.txtJobsCount.Size = new System.Drawing.Size(0, 23);
            this.txtJobsCount.TabIndex = 12;
            this.txtJobsCount.Visible = false;
            // 
            // btnclose2
            // 
            this.btnclose2.BackColor = System.Drawing.Color.Black;
            this.btnclose2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose2.ForeColor = System.Drawing.Color.White;
            this.btnclose2.Location = new System.Drawing.Point(99, 108);
            this.btnclose2.Name = "btnclose2";
            this.btnclose2.Size = new System.Drawing.Size(122, 23);
            this.btnclose2.TabIndex = 13;
            this.btnclose2.Text = "CLOSE";
            this.btnclose2.UseVisualStyleBackColor = false;
            this.btnclose2.Visible = false;
            this.btnclose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPoolBookingAlert
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(321, 132);
            this.ControlBox = false;
            this.Controls.Add(this.btnclose2);
            this.Controls.Add(this.txtJobsCount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtPickup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.txtheader);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPoolBookingAlert";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = " ";
            this.TopMost = true;
            this.MouseLeave += new System.EventHandler(this.frmLicenseAlert_MouseLeave);
            this.MouseHover += new System.EventHandler(this.frmLicenseAlert_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtheader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label txttime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txtPickup;
        private System.Windows.Forms.Label txtDriver;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label txtJobsCount;
        private System.Windows.Forms.Button btnclose2;
    }
}