namespace Taxi_AppMain
{
    partial class rptfrmAccountInvoiceSummary
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptfrmAccountInvoiceSummary));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.AccountInvoiceSummaryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.ddlInvoiceType = new Telerik.WinControls.UI.RadDropDownList();
            this.optDefault = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.OPTDESC = new System.Windows.Forms.RadioButton();
            this.OPTASC = new System.Windows.Forms.RadioButton();
            this.ddlGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.chkAllGroups = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.chkAll = new Telerik.WinControls.UI.RadCheckBox();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountInvoiceSummaryModelBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountInvoiceSummaryModelBindingSource
            // 
            this.AccountInvoiceSummaryModelBindingSource.DataSource = typeof(Taxi_AppMain.Classes.AccountInvoiceSummaryModel);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.ddlInvoiceType);
            this.panel1.Controls.Add(this.optDefault);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OPTDESC);
            this.panel1.Controls.Add(this.OPTASC);
            this.panel1.Controls.Add(this.ddlGroup);
            this.panel1.Controls.Add(this.chkAllGroups);
            this.panel1.Controls.Add(this.ddlCompany);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.btnExit1);
            this.panel1.Controls.Add(this.btnExportPDF);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dtpTillDate);
            this.panel1.Controls.Add(this.radLabel3);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1506, 106);
            this.panel1.TabIndex = 108;
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnEmail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEmail.Location = new System.Drawing.Point(1082, 10);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(124, 64);
            this.btnEmail.TabIndex = 128;
            this.btnEmail.Text = "Email";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlInvoiceType
            // 
            this.ddlInvoiceType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "All Invoice";
            radListDataItem2.Text = "Paid Invoice";
            radListDataItem3.Text = "UnPaid Invoice";
            this.ddlInvoiceType.Items.Add(radListDataItem1);
            this.ddlInvoiceType.Items.Add(radListDataItem2);
            this.ddlInvoiceType.Items.Add(radListDataItem3);
            this.ddlInvoiceType.Location = new System.Drawing.Point(516, 78);
            this.ddlInvoiceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlInvoiceType.Name = "ddlInvoiceType";
            this.ddlInvoiceType.Size = new System.Drawing.Size(208, 21);
            this.ddlInvoiceType.TabIndex = 127;
            // 
            // optDefault
            // 
            this.optDefault.AutoSize = true;
            this.optDefault.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDefault.Location = new System.Drawing.Point(105, 78);
            this.optDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDefault.Name = "optDefault";
            this.optDefault.Size = new System.Drawing.Size(70, 18);
            this.optDefault.TabIndex = 126;
            this.optDefault.Tag = "0";
            this.optDefault.Text = "Default";
            this.optDefault.UseVisualStyleBackColor = true;
            this.optDefault.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 125;
            this.label1.Text = "Sort by";
            // 
            // OPTDESC
            // 
            this.OPTDESC.AutoSize = true;
            this.OPTDESC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTDESC.Location = new System.Drawing.Point(308, 78);
            this.OPTDESC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTDESC.Name = "OPTDESC";
            this.OPTDESC.Size = new System.Drawing.Size(95, 18);
            this.OPTDESC.TabIndex = 124;
            this.OPTDESC.Tag = "2";
            this.OPTDESC.Text = "Descending";
            this.OPTDESC.UseVisualStyleBackColor = true;
            this.OPTDESC.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // OPTASC
            // 
            this.OPTASC.AutoSize = true;
            this.OPTASC.Checked = true;
            this.OPTASC.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPTASC.Location = new System.Drawing.Point(197, 78);
            this.OPTASC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OPTASC.Name = "OPTASC";
            this.OPTASC.Size = new System.Drawing.Size(88, 18);
            this.OPTASC.TabIndex = 123;
            this.OPTASC.TabStop = true;
            this.OPTASC.Tag = "1";
            this.OPTASC.Text = "Ascending";
            this.OPTASC.UseVisualStyleBackColor = true;
            this.OPTASC.CheckedChanged += new System.EventHandler(this.optDefault_CheckedChanged);
            // 
            // ddlGroup
            // 
            this.ddlGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGroup.Location = new System.Drawing.Point(516, 42);
            this.ddlGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlGroup.Name = "ddlGroup";
            this.ddlGroup.Size = new System.Drawing.Size(208, 21);
            this.ddlGroup.TabIndex = 122;
            // 
            // chkAllGroups
            // 
            this.chkAllGroups.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllGroups.Location = new System.Drawing.Point(516, 12);
            this.chkAllGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllGroups.Name = "chkAllGroups";
            this.chkAllGroups.Size = new System.Drawing.Size(96, 22);
            this.chkAllGroups.TabIndex = 121;
            this.chkAllGroups.Text = "All  Groups";
            // 
            // ddlCompany
            // 
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(289, 43);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(208, 21);
            this.ddlCompany.TabIndex = 120;
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(289, 14);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 22);
            this.chkAll.TabIndex = 119;
            this.chkAll.Text = "All  Accounts";
            this.chkAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAll_ToggleStateChanged);
            // 
            // btnExit1
            // 
            this.btnExit1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit1.Image = ((System.Drawing.Image)(resources.GetObject("btnExit1.Image")));
            this.btnExit1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit1.Location = new System.Drawing.Point(1247, 10);
            this.btnExit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(133, 64);
            this.btnExit1.TabIndex = 118;
            this.btnExit1.Text = "Exit";
            this.btnExit1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.Image")));
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(917, 10);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(133, 64);
            this.btnExportPDF.TabIndex = 117;
            this.btnExportPDF.Text = "Export To PDF";
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Text = "Export To PDF";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(755, 21);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 53);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "View Report";
            this.btnPrint.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "View Report";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(126, 44);
            this.dtpTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(133, 24);
            this.dtpTillDate.TabIndex = 7;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Value = null;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(24, 44);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(64, 22);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Till Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(126, 10);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(133, 24);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(21, 10);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(79, 22);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "From Date";
            this.radLabel2.Click += new System.EventHandler(this.radLabel2_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSAccountInvoiceSummary";
            reportDataSource1.Value = this.AccountInvoiceSummaryModelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptAccountInvoiceSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 144);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1506, 956);
            this.reportViewer1.TabIndex = 109;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // rptfrmAccountInvoiceSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 1100);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormTitle = "Account Invoice Summary";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmAccountInvoiceSummary";
            this.ShowHeader = true;
            this.Text = "Account Invoice Summary";
            this.Load += new System.EventHandler(this.rptfrmAccountInvoiceSummary_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountInvoiceSummaryModelBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private System.Windows.Forms.BindingSource AccountInvoiceSummaryModelBindingSource;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadDropDownList ddlCompany;
        private Telerik.WinControls.UI.RadCheckBox chkAll;
        private Telerik.WinControls.UI.RadDropDownList ddlGroup;
        private Telerik.WinControls.UI.RadCheckBox chkAllGroups;
        private System.Windows.Forms.RadioButton optDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton OPTDESC;
        private System.Windows.Forms.RadioButton OPTASC;
        private Telerik.WinControls.UI.RadDropDownList ddlInvoiceType;
        private Telerik.WinControls.UI.RadButton btnEmail;
    }
}