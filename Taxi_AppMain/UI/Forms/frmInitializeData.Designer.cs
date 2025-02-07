namespace UI
{
    partial class frmInitializeData
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(132, 252);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(130, 51);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Delete Master Codings";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(381, 252);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(130, 51);
            this.radButton2.TabIndex = 0;
            this.radButton2.Text = "Delete Transactions";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // frmInitializeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 443);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Name = "frmInitializeData";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmInitializeData";
            //this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmInitializeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal Telerik.WinControls.UI.RadButton radButton1;
        protected internal Telerik.WinControls.UI.RadButton radButton2;

    }
}
