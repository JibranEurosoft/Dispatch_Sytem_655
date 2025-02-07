namespace Taxi_AppMain
{
    partial class rptfrmDriverSummaryReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClsDriverSummaryReportcsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.btnExportExcel = new Telerik.WinControls.UI.RadButton();
            this.pnlCriteria = new Telerik.WinControls.UI.RadPanel();
            this.txtPaymentTypes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdPaymentTypes = new UI.MyGridView();
            this.chkIndividualDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.btnSendEmail = new Telerik.WinControls.UI.RadButton();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlAllDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.dtptilltime = new UI.MyDatePicker();
            this.dtpFromTime = new UI.MyDatePicker();
            this.dtpToDate = new UI.MyDatePicker();
            this.dtpFromDate = new UI.MyDatePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClsLogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddlDriverType = new UI.MyDropDownList();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsDriverSummaryReportcsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIndividualDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriverType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            this.SuspendLayout();
            // 
            // ClsDriverSummaryReportcsBindingSource
            // 
            this.ClsDriverSummaryReportcsBindingSource.DataSource = typeof(Taxi_AppMain.ClsDriverSummaryReportcs);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Till Date";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(698, 10);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 64);
            this.btnPrint.TabIndex = 89;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "PRINT";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(846, 10);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(133, 64);
            this.btnExportPDF.TabIndex = 90;
            this.btnExportPDF.Text = "Export To PDF";
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Text = "Export To PDF";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(988, 10);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(148, 64);
            this.btnExportExcel.TabIndex = 116;
            this.btnExportExcel.Text = "Export To EXCEL";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportExcel.GetChildAt(0))).Text = "Export To EXCEL";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCriteria.Controls.Add(this.ddlDriverType);
            this.pnlCriteria.Controls.Add(this.radLabel16);
            this.pnlCriteria.Controls.Add(this.txtPaymentTypes);
            this.pnlCriteria.Controls.Add(this.label6);
            this.pnlCriteria.Controls.Add(this.grdPaymentTypes);
            this.pnlCriteria.Controls.Add(this.chkIndividualDriver);
            this.pnlCriteria.Controls.Add(this.btnSendEmail);
            this.pnlCriteria.Controls.Add(this.chkAllDriver);
            this.pnlCriteria.Controls.Add(this.btnExportExcel);
            this.pnlCriteria.Controls.Add(this.ddlAllDriver);
            this.pnlCriteria.Controls.Add(this.dtptilltime);
            this.pnlCriteria.Controls.Add(this.dtpFromTime);
            this.pnlCriteria.Controls.Add(this.btnExportPDF);
            this.pnlCriteria.Controls.Add(this.btnPrint);
            this.pnlCriteria.Controls.Add(this.dtpToDate);
            this.pnlCriteria.Controls.Add(this.label3);
            this.pnlCriteria.Controls.Add(this.dtpFromDate);
            this.pnlCriteria.Controls.Add(this.label2);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 38);
            this.pnlCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(1458, 161);
            this.pnlCriteria.TabIndex = 113;
            // 
            // txtPaymentTypes
            // 
            this.txtPaymentTypes.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPaymentTypes.Location = new System.Drawing.Point(379, 81);
            this.txtPaymentTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPaymentTypes.Name = "txtPaymentTypes";
            this.txtPaymentTypes.Size = new System.Drawing.Size(108, 22);
            this.txtPaymentTypes.TabIndex = 152;
            this.txtPaymentTypes.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(371, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 151;
            this.label6.Text = "Payment Type";
            // 
            // grdPaymentTypes
            // 
            this.grdPaymentTypes.AutoCellFormatting = false;
            this.grdPaymentTypes.EnableCheckInCheckOut = false;
            this.grdPaymentTypes.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdPaymentTypes.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdPaymentTypes.Location = new System.Drawing.Point(500, 47);
            this.grdPaymentTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdPaymentTypes.MasterTemplate.AllowAddNewRow = false;
            this.grdPaymentTypes.MasterTemplate.AllowEditRow = false;
            this.grdPaymentTypes.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdPaymentTypes.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdPaymentTypes.Name = "grdPaymentTypes";
            this.grdPaymentTypes.PKFieldColumnName = "";
            this.grdPaymentTypes.ShowGroupPanel = false;
            this.grdPaymentTypes.ShowImageOnActionButton = true;
            this.grdPaymentTypes.Size = new System.Drawing.Size(183, 114);
            this.grdPaymentTypes.TabIndex = 150;
            this.grdPaymentTypes.Text = "myGridView1";
            // 
            // chkIndividualDriver
            // 
            this.chkIndividualDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndividualDriver.Location = new System.Drawing.Point(1288, 32);
            this.chkIndividualDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIndividualDriver.Name = "chkIndividualDriver";
            this.chkIndividualDriver.Size = new System.Drawing.Size(142, 23);
            this.chkIndividualDriver.TabIndex = 120;
            this.chkIndividualDriver.Text = "Individual Driver";
            this.chkIndividualDriver.Visible = false;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnSendEmail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendEmail.Location = new System.Drawing.Point(1147, 10);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(136, 64);
            this.btnSendEmail.TabIndex = 118;
            this.btnSendEmail.Text = "Email";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(30, 50);
            this.chkAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(88, 23);
            this.chkAllDriver.TabIndex = 117;
            this.chkAllDriver.Text = "All Driver";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // ddlAllDriver
            // 
            this.ddlAllDriver.Enabled = false;
            this.ddlAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAllDriver.Location = new System.Drawing.Point(150, 47);
            this.ddlAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlAllDriver.Name = "ddlAllDriver";
            this.ddlAllDriver.Size = new System.Drawing.Size(213, 24);
            this.ddlAllDriver.TabIndex = 115;
            this.ddlAllDriver.Enter += new System.EventHandler(this.ddlAllDriver_Enter);
            // 
            // dtptilltime
            // 
            this.dtptilltime.CustomFormat = "HH:mm";
            this.dtptilltime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptilltime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptilltime.Location = new System.Drawing.Point(598, 9);
            this.dtptilltime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtptilltime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtptilltime.Name = "dtptilltime";
            this.dtptilltime.ShowUpDown = true;
            this.dtptilltime.Size = new System.Drawing.Size(85, 24);
            this.dtptilltime.TabIndex = 113;
            this.dtptilltime.TabStop = false;
            this.dtptilltime.Text = "00:00";
            this.dtptilltime.Value = new System.DateTime(2014, 10, 21, 0, 0, 0, 0);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dtpFromTime.CustomFormat = "HH:mm";
            this.dtpFromTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(279, 9);
            this.dtpFromTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(85, 24);
            this.dtpFromTime.TabIndex = 112;
            this.dtpFromTime.TabStop = false;
            this.dtpFromTime.Text = "00:00";
            this.dtpFromTime.Value = new System.DateTime(2014, 10, 21, 0, 0, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(471, 9);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 24);
            this.dtpToDate.TabIndex = 23;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Value = null;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(150, 10);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(119, 24);
            this.dtpFromDate.TabIndex = 21;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "ClsDriverSummaryReport";
            reportDataSource4.Value = this.ClsDriverSummaryReportcsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptDriverSummaryReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 199);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1458, 761);
            this.reportViewer1.TabIndex = 114;
            // 
            // ClsLogoBindingSource
            // 
            this.ClsLogoBindingSource.DataSource = typeof(Taxi_AppMain.Classes.ClsLogo);
            // 
            // ddlDriverType
            // 
            this.ddlDriverType.Caption = null;
            this.ddlDriverType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriverType.Location = new System.Drawing.Point(150, 83);
            this.ddlDriverType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDriverType.Name = "ddlDriverType";
            this.ddlDriverType.Property = null;
            this.ddlDriverType.ShowDownArrow = true;
            this.ddlDriverType.Size = new System.Drawing.Size(147, 24);
            this.ddlDriverType.TabIndex = 154;
            this.ddlDriverType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlDriverType_SelectedIndexChanged);
            this.ddlDriverType.Enter += new System.EventHandler(this.ddlDriverType_Enter);
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.Location = new System.Drawing.Point(34, 84);
            this.radLabel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(87, 22);
            this.radLabel16.TabIndex = 153;
            this.radLabel16.Text = "Driver Type";
            // 
            // rptfrmDriverSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 960);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlCriteria);
            this.FormTitle = "Driver Job Summary Report";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmDriverSummaryReport";
            this.ShowHeader = true;
            this.Text = "Driver Job Summary Report";
            this.Load += new System.EventHandler(this.rptfrmJobsList_Load);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.pnlCriteria, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsDriverSummaryReportcsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIndividualDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriverType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton btnExportExcel;
        private Telerik.WinControls.UI.RadPanel pnlCriteria;
        private Telerik.WinControls.UI.RadDropDownList ddlAllDriver;
        private UI.MyDatePicker dtptilltime;
        private UI.MyDatePicker dtpFromTime;
        private UI.MyDatePicker dtpToDate;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadButton btnSendEmail;
        private System.Windows.Forms.BindingSource ClsDriverSummaryReportcsBindingSource;
        private System.Windows.Forms.BindingSource ClsLogoBindingSource;
        private Telerik.WinControls.UI.RadCheckBox chkIndividualDriver;
        private UI.MyGridView grdPaymentTypes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaymentTypes;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private UI.MyDropDownList ddlDriverType;
        private Telerik.WinControls.UI.RadLabel radLabel16;
    }
}