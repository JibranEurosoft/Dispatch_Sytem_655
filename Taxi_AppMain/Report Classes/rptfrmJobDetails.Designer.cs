namespace Taxi_AppMain
{
    partial class rptfrmJobDetails
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
            this.vuBookingDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnEmailPrint = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlCriteria = new System.Windows.Forms.ComboBox();
            this.chkPaymentSummary = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vuBookingDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmailPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1122, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Size = new System.Drawing.Size(90, 47);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // vuBookingDetailBindingSource
            // 
            this.vuBookingDetailBindingSource.DataSource = typeof(Taxi_Model.Vu_BookingDetail);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Taxi_Model_Vu_BookingDetail";
            reportDataSource1.Value = this.vuBookingDetailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Taxi_AppMain.ReportDesigns.rptJobDetails.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 38);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1216, 922);
            this.reportViewer1.TabIndex = 114;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            this.reportViewer1.LocationChanged += new System.EventHandler(this.reportViewer1_LocationChanged);
            // 
            // btnEmailPrint
            // 
            this.btnEmailPrint.Image = global::Taxi_AppMain.Properties.Resources.email;
            this.btnEmailPrint.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailPrint.Location = new System.Drawing.Point(1, 0);
            this.btnEmailPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmailPrint.Name = "btnEmailPrint";
            this.btnEmailPrint.Size = new System.Drawing.Size(133, 38);
            this.btnEmailPrint.TabIndex = 115;
            this.btnEmailPrint.Text = "Email Print";
            this.btnEmailPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmailPrint.Click += new System.EventHandler(this.btnEmailPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmailPrint.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmailPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmailPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmailPrint.GetChildAt(0))).Text = "Email Print";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmailPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmailPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmailPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(148, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 116;
            this.label1.Text = "Report for :";
            // 
            // ddlCriteria
            // 
            this.ddlCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlCriteria.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCriteria.FormattingEnabled = true;
            this.ddlCriteria.Items.AddRange(new object[] {
            "Driver",
            "Customer"});
            this.ddlCriteria.Location = new System.Drawing.Point(248, 10);
            this.ddlCriteria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCriteria.Name = "ddlCriteria";
            this.ddlCriteria.Size = new System.Drawing.Size(131, 26);
            this.ddlCriteria.TabIndex = 117;
            this.ddlCriteria.Text = "Driver";
            this.ddlCriteria.SelectedIndexChanged += new System.EventHandler(this.ddlCriteria_SelectedIndexChanged);
            // 
            // chkPaymentSummary
            // 
            this.chkPaymentSummary.BackColor = System.Drawing.Color.DodgerBlue;
            this.chkPaymentSummary.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkPaymentSummary.ForeColor = System.Drawing.Color.White;
            this.chkPaymentSummary.Location = new System.Drawing.Point(390, 2);
            this.chkPaymentSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPaymentSummary.Name = "chkPaymentSummary";
            this.chkPaymentSummary.Size = new System.Drawing.Size(173, 44);
            this.chkPaymentSummary.TabIndex = 118;
            this.chkPaymentSummary.Text = "Payment Summary";
            this.chkPaymentSummary.UseVisualStyleBackColor = false;
            this.chkPaymentSummary.Visible = false;
            this.chkPaymentSummary.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rptfrmJobDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 960);
            this.Controls.Add(this.chkPaymentSummary);
            this.Controls.Add(this.ddlCriteria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEmailPrint);
            this.Controls.Add(this.reportViewer1);
            this.FormTitle = "";
            this.HeaderColor = System.Drawing.Color.DodgerBlue;
            this.HeaderForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "rptfrmJobDetails";
            this.ShowHeader = true;
            this.Text = "Booking Report";
            this.Load += new System.EventHandler(this.rptfrmJobDetails_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.btnEmailPrint, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ddlCriteria, 0);
            this.Controls.SetChildIndex(this.chkPaymentSummary, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vuBookingDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmailPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource vuBookingDetailBindingSource;
        private Telerik.WinControls.UI.RadButton btnEmailPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlCriteria;
        private System.Windows.Forms.CheckBox chkPaymentSummary;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}