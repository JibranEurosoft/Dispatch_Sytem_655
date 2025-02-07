namespace Taxi_AppMain
{
    partial class rptfrmInvoicePayment
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClsLogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClsInvoicePaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlInvoiceType = new Telerik.WinControls.UI.RadDropDownList();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.dtpToDate = new UI.MyDatePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFromDate = new UI.MyDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new Telerik.WinControls.UI.RadButton();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.btnExport = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ddlCompanyGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsInvoicePaymentBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(864, 378);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(895, 302);
            this.btnOnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // ClsLogoBindingSource
            // 
            this.ClsLogoBindingSource.DataMember = "ClsLogo";
            // 
            // ClsInvoicePaymentBindingSource
            // 
            this.ClsInvoicePaymentBindingSource.DataSource = typeof(Taxi_AppMain.Classes.ClsInvoicePayment);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ddlCompanyGroup);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ddlInvoiceType);
            this.panel1.Controls.Add(this.chkAllDriver);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ddlCompany);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Controls.Add(this.ddlSubCompany);
            this.panel1.Controls.Add(this.btnExit1);
            this.panel1.Controls.Add(this.btnEmail);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 130);
            this.panel1.TabIndex = 106;
            // 
            // ddlInvoiceType
            // 
            this.ddlInvoiceType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem4.Text = "All Invoice";
            radListDataItem5.Text = "Paid Invoice";
            radListDataItem6.Text = "UnPaid Invoice";
            this.ddlInvoiceType.Items.Add(radListDataItem4);
            this.ddlInvoiceType.Items.Add(radListDataItem5);
            this.ddlInvoiceType.Items.Add(radListDataItem6);
            this.ddlInvoiceType.Location = new System.Drawing.Point(467, 7);
            this.ddlInvoiceType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlInvoiceType.Name = "ddlInvoiceType";
            this.ddlInvoiceType.Size = new System.Drawing.Size(126, 21);
            this.ddlInvoiceType.TabIndex = 140;
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(26, 52);
            this.chkAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(103, 19);
            this.chkAllDriver.TabIndex = 139;
            this.chkAllDriver.Text = "All Accounts";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Location = new System.Drawing.Point(414, 87);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 24);
            this.dtpToDate.TabIndex = 138;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 137;
            this.label3.Text = "Till Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Location = new System.Drawing.Point(166, 87);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(129, 24);
            this.dtpFromDate.TabIndex = 136;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 135;
            this.label4.Text = "Invoice From";
            // 
            // ddlCompany
            // 
            this.ddlCompany.Enabled = false;
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(166, 47);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(271, 24);
            this.ddlCompany.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 132;
            this.label1.Text = "Sub Company";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportToExcel.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportToExcel.Location = new System.Drawing.Point(966, 26);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 59);
            this.btnExportToExcel.TabIndex = 131;
            this.btnExportToExcel.Text = "Export";
            this.btnExportToExcel.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportToExcel.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportToExcel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportToExcel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportToExcel.GetChildAt(0))).Text = "Export";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportToExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportToExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportToExcel.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(166, 7);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(271, 24);
            this.ddlSubCompany.TabIndex = 117;
            // 
            // btnExit1
            // 
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit1.Location = new System.Drawing.Point(1225, 26);
            this.btnExit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(124, 59);
            this.btnExit1.TabIndex = 69;
            this.btnExit1.Text = "Exit";
            this.btnExit1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnEmail
            // 
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnEmail.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmail.Location = new System.Drawing.Point(1094, 26);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(124, 59);
            this.btnEmail.TabIndex = 68;
            this.btnEmail.Text = "Email";
            this.btnEmail.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExport.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(838, 26);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(124, 59);
            this.btnExport.TabIndex = 67;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Text = "Export";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(709, 26);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 59);
            this.btnPrint.TabIndex = 66;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "Print";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "Taxi_AppMain_Classes_ClsLogo";
            reportDataSource3.Value = this.ClsLogoBindingSource;
            reportDataSource4.Name = "ClsInvoicePayment";
            reportDataSource4.Value = this.ClsInvoicePaymentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptInvoicePayment.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 168);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1373, 802);
            this.reportViewer1.TabIndex = 107;
            // 
            // ddlCompanyGroup
            // 
            this.ddlCompanyGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompanyGroup.Location = new System.Drawing.Point(520, 47);
            this.ddlCompanyGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompanyGroup.Name = "ddlCompanyGroup";
            this.ddlCompanyGroup.Size = new System.Drawing.Size(154, 24);
            this.ddlCompanyGroup.TabIndex = 142;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(465, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 18);
            this.label8.TabIndex = 141;
            this.label8.Text = "Group";
            // 
            // rptfrmInvoicePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 970);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormTitle = "Invoice Statement Report";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmInvoicePayment";
            this.ShowHeader = true;
            this.Text = "Invoice Statement";
            this.Load += new System.EventHandler(this.rptfrmInvoicePayment_Load_1);
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
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsInvoicePaymentBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlInvoiceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private Telerik.WinControls.UI.RadButton btnEmail;
        private Telerik.WinControls.UI.RadButton btnExport;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private Telerik.WinControls.UI.RadButton btnExportToExcel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList ddlCompany;
        private UI.MyDatePicker dtpToDate;
        private System.Windows.Forms.Label label3;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource ClsLogoBindingSource;
        private System.Windows.Forms.BindingSource ClsInvoicePaymentBindingSource;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadDropDownList ddlInvoiceType;
        private Telerik.WinControls.UI.RadDropDownList ddlCompanyGroup;
        private System.Windows.Forms.Label label8;
    }
}