namespace UI
{
    partial class frmViewerBase
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFilter = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.pnlAction = new Telerik.WinControls.UI.RadPanel();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnSendEmail = new Telerik.WinControls.UI.RadButton();
            this.txtMessage = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtSubject = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtTo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.optPdf = new Telerik.WinControls.UI.RadRadioButton();
            this.optExcel = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            //this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            //this.office2010Theme1 = new Telerik.WinControls.Themes.Office2010Theme();
            //this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            //this.vistaTheme1 = new Telerik.WinControls.Themes.VistaTheme();
            //this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.PanelContainer.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAction)).BeginInit();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.AliceBlue;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(803, 968);
            this.reportViewer1.TabIndex = 104;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reportViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 968);
            this.splitContainer1.SplitterDistance = 803;
            this.splitContainer1.TabIndex = 105;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlAction, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 968);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlFilter
            // 
            this.pnlFilter.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pnlFilter.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(1);
            // 
            // pnlFilter.PanelContainer
            // 
            this.pnlFilter.PanelContainer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlFilter.PanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFilter.PanelContainer.Controls.Add(this.btnGenerate);
            this.pnlFilter.PanelContainer.Controls.Add(this.radLabel9);
            this.pnlFilter.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.PanelContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlFilter.PanelContainer.Name = "PanelContainer";
            this.pnlFilter.PanelContainer.Size = new System.Drawing.Size(195, 524);
            this.pnlFilter.PanelContainer.TabIndex = 0;
            // 
            // 
            // 
            this.pnlFilter.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.pnlFilter.Size = new System.Drawing.Size(197, 526);
            this.pnlFilter.TabIndex = 0;
            this.pnlFilter.Text = "radScrollablePanel1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = global::UI.Resource1.print2;
            this.btnGenerate.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGenerate.Location = new System.Drawing.Point(0, 478);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(191, 42);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerate.ThemeName = "Office2010";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).Image = global::UI.Resource1.print2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGenerate.GetChildAt(0))).Text = "Generate";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGenerate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel9
            // 
            this.radLabel9.AutoSize = false;
            this.radLabel9.BackColor = System.Drawing.SystemColors.Highlight;
            this.radLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.ForeColor = System.Drawing.Color.White;
            this.radLabel9.Location = new System.Drawing.Point(0, 0);
            this.radLabel9.Name = "radLabel9";
            // 
            // 
            // 
            this.radLabel9.RootElement.ForeColor = System.Drawing.Color.White;
            this.radLabel9.Size = new System.Drawing.Size(191, 20);
            this.radLabel9.TabIndex = 17;
            this.radLabel9.Text = "Filter";
            // 
            // pnlAction
            // 
            this.pnlAction.AutoScroll = true;
            this.pnlAction.Controls.Add(this.radPageView1);
            this.pnlAction.Controls.Add(this.radLabel8);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAction.Location = new System.Drawing.Point(3, 535);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(197, 430);
            this.pnlAction.TabIndex = 1;
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 20);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(197, 410);
            this.radPageView1.TabIndex = 15;
            this.radPageView1.Text = "Export";
            this.radPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPageViewPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.radPageViewPage1.Controls.Add(this.btnSendEmail);
            this.radPageViewPage1.Controls.Add(this.txtMessage);
            this.radPageViewPage1.Controls.Add(this.radLabel5);
            this.radPageViewPage1.Controls.Add(this.txtSubject);
            this.radPageViewPage1.Controls.Add(this.radLabel4);
            this.radPageViewPage1.Controls.Add(this.txtTo);
            this.radPageViewPage1.Controls.Add(this.radLabel3);
            this.radPageViewPage1.Controls.Add(this.optPdf);
            this.radPageViewPage1.Controls.Add(this.optExcel);
            this.radPageViewPage1.Controls.Add(this.radLabel1);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 29);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(187, 346);
            this.radPageViewPage1.Text = "Email";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Image = global::UI.Resource1.email;
            this.btnSendEmail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSendEmail.Location = new System.Drawing.Point(0, 300);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(183, 42);
            this.btnSendEmail.TabIndex = 19;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.ThemeName = "Office2010";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Image = global::UI.Resource1.email;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSendEmail.GetChildAt(0))).Text = "Send";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSendEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(59, 104);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            // 
            // 
            // 
            this.txtMessage.RootElement.StretchVertically = true;
            this.txtMessage.Size = new System.Drawing.Size(121, 111);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.TabStop = false;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(-1, 105);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(60, 18);
            this.radLabel5.TabIndex = 9;
            this.radLabel5.Text = "Message";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(59, 80);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(122, 20);
            this.txtSubject.TabIndex = 8;
            this.txtSubject.TabStop = false;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(0, 81);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(54, 18);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Subject";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(59, 56);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(122, 20);
            this.txtTo.TabIndex = 6;
            this.txtTo.TabStop = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(0, 57);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(22, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "To";
            // 
            // optPdf
            // 
            this.optPdf.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPdf.Location = new System.Drawing.Point(107, 29);
            this.optPdf.Name = "optPdf";
            this.optPdf.Size = new System.Drawing.Size(54, 18);
            this.optPdf.TabIndex = 2;
            this.optPdf.Text = "Pdf";
            this.optPdf.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // optExcel
            // 
            this.optExcel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optExcel.Location = new System.Drawing.Point(107, 5);
            this.optExcel.Name = "optExcel";
            this.optExcel.Size = new System.Drawing.Size(54, 18);
            this.optExcel.TabIndex = 1;
            this.optExcel.Text = "Excel";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(-1, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(105, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Report Format :";
            // 
            // radLabel8
            // 
            this.radLabel8.AutoSize = false;
            this.radLabel8.BackColor = System.Drawing.Color.MediumVioletRed;
            this.radLabel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.ForeColor = System.Drawing.Color.White;
            this.radLabel8.Location = new System.Drawing.Point(0, 0);
            this.radLabel8.Name = "radLabel8";
            // 
            // 
            // 
            this.radLabel8.RootElement.ForeColor = System.Drawing.Color.White;
            this.radLabel8.Size = new System.Drawing.Size(197, 20);
            this.radLabel8.TabIndex = 14;
            this.radLabel8.Text = "Action";
            // 
            // frmViewerBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 1006);
            this.Controls.Add(this.splitContainer1);
            this.FormTitle = "Reports";
            this.Name = "frmViewerBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowHeader = true;
            this.Text = "Reports";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.rptfrmViewer_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlFilter.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAction)).EndInit();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPanel pnlAction;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        protected Telerik.WinControls.UI.RadScrollablePanel pnlFilter;
        //private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        //private Telerik.WinControls.Themes.Office2010Theme office2010Theme1;
        //private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
        //private Telerik.WinControls.Themes.VistaTheme vistaTheme1;
        //private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadRadioButton optPdf;
        private Telerik.WinControls.UI.RadRadioButton optExcel;
        private Telerik.WinControls.UI.RadButton btnSendEmail;
        private Telerik.WinControls.UI.RadTextBox txtMessage;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtSubject;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtTo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}