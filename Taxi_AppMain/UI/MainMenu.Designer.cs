namespace UI
{
    partial class MainMenu
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
            Telerik.WinControls.UI.CommandBarStripInfoHolder commandBarStripInfoHolder1 = new Telerik.WinControls.UI.CommandBarStripInfoHolder();
            this.radToolStrip1 = new Telerik.WinControls.UI.RadCommandBar();
            this.radCommandBarRows = new Telerik.WinControls.UI.CommandBarRowElement();
            this.toolbar_Custom = new Telerik.WinControls.UI.CommandBarStripElement();
            this.radCommandBarElement1 = new Telerik.WinControls.UI.RadCommandBarElement();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem7 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem4 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem8 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem9 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem10 = new Telerik.WinControls.UI.RadMenuItem();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.pnl_StatusBar = new Telerik.WinControls.UI.RadPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusStrip_label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip_Label2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip_Label3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatisStrip_LicenseLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.radImageButtonElement11 = new Telerik.WinControls.UI.RadImageButtonElement();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.object_04a51bd6_802a_4382_952d_4ad6f63aadf9 = new Telerik.WinControls.UI.RadMenu.RadMenuRootElement();
            ((System.ComponentModel.ISupportInitialize)(this.radToolStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_StatusBar)).BeginInit();
            this.pnl_StatusBar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // radToolStrip1
            // 
            this.radToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.radToolStrip1.MinimumSize = new System.Drawing.Size(5, 5);
            this.radToolStrip1.Name = "radToolStrip1";
            // 
            // 
            // 
            this.radToolStrip1.RootElement.MinSize = new System.Drawing.Size(5, 5);
            this.radToolStrip1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.radCommandBarRows});
            this.radToolStrip1.Size = new System.Drawing.Size(1184, 30);
            this.radToolStrip1.TabIndex = 0;
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radToolStrip1.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            // 
            // radCommandBarRows
            // 
            this.radCommandBarRows.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radCommandBarRows.MinSize = new System.Drawing.Size(25, 25);
            this.radCommandBarRows.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.toolbar_Custom});
            this.radCommandBarRows.Text = "";
            this.radCommandBarRows.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // toolbar_Custom
            // 
            this.toolbar_Custom.DisplayName = "toolbar_Custom";
            // 
            // radCommandBarElement1
            // 
            this.radCommandBarElement1.Name = "radCommandBarElement1";
            this.radCommandBarElement1.StripInfoHolder = commandBarStripInfoHolder1;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.DescriptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem2,
            this.radMenuItem7});
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.ShowArrow = false;
            this.radMenuItem1.Text = "File";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Logout";
            this.radMenuItem2.Click += new System.EventHandler(this.radBtnLogout_Click);
            // 
            // radMenuItem7
            // 
            this.radMenuItem7.Name = "radMenuItem7";
            this.radMenuItem7.Text = "Exit";
            this.radMenuItem7.Click += new System.EventHandler(this.radMenuItem7_Click);
            // 
            // radMenuItem4
            // 
            this.radMenuItem4.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem3,
            this.radMenuItem8,
            this.radMenuItem9,
            this.radMenuItem10});
            this.radMenuItem4.Name = "radMenuItem4";
            this.radMenuItem4.Text = "View";
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.CheckOnClick = true;
            this.radMenuItem3.IsChecked = true;
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "Show ToolBar";
            this.radMenuItem3.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radMenuItem3.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radMenuItem8
            // 
            this.radMenuItem8.CheckOnClick = true;
            this.radMenuItem8.IsChecked = true;
            this.radMenuItem8.Name = "radMenuItem8";
            this.radMenuItem8.Text = "Show StatusBar";
            this.radMenuItem8.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radMenuItem8.Click += new System.EventHandler(this.radMenuItem8_Click);
            // 
            // radMenuItem9
            // 
            this.radMenuItem9.CheckOnClick = true;
            this.radMenuItem9.IsChecked = true;
            this.radMenuItem9.Name = "radMenuItem9";
            this.radMenuItem9.Text = "Show MenuBox";
            this.radMenuItem9.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radMenuItem9.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radMenuItem10
            // 
            this.radMenuItem10.CheckOnClick = true;
            this.radMenuItem10.Name = "radMenuItem10";
            this.radMenuItem10.Text = "Full Screen";
            this.radMenuItem10.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.radPanel1.Controls.Add(this.radToolStrip1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 20);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1184, 41);
            this.radPanel1.TabIndex = 4;
            this.radPanel1.Text = "radPanel1";
            // 
            // pnl_StatusBar
            // 
            this.pnl_StatusBar.BackColor = System.Drawing.Color.SkyBlue;
            this.pnl_StatusBar.Controls.Add(this.statusStrip1);
            this.pnl_StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_StatusBar.Location = new System.Drawing.Point(0, 475);
            this.pnl_StatusBar.Name = "pnl_StatusBar";
            this.pnl_StatusBar.Size = new System.Drawing.Size(1184, 25);
            this.pnl_StatusBar.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStrip_label1,
            this.StatusStrip_Label2,
            this.StatusStrip_Label3,
            this.StatisStrip_LicenseLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1184, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusStrip_label1
            // 
            this.StatusStrip_label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip_label1.Name = "StatusStrip_label1";
            this.StatusStrip_label1.Size = new System.Drawing.Size(0, 20);
            // 
            // StatusStrip_Label2
            // 
            this.StatusStrip_Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip_Label2.Name = "StatusStrip_Label2";
            this.StatusStrip_Label2.Size = new System.Drawing.Size(0, 20);
            // 
            // StatusStrip_Label3
            // 
            this.StatusStrip_Label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip_Label3.Name = "StatusStrip_Label3";
            this.StatusStrip_Label3.Size = new System.Drawing.Size(0, 20);
            // 
            // StatisStrip_LicenseLabel
            // 
            this.StatisStrip_LicenseLabel.AutoSize = false;
            this.StatisStrip_LicenseLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisStrip_LicenseLabel.ForeColor = System.Drawing.Color.Blue;
            this.StatisStrip_LicenseLabel.Name = "StatisStrip_LicenseLabel";
            this.StatisStrip_LicenseLabel.Size = new System.Drawing.Size(500, 20);
            this.StatisStrip_LicenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radDock1
            // 
            this.radDock1.AutoDetectMdiChildren = true;
            this.radDock1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 61);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(1184, 414);
            this.radDock1.TabIndex = 1;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            this.radDock1.DockWindowAdded += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_DockWindowAdded);
            this.radDock1.ActiveWindowChanged += new Telerik.WinControls.UI.Docking.DockWindowEventHandler(this.radDock1_ActiveWindowChanged);
            // 
            // documentContainer1
            // 
            this.documentContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.documentContainer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.AbsoluteSize = new System.Drawing.Size(963, 200);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-7, 0);
            // 
            // radImageButtonElement11
            // 
            this.radImageButtonElement11.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radImageButtonElement11.ImageIndexClicked = 0;
            this.radImageButtonElement11.ImageIndexHovered = 0;
            this.radImageButtonElement11.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radImageButtonElement11.Name = "radImageButtonElement11";
            this.radImageButtonElement11.ShowBorder = false;
            this.radImageButtonElement11.Text = "radImageButtonElement11";
            // 
            // radMenu1
            // 
            this.radMenu1.AutoSize = false;
            this.radMenu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem4});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1184, 20);
            this.radMenu1.TabIndex = 3;
            this.radMenu1.Text = "radMenu1";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radMenu1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radMenu1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // object_04a51bd6_802a_4382_952d_4ad6f63aadf9
            // 
            this.object_04a51bd6_802a_4382_952d_4ad6f63aadf9.Name = "object_04a51bd6_802a_4382_952d_4ad6f63aadf9";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 500);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.pnl_StatusBar);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radToolStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_StatusBar)).EndInit();
            this.pnl_StatusBar.ResumeLayout(false);
            this.pnl_StatusBar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem4;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem7;
        private Telerik.WinControls.UI.RadImageButtonElement radImageButtonElement11;
        protected Telerik.WinControls.UI.Docking.RadDock radDock1;
        public System.Windows.Forms.StatusStrip statusStrip1;
      
        //public Telerik.WinControls.UI.RadToolStripItem toolbar_Custom;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem8;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem9;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem10;
        //protected Telerik.WinControls.UI.RadToolStrip radToolStrip1;
        //private Telerik.WinControls.UI.RadToolStripElement radToolStripElement2;
        public Telerik.WinControls.UI.RadPanel radPanel1;
        public System.Windows.Forms.ToolStripStatusLabel StatusStrip_label1;
        public System.Windows.Forms.ToolStripStatusLabel StatusStrip_Label2;
        public System.Windows.Forms.ToolStripStatusLabel StatusStrip_Label3;
        public Telerik.WinControls.UI.RadMenu radMenu1;
        //private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        //private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        //private Telerik.WinControls.Themes.VistaTheme vistaTheme1;
        //private Telerik.WinControls.Themes.TelerikTheme telerikTheme1;
        //private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        //private Telerik.WinControls.Themes.DesertTheme desertTheme1;
        public Telerik.WinControls.UI.RadPanel pnl_StatusBar;
        public System.Windows.Forms.ToolStripStatusLabel StatisStrip_LicenseLabel;


        public Telerik.WinControls.UI.RadCommandBar radToolStrip1;
        public Telerik.WinControls.UI.RadCommandBarElement radCommandBarElement1;
        public Telerik.WinControls.UI.CommandBarRowElement radCommandBarRows;
        public Telerik.WinControls.UI.CommandBarStripElement toolbar_Custom;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.RadMenu.RadMenuRootElement object_04a51bd6_802a_4382_952d_4ad6f63aadf9;
    }
}