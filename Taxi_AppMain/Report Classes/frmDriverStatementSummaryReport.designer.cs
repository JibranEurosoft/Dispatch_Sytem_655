namespace Taxi_AppMain
{
    partial class frmDriverStatementSummaryReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlAllDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.radProgressBar2 = new Telerik.WinControls.UI.RadProgressBar();
            this.btnExport2 = new Telerik.WinControls.UI.RadButton();
            this.btnShow = new Telerik.WinControls.UI.RadButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.dtpFromDate = new UI.MyDatePicker();
            this.dtpTillDate = new UI.MyDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.dtpTillDate);
            this.panel2.Controls.Add(this.dtpFromDate);
            this.panel2.Controls.Add(this.ddlSubCompany);
            this.panel2.Controls.Add(this.chkAllDriver);
            this.panel2.Controls.Add(this.ddlAllDriver);
            this.panel2.Controls.Add(this.radProgressBar2);
            this.panel2.Controls.Add(this.btnExport2);
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1214, 72);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(148, 3);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(183, 26);
            this.ddlSubCompany.TabIndex = 231;
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(23, 38);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(88, 23);
            this.chkAllDriver.TabIndex = 230;
            this.chkAllDriver.Text = "All Driver";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // ddlAllDriver
            // 
            this.ddlAllDriver.Enabled = false;
            this.ddlAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAllDriver.Location = new System.Drawing.Point(148, 35);
            this.ddlAllDriver.Name = "ddlAllDriver";
            this.ddlAllDriver.Size = new System.Drawing.Size(183, 26);
            this.ddlAllDriver.TabIndex = 229;
            // 
            // radProgressBar2
            // 
            this.radProgressBar2.Dash = false;
            this.radProgressBar2.Location = new System.Drawing.Point(956, 4);
            this.radProgressBar2.Name = "radProgressBar2";
            this.radProgressBar2.Size = new System.Drawing.Size(121, 23);
            this.radProgressBar2.TabIndex = 228;
            this.radProgressBar2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radProgressBar2.Visible = false;
            // 
            // btnExport2
            // 
            this.btnExport2.Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            this.btnExport2.Location = new System.Drawing.Point(849, 4);
            this.btnExport2.Name = "btnExport2";
            this.btnExport2.Size = new System.Drawing.Size(89, 24);
            this.btnExport2.TabIndex = 226;
            this.btnExport2.Text = "Export";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport2.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport2.GetChildAt(0))).Text = "Export";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport2.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport2.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(763, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(72, 24);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Show";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShow.GetChildAt(0))).Text = "Show";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShow.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShow.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(558, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "To Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(354, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "From Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sub Company";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel Files (.xls)|*.xls|Advanced Excel Files (.xlsx)|*.xlsx";
            this.saveFileDialog1.FilterIndex = 0;
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Excel Files (.xls)|*.xls|Advanced Excel Files (.xlsx)|*.xlsx";
            this.saveFileDialog2.FilterIndex = 0;
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLister.Location = new System.Drawing.Point(0, 110);
            // 
            // grdLister
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.EnableFiltering = true;
            this.grdLister.MasterTemplate.EnableGrouping = false;
            this.grdLister.MasterTemplate.ShowGroupedColumns = true;
            this.grdLister.Name = "grdLister";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.Size = new System.Drawing.Size(1214, 582);
            this.grdLister.TabIndex = 3;
            this.grdLister.Text = "radGridView1";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(447, 6);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromDate.Size = new System.Drawing.Size(102, 24);
            this.dtpFromDate.TabIndex = 232;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(630, 6);
            this.dtpTillDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpTillDate.Size = new System.Drawing.Size(102, 24);
            this.dtpTillDate.TabIndex = 233;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Text = "myDatePicker1";
            this.dtpTillDate.Value = null;
            // 
            // frmDriverStatementSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 692);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.panel2);
            this.FormTitle = "Driver Statement summary Report";
            this.Name = "frmDriverStatementSummaryReport";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Driver Statement summary Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    
      
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
     
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnExport2;
        private Telerik.WinControls.UI.RadButton btnShow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar2;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadDropDownList ddlAllDriver;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private UI.MyDatePicker dtpTillDate;
        private UI.MyDatePicker dtpFromDate;
    }
}

