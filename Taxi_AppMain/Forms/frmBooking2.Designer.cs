using System;
using Telerik.WinControls.UI;
using System.Windows.Forms;
namespace Taxi_AppMain
{
    partial class frmBooking2
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSurge = new System.Windows.Forms.CheckBox();
            this.chkAllocateDriver = new System.Windows.Forms.CheckBox();
            this.btnAccountInformation = new System.Windows.Forms.Button();
            this.dtpPickupTime_txt = new System.Windows.Forms.TextBox();
            this.pnlReturnJobNo = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.lblretto = new System.Windows.Forms.Label();
            this.lblretfrom = new System.Windows.Forms.Label();
            this.lblReturnAddress = new System.Windows.Forms.Label();
            this.btnExcludeDrivers = new System.Windows.Forms.Button();
            this.txtReturnTo = new UIX.AutoCompleteTextBox();
            this.chkLead = new System.Windows.Forms.CheckBox();
            this.chkReverse = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numLead = new System.Windows.Forms.NumericUpDown();
            this.btnAttributes = new System.Windows.Forms.Button();
            this.ddlDriver = new UI.MyDropDownList();
            this.pnlAutoDespatch = new System.Windows.Forms.Panel();
            this.btnCall = new System.Windows.Forms.Button();
            this.chkHasPriority = new System.Windows.Forms.CheckBox();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.btnSms = new System.Windows.Forms.Button();
            this.chkBidding = new System.Windows.Forms.CheckBox();
            this.chkAutoDespatch = new System.Windows.Forms.CheckBox();
            this.numBeforeMinutes = new System.Windows.Forms.NumericUpDown();
            this.btnCustomerLister = new System.Windows.Forms.Button();
            this.chkIsCompanyRates = new System.Windows.Forms.CheckBox();
            this.lblLuggages = new System.Windows.Forms.Label();
            this.lblPassengers = new System.Windows.Forms.Label();
            this.pnljourney = new System.Windows.Forms.Panel();
            this.opt_one = new System.Windows.Forms.RadioButton();
            this.opt_waitreturn = new System.Windows.Forms.RadioButton();
            this.opt_return = new System.Windows.Forms.RadioButton();
            this.radLabel14 = new System.Windows.Forms.Label();
            this.btnMultiVehicle = new System.Windows.Forms.Button();
            this.btn_notes = new System.Windows.Forms.Button();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtReturnFrom = new UIX.AutoCompleteTextBox();
            this.btnSelectVia = new System.Windows.Forms.Button();
            this.ddlDropOffPlot = new System.Windows.Forms.ComboBox();
            this.ddlPickupPlot = new System.Windows.Forms.ComboBox();
            this.lblDropOffPlot = new System.Windows.Forms.Label();
            this.lblPickupPlot = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.Label();
            this.numTotalLuggages = new System.Windows.Forms.NumericUpDown();
            this.num_TotalPassengers = new System.Windows.Forms.NumericUpDown();
            this.ddlCompany = new Taxi_AppMain.SuggestComboBox();
            this.ddlVehicleType = new System.Windows.Forms.ComboBox();
            this.radLabel2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.radLabel6 = new System.Windows.Forms.Label();
            this.radLabel21 = new System.Windows.Forms.Label();
            this.radLabel19 = new System.Windows.Forms.Label();
            this.txtCustomerPhoneNo = new System.Windows.Forms.TextBox();
            this.txtCustomerMobileNo = new System.Windows.Forms.TextBox();
            this.ddlCustomerName = new System.Windows.Forms.TextBox();
            this.dtpPickupDate = new UI.MyDatePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpPickupTime = new UI.MyDatePicker();
            this.lblPickupTime = new System.Windows.Forms.Label();
            this.chkQuotation = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ddlRoute = new System.Windows.Forms.ComboBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.btnNearestDrv = new System.Windows.Forms.Button();
            this.btnDespatchView = new System.Windows.Forms.Button();
            this.btnPasteBooking = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnAccountCode = new System.Windows.Forms.Button();
            this.btnMultiBooking = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBase = new System.Windows.Forms.Button();
            this.txtFromAddress = new UIX.AutoCompleteTextBox();
            this.txtFromPostCode = new System.Windows.Forms.TextBox();
            this.txtFromStreetComing = new System.Windows.Forms.TextBox();
            this.txtFromFlightDoorNo = new System.Windows.Forms.TextBox();
            this.lblFromStreetComing = new System.Windows.Forms.Label();
            this.lblFromDoorFlightNo = new System.Windows.Forms.Label();
            this.txtToAddress = new UIX.AutoCompleteTextBox();
            this.lblFromLoc = new System.Windows.Forms.Label();
            this.ddlFromLocType = new System.Windows.Forms.ComboBox();
            this.ddlToLocType = new System.Windows.Forms.ComboBox();
            this.lblToLoc = new System.Windows.Forms.Label();
            this.txtToStreetComing = new System.Windows.Forms.TextBox();
            this.txtToPostCode = new System.Windows.Forms.TextBox();
            this.lblToStreetComing = new System.Windows.Forms.Label();
            this.txtToFlightDoorNo = new System.Windows.Forms.TextBox();
            this.lblToDoorFlightNo = new System.Windows.Forms.Label();
            this.radPanel3 = new System.Windows.Forms.Panel();
            this.btnSetFares = new Telerik.WinControls.UI.RadButton();
            this.txtPromotion = new System.Windows.Forms.Label();
            this.txtFaresPostedFrom = new System.Windows.Forms.Label();
            this.btnJobInformation = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnExitForm = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.radPanel1 = new System.Windows.Forms.Panel();
            this.btnregisterlink = new System.Windows.Forms.Button();
            this.btnsendpaymentlink = new System.Windows.Forms.Button();
            this.lblCardIsRegisteredKP = new System.Windows.Forms.Label();
            this.chkMiles = new System.Windows.Forms.CheckBox();
            this.numMiles = new System.Windows.Forms.NumericUpDown();
            this.pnlOtherCharges = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnExtrAcHARGES = new System.Windows.Forms.Button();
            this.numTipAmount = new System.Windows.Forms.NumericUpDown();
            this.radLabel4 = new System.Windows.Forms.Label();
            this.numDrvWaitingMins = new System.Windows.Forms.NumericUpDown();
            this.lblTotalCharges = new System.Windows.Forms.Label();
            this.numTotalChrgs = new System.Windows.Forms.NumericUpDown();
            this.radLabel20 = new System.Windows.Forms.Label();
            this.numCongChrgs = new System.Windows.Forms.NumericUpDown();
            this.radLabel16 = new System.Windows.Forms.Label();
            this.numMeetCharges = new System.Windows.Forms.NumericUpDown();
            this.radLabel17 = new System.Windows.Forms.Label();
            this.numExtraChrgs = new System.Windows.Forms.NumericUpDown();
            this.lblAccWaitingCharges = new System.Windows.Forms.Label();
            this.numWaitingChrgs = new System.Windows.Forms.NumericUpDown();
            this.lblAccParkingCharges = new System.Windows.Forms.Label();
            this.numParkingChrgs = new System.Windows.Forms.NumericUpDown();
            this.btnPickFares = new System.Windows.Forms.Button();
            this.pnlPayment1 = new Telerik.WinControls.UI.RadPanel();
            this.pic_card = new System.Windows.Forms.Label();
            this.btnRefundKP = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.radLabel7 = new System.Windows.Forms.Label();
            this.ddlPaymentType = new System.Windows.Forms.ComboBox();
            this.btnViewMapReport = new System.Windows.Forms.Button();
            this.radLabel27 = new System.Windows.Forms.Label();
            this.txtSpecialRequirements = new System.Windows.Forms.TextBox();
            this.btnTrackDriver = new System.Windows.Forms.Button();
            this.pnlBookingFees = new System.Windows.Forms.Label();
            this.numReturnBookingFee = new System.Windows.Forms.NumericUpDown();
            this.lblReturnCustFare = new System.Windows.Forms.Label();
            this.numBookingFee = new System.Windows.Forms.NumericUpDown();
            this.chkPermanentCustNotes = new System.Windows.Forms.CheckBox();
            this.txtPaymentReference = new System.Windows.Forms.TextBox();
            this.btnDetailMap = new System.Windows.Forms.Button();
            this.radLabel25 = new System.Windows.Forms.Label();
            this.lblPaymentRef = new System.Windows.Forms.Label();
            this.radLabel5 = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.pnlFares = new System.Windows.Forms.Label();
            this.numFareRate = new System.Windows.Forms.NumericUpDown();
            this.chkQuotedPrice = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBookingNo = new System.Windows.Forms.Label();
            this.ddlBookingType = new System.Windows.Forms.ComboBox();
            this.lblBookingType = new System.Windows.Forms.Label();
            this.lblBookedBy = new System.Windows.Forms.Label();
            this.ddlSubCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numHandLugg = new System.Windows.Forms.NumericUpDown();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).BeginInit();
            this.pnlAutoDespatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeforeMinutes)).BeginInit();
            this.pnljourney.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalLuggages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TotalPassengers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPickupDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPickupTime)).BeginInit();
            this.panel4.SuspendLayout();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetFares)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).BeginInit();
            this.pnlOtherCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTipAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDrvWaitingMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCongChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeetCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitingChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParkingChrgs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPayment1)).BeginInit();
            this.pnlPayment1.SuspendLayout();
            this.pnlBookingFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnBookingFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookingFee)).BeginInit();
            this.pnlFares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFareRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandLugg)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.radPanel3);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1284, 761);
            this.pnlMain.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.7944F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.20561F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 445);
            this.tableLayoutPanel1.TabIndex = 235;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.chkSurge);
            this.panel2.Controls.Add(this.chkAllocateDriver);
            this.panel2.Controls.Add(this.btnAccountInformation);
            this.panel2.Controls.Add(this.dtpPickupTime_txt);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.numHandLugg);
            this.panel2.Controls.Add(this.pnlReturnJobNo);
            this.panel2.Controls.Add(this.btnInfo);
            this.panel2.Controls.Add(this.lblretto);
            this.panel2.Controls.Add(this.lblretfrom);
            this.panel2.Controls.Add(this.lblReturnAddress);
            this.panel2.Controls.Add(this.btnExcludeDrivers);
            this.panel2.Controls.Add(this.txtReturnTo);
            this.panel2.Controls.Add(this.chkLead);
            this.panel2.Controls.Add(this.chkReverse);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.numLead);
            this.panel2.Controls.Add(this.btnAttributes);
            this.panel2.Controls.Add(this.ddlDriver);
            this.panel2.Controls.Add(this.pnlAutoDespatch);
            this.panel2.Controls.Add(this.btnCustomerLister);
            this.panel2.Controls.Add(this.chkIsCompanyRates);
            this.panel2.Controls.Add(this.lblLuggages);
            this.panel2.Controls.Add(this.lblPassengers);
            this.panel2.Controls.Add(this.pnljourney);
            this.panel2.Controls.Add(this.radLabel14);
            this.panel2.Controls.Add(this.btnMultiVehicle);
            this.panel2.Controls.Add(this.btn_notes);
            this.panel2.Controls.Add(this.lblVehicleType);
            this.panel2.Controls.Add(this.txtReturnFrom);
            this.panel2.Controls.Add(this.btnSelectVia);
            this.panel2.Controls.Add(this.ddlDropOffPlot);
            this.panel2.Controls.Add(this.ddlPickupPlot);
            this.panel2.Controls.Add(this.lblDropOffPlot);
            this.panel2.Controls.Add(this.lblPickupPlot);
            this.panel2.Controls.Add(this.txtVehicleNo);
            this.panel2.Controls.Add(this.pnlCustomer);
            this.panel2.Controls.Add(this.dtpPickupDate);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.dtpPickupTime);
            this.panel2.Controls.Add(this.lblPickupTime);
            this.panel2.Controls.Add(this.chkQuotation);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtFromAddress);
            this.panel2.Controls.Add(this.txtFromPostCode);
            this.panel2.Controls.Add(this.txtFromStreetComing);
            this.panel2.Controls.Add(this.txtFromFlightDoorNo);
            this.panel2.Controls.Add(this.lblFromStreetComing);
            this.panel2.Controls.Add(this.lblFromDoorFlightNo);
            this.panel2.Controls.Add(this.txtToAddress);
            this.panel2.Controls.Add(this.lblFromLoc);
            this.panel2.Controls.Add(this.ddlFromLocType);
            this.panel2.Controls.Add(this.ddlToLocType);
            this.panel2.Controls.Add(this.lblToLoc);
            this.panel2.Controls.Add(this.txtToStreetComing);
            this.panel2.Controls.Add(this.txtToPostCode);
            this.panel2.Controls.Add(this.lblToStreetComing);
            this.panel2.Controls.Add(this.txtToFlightDoorNo);
            this.panel2.Controls.Add(this.lblToDoorFlightNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(903, 439);
            this.panel2.TabIndex = 107;
            // 
            // chkSurge
            // 
            this.chkSurge.BackColor = System.Drawing.Color.Lavender;
            this.chkSurge.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSurge.ForeColor = System.Drawing.Color.Red;
            this.chkSurge.Location = new System.Drawing.Point(4, 416);
            this.chkSurge.Name = "chkSurge";
            this.chkSurge.Size = new System.Drawing.Size(333, 18);
            this.chkSurge.TabIndex = 529;
            this.chkSurge.Text = "Surge";
            this.chkSurge.UseVisualStyleBackColor = false;
            this.chkSurge.Visible = false;
            // 
            // chkAllocateDriver
            // 
            this.chkAllocateDriver.AutoSize = true;
            this.chkAllocateDriver.BackColor = System.Drawing.Color.AliceBlue;
            this.chkAllocateDriver.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkAllocateDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkAllocateDriver.Location = new System.Drawing.Point(3, 362);
            this.chkAllocateDriver.Name = "chkAllocateDriver";
            this.chkAllocateDriver.Size = new System.Drawing.Size(114, 21);
            this.chkAllocateDriver.TabIndex = 528;
            this.chkAllocateDriver.Text = "Allocate Drive&r";
            this.chkAllocateDriver.UseVisualStyleBackColor = false;
            // 
            // btnAccountInformation
            // 
            this.btnAccountInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnAccountInformation.Font = new System.Drawing.Font("Arial Narrow", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAccountInformation.ForeColor = System.Drawing.Color.Blue;
            this.btnAccountInformation.Location = new System.Drawing.Point(876, 331);
            this.btnAccountInformation.Name = "btnAccountInformation";
            this.btnAccountInformation.Size = new System.Drawing.Size(25, 24);
            this.btnAccountInformation.TabIndex = 527;
            this.btnAccountInformation.Text = "i";
            this.btnAccountInformation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAccountInformation.UseVisualStyleBackColor = false;
            this.btnAccountInformation.Visible = false;
            this.btnAccountInformation.Click += new System.EventHandler(this.btnAccountInformation_Click);
            // 
            // dtpPickupTime_txt
            // 
            this.dtpPickupTime_txt.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.dtpPickupTime_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.dtpPickupTime_txt.Location = new System.Drawing.Point(118, 41);
            this.dtpPickupTime_txt.MaxLength = 4;
            this.dtpPickupTime_txt.Name = "dtpPickupTime_txt";
            this.dtpPickupTime_txt.Size = new System.Drawing.Size(60, 25);
            this.dtpPickupTime_txt.TabIndex = 526;
            this.dtpPickupTime_txt.Text = "ASAP";
            // 
            // pnlReturnJobNo
            // 
            this.pnlReturnJobNo.BackColor = System.Drawing.Color.Lavender;
            this.pnlReturnJobNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReturnJobNo.ForeColor = System.Drawing.Color.OrangeRed;
            this.pnlReturnJobNo.Location = new System.Drawing.Point(387, 38);
            this.pnlReturnJobNo.Name = "pnlReturnJobNo";
            this.pnlReturnJobNo.Size = new System.Drawing.Size(210, 28);
            this.pnlReturnJobNo.TabIndex = 202;
            this.pnlReturnJobNo.Text = "return";
            this.pnlReturnJobNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlReturnJobNo.Visible = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnInfo.Font = new System.Drawing.Font("Arial Narrow", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnInfo.ForeColor = System.Drawing.Color.Blue;
            this.btnInfo.Location = new System.Drawing.Point(446, 186);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(31, 28);
            this.btnInfo.TabIndex = 524;
            this.btnInfo.Text = "i";
            this.btnInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // lblretto
            // 
            this.lblretto.AutoSize = true;
            this.lblretto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblretto.Location = new System.Drawing.Point(363, 152);
            this.lblretto.Name = "lblretto";
            this.lblretto.Size = new System.Drawing.Size(39, 14);
            this.lblretto.TabIndex = 523;
            this.lblretto.Text = "R. To";
            this.lblretto.Visible = false;
            // 
            // lblretfrom
            // 
            this.lblretfrom.AutoSize = true;
            this.lblretfrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblretfrom.Location = new System.Drawing.Point(364, 86);
            this.lblretfrom.Name = "lblretfrom";
            this.lblretfrom.Size = new System.Drawing.Size(35, 14);
            this.lblretfrom.TabIndex = 522;
            this.lblretfrom.Text = "R. Fr";
            this.lblretfrom.Visible = false;
            // 
            // lblReturnAddress
            // 
            this.lblReturnAddress.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.lblReturnAddress.Location = new System.Drawing.Point(366, 115);
            this.lblReturnAddress.Name = "lblReturnAddress";
            this.lblReturnAddress.Size = new System.Drawing.Size(118, 21);
            this.lblReturnAddress.TabIndex = 521;
            this.lblReturnAddress.Text = "Return Address";
            this.lblReturnAddress.Visible = false;
            // 
            // btnExcludeDrivers
            // 
            this.btnExcludeDrivers.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExcludeDrivers.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnExcludeDrivers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnExcludeDrivers.Location = new System.Drawing.Point(487, 185);
            this.btnExcludeDrivers.Name = "btnExcludeDrivers";
            this.btnExcludeDrivers.Size = new System.Drawing.Size(189, 49);
            this.btnExcludeDrivers.TabIndex = 520;
            this.btnExcludeDrivers.Text = "E&xclude Driver(s)";
            this.btnExcludeDrivers.UseVisualStyleBackColor = false;
            this.btnExcludeDrivers.Click += new System.EventHandler(this.btnExcludeDrivers_Click);
            // 
            // txtReturnTo
            // 
            this.txtReturnTo.BackColor = System.Drawing.Color.White;
            this.txtReturnTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReturnTo.DefaultHeight = 0;
            this.txtReturnTo.DefaultWidth = 0;
            this.txtReturnTo.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnTo.ForceListBoxToUpdate = false;
            this.txtReturnTo.ForeColor = System.Drawing.Color.Black;
            this.txtReturnTo.FormerValue = "";
            this.txtReturnTo.Location = new System.Drawing.Point(402, 138);
            this.txtReturnTo.Multiline = true;
            this.txtReturnTo.Name = "txtReturnTo";
            this.txtReturnTo.SelectedItem = null;
            this.txtReturnTo.Size = new System.Drawing.Size(197, 40);
            this.txtReturnTo.TabIndex = 506;
            this.txtReturnTo.TabStop = false;
            this.txtReturnTo.Values = null;
            // 
            // chkLead
            // 
            this.chkLead.AutoSize = true;
            this.chkLead.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkLead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkLead.Location = new System.Drawing.Point(687, 184);
            this.chkLead.Name = "chkLead";
            this.chkLead.Size = new System.Drawing.Size(55, 18);
            this.chkLead.TabIndex = 519;
            this.chkLead.Text = "&Lead";
            this.chkLead.CheckedChanged += new System.EventHandler(this.chkLead_CheckedChanged);
            // 
            // chkReverse
            // 
            this.chkReverse.AutoSize = true;
            this.chkReverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.chkReverse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkReverse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkReverse.Location = new System.Drawing.Point(275, 117);
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(85, 17);
            this.chkReverse.TabIndex = 0;
            this.chkReverse.Text = "SWAP (F9)";
            this.chkReverse.UseVisualStyleBackColor = false;
            this.chkReverse.CheckStateChanged += new System.EventHandler(this.chkReverse_ToggleStateChanging);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FloralWhite;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label6.Location = new System.Drawing.Point(792, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 518;
            this.label6.Text = "mins";
            // 
            // numLead
            // 
            this.numLead.Enabled = false;
            this.numLead.Font = new System.Drawing.Font("Tahoma", 9F);
            this.numLead.InterceptArrowKeys = false;
            this.numLead.Location = new System.Drawing.Point(742, 183);
            this.numLead.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numLead.Name = "numLead";
            this.numLead.Size = new System.Drawing.Size(50, 22);
            this.numLead.TabIndex = 517;
            this.numLead.TabStop = false;
            // 
            // btnAttributes
            // 
            this.btnAttributes.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAttributes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAttributes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnAttributes.Location = new System.Drawing.Point(487, 240);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Size = new System.Drawing.Size(189, 46);
            this.btnAttributes.TabIndex = 502;
            this.btnAttributes.Text = "Attri&butes";
            this.btnAttributes.UseVisualStyleBackColor = false;
            // 
            // ddlDriver
            // 
            this.ddlDriver.Caption = null;
            this.ddlDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriver.Location = new System.Drawing.Point(118, 359);
            this.ddlDriver.Name = "ddlDriver";
            this.ddlDriver.Property = null;
            this.ddlDriver.ShowDownArrow = true;
            this.ddlDriver.Size = new System.Drawing.Size(220, 24);
            this.ddlDriver.TabIndex = 0;
            // 
            // pnlAutoDespatch
            // 
            this.pnlAutoDespatch.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlAutoDespatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAutoDespatch.Controls.Add(this.btnCall);
            this.pnlAutoDespatch.Controls.Add(this.chkHasPriority);
            this.pnlAutoDespatch.Controls.Add(this.numPriority);
            this.pnlAutoDespatch.Controls.Add(this.btnSms);
            this.pnlAutoDespatch.Controls.Add(this.chkBidding);
            this.pnlAutoDespatch.Controls.Add(this.chkAutoDespatch);
            this.pnlAutoDespatch.Controls.Add(this.numBeforeMinutes);
            this.pnlAutoDespatch.Location = new System.Drawing.Point(681, 179);
            this.pnlAutoDespatch.Name = "pnlAutoDespatch";
            this.pnlAutoDespatch.Size = new System.Drawing.Size(216, 116);
            this.pnlAutoDespatch.TabIndex = 0;
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.Green;
            this.btnCall.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCall.ForeColor = System.Drawing.Color.White;
            this.btnCall.Location = new System.Drawing.Point(84, 78);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(57, 27);
            this.btnCall.TabIndex = 532;
            this.btnCall.Text = "CALL";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Visible = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // chkHasPriority
            // 
            this.chkHasPriority.AutoSize = true;
            this.chkHasPriority.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkHasPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkHasPriority.Location = new System.Drawing.Point(5, 31);
            this.chkHasPriority.Name = "chkHasPriority";
            this.chkHasPriority.Size = new System.Drawing.Size(71, 18);
            this.chkHasPriority.TabIndex = 531;
            this.chkHasPriority.Text = "Priority";
            this.chkHasPriority.Visible = false;
            this.chkHasPriority.CheckedChanged += new System.EventHandler(this.chkHasPriority_CheckedChanged);
            // 
            // numPriority
            // 
            this.numPriority.Enabled = false;
            this.numPriority.Font = new System.Drawing.Font("Tahoma", 9F);
            this.numPriority.InterceptArrowKeys = false;
            this.numPriority.Location = new System.Drawing.Point(79, 30);
            this.numPriority.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(48, 22);
            this.numPriority.TabIndex = 529;
            this.numPriority.TabStop = false;
            this.numPriority.Visible = false;
            // 
            // btnSms
            // 
            this.btnSms.BackColor = System.Drawing.Color.Purple;
            this.btnSms.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSms.ForeColor = System.Drawing.Color.White;
            this.btnSms.Location = new System.Drawing.Point(150, 77);
            this.btnSms.Name = "btnSms";
            this.btnSms.Size = new System.Drawing.Size(61, 28);
            this.btnSms.TabIndex = 222;
            this.btnSms.Text = "SMS";
            this.btnSms.UseVisualStyleBackColor = false;
            this.btnSms.Visible = false;
            // 
            // chkBidding
            // 
            this.chkBidding.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkBidding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkBidding.Location = new System.Drawing.Point(5, 79);
            this.chkBidding.Name = "chkBidding";
            this.chkBidding.Size = new System.Drawing.Size(73, 20);
            this.chkBidding.TabIndex = 223;
            this.chkBidding.Text = "Bidding";
            // 
            // chkAutoDespatch
            // 
            this.chkAutoDespatch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoDespatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkAutoDespatch.Location = new System.Drawing.Point(5, 58);
            this.chkAutoDespatch.Name = "chkAutoDespatch";
            this.chkAutoDespatch.Size = new System.Drawing.Size(122, 20);
            this.chkAutoDespatch.TabIndex = 0;
            this.chkAutoDespatch.Text = "Auto Despatch";
            // 
            // numBeforeMinutes
            // 
            this.numBeforeMinutes.Enabled = false;
            this.numBeforeMinutes.InterceptArrowKeys = false;
            this.numBeforeMinutes.Location = new System.Drawing.Point(176, 4);
            this.numBeforeMinutes.Name = "numBeforeMinutes";
            this.numBeforeMinutes.Size = new System.Drawing.Size(24, 26);
            this.numBeforeMinutes.TabIndex = 10;
            this.numBeforeMinutes.TabStop = false;
            this.numBeforeMinutes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBeforeMinutes.Visible = false;
            // 
            // btnCustomerLister
            // 
            this.btnCustomerLister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnCustomerLister.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCustomerLister.Location = new System.Drawing.Point(408, 186);
            this.btnCustomerLister.Name = "btnCustomerLister";
            this.btnCustomerLister.Size = new System.Drawing.Size(31, 28);
            this.btnCustomerLister.TabIndex = 0;
            this.btnCustomerLister.Text = "...";
            this.btnCustomerLister.UseVisualStyleBackColor = false;
            // 
            // chkIsCompanyRates
            // 
            this.chkIsCompanyRates.AutoSize = true;
            this.chkIsCompanyRates.BackColor = System.Drawing.Color.AliceBlue;
            this.chkIsCompanyRates.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkIsCompanyRates.ForeColor = System.Drawing.Color.Black;
            this.chkIsCompanyRates.Location = new System.Drawing.Point(406, 303);
            this.chkIsCompanyRates.Name = "chkIsCompanyRates";
            this.chkIsCompanyRates.Size = new System.Drawing.Size(84, 21);
            this.chkIsCompanyRates.TabIndex = 238;
            this.chkIsCompanyRates.Text = "&Account";
            this.chkIsCompanyRates.UseVisualStyleBackColor = false;
            // 
            // lblLuggages
            // 
            this.lblLuggages.BackColor = System.Drawing.Color.AliceBlue;
            this.lblLuggages.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuggages.ForeColor = System.Drawing.Color.Black;
            this.lblLuggages.Location = new System.Drawing.Point(200, 389);
            this.lblLuggages.Name = "lblLuggages";
            this.lblLuggages.Size = new System.Drawing.Size(73, 22);
            this.lblLuggages.TabIndex = 254;
            this.lblLuggages.Text = "Lu&ggage";
            // 
            // lblPassengers
            // 
            this.lblPassengers.BackColor = System.Drawing.Color.AliceBlue;
            this.lblPassengers.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassengers.ForeColor = System.Drawing.Color.Black;
            this.lblPassengers.Location = new System.Drawing.Point(9, 390);
            this.lblPassengers.Name = "lblPassengers";
            this.lblPassengers.Size = new System.Drawing.Size(93, 22);
            this.lblPassengers.TabIndex = 252;
            this.lblPassengers.Text = "Passe&ngers";
            // 
            // pnljourney
            // 
            this.pnljourney.BackColor = System.Drawing.Color.AliceBlue;
            this.pnljourney.Controls.Add(this.opt_one);
            this.pnljourney.Controls.Add(this.opt_waitreturn);
            this.pnljourney.Controls.Add(this.opt_return);
            this.pnljourney.Location = new System.Drawing.Point(119, 328);
            this.pnljourney.Name = "pnljourney";
            this.pnljourney.Size = new System.Drawing.Size(238, 29);
            this.pnljourney.TabIndex = 9;
            this.pnljourney.TabStop = true;
            // 
            // opt_one
            // 
            this.opt_one.AutoSize = true;
            this.opt_one.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_one.Location = new System.Drawing.Point(5, 4);
            this.opt_one.Name = "opt_one";
            this.opt_one.Size = new System.Drawing.Size(88, 22);
            this.opt_one.TabIndex = 7;
            this.opt_one.TabStop = true;
            this.opt_one.Text = "&One Way";
            this.opt_one.UseVisualStyleBackColor = true;
            this.opt_one.CheckedChanged += new System.EventHandler(this.opt_one_CheckedChanged);
            this.opt_one.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opt_one_KeyDown);
            // 
            // opt_waitreturn
            // 
            this.opt_waitreturn.AutoSize = true;
            this.opt_waitreturn.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_waitreturn.Location = new System.Drawing.Point(175, 4);
            this.opt_waitreturn.Name = "opt_waitreturn";
            this.opt_waitreturn.Size = new System.Drawing.Size(55, 22);
            this.opt_waitreturn.TabIndex = 9;
            this.opt_waitreturn.TabStop = true;
            this.opt_waitreturn.Text = "&W/R";
            this.opt_waitreturn.UseVisualStyleBackColor = true;
            this.opt_waitreturn.CheckedChanged += new System.EventHandler(this.opt_waitreturn_CheckedChanged);
            this.opt_waitreturn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opt_one_KeyDown);
            // 
            // opt_return
            // 
            this.opt_return.AutoSize = true;
            this.opt_return.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_return.Location = new System.Drawing.Point(99, 4);
            this.opt_return.Name = "opt_return";
            this.opt_return.Size = new System.Drawing.Size(69, 22);
            this.opt_return.TabIndex = 8;
            this.opt_return.TabStop = true;
            this.opt_return.Text = "Ret&urn";
            this.opt_return.UseVisualStyleBackColor = true;
            this.opt_return.CheckedChanged += new System.EventHandler(this.opt_return_CheckedChanged);
            this.opt_return.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opt_one_KeyDown);
            this.opt_return.Validating += new System.ComponentModel.CancelEventHandler(this.opt_return_Validating);
            // 
            // radLabel14
            // 
            this.radLabel14.BackColor = System.Drawing.Color.AliceBlue;
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel14.Location = new System.Drawing.Point(8, 333);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(104, 21);
            this.radLabel14.TabIndex = 245;
            this.radLabel14.Text = "Journey";
            // 
            // btnMultiVehicle
            // 
            this.btnMultiVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnMultiVehicle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnMultiVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnMultiVehicle.Location = new System.Drawing.Point(322, 300);
            this.btnMultiVehicle.Name = "btnMultiVehicle";
            this.btnMultiVehicle.Size = new System.Drawing.Size(79, 26);
            this.btnMultiVehicle.TabIndex = 0;
            this.btnMultiVehicle.Text = "&Multi Veh";
            this.btnMultiVehicle.UseVisualStyleBackColor = false;
            // 
            // btn_notes
            // 
            this.btn_notes.BackColor = System.Drawing.Color.GhostWhite;
            this.btn_notes.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_notes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btn_notes.Location = new System.Drawing.Point(410, 221);
            this.btn_notes.Name = "btn_notes";
            this.btn_notes.Size = new System.Drawing.Size(59, 63);
            this.btn_notes.TabIndex = 0;
            this.btn_notes.Text = "Notes(0) [F5]";
            this.btn_notes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_notes.UseVisualStyleBackColor = false;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.BackColor = this.panel2.BackColor;
            this.lblVehicleType.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblVehicleType.Location = new System.Drawing.Point(9, 304);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(94, 20);
            this.lblVehicleType.TabIndex = 244;
            this.lblVehicleType.Text = "&Vehicle";
            // 
            // txtReturnFrom
            // 
            this.txtReturnFrom.BackColor = System.Drawing.Color.White;
            this.txtReturnFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReturnFrom.DefaultHeight = 0;
            this.txtReturnFrom.DefaultWidth = 0;
            this.txtReturnFrom.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnFrom.ForceListBoxToUpdate = false;
            this.txtReturnFrom.ForeColor = System.Drawing.Color.Black;
            this.txtReturnFrom.FormerValue = "";
            this.txtReturnFrom.Location = new System.Drawing.Point(402, 72);
            this.txtReturnFrom.Multiline = true;
            this.txtReturnFrom.Name = "txtReturnFrom";
            this.txtReturnFrom.SelectedItem = null;
            this.txtReturnFrom.Size = new System.Drawing.Size(197, 40);
            this.txtReturnFrom.TabIndex = 505;
            this.txtReturnFrom.TabStop = false;
            this.txtReturnFrom.Values = null;
            // 
            // btnSelectVia
            // 
            this.btnSelectVia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnSelectVia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSelectVia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSelectVia.Location = new System.Drawing.Point(132, 113);
            this.btnSelectVia.Name = "btnSelectVia";
            this.btnSelectVia.Size = new System.Drawing.Size(133, 23);
            this.btnSelectVia.TabIndex = 0;
            this.btnSelectVia.Text = "+Via Point (0) [ F2 ]";
            this.btnSelectVia.UseVisualStyleBackColor = false;
            this.btnSelectVia.Click += new System.EventHandler(this.btnSelectVia_Click);
            // 
            // ddlDropOffPlot
            // 
            this.ddlDropOffPlot.BackColor = System.Drawing.Color.White;
            this.ddlDropOffPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDropOffPlot.FormattingEnabled = true;
            this.ddlDropOffPlot.Location = new System.Drawing.Point(8, 152);
            this.ddlDropOffPlot.Name = "ddlDropOffPlot";
            this.ddlDropOffPlot.Size = new System.Drawing.Size(105, 24);
            this.ddlDropOffPlot.TabIndex = 0;
            // 
            // ddlPickupPlot
            // 
            this.ddlPickupPlot.BackColor = System.Drawing.Color.White;
            this.ddlPickupPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPickupPlot.FormattingEnabled = true;
            this.ddlPickupPlot.Location = new System.Drawing.Point(7, 88);
            this.ddlPickupPlot.Name = "ddlPickupPlot";
            this.ddlPickupPlot.Size = new System.Drawing.Size(106, 24);
            this.ddlPickupPlot.TabIndex = 0;
            // 
            // lblDropOffPlot
            // 
            this.lblDropOffPlot.AutoSize = true;
            this.lblDropOffPlot.BackColor = this.panel2.BackColor;
            this.lblDropOffPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropOffPlot.Location = new System.Drawing.Point(976, 270);
            this.lblDropOffPlot.Name = "lblDropOffPlot";
            this.lblDropOffPlot.Size = new System.Drawing.Size(87, 16);
            this.lblDropOffPlot.TabIndex = 261;
            this.lblDropOffPlot.Text = "Return From";
            this.lblDropOffPlot.Visible = false;
            // 
            // lblPickupPlot
            // 
            this.lblPickupPlot.AutoSize = true;
            this.lblPickupPlot.BackColor = this.panel2.BackColor;
            this.lblPickupPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickupPlot.Location = new System.Drawing.Point(795, 363);
            this.lblPickupPlot.Name = "lblPickupPlot";
            this.lblPickupPlot.Size = new System.Drawing.Size(71, 16);
            this.lblPickupPlot.TabIndex = 259;
            this.lblPickupPlot.Text = "Return To";
            this.lblPickupPlot.Visible = false;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.BackColor = System.Drawing.Color.AliceBlue;
            this.txtVehicleNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleNo.ForeColor = System.Drawing.Color.Black;
            this.txtVehicleNo.Location = new System.Drawing.Point(353, 193);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(2, 2);
            this.txtVehicleNo.TabIndex = 258;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCustomer.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlCustomer.Controls.Add(this.numTotalLuggages);
            this.pnlCustomer.Controls.Add(this.num_TotalPassengers);
            this.pnlCustomer.Controls.Add(this.ddlCompany);
            this.pnlCustomer.Controls.Add(this.ddlVehicleType);
            this.pnlCustomer.Controls.Add(this.radLabel2);
            this.pnlCustomer.Controls.Add(this.txtEmail);
            this.pnlCustomer.Controls.Add(this.radLabel6);
            this.pnlCustomer.Controls.Add(this.radLabel21);
            this.pnlCustomer.Controls.Add(this.radLabel19);
            this.pnlCustomer.Controls.Add(this.txtCustomerPhoneNo);
            this.pnlCustomer.Controls.Add(this.txtCustomerMobileNo);
            this.pnlCustomer.Controls.Add(this.ddlCustomerName);
            this.pnlCustomer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCustomer.Location = new System.Drawing.Point(5, 181);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(894, 288);
            this.pnlCustomer.TabIndex = 6;
            // 
            // numTotalLuggages
            // 
            this.numTotalLuggages.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalLuggages.InterceptArrowKeys = false;
            this.numTotalLuggages.Location = new System.Drawing.Point(275, 207);
            this.numTotalLuggages.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTotalLuggages.Name = "numTotalLuggages";
            this.numTotalLuggages.Size = new System.Drawing.Size(57, 26);
            this.numTotalLuggages.TabIndex = 0;
            this.numTotalLuggages.TabStop = false;
            // 
            // num_TotalPassengers
            // 
            this.num_TotalPassengers.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_TotalPassengers.InterceptArrowKeys = false;
            this.num_TotalPassengers.Location = new System.Drawing.Point(114, 207);
            this.num_TotalPassengers.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.num_TotalPassengers.Name = "num_TotalPassengers";
            this.num_TotalPassengers.Size = new System.Drawing.Size(67, 26);
            this.num_TotalPassengers.TabIndex = 0;
            this.num_TotalPassengers.TabStop = false;
            this.num_TotalPassengers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ddlCompany
            // 
            this.ddlCompany.FilterRule = null;
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.ddlCompany.Location = new System.Drawing.Point(486, 120);
            this.ddlCompany.Size = new System.Drawing.Size(406, 25);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.PropertySelector = null;
            this.ddlCompany.SuggestBoxHeight = 96;
            this.ddlCompany.SuggestListOrderRule = null;
            this.ddlCompany.TabIndex = 240;
            this.ddlCompany.TabStop = false;
            // 
            // ddlVehicleType
            // 
            this.ddlVehicleType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleType.FormattingEnabled = true;
            this.ddlVehicleType.Location = new System.Drawing.Point(112, 119);
            this.ddlVehicleType.Name = "ddlVehicleType";
            this.ddlVehicleType.Size = new System.Drawing.Size(120, 26);
            this.ddlVehicleType.TabIndex = 8;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.radLabel2.Location = new System.Drawing.Point(4, 93);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 21);
            this.radLabel2.TabIndex = 165;
            this.radLabel2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(112, 90);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 26);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.TabStop = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel6.Location = new System.Drawing.Point(0, 8);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(84, 22);
            this.radLabel6.TabIndex = 159;
            this.radLabel6.Text = " Name [K]";
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.radLabel21.Location = new System.Drawing.Point(4, 65);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(70, 21);
            this.radLabel21.TabIndex = 161;
            this.radLabel21.Text = "Mobile No";
            // 
            // radLabel19
            // 
            this.radLabel19.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.radLabel19.Location = new System.Drawing.Point(4, 36);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Size = new System.Drawing.Size(76, 21);
            this.radLabel19.TabIndex = 160;
            this.radLabel19.Text = "Tel. No";
            // 
            // txtCustomerPhoneNo
            // 
            this.txtCustomerPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPhoneNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerPhoneNo.Location = new System.Drawing.Point(112, 35);
            this.txtCustomerPhoneNo.MaxLength = 30;
            this.txtCustomerPhoneNo.Name = "txtCustomerPhoneNo";
            this.txtCustomerPhoneNo.Size = new System.Drawing.Size(285, 26);
            this.txtCustomerPhoneNo.TabIndex = 0;
            this.txtCustomerPhoneNo.TabStop = false;
            // 
            // txtCustomerMobileNo
            // 
            this.txtCustomerMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerMobileNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerMobileNo.Location = new System.Drawing.Point(112, 63);
            this.txtCustomerMobileNo.MaxLength = 30;
            this.txtCustomerMobileNo.Name = "txtCustomerMobileNo";
            this.txtCustomerMobileNo.Size = new System.Drawing.Size(285, 26);
            this.txtCustomerMobileNo.TabIndex = 0;
            this.txtCustomerMobileNo.TabStop = false;
            // 
            // ddlCustomerName
            // 
            this.ddlCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ddlCustomerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCustomerName.Location = new System.Drawing.Point(112, 6);
            this.ddlCustomerName.MaxLength = 100;
            this.ddlCustomerName.Name = "ddlCustomerName";
            this.ddlCustomerName.Size = new System.Drawing.Size(285, 26);
            this.ddlCustomerName.TabIndex = 6;
            this.ddlCustomerName.TabStop = false;
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.CustomFormat = "ddd dd/MM/yyyy";
            this.dtpPickupDate.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickupDate.Location = new System.Drawing.Point(229, 41);
            this.dtpPickupDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPickupDate.Size = new System.Drawing.Size(140, 23);
            this.dtpPickupDate.TabIndex = 5;
            this.dtpPickupDate.TabStop = false;
            this.dtpPickupDate.Value = null;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.Red;
            this.lblDate.Location = new System.Drawing.Point(181, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 18);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Dat&e";
            // 
            // dtpPickupTime
            // 
            this.dtpPickupTime.CustomFormat = "HH:mm";
            this.dtpPickupTime.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dtpPickupTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickupTime.Location = new System.Drawing.Point(117, 41);
            this.dtpPickupTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPickupTime.Name = "dtpPickupTime";
            this.dtpPickupTime.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPickupTime.ShowUpDown = true;
            this.dtpPickupTime.Size = new System.Drawing.Size(69, 23);
            this.dtpPickupTime.TabIndex = 4;
            this.dtpPickupTime.TabStop = false;
            this.dtpPickupTime.Text = "13:54";
            this.dtpPickupTime.Value = null;
            this.dtpPickupTime.Visible = false;
            // 
            // lblPickupTime
            // 
            this.lblPickupTime.BackColor = System.Drawing.Color.AliceBlue;
            this.lblPickupTime.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblPickupTime.ForeColor = System.Drawing.Color.Red;
            this.lblPickupTime.Location = new System.Drawing.Point(8, 44);
            this.lblPickupTime.Name = "lblPickupTime";
            this.lblPickupTime.Size = new System.Drawing.Size(104, 20);
            this.lblPickupTime.TabIndex = 247;
            this.lblPickupTime.Text = "Pickup &Time";
            this.lblPickupTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkQuotation
            // 
            this.chkQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.chkQuotation.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.chkQuotation.ForeColor = System.Drawing.Color.Fuchsia;
            this.chkQuotation.Location = new System.Drawing.Point(755, 43);
            this.chkQuotation.Name = "chkQuotation";
            this.chkQuotation.Size = new System.Drawing.Size(142, 22);
            this.chkQuotation.TabIndex = 206;
            this.chkQuotation.Text = "Quotation (F6)";
            this.chkQuotation.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel4.Controls.Add(this.ddlRoute);
            this.panel4.Controls.Add(this.lblRoute);
            this.panel4.Controls.Add(this.btnNearestDrv);
            this.panel4.Controls.Add(this.btnDespatchView);
            this.panel4.Controls.Add(this.btnPasteBooking);
            this.panel4.Controls.Add(this.btnSendEmail);
            this.panel4.Controls.Add(this.btnAccountCode);
            this.panel4.Controls.Add(this.btnMultiBooking);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.btnBase);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(903, 37);
            this.panel4.TabIndex = 0;
            // 
            // ddlRoute
            // 
            this.ddlRoute.BackColor = System.Drawing.Color.FloralWhite;
            this.ddlRoute.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ddlRoute.Items.AddRange(new object[] {
            "Shortest",
            "Fastest"});
            this.ddlRoute.Location = new System.Drawing.Point(679, 5);
            this.ddlRoute.Name = "ddlRoute";
            this.ddlRoute.Size = new System.Drawing.Size(100, 26);
            this.ddlRoute.TabIndex = 283;
            this.ddlRoute.Text = "Shortest";
            this.ddlRoute.Visible = false;
            // 
            // lblRoute
            // 
            this.lblRoute.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblRoute.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoute.ForeColor = System.Drawing.Color.White;
            this.lblRoute.Location = new System.Drawing.Point(617, 8);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(57, 22);
            this.lblRoute.TabIndex = 284;
            this.lblRoute.Text = "Route";
            this.lblRoute.Visible = false;
            // 
            // btnNearestDrv
            // 
            this.btnNearestDrv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnNearestDrv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnNearestDrv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnNearestDrv.Location = new System.Drawing.Point(789, -1);
            this.btnNearestDrv.Name = "btnNearestDrv";
            this.btnNearestDrv.Size = new System.Drawing.Size(113, 38);
            this.btnNearestDrv.TabIndex = 278;
            this.btnNearestDrv.Text = "Nearest Drivers (F12)";
            this.btnNearestDrv.UseVisualStyleBackColor = false;
            this.btnNearestDrv.Click += new System.EventHandler(this.btnNearestDrv_Click);
            // 
            // btnDespatchView
            // 
            this.btnDespatchView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnDespatchView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDespatchView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnDespatchView.Location = new System.Drawing.Point(642, -1);
            this.btnDespatchView.Name = "btnDespatchView";
            this.btnDespatchView.Size = new System.Drawing.Size(127, 38);
            this.btnDespatchView.TabIndex = 277;
            this.btnDespatchView.Text = "Route Suggestion";
            this.btnDespatchView.UseVisualStyleBackColor = false;
            this.btnDespatchView.Click += new System.EventHandler(this.btnDespatchView_Click);
            // 
            // btnPasteBooking
            // 
            this.btnPasteBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPasteBooking.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnPasteBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnPasteBooking.Location = new System.Drawing.Point(493, -1);
            this.btnPasteBooking.Name = "btnPasteBooking";
            this.btnPasteBooking.Size = new System.Drawing.Size(105, 38);
            this.btnPasteBooking.TabIndex = 275;
            this.btnPasteBooking.Text = "Paste Booking";
            this.btnPasteBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPasteBooking.UseVisualStyleBackColor = false;
            this.btnPasteBooking.Click += new System.EventHandler(this.btnPasteBooking_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnSendEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSendEmail.Location = new System.Drawing.Point(394, -1);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(90, 38);
            this.btnSendEmail.TabIndex = 212;
            this.btnSendEmail.Text = "Send Email     (F11)";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnAccountCode
            // 
            this.btnAccountCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnAccountCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAccountCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnAccountCode.Location = new System.Drawing.Point(289, -1);
            this.btnAccountCode.Name = "btnAccountCode";
            this.btnAccountCode.Size = new System.Drawing.Size(98, 38);
            this.btnAccountCode.TabIndex = 211;
            this.btnAccountCode.Text = "Account Code (F10)";
            this.btnAccountCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountCode.UseVisualStyleBackColor = false;
            this.btnAccountCode.Click += new System.EventHandler(this.btnAccountCode_Click);
            // 
            // btnMultiBooking
            // 
            this.btnMultiBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnMultiBooking.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnMultiBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnMultiBooking.Location = new System.Drawing.Point(189, -1);
            this.btnMultiBooking.Name = "btnMultiBooking";
            this.btnMultiBooking.Size = new System.Drawing.Size(98, 38);
            this.btnMultiBooking.TabIndex = 3;
            this.btnMultiBooking.Text = "Multi Booking (F8)";
            this.btnMultiBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMultiBooking.UseVisualStyleBackColor = false;
            this.btnMultiBooking.Click += new System.EventHandler(this.btnMultiBooking_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSearch.Location = new System.Drawing.Point(93, -1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 38);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Job History (F7)";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBase
            // 
            this.btnBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnBase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnBase.Location = new System.Drawing.Point(5, -2);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(82, 38);
            this.btnBase.TabIndex = 1;
            this.btnBase.Text = "     Base    (F1)";
            this.btnBase.UseVisualStyleBackColor = false;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.BackColor = System.Drawing.Color.White;
            this.txtFromAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFromAddress.DefaultHeight = 0;
            this.txtFromAddress.DefaultWidth = 0;
            this.txtFromAddress.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtFromAddress.ForceListBoxToUpdate = false;
            this.txtFromAddress.FormerValue = "";
            this.txtFromAddress.Location = new System.Drawing.Point(117, 72);
            this.txtFromAddress.Multiline = true;
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.SelectedItem = null;
            this.txtFromAddress.Size = new System.Drawing.Size(465, 40);
            this.txtFromAddress.TabIndex = 1;
            this.txtFromAddress.TabStop = false;
            this.txtFromAddress.Values = null;
            this.txtFromAddress.Enter += new System.EventHandler(this.txtFromAddress_Enter);
            this.txtFromAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFromAddress_KeyDown);
            this.txtFromAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromAddress_KeyPress);
            // 
            // txtFromPostCode
            // 
            this.txtFromPostCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFromPostCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFromPostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFromPostCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromPostCode.Location = new System.Drawing.Point(955, 40);
            this.txtFromPostCode.MaxLength = 100;
            this.txtFromPostCode.Name = "txtFromPostCode";
            this.txtFromPostCode.Size = new System.Drawing.Size(206, 26);
            this.txtFromPostCode.TabIndex = 1;
            this.txtFromPostCode.TabStop = false;
            this.txtFromPostCode.Visible = false;
            // 
            // txtFromStreetComing
            // 
            this.txtFromStreetComing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromStreetComing.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFromStreetComing.Location = new System.Drawing.Point(681, 95);
            this.txtFromStreetComing.MaxLength = 100;
            this.txtFromStreetComing.Name = "txtFromStreetComing";
            this.txtFromStreetComing.Size = new System.Drawing.Size(197, 24);
            this.txtFromStreetComing.TabIndex = 300;
            this.txtFromStreetComing.TabStop = false;
            // 
            // txtFromFlightDoorNo
            // 
            this.txtFromFlightDoorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromFlightDoorNo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFromFlightDoorNo.Location = new System.Drawing.Point(681, 70);
            this.txtFromFlightDoorNo.MaxLength = 100;
            this.txtFromFlightDoorNo.Name = "txtFromFlightDoorNo";
            this.txtFromFlightDoorNo.Size = new System.Drawing.Size(197, 24);
            this.txtFromFlightDoorNo.TabIndex = 2;
            this.txtFromFlightDoorNo.TabStop = false;
            // 
            // lblFromStreetComing
            // 
            this.lblFromStreetComing.BackColor = this.panel2.BackColor;
            this.lblFromStreetComing.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFromStreetComing.Location = new System.Drawing.Point(602, 97);
            this.lblFromStreetComing.Name = "lblFromStreetComing";
            this.lblFromStreetComing.Size = new System.Drawing.Size(80, 22);
            this.lblFromStreetComing.TabIndex = 182;
            this.lblFromStreetComing.Text = "From Street";
            this.lblFromStreetComing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFromDoorFlightNo
            // 
            this.lblFromDoorFlightNo.BackColor = this.panel2.BackColor;
            this.lblFromDoorFlightNo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFromDoorFlightNo.Location = new System.Drawing.Point(602, 71);
            this.lblFromDoorFlightNo.Name = "lblFromDoorFlightNo";
            this.lblFromDoorFlightNo.Size = new System.Drawing.Size(73, 22);
            this.lblFromDoorFlightNo.TabIndex = 180;
            this.lblFromDoorFlightNo.Text = "Door #";
            this.lblFromDoorFlightNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtToAddress
            // 
            this.txtToAddress.BackColor = System.Drawing.Color.White;
            this.txtToAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToAddress.DefaultHeight = 0;
            this.txtToAddress.DefaultWidth = 0;
            this.txtToAddress.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtToAddress.ForceListBoxToUpdate = false;
            this.txtToAddress.FormerValue = "";
            this.txtToAddress.Location = new System.Drawing.Point(117, 138);
            this.txtToAddress.Multiline = true;
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.SelectedItem = null;
            this.txtToAddress.Size = new System.Drawing.Size(465, 40);
            this.txtToAddress.TabIndex = 3;
            this.txtToAddress.TabStop = false;
            this.txtToAddress.Values = null;
            this.txtToAddress.Enter += new System.EventHandler(this.txtToAddress_Enter);
            this.txtToAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtToAddress_KeyDown);
            this.txtToAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromAddress_KeyPress);
            // 
            // lblFromLoc
            // 
            this.lblFromLoc.BackColor = this.panel2.BackColor;
            this.lblFromLoc.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFromLoc.Location = new System.Drawing.Point(7, 69);
            this.lblFromLoc.Name = "lblFromLoc";
            this.lblFromLoc.Size = new System.Drawing.Size(108, 21);
            this.lblFromLoc.TabIndex = 130;
            this.lblFromLoc.Text = "From Location";
            // 
            // ddlFromLocType
            // 
            this.ddlFromLocType.BackColor = System.Drawing.Color.White;
            this.ddlFromLocType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFromLocType.Location = new System.Drawing.Point(988, 155);
            this.ddlFromLocType.Name = "ddlFromLocType";
            this.ddlFromLocType.Size = new System.Drawing.Size(36, 24);
            this.ddlFromLocType.TabIndex = 500;
            this.ddlFromLocType.TabStop = false;
            this.ddlFromLocType.Visible = false;
            this.ddlFromLocType.SelectedIndexChanged += new System.EventHandler(this.ddlFromLocType_SelectedIndexChanged);
            // 
            // ddlToLocType
            // 
            this.ddlToLocType.BackColor = System.Drawing.Color.White;
            this.ddlToLocType.Location = new System.Drawing.Point(948, 153);
            this.ddlToLocType.Name = "ddlToLocType";
            this.ddlToLocType.Size = new System.Drawing.Size(24, 26);
            this.ddlToLocType.TabIndex = 501;
            this.ddlToLocType.TabStop = false;
            this.ddlToLocType.Visible = false;
            this.ddlToLocType.SelectedIndexChanged += new System.EventHandler(this.ddlToLocType_SelectedIndexChanged);
            // 
            // lblToLoc
            // 
            this.lblToLoc.BackColor = this.panel2.BackColor;
            this.lblToLoc.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblToLoc.Location = new System.Drawing.Point(7, 131);
            this.lblToLoc.Name = "lblToLoc";
            this.lblToLoc.Size = new System.Drawing.Size(98, 21);
            this.lblToLoc.TabIndex = 134;
            this.lblToLoc.Text = "To Location";
            // 
            // txtToStreetComing
            // 
            this.txtToStreetComing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToStreetComing.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtToStreetComing.Location = new System.Drawing.Point(681, 153);
            this.txtToStreetComing.MaxLength = 100;
            this.txtToStreetComing.Name = "txtToStreetComing";
            this.txtToStreetComing.Size = new System.Drawing.Size(197, 24);
            this.txtToStreetComing.TabIndex = 301;
            this.txtToStreetComing.TabStop = false;
            // 
            // txtToPostCode
            // 
            this.txtToPostCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtToPostCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtToPostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToPostCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToPostCode.Location = new System.Drawing.Point(841, 44);
            this.txtToPostCode.MaxLength = 100;
            this.txtToPostCode.Name = "txtToPostCode";
            this.txtToPostCode.Size = new System.Drawing.Size(206, 26);
            this.txtToPostCode.TabIndex = 4;
            this.txtToPostCode.TabStop = false;
            this.txtToPostCode.Visible = false;
            // 
            // lblToStreetComing
            // 
            this.lblToStreetComing.BackColor = this.panel2.BackColor;
            this.lblToStreetComing.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblToStreetComing.Location = new System.Drawing.Point(602, 158);
            this.lblToStreetComing.Name = "lblToStreetComing";
            this.lblToStreetComing.Size = new System.Drawing.Size(78, 22);
            this.lblToStreetComing.TabIndex = 187;
            this.lblToStreetComing.Text = "To Street";
            this.lblToStreetComing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtToFlightDoorNo
            // 
            this.txtToFlightDoorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToFlightDoorNo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtToFlightDoorNo.Location = new System.Drawing.Point(681, 129);
            this.txtToFlightDoorNo.MaxLength = 100;
            this.txtToFlightDoorNo.Name = "txtToFlightDoorNo";
            this.txtToFlightDoorNo.Size = new System.Drawing.Size(197, 24);
            this.txtToFlightDoorNo.TabIndex = 4;
            this.txtToFlightDoorNo.TabStop = false;
            // 
            // lblToDoorFlightNo
            // 
            this.lblToDoorFlightNo.BackColor = this.panel2.BackColor;
            this.lblToDoorFlightNo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblToDoorFlightNo.Location = new System.Drawing.Point(603, 134);
            this.lblToDoorFlightNo.Name = "lblToDoorFlightNo";
            this.lblToDoorFlightNo.Size = new System.Drawing.Size(72, 22);
            this.lblToDoorFlightNo.TabIndex = 186;
            this.lblToDoorFlightNo.Text = "Door #";
            this.lblToDoorFlightNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.Lavender;
            this.radPanel3.Controls.Add(this.btnSetFares);
            this.radPanel3.Controls.Add(this.txtPromotion);
            this.radPanel3.Controls.Add(this.txtFaresPostedFrom);
            this.radPanel3.Controls.Add(this.btnJobInformation);
            this.radPanel3.Controls.Add(this.btnCancelBooking);
            this.radPanel3.Controls.Add(this.btnExitForm);
            this.radPanel3.Controls.Add(this.btnSaveNew);
            this.radPanel3.Controls.Add(this.radPanel1);
            this.radPanel3.Controls.Add(this.chkQuotedPrice);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel3.Location = new System.Drawing.Point(0, 482);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1284, 279);
            this.radPanel3.TabIndex = 234;
            // 
            // btnSetFares
            // 
            this.btnSetFares.BackColor = System.Drawing.Color.Coral;
            this.btnSetFares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetFares.ForeColor = System.Drawing.Color.Red;
            this.btnSetFares.Location = new System.Drawing.Point(435, 2);
            this.btnSetFares.Name = "btnSetFares";
            this.btnSetFares.Size = new System.Drawing.Size(84, 24);
            this.btnSetFares.TabIndex = 251;
            this.btnSetFares.Text = "Set Fares";
            this.btnSetFares.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSetFares.GetChildAt(0))).Text = "Set Fares";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.AliceBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.AliceBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.AliceBlue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.AliceBlue;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BackColor = System.Drawing.SystemColors.Info;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSetFares.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPromotion
            // 
            this.txtPromotion.BackColor = System.Drawing.Color.Lavender;
            this.txtPromotion.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txtPromotion.ForeColor = System.Drawing.Color.Red;
            this.txtPromotion.Location = new System.Drawing.Point(151, 1);
            this.txtPromotion.Name = "txtPromotion";
            this.txtPromotion.Size = new System.Drawing.Size(798, 18);
            this.txtPromotion.TabIndex = 252;
            // 
            // txtFaresPostedFrom
            // 
            this.txtFaresPostedFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.txtFaresPostedFrom.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaresPostedFrom.ForeColor = System.Drawing.Color.Red;
            this.txtFaresPostedFrom.Location = new System.Drawing.Point(80, 1);
            this.txtFaresPostedFrom.Name = "txtFaresPostedFrom";
            this.txtFaresPostedFrom.Size = new System.Drawing.Size(76, 18);
            this.txtFaresPostedFrom.TabIndex = 243;
            this.txtFaresPostedFrom.Text = "Meter  ";
            this.txtFaresPostedFrom.Visible = false;
            // 
            // btnJobInformation
            // 
            this.btnJobInformation.BackColor = System.Drawing.Color.AliceBlue;
            this.btnJobInformation.Enabled = false;
            this.btnJobInformation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnJobInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnJobInformation.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnJobInformation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJobInformation.Location = new System.Drawing.Point(874, 195);
            this.btnJobInformation.Name = "btnJobInformation";
            this.btnJobInformation.Size = new System.Drawing.Size(112, 65);
            this.btnJobInformation.TabIndex = 201;
            this.btnJobInformation.Text = "Job Information";
            this.btnJobInformation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJobInformation.UseVisualStyleBackColor = false;
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCancelBooking.Enabled = false;
            this.btnCancelBooking.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnCancelBooking.Image = global::Taxi_AppMain.Properties.Resources.remove;
            this.btnCancelBooking.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelBooking.Location = new System.Drawing.Point(1002, 195);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(112, 65);
            this.btnCancelBooking.TabIndex = 199;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            // 
            // btnExitForm
            // 
            this.btnExitForm.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExitForm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnExitForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnExitForm.Image = global::Taxi_AppMain.Resources.Resource1.exit;
            this.btnExitForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExitForm.Location = new System.Drawing.Point(1132, 195);
            this.btnExitForm.Name = "btnExitForm";
            this.btnExitForm.Size = new System.Drawing.Size(117, 65);
            this.btnExitForm.TabIndex = 200;
            this.btnExitForm.TabStop = false;
            this.btnExitForm.Text = "Exit";
            this.btnExitForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExitForm.UseVisualStyleBackColor = false;
            this.btnExitForm.MouseLeave += new System.EventHandler(this.btnSaveNew_MouseLeave);
            this.btnExitForm.MouseHover += new System.EventHandler(this.btnSaveNew_MouseHover);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSaveNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSaveNew.Image = global::Taxi_AppMain.Resources.Resource1.save_Tick;
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveNew.Location = new System.Drawing.Point(717, 196);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(136, 64);
            this.btnSaveNew.TabIndex = 25;
            this.btnSaveNew.Text = "Save Booking    (CTRL+S)";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveNew.UseVisualStyleBackColor = false;
            this.btnSaveNew.MouseLeave += new System.EventHandler(this.btnSaveNew_MouseLeave);
            this.btnSaveNew.MouseHover += new System.EventHandler(this.btnSaveNew_MouseHover);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Lavender;
            this.radPanel1.Controls.Add(this.btnregisterlink);
            this.radPanel1.Controls.Add(this.btnsendpaymentlink);
            this.radPanel1.Controls.Add(this.lblCardIsRegisteredKP);
            this.radPanel1.Controls.Add(this.chkMiles);
            this.radPanel1.Controls.Add(this.numMiles);
            this.radPanel1.Controls.Add(this.pnlOtherCharges);
            this.radPanel1.Controls.Add(this.btnPickFares);
            this.radPanel1.Controls.Add(this.pnlPayment1);
            this.radPanel1.Controls.Add(this.btnViewMapReport);
            this.radPanel1.Controls.Add(this.radLabel27);
            this.radPanel1.Controls.Add(this.txtSpecialRequirements);
            this.radPanel1.Controls.Add(this.btnTrackDriver);
            this.radPanel1.Controls.Add(this.pnlBookingFees);
            this.radPanel1.Controls.Add(this.chkPermanentCustNotes);
            this.radPanel1.Controls.Add(this.txtPaymentReference);
            this.radPanel1.Controls.Add(this.btnDetailMap);
            this.radPanel1.Controls.Add(this.radLabel25);
            this.radPanel1.Controls.Add(this.lblPaymentRef);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.lblMap);
            this.radPanel1.Controls.Add(this.pnlFares);
            this.radPanel1.Location = new System.Drawing.Point(5, 20);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1276, 241);
            this.radPanel1.TabIndex = 2;
            // 
            // btnregisterlink
            // 
            this.btnregisterlink.BackColor = System.Drawing.Color.Blue;
            this.btnregisterlink.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregisterlink.ForeColor = System.Drawing.Color.White;
            this.btnregisterlink.Location = new System.Drawing.Point(558, 132);
            this.btnregisterlink.Name = "btnregisterlink";
            this.btnregisterlink.Size = new System.Drawing.Size(150, 30);
            this.btnregisterlink.TabIndex = 534;
            this.btnregisterlink.Text = "CARD REGISTER LINK";
            this.btnregisterlink.UseVisualStyleBackColor = false;
            this.btnregisterlink.Visible = false;
            // 
            // btnsendpaymentlink
            // 
            this.btnsendpaymentlink.BackColor = System.Drawing.Color.Blue;
            this.btnsendpaymentlink.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsendpaymentlink.ForeColor = System.Drawing.Color.White;
            this.btnsendpaymentlink.Location = new System.Drawing.Point(433, 132);
            this.btnsendpaymentlink.Name = "btnsendpaymentlink";
            this.btnsendpaymentlink.Size = new System.Drawing.Size(116, 30);
            this.btnsendpaymentlink.TabIndex = 533;
            this.btnsendpaymentlink.Text = "PAYMENT LINK";
            this.btnsendpaymentlink.UseVisualStyleBackColor = false;
            this.btnsendpaymentlink.Visible = false;
            // 
            // lblCardIsRegisteredKP
            // 
            this.lblCardIsRegisteredKP.BackColor = System.Drawing.Color.Transparent;
            this.lblCardIsRegisteredKP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardIsRegisteredKP.ForeColor = System.Drawing.Color.Black;
            this.lblCardIsRegisteredKP.Location = new System.Drawing.Point(401, 165);
            this.lblCardIsRegisteredKP.Name = "lblCardIsRegisteredKP";
            this.lblCardIsRegisteredKP.Size = new System.Drawing.Size(267, 67);
            this.lblCardIsRegisteredKP.TabIndex = 512;
            // 
            // chkMiles
            // 
            this.chkMiles.AutoSize = true;
            this.chkMiles.BackColor = System.Drawing.Color.Lavender;
            this.chkMiles.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMiles.ForeColor = System.Drawing.Color.Blue;
            this.chkMiles.Location = new System.Drawing.Point(277, 102);
            this.chkMiles.Name = "chkMiles";
            this.chkMiles.Size = new System.Drawing.Size(67, 22);
            this.chkMiles.TabIndex = 509;
            this.chkMiles.Text = "Miles";
            this.chkMiles.UseVisualStyleBackColor = false;
            this.chkMiles.Visible = false;
            this.chkMiles.CheckedChanged += new System.EventHandler(this.chkMiles_CheckedChanged);
            // 
            // numMiles
            // 
            this.numMiles.BackColor = System.Drawing.Color.FloralWhite;
            this.numMiles.DecimalPlaces = 1;
            this.numMiles.Enabled = false;
            this.numMiles.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMiles.ForeColor = System.Drawing.Color.Red;
            this.numMiles.InterceptArrowKeys = false;
            this.numMiles.Location = new System.Drawing.Point(345, 100);
            this.numMiles.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMiles.Name = "numMiles";
            this.numMiles.Size = new System.Drawing.Size(72, 26);
            this.numMiles.TabIndex = 508;
            this.numMiles.TabStop = false;
            this.numMiles.Visible = false;
            // 
            // pnlOtherCharges
            // 
            this.pnlOtherCharges.BackColor = System.Drawing.Color.Lavender;
            this.pnlOtherCharges.Controls.Add(this.label17);
            this.pnlOtherCharges.Controls.Add(this.btnExtrAcHARGES);
            this.pnlOtherCharges.Controls.Add(this.numTipAmount);
            this.pnlOtherCharges.Controls.Add(this.radLabel4);
            this.pnlOtherCharges.Controls.Add(this.numDrvWaitingMins);
            this.pnlOtherCharges.Controls.Add(this.lblTotalCharges);
            this.pnlOtherCharges.Controls.Add(this.numTotalChrgs);
            this.pnlOtherCharges.Controls.Add(this.radLabel20);
            this.pnlOtherCharges.Controls.Add(this.numCongChrgs);
            this.pnlOtherCharges.Controls.Add(this.radLabel16);
            this.pnlOtherCharges.Controls.Add(this.numMeetCharges);
            this.pnlOtherCharges.Controls.Add(this.radLabel17);
            this.pnlOtherCharges.Controls.Add(this.numExtraChrgs);
            this.pnlOtherCharges.Controls.Add(this.lblAccWaitingCharges);
            this.pnlOtherCharges.Controls.Add(this.numWaitingChrgs);
            this.pnlOtherCharges.Controls.Add(this.lblAccParkingCharges);
            this.pnlOtherCharges.Controls.Add(this.numParkingChrgs);
            this.pnlOtherCharges.Location = new System.Drawing.Point(714, 3);
            this.pnlOtherCharges.Name = "pnlOtherCharges";
            this.pnlOtherCharges.Size = new System.Drawing.Size(562, 85);
            this.pnlOtherCharges.TabIndex = 0;
            this.pnlOtherCharges.TabStop = true;
            // 
            // label17
            // 
            this.label17.BackColor = this.pnlOtherCharges.BackColor;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(232, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 20);
            this.label17.TabIndex = 509;
            this.label17.Text = "Tip";
            // 
            // btnExtrAcHARGES
            // 
            this.btnExtrAcHARGES.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExtrAcHARGES.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnExtrAcHARGES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnExtrAcHARGES.Location = new System.Drawing.Point(236, 54);
            this.btnExtrAcHARGES.Name = "btnExtrAcHARGES";
            this.btnExtrAcHARGES.Size = new System.Drawing.Size(119, 30);
            this.btnExtrAcHARGES.TabIndex = 508;
            this.btnExtrAcHARGES.Text = "Extra C&harges";
            this.btnExtrAcHARGES.UseVisualStyleBackColor = false;
            this.btnExtrAcHARGES.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numTipAmount
            // 
            this.numTipAmount.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numTipAmount.InterceptArrowKeys = false;
            this.numTipAmount.Location = new System.Drawing.Point(276, 2);
            this.numTipAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTipAmount.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numTipAmount.Name = "numTipAmount";
            this.numTipAmount.Size = new System.Drawing.Size(48, 24);
            this.numTipAmount.TabIndex = 0;
            this.numTipAmount.TabStop = false;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = this.pnlOtherCharges.BackColor;
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel4.ForeColor = System.Drawing.Color.Black;
            this.radLabel4.Location = new System.Drawing.Point(233, 32);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(39, 20);
            this.radLabel4.TabIndex = 153;
            this.radLabel4.Text = "W/T";
            // 
            // numDrvWaitingMins
            // 
            this.numDrvWaitingMins.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numDrvWaitingMins.InterceptArrowKeys = false;
            this.numDrvWaitingMins.Location = new System.Drawing.Point(277, 29);
            this.numDrvWaitingMins.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numDrvWaitingMins.Name = "numDrvWaitingMins";
            this.numDrvWaitingMins.Size = new System.Drawing.Size(48, 24);
            this.numDrvWaitingMins.TabIndex = 0;
            this.numDrvWaitingMins.TabStop = false;
            // 
            // lblTotalCharges
            // 
            this.lblTotalCharges.BackColor = this.pnlOtherCharges.BackColor;
            this.lblTotalCharges.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCharges.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCharges.Location = new System.Drawing.Point(379, 61);
            this.lblTotalCharges.Name = "lblTotalCharges";
            this.lblTotalCharges.Size = new System.Drawing.Size(118, 20);
            this.lblTotalCharges.TabIndex = 150;
            this.lblTotalCharges.Text = "Total Charges £";
            // 
            // numTotalChrgs
            // 
            this.numTotalChrgs.BackColor = System.Drawing.SystemColors.Control;
            this.numTotalChrgs.DecimalPlaces = 2;
            this.numTotalChrgs.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numTotalChrgs.ForeColor = System.Drawing.Color.Red;
            this.numTotalChrgs.Location = new System.Drawing.Point(500, 59);
            this.numTotalChrgs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTotalChrgs.Name = "numTotalChrgs";
            this.numTotalChrgs.ReadOnly = true;
            this.numTotalChrgs.Size = new System.Drawing.Size(61, 24);
            this.numTotalChrgs.TabIndex = 0;
            this.numTotalChrgs.TabStop = false;
            // 
            // radLabel20
            // 
            this.radLabel20.BackColor = this.pnlOtherCharges.BackColor;
            this.radLabel20.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel20.ForeColor = System.Drawing.Color.Black;
            this.radLabel20.Location = new System.Drawing.Point(1, 33);
            this.radLabel20.Name = "radLabel20";
            this.radLabel20.Size = new System.Drawing.Size(165, 20);
            this.radLabel20.TabIndex = 148;
            this.radLabel20.Text = "Drv Parking Charges £ ";
            // 
            // numCongChrgs
            // 
            this.numCongChrgs.DecimalPlaces = 2;
            this.numCongChrgs.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numCongChrgs.ForeColor = System.Drawing.Color.Red;
            this.numCongChrgs.InterceptArrowKeys = false;
            this.numCongChrgs.Location = new System.Drawing.Point(170, 32);
            this.numCongChrgs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCongChrgs.Name = "numCongChrgs";
            this.numCongChrgs.Size = new System.Drawing.Size(59, 24);
            this.numCongChrgs.TabIndex = 0;
            this.numCongChrgs.TabStop = false;
            // 
            // radLabel16
            // 
            this.radLabel16.BackColor = this.pnlOtherCharges.BackColor;
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel16.ForeColor = System.Drawing.Color.Black;
            this.radLabel16.Location = new System.Drawing.Point(331, 33);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(166, 20);
            this.radLabel16.TabIndex = 146;
            this.radLabel16.Text = "Drv Waiting Charges  £";
            // 
            // numMeetCharges
            // 
            this.numMeetCharges.DecimalPlaces = 2;
            this.numMeetCharges.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numMeetCharges.ForeColor = System.Drawing.Color.Red;
            this.numMeetCharges.InterceptArrowKeys = false;
            this.numMeetCharges.Location = new System.Drawing.Point(500, 32);
            this.numMeetCharges.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMeetCharges.Name = "numMeetCharges";
            this.numMeetCharges.Size = new System.Drawing.Size(61, 24);
            this.numMeetCharges.TabIndex = 0;
            this.numMeetCharges.TabStop = false;
            // 
            // radLabel17
            // 
            this.radLabel17.AutoSize = true;
            this.radLabel17.BackColor = this.pnlOtherCharges.BackColor;
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel17.ForeColor = System.Drawing.Color.Black;
            this.radLabel17.Location = new System.Drawing.Point(43, 61);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(119, 17);
            this.radLabel17.TabIndex = 144;
            this.radLabel17.Text = "Extra Charges £";
            // 
            // numExtraChrgs
            // 
            this.numExtraChrgs.DecimalPlaces = 2;
            this.numExtraChrgs.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numExtraChrgs.ForeColor = System.Drawing.Color.Red;
            this.numExtraChrgs.InterceptArrowKeys = false;
            this.numExtraChrgs.Location = new System.Drawing.Point(170, 59);
            this.numExtraChrgs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numExtraChrgs.Name = "numExtraChrgs";
            this.numExtraChrgs.Size = new System.Drawing.Size(60, 24);
            this.numExtraChrgs.TabIndex = 0;
            this.numExtraChrgs.TabStop = false;
            // 
            // lblAccWaitingCharges
            // 
            this.lblAccWaitingCharges.BackColor = this.pnlOtherCharges.BackColor;
            this.lblAccWaitingCharges.Enabled = false;
            this.lblAccWaitingCharges.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccWaitingCharges.ForeColor = System.Drawing.Color.Black;
            this.lblAccWaitingCharges.Location = new System.Drawing.Point(333, 7);
            this.lblAccWaitingCharges.Name = "lblAccWaitingCharges";
            this.lblAccWaitingCharges.Size = new System.Drawing.Size(164, 20);
            this.lblAccWaitingCharges.TabIndex = 142;
            this.lblAccWaitingCharges.Text = "A/C Waiting Charges £";
            // 
            // numWaitingChrgs
            // 
            this.numWaitingChrgs.DecimalPlaces = 2;
            this.numWaitingChrgs.Enabled = false;
            this.numWaitingChrgs.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numWaitingChrgs.ForeColor = System.Drawing.Color.Red;
            this.numWaitingChrgs.InterceptArrowKeys = false;
            this.numWaitingChrgs.Location = new System.Drawing.Point(500, 5);
            this.numWaitingChrgs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numWaitingChrgs.Name = "numWaitingChrgs";
            this.numWaitingChrgs.Size = new System.Drawing.Size(61, 24);
            this.numWaitingChrgs.TabIndex = 0;
            this.numWaitingChrgs.TabStop = false;
            // 
            // lblAccParkingCharges
            // 
            this.lblAccParkingCharges.BackColor = this.pnlOtherCharges.BackColor;
            this.lblAccParkingCharges.Enabled = false;
            this.lblAccParkingCharges.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccParkingCharges.ForeColor = System.Drawing.Color.Black;
            this.lblAccParkingCharges.Location = new System.Drawing.Point(2, 6);
            this.lblAccParkingCharges.Name = "lblAccParkingCharges";
            this.lblAccParkingCharges.Size = new System.Drawing.Size(163, 20);
            this.lblAccParkingCharges.TabIndex = 140;
            this.lblAccParkingCharges.Text = "A/C Parking Charges £";
            // 
            // numParkingChrgs
            // 
            this.numParkingChrgs.DecimalPlaces = 2;
            this.numParkingChrgs.Enabled = false;
            this.numParkingChrgs.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.numParkingChrgs.ForeColor = System.Drawing.Color.Red;
            this.numParkingChrgs.InterceptArrowKeys = false;
            this.numParkingChrgs.Location = new System.Drawing.Point(170, 5);
            this.numParkingChrgs.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numParkingChrgs.Name = "numParkingChrgs";
            this.numParkingChrgs.Size = new System.Drawing.Size(59, 24);
            this.numParkingChrgs.TabIndex = 0;
            this.numParkingChrgs.TabStop = false;
            // 
            // btnPickFares
            // 
            this.btnPickFares.BackColor = System.Drawing.Color.FloralWhite;
            this.btnPickFares.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPickFares.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnPickFares.Location = new System.Drawing.Point(558, 40);
            this.btnPickFares.Name = "btnPickFares";
            this.btnPickFares.Size = new System.Drawing.Size(123, 50);
            this.btnPickFares.TabIndex = 0;
            this.btnPickFares.Text = "Calculate Fares (F4)";
            this.btnPickFares.UseVisualStyleBackColor = false;
            // 
            // pnlPayment1
            // 
            this.pnlPayment1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPayment1.BackColor = System.Drawing.Color.Lavender;
            this.pnlPayment1.Controls.Add(this.pic_card);
            this.pnlPayment1.Controls.Add(this.btnRefundKP);
            this.pnlPayment1.Controls.Add(this.btnPayment);
            this.pnlPayment1.Controls.Add(this.radLabel7);
            this.pnlPayment1.Controls.Add(this.ddlPaymentType);
            this.pnlPayment1.Location = new System.Drawing.Point(7, 125);
            this.pnlPayment1.Name = "pnlPayment1";
            this.pnlPayment1.Size = new System.Drawing.Size(430, 33);
            this.pnlPayment1.TabIndex = 506;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlPayment1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // pic_card
            // 
            this.pic_card.BackColor = System.Drawing.Color.Lavender;
            this.pic_card.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pic_card.ForeColor = System.Drawing.Color.Maroon;
            this.pic_card.Location = new System.Drawing.Point(388, 9);
            this.pic_card.Name = "pic_card";
            this.pic_card.Size = new System.Drawing.Size(26, 20);
            this.pic_card.TabIndex = 512;
            this.pic_card.Visible = false;
            // 
            // btnRefundKP
            // 
            this.btnRefundKP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnRefundKP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefundKP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnRefundKP.Location = new System.Drawing.Point(273, 4);
            this.btnRefundKP.Name = "btnRefundKP";
            this.btnRefundKP.Size = new System.Drawing.Size(105, 30);
            this.btnRefundKP.TabIndex = 511;
            this.btnRefundKP.Text = "Refund";
            this.btnRefundKP.UseVisualStyleBackColor = false;
            this.btnRefundKP.Visible = false;
            this.btnRefundKP.Click += new System.EventHandler(this.btnRefundKP_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnPayment.Location = new System.Drawing.Point(267, 4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(105, 30);
            this.btnPayment.TabIndex = 0;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Visible = false;
            // 
            // radLabel7
            // 
            this.radLabel7.BackColor = System.Drawing.Color.Transparent;
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel7.ForeColor = System.Drawing.Color.Black;
            this.radLabel7.Location = new System.Drawing.Point(3, 8);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(72, 20);
            this.radLabel7.TabIndex = 132;
            this.radLabel7.Text = "Pa&yment Mode";
            // 
            // ddlPaymentType
            // 
            this.ddlPaymentType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPaymentType.ForeColor = System.Drawing.Color.Black;
            this.ddlPaymentType.Location = new System.Drawing.Point(100, 6);
            this.ddlPaymentType.Name = "ddlPaymentType";
            this.ddlPaymentType.Size = new System.Drawing.Size(157, 26);
            this.ddlPaymentType.TabIndex = 0;
            // 
            // btnViewMapReport
            // 
            this.btnViewMapReport.BackColor = System.Drawing.Color.FloralWhite;
            this.btnViewMapReport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewMapReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnViewMapReport.Location = new System.Drawing.Point(433, 87);
            this.btnViewMapReport.Name = "btnViewMapReport";
            this.btnViewMapReport.Size = new System.Drawing.Size(107, 47);
            this.btnViewMapReport.TabIndex = 507;
            this.btnViewMapReport.Text = "Map Report (CTRL+M)";
            this.btnViewMapReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewMapReport.UseVisualStyleBackColor = false;
            this.btnViewMapReport.Visible = false;
            // 
            // radLabel27
            // 
            this.radLabel27.BackColor = System.Drawing.Color.Navy;
            this.radLabel27.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.radLabel27.ForeColor = System.Drawing.Color.White;
            this.radLabel27.Location = new System.Drawing.Point(712, 157);
            this.radLabel27.Name = "radLabel27";
            this.radLabel27.Size = new System.Drawing.Size(564, 17);
            this.radLabel27.TabIndex = 26;
            this.radLabel27.Text = "Actions";
            // 
            // txtSpecialRequirements
            // 
            this.txtSpecialRequirements.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtSpecialRequirements.ForeColor = System.Drawing.Color.Red;
            this.txtSpecialRequirements.Location = new System.Drawing.Point(106, 161);
            this.txtSpecialRequirements.MaxLength = 500;
            this.txtSpecialRequirements.Multiline = true;
            this.txtSpecialRequirements.Name = "txtSpecialRequirements";
            this.txtSpecialRequirements.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSpecialRequirements.Size = new System.Drawing.Size(273, 71);
            this.txtSpecialRequirements.TabIndex = 3;
            this.txtSpecialRequirements.TabStop = false;
            // 
            // btnTrackDriver
            // 
            this.btnTrackDriver.BackColor = System.Drawing.Color.FloralWhite;
            this.btnTrackDriver.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnTrackDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnTrackDriver.Location = new System.Drawing.Point(558, 86);
            this.btnTrackDriver.Name = "btnTrackDriver";
            this.btnTrackDriver.Size = new System.Drawing.Size(123, 48);
            this.btnTrackDriver.TabIndex = 276;
            this.btnTrackDriver.Text = "Track Driver (CTRL + T)";
            this.btnTrackDriver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrackDriver.UseVisualStyleBackColor = false;
            this.btnTrackDriver.Visible = false;
            // 
            // pnlBookingFees
            // 
            this.pnlBookingFees.BackColor = System.Drawing.Color.Lavender;
            this.pnlBookingFees.Controls.Add(this.numReturnBookingFee);
            this.pnlBookingFees.Controls.Add(this.lblReturnCustFare);
            this.pnlBookingFees.Controls.Add(this.numBookingFee);
            this.pnlBookingFees.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.pnlBookingFees.ForeColor = System.Drawing.Color.Black;
            this.pnlBookingFees.Location = new System.Drawing.Point(419, 2);
            this.pnlBookingFees.Name = "pnlBookingFees";
            this.pnlBookingFees.Size = new System.Drawing.Size(282, 35);
            this.pnlBookingFees.TabIndex = 0;
            this.pnlBookingFees.Text = "Booking Fee £";
            this.pnlBookingFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlBookingFees.Visible = false;
            // 
            // numReturnBookingFee
            // 
            this.numReturnBookingFee.DecimalPlaces = 2;
            this.numReturnBookingFee.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numReturnBookingFee.ForeColor = System.Drawing.Color.Red;
            this.numReturnBookingFee.InterceptArrowKeys = false;
            this.numReturnBookingFee.Location = new System.Drawing.Point(221, 6);
            this.numReturnBookingFee.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numReturnBookingFee.Name = "numReturnBookingFee";
            this.numReturnBookingFee.Size = new System.Drawing.Size(58, 26);
            this.numReturnBookingFee.TabIndex = 0;
            this.numReturnBookingFee.TabStop = false;
            this.numReturnBookingFee.Visible = false;
            // 
            // lblReturnCustFare
            // 
            this.lblReturnCustFare.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnCustFare.Location = new System.Drawing.Point(170, 9);
            this.lblReturnCustFare.Name = "lblReturnCustFare";
            this.lblReturnCustFare.Size = new System.Drawing.Size(49, 19);
            this.lblReturnCustFare.TabIndex = 248;
            this.lblReturnCustFare.Text = "R/T  £";
            this.lblReturnCustFare.Visible = false;
            // 
            // numBookingFee
            // 
            this.numBookingFee.DecimalPlaces = 2;
            this.numBookingFee.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBookingFee.ForeColor = System.Drawing.Color.Red;
            this.numBookingFee.InterceptArrowKeys = false;
            this.numBookingFee.Location = new System.Drawing.Point(109, 6);
            this.numBookingFee.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numBookingFee.Name = "numBookingFee";
            this.numBookingFee.Size = new System.Drawing.Size(59, 26);
            this.numBookingFee.TabIndex = 0;
            this.numBookingFee.TabStop = false;
            // 
            // chkPermanentCustNotes
            // 
            this.chkPermanentCustNotes.BackColor = System.Drawing.Color.Lavender;
            this.chkPermanentCustNotes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkPermanentCustNotes.Location = new System.Drawing.Point(6, 210);
            this.chkPermanentCustNotes.Name = "chkPermanentCustNotes";
            this.chkPermanentCustNotes.Size = new System.Drawing.Size(94, 18);
            this.chkPermanentCustNotes.TabIndex = 0;
            this.chkPermanentCustNotes.Text = "Permanent";
            this.chkPermanentCustNotes.UseVisualStyleBackColor = false;
            // 
            // txtPaymentReference
            // 
            this.txtPaymentReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentReference.Location = new System.Drawing.Point(794, 91);
            this.txtPaymentReference.MaxLength = 500;
            this.txtPaymentReference.Multiline = true;
            this.txtPaymentReference.Name = "txtPaymentReference";
            this.txtPaymentReference.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaymentReference.Size = new System.Drawing.Size(438, 62);
            this.txtPaymentReference.TabIndex = 0;
            this.txtPaymentReference.TabStop = false;
            // 
            // btnDetailMap
            // 
            this.btnDetailMap.BackColor = System.Drawing.Color.FloralWhite;
            this.btnDetailMap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetailMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnDetailMap.Location = new System.Drawing.Point(433, 40);
            this.btnDetailMap.Name = "btnDetailMap";
            this.btnDetailMap.Size = new System.Drawing.Size(107, 50);
            this.btnDetailMap.TabIndex = 0;
            this.btnDetailMap.TabStop = false;
            this.btnDetailMap.Text = "Show Map (F3)";
            this.btnDetailMap.UseVisualStyleBackColor = false;
            // 
            // radLabel25
            // 
            this.radLabel25.BackColor = System.Drawing.Color.Lavender;
            this.radLabel25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel25.Location = new System.Drawing.Point(8, 163);
            this.radLabel25.Name = "radLabel25";
            this.radLabel25.Size = new System.Drawing.Size(92, 38);
            this.radLabel25.TabIndex = 243;
            this.radLabel25.Text = "&Special Requirements";
            // 
            // lblPaymentRef
            // 
            this.lblPaymentRef.BackColor = System.Drawing.Color.Lavender;
            this.lblPaymentRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentRef.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentRef.Location = new System.Drawing.Point(714, 96);
            this.lblPaymentRef.Name = "lblPaymentRef";
            this.lblPaymentRef.Size = new System.Drawing.Size(77, 47);
            this.lblPaymentRef.TabIndex = 244;
            this.lblPaymentRef.Text = "Payment References";
            // 
            // radLabel5
            // 
            this.radLabel5.AutoSize = true;
            this.radLabel5.BackColor = System.Drawing.Color.Lavender;
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 11F);
            this.radLabel5.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Location = new System.Drawing.Point(9, 9);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(57, 18);
            this.radLabel5.TabIndex = 237;
            this.radLabel5.Text = "&Fares £";
            // 
            // lblMap
            // 
            this.lblMap.BackColor = System.Drawing.Color.Lavender;
            this.lblMap.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.ForeColor = System.Drawing.Color.Blue;
            this.lblMap.Location = new System.Drawing.Point(7, 103);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(274, 26);
            this.lblMap.TabIndex = 0;
            // 
            // pnlFares
            // 
            this.pnlFares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFares.BackColor = System.Drawing.Color.Lavender;
            this.pnlFares.Controls.Add(this.numFareRate);
            this.pnlFares.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFares.Location = new System.Drawing.Point(8, 5);
            this.pnlFares.Name = "pnlFares";
            this.pnlFares.Size = new System.Drawing.Size(409, 123);
            this.pnlFares.TabIndex = 2;
            // 
            // numFareRate
            // 
            this.numFareRate.DecimalPlaces = 2;
            this.numFareRate.Font = new System.Drawing.Font("Tahoma", 11F);
            this.numFareRate.ForeColor = System.Drawing.Color.Red;
            this.numFareRate.InterceptArrowKeys = false;
            this.numFareRate.Location = new System.Drawing.Point(97, 1);
            this.numFareRate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numFareRate.Name = "numFareRate";
            this.numFareRate.Size = new System.Drawing.Size(105, 25);
            this.numFareRate.TabIndex = 2;
            this.numFareRate.TabStop = false;
            // 
            // chkQuotedPrice
            // 
            this.chkQuotedPrice.BackColor = System.Drawing.Color.Lavender;
            this.chkQuotedPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQuotedPrice.Location = new System.Drawing.Point(11, 2);
            this.chkQuotedPrice.Name = "chkQuotedPrice";
            this.chkQuotedPrice.Size = new System.Drawing.Size(80, 18);
            this.chkQuotedPrice.TabIndex = 0;
            this.chkQuotedPrice.Text = "Quoted";
            this.chkQuotedPrice.UseVisualStyleBackColor = false;
            this.chkQuotedPrice.Click += new System.EventHandler(this.chkQuotedPrice_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 37);
            this.panel1.TabIndex = 0;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookingNo.Location = new System.Drawing.Point(59, 10);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(112, 22);
            this.txtBookingNo.TabIndex = 108;
            this.txtBookingNo.Text = "Not Allocated";
            this.txtBookingNo.Visible = false;
            // 
            // ddlBookingType
            // 
            this.ddlBookingType.BackColor = System.Drawing.Color.FloralWhite;
            this.ddlBookingType.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ddlBookingType.Location = new System.Drawing.Point(995, 7);
            this.ddlBookingType.Name = "ddlBookingType";
            this.ddlBookingType.Size = new System.Drawing.Size(146, 26);
            this.ddlBookingType.TabIndex = 218;
            // 
            // lblBookingType
            // 
            this.lblBookingType.BackColor = System.Drawing.Color.SteelBlue;
            this.lblBookingType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookingType.ForeColor = System.Drawing.Color.White;
            this.lblBookingType.Location = new System.Drawing.Point(942, 9);
            this.lblBookingType.Name = "lblBookingType";
            this.lblBookingType.Size = new System.Drawing.Size(57, 22);
            this.lblBookingType.TabIndex = 219;
            this.lblBookingType.Text = "Type";
            // 
            // lblBookedBy
            // 
            this.lblBookedBy.BackColor = System.Drawing.Color.FloralWhite;
            this.lblBookedBy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBookedBy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblBookedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblBookedBy.Location = new System.Drawing.Point(0, 740);
            this.lblBookedBy.Name = "lblBookedBy";
            this.lblBookedBy.Size = new System.Drawing.Size(1284, 21);
            this.lblBookedBy.TabIndex = 220;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.BackColor = System.Drawing.Color.White;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubCompany.FormattingEnabled = true;
            this.ddlSubCompany.Location = new System.Drawing.Point(7, 6);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(246, 27);
            this.ddlSubCompany.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1284, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = " Booking";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnExit.Image = global::Taxi_AppMain.Resources.Resource1.exit;
            this.btnExit.Location = new System.Drawing.Point(1217, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 37);
            this.btnExit.TabIndex = 273;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label17
            // 
            this.label17.BackColor = this.pnlOtherCharges.BackColor;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(232, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 20);
            this.label17.TabIndex = 509;
            this.label17.Text = "Tip";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.AliceBlue;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(343, 388);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 22);
            this.label18.TabIndex = 531;
            this.label18.Text = "H. Lugg";
            // 
            // numHandLugg
            // 
            this.numHandLugg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHandLugg.InterceptArrowKeys = false;
            this.numHandLugg.Location = new System.Drawing.Point(414, 385);
            this.numHandLugg.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numHandLugg.Name = "numHandLugg";
            this.numHandLugg.Size = new System.Drawing.Size(57, 26);
            this.numHandLugg.TabIndex = 530;
            this.numHandLugg.TabStop = false;
            // 
            // frmBooking2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ddlSubCompany);
            this.Controls.Add(this.lblBookedBy);
            this.Controls.Add(this.ddlBookingType);
            this.Controls.Add(this.lblBookingType);
            this.Controls.Add(this.txtBookingNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBooking2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBooking_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).EndInit();
            this.pnlAutoDespatch.ResumeLayout(false);
            this.pnlAutoDespatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeforeMinutes)).EndInit();
            this.pnljourney.ResumeLayout(false);
            this.pnljourney.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalLuggages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TotalPassengers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPickupDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPickupTime)).EndInit();
            this.panel4.ResumeLayout(false);
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSetFares)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).EndInit();
            this.pnlOtherCharges.ResumeLayout(false);
            this.pnlOtherCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTipAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDrvWaitingMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCongChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeetCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaitingChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParkingChrgs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPayment1)).EndInit();
            this.pnlPayment1.ResumeLayout(false);
            this.pnlBookingFees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numReturnBookingFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBookingFee)).EndInit();
            this.pnlFares.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFareRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHandLugg)).EndInit();
            this.ResumeLayout(false);

        }

       

        


        


        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Label lblReturnPickupTime;
        private Label lblReturnPickupDate;
        private UI.MyDatePicker dtpReturnPickupTime;
        private UI.MyDatePicker dtpReturnPickupDate;       
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlOrderNo;
        private Label lblOrderNo;
        private System.Windows.Forms.TextBox txtPupilNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private Label lblPupilNo;
        private System.Windows.Forms.Timer timer1;
        private Label txtBookingNo;
        private System.Windows.Forms.ComboBox ddlBookingType;
        private Label lblBookingType;   
        private System.Windows.Forms.Panel pnlAccpassword;
        private System.Windows.Forms.TextBox txtAccPassword;
        private Label radLabel33;
        private System.Windows.Forms.Label pnlReturnJobNo;
        private System.Windows.Forms.Panel pnlVia;
        private UIX.AutoCompleteTextBox txtViaAddress;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddVia;
        private UI.MyDropDownList ddlViaLocation;
        private Telerik.WinControls.UI.RadGridView grdVia;
        private UIX.AutoCompleteTextBox txtviaPostCode;
        private Label lblViaLoc;
        private Label lblFromViaPoint;     
		private ComboBox ddlViaFromLocType;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBookedBy;
        private ComboBox ddlReturnFromAirport;
        private Label lblReturnFromAirport;
        private System.Windows.Forms.ComboBox ddlSubCompany;
        private Label lblCompanyPrice;
        private System.Windows.Forms.NumericUpDown numCompanyFares;
        private Label lblReturnCompanyPrice;
        private System.Windows.Forms.NumericUpDown numReturnCompanyFares;
        private Label lblRetFares;
        private System.Windows.Forms.NumericUpDown numReturnFare;
        private System.Windows.Forms.Panel radPanel3;   
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnExitForm;      
        private Label radLabel27;
        private System.Windows.Forms.Button btnSaveNew;
        private Label lblDepartment;
        private UI.MyDropDownList ddlDepartment;
        private Label radLabel32;
        private Label lblagentcharge;
        private System.Windows.Forms.NumericUpDown numAgentCommission;
        private System.Windows.Forms.NumericUpDown numAgentCharge;

        private System.Windows.Forms.CheckBox chkTakenByAgent;
     //   private Label radLabel34;
      //  private System.Windows.Forms.NumericUpDown numAgentCommissionPercent;
    //    private UI.MyDropDownList ddlAgentCommissionType;
        private System.Windows.Forms.PictureBox pic_Signature;
        private System.Windows.Forms.Label txtCourierSignedOn;
        private System.Windows.Forms.Label lblCourierHeader;
        private Label lblAccountBookedBy;
        private System.Windows.Forms.TextBox txtAccountBookedBy;
        private Label lblReturnSpecialReq;
        private System.Windows.Forms.TextBox txtReturnSpecialReq;     
        private System.Windows.Forms.ComboBox ddlbabyseat2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlBabyseat1;
        private System.Windows.Forms.Label label8;
        private Label lblReturnVehicle;   
		private ComboBox ddlReturnVehicleType;
		private Label lblEscort;
        private System.Windows.Forms.NumericUpDown numEscortPrice;
        private Label lblEscortPrice;
        private System.Windows.Forms.Button btnExit;
        private Label lblJourneyTime;
        System.Windows.Forms.NumericUpDown numJourneyTime;      
        private System.Windows.Forms.DataGridView grdPickupDateTime;
        private System.Windows.Forms.TabControl radPageView1;
        private System.Windows.Forms.TabPage tabCurrentBooking;
        private System.Windows.Forms.TabPage tabNearestDrivers;
        private Button btnRefreshNearestDrivers;
        private Button btnJobInformation;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Button btnAttributes;
        private RadPanel pnlPayment1;
        private Button btnPayment;
        private Label radLabel7;
		private ComboBox ddlPaymentType;
        private Panel pnlAutoDespatch;
        private Button btnSms;
        private CheckBox chkBidding;
        private CheckBox chkAutoDespatch;
        private NumericUpDown numBeforeMinutes;
        private CheckBox chkReverse;
        private CheckBox chkPermanentCustNotes;
        private Label radLabel25;
        private CheckBox chkIsCompanyRates;
        private Label lblLuggages;
        private Label lblPassengers;
        private Panel pnljourney;
        private RadioButton opt_one;
        private RadioButton opt_waitreturn;
        private RadioButton opt_return;
        private Label radLabel14;
        private Button btnMultiVehicle;
        private Label lblVehicleType;	
		private UIX.AutoCompleteTextBox txtReturnFrom;
        private Button btnSelectVia;
        private ComboBox ddlDropOffPlot;
        private ComboBox ddlPickupPlot;
        private Panel radPanel1;
        private Button btnPickFares;
        private Panel pnlOtherCharges;
        private NumericUpDown numTipAmount;
        private Label radLabel4;
        private NumericUpDown numDrvWaitingMins;
        private Label lblTotalCharges;
        private NumericUpDown numTotalChrgs;
        private Label radLabel20;
        private NumericUpDown numCongChrgs;
        private Label radLabel16;
        private NumericUpDown numMeetCharges;
        private Label radLabel17;
        private NumericUpDown numExtraChrgs;
        private Label lblAccWaitingCharges;
        private NumericUpDown numWaitingChrgs;
        private Label lblAccParkingCharges;
        private NumericUpDown numParkingChrgs;
        private Label pnlBookingFees;
        private NumericUpDown numReturnBookingFee;
        private Label lblReturnCustFare;
        private NumericUpDown numBookingFee;
        private TextBox txtPaymentReference;
        private CheckBox chkQuotedPrice;
        private Label lblPaymentRef;
        private Label radLabel5;
        private Button btnDetailMap;
        private Label lblMap;
        private Label pnlFares;
        private NumericUpDown numFareRate;
        private Label txtFaresPostedFrom;
        private Label lblDropOffPlot;
        private Label lblPickupPlot;
        private Label txtVehicleNo;
        private Label pnlCustomer;
        private NumericUpDown numTotalLuggages;
        private NumericUpDown num_TotalPassengers;
        private TextBox txtSpecialRequirements;
        private SuggestComboBox ddlCompany;
        private UI.MyDropDownList ddlDriver;
 		private System.Windows.Forms.ComboBox ddlVehicleType;
		private Label radLabel2;
        private TextBox txtEmail;
        private Button btnCustomerLister;
        private Label radLabel6;
        private Label radLabel21;
        private Label radLabel19;
        private TextBox txtCustomerPhoneNo;
        private TextBox txtCustomerMobileNo;
        private TextBox ddlCustomerName;
        private Button btn_notes;
        private UI.MyDatePicker dtpPickupDate;
        private Label lblDate;
        private UI.MyDatePicker dtpPickupTime;
        private Label lblPickupTime;
        private CheckBox chkQuotation;
        private Panel panel4;
        private Button btnViewMapReport;
        private Button btnNearestDrv;
        private Button btnDespatchView;
        private Button btnTrackDriver;
        private Button btnPasteBooking;
        private Button btnSendEmail;
        private Button btnAccountCode;
        private Button btnMultiBooking;
        private Button btnSearch;
        private Button btnBase;
        private UIX.AutoCompleteTextBox txtFromAddress;
        private TextBox txtFromPostCode;
        private TextBox txtFromStreetComing;
        private TextBox txtFromFlightDoorNo;
        private Label lblFromStreetComing;
        private Label lblFromDoorFlightNo;
        private UIX.AutoCompleteTextBox txtToAddress;
        private Label lblFromLoc;
        private ComboBox ddlFromLocType;
        private ComboBox ddlToLocType;
        private Label lblToLoc;
        private TextBox txtToStreetComing;
        private TextBox txtToPostCode;
        private Label lblToStreetComing;
        private TextBox txtToFlightDoorNo;
        private Label lblToDoorFlightNo;
        private UIX.AutoCompleteTextBox txtReturnTo;
        private CheckBox chkLead;
        private Label label6;
        private NumericUpDown numLead;
        public Button btnExcludeDrivers;
        private Label lblReturnAddress;
        private Label lblretto;
        private Label lblretfrom;
        private Panel pnlSignature;


        //default null
        private ComboBox ddlCompletedSubCompany;
        private Label lblCompletedSubCompany;
        //

        private Button btnInfo;
        private TextBox dtpPickupTime_txt;
        private RadButton btnSetFares;
        private Label chkETA;
        private Button btnExtrAcHARGES;
        private Button btnAccountInformation;
        private CheckBox chkAllocateDriver;
        private Label txtPromotion;
        private CheckBox chkSurge;
        private CheckBox chkHasPriority;
        private NumericUpDown numPriority;
        private Button btnCall;
        private CheckBox chkMiles;
        private NumericUpDown numMiles;
        private ComboBox ddlRoute;
        private Label lblRoute;
        private Panel pnl_Drivers;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label11;
        private Label label10;
        private Label label5;
        private Label label4;
        private Label label2;
        private Button btnRefundKP;
        private Label lblCardIsRegisteredKP;
        private Label pic_card;
        private Button btnregisterlink;
        private Button btnsendpaymentlink;

        //

        private System.Windows.Forms.ComboBox ddlMilesDrvs2;
        private System.Windows.Forms.DataGridView grdDrivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverId;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
        private System.Windows.Forms.DataGridViewButtonColumn btnDespatchJob;
        private Label label17;
        private Label label18;
        private NumericUpDown numHandLugg;
    }
}