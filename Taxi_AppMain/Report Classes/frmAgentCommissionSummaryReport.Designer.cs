﻿namespace Taxi_AppMain
{
    partial class frmAgentCommissionSummaryReport
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
       //   Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1=null;
    //      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = null;
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3=null;
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = null;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Vu_BookingBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClsLogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.chkAllAgents = new Telerik.WinControls.UI.RadCheckBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.pnlPaymentTypes = new System.Windows.Forms.GroupBox();
            this.opBoth = new Telerik.WinControls.UI.RadRadioButton();
            this.opCreditCard = new Telerik.WinControls.UI.RadRadioButton();
            this.opCash = new Telerik.WinControls.UI.RadRadioButton();
            this.lblGroup = new System.Windows.Forms.Label();
            this.ddlGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.chkShowCharges = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlDepartment = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendEmail = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.ddlCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.clayhallExecutiveCarsDataSet = new Taxi_AppMain.ClayhallExecutiveCarsDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vu_BookingBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllAgents)).BeginInit();
            this.pnlPaymentTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opBoth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCreditCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clayhallExecutiveCarsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Vu_BookingBaseBindingSource
            // 
            this.Vu_BookingBaseBindingSource.DataSource = typeof(Taxi_AppMain.ClsAgentCommissionSummary);
            // 
            // ClsLogoBindingSource
            // 
            this.ClsLogoBindingSource.DataSource = typeof(Taxi_AppMain.Classes.ClsLogo);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.radPanel1.Controls.Add(this.chkAllAgents);
            this.radPanel1.Controls.Add(this.lblAgent);
            this.radPanel1.Controls.Add(this.pnlPaymentTypes);
            this.radPanel1.Controls.Add(this.lblGroup);
            this.radPanel1.Controls.Add(this.ddlGroup);
            this.radPanel1.Controls.Add(this.ddlSubCompany);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.chkShowCharges);
            this.radPanel1.Controls.Add(this.ddlDepartment);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.btnSendEmail);
            this.radPanel1.Controls.Add(this.btnExportPDF);
            this.radPanel1.Controls.Add(this.btnPrint);
            this.radPanel1.Controls.Add(this.ddlCompany);
            this.radPanel1.Controls.Add(this.dtpTillDate);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.dtpFromDate);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 38);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1297, 122);
            this.radPanel1.TabIndex = 108;
            // 
            // chkAllAgents
            // 
            this.chkAllAgents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllAgents.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllAgents.Location = new System.Drawing.Point(15, 11);
            this.chkAllAgents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllAgents.Name = "chkAllAgents";
            this.chkAllAgents.Size = new System.Drawing.Size(38, 22);
            this.chkAllAgents.TabIndex = 129;
            this.chkAllAgents.Text = "All";
            this.chkAllAgents.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllAgents.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllAgents_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chkAllAgents.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chkAllAgents.GetChildAt(0))).Text = "All";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.chkAllAgents.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.chkAllAgents.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.chkAllAgents.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.Location = new System.Drawing.Point(61, 12);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(46, 18);
            this.lblAgent.TabIndex = 130;
            this.lblAgent.Text = "Agent";
            // 
            // pnlPaymentTypes
            // 
            this.pnlPaymentTypes.Controls.Add(this.opBoth);
            this.pnlPaymentTypes.Controls.Add(this.opCreditCard);
            this.pnlPaymentTypes.Controls.Add(this.opCash);
            this.pnlPaymentTypes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPaymentTypes.Location = new System.Drawing.Point(560, 53);
            this.pnlPaymentTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPaymentTypes.Name = "pnlPaymentTypes";
            this.pnlPaymentTypes.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPaymentTypes.Size = new System.Drawing.Size(240, 62);
            this.pnlPaymentTypes.TabIndex = 128;
            this.pnlPaymentTypes.TabStop = false;
            this.pnlPaymentTypes.Text = "Payment Type";
            this.pnlPaymentTypes.Visible = false;
            // 
            // opBoth
            // 
            this.opBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opBoth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opBoth.Location = new System.Drawing.Point(175, 27);
            this.opBoth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opBoth.Name = "opBoth";
            this.opBoth.Size = new System.Drawing.Size(48, 19);
            this.opBoth.TabIndex = 2;
            this.opBoth.Text = "Both";
            this.opBoth.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // opCreditCard
            // 
            this.opCreditCard.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCreditCard.Location = new System.Drawing.Point(71, 27);
            this.opCreditCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opCreditCard.Name = "opCreditCard";
            this.opCreditCard.Size = new System.Drawing.Size(87, 19);
            this.opCreditCard.TabIndex = 1;
            this.opCreditCard.Text = "Credit Card";
            // 
            // opCash
            // 
            this.opCash.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCash.Location = new System.Drawing.Point(7, 27);
            this.opCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opCash.Name = "opCash";
            this.opCash.Size = new System.Drawing.Size(49, 19);
            this.opCash.TabIndex = 0;
            this.opCash.Text = "Cash";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(456, 14);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(76, 18);
            this.lblGroup.TabIndex = 127;
            this.lblGroup.Text = "A/C Group";
            this.lblGroup.Visible = false;
            // 
            // ddlGroup
            // 
            this.ddlGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGroup.Location = new System.Drawing.Point(560, 10);
            this.ddlGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlGroup.Name = "ddlGroup";
            this.ddlGroup.Size = new System.Drawing.Size(216, 24);
            this.ddlGroup.TabIndex = 126;
            this.ddlGroup.Visible = false;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(1163, 7);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(264, 24);
            this.ddlSubCompany.TabIndex = 100;
            this.ddlSubCompany.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1007, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 99;
            this.label3.Text = "Company Header";
            this.label3.Visible = false;
            // 
            // chkShowCharges
            // 
            this.chkShowCharges.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowCharges.Location = new System.Drawing.Point(413, 50);
            this.chkShowCharges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowCharges.Name = "chkShowCharges";
            this.chkShowCharges.Size = new System.Drawing.Size(117, 19);
            this.chkShowCharges.TabIndex = 98;
            this.chkShowCharges.Text = "Show Charges";
            this.chkShowCharges.Visible = false;
            this.chkShowCharges.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkShowCharges_ToggleStateChanged);
            // 
            // ddlDepartment
            // 
            this.ddlDepartment.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDepartment.Location = new System.Drawing.Point(143, 95);
            this.ddlDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDepartment.Name = "ddlDepartment";
            this.ddlDepartment.Size = new System.Drawing.Size(264, 24);
            this.ddlDepartment.TabIndex = 97;
            this.ddlDepartment.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 96;
            this.label1.Text = "By Department";
            this.label1.Visible = false;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnSendEmail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendEmail.Location = new System.Drawing.Point(1013, 48);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(133, 64);
            this.btnSendEmail.TabIndex = 95;
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
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(1160, 48);
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
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(867, 49);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 64);
            this.btnPrint.TabIndex = 89;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "PRINT";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlCompany
            // 
            this.ddlCompany.Enabled = false;
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(143, 6);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(264, 24);
            this.ddlCompany.TabIndex = 18;
            this.ddlCompany.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCompany_SelectedIndexChanged);
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(363, 51);
            this.dtpTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(133, 24);
            this.dtpTillDate.TabIndex = 3;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Value = null;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(283, 53);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(62, 22);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(143, 51);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(133, 24);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(12, 53);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(79, 22);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "From Date";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Vu_BookingBaseBindingSource;
            reportDataSource2.Name = "Taxi_AppMain_Classes_ClsLogo";
            reportDataSource2.Value = this.ClsLogoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.Template2_rptAgentCommissionStatement.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 160);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1297, 839);
            this.reportViewer1.TabIndex = 116;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // clayhallExecutiveCarsDataSet
            // 
            this.clayhallExecutiveCarsDataSet.DataSetName = "ClayhallExecutiveCarsDataSet";
            this.clayhallExecutiveCarsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmAgentCommissionSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 999);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.radPanel1);
            this.FormTitle = " Agent Commission Summary Report";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAgentCommissionSummaryReport";
            this.ShowHeader = true;
            this.Text = " Agent Commission Summary Report";
            this.Load += new System.EventHandler(this.frmDriverCommissionReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDriverCommissionReport_KeyDown);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.Vu_BookingBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllAgents)).EndInit();
            this.pnlPaymentTypes.ResumeLayout(false);
            this.pnlPaymentTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opBoth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCreditCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clayhallExecutiveCarsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadDropDownList ddlCompany;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSendEmail;
        private System.Windows.Forms.BindingSource Vu_BookingBaseBindingSource;
        private System.Windows.Forms.BindingSource ClsLogoBindingSource;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadCheckBox chkAllAgents;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.GroupBox pnlPaymentTypes;
        private Telerik.WinControls.UI.RadRadioButton opBoth;
        private Telerik.WinControls.UI.RadRadioButton opCreditCard;
        private Telerik.WinControls.UI.RadRadioButton opCash;
        private System.Windows.Forms.Label lblGroup;
        private Telerik.WinControls.UI.RadDropDownList ddlGroup;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadCheckBox chkShowCharges;
        private Telerik.WinControls.UI.RadDropDownList ddlDepartment;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ClayhallExecutiveCarsDataSet clayhallExecutiveCarsDataSet;
    }
}