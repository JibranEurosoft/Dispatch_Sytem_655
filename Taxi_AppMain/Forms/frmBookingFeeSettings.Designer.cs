namespace Taxi_AppMain
{
    partial class frmBookingFeeSettings
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.grdBookingFeeSettings = new Telerik.WinControls.UI.RadGridView();
            this.btnExitForm = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeSettings.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel1.Controls.Add(this.grdBookingFeeSettings);
            this.radPanel1.Controls.Add(this.btnExitForm);
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(910, 635);
            this.radPanel1.TabIndex = 104;
            // 
            // grdBookingFeeSettings
            // 
            this.grdBookingFeeSettings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBookingFeeSettings.Location = new System.Drawing.Point(13, 66);
            this.grdBookingFeeSettings.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.grdBookingFeeSettings.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewDecimalColumn1.FormatString = "{0:#,###0.00}";
            gridViewDecimalColumn1.HeaderText = "From (£)";
            gridViewDecimalColumn1.Name = "FromValue";
            gridViewDecimalColumn1.Width = 200;
            gridViewDecimalColumn2.FormatString = "{0:#,###0.00}";
            gridViewDecimalColumn2.HeaderText = "To (£)";
            gridViewDecimalColumn2.Name = "ToValue";
            gridViewDecimalColumn2.Width = 200;
            gridViewDecimalColumn3.FormatString = "{0:#,###0.00}";
            gridViewDecimalColumn3.HeaderText = "Fee";
            gridViewDecimalColumn3.Name = "ServiceChargeAmount";
            gridViewDecimalColumn3.Width = 200;
            this.grdBookingFeeSettings.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3});
            this.grdBookingFeeSettings.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdBookingFeeSettings.Name = "grdBookingFeeSettings";
            this.grdBookingFeeSettings.ShowGroupPanel = false;
            this.grdBookingFeeSettings.Size = new System.Drawing.Size(884, 388);
            this.grdBookingFeeSettings.TabIndex = 208;
            this.grdBookingFeeSettings.Text = "radGridView2";
            // 
            // btnExitForm
            // 
            this.btnExitForm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitForm.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExitForm.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExitForm.Location = new System.Drawing.Point(538, 544);
            this.btnExitForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnExitForm.Name = "btnExitForm";
            this.btnExitForm.Size = new System.Drawing.Size(131, 69);
            this.btnExitForm.TabIndex = 202;
            this.btnExitForm.Text = "Exit";
            this.btnExitForm.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExitForm.Click += new System.EventHandler(this.btnExitForm_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExitForm.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExitForm.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExitForm.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.Tick31;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(365, 545);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 69);
            this.btnSave.TabIndex = 201;
            this.btnSave.Text = "Save Settings";
            this.btnSave.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick31;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save Settings";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = false;
            this.radLabel6.BackColor = System.Drawing.Color.SteelBlue;
            this.radLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.ForeColor = System.Drawing.Color.White;
            this.radLabel6.Location = new System.Drawing.Point(0, 38);
            this.radLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(910, 46);
            this.radLabel6.TabIndex = 105;
            this.radLabel6.Text = "Booking Fee Settings";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBookingFeeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 673);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBookingFeeSettings";
            this.Text = "Booking Fee Settings";
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.radLabel6, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeSettings.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookingFeeSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton btnExitForm;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGridView grdBookingFeeSettings;
    }
}