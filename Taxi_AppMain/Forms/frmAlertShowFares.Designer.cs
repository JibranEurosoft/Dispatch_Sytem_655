namespace Taxi_AppMain
{
    partial class frmAlertShowFares
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.Label();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlToLocType = new UI.MyDropDownList();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.ddlFromLocType = new UI.MyDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlToLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFromLocType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.White;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(72, 193);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(111, 42);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "SAVE";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(246, 193);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 42);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "EXIT";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Silver;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Font = new System.Drawing.Font("Arial", 14F);
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(469, 30);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Text = "Set Fares";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel7.Location = new System.Drawing.Point(86, 108);
            this.radLabel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(67, 23);
            this.radLabel7.TabIndex = 66;
            this.radLabel7.Text = "To Type";
            // 
            // ddlToLocType
            // 
            this.ddlToLocType.Caption = null;
            this.ddlToLocType.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ddlToLocType.Location = new System.Drawing.Point(168, 108);
            this.ddlToLocType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlToLocType.Name = "ddlToLocType";
            this.ddlToLocType.Property = null;
            this.ddlToLocType.ShowDownArrow = true;
            this.ddlToLocType.Size = new System.Drawing.Size(150, 25);
            this.ddlToLocType.TabIndex = 64;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel8.Location = new System.Drawing.Point(72, 45);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(86, 23);
            this.radLabel8.TabIndex = 65;
            this.radLabel8.Text = "From Type";
            // 
            // ddlFromLocType
            // 
            this.ddlFromLocType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlFromLocType.Caption = null;
            this.ddlFromLocType.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ddlFromLocType.Location = new System.Drawing.Point(167, 45);
            this.ddlFromLocType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlFromLocType.Name = "ddlFromLocType";
            this.ddlFromLocType.Property = null;
            this.ddlFromLocType.ShowDownArrow = true;
            this.ddlFromLocType.Size = new System.Drawing.Size(151, 25);
            this.ddlFromLocType.TabIndex = 63;
            // 
            // frmAlertShowFares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 249);
            this.ControlBox = false;
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.ddlToLocType);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.ddlFromLocType);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlertShowFares";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlToLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFromLocType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label txtTitle;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private UI.MyDropDownList ddlToLocType;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private UI.MyDropDownList ddlFromLocType;
    }
}