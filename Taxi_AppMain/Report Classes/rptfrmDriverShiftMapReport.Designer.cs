namespace Taxi_AppMain
{
    partial class rptfrmDriverShiftMapReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Vu_BookingBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlCriteria = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Telerik.WinControls.UI.RadButton();
            this.ddlAllDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.btnViewReport = new Telerik.WinControls.UI.RadButton();
            this.btnExportPDF = new Telerik.WinControls.UI.RadButton();
            this.dtpToDate = new UI.MyDatePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.grdLister = new UI.MyGridView();
            this.lblTotalJobs = new System.Windows.Forms.Label();
            this.lblTotalEarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vu_BookingBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // Vu_BookingBaseBindingSource
            // 
            this.Vu_BookingBaseBindingSource.DataSource = typeof(Taxi_Model.Vu_BookingBase);
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlCriteria.Controls.Add(this.label1);
            this.pnlCriteria.Controls.Add(this.btnExportExcel);
            this.pnlCriteria.Controls.Add(this.ddlAllDriver);
            this.pnlCriteria.Controls.Add(this.btnViewReport);
            this.pnlCriteria.Controls.Add(this.btnExportPDF);
            this.pnlCriteria.Controls.Add(this.dtpToDate);
            this.pnlCriteria.Controls.Add(this.label3);
            this.pnlCriteria.Controls.Add(this.dtpFromDate);
            this.pnlCriteria.Controls.Add(this.label2);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 38);
            this.pnlCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(1449, 119);
            this.pnlCriteria.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 117;
            this.label1.Text = "Driver";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::Taxi_AppMain.Properties.Resources.excel;
            this.btnExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(1311, 14);
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
            // ddlAllDriver
            // 
            this.ddlAllDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAllDriver.Location = new System.Drawing.Point(136, 64);
            this.ddlAllDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlAllDriver.Name = "ddlAllDriver";
            this.ddlAllDriver.Size = new System.Drawing.Size(219, 24);
            this.ddlAllDriver.TabIndex = 115;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnViewReport.Location = new System.Drawing.Point(983, 14);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(150, 64);
            this.btnViewReport.TabIndex = 91;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Text = "View Report";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Image = global::Taxi_AppMain.Properties.Resources.pdf1;
            this.btnExportPDF.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportPDF.Location = new System.Drawing.Point(1158, 14);
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
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(372, 16);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(198, 24);
            this.dtpToDate.TabIndex = 23;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Value = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(341, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "To";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(136, 17);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(199, 24);
            this.dtpFromDate.TabIndex = 21;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date From";
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 200);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1449, 718);
            this.grdLister.TabIndex = 116;
            this.grdLister.Text = "myGridView1";
            this.grdLister.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdLister_CellDoubleClick);
            // 
            // lblTotalJobs
            // 
            this.lblTotalJobs.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblTotalJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalJobs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalJobs.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJobs.Location = new System.Drawing.Point(0, 157);
            this.lblTotalJobs.Name = "lblTotalJobs";
            this.lblTotalJobs.Size = new System.Drawing.Size(1449, 43);
            this.lblTotalJobs.TabIndex = 115;
            this.lblTotalJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalEarning
            // 
            this.lblTotalEarning.AutoSize = true;
            this.lblTotalEarning.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblTotalEarning.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalEarning.ForeColor = System.Drawing.Color.Red;
            this.lblTotalEarning.Location = new System.Drawing.Point(239, 249);
            this.lblTotalEarning.Name = "lblTotalEarning";
            this.lblTotalEarning.Size = new System.Drawing.Size(0, 23);
            this.lblTotalEarning.TabIndex = 122;
            // 
            // rptfrmDriverShiftMapReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 918);
            this.ControlBox = true;
            this.Controls.Add(this.lblTotalEarning);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.lblTotalJobs);
            this.Controls.Add(this.pnlCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Driver Shift Map Report";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmDriverShiftMapReport";
            this.ShowHeader = true;
            this.Text = "Driver Shift Map Report";
            this.Load += new System.EventHandler(this.rptfrmJobsList_Load);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.pnlCriteria, 0);
            this.Controls.SetChildIndex(this.lblTotalJobs, 0);
            this.Controls.SetChildIndex(this.grdLister, 0);
            this.Controls.SetChildIndex(this.lblTotalEarning, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vu_BookingBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAllDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel pnlCriteria;
        private UI.MyDatePicker dtpToDate;
        private System.Windows.Forms.Label label3;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource Vu_BookingBaseBindingSource;
        private Telerik.WinControls.UI.RadButton btnExportPDF;
        private Telerik.WinControls.UI.RadButton btnViewReport;
        private UI.MyGridView grdLister;
        private System.Windows.Forms.Label lblTotalJobs;
        private Telerik.WinControls.UI.RadDropDownList ddlAllDriver;
        private Telerik.WinControls.UI.RadButton btnExportExcel;
        private System.Windows.Forms.Label lblTotalEarning;
        private System.Windows.Forms.Label label1;
    }
}