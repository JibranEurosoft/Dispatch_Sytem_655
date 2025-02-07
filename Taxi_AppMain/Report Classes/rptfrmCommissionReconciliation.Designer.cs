namespace Taxi_AppMain
{
    partial class rptfrmCommissionReconciliation
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClsLogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClsCommissionReconciliationReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlCriteria = new Telerik.WinControls.UI.RadPanel();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.chkAllDriver = new System.Windows.Forms.CheckBox();
            this.chkAllSubCompany = new System.Windows.Forms.CheckBox();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.ddl_Driver = new Telerik.WinControls.UI.RadDropDownList();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.chkAllDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new UI.MyDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsCommissionReconciliationReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_Driver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ClsLogoBindingSource
            // 
            this.ClsLogoBindingSource.DataMember = "ClsLogo";
            // 
            // ClsCommissionReconciliationReportBindingSource
            // 
            this.ClsCommissionReconciliationReportBindingSource.DataMember = "ClsCommissionReconciliationReport";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Taxi_AppMain_Classes_ClsLogo";
            reportDataSource1.Value = this.ClsLogoBindingSource;
            reportDataSource2.Name = "ClsCommissionReconciliationReport";
            reportDataSource2.Value = this.ClsCommissionReconciliationReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptCommissionReconciliation.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 149);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(941, 402);
            this.reportViewer1.TabIndex = 120;
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCriteria.Controls.Add(this.dtpFromDate);
            this.pnlCriteria.Controls.Add(this.label1);
            this.pnlCriteria.Controls.Add(this.chkAllDate);
            this.pnlCriteria.Controls.Add(this.btnExit1);
            this.pnlCriteria.Controls.Add(this.chkAllDriver);
            this.pnlCriteria.Controls.Add(this.chkAllSubCompany);
            this.pnlCriteria.Controls.Add(this.ddlSubCompany);
            this.pnlCriteria.Controls.Add(this.ddl_Driver);
            this.pnlCriteria.Controls.Add(this.btnExportPDF);
            this.pnlCriteria.Controls.Add(this.btnPrint);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 38);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(941, 111);
            this.pnlCriteria.TabIndex = 119;
            // 
            // btnExit1
            // 
            this.btnExit1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit1.Location = new System.Drawing.Point(815, 38);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(114, 52);
            this.btnExit1.TabIndex = 98;
            this.btnExit1.Text = "Exit";
            this.btnExit1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.AutoSize = true;
            this.chkAllDriver.Checked = true;
            this.chkAllDriver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(18, 48);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(83, 22);
            this.chkAllDriver.TabIndex = 97;
            this.chkAllDriver.Text = "All Driver";
            this.chkAllDriver.UseVisualStyleBackColor = true;
            // 
            // chkAllSubCompany
            // 
            this.chkAllSubCompany.AutoSize = true;
            this.chkAllSubCompany.Checked = true;
            this.chkAllSubCompany.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllSubCompany.Location = new System.Drawing.Point(18, 16);
            this.chkAllSubCompany.Name = "chkAllSubCompany";
            this.chkAllSubCompany.Size = new System.Drawing.Size(136, 22);
            this.chkAllSubCompany.TabIndex = 96;
            this.chkAllSubCompany.Text = "All Sub Company";
            this.chkAllSubCompany.UseVisualStyleBackColor = true;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Enabled = false;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.Location = new System.Drawing.Point(163, 13);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(226, 26);
            this.ddlSubCompany.TabIndex = 95;
            // 
            // ddl_Driver
            // 
            this.ddl_Driver.Enabled = false;
            this.ddl_Driver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Driver.Location = new System.Drawing.Point(163, 45);
            this.ddl_Driver.Name = "ddl_Driver";
            this.ddl_Driver.Size = new System.Drawing.Size(226, 26);
            this.ddl_Driver.TabIndex = 94;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(656, 39);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(114, 52);
            this.btnExportPDF.TabIndex = 92;
            this.btnExportPDF.Text = "Export To PDF";
            this.btnExportPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExportPDF.GetChildAt(0))).Text = "Export To PDF";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExportPDF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(498, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 52);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "PRINT";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chkAllDate
            // 
            this.chkAllDate.AutoSize = true;
            this.chkAllDate.Checked = true;
            this.chkAllDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDate.Location = new System.Drawing.Point(18, 78);
            this.chkAllDate.Name = "chkAllDate";
            this.chkAllDate.Size = new System.Drawing.Size(40, 22);
            this.chkAllDate.TabIndex = 99;
            this.chkAllDate.Text = "All";
            this.chkAllDate.UseVisualStyleBackColor = true;
            this.chkAllDate.CheckedChanged += new System.EventHandler(this.chkAllDate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 100;
            this.label1.Text = "Starting From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(163, 78);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpFromDate.Size = new System.Drawing.Size(137, 24);
            this.dtpFromDate.TabIndex = 101;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            // 
            // rptfrmCommissionReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 551);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlCriteria);
            this.FormTitle = "Rent Reconciliation Report";
            this.Name = "rptfrmCommissionReconciliation";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Rent Reconciliation Report";
            this.Load += new System.EventHandler(this.rptfrmDriverLoginHistory_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.pnlCriteria, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsLogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClsCommissionReconciliationReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl_Driver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Telerik.WinControls.UI.RadPanel pnlCriteria;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadDropDownList ddl_Driver;
        private System.Windows.Forms.CheckBox chkAllDriver;
        private System.Windows.Forms.CheckBox chkAllSubCompany;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private System.Windows.Forms.BindingSource ClsLogoBindingSource;
        private System.Windows.Forms.BindingSource ClsCommissionReconciliationReportBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAllDate;
        private UI.MyDatePicker dtpFromDate;
    }
}