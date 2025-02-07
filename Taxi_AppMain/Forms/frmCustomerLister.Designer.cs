namespace Taxi_AppMain
{
    partial class frmCustomerLister
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
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.chkSelectAll = new Telerik.WinControls.UI.RadCheckBox();
            this.pnlFooter = new Telerik.WinControls.UI.RadPanel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnPick = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EndRange = new System.Windows.Forms.NumericUpDown();
            this.StartRange = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNotInclude = new Telerik.WinControls.UI.RadCheckBox();
            this.chkInclude = new Telerik.WinControls.UI.RadCheckBox();
            this.chkNotInPeriod = new Telerik.WinControls.UI.RadCheckBox();
            this.btnGetCustomerDetail = new Telerik.WinControls.UI.RadButton();
            this.chkPeriod = new Telerik.WinControls.UI.RadCheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpToDate = new UI.MyDatePicker();
            this.dtpFromDate = new UI.MyDatePicker();
            this.chkZones = new System.Windows.Forms.RadioButton();
            this.chkPostCode = new System.Windows.Forms.RadioButton();
            this.ddlZones = new UI.MyDropDownList();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtNoofBooking = new System.Windows.Forms.TextBox();
            this.txtNoofDays = new System.Windows.Forms.TextBox();
            this.lblNoofBooking = new System.Windows.Forms.Label();
            this.lblnoofDays = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAppUsers = new Telerik.WinControls.UI.RadRadioButton();
            this.chkDateTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.chkBookingWise = new Telerik.WinControls.UI.RadRadioButton();
            this.chkDateWise = new Telerik.WinControls.UI.RadRadioButton();
            this.chkAreaWise = new Telerik.WinControls.UI.RadRadioButton();
            this.chkAll = new Telerik.WinControls.UI.RadRadioButton();
            this.lblTotalRecods = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.grdLister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPick)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartRange)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotInclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotInPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetCustomerDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZones)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAppUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDateTimeWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBookingWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDateWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAreaWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLister
            // 
            this.grdLister.AutoSizeRows = true;
            this.grdLister.Controls.Add(this.chkSelectAll);
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLister.Location = new System.Drawing.Point(0, 151);
            // 
            // grdLister
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowDeleteRow = false;
            this.grdLister.Name = "grdLister";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.Size = new System.Drawing.Size(961, 477);
            this.grdLister.TabIndex = 0;
            this.grdLister.Text = "radGridView1";
            this.grdLister.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdLister_ViewCellFormatting);
            this.grdLister.Click += new System.EventHandler(this.grdLister_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(27, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 15);
            this.chkSelectAll.TabIndex = 25;
            this.chkSelectAll.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkSelectAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkSelectAll_ToggleStateChanged);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnExit);
            this.pnlFooter.Controls.Add(this.btnPick);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 628);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(961, 75);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(508, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPick
            // 
            this.btnPick.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPick.Location = new System.Drawing.Point(268, 13);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(105, 42);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "Pick";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPick.GetChildAt(0))).Text = "Pick";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPick.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPick.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EndRange);
            this.panel1.Controls.Add(this.StartRange);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblTotalRecods);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 151);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(482, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 95;
            this.label2.Text = "End Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(291, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "Start Range";
            // 
            // EndRange
            // 
            this.EndRange.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndRange.ForeColor = System.Drawing.Color.Black;
            this.EndRange.InterceptArrowKeys = false;
            this.EndRange.Location = new System.Drawing.Point(565, 121);
            this.EndRange.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.EndRange.Name = "EndRange";
            this.EndRange.Size = new System.Drawing.Size(65, 26);
            this.EndRange.TabIndex = 26;
            this.EndRange.TabStop = false;
            // 
            // StartRange
            // 
            this.StartRange.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartRange.ForeColor = System.Drawing.Color.Black;
            this.StartRange.InterceptArrowKeys = false;
            this.StartRange.Location = new System.Drawing.Point(383, 121);
            this.StartRange.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.StartRange.Name = "StartRange";
            this.StartRange.Size = new System.Drawing.Size(65, 26);
            this.StartRange.TabIndex = 3;
            this.StartRange.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.chkNotInclude);
            this.groupBox1.Controls.Add(this.chkInclude);
            this.groupBox1.Controls.Add(this.chkNotInPeriod);
            this.groupBox1.Controls.Add(this.btnGetCustomerDetail);
            this.groupBox1.Controls.Add(this.chkPeriod);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.chkZones);
            this.groupBox1.Controls.Add(this.chkPostCode);
            this.groupBox1.Controls.Add(this.ddlZones);
            this.groupBox1.Controls.Add(this.txtPostCode);
            this.groupBox1.Controls.Add(this.txtNoofBooking);
            this.groupBox1.Controls.Add(this.txtNoofDays);
            this.groupBox1.Controls.Add(this.lblNoofBooking);
            this.groupBox1.Controls.Add(this.lblnoofDays);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 86);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            // 
            // chkNotInclude
            // 
            this.chkNotInclude.BackColor = System.Drawing.Color.Transparent;
            this.chkNotInclude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotInclude.Location = new System.Drawing.Point(147, 7);
            this.chkNotInclude.Name = "chkNotInclude";
            this.chkNotInclude.Size = new System.Drawing.Size(123, 22);
            this.chkNotInclude.TabIndex = 106;
            this.chkNotInclude.Text = "Not Included";
            this.chkNotInclude.Visible = false;
            this.chkNotInclude.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkNotInclude_ToggleStateChanged);
            // 
            // chkInclude
            // 
            this.chkInclude.BackColor = System.Drawing.Color.Transparent;
            this.chkInclude.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInclude.Location = new System.Drawing.Point(58, 7);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Size = new System.Drawing.Size(90, 22);
            this.chkInclude.TabIndex = 105;
            this.chkInclude.Text = "Included";
            this.chkInclude.Visible = false;
            this.chkInclude.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkInclude_ToggleStateChanged);
            // 
            // chkNotInPeriod
            // 
            this.chkNotInPeriod.BackColor = System.Drawing.Color.Transparent;
            this.chkNotInPeriod.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotInPeriod.Location = new System.Drawing.Point(701, 7);
            this.chkNotInPeriod.Name = "chkNotInPeriod";
            this.chkNotInPeriod.Size = new System.Drawing.Size(126, 22);
            this.chkNotInPeriod.TabIndex = 104;
            this.chkNotInPeriod.Text = "Not In Period";
            this.chkNotInPeriod.Visible = false;
            this.chkNotInPeriod.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkNotInPeriod_ToggleStateChanged);
            // 
            // btnGetCustomerDetail
            // 
            this.btnGetCustomerDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCustomerDetail.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnGetCustomerDetail.Location = new System.Drawing.Point(845, 24);
            this.btnGetCustomerDetail.Name = "btnGetCustomerDetail";
            this.btnGetCustomerDetail.Size = new System.Drawing.Size(110, 55);
            this.btnGetCustomerDetail.TabIndex = 1;
            this.btnGetCustomerDetail.Text = "Search";
            this.btnGetCustomerDetail.Click += new System.EventHandler(this.btnGetCustomerDetail_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGetCustomerDetail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGetCustomerDetail.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGetCustomerDetail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnGetCustomerDetail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chkPeriod
            // 
            this.chkPeriod.BackColor = System.Drawing.Color.Transparent;
            this.chkPeriod.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPeriod.Location = new System.Drawing.Point(606, 7);
            this.chkPeriod.Name = "chkPeriod";
            this.chkPeriod.Size = new System.Drawing.Size(93, 22);
            this.chkPeriod.TabIndex = 103;
            this.chkPeriod.Text = "In Period";
            this.chkPeriod.Visible = false;
            this.chkPeriod.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkPeriod_ToggleStateChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(600, 63);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(58, 16);
            this.lblToDate.TabIndex = 102;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(600, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(74, 16);
            this.lblFromDate.TabIndex = 101;
            this.lblFromDate.Text = "From Date";
            this.lblFromDate.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(684, 60);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Size = new System.Drawing.Size(111, 24);
            this.dtpToDate.TabIndex = 100;
            this.dtpToDate.TabStop = false;
            this.dtpToDate.Text = "radDateTimePicker1";
            this.dtpToDate.Value = new System.DateTime(2011, 9, 21, 2, 48, 22, 638);
            this.dtpToDate.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(684, 32);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(111, 24);
            this.dtpFromDate.TabIndex = 99;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "radDateTimePicker1";
            this.dtpFromDate.Value = new System.DateTime(2011, 9, 21, 2, 48, 22, 638);
            this.dtpFromDate.Visible = false;
            // 
            // chkZones
            // 
            this.chkZones.AutoSize = true;
            this.chkZones.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZones.Location = new System.Drawing.Point(58, 61);
            this.chkZones.Name = "chkZones";
            this.chkZones.Size = new System.Drawing.Size(64, 20);
            this.chkZones.TabIndex = 98;
            this.chkZones.Text = "Zones";
            this.chkZones.UseVisualStyleBackColor = true;
            this.chkZones.Visible = false;
            this.chkZones.CheckedChanged += new System.EventHandler(this.chkZones_CheckedChanged);
            // 
            // chkPostCode
            // 
            this.chkPostCode.AutoSize = true;
            this.chkPostCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPostCode.Location = new System.Drawing.Point(58, 35);
            this.chkPostCode.Name = "chkPostCode";
            this.chkPostCode.Size = new System.Drawing.Size(86, 20);
            this.chkPostCode.TabIndex = 97;
            this.chkPostCode.Text = "Postcode";
            this.chkPostCode.UseVisualStyleBackColor = true;
            this.chkPostCode.Visible = false;
            this.chkPostCode.CheckedChanged += new System.EventHandler(this.chkPostCode_CheckedChanged);
            // 
            // ddlZones
            // 
            this.ddlZones.Caption = null;
            this.ddlZones.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlZones.Location = new System.Drawing.Point(147, 59);
            this.ddlZones.Name = "ddlZones";
            this.ddlZones.Property = null;
            this.ddlZones.ShowDownArrow = true;
            this.ddlZones.Size = new System.Drawing.Size(167, 26);
            this.ddlZones.TabIndex = 96;
            this.ddlZones.Visible = false;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(147, 35);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(83, 20);
            this.txtPostCode.TabIndex = 95;
            this.txtPostCode.Visible = false;
            // 
            // txtNoofBooking
            // 
            this.txtNoofBooking.Location = new System.Drawing.Point(557, 7);
            this.txtNoofBooking.Name = "txtNoofBooking";
            this.txtNoofBooking.Size = new System.Drawing.Size(83, 20);
            this.txtNoofBooking.TabIndex = 94;
            this.txtNoofBooking.Visible = false;
            // 
            // txtNoofDays
            // 
            this.txtNoofDays.Location = new System.Drawing.Point(365, 8);
            this.txtNoofDays.Name = "txtNoofDays";
            this.txtNoofDays.Size = new System.Drawing.Size(83, 20);
            this.txtNoofDays.TabIndex = 93;
            this.txtNoofDays.Visible = false;
            // 
            // lblNoofBooking
            // 
            this.lblNoofBooking.AutoSize = true;
            this.lblNoofBooking.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoofBooking.Location = new System.Drawing.Point(441, 8);
            this.lblNoofBooking.Name = "lblNoofBooking";
            this.lblNoofBooking.Size = new System.Drawing.Size(112, 18);
            this.lblNoofBooking.TabIndex = 92;
            this.lblNoofBooking.Text = "No of Booking";
            this.lblNoofBooking.Visible = false;
            // 
            // lblnoofDays
            // 
            this.lblnoofDays.AutoSize = true;
            this.lblnoofDays.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnoofDays.Location = new System.Drawing.Point(274, 9);
            this.lblnoofDays.Name = "lblnoofDays";
            this.lblnoofDays.Size = new System.Drawing.Size(89, 18);
            this.lblnoofDays.TabIndex = 91;
            this.lblnoofDays.Text = "No of Days";
            this.lblnoofDays.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.chkAppUsers);
            this.panel2.Controls.Add(this.chkDateTimeWise);
            this.panel2.Controls.Add(this.chkBookingWise);
            this.panel2.Controls.Add(this.chkDateWise);
            this.panel2.Controls.Add(this.chkAreaWise);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 32);
            this.panel2.TabIndex = 94;
            // 
            // chkAppUsers
            // 
            this.chkAppUsers.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkAppUsers.AutoSize = true;
            this.chkAppUsers.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAppUsers.ForeColor = System.Drawing.Color.Maroon;
            this.chkAppUsers.Location = new System.Drawing.Point(760, 3);
            this.chkAppUsers.Name = "chkAppUsers";
            // 
            // 
            // 
            this.chkAppUsers.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkAppUsers.Size = new System.Drawing.Size(99, 22);
            this.chkAppUsers.TabIndex = 101;
            this.chkAppUsers.Text = "App Users";
            this.chkAppUsers.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAppUsers_ToggleStateChanged);
            // 
            // chkDateTimeWise
            // 
            this.chkDateTimeWise.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkDateTimeWise.AutoSize = true;
            this.chkDateTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDateTimeWise.ForeColor = System.Drawing.Color.Maroon;
            this.chkDateTimeWise.Location = new System.Drawing.Point(630, 3);
            this.chkDateTimeWise.Name = "chkDateTimeWise";
            // 
            // 
            // 
            this.chkDateTimeWise.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkDateTimeWise.Size = new System.Drawing.Size(98, 22);
            this.chkDateTimeWise.TabIndex = 100;
            this.chkDateTimeWise.Text = "Date wise";
            this.chkDateTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkDateTimeWise_ToggleStateChanged);
            // 
            // chkBookingWise
            // 
            this.chkBookingWise.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkBookingWise.AutoSize = true;
            this.chkBookingWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBookingWise.ForeColor = System.Drawing.Color.Maroon;
            this.chkBookingWise.Location = new System.Drawing.Point(467, 3);
            this.chkBookingWise.Name = "chkBookingWise";
            // 
            // 
            // 
            this.chkBookingWise.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkBookingWise.Size = new System.Drawing.Size(125, 22);
            this.chkBookingWise.TabIndex = 99;
            this.chkBookingWise.Text = "Booking wise";
            this.chkBookingWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkBookingWise_ToggleStateChanged);
            // 
            // chkDateWise
            // 
            this.chkDateWise.AutoSize = true;
            this.chkDateWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDateWise.ForeColor = System.Drawing.Color.Maroon;
            this.chkDateWise.Location = new System.Drawing.Point(293, 3);
            this.chkDateWise.Name = "chkDateWise";
            // 
            // 
            // 
            this.chkDateWise.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkDateWise.Size = new System.Drawing.Size(132, 22);
            this.chkDateWise.TabIndex = 98;
            this.chkDateWise.Text = "Absence Since";
            this.chkDateWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkDateWise_ToggleStateChanged);
            // 
            // chkAreaWise
            // 
            this.chkAreaWise.AutoSize = true;
            this.chkAreaWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAreaWise.ForeColor = System.Drawing.Color.Maroon;
            this.chkAreaWise.Location = new System.Drawing.Point(72, 3);
            this.chkAreaWise.Name = "chkAreaWise";
            // 
            // 
            // 
            this.chkAreaWise.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkAreaWise.Size = new System.Drawing.Size(186, 22);
            this.chkAreaWise.TabIndex = 97;
            this.chkAreaWise.Text = "Postcode / Area wise";
            this.chkAreaWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAreaWise_ToggleStateChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.Maroon;
            this.chkAll.Location = new System.Drawing.Point(10, 3);
            this.chkAll.Name = "chkAll";
            // 
            // 
            // 
            this.chkAll.RootElement.ForeColor = System.Drawing.Color.Maroon;
            this.chkAll.Size = new System.Drawing.Size(41, 22);
            this.chkAll.TabIndex = 96;
            this.chkAll.Text = "All";
            this.chkAll.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAll_ToggleStateChanged);
            // 
            // lblTotalRecods
            // 
            this.lblTotalRecods.AutoSize = true;
            this.lblTotalRecods.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecods.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRecods.Location = new System.Drawing.Point(6, 127);
            this.lblTotalRecods.Name = "lblTotalRecods";
            this.lblTotalRecods.Size = new System.Drawing.Size(118, 14);
            this.lblTotalRecods.TabIndex = 93;
            this.lblTotalRecods.Text = "Records Found : 0";
            // 
            // frmCustomerLister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 703);
            this.Controls.Add(this.grdLister);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmCustomerLister";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            //this.ThemeName = "ControlDefault";
            this.Enter += new System.EventHandler(this.btnGetCustomerDetail_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLister_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.grdLister.ResumeLayout(false);
            this.grdLister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPick)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartRange)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotInclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotInPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetCustomerDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAppUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDateTimeWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBookingWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDateWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAreaWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdLister;
        private Telerik.WinControls.UI.RadPanel pnlFooter;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnPick;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnGetCustomerDetail;
        private Telerik.WinControls.UI.RadCheckBox chkSelectAll;
        private System.Windows.Forms.Label lblTotalRecods;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadRadioButton chkAll;
        private Telerik.WinControls.UI.RadRadioButton chkAreaWise;
        private Telerik.WinControls.UI.RadRadioButton chkDateWise;
        private Telerik.WinControls.UI.RadRadioButton chkBookingWise;
        private Telerik.WinControls.UI.RadRadioButton chkDateTimeWise;
        private Telerik.WinControls.UI.RadRadioButton chkAppUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadCheckBox chkNotInclude;
        private Telerik.WinControls.UI.RadCheckBox chkInclude;
        private Telerik.WinControls.UI.RadCheckBox chkNotInPeriod;
        private Telerik.WinControls.UI.RadCheckBox chkPeriod;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private UI.MyDatePicker dtpToDate;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.RadioButton chkZones;
        private System.Windows.Forms.RadioButton chkPostCode;
        private UI.MyDropDownList ddlZones;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.TextBox txtNoofBooking;
        private System.Windows.Forms.TextBox txtNoofDays;
        private System.Windows.Forms.Label lblNoofBooking;
        private System.Windows.Forms.Label lblnoofDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown EndRange;
        private System.Windows.Forms.NumericUpDown StartRange;
    }
}
