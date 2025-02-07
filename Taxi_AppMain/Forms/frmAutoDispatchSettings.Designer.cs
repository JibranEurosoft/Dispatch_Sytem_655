
namespace Taxi_AppMain
{
    partial class frmAutoDispatchSettings
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pnlSettings = new System.Windows.Forms.GroupBox();
            this.lblHeadingNearest = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grdLister = new UI.MyGridView();
            this.ddlMode = new System.Windows.Forms.ComboBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.chkbinding = new System.Windows.Forms.CheckBox();
            this.lblRadious = new System.Windows.Forms.Label();
            this.NearestDriverRadious = new System.Windows.Forms.NumericUpDown();
            this.lblcounter = new System.Windows.Forms.Label();
            this.btnUpdateSettings = new Telerik.WinControls.UI.RadButton();
            this.chkNearestDriver = new System.Windows.Forms.CheckBox();
            this.chkTopstdJobBackPlot = new System.Windows.Forms.CheckBox();
            this.chkTopstdJobPlot = new System.Windows.Forms.CheckBox();
            this.chkAutoAllocateSTC = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.lblHeadingNearest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NearestDriverRadious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlSettings.Controls.Add(this.lblHeadingNearest);
            this.pnlSettings.Controls.Add(this.grdLister);
            this.pnlSettings.Controls.Add(this.ddlMode);
            this.pnlSettings.Controls.Add(this.radButton1);
            this.pnlSettings.Controls.Add(this.chkbinding);
            this.pnlSettings.Controls.Add(this.lblRadious);
            this.pnlSettings.Controls.Add(this.NearestDriverRadious);
            this.pnlSettings.Controls.Add(this.lblcounter);
            this.pnlSettings.Controls.Add(this.btnUpdateSettings);
            this.pnlSettings.Controls.Add(this.chkNearestDriver);
            this.pnlSettings.Controls.Add(this.chkTopstdJobBackPlot);
            this.pnlSettings.Controls.Add(this.chkTopstdJobPlot);
            this.pnlSettings.Controls.Add(this.chkAutoAllocateSTC);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSettings.Location = new System.Drawing.Point(0, 38);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSettings.Size = new System.Drawing.Size(1063, 475);
            this.pnlSettings.TabIndex = 106;
            this.pnlSettings.TabStop = false;
            this.pnlSettings.Text = "Auto Dispatch Settings";
            this.pnlSettings.Enter += new System.EventHandler(this.pnlSettings_Enter);
            // 
            // lblHeadingNearest
            // 
            this.lblHeadingNearest.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblHeadingNearest.Controls.Add(this.label1);
            this.lblHeadingNearest.ForeColor = System.Drawing.Color.White;
            this.lblHeadingNearest.Location = new System.Drawing.Point(617, 26);
            this.lblHeadingNearest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblHeadingNearest.Name = "lblHeadingNearest";
            this.lblHeadingNearest.Size = new System.Drawing.Size(413, 37);
            this.lblHeadingNearest.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 18);
            this.label1.TabIndex = 117;
            this.label1.Text = "Prioritise Nearest Driver";
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(617, 63);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(413, 303);
            this.grdLister.TabIndex = 115;
            this.grdLister.Text = "myGridView1";
            // 
            // ddlMode
            // 
            this.ddlMode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMode.FormattingEnabled = true;
            this.ddlMode.Items.AddRange(new object[] {
            "Normal",
            "Quite",
            "Busy"});
            this.ddlMode.Location = new System.Drawing.Point(99, 33);
            this.ddlMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlMode.Name = "ddlMode";
            this.ddlMode.Size = new System.Drawing.Size(175, 26);
            this.ddlMode.TabIndex = 9;
            this.ddlMode.SelectedIndexChanged += new System.EventHandler(this.ddlMode_SelectedIndexChanged);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(213, 330);
            this.radButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(119, 66);
            this.radButton1.TabIndex = 61;
            this.radButton1.Text = "Exit ";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Exit ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkbinding
            // 
            this.chkbinding.AutoSize = true;
            this.chkbinding.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbinding.Location = new System.Drawing.Point(20, 267);
            this.chkbinding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkbinding.Name = "chkbinding";
            this.chkbinding.Size = new System.Drawing.Size(72, 22);
            this.chkbinding.TabIndex = 60;
            this.chkbinding.Text = "Bidding";
            this.chkbinding.UseVisualStyleBackColor = true;
            // 
            // lblRadious
            // 
            this.lblRadious.AutoSize = true;
            this.lblRadious.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadious.Location = new System.Drawing.Point(175, 230);
            this.lblRadious.Name = "lblRadious";
            this.lblRadious.Size = new System.Drawing.Size(55, 18);
            this.lblRadious.TabIndex = 59;
            this.lblRadious.Text = "Radius:";
            this.lblRadious.Visible = false;
            // 
            // NearestDriverRadious
            // 
            this.NearestDriverRadious.DecimalPlaces = 2;
            this.NearestDriverRadious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NearestDriverRadious.Location = new System.Drawing.Point(253, 229);
            this.NearestDriverRadious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NearestDriverRadious.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.NearestDriverRadious.Name = "NearestDriverRadious";
            this.NearestDriverRadious.Size = new System.Drawing.Size(79, 22);
            this.NearestDriverRadious.TabIndex = 58;
            this.NearestDriverRadious.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblcounter
            // 
            this.lblcounter.AutoSize = true;
            this.lblcounter.Location = new System.Drawing.Point(603, 76);
            this.lblcounter.Name = "lblcounter";
            this.lblcounter.Size = new System.Drawing.Size(0, 14);
            this.lblcounter.TabIndex = 57;
            this.lblcounter.Visible = false;
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.Location = new System.Drawing.Point(22, 327);
            this.btnUpdateSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(164, 69);
            this.btnUpdateSettings.TabIndex = 53;
            this.btnUpdateSettings.Text = "Save";
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdateSettings.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkNearestDriver
            // 
            this.chkNearestDriver.AutoSize = true;
            this.chkNearestDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNearestDriver.Location = new System.Drawing.Point(20, 225);
            this.chkNearestDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkNearestDriver.Name = "chkNearestDriver";
            this.chkNearestDriver.Size = new System.Drawing.Size(121, 22);
            this.chkNearestDriver.TabIndex = 17;
            this.chkNearestDriver.Text = "Nearest Driver";
            this.chkNearestDriver.UseVisualStyleBackColor = true;
            this.chkNearestDriver.CheckedChanged += new System.EventHandler(this.chkNearestDriver_CheckedChanged);
            // 
            // chkTopstdJobBackPlot
            // 
            this.chkTopstdJobBackPlot.AutoSize = true;
            this.chkTopstdJobBackPlot.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTopstdJobBackPlot.Location = new System.Drawing.Point(20, 182);
            this.chkTopstdJobBackPlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTopstdJobBackPlot.Name = "chkTopstdJobBackPlot";
            this.chkTopstdJobBackPlot.Size = new System.Drawing.Size(235, 22);
            this.chkTopstdJobBackPlot.TabIndex = 14;
            this.chkTopstdJobBackPlot.Text = "Top Standing in Job Backup Plot";
            this.chkTopstdJobBackPlot.UseVisualStyleBackColor = true;
            // 
            // chkTopstdJobPlot
            // 
            this.chkTopstdJobPlot.AutoSize = true;
            this.chkTopstdJobPlot.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTopstdJobPlot.Location = new System.Drawing.Point(20, 96);
            this.chkTopstdJobPlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTopstdJobPlot.Name = "chkTopstdJobPlot";
            this.chkTopstdJobPlot.Size = new System.Drawing.Size(183, 22);
            this.chkTopstdJobPlot.TabIndex = 13;
            this.chkTopstdJobPlot.Text = "Top Standing in Job Plot";
            this.chkTopstdJobPlot.UseVisualStyleBackColor = true;
            // 
            // chkAutoAllocateSTC
            // 
            this.chkAutoAllocateSTC.AutoSize = true;
            this.chkAutoAllocateSTC.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoAllocateSTC.Location = new System.Drawing.Point(20, 138);
            this.chkAutoAllocateSTC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAutoAllocateSTC.Name = "chkAutoAllocateSTC";
            this.chkAutoAllocateSTC.Size = new System.Drawing.Size(143, 22);
            this.chkAutoAllocateSTC.TabIndex = 12;
            this.chkAutoAllocateSTC.Text = "Auto Allocate STC";
            this.chkAutoAllocateSTC.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mode  :";
            // 
            // frmAutoDispatchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 513);
            this.Controls.Add(this.pnlSettings);
            this.FormTitle = "Auto Dispatch Settings";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAutoDispatchSettings";
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.Text = "Auto Dispatch Settings";
            this.Load += new System.EventHandler(this.frmAutoDispatchSettings_Load);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.pnlSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.lblHeadingNearest.ResumeLayout(false);
            this.lblHeadingNearest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NearestDriverRadious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlSettings;
        private System.Windows.Forms.Label lblcounter;
        private Telerik.WinControls.UI.RadButton btnUpdateSettings;
        private System.Windows.Forms.CheckBox chkNearestDriver;
        private System.Windows.Forms.CheckBox chkTopstdJobBackPlot;
        private System.Windows.Forms.CheckBox chkTopstdJobPlot;
        private System.Windows.Forms.CheckBox chkAutoAllocateSTC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlMode;
        private System.Windows.Forms.NumericUpDown NearestDriverRadious;
        private System.Windows.Forms.CheckBox chkbinding;
        private System.Windows.Forms.Label lblRadious;
        private Telerik.WinControls.UI.RadButton radButton1;
        private UI.MyGridView grdLister;
        private System.Windows.Forms.Panel lblHeadingNearest;
        private System.Windows.Forms.Label label1;
    }
}