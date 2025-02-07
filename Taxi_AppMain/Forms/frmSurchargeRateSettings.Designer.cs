namespace Taxi_AppMain
{
    partial class frmSurchargeRateSettings
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdSurchargeRateonPlots = new UI.MyGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit1 = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.optTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.optDateWise = new Telerik.WinControls.UI.RadRadioButton();
            this.optDateTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkEnableIncrement = new Telerik.WinControls.UI.RadCheckBox();
            this.optDayTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.ddlFromDay = new System.Windows.Forms.ComboBox();
            this.ddlTillDay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurchargeRateonPlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurchargeRateonPlots.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTimeWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateTimeWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDayTimeWise)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 204);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(983, 428);
            this.tabControl1.TabIndex = 106;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdSurchargeRateonPlots);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(975, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plot wise Surcharge";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdSurchargeRateonPlots
            // 
            this.grdSurchargeRateonPlots.AutoCellFormatting = false;
            this.grdSurchargeRateonPlots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSurchargeRateonPlots.EnableCheckInCheckOut = false;
            this.grdSurchargeRateonPlots.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdSurchargeRateonPlots.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdSurchargeRateonPlots.Location = new System.Drawing.Point(3, 4);
            this.grdSurchargeRateonPlots.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdSurchargeRateonPlots.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdSurchargeRateonPlots.Name = "grdSurchargeRateonPlots";
            this.grdSurchargeRateonPlots.PKFieldColumnName = "";
            this.grdSurchargeRateonPlots.ShowImageOnActionButton = true;
            this.grdSurchargeRateonPlots.Size = new System.Drawing.Size(969, 391);
            this.grdSurchargeRateonPlots.TabIndex = 2;
            this.grdSurchargeRateonPlots.Text = "radGridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 633);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 102);
            this.panel1.TabIndex = 107;
            // 
            // btnExit1
            // 
            this.btnExit1.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit1.Location = new System.Drawing.Point(394, 14);
            this.btnExit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(127, 74);
            this.btnExit1.TabIndex = 221;
            this.btnExit1.Text = "Exit";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit1.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            this.btnSave.Location = new System.Drawing.Point(225, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 74);
            this.btnSave.TabIndex = 220;
            this.btnSave.Text = "Save";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optTimeWise
            // 
            this.optTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTimeWise.Location = new System.Drawing.Point(623, 107);
            this.optTimeWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optTimeWise.Name = "optTimeWise";
            this.optTimeWise.Size = new System.Drawing.Size(102, 22);
            this.optTimeWise.TabIndex = 213;
            this.optTimeWise.TabStop = false;
            this.optTimeWise.Text = "Time Wise";
            this.optTimeWise.Visible = false;
            this.optTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optTimeWise_ToggleStateChanged);
            // 
            // optDateWise
            // 
            this.optDateWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDateWise.Location = new System.Drawing.Point(233, 107);
            this.optDateWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDateWise.Name = "optDateWise";
            this.optDateWise.Size = new System.Drawing.Size(100, 22);
            this.optDateWise.TabIndex = 212;
            this.optDateWise.TabStop = false;
            this.optDateWise.Text = "Date Wise";
            this.optDateWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optDateWise_ToggleStateChanged);
            // 
            // optDateTimeWise
            // 
            this.optDateTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDateTimeWise.Location = new System.Drawing.Point(17, 107);
            this.optDateTimeWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDateTimeWise.Name = "optDateTimeWise";
            this.optDateTimeWise.Size = new System.Drawing.Size(159, 22);
            this.optDateTimeWise.TabIndex = 211;
            this.optDateTimeWise.TabStop = false;
            this.optDateTimeWise.Text = "Date && Time Wise";
            this.optDateTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(479, 140);
            this.dtpTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(182, 24);
            this.dtpTillDate.TabIndex = 210;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Value = null;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(423, 143);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(27, 22);
            this.radLabel3.TabIndex = 209;
            this.radLabel3.Text = "Till";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(209, 140);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(184, 24);
            this.dtpFromDate.TabIndex = 208;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Value = null;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(122, 143);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 22);
            this.radLabel2.TabIndex = 207;
            this.radLabel2.Text = "From";
            // 
            // chkEnableIncrement
            // 
            this.chkEnableIncrement.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chkEnableIncrement.Location = new System.Drawing.Point(14, 54);
            this.chkEnableIncrement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnableIncrement.Name = "chkEnableIncrement";
            this.chkEnableIncrement.Size = new System.Drawing.Size(192, 27);
            this.chkEnableIncrement.TabIndex = 206;
            this.chkEnableIncrement.Text = "Enable Surcharge";
            // 
            // optDayTimeWise
            // 
            this.optDayTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDayTimeWise.Location = new System.Drawing.Point(408, 107);
            this.optDayTimeWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDayTimeWise.Name = "optDayTimeWise";
            this.optDayTimeWise.Size = new System.Drawing.Size(153, 22);
            this.optDayTimeWise.TabIndex = 214;
            this.optDayTimeWise.TabStop = false;
            this.optDayTimeWise.Text = "Day && Time Wise";
            this.optDayTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optTimeWise_ToggleStateChanged);
            // 
            // ddlFromDay
            // 
            this.ddlFromDay.FormattingEnabled = true;
            this.ddlFromDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.ddlFromDay.Location = new System.Drawing.Point(209, 172);
            this.ddlFromDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlFromDay.Name = "ddlFromDay";
            this.ddlFromDay.Size = new System.Drawing.Size(160, 24);
            this.ddlFromDay.TabIndex = 215;
            this.ddlFromDay.Visible = false;
            // 
            // ddlTillDay
            // 
            this.ddlTillDay.FormattingEnabled = true;
            this.ddlTillDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.ddlTillDay.Location = new System.Drawing.Point(479, 172);
            this.ddlTillDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlTillDay.Name = "ddlTillDay";
            this.ddlTillDay.Size = new System.Drawing.Size(160, 24);
            this.ddlTillDay.TabIndex = 216;
            this.ddlTillDay.Visible = false;
            // 
            // frmSurchargeRateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 735);
            this.Controls.Add(this.ddlTillDay);
            this.Controls.Add(this.ddlFromDay);
            this.Controls.Add(this.optDayTimeWise);
            this.Controls.Add(this.optTimeWise);
            this.Controls.Add(this.optDateWise);
            this.Controls.Add(this.optDateTimeWise);
            this.Controls.Add(this.dtpTillDate);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.chkEnableIncrement);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormTitle = "Surcharge Rate Settings";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSurchargeRateSettings";
            this.ShowHeader = true;
            this.Text = "Surcharge Rate Settings";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.chkEnableIncrement, 0);
            this.Controls.SetChildIndex(this.radLabel2, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.radLabel3, 0);
            this.Controls.SetChildIndex(this.dtpTillDate, 0);
            this.Controls.SetChildIndex(this.optDateTimeWise, 0);
            this.Controls.SetChildIndex(this.optDateWise, 0);
            this.Controls.SetChildIndex(this.optTimeWise, 0);
            this.Controls.SetChildIndex(this.optDayTimeWise, 0);
            this.Controls.SetChildIndex(this.ddlFromDay, 0);
            this.Controls.SetChildIndex(this.ddlTillDay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSurchargeRateonPlots.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurchargeRateonPlots)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTimeWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateTimeWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDayTimeWise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnExit1;
        private UI.MyGridView grdSurchargeRateonPlots;
        private Telerik.WinControls.UI.RadRadioButton optTimeWise;
        private Telerik.WinControls.UI.RadRadioButton optDateWise;
        private Telerik.WinControls.UI.RadRadioButton optDateTimeWise;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadCheckBox chkEnableIncrement;
        private Telerik.WinControls.UI.RadRadioButton optDayTimeWise;
        private System.Windows.Forms.ComboBox ddlFromDay;
        private System.Windows.Forms.ComboBox ddlTillDay;
    }
}