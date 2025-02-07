namespace UI
{
    partial class frmSearchBase
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
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.btnViewSearches = new Telerik.WinControls.UI.RadButton();
            this.btnExport = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.pnl_Header = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.grdLister = new UI.UserControls.EuroGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewSearches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Header)).BeginInit();
            this.pnl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.btnViewSearches);
            this.radPanel3.Controls.Add(this.btnExport);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanel3.Location = new System.Drawing.Point(680, 0);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(218, 247);
            this.radPanel3.TabIndex = 69;
            // 
            // btnViewSearches
            // 
            this.btnViewSearches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSearches.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSearches.Image = global::UI.Resource1.main;
            this.btnViewSearches.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewSearches.Location = new System.Drawing.Point(43, 119);
            this.btnViewSearches.Name = "btnViewSearches";
            this.btnViewSearches.Size = new System.Drawing.Size(132, 50);
            this.btnViewSearches.TabIndex = 12;
            this.btnViewSearches.Text = "View Searches";
            this.btnViewSearches.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnViewSearches.Click += new System.EventHandler(this.btnViewSearches_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewSearches.GetChildAt(0))).Image = global::UI.Resource1.main;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewSearches.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewSearches.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewSearches.GetChildAt(0))).Text = "View Searches";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewSearches.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewSearches.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::UI.Resource1.Excel;
            this.btnExport.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(43, 66);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(132, 45);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Image = global::UI.Resource1.Excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExport.GetChildAt(0))).Text = "Export to Excel";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExport.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::UI.Resource1.pic_Search;
            this.btnSearch.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(529, 167);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 45);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Image = global::UI.Resource1.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pnl_Header
            // 
            this.pnl_Header.Controls.Add(this.radPanel3);
            this.pnl_Header.Controls.Add(this.btnSearch);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_Header.Location = new System.Drawing.Point(0, 38);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Size = new System.Drawing.Size(898, 247);
            this.pnl_Header.TabIndex = 70;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.grdLister);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 285);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(898, 523);
            this.radPanel2.TabIndex = 71;
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLister.HeadingBackColor = System.Drawing.Color.Black;
            this.grdLister.HeadingForeColor = System.Drawing.Color.Black;
            this.grdLister.HeadingName = "";
            this.grdLister.Location = new System.Drawing.Point(0, 0);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdLister.Name = "grdLister";
            this.grdLister.Size = new System.Drawing.Size(898, 523);
            this.grdLister.TabIndex = 0;
            // 
            // frmSearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 808);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.pnl_Header);
            this.Name = "frmSearchBase";
            // 
            // 
            // 
         //   this.RootElement.ApplyShapeToControl = true;
           // this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.Text = "frmSearchBase";
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.pnl_Header, 0);
            this.Controls.SetChildIndex(this.radPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnViewSearches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_Header)).EndInit();
            this.pnl_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnViewSearches;
        private Telerik.WinControls.UI.RadButton btnExport;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public Telerik.WinControls.UI.RadPanel radPanel3;
        public Telerik.WinControls.UI.RadPanel pnl_Header;
        protected Telerik.WinControls.UI.RadButton btnSearch;
        public UI.UserControls.EuroGridView grdLister;
    }
}