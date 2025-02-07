namespace Taxi_AppMain
{
    partial class rptfrmRentReport
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
            this.pnlCriteria = new Telerik.WinControls.UI.RadPanel();
            this.grdPaymentTypes = new UI.MyGridView();
            this.tbRent = new Telerik.WinControls.UI.RadSpinEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Telerik.WinControls.UI.RadButton();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.dtpFromTime = new UI.MyDatePicker();
            this.dtptilltime = new UI.MyDatePicker();
            this.ddlDrivers = new Telerik.WinControls.UI.RadDropDownList();
            this.btnViewReport = new Telerik.WinControls.UI.RadButton();
            this.dtpToDate = new UI.MyDatePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Size = new System.Drawing.Size(70, 57);
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCriteria.Controls.Add(this.radProgressBar1);
            this.pnlCriteria.Controls.Add(this.grdPaymentTypes);
            this.pnlCriteria.Controls.Add(this.tbRent);
            this.pnlCriteria.Controls.Add(this.label6);
            this.pnlCriteria.Controls.Add(this.btnExportExcel);
            this.pnlCriteria.Controls.Add(this.radCheckBox1);
            this.pnlCriteria.Controls.Add(this.chkAllDriver);
            this.pnlCriteria.Controls.Add(this.dtpFromTime);
            this.pnlCriteria.Controls.Add(this.dtptilltime);
            this.pnlCriteria.Controls.Add(this.ddlDrivers);
            this.pnlCriteria.Controls.Add(this.btnViewReport);
            this.pnlCriteria.Controls.Add(this.dtpToDate);
            this.pnlCriteria.Controls.Add(this.label3);
            this.pnlCriteria.Controls.Add(this.dtpFromDate);
            this.pnlCriteria.Controls.Add(this.label2);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 0);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(1378, 133);
            this.pnlCriteria.TabIndex = 117;
            // 
            // grdPaymentTypes
            // 
            this.grdPaymentTypes.AutoCellFormatting = false;
            this.grdPaymentTypes.EnableCheckInCheckOut = false;
            this.grdPaymentTypes.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdPaymentTypes.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdPaymentTypes.Location = new System.Drawing.Point(678, 2);
            // 
            // grdPaymentTypes
            // 
            this.grdPaymentTypes.MasterTemplate.AllowAddNewRow = false;
            this.grdPaymentTypes.MasterTemplate.AllowEditRow = false;
            this.grdPaymentTypes.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdPaymentTypes.Name = "grdPaymentTypes";
            this.grdPaymentTypes.PKFieldColumnName = "";
            this.grdPaymentTypes.ShowGroupPanel = false;
            this.grdPaymentTypes.ShowImageOnActionButton = true;
            this.grdPaymentTypes.Size = new System.Drawing.Size(170, 128);
            this.grdPaymentTypes.TabIndex = 149;
            this.grdPaymentTypes.Text = "myGridView1";
            // 
            // tbRent
            // 
            this.tbRent.DecimalPlaces = 2;
            this.tbRent.EnableKeyMap = true;
            this.tbRent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRent.ForeColor = System.Drawing.Color.Red;
            this.tbRent.InterceptArrowKeys = false;
            this.tbRent.Location = new System.Drawing.Point(423, 41);
            this.tbRent.Name = "tbRent";
            // 
            // 
            // 
            this.tbRent.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.tbRent.RootElement.ForeColor = System.Drawing.Color.Red;
            this.tbRent.ShowBorder = true;
            this.tbRent.Size = new System.Drawing.Size(142, 21);
            this.tbRent.TabIndex = 151;
            this.tbRent.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.tbRent.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSpinElement)(this.tbRent.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.tbRent.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.tbRent.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.tbRent.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(572, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 142;
            this.label6.Text = "Payment Type";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(1021, 9);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(122, 52);
            this.btnExportExcel.TabIndex = 141;
            this.btnExportExcel.Text = "Export To EXCEL";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Text = "Export To EXCEL";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBox1.Location = new System.Drawing.Point(307, 39);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(114, 23);
            this.radCheckBox1.TabIndex = 131;
            this.radCheckBox1.Text = "Include Rent";
            this.radCheckBox1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(307, 6);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(95, 23);
            this.chkAllDriver.TabIndex = 130;
            this.chkAllDriver.Text = "All Drivers";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpFromTime.CustomFormat = "HH:mm";
            this.dtpFromTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(229, 5);
            this.dtpFromTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(63, 24);
            this.dtpFromTime.TabIndex = 128;
            this.dtpFromTime.TabStop = false;
            this.dtpFromTime.Text = "myDatePicker1";
            this.dtpFromTime.Value = new System.DateTime(2014, 10, 21, 0, 0, 0, 0);
            // 
            // dtptilltime
            // 
            this.dtptilltime.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtptilltime.CustomFormat = "HH:mm";
            this.dtptilltime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptilltime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptilltime.Location = new System.Drawing.Point(229, 37);
            this.dtptilltime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtptilltime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtptilltime.Name = "dtptilltime";
            this.dtptilltime.NullDate = new System.DateTime(((long)(0)));
            this.dtptilltime.ShowUpDown = true;
            this.dtptilltime.Size = new System.Drawing.Size(63, 24);
            this.dtptilltime.TabIndex = 127;
            this.dtptilltime.TabStop = false;
            this.dtptilltime.Text = "myDatePicker1";
            this.dtptilltime.Value = new System.DateTime(2014, 10, 21, 23, 59, 59, 0);
            // 
            // ddlDrivers
            // 
            this.ddlDrivers.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDrivers.Location = new System.Drawing.Point(423, 5);
            this.ddlDrivers.Name = "ddlDrivers";
            this.ddlDrivers.Size = new System.Drawing.Size(142, 26);
            this.ddlDrivers.TabIndex = 101;
            this.ddlDrivers.Text = "ddlDrivers";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnViewReport.Location = new System.Drawing.Point(876, 9);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(113, 52);
            this.btnViewReport.TabIndex = 91;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Text = "View Report";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dtpToDate
            // 
            this.dtpToDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(120, 37);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpToDate.Size = new System.Drawing.Size(102, 24);
            this.dtpToDate.TabIndex = 23;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Text = "myDatePicker1";
            this.dtpToDate.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 5);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromDate.Size = new System.Drawing.Size(102, 24);
            this.dtpFromDate.TabIndex = 21;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "From Date";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel Files (.xls)|*.xls|Advanced Excel Files (.xlsx)|*.xlsx";
            this.saveFileDialog1.FilterIndex = 0;
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLister.Location = new System.Drawing.Point(0, 0);
            // 
            // grdLister
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.grdLister.MasterTemplate.AllowDeleteRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.EnableFiltering = true;
            this.grdLister.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdLister.Name = "grdLister";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.Size = new System.Drawing.Size(1378, 605);
            this.grdLister.TabIndex = 119;
            this.grdLister.Text = "radGridView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlCriteria);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdLister);
            this.splitContainer1.Size = new System.Drawing.Size(1378, 742);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 118;
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Dash = false;
            this.radProgressBar1.Location = new System.Drawing.Point(1021, 67);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.Size = new System.Drawing.Size(147, 26);
            this.radProgressBar1.TabIndex = 152;
            this.radProgressBar1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rptfrmRentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.splitContainer1);
            this.FormTitle = "Rent Report";
            this.Name = "rptfrmRentReport";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Rent Report";
            this.Load += new System.EventHandler(this.rptfrmJobsPaymentList_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel pnlCriteria;
        private Telerik.WinControls.UI.RadButton btnViewReport;
        private UI.MyDatePicker dtpToDate;
        private System.Windows.Forms.Label label3;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList ddlDrivers;
        private UI.MyDatePicker dtptilltime;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadButton btnExportExcel;
        private System.Windows.Forms.Label label6;
        private UI.MyGridView grdPaymentTypes;
        private UI.MyDatePicker dtpFromTime;
        private Telerik.WinControls.UI.RadSpinEditor tbRent;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
    }
}