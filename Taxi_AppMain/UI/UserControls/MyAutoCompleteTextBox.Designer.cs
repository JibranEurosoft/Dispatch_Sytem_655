namespace UI.UserControls
{
    partial class MyAutoCompleteTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtData = new Telerik.WinControls.UI.RadTextBox();
            this.lst_AutoComplete = new Telerik.WinControls.UI.RadListControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_AutoComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(1, 3);
            this.txtData.MaxLength = 20;
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            // 
            // 
            // 
            this.txtData.RootElement.StretchVertically = true;
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtData.Size = new System.Drawing.Size(254, 48);
            this.txtData.TabIndex = 174;
            this.txtData.TabStop = false;
            // 
            // lst_AutoComplete
            // 
            this.lst_AutoComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_AutoComplete.AutoScroll = true;
            this.lst_AutoComplete.AutoSizeItems = true;
            this.lst_AutoComplete.CaseSensitiveSort = true;
            this.lst_AutoComplete.Location = new System.Drawing.Point(3, 52);
            this.lst_AutoComplete.Name = "lst_AutoComplete";
            this.lst_AutoComplete.Size = new System.Drawing.Size(252, 105);
            this.lst_AutoComplete.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            this.lst_AutoComplete.TabIndex = 175;
            this.lst_AutoComplete.Text = "radListControl1";
            this.lst_AutoComplete.Visible = false;
            // 
            // MyAutoCompleteTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_AutoComplete);
            this.Controls.Add(this.txtData);
            this.Name = "MyAutoCompleteTextBox";
            this.Size = new System.Drawing.Size(258, 54);
            ((System.ComponentModel.ISupportInitialize)(this.txtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_AutoComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtData;
        private Telerik.WinControls.UI.RadListControl lst_AutoComplete;
    }
}
