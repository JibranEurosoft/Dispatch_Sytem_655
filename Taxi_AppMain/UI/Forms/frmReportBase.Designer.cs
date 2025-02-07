namespace UI
{
    partial class frmReportBase
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
            this.pnlHeaderTitle = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeaderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderTitle
            // 
            this.pnlHeaderTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.pnlHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderTitle.Name = "pnlHeaderTitle";
            // 
            // 
            // 
            this.pnlHeaderTitle.RootElement.ForeColor = System.Drawing.Color.Gainsboro;
            this.pnlHeaderTitle.Size = new System.Drawing.Size(292, 38);
            this.pnlHeaderTitle.TabIndex = 17;
            this.pnlHeaderTitle.Text = "Form Title";
            this.pnlHeaderTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHeaderTitle.Visible = false;
            // 
            // frmReportBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.pnlHeaderTitle);
            this.Name = "frmReportBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmReportBase";
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeaderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlHeaderTitle;
    }
}