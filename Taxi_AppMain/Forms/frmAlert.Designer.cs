namespace Taxi_AppMain
{
    partial class frmAlert
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
            this.txtHeader = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.BackColor = System.Drawing.Color.Crimson;
            this.txtHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtHeader.ForeColor = System.Drawing.Color.White;
            this.txtHeader.Location = new System.Drawing.Point(0, 0);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(150, 23);
            this.txtHeader.TabIndex = 1;
            this.txtHeader.Text = "Company Name";
            this.txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.txtMsg.ForeColor = System.Drawing.Color.Blue;
            this.txtMsg.Location = new System.Drawing.Point(0, 23);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(150, 22);
            this.txtMsg.TabIndex = 6;
            this.txtMsg.Text = "0";
            this.txtMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40000;
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(150, 45);
            this.ControlBox = false;
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtHeader);
           
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmAlert";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = " ";
            this.TopMost = true;
            this.Enabled = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtHeader;
        private System.Windows.Forms.Label txtMsg;
        private System.Windows.Forms.Timer timer1;
    }
}