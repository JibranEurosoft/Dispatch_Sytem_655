using System.Windows.Forms;

namespace Taxi_AppMain
{
    partial class frmTrip
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
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.btnDown = new Telerik.WinControls.UI.RadButton();
            this.btnUp = new Telerik.WinControls.UI.RadButton();
            this.txtNoOfPax = new Telerik.WinControls.UI.RadTextBox();
            this.lblTotalNoPassenger = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdLister = new UI.MyGridView();
            this.chkAll = new Telerik.WinControls.UI.RadCheckBox();
            this.btnSaveInvoice = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.dtpTillDate = new UI.MyDatePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkFollowSequence = new Telerik.WinControls.UI.RadCheckBox();
            this.dtpFromDate = new UI.MyDatePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnAddNewShuttle = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpTripDate = new UI.MyDatePicker();
            this.txtTripNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.f = new Telerik.WinControls.UI.RadPanel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.dtpShuttleDate = new System.Windows.Forms.DateTimePicker();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.grdTripList = new UI.MyGridView();
            this.contextMenuCreditNote = new System.Windows.Forms.ContextMenuStrip(this.components);
          //  this.deleteCreditNote = new Telerik.WinControls.Design.ToolStripAddNewMenuItem();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoOfPax)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            this.grdLister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFollowSequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewShuttle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTripDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTripNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).BeginInit();
            this.f.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTripList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTripList.MasterTemplate)).BeginInit();
            this.contextMenuCreditNote.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(362, 92);
            this.btnSaveOn.Size = new System.Drawing.Size(101, 56);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1335, 0);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(461, 286);
            this.btnSaveAndClose.Size = new System.Drawing.Size(150, 56);
            // 
            // radPanel5
            // 
            this.radPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel5.Controls.Add(this.btnDown);
            this.radPanel5.Controls.Add(this.btnUp);
            this.radPanel5.Controls.Add(this.txtNoOfPax);
            this.radPanel5.Controls.Add(this.lblTotalNoPassenger);
            this.radPanel5.Controls.Add(this.panel1);
            this.radPanel5.Controls.Add(this.btnSaveInvoice);
            this.radPanel5.Controls.Add(this.radButton1);
            this.radPanel5.Controls.Add(this.dtpTillDate);
            this.radPanel5.Controls.Add(this.radLabel2);
            this.radPanel5.Controls.Add(this.chkFollowSequence);
            this.radPanel5.Controls.Add(this.dtpFromDate);
            this.radPanel5.Controls.Add(this.radLabel4);
            this.radPanel5.Controls.Add(this.btnAddNewShuttle);
            this.radPanel5.Controls.Add(this.radLabel3);
            this.radPanel5.Controls.Add(this.dtpTripDate);
            this.radPanel5.Controls.Add(this.txtTripNo);
            this.radPanel5.Controls.Add(this.radLabel1);
            this.radPanel5.Controls.Add(this.label7);
            this.radPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel5.Location = new System.Drawing.Point(0, 38);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(1415, 371);
            this.radPanel5.TabIndex = 106;
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            this.btnDown.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDown.Location = new System.Drawing.Point(340, 118);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(63, 33);
            this.btnDown.TabIndex = 226;
            this.btnDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDown.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDown.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDown.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDown.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDown.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDown.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            this.btnUp.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUp.Location = new System.Drawing.Point(340, 79);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(63, 33);
            this.btnUp.TabIndex = 225;
            this.btnUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUp.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_moveup;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUp.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUp.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUp.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUp.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUp.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtNoOfPax
            // 
            this.txtNoOfPax.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfPax.Location = new System.Drawing.Point(37, 182);
            this.txtNoOfPax.Name = "txtNoOfPax";
            this.txtNoOfPax.ReadOnly = true;
            this.txtNoOfPax.Size = new System.Drawing.Size(54, 24);
            this.txtNoOfPax.TabIndex = 224;
            this.txtNoOfPax.TabStop = false;
            this.txtNoOfPax.Visible = false;
            // 
            // lblTotalNoPassenger
            // 
            this.lblTotalNoPassenger.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNoPassenger.ForeColor = System.Drawing.Color.Red;
            this.lblTotalNoPassenger.Location = new System.Drawing.Point(12, 125);
            this.lblTotalNoPassenger.Name = "lblTotalNoPassenger";
            this.lblTotalNoPassenger.Size = new System.Drawing.Size(205, 53);
            this.lblTotalNoPassenger.TabIndex = 223;
            this.lblTotalNoPassenger.Text = "Total No of Passenger(s) :";
            this.lblTotalNoPassenger.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdLister);
            this.panel1.Location = new System.Drawing.Point(409, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 290);
            this.panel1.TabIndex = 222;
            // 
            // grdLister
            // 
            this.grdLister.AutoCellFormatting = false;
            this.grdLister.Controls.Add(this.chkAll);
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLister.EnableCheckInCheckOut = false;
            this.grdLister.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdLister.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdLister.Location = new System.Drawing.Point(0, 0);
            // 
            // grdLister
            // 
            this.grdLister.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.grdLister.Name = "grdLister";
            this.grdLister.PKFieldColumnName = "";
            this.grdLister.ShowImageOnActionButton = true;
            this.grdLister.Size = new System.Drawing.Size(1002, 290);
            this.grdLister.TabIndex = 221;
            this.grdLister.Text = "myGridView1";
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(11, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 15);
            this.chkAll.TabIndex = 219;
            this.chkAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAll_ToggleStateChanged);
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveInvoice.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveInvoice.Location = new System.Drawing.Point(222, 224);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(149, 55);
            this.btnSaveInvoice.TabIndex = 89;
            this.btnSaveInvoice.Text = "Save";
            this.btnSaveInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveInvoice.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSaveInvoice.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(1148, 43);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(126, 30);
            this.radButton1.TabIndex = 86;
            this.radButton1.Text = "Pick Booking";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Click += new System.EventHandler(this.btnPickBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Pick Booking";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dtpTillDate
            // 
            this.dtpTillDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpTillDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTillDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTillDate.Location = new System.Drawing.Point(964, 47);
            this.dtpTillDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Name = "dtpTillDate";
            this.dtpTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTillDate.Size = new System.Drawing.Size(156, 24);
            this.dtpTillDate.TabIndex = 61;
            this.dtpTillDate.TabStop = false;
            this.dtpTillDate.Text = "myDatePicker2";
            this.dtpTillDate.Value = null;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(915, 49);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 22);
            this.radLabel2.TabIndex = 60;
            this.radLabel2.Text = "Till";
            // 
            // chkFollowSequence
            // 
            this.chkFollowSequence.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFollowSequence.Location = new System.Drawing.Point(405, 49);
            this.chkFollowSequence.Name = "chkFollowSequence";
            this.chkFollowSequence.Size = new System.Drawing.Size(152, 22);
            this.chkFollowSequence.TabIndex = 218;
            this.chkFollowSequence.Text = "Follow Sequence";
            this.chkFollowSequence.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Culture = new System.Globalization.CultureInfo("en-GB");
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(753, 49);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Size = new System.Drawing.Size(156, 24);
            this.dtpFromDate.TabIndex = 59;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Text = "myDatePicker1";
            this.dtpFromDate.Value = null;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(636, 49);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(114, 22);
            this.radLabel4.TabIndex = 58;
            this.radLabel4.Text = "Pickup From :";
            // 
            // btnAddNewShuttle
            // 
            this.btnAddNewShuttle.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAddNewShuttle.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewShuttle.Location = new System.Drawing.Point(10, 224);
            this.btnAddNewShuttle.Name = "btnAddNewShuttle";
            this.btnAddNewShuttle.Size = new System.Drawing.Size(143, 56);
            this.btnAddNewShuttle.TabIndex = 108;
            this.btnAddNewShuttle.Text = "Create New Shuttle";
            this.btnAddNewShuttle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNewShuttle.Click += new System.EventHandler(this.btnAddNewInvoice_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewShuttle.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewShuttle.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewShuttle.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddNewShuttle.GetChildAt(0))).Text = "Create New Shuttle";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddNewShuttle.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddNewShuttle.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(12, 82);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(92, 22);
            this.radLabel3.TabIndex = 81;
            this.radLabel3.Text = "Shuttle Date";
            // 
            // dtpTripDate
            // 
            this.dtpTripDate.Culture = new System.Globalization.CultureInfo("en-AU");
            this.dtpTripDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTripDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTripDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTripDate.Location = new System.Drawing.Point(155, 81);
            this.dtpTripDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTripDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTripDate.Name = "dtpTripDate";
            this.dtpTripDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTripDate.Size = new System.Drawing.Size(156, 24);
            this.dtpTripDate.TabIndex = 82;
            this.dtpTripDate.TabStop = false;
            this.dtpTripDate.Text = "radDateTimePicker1";
            this.dtpTripDate.Value = new System.DateTime(2011, 9, 21, 2, 48, 22, 638);
            // 
            // txtTripNo
            // 
            this.txtTripNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTripNo.Location = new System.Drawing.Point(155, 44);
            this.txtTripNo.Name = "txtTripNo";
            this.txtTripNo.ReadOnly = true;
            this.txtTripNo.Size = new System.Drawing.Size(156, 24);
            this.txtTripNo.TabIndex = 76;
            this.txtTripNo.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(12, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 22);
            this.radLabel1.TabIndex = 77;
            this.radLabel1.Text = "Shuttle No";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1415, 38);
            this.label7.TabIndex = 109;
            this.label7.Text = "Manage Shuttle";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f
            // 
            this.f.BackColor = System.Drawing.Color.AntiqueWhite;
            this.f.Controls.Add(this.radPanel1);
            this.f.Dock = System.Windows.Forms.DockStyle.Top;
            this.f.Location = new System.Drawing.Point(0, 409);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(1415, 29);
            this.f.TabIndex = 107;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.radPanel1.Controls.Add(this.dtpShuttleDate);
            this.radPanel1.Controls.Add(this.radLabel7);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1415, 29);
            this.radPanel1.TabIndex = 110;
            this.radPanel1.Text = "Shuttle List";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpShuttleDate
            // 
            this.dtpShuttleDate.CustomFormat = "dd/MM/yyyy";
            this.dtpShuttleDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpShuttleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShuttleDate.Location = new System.Drawing.Point(124, 2);
            this.dtpShuttleDate.Name = "dtpShuttleDate";
            this.dtpShuttleDate.Size = new System.Drawing.Size(148, 27);
            this.dtpShuttleDate.TabIndex = 110;
            this.dtpShuttleDate.ValueChanged += new System.EventHandler(this.dtpShuttleDate_ValueChanged);
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(7, 6);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(106, 22);
            this.radLabel7.TabIndex = 108;
            this.radLabel7.Text = "Date Criteria";
            // 
            // grdTripList
            // 
            this.grdTripList.AutoCellFormatting = false;
            this.grdTripList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTripList.EnableCheckInCheckOut = false;
            this.grdTripList.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdTripList.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdTripList.Location = new System.Drawing.Point(0, 438);
            this.grdTripList.Name = "grdTripList";
            this.grdTripList.PKFieldColumnName = "";
            this.grdTripList.ShowImageOnActionButton = true;
            this.grdTripList.Size = new System.Drawing.Size(1415, 342);
            this.grdTripList.TabIndex = 109;
            this.grdTripList.Text = "myGridView1";
            this.grdTripList.Click += new System.EventHandler(this.grdTripList_Click);
            this.grdTripList.DoubleClick += new System.EventHandler(this.grdTripList_DoubleClick);
            // 
            // contextMenuCreditNote
            // 
            this.contextMenuCreditNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                //  this.deleteCreditNote
            }
            );
            this.contextMenuCreditNote.Name = "contextMenuCreditNote";
            this.contextMenuCreditNote.Size = new System.Drawing.Size(172, 26);
            //// 
            //// deleteCreditNote
            //// 
            //this.deleteCreditNote.CustomOnClickHandler = false;
            //this.deleteCreditNote.Image = global::Taxi_AppMain.Properties.Resources.delete;
            //this.deleteCreditNote.ItemsToAddTo = null;
            //this.deleteCreditNote.Name = "deleteCreditNote";
            //this.deleteCreditNote.NewItemType = null;
            //this.deleteCreditNote.ShouldInsertAfterCurrent = false;
            //this.deleteCreditNote.Size = new System.Drawing.Size(171, 22);
            //this.deleteCreditNote.Text = "Delete Credit Note";
            // 
            // frmTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 780);
            this.Controls.Add(this.grdTripList);
            this.Controls.Add(this.f);
            this.Controls.Add(this.radPanel5);
            this.FixedExitButtonOnTopRight = true;
            this.FormTitle = "Manage Shuttle";
            this.Name = "frmTrip";
            // 
            // 
            // 
        //    //this.RootElement.ApplyShapeToControl = true;
        //    //this.RootElement.MinSize = new System.Drawing.Size(150, 36);
            this.ShowExitButton = true;
            this.Text = "Manage Shuttle";
            this.Shown += new System.EventHandler(this.frmInvoice_Shown);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.radPanel5, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.f, 0);
            this.Controls.SetChildIndex(this.grdTripList, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoOfPax)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            this.grdLister.ResumeLayout(false);
            this.grdLister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFollowSequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewShuttle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTripDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTripNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).EndInit();
            this.f.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTripList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTripList)).EndInit();
            this.contextMenuCreditNote.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyDatePicker dtpTripDate;
        private Telerik.WinControls.UI.RadTextBox txtTripNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel f;
        private UI.MyGridView grdTripList;
        private Telerik.WinControls.UI.RadGridView radGridView2;
        private UI.MyDatePicker dtpTillDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private UI.MyDatePicker dtpFromDate;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnSaveInvoice;
        private Telerik.WinControls.UI.RadButton btnAddNewShuttle;
        private System.Windows.Forms.Label label7;
        private ContextMenuStrip contextMenuCreditNote;
      //  private Telerik.WinControls.Design.ToolStripAddNewMenuItem deleteCreditNote;
        private SaveFileDialog saveFileDialog2;
        private Telerik.WinControls.UI.RadCheckBox chkFollowSequence;
        private Telerik.WinControls.UI.RadCheckBox chkAll;
        private UI.MyGridView grdLister;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Panel panel1;
        private DateTimePicker dtpShuttleDate;
        private Label lblTotalNoPassenger;
        private Telerik.WinControls.UI.RadTextBox txtNoOfPax;
        private Telerik.WinControls.UI.RadButton btnDown;
        private Telerik.WinControls.UI.RadButton btnUp;
    }
}