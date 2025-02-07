namespace Taxi_AppMain
{
    partial class frmSurgePrice
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numIncrementRate = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddlSearchType = new Telerik.WinControls.UI.RadDropDownList();
            this.grdDayWise = new Telerik.WinControls.UI.RadGridView();
            this.optDayWise = new Telerik.WinControls.UI.RadRadioButton();
            this.optDateTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.optTimeWise = new Telerik.WinControls.UI.RadRadioButton();
            this.chkEnableSurcharge = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.optDateWise = new Telerik.WinControls.UI.RadRadioButton();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpTillDate = new UI.MyDatePicker();
            this.grdPlot = new UI.MyGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.grdSurgeIncreament = new Telerik.WinControls.UI.RadGridView();
            this.btnExitForm = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrementRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayWise.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDayWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateTimeWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTimeWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableSurcharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurgeIncreament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurgeIncreament.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel1.Controls.Add(this.grdPlot);
            this.radPanel1.Controls.Add(this.groupBox1);
            this.radPanel1.Controls.Add(this.panel1);
            this.radPanel1.Controls.Add(this.grdSurgeIncreament);
            this.radPanel1.Controls.Add(this.btnExitForm);
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 75);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(745, 644);
            this.radPanel1.TabIndex = 104;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numIncrementRate);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Controls.Add(this.radLabel4);
            this.groupBox1.Controls.Add(this.ddlSearchType);
            this.groupBox1.Controls.Add(this.grdDayWise);
            this.groupBox1.Controls.Add(this.optDayWise);
            this.groupBox1.Controls.Add(this.optDateTimeWise);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.radLabel17);
            this.groupBox1.Controls.Add(this.optTimeWise);
            this.groupBox1.Controls.Add(this.chkEnableSurcharge);
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.optDateWise);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.radLabel3);
            this.groupBox1.Controls.Add(this.dtpTillDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 162);
            this.groupBox1.TabIndex = 209;
            this.groupBox1.TabStop = false;
            // 
            // numIncrementRate
            // 
            this.numIncrementRate.DecimalPlaces = 1;
            this.numIncrementRate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIncrementRate.InterceptArrowKeys = false;
            this.numIncrementRate.Location = new System.Drawing.Point(123, 118);
            this.numIncrementRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numIncrementRate.Name = "numIncrementRate";
            // 
            // 
            // 
            this.numIncrementRate.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numIncrementRate.RootElement.StretchVertically = true;
            this.numIncrementRate.ShowBorder = true;
            this.numIncrementRate.ShowUpDownButtons = false;
            this.numIncrementRate.Size = new System.Drawing.Size(41, 24);
            this.numIncrementRate.TabIndex = 238;
            this.numIncrementRate.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numIncrementRate.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numIncrementRate.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.0";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numIncrementRate.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(165, 118);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(18, 22);
            this.radLabel1.TabIndex = 215;
            this.radLabel1.Text = "X";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.ForeColor = System.Drawing.Color.Black;
            this.radLabel4.Location = new System.Drawing.Point(192, 36);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel4.Size = new System.Drawing.Size(92, 22);
            this.radLabel4.TabIndex = 212;
            this.radLabel4.Text = "Search Type";
            this.radLabel4.Visible = false;
            // 
            // ddlSearchType
            // 
            this.ddlSearchType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "ASAP";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Text = "Future Booking";
            radListDataItem2.TextWrap = true;
            this.ddlSearchType.Items.Add(radListDataItem1);
            this.ddlSearchType.Items.Add(radListDataItem2);
            this.ddlSearchType.Location = new System.Drawing.Point(298, 36);
            this.ddlSearchType.Name = "ddlSearchType";
            this.ddlSearchType.Size = new System.Drawing.Size(180, 23);
            this.ddlSearchType.TabIndex = 211;
            this.ddlSearchType.Text = "ASAP";
            this.ddlSearchType.Visible = false;
            // 
            // grdDayWise
            // 
            this.grdDayWise.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDayWise.Location = new System.Drawing.Point(479, 49);
            // 
            // grdDayWise
            // 
            this.grdDayWise.MasterTemplate.AllowAddNewRow = false;
            this.grdDayWise.Name = "grdDayWise";
            this.grdDayWise.ShowGroupPanel = false;
            this.grdDayWise.Size = new System.Drawing.Size(68, 121);
            this.grdDayWise.TabIndex = 213;
            this.grdDayWise.Text = "radGridView2";
            this.grdDayWise.Visible = false;
            // 
            // optDayWise
            // 
            this.optDayWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDayWise.Location = new System.Drawing.Point(443, 11);
            this.optDayWise.Name = "optDayWise";
            this.optDayWise.Size = new System.Drawing.Size(104, 18);
            this.optDayWise.TabIndex = 208;
            this.optDayWise.Text = "Day Wise";
            this.optDayWise.Visible = false;
            this.optDayWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optDayWise_ToggleStateChanged);
            // 
            // optDateTimeWise
            // 
            this.optDateTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDateTimeWise.Location = new System.Drawing.Point(36, 12);
            this.optDateTimeWise.Name = "optDateTimeWise";
            this.optDateTimeWise.Size = new System.Drawing.Size(183, 18);
            this.optDateTimeWise.TabIndex = 203;
            this.optDateTimeWise.Text = "Date && Time Wise";
            this.optDateTimeWise.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.optDateTimeWise.Visible = false;
            this.optDateTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(329, 101);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 41);
            this.btnAdd.TabIndex = 207;
            this.btnAdd.Text = "Add";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Text = "Add";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAdd.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAdd.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel17
            // 
            this.radLabel17.BackColor = System.Drawing.Color.Transparent;
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.ForeColor = System.Drawing.Color.Black;
            this.radLabel17.Location = new System.Drawing.Point(25, 117);
            this.radLabel17.Name = "radLabel17";
            // 
            // 
            // 
            this.radLabel17.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel17.Size = new System.Drawing.Size(87, 22);
            this.radLabel17.TabIndex = 146;
            this.radLabel17.Text = "Peak Factor";
            // 
            // optTimeWise
            // 
            this.optTimeWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTimeWise.Location = new System.Drawing.Point(327, 11);
            this.optTimeWise.Name = "optTimeWise";
            this.optTimeWise.Size = new System.Drawing.Size(109, 18);
            this.optTimeWise.TabIndex = 205;
            this.optTimeWise.Text = "Time Wise";
            this.optTimeWise.Visible = false;
            this.optTimeWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optTimeWise_ToggleStateChanged);
            // 
            // chkEnableSurcharge
            // 
            this.chkEnableSurcharge.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableSurcharge.ForeColor = System.Drawing.Color.Blue;
            this.chkEnableSurcharge.Location = new System.Drawing.Point(34, 31);
            this.chkEnableSurcharge.Name = "chkEnableSurcharge";
            // 
            // 
            // 
            this.chkEnableSurcharge.RootElement.ForeColor = System.Drawing.Color.Blue;
            this.chkEnableSurcharge.Size = new System.Drawing.Size(150, 20);
            this.chkEnableSurcharge.TabIndex = 147;
            this.chkEnableSurcharge.Text = "Enable Peak factor";
            this.chkEnableSurcharge.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkEnableIncrement_ToggleStateChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(25, 67);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 22);
            this.radLabel2.TabIndex = 148;
            this.radLabel2.Text = "From";
            this.radLabel2.Visible = false;
            // 
            // optDateWise
            // 
            this.optDateWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDateWise.Location = new System.Drawing.Point(209, 12);
            this.optDateWise.Name = "optDateWise";
            this.optDateWise.Size = new System.Drawing.Size(108, 18);
            this.optDateWise.TabIndex = 204;
            this.optDateWise.Text = "Date Wise";
            this.optDateWise.Visible = false;
            this.optDateWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optDateWise_ToggleStateChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(81, 66);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(105, 24);
            this.dtpFromDate.TabIndex = 149;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            this.dtpFromDate.Visible = false;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(209, 68);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(27, 22);
            this.radLabel3.TabIndex = 150;
            this.radLabel3.Text = "Till";
            this.radLabel3.Visible = false;
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(255, 67);
            this.dtpTillDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(101, 24);
            this.dtpTillDate.TabIndex = 151;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Text = "myDatePicker2";
            this.dtpTillDate.Value = null;
            this.dtpTillDate.Visible = false;
            // 
            // grdPlot
            // 
            this.grdPlot.AutoCellFormatting = true;
            this.grdPlot.EnableCheckInCheckOut = false;
            this.grdPlot.EnableHotTracking = false;
            this.grdPlot.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPlot.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdPlot.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdPlot.Location = new System.Drawing.Point(2, 213);
            // 
            // grdPlot
            // 
            this.grdPlot.MasterTemplate.AllowAddNewRow = false;
            this.grdPlot.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdPlot.Name = "grdPlot";
            this.grdPlot.PKFieldColumnName = "";
            this.grdPlot.ShowGroupPanel = false;
            this.grdPlot.ShowImageOnActionButton = true;
            this.grdPlot.Size = new System.Drawing.Size(311, 352);
            this.grdPlot.TabIndex = 214;
            this.grdPlot.Text = "myGridView1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.radLabel5);
            this.panel1.Location = new System.Drawing.Point(3, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 31);
            this.panel1.TabIndex = 213;
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.White;
            this.radLabel5.Location = new System.Drawing.Point(7, 4);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ForeColor = System.Drawing.Color.White;
            this.radLabel5.Size = new System.Drawing.Size(121, 22);
            this.radLabel5.TabIndex = 151;
            this.radLabel5.Text = "Excluded Plots";
            // 
            // grdSurgeIncreament
            // 
            this.grdSurgeIncreament.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdSurgeIncreament.Location = new System.Drawing.Point(3, 169);
            // 
            // grdSurgeIncreament
            // 
            this.grdSurgeIncreament.MasterTemplate.AllowAddNewRow = false;
            this.grdSurgeIncreament.Name = "grdSurgeIncreament";
            this.grdSurgeIncreament.ShowGroupPanel = false;
            this.grdSurgeIncreament.Size = new System.Drawing.Size(554, 11);
            this.grdSurgeIncreament.TabIndex = 208;
            this.grdSurgeIncreament.Text = "radGridView2";
            this.grdSurgeIncreament.Visible = false;
            // 
            // btnExitForm
            // 
            this.btnExitForm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitForm.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExitForm.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnExitForm.Location = new System.Drawing.Point(444, 513);
            this.btnExitForm.Name = "btnExitForm";
            this.btnExitForm.Size = new System.Drawing.Size(112, 56);
            this.btnExitForm.TabIndex = 202;
            this.btnExitForm.Text = "Exit";
            this.btnExitForm.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExitForm.Click += new System.EventHandler(this.btnExitForm_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExitForm.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExitForm.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExitForm.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.Tick31;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(324, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 56);
            this.btnSave.TabIndex = 201;
            this.btnSave.Text = "Save Settings";
            this.btnSave.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick31;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save Settings";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = false;
            this.radLabel6.BackColor = System.Drawing.Color.SteelBlue;
            this.radLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.ForeColor = System.Drawing.Color.White;
            this.radLabel6.Location = new System.Drawing.Point(0, 38);
            this.radLabel6.Name = "radLabel6";
            // 
            // 
            // 
            this.radLabel6.RootElement.ForeColor = System.Drawing.Color.White;
            this.radLabel6.Size = new System.Drawing.Size(745, 37);
            this.radLabel6.TabIndex = 105;
            this.radLabel6.Text = "Peak factor Settings";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSurgePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 719);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radLabel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormTitle = "Surge Price";
            this.KeyPreview = true;
            this.Name = "frmSurgePrice";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.Text = "Surge Price";
            this.Controls.SetChildIndex(this.radLabel6, 0);
            this.Controls.SetChildIndex(this.radPanel1, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrementRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayWise.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDayWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateTimeWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optTimeWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableSurcharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDateWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlot)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurgeIncreament.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurgeIncreament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadCheckBox chkEnableSurcharge;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnExitForm;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadRadioButton optTimeWise;
        private Telerik.WinControls.UI.RadRadioButton optDateWise;
        private Telerik.WinControls.UI.RadRadioButton optDateTimeWise;
		private Telerik.WinControls.UI.RadButton btnAdd;
		private Telerik.WinControls.UI.RadGridView grdSurgeIncreament;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadRadioButton optDayWise;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddlSearchType;
        private Telerik.WinControls.UI.RadGridView grdDayWise;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSpinEditor numIncrementRate;
        private UI.MyGridView grdPlot;
    }
}