namespace Taxi_AppMain
{
    partial class rptfrmdriverPaymentReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pnlCriteria = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Telerik.WinControls.UI.RadButton();
            this.dtptilltime = new UI.MyDatePicker();
            this.dtpFromTime = new UI.MyDatePicker();
            this.btnViewReport = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.dtpToDate = new UI.MyDatePicker();
            this.dtpFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.grdLister = new UI.MyGridView();
            this.chkAllDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlAllDriver = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCriteria.Controls.Add(this.chkAllDriver);
            this.pnlCriteria.Controls.Add(this.ddlAllDriver);
            this.pnlCriteria.Controls.Add(this.label1);
            this.pnlCriteria.Controls.Add(this.btnExportExcel);
            this.pnlCriteria.Controls.Add(this.dtptilltime);
            this.pnlCriteria.Controls.Add(this.dtpFromTime);
            this.pnlCriteria.Controls.Add(this.btnViewReport);
            this.pnlCriteria.Controls.Add(this.btnExportPDF);
            this.pnlCriteria.Controls.Add(this.btnPrint);
            this.pnlCriteria.Controls.Add(this.dtpToDate);
            this.pnlCriteria.Controls.Add(this.dtpFromDate);
            this.pnlCriteria.Controls.Add(this.label2);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 38);
            this.pnlCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(1293, 89);
            this.pnlCriteria.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 117;
            this.label1.Text = "Till Date";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(1091, 12);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(142, 64);
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
            // dtptilltime
            // 
            this.dtptilltime.CustomFormat = "HH:mm";
            this.dtptilltime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptilltime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptilltime.Location = new System.Drawing.Point(565, 7);
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
            this.dtpFromTime.Location = new System.Drawing.Point(238, 7);
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
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnViewReport.Location = new System.Drawing.Point(679, 12);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(125, 64);
            this.btnViewReport.TabIndex = 91;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Text = "View Report";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(952, 12);
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
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Location = new System.Drawing.Point(810, 12);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 64);
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
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(437, 7);
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
            this.dtpFromDate.Location = new System.Drawing.Point(110, 9);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(119, 24);
            this.dtpFromDate.TabIndex = 21;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "From Date";
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 127);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1293, 577);
            this.grdLister.TabIndex = 117;
            this.grdLister.Text = "myGridView1";
            // 
            // chkAllDriver
            // 
            this.chkAllDriver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllDriver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllDriver.Location = new System.Drawing.Point(10, 53);
            this.chkAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAllDriver.Name = "chkAllDriver";
            this.chkAllDriver.Size = new System.Drawing.Size(88, 23);
            this.chkAllDriver.TabIndex = 119;
            this.chkAllDriver.Text = "All Driver";
            this.chkAllDriver.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAllDriver.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllDriver_ToggleStateChanged);
            // 
            // ddlAllDriver
            // 
            this.ddlAllDriver.Enabled = false;
            this.ddlAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAllDriver.Location = new System.Drawing.Point(110, 53);
            this.ddlAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlAllDriver.Name = "ddlAllDriver";
            this.ddlAllDriver.Size = new System.Drawing.Size(213, 24);
            this.ddlAllDriver.TabIndex = 118;
            this.ddlAllDriver.Enter += new System.EventHandler(this.ddlAllDriver_Enter);
            // 
            // rptfrmdriverPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 704);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.pnlCriteria);
            this.FormTitle = "Driver Payment Report";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmdriverPaymentReport";
            this.ShowHeader = true;
            this.Text = "Driver Payment Report";
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.pnlCriteria, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtptilltime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlCriteria;
        private Telerik.WinControls.UI.RadButton btnExportExcel;
        private UI.MyDatePicker dtptilltime;
        private UI.MyDatePicker dtpFromTime;
        private Telerik.WinControls.UI.RadButton btnViewReport;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private UI.MyDatePicker dtpToDate;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private UI.MyGridView grdLister;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadCheckBox chkAllDriver;
        private Telerik.WinControls.UI.RadDropDownList ddlAllDriver;
    }
}