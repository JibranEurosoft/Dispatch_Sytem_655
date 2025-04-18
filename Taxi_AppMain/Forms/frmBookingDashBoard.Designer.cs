﻿using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Utils;

namespace Taxi_AppMain
{
    partial class frmBookingDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.taxi1.
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition11 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition12 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition13 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition14 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition15 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition16 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition17 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition18 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition19 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition20 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.Pg_PendingJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radPanel10 = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOnPlotDrivers = new Telerik.WinControls.UI.RadPanel();
            this.chkShowAuthorization = new System.Windows.Forms.CheckBox();
            this.lblOnPlot = new System.Windows.Forms.Label();
            this.grdOnPlotDrivers = new System.Windows.Forms.DataGridView();
            this.panel2 = new Telerik.WinControls.UI.RadPanel();
            this.grdDriverPricePlot = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlDriverWaiting = new System.Windows.Forms.Panel();
            this.grdDriverWaiting = new Telerik.WinControls.UI.RadGridView();
            this.lblDriverWaiting = new System.Windows.Forms.Label();
            this.pnlDriverOnBoard = new System.Windows.Forms.Panel();
            this.grdOnBoardDriver = new Telerik.WinControls.UI.RadGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new Telerik.WinControls.UI.RadPanel();
            this.grdPendingJobs = new Telerik.WinControls.UI.RadGridView();
            this.btnDeleteSelected = new Telerik.WinControls.UI.RadButton();
            this.lst_cdr = new System.Windows.Forms.ListBox();
            this.pnlActions = new Telerik.WinControls.UI.RadPanel();
            this.btnSMS = new Telerik.WinControls.UI.RadSplitButton();
            this.btnwritesms = new Telerik.WinControls.UI.RadMenuItem();
            this.btnInbox = new Telerik.WinControls.UI.RadMenuItem();
            this.btnPDAInbox = new Telerik.WinControls.UI.RadMenuItem();
            this.btnMessageAllDrivers = new Telerik.WinControls.UI.RadMenuItem();
            this.optSortTodayPickup = new Telerik.WinControls.UI.RadRadioButton();
            this.optSortTodayDriver = new Telerik.WinControls.UI.RadRadioButton();
            this.chkShowAllocatedTodayJobs = new System.Windows.Forms.CheckBox();
            this.ddlShowDue = new Telerik.WinControls.UI.RadDropDownList();
            this.chkShowACJobs = new System.Windows.Forms.RadioButton();
            this.chkShowCashJobs = new System.Windows.Forms.RadioButton();
            this.ChkShowAllJobs = new System.Windows.Forms.RadioButton();
            this.btnPrintJobInfo = new Telerik.WinControls.UI.RadSplitButton();
            this.btnViewPrint = new Telerik.WinControls.UI.RadMenuItem();
            this.btnEmailPrint = new Telerik.WinControls.UI.RadMenuItem();
            this.btnRecover = new Telerik.WinControls.UI.RadButton();
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.btnNewJob = new Telerik.WinControls.UI.RadButton();
            this.btnShowMap = new Telerik.WinControls.UI.RadButton();
            this.btnDespatchJob = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblProgressBar = new Telerik.WinControls.UI.RadLabel();
            this.pnlNotification = new Telerik.WinControls.UI.RadPanel();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.btnAirportArrivals = new System.Windows.Forms.Button();
            this.btnRentPay = new Telerik.WinControls.UI.RadButton();
            this.lblNotification = new Telerik.WinControls.UI.RadLabel();
            this.btnLostProperty = new Telerik.WinControls.UI.RadSplitButton();
            this.btnAddLostProperty = new Telerik.WinControls.UI.RadMenuItem();
            this.btnLostPropertyList = new Telerik.WinControls.UI.RadMenuItem();
            this.btnComplaints = new Telerik.WinControls.UI.RadMenuItem();
            this.btnHideBooking = new Telerik.WinControls.UI.RadToggleButton();
            this.btnHideMap = new Telerik.WinControls.UI.RadToggleButton();
            this.Pg_PreBookings = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdPreBookings = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.ddlSubCompanyPreBooking = new Telerik.WinControls.UI.RadDropDownList();
            this.btnPrintSelected = new Telerik.WinControls.UI.RadButton();
            this.chkShowAllocatedJobs = new System.Windows.Forms.CheckBox();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnShowAllPreBooking = new Telerik.WinControls.UI.RadButton();
            this.dtpToDatePreBook = new UI.MyDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDatePreBook = new UI.MyDatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindPreBooking = new Telerik.WinControls.UI.RadButton();
            this.ddlColumns = new Telerik.WinControls.UI.RadDropDownList();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.optSortPickupDate = new Telerik.WinControls.UI.RadRadioButton();
            this.optSortDriver = new Telerik.WinControls.UI.RadRadioButton();
            this.Pg_AllJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdAllJobs = new Telerik.WinControls.UI.RadGridView();
            this.radPanel9 = new Telerik.WinControls.UI.RadPanel();
            this.btnRecentShowAll = new Telerik.WinControls.UI.RadButton();
            this.btnRecentFind = new Telerik.WinControls.UI.RadButton();
            this.txtPassengerRecent = new Telerik.WinControls.UI.RadTextBox();
            this.txtMobileRecent = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtPhoneRecent = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpToDateRecent = new UI.MyDatePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDateRecent = new UI.MyDatePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchRec = new Telerik.WinControls.UI.RadTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlBookingStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlRecentColumn = new Telerik.WinControls.UI.RadDropDownList();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_NoShow = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdNoShowJobs = new Telerik.WinControls.UI.RadGridView();
            this.radLabel33 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_Cancelled = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdCancelledJobs = new Telerik.WinControls.UI.RadGridView();
            this.radLabel34 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_Quotations = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdQuotations = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnShowAllQuotation = new Telerik.WinControls.UI.RadButton();
            this.dtpToQuotation = new UI.MyDatePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFromQuotation = new UI.MyDatePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFindQuotations = new Telerik.WinControls.UI.RadButton();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_RecentJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new Telerik.WinControls.UI.RadPanel();
            this.grdRecentJobs = new Telerik.WinControls.UI.RadGridView();
            this.panel8 = new Telerik.WinControls.UI.RadPanel();
            this.lblSearchResults = new Telerik.WinControls.UI.RadLabel();
            this.chkAvailableRecordings = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCompanyVehicle = new Telerik.WinControls.UI.RadDropDownList();
            this.txtTokenNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblTokenNo = new Telerik.WinControls.UI.RadLabel();
            this.radLabel30 = new Telerik.WinControls.UI.RadLabel();
            this.ddlBookingType = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPaymentRef = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel29 = new Telerik.WinControls.UI.RadLabel();
            this.chkQuotation = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlSearchDateType = new Telerik.WinControls.UI.RadDropDownList();
            this.btnclearSearchFilter = new Telerik.WinControls.UI.RadButton();
            this.txtOrderNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtRefNumber = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.btnViewJob = new Telerik.WinControls.UI.RadButton();
            this.radLabel25 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel24 = new Telerik.WinControls.UI.RadLabel();
            this.ddlDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.ddlPaymentType = new Telerik.WinControls.UI.RadDropDownList();
            this.txtMobileNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel22 = new Telerik.WinControls.UI.RadLabel();
            this.txtPhoneNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel20 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCust = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.ddlVehicleType = new Telerik.WinControls.UI.RadDropDownList();
            this.opt_JOneWay = new Telerik.WinControls.UI.RadRadioButton();
            this.opt_JReturnWay = new Telerik.WinControls.UI.RadRadioButton();
            this.txtDestination = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.txtVia = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.txtPickup = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_RecentJobs_EndDate = new UI.MyDatePicker();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_recentJob_StartDate = new UI.MyDatePicker();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_DrvBookingStats = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdStats = new Telerik.WinControls.UI.RadGridView();
            this.pnlStatsHeader = new System.Windows.Forms.Panel();
            this.optToday = new Telerik.WinControls.UI.RadRadioButton();
            this.pnlMonthWise = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStatsFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStatsTillDate = new UI.MyDatePicker();
            this.optMonthWise = new Telerik.WinControls.UI.RadRadioButton();
            this.optDriverWise = new Telerik.WinControls.UI.RadRadioButton();
            this.btnPreview = new Telerik.WinControls.UI.RadButton();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_Stats = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPanel8 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel43 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel44 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel45 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel46 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel47 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel48 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel49 = new Telerik.WinControls.UI.RadLabel();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel50 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel51 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel52 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel53 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel54 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.timer_WebBooking = new System.Windows.Forms.Timer(this.components);
            this.tmrAlert = new System.Windows.Forms.Timer(this.components);
            this.timer_Lic = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.Pg_PendingJobs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel10)).BeginInit();
            this.radPanel10.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOnPlotDrivers)).BeginInit();
            this.pnlOnPlotDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnPlotDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverPricePlot)).BeginInit();
            this.pnlDriverWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting.MasterTemplate)).BeginInit();
            this.pnlDriverOnBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs.MasterTemplate)).BeginInit();
            this.grdPendingJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActions)).BeginInit();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShowDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintJobInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDespatchJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.radLabel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNotification)).BeginInit();
            this.pnlNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRentPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLostProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideMap)).BeginInit();
            this.Pg_PreBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompanyPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDatePreBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDatePreBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.radLabel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optSortPickupDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortDriver)).BeginInit();
            this.Pg_AllJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).BeginInit();
            this.radPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentShowAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassengerRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDateRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDateRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecentColumn)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.Pg_NoShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).BeginInit();
            this.Pg_Cancelled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel34)).BeginInit();
            this.Pg_Quotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            this.Pg_RecentJobs.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel8)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailableRecordings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTokenNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTokenNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchDateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclearSearchFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JOneWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JReturnWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_RecentJobs_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_recentJob_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            this.Pg_DrvBookingStats.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats.MasterTemplate)).BeginInit();
            this.pnlStatsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optToday)).BeginInit();
            this.pnlMonthWise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optMonthWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDriverWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).BeginInit();
            this.radPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel54)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(807, 230);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(698, 362);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.Pg_PendingJobs);
            this.radPageView1.Controls.Add(this.Pg_PreBookings);
            this.radPageView1.Controls.Add(this.Pg_AllJobs);
            this.radPageView1.Controls.Add(this.Pg_NoShow);
            this.radPageView1.Controls.Add(this.Pg_Cancelled);
            this.radPageView1.Controls.Add(this.Pg_Quotations);
            this.radPageView1.Controls.Add(this.Pg_RecentJobs);
            this.radPageView1.Controls.Add(this.Pg_DrvBookingStats);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPageView1.Location = new System.Drawing.Point(0, 38);
            this.radPageView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.Pg_RecentJobs;
            this.radPageView1.Size = new System.Drawing.Size(1400, 922);
            this.radPageView1.TabIndex = 106;
            this.radPageView1.Text = "Recent Jobs";
            this.radPageView1.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.radPageView1_SelectedPageChanging);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemSpacing = 10;
            // 
            // Pg_PendingJobs
            // 
            this.Pg_PendingJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.Pg_PendingJobs.Controls.Add(this.tableLayoutPanel1);
            this.Pg_PendingJobs.Controls.Add(this.radLabel1);
            this.Pg_PendingJobs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pg_PendingJobs.ItemSize = new System.Drawing.SizeF(127F, 29F);
            this.Pg_PendingJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_PendingJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_PendingJobs.Name = "Pg_PendingJobs";
            this.Pg_PendingJobs.Size = new System.Drawing.Size(1379, 873);
            this.Pg_PendingJobs.Text = "Today\'s Booking";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radPanel10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1379, 836);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radPanel10
            // 
            this.radPanel10.Controls.Add(this.tableLayoutPanel2);
            this.radPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel10.Location = new System.Drawing.Point(3, 4);
            this.radPanel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel10.Name = "radPanel10";
            this.radPanel10.Size = new System.Drawing.Size(1373, 326);
            this.radPanel10.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.Controls.Add(this.pnlOnPlotDrivers, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlDriverWaiting, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlDriverOnBoard, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1373, 326);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // pnlOnPlotDrivers
            // 
            this.pnlOnPlotDrivers.Controls.Add(this.chkShowAuthorization);
            this.pnlOnPlotDrivers.Controls.Add(this.lblOnPlot);
            this.pnlOnPlotDrivers.Controls.Add(this.grdOnPlotDrivers);
            this.pnlOnPlotDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOnPlotDrivers.Location = new System.Drawing.Point(3, 4);
            this.pnlOnPlotDrivers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOnPlotDrivers.Name = "pnlOnPlotDrivers";
            this.pnlOnPlotDrivers.Size = new System.Drawing.Size(900, 318);
            this.pnlOnPlotDrivers.TabIndex = 0;
            // 
            // chkShowAuthorization
            // 
            this.chkShowAuthorization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAuthorization.BackColor = System.Drawing.Color.DarkBlue;
            this.chkShowAuthorization.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAuthorization.ForeColor = System.Drawing.Color.Beige;
            this.chkShowAuthorization.Location = new System.Drawing.Point(886, 0);
            this.chkShowAuthorization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAuthorization.Name = "chkShowAuthorization";
            this.chkShowAuthorization.Size = new System.Drawing.Size(177, 25);
            this.chkShowAuthorization.TabIndex = 216;
            this.chkShowAuthorization.Text = "Show Authorization";
            this.chkShowAuthorization.UseVisualStyleBackColor = false;
            this.chkShowAuthorization.Visible = false;
            // 
            // lblOnPlot
            // 
            this.lblOnPlot.BackColor = System.Drawing.Color.DarkBlue;
            this.lblOnPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOnPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnPlot.ForeColor = System.Drawing.Color.White;
            this.lblOnPlot.Location = new System.Drawing.Point(0, 0);
            this.lblOnPlot.Name = "lblOnPlot";
            this.lblOnPlot.Size = new System.Drawing.Size(900, 25);
            this.lblOnPlot.TabIndex = 12;
            this.lblOnPlot.Text = "Drivers OnPlot";
            this.lblOnPlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdOnPlotDrivers
            // 
            this.grdOnPlotDrivers.AllowUserToAddRows = false;
            this.grdOnPlotDrivers.AllowUserToDeleteRows = false;
            this.grdOnPlotDrivers.AllowUserToResizeColumns = false;
            this.grdOnPlotDrivers.AllowUserToResizeRows = false;
            this.grdOnPlotDrivers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOnPlotDrivers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdOnPlotDrivers.ColumnHeadersHeight = 24;
            this.grdOnPlotDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOnPlotDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOnPlotDrivers.GridColor = System.Drawing.Color.Black;
            this.grdOnPlotDrivers.Location = new System.Drawing.Point(0, 0);
            this.grdOnPlotDrivers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdOnPlotDrivers.Name = "grdOnPlotDrivers";
            this.grdOnPlotDrivers.RowHeadersVisible = false;
            this.grdOnPlotDrivers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOnPlotDrivers.RowTemplate.ReadOnly = true;
            this.grdOnPlotDrivers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOnPlotDrivers.ShowCellErrors = false;
            this.grdOnPlotDrivers.ShowRowErrors = false;
            this.grdOnPlotDrivers.Size = new System.Drawing.Size(900, 318);
            this.grdOnPlotDrivers.TabIndex = 9;
            this.grdOnPlotDrivers.Text = "myGridView4";
            this.grdOnPlotDrivers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdOnPlotDrivers_CellFormatting);
            this.grdOnPlotDrivers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOnPlotDrivers_CellMouseEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdDriverPricePlot);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(909, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 318);
            this.panel2.TabIndex = 13;
            // 
            // grdDriverPricePlot
            // 
            this.grdDriverPricePlot.AllowUserToAddRows = false;
            this.grdDriverPricePlot.AllowUserToDeleteRows = false;
            this.grdDriverPricePlot.AllowUserToResizeColumns = false;
            this.grdDriverPricePlot.AllowUserToResizeRows = false;
            this.grdDriverPricePlot.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDriverPricePlot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdDriverPricePlot.ColumnHeadersHeight = 24;
            this.grdDriverPricePlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDriverPricePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDriverPricePlot.GridColor = System.Drawing.Color.Black;
            this.grdDriverPricePlot.Location = new System.Drawing.Point(0, 25);
            this.grdDriverPricePlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDriverPricePlot.Name = "grdDriverPricePlot";
            this.grdDriverPricePlot.RowHeadersVisible = false;
            this.grdDriverPricePlot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDriverPricePlot.RowTemplate.ReadOnly = true;
            this.grdDriverPricePlot.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDriverPricePlot.ShowCellErrors = false;
            this.grdDriverPricePlot.ShowRowErrors = false;
            this.grdDriverPricePlot.Size = new System.Drawing.Size(1, 293);
            this.grdDriverPricePlot.TabIndex = 10;
            this.grdDriverPricePlot.Text = "myGridView4";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DarkMagenta;
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1, 25);
            this.label20.TabIndex = 11;
            this.label20.Text = "Price Plot";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDriverWaiting
            // 
            this.pnlDriverWaiting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriverWaiting.Controls.Add(this.grdDriverWaiting);
            this.pnlDriverWaiting.Controls.Add(this.lblDriverWaiting);
            this.pnlDriverWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverWaiting.Location = new System.Drawing.Point(1156, 4);
            this.pnlDriverWaiting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDriverWaiting.Name = "pnlDriverWaiting";
            this.pnlDriverWaiting.Size = new System.Drawing.Size(214, 318);
            this.pnlDriverWaiting.TabIndex = 11;
            // 
            // grdDriverWaiting
            // 
            this.grdDriverWaiting.AutoSizeRows = true;
            this.grdDriverWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDriverWaiting.Location = new System.Drawing.Point(0, 25);
            this.grdDriverWaiting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverWaiting.MasterTemplate.ViewDefinition = tableViewDefinition11;
            this.grdDriverWaiting.Name = "grdDriverWaiting";
            this.grdDriverWaiting.Size = new System.Drawing.Size(212, 291);
            this.grdDriverWaiting.TabIndex = 4;
            this.grdDriverWaiting.Text = "myGridView4";
            this.grdDriverWaiting.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdDriver_CellFormatting);
            // 
            // lblDriverWaiting
            // 
            this.lblDriverWaiting.BackColor = System.Drawing.Color.Green;
            this.lblDriverWaiting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDriverWaiting.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverWaiting.ForeColor = System.Drawing.Color.White;
            this.lblDriverWaiting.Location = new System.Drawing.Point(0, 0);
            this.lblDriverWaiting.Name = "lblDriverWaiting";
            this.lblDriverWaiting.Size = new System.Drawing.Size(212, 25);
            this.lblDriverWaiting.TabIndex = 5;
            this.lblDriverWaiting.Text = "Drivers Waiting";
            this.lblDriverWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDriverOnBoard
            // 
            this.pnlDriverOnBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriverOnBoard.Controls.Add(this.grdOnBoardDriver);
            this.pnlDriverOnBoard.Controls.Add(this.label3);
            this.pnlDriverOnBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverOnBoard.Location = new System.Drawing.Point(909, 4);
            this.pnlDriverOnBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDriverOnBoard.Name = "pnlDriverOnBoard";
            this.pnlDriverOnBoard.Size = new System.Drawing.Size(241, 318);
            this.pnlDriverOnBoard.TabIndex = 10;
            this.pnlDriverOnBoard.Visible = false;
            // 
            // grdOnBoardDriver
            // 
            this.grdOnBoardDriver.AutoSizeRows = true;
            this.grdOnBoardDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOnBoardDriver.Location = new System.Drawing.Point(0, 25);
            this.grdOnBoardDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdOnBoardDriver.MasterTemplate.ViewDefinition = tableViewDefinition12;
            this.grdOnBoardDriver.Name = "grdOnBoardDriver";
            this.grdOnBoardDriver.Size = new System.Drawing.Size(239, 291);
            this.grdOnBoardDriver.TabIndex = 4;
            this.grdOnBoardDriver.Text = "myGridView4";
            this.grdOnBoardDriver.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdOnBoardDriver_CellFormatting);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Crimson;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Drivers OnBoard";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdPendingJobs);
            this.panel1.Controls.Add(this.pnlActions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 338);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 494);
            this.panel1.TabIndex = 2;
            // 
            // grdPendingJobs
            // 
            this.grdPendingJobs.Controls.Add(this.btnDeleteSelected);
            this.grdPendingJobs.Controls.Add(this.lst_cdr);
            this.grdPendingJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPendingJobs.Location = new System.Drawing.Point(0, 42);
            this.grdPendingJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdPendingJobs.MasterTemplate.ViewDefinition = tableViewDefinition13;
            this.grdPendingJobs.Name = "grdPendingJobs";
            this.grdPendingJobs.Size = new System.Drawing.Size(1373, 452);
            this.grdPendingJobs.TabIndex = 4;
            this.grdPendingJobs.Text = "myGridView1";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.btnDeleteSelected.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteSelected.Location = new System.Drawing.Point(3, 4);
            this.btnDeleteSelected.Margin = new System.Windows.Forms.Padding(12, 4, 3, 12);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(37, 26);
            this.btnDeleteSelected.TabIndex = 11;
            this.btnDeleteSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteSelected.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteSelected.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteSelected.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteSelected.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDeleteSelected.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDeleteSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lst_cdr
            // 
            this.lst_cdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_cdr.FormattingEnabled = true;
            this.lst_cdr.ItemHeight = 16;
            this.lst_cdr.Location = new System.Drawing.Point(1145, 324);
            this.lst_cdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lst_cdr.Name = "lst_cdr";
            this.lst_cdr.Size = new System.Drawing.Size(224, 116);
            this.lst_cdr.TabIndex = 0;
            this.lst_cdr.Visible = false;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.Beige;
            this.pnlActions.Controls.Add(this.btnSMS);
            this.pnlActions.Controls.Add(this.optSortTodayPickup);
            this.pnlActions.Controls.Add(this.optSortTodayDriver);
            this.pnlActions.Controls.Add(this.chkShowAllocatedTodayJobs);
            this.pnlActions.Controls.Add(this.ddlShowDue);
            this.pnlActions.Controls.Add(this.chkShowACJobs);
            this.pnlActions.Controls.Add(this.chkShowCashJobs);
            this.pnlActions.Controls.Add(this.ChkShowAllJobs);
            this.pnlActions.Controls.Add(this.btnPrintJobInfo);
            this.pnlActions.Controls.Add(this.btnRecover);
            this.pnlActions.Controls.Add(this.btnEmail);
            this.pnlActions.Controls.Add(this.btnNewJob);
            this.pnlActions.Controls.Add(this.btnShowMap);
            this.pnlActions.Controls.Add(this.btnDespatchJob);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 0);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1373, 42);
            this.pnlActions.TabIndex = 6;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).Width = 2F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BottomWidth = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor2 = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor3 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor4 = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Gold;
            // 
            // btnSMS
            // 
            this.btnSMS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSMS.Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            this.btnSMS.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSMS.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnwritesms,
            this.btnInbox,
            this.btnPDAInbox,
            this.btnMessageAllDrivers});
            this.btnSMS.Location = new System.Drawing.Point(880, 5);
            this.btnSMS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(129, 37);
            this.btnSMS.TabIndex = 204;
            this.btnSMS.Text = "SMS/Text";
            this.btnSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Text = "SMS/Text";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnwritesms
            // 
            this.btnwritesms.Name = "btnwritesms";
            this.btnwritesms.Text = "Write SMS";
            this.btnwritesms.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // btnInbox
            // 
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Text = "Inbox";
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnPDAInbox
            // 
            this.btnPDAInbox.Name = "btnPDAInbox";
            this.btnPDAInbox.Text = "PDA Inbox";
            this.btnPDAInbox.Click += new System.EventHandler(this.btnPDAInbox_Click);
            // 
            // btnMessageAllDrivers
            // 
            this.btnMessageAllDrivers.Name = "btnMessageAllDrivers";
            this.btnMessageAllDrivers.Text = "Message All Drivers";
            this.btnMessageAllDrivers.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.btnMessageAllDrivers.Click += new System.EventHandler(this.btnMessageAllDrivers_Click);
            // 
            // optSortTodayPickup
            // 
            this.optSortTodayPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortTodayPickup.BackColor = System.Drawing.Color.Beige;
            this.optSortTodayPickup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSortTodayPickup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortTodayPickup.ForeColor = System.Drawing.Color.Black;
            this.optSortTodayPickup.Location = new System.Drawing.Point(1204, 23);
            this.optSortTodayPickup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortTodayPickup.Name = "optSortTodayPickup";
            this.optSortTodayPickup.Size = new System.Drawing.Size(86, 16);
            this.optSortTodayPickup.TabIndex = 215;
            this.optSortTodayPickup.Text = "Pickup Date";
            this.optSortTodayPickup.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.optSortTodayPickup.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optSortTodayPickup_ToggleStateChanged);
            // 
            // optSortTodayDriver
            // 
            this.optSortTodayDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortTodayDriver.BackColor = System.Drawing.Color.Beige;
            this.optSortTodayDriver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortTodayDriver.Location = new System.Drawing.Point(1307, 23);
            this.optSortTodayDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortTodayDriver.Name = "optSortTodayDriver";
            this.optSortTodayDriver.Size = new System.Drawing.Size(54, 16);
            this.optSortTodayDriver.TabIndex = 214;
            this.optSortTodayDriver.Text = "Driver";
            // 
            // chkShowAllocatedTodayJobs
            // 
            this.chkShowAllocatedTodayJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllocatedTodayJobs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowAllocatedTodayJobs.ForeColor = System.Drawing.Color.Blue;
            this.chkShowAllocatedTodayJobs.Location = new System.Drawing.Point(1211, 5);
            this.chkShowAllocatedTodayJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAllocatedTodayJobs.Name = "chkShowAllocatedTodayJobs";
            this.chkShowAllocatedTodayJobs.Size = new System.Drawing.Size(164, 21);
            this.chkShowAllocatedTodayJobs.TabIndex = 211;
            this.chkShowAllocatedTodayJobs.Text = "Show Allocated Jobs";
            this.chkShowAllocatedTodayJobs.UseVisualStyleBackColor = true;
            this.chkShowAllocatedTodayJobs.CheckedChanged += new System.EventHandler(this.chkShowAllocatedTodayJobs_CheckedChanged);
            // 
            // ddlShowDue
            // 
            this.ddlShowDue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlShowDue.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlShowDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlShowDue.Location = new System.Drawing.Point(90, 1);
            this.ddlShowDue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlShowDue.Name = "ddlShowDue";
            this.ddlShowDue.Size = new System.Drawing.Size(112, 19);
            this.ddlShowDue.TabIndex = 210;
            this.ddlShowDue.Text = "No Filter";
            this.ddlShowDue.SelectedIndexChanging += new Telerik.WinControls.UI.Data.PositionChangingEventHandler(this.ddlShowDue_SelectedIndexChanging);
            // 
            // chkShowACJobs
            // 
            this.chkShowACJobs.AutoSize = true;
            this.chkShowACJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowACJobs.ForeColor = System.Drawing.Color.Red;
            this.chkShowACJobs.Location = new System.Drawing.Point(107, 28);
            this.chkShowACJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowACJobs.Name = "chkShowACJobs";
            this.chkShowACJobs.Size = new System.Drawing.Size(81, 18);
            this.chkShowACJobs.TabIndex = 209;
            this.chkShowACJobs.Text = "A/C Jobs";
            this.chkShowACJobs.UseVisualStyleBackColor = true;
            this.chkShowACJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // chkShowCashJobs
            // 
            this.chkShowCashJobs.AutoSize = true;
            this.chkShowCashJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowCashJobs.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkShowCashJobs.Location = new System.Drawing.Point(3, 28);
            this.chkShowCashJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowCashJobs.Name = "chkShowCashJobs";
            this.chkShowCashJobs.Size = new System.Drawing.Size(86, 18);
            this.chkShowCashJobs.TabIndex = 208;
            this.chkShowCashJobs.Text = "Cash Jobs";
            this.chkShowCashJobs.UseVisualStyleBackColor = true;
            this.chkShowCashJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // ChkShowAllJobs
            // 
            this.ChkShowAllJobs.AutoSize = true;
            this.ChkShowAllJobs.Checked = true;
            this.ChkShowAllJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ChkShowAllJobs.Location = new System.Drawing.Point(3, 2);
            this.ChkShowAllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChkShowAllJobs.Name = "ChkShowAllJobs";
            this.ChkShowAllJobs.Size = new System.Drawing.Size(72, 18);
            this.ChkShowAllJobs.TabIndex = 207;
            this.ChkShowAllJobs.TabStop = true;
            this.ChkShowAllJobs.Text = "All Jobs";
            this.ChkShowAllJobs.UseVisualStyleBackColor = true;
            this.ChkShowAllJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // btnPrintJobInfo
            // 
            this.btnPrintJobInfo.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintJobInfo.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnViewPrint,
            this.btnEmailPrint});
            this.btnPrintJobInfo.Location = new System.Drawing.Point(465, 5);
            this.btnPrintJobInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintJobInfo.Name = "btnPrintJobInfo";
            this.btnPrintJobInfo.Size = new System.Drawing.Size(120, 37);
            this.btnPrintJobInfo.TabIndex = 206;
            this.btnPrintJobInfo.Text = "Print Job";
            this.btnPrintJobInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).Text = "Print Job";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewPrint
            // 
            this.btnViewPrint.Name = "btnViewPrint";
            this.btnViewPrint.Text = "View Print";
            this.btnViewPrint.Click += new System.EventHandler(this.btnPrintJob_Click);
            // 
            // btnEmailPrint
            // 
            this.btnEmailPrint.Name = "btnEmailPrint";
            this.btnEmailPrint.Text = "Email Print";
            this.btnEmailPrint.Click += new System.EventHandler(this.btnEmailPrint_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            this.btnRecover.Location = new System.Drawing.Point(328, 5);
            this.btnRecover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(117, 37);
            this.btnRecover.TabIndex = 205;
            this.btnRecover.Text = "Recover Job";
            this.btnRecover.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).Text = "Recover Job";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // btnEmail
            // 
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            this.btnEmail.Location = new System.Drawing.Point(1020, 5);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(94, 37);
            this.btnEmail.TabIndex = 14;
            this.btnEmail.Tag = "";
            this.btnEmail.Text = "Email";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // btnNewJob
            // 
            this.btnNewJob.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewJob.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnNewJob.Location = new System.Drawing.Point(220, 5);
            this.btnNewJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(93, 37);
            this.btnNewJob.TabIndex = 6;
            this.btnNewJob.Text = "Add Job";
            this.btnNewJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewJob.TextWrap = true;
            this.btnNewJob.Visible = false;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Text = "Add Job";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).BoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).LeftColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).TopColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).RightColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).BottomShadowColor = System.Drawing.Color.Black;
            // 
            // btnShowMap
            // 
            this.btnShowMap.Image = global::Taxi_AppMain.Properties.Resources.map_icon;
            this.btnShowMap.Location = new System.Drawing.Point(749, 5);
            this.btnShowMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(114, 37);
            this.btnShowMap.TabIndex = 3;
            this.btnShowMap.Text = "View Map";
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.map_icon;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).Text = "View Map";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // btnDespatchJob
            // 
            this.btnDespatchJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespatchJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnDespatchJob.Image = global::Taxi_AppMain.Properties.Resources.icon_3;
            this.btnDespatchJob.Location = new System.Drawing.Point(600, 5);
            this.btnDespatchJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDespatchJob.Name = "btnDespatchJob";
            this.btnDespatchJob.Size = new System.Drawing.Size(140, 37);
            this.btnDespatchJob.TabIndex = 1;
            this.btnDespatchJob.Tag = "";
            this.btnDespatchJob.Text = "Dispatch Job";
            this.btnDespatchJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDespatchJob.Click += new System.EventHandler(this.btnDespatchJob_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).Text = "Dispatch Job";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.BackColor = System.Drawing.Color.Coral;
            this.radLabel1.Controls.Add(this.lblProgressBar);
            this.radLabel1.Controls.Add(this.pnlNotification);
            this.radLabel1.Controls.Add(this.btnLostProperty);
            this.radLabel1.Controls.Add(this.btnHideBooking);
            this.radLabel1.Controls.Add(this.btnHideMap);
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(1379, 37);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Today\'s Booking";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = false;
            this.lblProgressBar.BackColor = System.Drawing.Color.Red;
            this.lblProgressBar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.ForeColor = System.Drawing.Color.White;
            this.lblProgressBar.Image = global::Taxi_AppMain.Properties.Resources.spinner;
            this.lblProgressBar.Location = new System.Drawing.Point(-3, 1);
            this.lblProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(222, 33);
            this.lblProgressBar.TabIndex = 13;
            this.lblProgressBar.Text = "Loading";
            this.lblProgressBar.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgressBar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblProgressBar.Visible = false;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblProgressBar.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblProgressBar.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.spinner;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblProgressBar.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblProgressBar.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblProgressBar.GetChildAt(0))).Text = "Loading";
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.lblProgressBar.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.lblProgressBar.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.lblProgressBar.GetChildAt(0).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Red;
            // 
            // pnlNotification
            // 
            this.pnlNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotification.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotification.Controls.Add(this.ddlSubCompany);
            this.pnlNotification.Controls.Add(this.btnAirportArrivals);
            this.pnlNotification.Controls.Add(this.btnRentPay);
            this.pnlNotification.Controls.Add(this.lblNotification);
            this.pnlNotification.Location = new System.Drawing.Point(434, 0);
            this.pnlNotification.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlNotification.Name = "pnlNotification";
            this.pnlNotification.Size = new System.Drawing.Size(945, 37);
            this.pnlNotification.TabIndex = 208;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlNotification.GetChildAt(0).GetChildAt(1))).Width = 1F;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.BackColor = System.Drawing.Color.White;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ddlSubCompany.Location = new System.Drawing.Point(670, 4);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(243, 22);
            this.ddlSubCompany.TabIndex = 222;
            this.ddlSubCompany.Visible = false;
            // 
            // btnAirportArrivals
            // 
            this.btnAirportArrivals.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAirportArrivals.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAirportArrivals.Image = global::Taxi_AppMain.Properties.Resources.arrivals;
            this.btnAirportArrivals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAirportArrivals.Location = new System.Drawing.Point(6, 0);
            this.btnAirportArrivals.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAirportArrivals.Name = "btnAirportArrivals";
            this.btnAirportArrivals.Size = new System.Drawing.Size(149, 37);
            this.btnAirportArrivals.TabIndex = 13;
            this.btnAirportArrivals.Text = "Airport Arrivals";
            this.btnAirportArrivals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAirportArrivals.UseVisualStyleBackColor = false;
            this.btnAirportArrivals.Click += new System.EventHandler(this.btnAirportArrivals_Click);
            // 
            // btnRentPay
            // 
            this.btnRentPay.Image = global::Taxi_AppMain.Properties.Resources.fares28x28;
            this.btnRentPay.Location = new System.Drawing.Point(14, 0);
            this.btnRentPay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRentPay.Name = "btnRentPay";
            this.btnRentPay.Size = new System.Drawing.Size(117, 37);
            this.btnRentPay.TabIndex = 207;
            this.btnRentPay.Tag = "";
            this.btnRentPay.Text = "Rent Pay";
            this.btnRentPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRentPay.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRentPay.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.fares28x28;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRentPay.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRentPay.GetChildAt(0))).Text = "Rent Pay";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRentPay.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRentPay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRentPay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRentPay.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnRentPay.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // lblNotification
            // 
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.ForeColor = System.Drawing.Color.White;
            this.lblNotification.Location = new System.Drawing.Point(926, 0);
            this.lblNotification.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(2, 2);
            this.lblNotification.TabIndex = 206;
            this.lblNotification.Visible = false;
            this.lblNotification.MouseLeave += new System.EventHandler(this.lblNotification_MouseLeave);
            this.lblNotification.MouseHover += new System.EventHandler(this.lblNotification_MouseHover);
            // 
            // btnLostProperty
            // 
            this.btnLostProperty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLostProperty.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnLostProperty.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddLostProperty,
            this.btnLostPropertyList,
            this.btnComplaints});
            this.btnLostProperty.Location = new System.Drawing.Point(220, 1);
            this.btnLostProperty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLostProperty.Name = "btnLostProperty";
            this.btnLostProperty.Size = new System.Drawing.Size(213, 34);
            this.btnLostProperty.TabIndex = 204;
            this.btnLostProperty.Text = "Lost Property/Complaints";
            this.btnLostProperty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnLostProperty.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnLostProperty.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnLostProperty.GetChildAt(0))).Text = "Lost Property/Complaints";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnLostProperty.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnLostProperty.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLostProperty.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.OverflowPrimitive)(this.btnLostProperty.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(3))).ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnLostProperty.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAddLostProperty
            // 
            this.btnAddLostProperty.Name = "btnAddLostProperty";
            this.btnAddLostProperty.Text = "Add Lost Property";
            this.btnAddLostProperty.Click += new System.EventHandler(this.btnAddLostProperty_Click);
            // 
            // btnLostPropertyList
            // 
            this.btnLostPropertyList.Name = "btnLostPropertyList";
            this.btnLostPropertyList.Text = "Lost Property List";
            this.btnLostPropertyList.Click += new System.EventHandler(this.btnLostPropertyList_Click);
            // 
            // btnComplaints
            // 
            this.btnComplaints.Name = "btnComplaints";
            this.btnComplaints.Text = "Show Complaints";
            this.btnComplaints.Click += new System.EventHandler(this.btnComplaints_Click);
            // 
            // btnHideBooking
            // 
            this.btnHideBooking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnHideBooking.Location = new System.Drawing.Point(111, 2);
            this.btnHideBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHideBooking.Name = "btnHideBooking";
            this.btnHideBooking.Size = new System.Drawing.Size(99, 31);
            this.btnHideBooking.TabIndex = 2;
            this.btnHideBooking.Text = "Hide Booking";
            this.btnHideBooking.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.btnHideBooking.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.btnHideBooking_ToggleStateChanging);
            // 
            // btnHideMap
            // 
            this.btnHideMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnHideMap.Location = new System.Drawing.Point(8, 2);
            this.btnHideMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHideMap.Name = "btnHideMap";
            this.btnHideMap.Size = new System.Drawing.Size(92, 31);
            this.btnHideMap.TabIndex = 0;
            this.btnHideMap.Text = "Hide Drivers";
            this.btnHideMap.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.btnHideMap.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.btnHideMap_ToggleStateChanging);
            // 
            // Pg_PreBookings
            // 
            this.Pg_PreBookings.Controls.Add(this.grdPreBookings);
            this.Pg_PreBookings.Controls.Add(this.radPanel1);
            this.Pg_PreBookings.Controls.Add(this.panel4);
            this.Pg_PreBookings.ItemSize = new System.Drawing.SizeF(105F, 29F);
            this.Pg_PreBookings.Location = new System.Drawing.Point(10, 10);
            this.Pg_PreBookings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_PreBookings.Name = "Pg_PreBookings";
            this.Pg_PreBookings.Size = new System.Drawing.Size(1379, 873);
            this.Pg_PreBookings.Text = "Pre Bookings";
            // 
            // grdPreBookings
            // 
            this.grdPreBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPreBookings.Location = new System.Drawing.Point(0, 79);
            this.grdPreBookings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdPreBookings.MasterTemplate.ViewDefinition = tableViewDefinition14;
            this.grdPreBookings.Name = "grdPreBookings";
            this.grdPreBookings.Size = new System.Drawing.Size(1379, 794);
            this.grdPreBookings.TabIndex = 5;
            this.grdPreBookings.Text = "myGridView1";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.ddlSubCompanyPreBooking);
            this.radPanel1.Controls.Add(this.btnPrintSelected);
            this.radPanel1.Controls.Add(this.chkShowAllocatedJobs);
            this.radPanel1.Controls.Add(this.txtSearch);
            this.radPanel1.Controls.Add(this.label8);
            this.radPanel1.Controls.Add(this.btnShowAllPreBooking);
            this.radPanel1.Controls.Add(this.dtpToDatePreBook);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.dtpFromDatePreBook);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.btnFindPreBooking);
            this.radPanel1.Controls.Add(this.ddlColumns);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 37);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1379, 42);
            this.radPanel1.TabIndex = 110;
            // 
            // ddlSubCompanyPreBooking
            // 
            this.ddlSubCompanyPreBooking.BackColor = System.Drawing.Color.White;
            this.ddlSubCompanyPreBooking.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ddlSubCompanyPreBooking.Location = new System.Drawing.Point(900, 20);
            this.ddlSubCompanyPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompanyPreBooking.Name = "ddlSubCompanyPreBooking";
            this.ddlSubCompanyPreBooking.Size = new System.Drawing.Size(243, 22);
            this.ddlSubCompanyPreBooking.TabIndex = 223;
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintSelected.Location = new System.Drawing.Point(982, 2);
            this.btnPrintSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(133, 36);
            this.btnPrintSelected.TabIndex = 23;
            this.btnPrintSelected.Tag = "";
            this.btnPrintSelected.Text = "Print Booking";
            this.btnPrintSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Text = "Print Booking";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkShowAllocatedJobs
            // 
            this.chkShowAllocatedJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllocatedJobs.AutoSize = true;
            this.chkShowAllocatedJobs.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.chkShowAllocatedJobs.ForeColor = System.Drawing.Color.Blue;
            this.chkShowAllocatedJobs.Location = new System.Drawing.Point(1154, 7);
            this.chkShowAllocatedJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAllocatedJobs.Name = "chkShowAllocatedJobs";
            this.chkShowAllocatedJobs.Size = new System.Drawing.Size(216, 22);
            this.chkShowAllocatedJobs.TabIndex = 22;
            this.chkShowAllocatedJobs.Text = "Show Allocated Jobs only";
            this.chkShowAllocatedJobs.UseVisualStyleBackColor = true;
            this.chkShowAllocatedJobs.CheckedChanged += new System.EventHandler(this.chkShowAllocatedJobs_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(77, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(133, 21);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Search";
            // 
            // btnShowAllPreBooking
            // 
            this.btnShowAllPreBooking.Location = new System.Drawing.Point(884, 6);
            this.btnShowAllPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAllPreBooking.Name = "btnShowAllPreBooking";
            this.btnShowAllPreBooking.Size = new System.Drawing.Size(90, 30);
            this.btnShowAllPreBooking.TabIndex = 15;
            this.btnShowAllPreBooking.Tag = "";
            this.btnShowAllPreBooking.Text = "Clear Filter ";
            this.btnShowAllPreBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAllPreBooking.Click += new System.EventHandler(this.btnShowAllPreBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).Text = "Clear Filter ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDatePreBook
            // 
            this.dtpToDatePreBook.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpToDatePreBook.CustomFormat = "dd/MM/yyyy";
            this.dtpToDatePreBook.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDatePreBook.Location = new System.Drawing.Point(646, 6);
            this.dtpToDatePreBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDatePreBook.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDatePreBook.Name = "dtpToDatePreBook";
            this.dtpToDatePreBook.Size = new System.Drawing.Size(140, 25);
            this.dtpToDatePreBook.TabIndex = 14;
            this.dtpToDatePreBook.TabStop = false;
            this.dtpToDatePreBook.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(610, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "To";
            // 
            // dtpFromDatePreBook
            // 
            this.dtpFromDatePreBook.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDatePreBook.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatePreBook.Location = new System.Drawing.Point(458, 6);
            this.dtpFromDatePreBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDatePreBook.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDatePreBook.Name = "dtpFromDatePreBook";
            this.dtpFromDatePreBook.Size = new System.Drawing.Size(140, 25);
            this.dtpFromDatePreBook.TabIndex = 12;
            this.dtpFromDatePreBook.TabStop = false;
            this.dtpFromDatePreBook.Value = null;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtpFromDatePreBook.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtpFromDatePreBook.GetChildAt(0))).BackColor = System.Drawing.Color.AliceBlue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(356, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date From";
            // 
            // btnFindPreBooking
            // 
            this.btnFindPreBooking.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFindPreBooking.Location = new System.Drawing.Point(804, 6);
            this.btnFindPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindPreBooking.Name = "btnFindPreBooking";
            this.btnFindPreBooking.Size = new System.Drawing.Size(69, 30);
            this.btnFindPreBooking.TabIndex = 7;
            this.btnFindPreBooking.Tag = "";
            this.btnFindPreBooking.Text = "Find";
            this.btnFindPreBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindPreBooking.Click += new System.EventHandler(this.btnFindPreBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlColumns
            // 
            this.ddlColumns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlColumns.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlColumns.Location = new System.Drawing.Point(217, 7);
            this.ddlColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlColumns.Name = "ddlColumns";
            this.ddlColumns.Size = new System.Drawing.Size(129, 21);
            this.ddlColumns.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radLabel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1379, 37);
            this.panel4.TabIndex = 0;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.Crimson;
            this.radLabel3.Controls.Add(this.label17);
            this.radLabel3.Controls.Add(this.optSortPickupDate);
            this.radLabel3.Controls.Add(this.optSortDriver);
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.White;
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(1379, 37);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Pre Bookings";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1069, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 16);
            this.label17.TabIndex = 214;
            this.label17.Text = "Sort by";
            // 
            // optSortPickupDate
            // 
            this.optSortPickupDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortPickupDate.BackColor = System.Drawing.Color.Crimson;
            this.optSortPickupDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSortPickupDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSortPickupDate.ForeColor = System.Drawing.Color.White;
            this.optSortPickupDate.Location = new System.Drawing.Point(1173, 7);
            this.optSortPickupDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortPickupDate.Name = "optSortPickupDate";
            this.optSortPickupDate.Size = new System.Drawing.Size(91, 19);
            this.optSortPickupDate.TabIndex = 213;
            this.optSortPickupDate.Text = "Pickup Date";
            this.optSortPickupDate.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.optSortPickupDate.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optSortPickupDate_ToggleStateChanged);
            // 
            // optSortDriver
            // 
            this.optSortDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortDriver.BackColor = System.Drawing.Color.Crimson;
            this.optSortDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSortDriver.Location = new System.Drawing.Point(1304, 7);
            this.optSortDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortDriver.Name = "optSortDriver";
            this.optSortDriver.Size = new System.Drawing.Size(56, 19);
            this.optSortDriver.TabIndex = 212;
            this.optSortDriver.Text = "Driver";
            // 
            // Pg_AllJobs
            // 
            this.Pg_AllJobs.Controls.Add(this.grdAllJobs);
            this.Pg_AllJobs.Controls.Add(this.radPanel9);
            this.Pg_AllJobs.Controls.Add(this.panel5);
            this.Pg_AllJobs.ItemSize = new System.Drawing.SizeF(98F, 29F);
            this.Pg_AllJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_AllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_AllJobs.Name = "Pg_AllJobs";
            this.Pg_AllJobs.Size = new System.Drawing.Size(1379, 873);
            this.Pg_AllJobs.Text = "Recent Jobs";
            // 
            // grdAllJobs
            // 
            this.grdAllJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAllJobs.Location = new System.Drawing.Point(0, 236);
            this.grdAllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdAllJobs.MasterTemplate.ViewDefinition = tableViewDefinition15;
            this.grdAllJobs.Name = "grdAllJobs";
            this.grdAllJobs.Size = new System.Drawing.Size(1379, 637);
            this.grdAllJobs.TabIndex = 5;
            this.grdAllJobs.Text = "myGridView1";
            // 
            // radPanel9
            // 
            this.radPanel9.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel9.Controls.Add(this.btnRecentShowAll);
            this.radPanel9.Controls.Add(this.btnRecentFind);
            this.radPanel9.Controls.Add(this.txtPassengerRecent);
            this.radPanel9.Controls.Add(this.txtMobileRecent);
            this.radPanel9.Controls.Add(this.radLabel8);
            this.radPanel9.Controls.Add(this.txtPhoneRecent);
            this.radPanel9.Controls.Add(this.radLabel12);
            this.radPanel9.Controls.Add(this.label13);
            this.radPanel9.Controls.Add(this.dtpToDateRecent);
            this.radPanel9.Controls.Add(this.label9);
            this.radPanel9.Controls.Add(this.dtpFromDateRecent);
            this.radPanel9.Controls.Add(this.label12);
            this.radPanel9.Controls.Add(this.label11);
            this.radPanel9.Controls.Add(this.txtSearchRec);
            this.radPanel9.Controls.Add(this.label10);
            this.radPanel9.Controls.Add(this.ddlBookingStatus);
            this.radPanel9.Controls.Add(this.ddlRecentColumn);
            this.radPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel9.Location = new System.Drawing.Point(0, 37);
            this.radPanel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel9.Name = "radPanel9";
            this.radPanel9.Size = new System.Drawing.Size(1379, 199);
            this.radPanel9.TabIndex = 113;
            // 
            // btnRecentShowAll
            // 
            this.btnRecentShowAll.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecentShowAll.Location = new System.Drawing.Point(659, 105);
            this.btnRecentShowAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecentShowAll.Name = "btnRecentShowAll";
            this.btnRecentShowAll.Size = new System.Drawing.Size(129, 50);
            this.btnRecentShowAll.TabIndex = 228;
            this.btnRecentShowAll.Text = "Clear Filter";
            this.btnRecentShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRecentShowAll.Click += new System.EventHandler(this.btnRecentShowAll_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).Text = "Clear Filter";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRecentFind
            // 
            this.btnRecentFind.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnRecentFind.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecentFind.Location = new System.Drawing.Point(512, 105);
            this.btnRecentFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecentFind.Name = "btnRecentFind";
            this.btnRecentFind.Size = new System.Drawing.Size(129, 50);
            this.btnRecentFind.TabIndex = 227;
            this.btnRecentFind.Text = "Find Jobs";
            this.btnRecentFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecentFind.Click += new System.EventHandler(this.btnRecentFind_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).Text = "Find Jobs";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassengerRecent
            // 
            this.txtPassengerRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassengerRecent.Location = new System.Drawing.Point(161, 94);
            this.txtPassengerRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassengerRecent.Name = "txtPassengerRecent";
            this.txtPassengerRecent.Size = new System.Drawing.Size(173, 21);
            this.txtPassengerRecent.TabIndex = 224;
            this.txtPassengerRecent.TabStop = false;
            this.txtPassengerRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassengerRecent_KeyDown);
            // 
            // txtMobileRecent
            // 
            this.txtMobileRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileRecent.Location = new System.Drawing.Point(162, 162);
            this.txtMobileRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileRecent.Name = "txtMobileRecent";
            this.txtMobileRecent.Size = new System.Drawing.Size(173, 21);
            this.txtMobileRecent.TabIndex = 223;
            this.txtMobileRecent.TabStop = false;
            this.txtMobileRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileRecent_KeyDown);
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(19, 164);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(83, 19);
            this.radLabel8.TabIndex = 222;
            this.radLabel8.Text = "Mobile No :";
            // 
            // txtPhoneRecent
            // 
            this.txtPhoneRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneRecent.Location = new System.Drawing.Point(162, 129);
            this.txtPhoneRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneRecent.Name = "txtPhoneRecent";
            this.txtPhoneRecent.Size = new System.Drawing.Size(173, 21);
            this.txtPhoneRecent.TabIndex = 221;
            this.txtPhoneRecent.TabStop = false;
            this.txtPhoneRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhoneRecent_KeyDown);
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel12.Location = new System.Drawing.Point(19, 132);
            this.radLabel12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(80, 19);
            this.radLabel12.TabIndex = 220;
            this.radLabel12.Text = "Phone No :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "Customer Name :";
            // 
            // dtpToDateRecent
            // 
            this.dtpToDateRecent.CustomFormat = "dd/MM/yyyy";
            this.dtpToDateRecent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDateRecent.Location = new System.Drawing.Point(350, 7);
            this.dtpToDateRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDateRecent.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDateRecent.Name = "dtpToDateRecent";
            this.dtpToDateRecent.Size = new System.Drawing.Size(119, 24);
            this.dtpToDateRecent.TabIndex = 27;
            this.dtpToDateRecent.TabStop = false;
            this.dtpToDateRecent.Value = null;
            this.dtpToDateRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpToDateRecent_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(275, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Till Date";
            // 
            // dtpFromDateRecent
            // 
            this.dtpFromDateRecent.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDateRecent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDateRecent.Location = new System.Drawing.Point(120, 9);
            this.dtpFromDateRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDateRecent.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDateRecent.Name = "dtpFromDateRecent";
            this.dtpFromDateRecent.Size = new System.Drawing.Size(128, 24);
            this.dtpFromDateRecent.TabIndex = 25;
            this.dtpFromDateRecent.TabStop = false;
            this.dtpFromDateRecent.Value = null;
            this.dtpFromDateRecent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFromDateRecent_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "From Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(500, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Booking Status:";
            // 
            // txtSearchRec
            // 
            this.txtSearchRec.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchRec.Location = new System.Drawing.Point(120, 55);
            this.txtSearchRec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchRec.Name = "txtSearchRec";
            this.txtSearchRec.Size = new System.Drawing.Size(211, 21);
            this.txtSearchRec.TabIndex = 20;
            this.txtSearchRec.TabStop = false;
            this.txtSearchRec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchRec_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Search by:";
            // 
            // ddlBookingStatus
            // 
            this.ddlBookingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBookingStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBookingStatus.Location = new System.Drawing.Point(637, 7);
            this.ddlBookingStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlBookingStatus.Name = "ddlBookingStatus";
            this.ddlBookingStatus.Size = new System.Drawing.Size(156, 21);
            this.ddlBookingStatus.TabIndex = 22;
            this.ddlBookingStatus.Text = "Ongoing";
            this.ddlBookingStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlBookingStatus_KeyDown);
            // 
            // ddlRecentColumn
            // 
            this.ddlRecentColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRecentColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRecentColumn.Location = new System.Drawing.Point(345, 53);
            this.ddlRecentColumn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlRecentColumn.Name = "ddlRecentColumn";
            this.ddlRecentColumn.Size = new System.Drawing.Size(129, 21);
            this.ddlRecentColumn.TabIndex = 21;
            this.ddlRecentColumn.Text = "Refrence No";
            this.ddlRecentColumn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlRecentColumn_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radLabel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1379, 37);
            this.panel5.TabIndex = 0;
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.BackColor = System.Drawing.Color.SeaGreen;
            this.radLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.ForeColor = System.Drawing.Color.White;
            this.radLabel4.Location = new System.Drawing.Point(0, 0);
            this.radLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(1379, 37);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Recent Jobs";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_NoShow
            // 
            this.Pg_NoShow.Controls.Add(this.grdNoShowJobs);
            this.Pg_NoShow.Controls.Add(this.radLabel33);
            this.Pg_NoShow.ItemSize = new System.Drawing.SizeF(77F, 29F);
            this.Pg_NoShow.Location = new System.Drawing.Point(12, 12);
            this.Pg_NoShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_NoShow.Name = "Pg_NoShow";
            this.Pg_NoShow.Size = new System.Drawing.Size(1375, 844);
            this.Pg_NoShow.Text = "No Show";
            // 
            // grdNoShowJobs
            // 
            this.grdNoShowJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNoShowJobs.Location = new System.Drawing.Point(0, 37);
            this.grdNoShowJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdNoShowJobs.MasterTemplate.ViewDefinition = tableViewDefinition16;
            this.grdNoShowJobs.Name = "grdNoShowJobs";
            this.grdNoShowJobs.Size = new System.Drawing.Size(1375, 807);
            this.grdNoShowJobs.TabIndex = 8;
            this.grdNoShowJobs.Text = "myGridView1";
            // 
            // radLabel33
            // 
            this.radLabel33.AutoSize = false;
            this.radLabel33.BackColor = System.Drawing.Color.Crimson;
            this.radLabel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel33.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel33.ForeColor = System.Drawing.Color.White;
            this.radLabel33.Location = new System.Drawing.Point(0, 0);
            this.radLabel33.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel33.Name = "radLabel33";
            this.radLabel33.Size = new System.Drawing.Size(1375, 37);
            this.radLabel33.TabIndex = 7;
            this.radLabel33.Text = "No Show Bookings";
            this.radLabel33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_Cancelled
            // 
            this.Pg_Cancelled.Controls.Add(this.grdCancelledJobs);
            this.Pg_Cancelled.Controls.Add(this.radLabel34);
            this.Pg_Cancelled.ItemSize = new System.Drawing.SizeF(82F, 29F);
            this.Pg_Cancelled.Location = new System.Drawing.Point(10, 10);
            this.Pg_Cancelled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Cancelled.Name = "Pg_Cancelled";
            this.Pg_Cancelled.Size = new System.Drawing.Size(1379, 873);
            this.Pg_Cancelled.Text = "Cancelled";
            // 
            // grdCancelledJobs
            // 
            this.grdCancelledJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCancelledJobs.Location = new System.Drawing.Point(0, 37);
            this.grdCancelledJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdCancelledJobs.MasterTemplate.ViewDefinition = tableViewDefinition17;
            this.grdCancelledJobs.Name = "grdCancelledJobs";
            this.grdCancelledJobs.Size = new System.Drawing.Size(1379, 836);
            this.grdCancelledJobs.TabIndex = 10;
            this.grdCancelledJobs.Text = "Cancelled Bookings";
            // 
            // radLabel34
            // 
            this.radLabel34.AutoSize = false;
            this.radLabel34.BackColor = System.Drawing.Color.Crimson;
            this.radLabel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel34.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel34.ForeColor = System.Drawing.Color.White;
            this.radLabel34.Location = new System.Drawing.Point(0, 0);
            this.radLabel34.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel34.Name = "radLabel34";
            this.radLabel34.Size = new System.Drawing.Size(1379, 37);
            this.radLabel34.TabIndex = 9;
            this.radLabel34.Text = "Cancelled Bookings";
            this.radLabel34.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_Quotations
            // 
            this.Pg_Quotations.Controls.Add(this.grdQuotations);
            this.Pg_Quotations.Controls.Add(this.radPanel2);
            this.Pg_Quotations.Controls.Add(this.radLabel11);
            this.Pg_Quotations.ItemSize = new System.Drawing.SizeF(91F, 29F);
            this.Pg_Quotations.Location = new System.Drawing.Point(12, 12);
            this.Pg_Quotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Quotations.Name = "Pg_Quotations";
            this.Pg_Quotations.Size = new System.Drawing.Size(1375, 844);
            this.Pg_Quotations.Text = "Quotations";
            // 
            // grdQuotations
            // 
            this.grdQuotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuotations.Location = new System.Drawing.Point(0, 79);
            this.grdQuotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdQuotations.MasterTemplate.ViewDefinition = tableViewDefinition18;
            this.grdQuotations.Name = "grdQuotations";
            this.grdQuotations.Size = new System.Drawing.Size(1375, 765);
            this.grdQuotations.TabIndex = 111;
            this.grdQuotations.Text = "myGridView1";
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel2.Controls.Add(this.btnShowAllQuotation);
            this.radPanel2.Controls.Add(this.dtpToQuotation);
            this.radPanel2.Controls.Add(this.label6);
            this.radPanel2.Controls.Add(this.dtpFromQuotation);
            this.radPanel2.Controls.Add(this.label7);
            this.radPanel2.Controls.Add(this.btnFindQuotations);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 37);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1375, 42);
            this.radPanel2.TabIndex = 113;
            // 
            // btnShowAllQuotation
            // 
            this.btnShowAllQuotation.Location = new System.Drawing.Point(496, 6);
            this.btnShowAllQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAllQuotation.Name = "btnShowAllQuotation";
            this.btnShowAllQuotation.Size = new System.Drawing.Size(90, 30);
            this.btnShowAllQuotation.TabIndex = 15;
            this.btnShowAllQuotation.Tag = "";
            this.btnShowAllQuotation.Text = "Show All ";
            this.btnShowAllQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAllQuotation.Click += new System.EventHandler(this.btnShowAllQuotation_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).Text = "Show All ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllQuotation.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dtpToQuotation
            // 
            this.dtpToQuotation.CustomFormat = "dd/MM/yyyy";
            this.dtpToQuotation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToQuotation.Location = new System.Drawing.Point(258, 6);
            this.dtpToQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToQuotation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToQuotation.Name = "dtpToQuotation";
            this.dtpToQuotation.Size = new System.Drawing.Size(119, 30);
            this.dtpToQuotation.TabIndex = 14;
            this.dtpToQuotation.TabStop = false;
            this.dtpToQuotation.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "To";
            // 
            // dtpFromQuotation
            // 
            this.dtpFromQuotation.CustomFormat = "dd/MM/yyyy";
            this.dtpFromQuotation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromQuotation.Location = new System.Drawing.Point(103, 7);
            this.dtpFromQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromQuotation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromQuotation.Name = "dtpFromQuotation";
            this.dtpFromQuotation.Size = new System.Drawing.Size(119, 30);
            this.dtpFromQuotation.TabIndex = 12;
            this.dtpFromQuotation.TabStop = false;
            this.dtpFromQuotation.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Date From";
            // 
            // btnFindQuotations
            // 
            this.btnFindQuotations.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFindQuotations.Location = new System.Drawing.Point(405, 6);
            this.btnFindQuotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindQuotations.Name = "btnFindQuotations";
            this.btnFindQuotations.Size = new System.Drawing.Size(69, 30);
            this.btnFindQuotations.TabIndex = 7;
            this.btnFindQuotations.Tag = "";
            this.btnFindQuotations.Text = "Find";
            this.btnFindQuotations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindQuotations.Click += new System.EventHandler(this.btnFindQuotations_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindQuotations.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel11
            // 
            this.radLabel11.AutoSize = false;
            this.radLabel11.BackColor = System.Drawing.Color.DimGray;
            this.radLabel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.ForeColor = System.Drawing.Color.White;
            this.radLabel11.Location = new System.Drawing.Point(0, 0);
            this.radLabel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(1375, 37);
            this.radLabel11.TabIndex = 112;
            this.radLabel11.Text = "Quotations";
            this.radLabel11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_RecentJobs
            // 
            this.Pg_RecentJobs.Controls.Add(this.tableLayoutPanel4);
            this.Pg_RecentJobs.Controls.Add(this.radLabel6);
            this.Pg_RecentJobs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pg_RecentJobs.ItemSize = new System.Drawing.SizeF(97F, 29F);
            this.Pg_RecentJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_RecentJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_RecentJobs.Name = "Pg_RecentJobs";
            this.Pg_RecentJobs.Size = new System.Drawing.Size(1379, 873);
            this.Pg_RecentJobs.Text = "Search Jobs";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1379, 836);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grdRecentJobs);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 338);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1373, 494);
            this.panel7.TabIndex = 0;
            // 
            // grdRecentJobs
            // 
            this.grdRecentJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecentJobs.Location = new System.Drawing.Point(0, 0);
            this.grdRecentJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdRecentJobs.MasterTemplate.ViewDefinition = tableViewDefinition19;
            this.grdRecentJobs.Name = "grdRecentJobs";
            this.grdRecentJobs.Size = new System.Drawing.Size(1373, 494);
            this.grdRecentJobs.TabIndex = 1;
            this.grdRecentJobs.Text = "myGridView3";
            this.grdRecentJobs.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdLister_CellDoubleClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblSearchResults);
            this.panel8.Controls.Add(this.chkAvailableRecordings);
            this.panel8.Controls.Add(this.radLabel32);
            this.panel8.Controls.Add(this.ddlCompanyVehicle);
            this.panel8.Controls.Add(this.txtTokenNo);
            this.panel8.Controls.Add(this.lblTokenNo);
            this.panel8.Controls.Add(this.radLabel30);
            this.panel8.Controls.Add(this.ddlBookingType);
            this.panel8.Controls.Add(this.txtPaymentRef);
            this.panel8.Controls.Add(this.radLabel29);
            this.panel8.Controls.Add(this.chkQuotation);
            this.panel8.Controls.Add(this.radLabel2);
            this.panel8.Controls.Add(this.ddlCompany);
            this.panel8.Controls.Add(this.ddlSearchDateType);
            this.panel8.Controls.Add(this.btnclearSearchFilter);
            this.panel8.Controls.Add(this.txtOrderNo);
            this.panel8.Controls.Add(this.radLabel10);
            this.panel8.Controls.Add(this.txtRefNumber);
            this.panel8.Controls.Add(this.radLabel9);
            this.panel8.Controls.Add(this.btnViewJob);
            this.panel8.Controls.Add(this.radLabel25);
            this.panel8.Controls.Add(this.ddlStatus);
            this.panel8.Controls.Add(this.radLabel24);
            this.panel8.Controls.Add(this.ddlDriver);
            this.panel8.Controls.Add(this.radLabel23);
            this.panel8.Controls.Add(this.ddlPaymentType);
            this.panel8.Controls.Add(this.txtMobileNo);
            this.panel8.Controls.Add(this.radLabel22);
            this.panel8.Controls.Add(this.txtPhoneNo);
            this.panel8.Controls.Add(this.radLabel21);
            this.panel8.Controls.Add(this.radLabel20);
            this.panel8.Controls.Add(this.ddlCust);
            this.panel8.Controls.Add(this.radLabel19);
            this.panel8.Controls.Add(this.ddlVehicleType);
            this.panel8.Controls.Add(this.opt_JOneWay);
            this.panel8.Controls.Add(this.opt_JReturnWay);
            this.panel8.Controls.Add(this.txtDestination);
            this.panel8.Controls.Add(this.radLabel18);
            this.panel8.Controls.Add(this.txtVia);
            this.panel8.Controls.Add(this.radLabel17);
            this.panel8.Controls.Add(this.txtPickup);
            this.panel8.Controls.Add(this.radLabel16);
            this.panel8.Controls.Add(this.dtp_RecentJobs_EndDate);
            this.panel8.Controls.Add(this.radLabel15);
            this.panel8.Controls.Add(this.dtp_recentJob_StartDate);
            this.panel8.Controls.Add(this.radLabel14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 4);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1373, 326);
            this.panel8.TabIndex = 1;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSearchResults.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.ForeColor = System.Drawing.Color.Red;
            this.lblSearchResults.Location = new System.Drawing.Point(0, 324);
            this.lblSearchResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(1373, 2);
            this.lblSearchResults.TabIndex = 245;
            this.lblSearchResults.Visible = false;
            // 
            // chkAvailableRecordings
            // 
            this.chkAvailableRecordings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAvailableRecordings.ForeColor = System.Drawing.Color.Red;
            this.chkAvailableRecordings.Location = new System.Drawing.Point(1184, 15);
            this.chkAvailableRecordings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAvailableRecordings.Name = "chkAvailableRecordings";
            this.chkAvailableRecordings.Size = new System.Drawing.Size(150, 18);
            this.chkAvailableRecordings.TabIndex = 244;
            this.chkAvailableRecordings.Text = "Available Recordings";
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel32.Location = new System.Drawing.Point(609, 175);
            this.radLabel32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(69, 19);
            this.radLabel32.TabIndex = 243;
            this.radLabel32.Text = "Vehicle No";
            // 
            // ddlCompanyVehicle
            // 
            this.ddlCompanyVehicle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompanyVehicle.Location = new System.Drawing.Point(709, 174);
            this.ddlCompanyVehicle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompanyVehicle.Name = "ddlCompanyVehicle";
            this.ddlCompanyVehicle.Size = new System.Drawing.Size(253, 21);
            this.ddlCompanyVehicle.TabIndex = 242;
            this.ddlCompanyVehicle.Enter += new System.EventHandler(this.ddlCompanyVehicle_Enter);
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNo.Location = new System.Drawing.Point(131, 228);
            this.txtTokenNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(170, 21);
            this.txtTokenNo.TabIndex = 241;
            this.txtTokenNo.TabStop = false;
            this.txtTokenNo.Visible = false;
            // 
            // lblTokenNo
            // 
            this.lblTokenNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenNo.Location = new System.Drawing.Point(26, 229);
            this.lblTokenNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTokenNo.Name = "lblTokenNo";
            this.lblTokenNo.Size = new System.Drawing.Size(57, 19);
            this.lblTokenNo.TabIndex = 240;
            this.lblTokenNo.Text = "Token #";
            this.lblTokenNo.Visible = false;
            // 
            // radLabel30
            // 
            this.radLabel30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel30.Location = new System.Drawing.Point(313, 146);
            this.radLabel30.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel30.Name = "radLabel30";
            this.radLabel30.Size = new System.Drawing.Size(87, 19);
            this.radLabel30.TabIndex = 239;
            this.radLabel30.Text = "Booking Type";
            // 
            // ddlBookingType
            // 
            this.ddlBookingType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBookingType.Location = new System.Drawing.Point(418, 144);
            this.ddlBookingType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlBookingType.Name = "ddlBookingType";
            this.ddlBookingType.Size = new System.Drawing.Size(173, 21);
            this.ddlBookingType.TabIndex = 238;
            // 
            // txtPaymentRef
            // 
            this.txtPaymentRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentRef.Location = new System.Drawing.Point(709, 145);
            this.txtPaymentRef.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPaymentRef.Name = "txtPaymentRef";
            this.txtPaymentRef.Size = new System.Drawing.Size(253, 21);
            this.txtPaymentRef.TabIndex = 237;
            this.txtPaymentRef.TabStop = false;
            // 
            // radLabel29
            // 
            this.radLabel29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel29.Location = new System.Drawing.Point(608, 143);
            this.radLabel29.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel29.Name = "radLabel29";
            this.radLabel29.Size = new System.Drawing.Size(86, 19);
            this.radLabel29.TabIndex = 236;
            this.radLabel29.Text = "Payment Ref.";
            // 
            // chkQuotation
            // 
            this.chkQuotation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQuotation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkQuotation.Location = new System.Drawing.Point(924, 12);
            this.chkQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkQuotation.Name = "chkQuotation";
            this.chkQuotation.Size = new System.Drawing.Size(116, 18);
            this.chkQuotation.TabIndex = 235;
            this.chkQuotation.Text = "With Quotation";
            this.chkQuotation.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(313, 180);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(54, 19);
            this.radLabel2.TabIndex = 234;
            this.radLabel2.Text = "Account";
            this.radLabel2.Click += new System.EventHandler(this.radLabel2_Click);
            // 
            // ddlCompany
            // 
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(418, 177);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(173, 21);
            this.ddlCompany.TabIndex = 233;
            // 
            // ddlSearchDateType
            // 
            this.ddlSearchDateType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchDateType.Location = new System.Drawing.Point(3, 6);
            this.ddlSearchDateType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSearchDateType.Name = "ddlSearchDateType";
            this.ddlSearchDateType.Size = new System.Drawing.Size(125, 21);
            this.ddlSearchDateType.TabIndex = 232;
            this.ddlSearchDateType.Text = "Booking Date";
            // 
            // btnclearSearchFilter
            // 
            this.btnclearSearchFilter.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.btnclearSearchFilter.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnclearSearchFilter.Location = new System.Drawing.Point(792, 229);
            this.btnclearSearchFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnclearSearchFilter.Name = "btnclearSearchFilter";
            this.btnclearSearchFilter.Size = new System.Drawing.Size(128, 62);
            this.btnclearSearchFilter.TabIndex = 231;
            this.btnclearSearchFilter.Text = "Clear Filter";
            this.btnclearSearchFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnclearSearchFilter.Click += new System.EventHandler(this.btnclearSearchFilter_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).Text = "Clear Filter";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(419, 212);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(170, 21);
            this.txtOrderNo.TabIndex = 230;
            this.txtOrderNo.TabStop = false;
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(314, 213);
            this.radLabel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(61, 19);
            this.radLabel10.TabIndex = 229;
            this.radLabel10.Text = "Order No";
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNumber.Location = new System.Drawing.Point(127, 196);
            this.txtRefNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(170, 21);
            this.txtRefNumber.TabIndex = 228;
            this.txtRefNumber.TabStop = false;
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(27, 197);
            this.radLabel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(82, 19);
            this.radLabel9.TabIndex = 227;
            this.radLabel9.Text = "Ref. Number";
            // 
            // btnViewJob
            // 
            this.btnViewJob.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnViewJob.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnViewJob.Location = new System.Drawing.Point(607, 226);
            this.btnViewJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewJob.Name = "btnViewJob";
            this.btnViewJob.Size = new System.Drawing.Size(128, 62);
            this.btnViewJob.TabIndex = 226;
            this.btnViewJob.Text = "View Jobs";
            this.btnViewJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewJob.Click += new System.EventHandler(this.radButton9_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).Text = "View Jobs";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel25
            // 
            this.radLabel25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel25.Location = new System.Drawing.Point(608, 112);
            this.radLabel25.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel25.Name = "radLabel25";
            this.radLabel25.Size = new System.Drawing.Size(44, 19);
            this.radLabel25.TabIndex = 225;
            this.radLabel25.Text = "Status";
            // 
            // ddlStatus
            // 
            this.ddlStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStatus.Location = new System.Drawing.Point(709, 111);
            this.ddlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(142, 21);
            this.ddlStatus.TabIndex = 224;
            // 
            // radLabel24
            // 
            this.radLabel24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel24.Location = new System.Drawing.Point(608, 79);
            this.radLabel24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel24.Name = "radLabel24";
            this.radLabel24.Size = new System.Drawing.Size(42, 19);
            this.radLabel24.TabIndex = 223;
            this.radLabel24.Text = "Driver";
            // 
            // ddlDriver
            // 
            this.ddlDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriver.Location = new System.Drawing.Point(709, 76);
            this.ddlDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDriver.Name = "ddlDriver";
            this.ddlDriver.Size = new System.Drawing.Size(173, 21);
            this.ddlDriver.TabIndex = 222;
            // 
            // radLabel23
            // 
            this.radLabel23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel23.Location = new System.Drawing.Point(608, 44);
            this.radLabel23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(58, 19);
            this.radLabel23.TabIndex = 221;
            this.radLabel23.Text = "Payment";
            // 
            // ddlPaymentType
            // 
            this.ddlPaymentType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPaymentType.Location = new System.Drawing.Point(709, 42);
            this.ddlPaymentType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlPaymentType.Name = "ddlPaymentType";
            this.ddlPaymentType.Size = new System.Drawing.Size(142, 21);
            this.ddlPaymentType.TabIndex = 220;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(418, 112);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(173, 21);
            this.txtMobileNo.TabIndex = 219;
            this.txtMobileNo.TabStop = false;
            // 
            // radLabel22
            // 
            this.radLabel22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel22.Location = new System.Drawing.Point(314, 113);
            this.radLabel22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel22.Name = "radLabel22";
            this.radLabel22.Size = new System.Drawing.Size(65, 19);
            this.radLabel22.TabIndex = 218;
            this.radLabel22.Text = "Mobile No";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(418, 79);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(173, 21);
            this.txtPhoneNo.TabIndex = 217;
            this.txtPhoneNo.TabStop = false;
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(314, 80);
            this.radLabel21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(64, 19);
            this.radLabel21.TabIndex = 216;
            this.radLabel21.Text = "Phone No";
            // 
            // radLabel20
            // 
            this.radLabel20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel20.Location = new System.Drawing.Point(313, 44);
            this.radLabel20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel20.Name = "radLabel20";
            this.radLabel20.Size = new System.Drawing.Size(63, 19);
            this.radLabel20.TabIndex = 215;
            this.radLabel20.Text = "Customer";
            // 
            // ddlCust
            // 
            this.ddlCust.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCust.Location = new System.Drawing.Point(418, 42);
            this.ddlCust.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCust.Name = "ddlCust";
            this.ddlCust.Size = new System.Drawing.Size(173, 21);
            this.ddlCust.TabIndex = 214;
            // 
            // radLabel19
            // 
            this.radLabel19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel19.Location = new System.Drawing.Point(26, 44);
            this.radLabel19.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Size = new System.Drawing.Size(82, 19);
            this.radLabel19.TabIndex = 213;
            this.radLabel19.Text = "Vehicle Type";
            // 
            // ddlVehicleType
            // 
            this.ddlVehicleType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleType.Location = new System.Drawing.Point(127, 42);
            this.ddlVehicleType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlVehicleType.Name = "ddlVehicleType";
            this.ddlVehicleType.Size = new System.Drawing.Size(134, 21);
            this.ddlVehicleType.TabIndex = 212;
            // 
            // opt_JOneWay
            // 
            this.opt_JOneWay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opt_JOneWay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_JOneWay.Location = new System.Drawing.Point(675, 11);
            this.opt_JOneWay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt_JOneWay.Name = "opt_JOneWay";
            this.opt_JOneWay.Size = new System.Drawing.Size(75, 19);
            this.opt_JOneWay.TabIndex = 211;
            this.opt_JOneWay.Text = "One Way";
            this.opt_JOneWay.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // opt_JReturnWay
            // 
            this.opt_JReturnWay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_JReturnWay.Location = new System.Drawing.Point(777, 11);
            this.opt_JReturnWay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt_JReturnWay.Name = "opt_JReturnWay";
            this.opt_JReturnWay.Size = new System.Drawing.Size(111, 19);
            this.opt_JReturnWay.TabIndex = 210;
            this.opt_JReturnWay.Text = "Return Journey";
            // 
            // txtDestination
            // 
            this.txtDestination.AutoSize = false;
            this.txtDestination.BackColor = System.Drawing.Color.White;
            this.txtDestination.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(127, 138);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDestination.Multiline = true;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(170, 50);
            this.txtDestination.TabIndex = 209;
            this.txtDestination.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtDestination.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel18
            // 
            this.radLabel18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.Location = new System.Drawing.Point(3, 138);
            this.radLabel18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(107, 19);
            this.radLabel18.TabIndex = 208;
            this.radLabel18.Text = "Destination Point";
            // 
            // txtVia
            // 
            this.txtVia.AutoSize = false;
            this.txtVia.BackColor = System.Drawing.Color.White;
            this.txtVia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVia.Location = new System.Drawing.Point(972, 42);
            this.txtVia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVia.Multiline = true;
            this.txtVia.Name = "txtVia";
            this.txtVia.Size = new System.Drawing.Size(170, 50);
            this.txtVia.TabIndex = 207;
            this.txtVia.TabStop = false;
            this.txtVia.Visible = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtVia.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel17
            // 
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.Location = new System.Drawing.Point(894, 42);
            this.radLabel17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(59, 19);
            this.radLabel17.TabIndex = 206;
            this.radLabel17.Text = "Via Point";
            this.radLabel17.Visible = false;
            // 
            // txtPickup
            // 
            this.txtPickup.AutoSize = false;
            this.txtPickup.BackColor = System.Drawing.Color.White;
            this.txtPickup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPickup.Location = new System.Drawing.Point(127, 79);
            this.txtPickup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPickup.Multiline = true;
            this.txtPickup.Name = "txtPickup";
            this.txtPickup.Size = new System.Drawing.Size(170, 50);
            this.txtPickup.TabIndex = 205;
            this.txtPickup.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtPickup.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.Location = new System.Drawing.Point(28, 79);
            this.radLabel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(79, 19);
            this.radLabel16.TabIndex = 204;
            this.radLabel16.Text = "Pickup Point";
            // 
            // dtp_RecentJobs_EndDate
            // 
            this.dtp_RecentJobs_EndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_RecentJobs_EndDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_RecentJobs_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_RecentJobs_EndDate.Location = new System.Drawing.Point(463, 9);
            this.dtp_RecentJobs_EndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_RecentJobs_EndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_RecentJobs_EndDate.Name = "dtp_RecentJobs_EndDate";
            this.dtp_RecentJobs_EndDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_RecentJobs_EndDate.Size = new System.Drawing.Size(164, 21);
            this.dtp_RecentJobs_EndDate.TabIndex = 203;
            this.dtp_RecentJobs_EndDate.TabStop = false;
            this.dtp_RecentJobs_EndDate.Value = null;
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(391, 10);
            this.radLabel15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(61, 19);
            this.radLabel15.TabIndex = 202;
            this.radLabel15.Text = "End Date";
            // 
            // dtp_recentJob_StartDate
            // 
            this.dtp_recentJob_StartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_recentJob_StartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_recentJob_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_recentJob_StartDate.Location = new System.Drawing.Point(209, 9);
            this.dtp_recentJob_StartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_recentJob_StartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_recentJob_StartDate.Name = "dtp_recentJob_StartDate";
            this.dtp_recentJob_StartDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_recentJob_StartDate.Size = new System.Drawing.Size(175, 21);
            this.dtp_recentJob_StartDate.TabIndex = 201;
            this.dtp_recentJob_StartDate.TabStop = false;
            this.dtp_recentJob_StartDate.Value = null;
            // 
            // radLabel14
            // 
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(129, 10);
            this.radLabel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(67, 19);
            this.radLabel14.TabIndex = 200;
            this.radLabel14.Text = "Start Date";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = false;
            this.radLabel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.radLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.ForeColor = System.Drawing.Color.White;
            this.radLabel6.Location = new System.Drawing.Point(0, 0);
            this.radLabel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(1379, 37);
            this.radLabel6.TabIndex = 7;
            this.radLabel6.Text = "Search Jobs";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_DrvBookingStats
            // 
            this.Pg_DrvBookingStats.Controls.Add(this.pnlChart);
            this.Pg_DrvBookingStats.Controls.Add(this.radLabel5);
            this.Pg_DrvBookingStats.ItemSize = new System.Drawing.SizeF(156F, 29F);
            this.Pg_DrvBookingStats.Location = new System.Drawing.Point(12, 12);
            this.Pg_DrvBookingStats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_DrvBookingStats.Name = "Pg_DrvBookingStats";
            this.Pg_DrvBookingStats.Size = new System.Drawing.Size(1375, 853);
            this.Pg_DrvBookingStats.Text = "Driver Booking Stats";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.splitContainer1);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 37);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1375, 816);
            this.pnlChart.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdStats);
            this.splitContainer1.Panel1.Controls.Add(this.pnlStatsHeader);
            this.splitContainer1.Size = new System.Drawing.Size(1375, 816);
            this.splitContainer1.SplitterDistance = 587;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 9;
            // 
            // grdStats
            // 
            this.grdStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStats.Location = new System.Drawing.Point(0, 108);
            this.grdStats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdStats.MasterTemplate.ViewDefinition = tableViewDefinition20;
            this.grdStats.Name = "grdStats";
            this.grdStats.Size = new System.Drawing.Size(587, 708);
            this.grdStats.TabIndex = 1;
            this.grdStats.Text = "myGridView4";
            // 
            // pnlStatsHeader
            // 
            this.pnlStatsHeader.Controls.Add(this.optToday);
            this.pnlStatsHeader.Controls.Add(this.pnlMonthWise);
            this.pnlStatsHeader.Controls.Add(this.optMonthWise);
            this.pnlStatsHeader.Controls.Add(this.optDriverWise);
            this.pnlStatsHeader.Controls.Add(this.btnPreview);
            this.pnlStatsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlStatsHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatsHeader.Name = "pnlStatsHeader";
            this.pnlStatsHeader.Size = new System.Drawing.Size(587, 108);
            this.pnlStatsHeader.TabIndex = 2;
            // 
            // optToday
            // 
            this.optToday.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optToday.Location = new System.Drawing.Point(315, 17);
            this.optToday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optToday.Name = "optToday";
            this.optToday.Size = new System.Drawing.Size(68, 22);
            this.optToday.TabIndex = 19;
            this.optToday.Text = "Today";
            this.optToday.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optMonthWise_ToggleStateChanged);
            // 
            // pnlMonthWise
            // 
            this.pnlMonthWise.Controls.Add(this.label1);
            this.pnlMonthWise.Controls.Add(this.dtpStatsFromDate);
            this.pnlMonthWise.Controls.Add(this.label2);
            this.pnlMonthWise.Controls.Add(this.dtpStatsTillDate);
            this.pnlMonthWise.Enabled = false;
            this.pnlMonthWise.Location = new System.Drawing.Point(3, 50);
            this.pnlMonthWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMonthWise.Name = "pnlMonthWise";
            this.pnlMonthWise.Size = new System.Drawing.Size(419, 47);
            this.pnlMonthWise.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dtpStatsFromDate
            // 
            this.dtpStatsFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStatsFromDate.Location = new System.Drawing.Point(44, 11);
            this.dtpStatsFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStatsFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsFromDate.Name = "dtpStatsFromDate";
            this.dtpStatsFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsFromDate.Size = new System.Drawing.Size(173, 21);
            this.dtpStatsFromDate.TabIndex = 1;
            this.dtpStatsFromDate.TabStop = false;
            this.dtpStatsFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Till";
            // 
            // dtpStatsTillDate
            // 
            this.dtpStatsTillDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStatsTillDate.Location = new System.Drawing.Point(246, 11);
            this.dtpStatsTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStatsTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsTillDate.Name = "dtpStatsTillDate";
            this.dtpStatsTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsTillDate.Size = new System.Drawing.Size(173, 21);
            this.dtpStatsTillDate.TabIndex = 3;
            this.dtpStatsTillDate.TabStop = false;
            this.dtpStatsTillDate.Value = null;
            // 
            // optMonthWise
            // 
            this.optMonthWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMonthWise.Location = new System.Drawing.Point(203, 17);
            this.optMonthWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optMonthWise.Name = "optMonthWise";
            this.optMonthWise.Size = new System.Drawing.Size(85, 22);
            this.optMonthWise.TabIndex = 17;
            this.optMonthWise.Text = "Monthly";
            this.optMonthWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optMonthWise_ToggleStateChanged);
            // 
            // optDriverWise
            // 
            this.optDriverWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optDriverWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDriverWise.Location = new System.Drawing.Point(10, 17);
            this.optDriverWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDriverWise.Name = "optDriverWise";
            this.optDriverWise.Size = new System.Drawing.Size(156, 22);
            this.optDriverWise.TabIndex = 16;
            this.optDriverWise.Text = "Login Driver Only";
            this.optDriverWise.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(429, 30);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(155, 68);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPreview.GetChildAt(0))).Text = "Preview";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel5
            // 
            this.radLabel5.AutoSize = false;
            this.radLabel5.BackColor = System.Drawing.Color.MediumOrchid;
            this.radLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.White;
            this.radLabel5.Location = new System.Drawing.Point(0, 0);
            this.radLabel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(1375, 37);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "Driver Booking Stats";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_Stats
            // 
            this.Pg_Stats.Location = new System.Drawing.Point(0, 0);
            this.Pg_Stats.Name = "Pg_Stats";
            this.Pg_Stats.Size = new System.Drawing.Size(200, 100);
            // 
            // radPanel8
            // 
            this.radPanel8.Controls.Add(this.radLabel43);
            this.radPanel8.Controls.Add(this.radLabel44);
            this.radPanel8.Controls.Add(this.radLabel45);
            this.radPanel8.Controls.Add(this.radLabel46);
            this.radPanel8.Controls.Add(this.radLabel47);
            this.radPanel8.Controls.Add(this.radLabel48);
            this.radPanel8.Controls.Add(this.radLabel49);
            this.radPanel8.Controls.Add(this.radRadioButton1);
            this.radPanel8.Controls.Add(this.radRadioButton2);
            this.radPanel8.Controls.Add(this.radLabel50);
            this.radPanel8.Controls.Add(this.radLabel51);
            this.radPanel8.Controls.Add(this.radLabel52);
            this.radPanel8.Controls.Add(this.radLabel53);
            this.radPanel8.Controls.Add(this.radLabel54);
            this.radPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel8.Location = new System.Drawing.Point(3, 3);
            this.radPanel8.Name = "radPanel8";
            this.radPanel8.Size = new System.Drawing.Size(194, 269);
            this.radPanel8.TabIndex = 1;
            // 
            // radLabel43
            // 
            this.radLabel43.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel43.Location = new System.Drawing.Point(521, 112);
            this.radLabel43.Name = "radLabel43";
            this.radLabel43.Size = new System.Drawing.Size(44, 19);
            this.radLabel43.TabIndex = 225;
            this.radLabel43.Text = "Status";
            // 
            // radLabel44
            // 
            this.radLabel44.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel44.Location = new System.Drawing.Point(521, 85);
            this.radLabel44.Name = "radLabel44";
            this.radLabel44.Size = new System.Drawing.Size(42, 19);
            this.radLabel44.TabIndex = 223;
            this.radLabel44.Text = "Driver";
            // 
            // radLabel45
            // 
            this.radLabel45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel45.Location = new System.Drawing.Point(521, 57);
            this.radLabel45.Name = "radLabel45";
            this.radLabel45.Size = new System.Drawing.Size(58, 19);
            this.radLabel45.TabIndex = 221;
            this.radLabel45.Text = "Payment";
            // 
            // radLabel46
            // 
            this.radLabel46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel46.Location = new System.Drawing.Point(269, 113);
            this.radLabel46.Name = "radLabel46";
            this.radLabel46.Size = new System.Drawing.Size(65, 19);
            this.radLabel46.TabIndex = 218;
            this.radLabel46.Text = "Mobile No";
            // 
            // radLabel47
            // 
            this.radLabel47.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel47.Location = new System.Drawing.Point(269, 86);
            this.radLabel47.Name = "radLabel47";
            this.radLabel47.Size = new System.Drawing.Size(64, 19);
            this.radLabel47.TabIndex = 216;
            this.radLabel47.Text = "Phone No";
            // 
            // radLabel48
            // 
            this.radLabel48.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel48.Location = new System.Drawing.Point(268, 57);
            this.radLabel48.Name = "radLabel48";
            this.radLabel48.Size = new System.Drawing.Size(63, 19);
            this.radLabel48.TabIndex = 215;
            this.radLabel48.Text = "Customer";
            // 
            // radLabel49
            // 
            this.radLabel49.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel49.Location = new System.Drawing.Point(22, 57);
            this.radLabel49.Name = "radLabel49";
            this.radLabel49.Size = new System.Drawing.Size(82, 19);
            this.radLabel49.TabIndex = 213;
            this.radLabel49.Text = "Vehicle Type";
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radRadioButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton1.Location = new System.Drawing.Point(521, 30);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(75, 19);
            this.radRadioButton1.TabIndex = 211;
            this.radRadioButton1.Text = "One Way";
            this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton2.Location = new System.Drawing.Point(603, 30);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(111, 19);
            this.radRadioButton2.TabIndex = 210;
            this.radRadioButton2.Text = "Return Journey";
            // 
            // radLabel50
            // 
            this.radLabel50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel50.Location = new System.Drawing.Point(3, 179);
            this.radLabel50.Name = "radLabel50";
            this.radLabel50.Size = new System.Drawing.Size(107, 19);
            this.radLabel50.TabIndex = 208;
            this.radLabel50.Text = "Destination Point";
            // 
            // radLabel51
            // 
            this.radLabel51.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel51.Location = new System.Drawing.Point(42, 132);
            this.radLabel51.Name = "radLabel51";
            this.radLabel51.Size = new System.Drawing.Size(59, 19);
            this.radLabel51.TabIndex = 206;
            this.radLabel51.Text = "Via Point";
            // 
            // radLabel52
            // 
            this.radLabel52.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel52.Location = new System.Drawing.Point(24, 85);
            this.radLabel52.Name = "radLabel52";
            this.radLabel52.Size = new System.Drawing.Size(79, 19);
            this.radLabel52.TabIndex = 204;
            this.radLabel52.Text = "Pickup Point";
            // 
            // radLabel53
            // 
            this.radLabel53.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel53.Location = new System.Drawing.Point(268, 29);
            this.radLabel53.Name = "radLabel53";
            this.radLabel53.Size = new System.Drawing.Size(61, 19);
            this.radLabel53.TabIndex = 202;
            this.radLabel53.Text = "End Date";
            // 
            // radLabel54
            // 
            this.radLabel54.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel54.Location = new System.Drawing.Point(37, 29);
            this.radLabel54.Name = "radLabel54";
            this.radLabel54.Size = new System.Drawing.Size(67, 19);
            this.radLabel54.TabIndex = 200;
            this.radLabel54.Text = "Start Date";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Location = new System.Drawing.Point(0, 0);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(200, 100);
            this.radPageViewPage1.Text = "radPageViewPage1";
            // 
            // timer_WebBooking
            // 
            this.timer_WebBooking.Interval = 1000;
            // 
            // tmrAlert
            // 
            this.tmrAlert.Interval = 50;
            this.tmrAlert.Tick += new System.EventHandler(this.tmrAlert_Tick);
            // 
            // timer_Lic
            // 
            this.timer_Lic.Enabled = true;
            this.timer_Lic.Interval = 21600000;
            this.timer_Lic.Tick += new System.EventHandler(this.timer_Lic_Tick);
            // 
            // frmBookingDashBoard
            // 
            this.AllowDrop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 960);
            this.Controls.Add(this.radPageView1);
            this.FormTitle = "DashBoard";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBookingDashBoard";
            this.Text = "DashBoard";
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.radPageView1, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.Pg_PendingJobs.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel10)).EndInit();
            this.radPanel10.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOnPlotDrivers)).EndInit();
            this.pnlOnPlotDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOnPlotDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverPricePlot)).EndInit();
            this.pnlDriverWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting)).EndInit();
            this.pnlDriverOnBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs)).EndInit();
            this.grdPendingJobs.ResumeLayout(false);
            this.grdPendingJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActions)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShowDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintJobInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDespatchJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radLabel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNotification)).EndInit();
            this.pnlNotification.ResumeLayout(false);
            this.pnlNotification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRentPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLostProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideMap)).EndInit();
            this.Pg_PreBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompanyPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDatePreBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDatePreBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.radLabel3.ResumeLayout(false);
            this.radLabel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optSortPickupDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortDriver)).EndInit();
            this.Pg_AllJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).EndInit();
            this.radPanel9.ResumeLayout(false);
            this.radPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentShowAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassengerRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDateRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDateRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecentColumn)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.Pg_NoShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).EndInit();
            this.Pg_Cancelled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel34)).EndInit();
            this.Pg_Quotations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            this.Pg_RecentJobs.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel8)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailableRecordings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTokenNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTokenNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchDateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclearSearchFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JOneWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JReturnWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_RecentJobs_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_recentJob_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.Pg_DrvBookingStats.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStats.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats)).EndInit();
            this.pnlStatsHeader.ResumeLayout(false);
            this.pnlStatsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optToday)).EndInit();
            this.pnlMonthWise.ResumeLayout(false);
            this.pnlMonthWise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optMonthWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDriverWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).EndInit();
            this.radPanel8.ResumeLayout(false);
            this.radPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel54)).EndInit();
            this.ResumeLayout(false);

        }




        private void InitializeComponentLayout2()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition9 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition10 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddlSubCompanyPreBooking = new Telerik.WinControls.UI.RadDropDownList();
            this.Pg_Stats = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPanel8 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel43 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel44 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel45 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel46 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel47 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel48 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel49 = new Telerik.WinControls.UI.RadLabel();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel50 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel51 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel52 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel53 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel54 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.timer_WebBooking = new System.Windows.Forms.Timer(this.components);
            this.tmrAlert = new System.Windows.Forms.Timer(this.components);
            this.timer_Lic = new System.Windows.Forms.Timer(this.components);
            this.pnlDriverOnBoard = new System.Windows.Forms.Panel();
            this.grdOnBoardDriver = new Telerik.WinControls.UI.RadGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDriverWaiting = new System.Windows.Forms.Panel();
            this.grdDriverWaiting = new Telerik.WinControls.UI.RadGridView();
            this.lblDriverWaiting = new System.Windows.Forms.Label();
            this.panel2 = new Telerik.WinControls.UI.RadPanel();
            this.grdDriverPricePlot = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlOnPlotDrivers = new Telerik.WinControls.UI.RadPanel();
            this.ddlSubCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.lblOnPlot = new System.Windows.Forms.Label();
            this.grdOnPlotDrivers = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.Pg_PendingJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdPendingJobs = new Telerik.WinControls.UI.RadGridView();
            this.lst_cdr = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new Telerik.WinControls.UI.RadPanel();
            this.pnlActions = new Telerik.WinControls.UI.RadPanel();
            this.btnRecover = new Telerik.WinControls.UI.RadButton();
            this.chkShowAuthorization = new System.Windows.Forms.CheckBox();
            this.btnOption = new Telerik.WinControls.UI.RadSplitButton();
            this.btnAddLostProperty = new Telerik.WinControls.UI.RadMenuItem();
            this.btnLostPropertyList = new Telerik.WinControls.UI.RadMenuItem();
            this.btnComplaints = new Telerik.WinControls.UI.RadMenuItem();
            this.btnAirportArrivals_new = new Telerik.WinControls.UI.RadMenuItem();
            this.btnHideMap_new = new Telerik.WinControls.UI.RadMenuItem();
            this.btnHideBooking_new = new Telerik.WinControls.UI.RadMenuItem();
            this.chkEnableAutoDespatch = new Telerik.WinControls.UI.RadMenuItem();
            this.chkEnableBidding = new Telerik.WinControls.UI.RadMenuItem();
            this.chkEnableAutoDespatchNormalMode = new Telerik.WinControls.UI.RadRadioButtonElement();
            this.chkEnableAutoDespatchQuiteMode = new Telerik.WinControls.UI.RadRadioButtonElement();
            this.chkEnableAutoDespatchBusyMode = new Telerik.WinControls.UI.RadRadioButtonElement();
            this.btnSMS = new Telerik.WinControls.UI.RadSplitButton();
            this.btnwritesms = new Telerik.WinControls.UI.RadMenuItem();
            this.btnInbox = new Telerik.WinControls.UI.RadMenuItem();
            this.btnPDAInbox = new Telerik.WinControls.UI.RadMenuItem();
            this.btnMessageAllDrivers = new Telerik.WinControls.UI.RadMenuItem();
            this.optSortTodayPickup = new Telerik.WinControls.UI.RadRadioButton();
            this.optSortTodayDriver = new Telerik.WinControls.UI.RadRadioButton();
            this.chkShowAllocatedTodayJobs = new System.Windows.Forms.CheckBox();
            this.ddlShowDue = new Telerik.WinControls.UI.RadDropDownList();
            this.chkShowACJobs = new System.Windows.Forms.RadioButton();
            this.chkShowCashJobs = new System.Windows.Forms.RadioButton();
            this.ChkShowAllJobs = new System.Windows.Forms.RadioButton();
            this.btnPrintJobInfo = new Telerik.WinControls.UI.RadSplitButton();
            this.btnViewPrint = new Telerik.WinControls.UI.RadMenuItem();
            this.btnEmailPrint = new Telerik.WinControls.UI.RadMenuItem();
            this.btnEmail = new Telerik.WinControls.UI.RadButton();
            this.btnNewJob = new Telerik.WinControls.UI.RadButton();
            this.btnShowMap = new Telerik.WinControls.UI.RadButton();
            this.btnDespatchJob = new Telerik.WinControls.UI.RadButton();
            this.Pg_PreBookings = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdPreBookings = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.btnPrintSelected = new Telerik.WinControls.UI.RadButton();
            this.optSortPickupDate = new Telerik.WinControls.UI.RadRadioButton();
            this.optSortDriver = new Telerik.WinControls.UI.RadRadioButton();
            this.chkShowAllocatedJobs = new System.Windows.Forms.CheckBox();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnShowAllPreBooking = new Telerik.WinControls.UI.RadButton();
            this.dtpToDatePreBook = new UI.MyDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDatePreBook = new UI.MyDatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindPreBooking = new Telerik.WinControls.UI.RadButton();
            this.ddlColumns = new Telerik.WinControls.UI.RadDropDownList();
            this.Pg_RecentJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new Telerik.WinControls.UI.RadPanel();
            this.grdRecentJobs = new Telerik.WinControls.UI.RadGridView();
            this.panel8 = new Telerik.WinControls.UI.RadPanel();
            this.txtDestination = new Telerik.WinControls.UI.RadTextBox();
            this.lblSearchResults = new Telerik.WinControls.UI.RadLabel();
            this.chkAvailableRecordings = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCompanyVehicle = new Telerik.WinControls.UI.RadDropDownList();
            this.txtTokenNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblTokenNo = new Telerik.WinControls.UI.RadLabel();
            this.radLabel30 = new Telerik.WinControls.UI.RadLabel();
            this.ddlBookingType = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPaymentRef = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel29 = new Telerik.WinControls.UI.RadLabel();
            this.chkQuotation = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCompany = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlSearchDateType = new Telerik.WinControls.UI.RadDropDownList();
            this.btnclearSearchFilter = new Telerik.WinControls.UI.RadButton();
            this.txtOrderNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtRefNumber = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.btnViewJob = new Telerik.WinControls.UI.RadButton();
            this.radLabel25 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel24 = new Telerik.WinControls.UI.RadLabel();
            this.ddlDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.ddlPaymentType = new Telerik.WinControls.UI.RadDropDownList();


            this.radLabel35 = new Telerik.WinControls.UI.RadLabel();

            this.ddlJourneyType = new Telerik.WinControls.UI.RadDropDownList();


            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.lblEmail = new Telerik.WinControls.UI.RadLabel();

            this.txtMobileNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel22 = new Telerik.WinControls.UI.RadLabel();
            this.txtPhoneNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel20 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCust = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.ddlVehicleType = new Telerik.WinControls.UI.RadDropDownList();
            this.opt_JOneWay = new Telerik.WinControls.UI.RadRadioButton();
            this.opt_JReturnWay = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.txtVia = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.txtPickup = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_RecentJobs_EndDate = new UI.MyDatePicker();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_recentJob_StartDate = new UI.MyDatePicker();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.Pg_AllJobs = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdAllJobs = new Telerik.WinControls.UI.RadGridView();
            this.radPanel9 = new Telerik.WinControls.UI.RadPanel();
            this.btnRecentShowAll = new Telerik.WinControls.UI.RadButton();
            this.btnRecentFind = new Telerik.WinControls.UI.RadButton();
            this.txtPassengerRecent = new Telerik.WinControls.UI.RadTextBox();
            this.txtMobileRecent = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtPhoneRecent = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpToDateRecent = new UI.MyDatePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDateRecent = new UI.MyDatePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchRec = new Telerik.WinControls.UI.RadTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlBookingStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlRecentColumn = new Telerik.WinControls.UI.RadDropDownList();
            this.Pg_DrvBookingStats = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdStats = new Telerik.WinControls.UI.RadGridView();
            this.pnlStatsHeader = new System.Windows.Forms.Panel();
            this.optToday = new Telerik.WinControls.UI.RadRadioButton();
            this.pnlMonthWise = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStatsFromDate = new UI.MyDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStatsTillDate = new UI.MyDatePicker();
            this.optMonthWise = new Telerik.WinControls.UI.RadRadioButton();
            this.optDriverWise = new Telerik.WinControls.UI.RadRadioButton();
            this.btnPreview = new Telerik.WinControls.UI.RadButton();
            this.Pg_Quotations = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdQuotations = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnShowAllQuotation = new Telerik.WinControls.UI.RadButton();
            this.dtpToQuotation = new UI.MyDatePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFromQuotation = new UI.MyDatePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFindQuotations = new Telerik.WinControls.UI.RadButton();
            this.Pg_NoShow = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdNoShowJobs = new Telerik.WinControls.UI.RadGridView();
            this.Pg_Cancelled = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdCancelledJobs = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).BeginInit();
            this.radPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel54)).BeginInit();
            this.pnlDriverOnBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver.MasterTemplate)).BeginInit();
            this.pnlDriverWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverPricePlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOnPlotDrivers)).BeginInit();
            this.pnlOnPlotDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnPlotDrivers)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.Pg_PendingJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs.MasterTemplate)).BeginInit();
            this.grdPendingJobs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActions)).BeginInit();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShowDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintJobInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDespatchJob)).BeginInit();
            this.Pg_PreBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompanyPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortPickupDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDatePreBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDatePreBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindPreBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).BeginInit();
            this.Pg_RecentJobs.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel8)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailableRecordings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTokenNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTokenNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchDateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclearSearchFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentType)).BeginInit();


            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlJourneyType)).BeginInit();


            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JOneWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JReturnWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_RecentJobs_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_recentJob_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            this.Pg_AllJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).BeginInit();
            this.radPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentShowAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassengerRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDateRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDateRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecentColumn)).BeginInit();
            this.Pg_DrvBookingStats.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats.MasterTemplate)).BeginInit();
            this.pnlStatsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optToday)).BeginInit();
            this.pnlMonthWise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsTillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optMonthWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDriverWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).BeginInit();
            this.Pg_Quotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindQuotations)).BeginInit();
            this.Pg_NoShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs.MasterTemplate)).BeginInit();
            this.Pg_Cancelled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(807, 230);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(698, 362);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // Pg_Stats
            // 
            this.Pg_Stats.Location = new System.Drawing.Point(0, 0);
            this.Pg_Stats.Name = "Pg_Stats";
            this.Pg_Stats.Size = new System.Drawing.Size(200, 100);
            // 
            // ddlSubCompanyPreBooking
            // 
            this.ddlSubCompanyPreBooking.BackColor = System.Drawing.Color.White;
            this.ddlSubCompanyPreBooking.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ddlSubCompanyPreBooking.Location = new System.Drawing.Point(1000, 20);
            this.ddlSubCompanyPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompanyPreBooking.Name = "ddlSubCompanyPreBooking";
            this.ddlSubCompanyPreBooking.Size = new System.Drawing.Size(150, 22);
            this.ddlSubCompanyPreBooking.TabIndex = 223;
            // 
            // radPanel8
            // 
            this.radPanel8.Controls.Add(this.radLabel43);
            this.radPanel8.Controls.Add(this.radLabel44);
            this.radPanel8.Controls.Add(this.radLabel45);
            this.radPanel8.Controls.Add(this.radLabel46);
            this.radPanel8.Controls.Add(this.radLabel47);
            this.radPanel8.Controls.Add(this.radLabel48);
            this.radPanel8.Controls.Add(this.radLabel49);
            this.radPanel8.Controls.Add(this.radRadioButton1);
            this.radPanel8.Controls.Add(this.radRadioButton2);
            this.radPanel8.Controls.Add(this.radLabel50);
            this.radPanel8.Controls.Add(this.radLabel51);
            this.radPanel8.Controls.Add(this.radLabel52);
            this.radPanel8.Controls.Add(this.radLabel53);
            this.radPanel8.Controls.Add(this.radLabel54);
            this.radPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel8.Location = new System.Drawing.Point(3, 3);
            this.radPanel8.Name = "radPanel8";
            this.radPanel8.Size = new System.Drawing.Size(194, 269);
            this.radPanel8.TabIndex = 1;
            // 
            // radLabel43
            // 
            this.radLabel43.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel43.Location = new System.Drawing.Point(521, 112);
            this.radLabel43.Name = "radLabel43";
            this.radLabel43.Size = new System.Drawing.Size(44, 19);
            this.radLabel43.TabIndex = 225;
            this.radLabel43.Text = "Status";
            // 
            // radLabel44
            // 
            this.radLabel44.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel44.Location = new System.Drawing.Point(521, 85);
            this.radLabel44.Name = "radLabel44";
            this.radLabel44.Size = new System.Drawing.Size(42, 19);
            this.radLabel44.TabIndex = 223;
            this.radLabel44.Text = "Driver";
            // 
            // radLabel45
            // 
            this.radLabel45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel45.Location = new System.Drawing.Point(521, 57);
            this.radLabel45.Name = "radLabel45";
            this.radLabel45.Size = new System.Drawing.Size(58, 19);
            this.radLabel45.TabIndex = 221;
            this.radLabel45.Text = "Payment";
            // 
            // radLabel46
            // 
            this.radLabel46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel46.Location = new System.Drawing.Point(269, 113);
            this.radLabel46.Name = "radLabel46";
            this.radLabel46.Size = new System.Drawing.Size(65, 19);
            this.radLabel46.TabIndex = 218;
            this.radLabel46.Text = "Mobile No";
            // 
            // radLabel47
            // 
            this.radLabel47.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel47.Location = new System.Drawing.Point(269, 86);
            this.radLabel47.Name = "radLabel47";
            this.radLabel47.Size = new System.Drawing.Size(64, 19);
            this.radLabel47.TabIndex = 216;
            this.radLabel47.Text = "Phone No";
            // 
            // radLabel48
            // 
            this.radLabel48.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel48.Location = new System.Drawing.Point(268, 57);
            this.radLabel48.Name = "radLabel48";
            this.radLabel48.Size = new System.Drawing.Size(63, 19);
            this.radLabel48.TabIndex = 215;
            this.radLabel48.Text = "Customer";
            // 
            // radLabel49
            // 
            this.radLabel49.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel49.Location = new System.Drawing.Point(22, 57);
            this.radLabel49.Name = "radLabel49";
            this.radLabel49.Size = new System.Drawing.Size(82, 19);
            this.radLabel49.TabIndex = 213;
            this.radLabel49.Text = "Vehicle Type";
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radRadioButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton1.Location = new System.Drawing.Point(521, 30);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(75, 19);
            this.radRadioButton1.TabIndex = 211;
            this.radRadioButton1.Text = "One Way";
            this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRadioButton2.Location = new System.Drawing.Point(603, 30);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(111, 19);
            this.radRadioButton2.TabIndex = 210;
            this.radRadioButton2.Text = "Return Journey";
            // 
            // radLabel50
            // 
            this.radLabel50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel50.Location = new System.Drawing.Point(3, 179);
            this.radLabel50.Name = "radLabel50";
            this.radLabel50.Size = new System.Drawing.Size(107, 19);
            this.radLabel50.TabIndex = 208;
            this.radLabel50.Text = "Destination Point";
            // 
            // radLabel51
            // 
            this.radLabel51.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel51.Location = new System.Drawing.Point(42, 132);
            this.radLabel51.Name = "radLabel51";
            this.radLabel51.Size = new System.Drawing.Size(59, 19);
            this.radLabel51.TabIndex = 206;
            this.radLabel51.Text = "Via Point";
            // 
            // radLabel52
            // 
            this.radLabel52.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel52.Location = new System.Drawing.Point(24, 85);
            this.radLabel52.Name = "radLabel52";
            this.radLabel52.Size = new System.Drawing.Size(79, 19);
            this.radLabel52.TabIndex = 204;
            this.radLabel52.Text = "Pickup Point";
            // 
            // radLabel53
            // 
            this.radLabel53.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel53.Location = new System.Drawing.Point(268, 29);
            this.radLabel53.Name = "radLabel53";
            this.radLabel53.Size = new System.Drawing.Size(61, 19);
            this.radLabel53.TabIndex = 202;
            this.radLabel53.Text = "End Date";
            // 
            // radLabel54
            // 
            this.radLabel54.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel54.Location = new System.Drawing.Point(37, 29);
            this.radLabel54.Name = "radLabel54";
            this.radLabel54.Size = new System.Drawing.Size(67, 19);
            this.radLabel54.TabIndex = 200;
            this.radLabel54.Text = "Start Date";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Location = new System.Drawing.Point(0, 0);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(200, 100);
            this.radPageViewPage1.Text = "radPageViewPage1";
            // 
            // timer_WebBooking
            // 
            this.timer_WebBooking.Interval = 1000;
            // 
            // tmrAlert
            // 
            this.tmrAlert.Interval = 50;
            this.tmrAlert.Tick += new System.EventHandler(this.tmrAlert_Tick);
            // 
            // timer_Lic
            // 
            this.timer_Lic.Enabled = true;
            this.timer_Lic.Interval = 21600000;
            this.timer_Lic.Tick += new System.EventHandler(this.timer_Lic_Tick);
            // 
            // pnlDriverOnBoard
            // 
            this.pnlDriverOnBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriverOnBoard.Controls.Add(this.grdOnBoardDriver);
            this.pnlDriverOnBoard.Controls.Add(this.label3);
            this.pnlDriverOnBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverOnBoard.Location = new System.Drawing.Point(973, 4);
            this.pnlDriverOnBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDriverOnBoard.Name = "pnlDriverOnBoard";
            this.pnlDriverOnBoard.Size = new System.Drawing.Size(130, 300);
            this.pnlDriverOnBoard.TabIndex = 10;
            this.pnlDriverOnBoard.Visible = false;
            // 
            // grdOnBoardDriver
            // 
            this.grdOnBoardDriver.AutoSizeRows = true;
            this.grdOnBoardDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grdOnBoardDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOnBoardDriver.Location = new System.Drawing.Point(0, 25);
            this.grdOnBoardDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdOnBoardDriver.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdOnBoardDriver.Name = "grdOnBoardDriver";
            this.grdOnBoardDriver.Size = new System.Drawing.Size(128, 273);
            this.grdOnBoardDriver.TabIndex = 4;
            //  this.grdOnBoardDriver.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdOnBoardDriver_CellFormattingLayout2);
            ((Telerik.WinControls.UI.GridTableElement)(this.grdOnBoardDriver.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdOnBoardDriver.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Crimson;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "OnBoard";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDriverWaiting
            // 
            this.pnlDriverWaiting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDriverWaiting.Controls.Add(this.grdDriverWaiting);
            this.pnlDriverWaiting.Controls.Add(this.lblDriverWaiting);
            this.pnlDriverWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriverWaiting.Location = new System.Drawing.Point(1109, 4);
            this.pnlDriverWaiting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDriverWaiting.Name = "pnlDriverWaiting";
            this.pnlDriverWaiting.Size = new System.Drawing.Size(405, 300);
            this.pnlDriverWaiting.TabIndex = 11;
            // 
            // grdDriverWaiting
            // 
            this.grdDriverWaiting.AutoSizeRows = true;
            this.grdDriverWaiting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grdDriverWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDriverWaiting.Location = new System.Drawing.Point(0, 25);
            this.grdDriverWaiting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverWaiting.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdDriverWaiting.Name = "grdDriverWaiting";
            this.grdDriverWaiting.Size = new System.Drawing.Size(403, 273);
            this.grdDriverWaiting.TabIndex = 4;
            this.grdDriverWaiting.Text = "myGridView4";
            //  this.grdDriverWaiting.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.grdDriver_CellFormattingLayout2);
            ((Telerik.WinControls.UI.GridTableElement)(this.grdDriverWaiting.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdDriverWaiting.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // lblDriverWaiting
            // 
            this.lblDriverWaiting.BackColor = System.Drawing.Color.Green;
            this.lblDriverWaiting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDriverWaiting.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverWaiting.ForeColor = System.Drawing.Color.White;
            this.lblDriverWaiting.Location = new System.Drawing.Point(0, 0);
            this.lblDriverWaiting.Name = "lblDriverWaiting";
            this.lblDriverWaiting.Size = new System.Drawing.Size(403, 25);
            this.lblDriverWaiting.TabIndex = 5;
            this.lblDriverWaiting.Text = "Drivers Waiting";
            this.lblDriverWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdDriverPricePlot);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(973, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 300);
            this.panel2.TabIndex = 13;
            // 
            // grdDriverPricePlot
            // 
            this.grdDriverPricePlot.AllowUserToAddRows = false;
            this.grdDriverPricePlot.AllowUserToDeleteRows = false;
            this.grdDriverPricePlot.AllowUserToResizeColumns = false;
            this.grdDriverPricePlot.AllowUserToResizeRows = false;
            this.grdDriverPricePlot.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDriverPricePlot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDriverPricePlot.ColumnHeadersHeight = 24;
            this.grdDriverPricePlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDriverPricePlot.GridColor = System.Drawing.Color.Black;
            this.grdDriverPricePlot.Location = new System.Drawing.Point(0, 25);
            this.grdDriverPricePlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDriverPricePlot.Name = "grdDriverPricePlot";
            this.grdDriverPricePlot.RowHeadersVisible = false;
            this.grdDriverPricePlot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDriverPricePlot.RowTemplate.ReadOnly = true;
            this.grdDriverPricePlot.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDriverPricePlot.ShowCellErrors = false;
            this.grdDriverPricePlot.ShowRowErrors = false;
            this.grdDriverPricePlot.Size = new System.Drawing.Size(12, 283);
            this.grdDriverPricePlot.TabIndex = 10;
            this.grdDriverPricePlot.Text = "myGridView4";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DarkMagenta;
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1, 25);
            this.label20.TabIndex = 11;
            this.label20.Text = "Price Plot";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOnPlotDrivers
            // 
            this.pnlOnPlotDrivers.Controls.Add(this.ddlSubCompany);
            this.pnlOnPlotDrivers.Controls.Add(this.chkShowAuthorization);
            this.pnlOnPlotDrivers.Controls.Add(this.lblOnPlot);
            this.pnlOnPlotDrivers.Controls.Add(this.grdOnPlotDrivers);
            this.pnlOnPlotDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOnPlotDrivers.Location = new System.Drawing.Point(3, 4);
            this.pnlOnPlotDrivers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlOnPlotDrivers.Name = "pnlOnPlotDrivers";
            this.pnlOnPlotDrivers.Size = new System.Drawing.Size(964, 300);
            this.pnlOnPlotDrivers.TabIndex = 0;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlSubCompany.BackColor = System.Drawing.Color.White;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ddlSubCompany.Location = new System.Drawing.Point(712, 4);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(243, 18);
            this.ddlSubCompany.TabIndex = 222;
            this.ddlSubCompany.Visible = false;
            // 
            // lblOnPlot
            // 
            this.lblOnPlot.BackColor = System.Drawing.Color.DarkBlue;
            this.lblOnPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOnPlot.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnPlot.ForeColor = System.Drawing.Color.White;
            this.lblOnPlot.Location = new System.Drawing.Point(0, 0);
            this.lblOnPlot.Name = "lblOnPlot";
            this.lblOnPlot.Size = new System.Drawing.Size(964, 25);
            this.lblOnPlot.TabIndex = 12;
            this.lblOnPlot.Text = "Drivers OnPlot";
            this.lblOnPlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdOnPlotDrivers
            // 
            this.grdOnPlotDrivers.AllowUserToAddRows = false;
            this.grdOnPlotDrivers.AllowUserToDeleteRows = false;
            this.grdOnPlotDrivers.AllowUserToResizeColumns = false;
            this.grdOnPlotDrivers.AllowUserToResizeRows = false;
            this.grdOnPlotDrivers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grdOnPlotDrivers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdOnPlotDrivers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdOnPlotDrivers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOnPlotDrivers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;



            this.grdOnPlotDrivers.ColumnHeadersHeight = 24;
            this.grdOnPlotDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOnPlotDrivers.GridColor = System.Drawing.Color.Gainsboro;
            this.grdOnPlotDrivers.Location = new System.Drawing.Point(0, 0);
            this.grdOnPlotDrivers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdOnPlotDrivers.Name = "grdOnPlotDrivers";
            this.grdOnPlotDrivers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdOnPlotDrivers.RowHeadersVisible = false;
            this.grdOnPlotDrivers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            this.grdOnPlotDrivers.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdOnPlotDrivers.RowTemplate.ReadOnly = true;
            this.grdOnPlotDrivers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOnPlotDrivers.ShowCellErrors = false;
            this.grdOnPlotDrivers.ShowRowErrors = false;
            this.grdOnPlotDrivers.Size = new System.Drawing.Size(964, 300);
            this.grdOnPlotDrivers.TabIndex = 9;
            this.grdOnPlotDrivers.Text = "myGridView4";
            //    this.grdOnPlotDrivers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdOnPlotDrivers_CellFormattingLayout2);
            //     this.grdOnPlotDrivers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOnPlotDrivers_CellMouseEnter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel2.Controls.Add(this.pnlOnPlotDrivers, 0, 0);

            //      if(System.Diagnostics.Debugger.IsAttached==false)
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlDriverWaiting, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlDriverOnBoard, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1517, 308);
            this.tableLayoutPanel2.TabIndex = 210;
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.Pg_PendingJobs);
            this.radPageView1.Controls.Add(this.Pg_PreBookings);
            this.radPageView1.Controls.Add(this.Pg_RecentJobs);
            this.radPageView1.Controls.Add(this.Pg_AllJobs);
            this.radPageView1.Controls.Add(this.Pg_DrvBookingStats);
            this.radPageView1.Controls.Add(this.Pg_Quotations);
            this.radPageView1.Controls.Add(this.Pg_NoShow);
            this.radPageView1.Controls.Add(this.Pg_Cancelled);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPageView1.Location = new System.Drawing.Point(0, 346);
            this.radPageView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.Pg_PendingJobs;
            this.radPageView1.Size = new System.Drawing.Size(1517, 529);
            this.radPageView1.TabIndex = 211;
            this.radPageView1.Text = "Recent Jobs";
            this.radPageView1.ThemeName = "ControlDefault";
            this.radPageView1.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.radPageView1_SelectedPageChanging);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemSpacing = 10;
            // 
            // Pg_PendingJobs
            // 
            this.Pg_PendingJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.Pg_PendingJobs.Controls.Add(this.grdPendingJobs);
            this.Pg_PendingJobs.Controls.Add(this.tableLayoutPanel1);
            this.Pg_PendingJobs.Controls.Add(this.pnlActions);
            this.Pg_PendingJobs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pg_PendingJobs.ItemSize = new System.Drawing.SizeF(127F, 29F);
            this.Pg_PendingJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_PendingJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_PendingJobs.Name = "Pg_PendingJobs";
            this.Pg_PendingJobs.Size = new System.Drawing.Size(1496, 480);
            this.Pg_PendingJobs.Text = "Today\'s Booking";
            // 
            // grdPendingJobs
            // 
            this.grdPendingJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.grdPendingJobs.Controls.Add(this.lst_cdr);
            this.grdPendingJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPendingJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPendingJobs.Location = new System.Drawing.Point(0, 42);
            this.grdPendingJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdPendingJobs.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdPendingJobs.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdPendingJobs.Name = "grdPendingJobs";
            this.grdPendingJobs.Size = new System.Drawing.Size(1496, 438);
            this.grdPendingJobs.TabIndex = 6;
            this.grdPendingJobs.Text = "myGridView1";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdPendingJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdPendingJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // lst_cdr
            // 
            this.lst_cdr.FormattingEnabled = true;
            this.lst_cdr.ItemHeight = 16;
            this.lst_cdr.Location = new System.Drawing.Point(1354, 334);
            this.lst_cdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lst_cdr.Name = "lst_cdr";
            this.lst_cdr.Size = new System.Drawing.Size(139, 100);
            this.lst_cdr.TabIndex = 0;
            this.lst_cdr.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 442);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1514, 12);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1508, 3);
            this.panel1.TabIndex = 2;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.pnlActions.Controls.Add(this.btnRecover);
            this.pnlActions.Controls.Add(this.btnOption);
            this.pnlActions.Controls.Add(this.btnSMS);
            this.pnlActions.Controls.Add(this.optSortTodayPickup);
            this.pnlActions.Controls.Add(this.optSortTodayDriver);
            this.pnlActions.Controls.Add(this.chkShowAllocatedTodayJobs);
            this.pnlActions.Controls.Add(this.ddlShowDue);
            this.pnlActions.Controls.Add(this.chkShowACJobs);
            this.pnlActions.Controls.Add(this.chkShowCashJobs);
            this.pnlActions.Controls.Add(this.ChkShowAllJobs);
            this.pnlActions.Controls.Add(this.btnPrintJobInfo);
            this.pnlActions.Controls.Add(this.btnEmail);
            this.pnlActions.Controls.Add(this.btnNewJob);
            this.pnlActions.Controls.Add(this.btnShowMap);
            this.pnlActions.Controls.Add(this.btnDespatchJob);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 0);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1496, 42);
            this.pnlActions.TabIndex = 6;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).Width = 2F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BottomWidth = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor2 = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor3 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor4 = System.Drawing.Color.Beige;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.pnlActions.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            // 
            // btnRecover
            // 
            this.btnRecover.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            this.btnRecover.Location = new System.Drawing.Point(272, 5);
            this.btnRecover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(100, 30);
            this.btnRecover.TabIndex = 205;
            this.btnRecover.Text = "Recover Job";
            this.btnRecover.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.lc_movedown1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecover.GetChildAt(0))).Text = "Recover Job";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnRecover.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // chkShowAuthorization
            // 
            this.chkShowAuthorization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAuthorization.BackColor = System.Drawing.Color.DarkBlue;
            this.chkShowAuthorization.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAuthorization.ForeColor = System.Drawing.Color.Beige;
            this.chkShowAuthorization.Location = new System.Drawing.Point(408, 0);
            this.chkShowAuthorization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAuthorization.Name = "chkShowAuthorization";
            this.chkShowAuthorization.Size = new System.Drawing.Size(177, 25);
            this.chkShowAuthorization.TabIndex = 216;
            this.chkShowAuthorization.Text = "Show Authorization";
            this.chkShowAuthorization.UseVisualStyleBackColor = false;
            this.chkShowAuthorization.Visible = false;
            // 
            // btnOption
            // 
            //     this.btnOption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnOption.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnOption.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddLostProperty,
            this.btnLostPropertyList,
            this.btnComplaints,
            this.btnAirportArrivals_new,
            this.btnHideMap_new,
            this.btnHideBooking_new,
            this.chkEnableAutoDespatch,
            this.chkEnableBidding,
            this.chkEnableAutoDespatchNormalMode,
            this.chkEnableAutoDespatchQuiteMode,
            this.chkEnableAutoDespatchBusyMode});
            this.btnOption.Location = new System.Drawing.Point(930, 5);
            this.btnOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(112, 30);
            this.btnOption.TabIndex = 204;
            this.btnOption.Text = "Options";
            this.btnOption.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnOption.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnOption.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnOption.GetChildAt(0))).Text = "Options";
            //  ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnOption.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnOption.GetChildAt(0))).CanFocus = true;
            // ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnOption.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.OverflowPrimitive)(this.btnOption.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(3))).ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            //    ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnOption.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.ActionButtonElement)(this.btnOption.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));



            // 
            // btnAddLostProperty
            // 
            this.btnAddLostProperty.Name = "btnAddLostProperty";
            this.btnAddLostProperty.Text = "Add Lost Property";
            this.btnAddLostProperty.Click += new System.EventHandler(this.btnAddLostProperty_Click);
            // 
            // btnLostPropertyList
            // 
            this.btnLostPropertyList.Name = "btnLostPropertyList";
            this.btnLostPropertyList.Text = "Lost Property List";
            this.btnLostPropertyList.Click += new System.EventHandler(this.btnLostPropertyList_Click);
            // 
            // btnComplaints
            // 
            this.btnComplaints.Name = "btnComplaints";
            this.btnComplaints.Text = "Show Complaints";
            this.btnComplaints.Click += new System.EventHandler(this.btnComplaints_Click);
            // 
            // btnAirportArrivals_new
            // 
            this.btnAirportArrivals_new.Name = "btnAirportArrivals_new";
            this.btnAirportArrivals_new.Text = "Airport Arrivals";
            this.btnAirportArrivals_new.Click += new System.EventHandler(this.btnAirportArrivals_Click);
            // 
            // btnHideMap_new
            // 
            this.btnHideMap_new.Name = "btnHideMap_new";
            this.btnHideMap_new.Text = "Hide Drivers";
            this.btnHideMap_new.Click += new System.EventHandler(this.btnHideMap_Click);
            // 
            // btnHideBooking_new
            // 
            this.btnHideBooking_new.Name = "btnHideBooking_new";
            this.btnHideBooking_new.Text = "Hide Booking";
            this.btnHideBooking_new.Click += new System.EventHandler(this.btnHideBooking_Click);
            // 
            // chkEnableAutoDespatch
            // 
            this.chkEnableAutoDespatch.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.chkEnableAutoDespatch.CheckOnClick = true;
            this.chkEnableAutoDespatch.ClickMode = Telerik.WinControls.ClickMode.Press;
            this.chkEnableAutoDespatch.IsChecked = true;
            this.chkEnableAutoDespatch.Name = "chkEnableAutoDespatch";
            this.chkEnableAutoDespatch.Text = "AutoDespatch Mode";
            this.chkEnableAutoDespatch.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // chkEnableBidding
            // 
            this.chkEnableBidding.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.chkEnableBidding.CheckOnClick = true;
            this.chkEnableBidding.ClickMode = Telerik.WinControls.ClickMode.Press;
            this.chkEnableBidding.IsChecked = true;
            this.chkEnableBidding.Name = "chkEnableBidding";
            this.chkEnableBidding.Text = "Bidding  ";
            this.chkEnableBidding.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // chkEnableAutoDespatchNormalMode
            // 
            this.chkEnableAutoDespatchNormalMode.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEnableAutoDespatchNormalMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableAutoDespatchNormalMode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableAutoDespatchNormalMode.Name = "chkEnableAutoDespatchNormalMode";
            this.chkEnableAutoDespatchNormalMode.ReadOnly = false;
            this.chkEnableAutoDespatchNormalMode.Text = "NORMAL MODE";
            //  this.chkEnableAutoDespatchNormalMode.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            chkEnableAutoDespatchNormalMode.Visibility = AppVars.objPolicyConfiguration.AutoDespatchType.ToInt() == 5 ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            // 
            // chkEnableAutoDespatchQuiteMode
            // 
            this.chkEnableAutoDespatchQuiteMode.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEnableAutoDespatchQuiteMode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableAutoDespatchQuiteMode.ForeColor = System.Drawing.Color.Green;
            this.chkEnableAutoDespatchQuiteMode.Name = "chkEnableAutoDespatchQuiteMode";
            this.chkEnableAutoDespatchQuiteMode.ReadOnly = false;
            this.chkEnableAutoDespatchQuiteMode.Text = "QUITE MODE";

            chkEnableAutoDespatchQuiteMode.Visibility = chkEnableAutoDespatchNormalMode.Visibility;

            //  this.chkEnableAutoDespatchQuiteMode.Visibility = this.chkEnableAutoDespatchNormalMode.Visibility;
            //    chkEnableAutoDespatchQuiteMode.Visibility = chkEnableAutoDespatchNormalMode.Visibility;
            // 
            // chkEnableAutoDespatchBusyMode
            // 
            this.chkEnableAutoDespatchBusyMode.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEnableAutoDespatchBusyMode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableAutoDespatchBusyMode.ForeColor = System.Drawing.Color.Red;
            this.chkEnableAutoDespatchBusyMode.Name = "chkEnableAutoDespatchBusyMode";
            this.chkEnableAutoDespatchBusyMode.ReadOnly = false;
            this.chkEnableAutoDespatchBusyMode.Text = "BUSY MODE";
            this.chkEnableAutoDespatchBusyMode.Visibility = this.chkEnableAutoDespatchNormalMode.Visibility;



            if (AppVars.objPolicyConfiguration.AutoDespatchDriverCategoryPriority.ToInt() == 1)
            {
                chkEnableAutoDespatchNormalMode.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

            }
            else if (AppVars.objPolicyConfiguration.AutoDespatchDriverCategoryPriority.ToInt() == 2)
            {
                chkEnableAutoDespatchQuiteMode.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

            }
            else if (AppVars.objPolicyConfiguration.AutoDespatchDriverCategoryPriority.ToInt() == 3)
            {
                chkEnableAutoDespatchBusyMode.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

            }

            // 
            // btnSMS
            // 
            // this.btnSMS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSMS.Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            this.btnSMS.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSMS.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnwritesms,
            this.btnInbox,
            this.btnPDAInbox,
            this.btnMessageAllDrivers});
            this.btnSMS.Location = new System.Drawing.Point(815, 5);
            this.btnSMS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(111, 30);
            this.btnSMS.TabIndex = 204;
            this.btnSMS.Text = "SMS/Text";
            this.btnSMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Text = "SMS/Text";
            //  ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnSMS.GetChildAt(0))).CanFocus = true;
            //  ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            //((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            ((Telerik.WinControls.UI.ActionButtonElement)(this.btnSMS.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));



            // 
            // btnwritesms
            // 
            this.btnwritesms.Name = "btnwritesms";
            this.btnwritesms.Text = "Write SMS";
            this.btnwritesms.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // btnInbox
            // 
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Text = "Inbox";
            this.btnInbox.Click += new System.EventHandler(this.btnInbox_Click);
            // 
            // btnPDAInbox
            // 
            this.btnPDAInbox.Name = "btnPDAInbox";
            this.btnPDAInbox.Text = "PDA Inbox";
            this.btnPDAInbox.Click += new System.EventHandler(this.btnPDAInbox_Click);
            // 
            // btnMessageAllDrivers
            // 
            this.btnMessageAllDrivers.Name = "btnMessageAllDrivers";
            this.btnMessageAllDrivers.Text = "Message All Drivers";
            this.btnMessageAllDrivers.Click += new System.EventHandler(this.btnMessageAllDrivers_Click);
            // 
            // optSortTodayPickup
            // 
            this.optSortTodayPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortTodayPickup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.optSortTodayPickup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSortTodayPickup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortTodayPickup.ForeColor = System.Drawing.Color.Black;
            this.optSortTodayPickup.Location = new System.Drawing.Point(1327, 23);
            this.optSortTodayPickup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortTodayPickup.Name = "optSortTodayPickup";
            this.optSortTodayPickup.Size = new System.Drawing.Size(86, 16);
            this.optSortTodayPickup.TabIndex = 215;
            this.optSortTodayPickup.Text = "Pickup Date";
            this.optSortTodayPickup.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.optSortTodayPickup.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optSortTodayPickup_ToggleStateChanged);
            // 
            // optSortTodayDriver
            // 
            this.optSortTodayDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optSortTodayDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.optSortTodayDriver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortTodayDriver.Location = new System.Drawing.Point(1430, 23);
            this.optSortTodayDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortTodayDriver.Name = "optSortTodayDriver";
            this.optSortTodayDriver.Size = new System.Drawing.Size(54, 16);
            this.optSortTodayDriver.TabIndex = 214;
            this.optSortTodayDriver.Text = "Driver";
            // 
            // chkShowAllocatedTodayJobs
            // 
            this.chkShowAllocatedTodayJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllocatedTodayJobs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowAllocatedTodayJobs.ForeColor = System.Drawing.Color.Blue;
            this.chkShowAllocatedTodayJobs.Location = new System.Drawing.Point(1334, 5);
            this.chkShowAllocatedTodayJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAllocatedTodayJobs.Name = "chkShowAllocatedTodayJobs";
            this.chkShowAllocatedTodayJobs.Size = new System.Drawing.Size(164, 21);
            this.chkShowAllocatedTodayJobs.TabIndex = 211;
            this.chkShowAllocatedTodayJobs.Text = "Show Allocated Jobs";
            this.chkShowAllocatedTodayJobs.UseVisualStyleBackColor = true;
            this.chkShowAllocatedTodayJobs.CheckedChanged += new System.EventHandler(this.chkShowAllocatedTodayJobs_CheckedChanged);
            // 
            // ddlShowDue
            // 
            this.ddlShowDue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlShowDue.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlShowDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlShowDue.Location = new System.Drawing.Point(90, 1);
            this.ddlShowDue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlShowDue.Name = "ddlShowDue";
            this.ddlShowDue.Size = new System.Drawing.Size(90, 19);
            this.ddlShowDue.TabIndex = 210;
            this.ddlShowDue.Text = "No Filter";
            this.ddlShowDue.SelectedIndexChanging += new Telerik.WinControls.UI.Data.PositionChangingEventHandler(this.ddlShowDue_SelectedIndexChanging);
            // 
            // chkShowACJobs
            // 
            this.chkShowACJobs.AutoSize = true;
            this.chkShowACJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowACJobs.ForeColor = System.Drawing.Color.Red;
            this.chkShowACJobs.Location = new System.Drawing.Point(107, 25);
            this.chkShowACJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowACJobs.Name = "chkShowACJobs";
            this.chkShowACJobs.Size = new System.Drawing.Size(81, 18);
            this.chkShowACJobs.TabIndex = 209;
            this.chkShowACJobs.Text = "A/C Jobs";
            this.chkShowACJobs.UseVisualStyleBackColor = true;
            this.chkShowACJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // chkShowCashJobs
            // 
            this.chkShowCashJobs.AutoSize = true;
            this.chkShowCashJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowCashJobs.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkShowCashJobs.Location = new System.Drawing.Point(3, 25);
            this.chkShowCashJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowCashJobs.Name = "chkShowCashJobs";
            this.chkShowCashJobs.Size = new System.Drawing.Size(86, 18);
            this.chkShowCashJobs.TabIndex = 208;
            this.chkShowCashJobs.Text = "Cash Jobs";
            this.chkShowCashJobs.UseVisualStyleBackColor = true;
            this.chkShowCashJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // ChkShowAllJobs
            // 
            this.ChkShowAllJobs.AutoSize = true;
            this.ChkShowAllJobs.Checked = true;
            this.ChkShowAllJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ChkShowAllJobs.Location = new System.Drawing.Point(3, 2);
            this.ChkShowAllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChkShowAllJobs.Name = "ChkShowAllJobs";
            this.ChkShowAllJobs.Size = new System.Drawing.Size(72, 18);
            this.ChkShowAllJobs.TabIndex = 207;
            this.ChkShowAllJobs.TabStop = true;
            this.ChkShowAllJobs.Text = "All Jobs";
            this.ChkShowAllJobs.UseVisualStyleBackColor = true;
            this.ChkShowAllJobs.CheckedChanged += new System.EventHandler(this.ChkShowAllJobs_CheckedChanged);
            // 
            // btnPrintJobInfo
            // 
            this.btnPrintJobInfo.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintJobInfo.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnViewPrint,
            this.btnEmailPrint});
            this.btnPrintJobInfo.Location = new System.Drawing.Point(381, 5);
            this.btnPrintJobInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintJobInfo.Name = "btnPrintJobInfo";
            this.btnPrintJobInfo.Size = new System.Drawing.Size(103, 30);
            this.btnPrintJobInfo.TabIndex = 206;
            this.btnPrintJobInfo.Text = "Print Job";
            this.btnPrintJobInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).Text = "Print Job";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintJobInfo.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintJobInfo.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewPrint
            // 
            this.btnViewPrint.Name = "btnViewPrint";
            this.btnViewPrint.Text = "View Print";
            this.btnViewPrint.Click += new System.EventHandler(this.btnPrintJob_Click);
            // 
            // btnEmailPrint
            // 
            this.btnEmailPrint.Name = "btnEmailPrint";
            this.btnEmailPrint.Text = "Email Print";
            this.btnEmailPrint.Click += new System.EventHandler(this.btnEmailPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            this.btnEmail.Location = new System.Drawing.Point(727, 5);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(81, 30);
            this.btnEmail.TabIndex = 14;
            this.btnEmail.Tag = "";
            this.btnEmail.Text = "Email";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_email_png;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Text = "Email";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEmail.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnEmail.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // btnNewJob
            // 
            this.btnNewJob.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewJob.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnNewJob.Location = new System.Drawing.Point(189, 5);
            this.btnNewJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(93, 33);
            this.btnNewJob.TabIndex = 6;
            this.btnNewJob.Text = "Add Job";
            this.btnNewJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewJob.TextWrap = true;
            this.btnNewJob.Visible = false;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Text = "Add Job";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNewJob.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).BoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).LeftColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).TopColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).RightColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnNewJob.GetChildAt(0).GetChildAt(2))).BottomShadowColor = System.Drawing.Color.Black;
            // 
            // btnShowMap
            // 
            this.btnShowMap.Image = global::Taxi_AppMain.Properties.Resources.map_icon;
            this.btnShowMap.Location = new System.Drawing.Point(620, 5);
            this.btnShowMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(98, 30);
            this.btnShowMap.TabIndex = 3;
            this.btnShowMap.Text = "View Map";
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.map_icon;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowMap.GetChildAt(0))).Text = "View Map";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnShowMap.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // btnDespatchJob
            // 
            this.btnDespatchJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespatchJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnDespatchJob.Image = global::Taxi_AppMain.Properties.Resources.icon_3;
            this.btnDespatchJob.Location = new System.Drawing.Point(493, 5);
            this.btnDespatchJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDespatchJob.Name = "btnDespatchJob";
            this.btnDespatchJob.Size = new System.Drawing.Size(120, 30);
            this.btnDespatchJob.TabIndex = 1;
            this.btnDespatchJob.Tag = "";
            this.btnDespatchJob.Text = "Dispatch Job";
            this.btnDespatchJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDespatchJob.Click += new System.EventHandler(this.btnDespatchJob_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.icon_3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDespatchJob.GetChildAt(0))).Text = "Dispatch Job";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btnDespatchJob.GetChildAt(0).GetChildAt(2))).Width = 1F;
            // 
            // Pg_PreBookings
            // 
            
            this.Pg_PreBookings.Controls.Add(this.grdPreBookings);
            this.Pg_PreBookings.Controls.Add(this.radPanel1);
            this.Pg_PreBookings.ItemSize = new System.Drawing.SizeF(105F, 29F);
            this.Pg_PreBookings.Location = new System.Drawing.Point(10, 10);
            this.Pg_PreBookings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_PreBookings.Name = "Pg_PreBookings";
            this.Pg_PreBookings.Size = new System.Drawing.Size(1496, 480);
            this.Pg_PreBookings.Text = "Pre Bookings";
            // 
            // grdPreBookings
            // 
            this.grdPreBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPreBookings.Location = new System.Drawing.Point(0, 60);
            this.grdPreBookings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdPreBookings.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdPreBookings.Name = "grdPreBookings";
            this.grdPreBookings.Size = new System.Drawing.Size(1496, 420);
            this.grdPreBookings.TabIndex = 5;
            this.grdPreBookings.Text = "myGridView1";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdPreBookings.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdPreBookings.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel1.Controls.Add(this.label17);
            this.radPanel1.Controls.Add(this.ddlSubCompanyPreBooking);
            this.radPanel1.Controls.Add(this.btnPrintSelected);
            this.radPanel1.Controls.Add(this.optSortPickupDate);
            this.radPanel1.Controls.Add(this.optSortDriver);
            this.radPanel1.Controls.Add(this.chkShowAllocatedJobs);
            this.radPanel1.Controls.Add(this.txtSearch);
            this.radPanel1.Controls.Add(this.label8);
            this.radPanel1.Controls.Add(this.btnShowAllPreBooking);
            this.radPanel1.Controls.Add(this.dtpToDatePreBook);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.dtpFromDatePreBook);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.btnFindPreBooking);
            this.radPanel1.Controls.Add(this.ddlColumns);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1496, 60);
            this.radPanel1.TabIndex = 110;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1237, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 214;
            this.label17.Text = "Sort by";
            this.label17.Visible = false;
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintSelected.Location = new System.Drawing.Point(809, 9);
            this.btnPrintSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(133, 36);
            this.btnPrintSelected.TabIndex = 23;
            this.btnPrintSelected.Tag = "";
            this.btnPrintSelected.Text = "Print Booking";
            this.btnPrintSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintSelected.GetChildAt(0))).Text = "Print Booking";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrintSelected.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optSortPickupDate
            // 
            this.optSortPickupDate.BackColor = System.Drawing.Color.Transparent;
            this.optSortPickupDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSortPickupDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortPickupDate.ForeColor = System.Drawing.Color.Black;
            this.optSortPickupDate.Location = new System.Drawing.Point(1324, 30);
            this.optSortPickupDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortPickupDate.Name = "optSortPickupDate";
            this.optSortPickupDate.Size = new System.Drawing.Size(86, 16);
            this.optSortPickupDate.TabIndex = 213;
            this.optSortPickupDate.Text = "Pickup Date";
            this.optSortPickupDate.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.optSortPickupDate.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optSortPickupDate_ToggleStateChanged);
            // 
            // optSortDriver
            // 
            this.optSortDriver.BackColor = System.Drawing.Color.Transparent;
            this.optSortDriver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.optSortDriver.Location = new System.Drawing.Point(1435, 30);
            this.optSortDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optSortDriver.Name = "optSortDriver";
            this.optSortDriver.Size = new System.Drawing.Size(54, 16);
            this.optSortDriver.TabIndex = 212;
            this.optSortDriver.Text = "Driver";
            // 
            // chkShowAllocatedJobs
            // 
            this.chkShowAllocatedJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllocatedJobs.AutoSize = true;
            this.chkShowAllocatedJobs.BackColor = System.Drawing.Color.Transparent;
            this.chkShowAllocatedJobs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowAllocatedJobs.ForeColor = System.Drawing.Color.Blue;
            this.chkShowAllocatedJobs.Location = new System.Drawing.Point(1322, 6);
            this.chkShowAllocatedJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowAllocatedJobs.Name = "chkShowAllocatedJobs";
            this.chkShowAllocatedJobs.Size = new System.Drawing.Size(168, 17);
            this.chkShowAllocatedJobs.TabIndex = 22;
            this.chkShowAllocatedJobs.Text = "Show Allocated Jobs only";
            this.chkShowAllocatedJobs.UseVisualStyleBackColor = false;
            this.chkShowAllocatedJobs.CheckedChanged += new System.EventHandler(this.chkShowAllocatedJobs_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(77, 17);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(133, 21);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Search";
            // 
            // btnShowAllPreBooking
            // 
            this.btnShowAllPreBooking.Location = new System.Drawing.Point(849, 15);
            this.btnShowAllPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAllPreBooking.Name = "btnShowAllPreBooking";
            this.btnShowAllPreBooking.Size = new System.Drawing.Size(90, 30);
            this.btnShowAllPreBooking.TabIndex = 15;
            this.btnShowAllPreBooking.Tag = "";
            this.btnShowAllPreBooking.Text = "Clear Filter ";
            this.btnShowAllPreBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAllPreBooking.Click += new System.EventHandler(this.btnShowAllPreBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllPreBooking.GetChildAt(0))).Text = "Clear Filter ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDatePreBook
            // 
            this.dtpToDatePreBook.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpToDatePreBook.CustomFormat = "dd/MM/yyyy";
            this.dtpToDatePreBook.Format = DateTimePickerFormat.Custom;
            this.dtpToDatePreBook.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDatePreBook.Location = new System.Drawing.Point(626, 15);
            this.dtpToDatePreBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDatePreBook.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDatePreBook.Name = "dtpToDatePreBook";
            this.dtpToDatePreBook.Size = new System.Drawing.Size(140, 25);
            this.dtpToDatePreBook.TabIndex = 14;
            this.dtpToDatePreBook.TabStop = false;
            this.dtpToDatePreBook.Value = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(596, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "To";
            // 
            // dtpFromDatePreBook
            // 
            this.dtpFromDatePreBook.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDatePreBook.Format = DateTimePickerFormat.Custom;
            this.dtpFromDatePreBook.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatePreBook.Location = new System.Drawing.Point(453, 17);
            this.dtpFromDatePreBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDatePreBook.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDatePreBook.Name = "dtpFromDatePreBook";
            this.dtpFromDatePreBook.Size = new System.Drawing.Size(140, 25);
            this.dtpFromDatePreBook.TabIndex = 12;
            this.dtpFromDatePreBook.TabStop = false;
            this.dtpFromDatePreBook.Value = null;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtpFromDatePreBook.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtpFromDatePreBook.GetChildAt(0))).BackColor = System.Drawing.Color.AliceBlue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(352, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date From";
            // 
            // btnFindPreBooking
            // 
            this.btnFindPreBooking.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFindPreBooking.Location = new System.Drawing.Point(769, 15);
            this.btnFindPreBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindPreBooking.Name = "btnFindPreBooking";
            this.btnFindPreBooking.Size = new System.Drawing.Size(69, 30);
            this.btnFindPreBooking.TabIndex = 7;
            this.btnFindPreBooking.Tag = "";
            this.btnFindPreBooking.Text = "Find";
            this.btnFindPreBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindPreBooking.Click += new System.EventHandler(this.btnFindPreBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindPreBooking.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindPreBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlColumns
            // 
            this.ddlColumns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlColumns.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlColumns.Location = new System.Drawing.Point(217, 16);
            this.ddlColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlColumns.Name = "ddlColumns";
            this.ddlColumns.Size = new System.Drawing.Size(129, 21);
            this.ddlColumns.TabIndex = 21;
            // 
            // Pg_RecentJobs
            // 
            this.Pg_RecentJobs.Controls.Add(this.tableLayoutPanel4);
            this.Pg_RecentJobs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pg_RecentJobs.ItemSize = new System.Drawing.SizeF(97F, 29F);
            this.Pg_RecentJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_RecentJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_RecentJobs.Name = "Pg_RecentJobs";
            this.Pg_RecentJobs.Size = new System.Drawing.Size(1496, 480);
            this.Pg_RecentJobs.Text = "Search Jobs";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1496, 480);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grdRecentJobs);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 275);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1490, 201);
            this.panel7.TabIndex = 0;
            // 
            // grdRecentJobs
            // 
            this.grdRecentJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecentJobs.Location = new System.Drawing.Point(0, 0);
            this.grdRecentJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdRecentJobs.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.grdRecentJobs.Name = "grdRecentJobs";
            this.grdRecentJobs.Size = new System.Drawing.Size(1490, 201);
            this.grdRecentJobs.TabIndex = 1;
            this.grdRecentJobs.Text = "myGridView3";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdRecentJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdRecentJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtDestination);
            this.panel8.Controls.Add(this.lblSearchResults);
            this.panel8.Controls.Add(this.chkAvailableRecordings);
            this.panel8.Controls.Add(this.radLabel32);
            this.panel8.Controls.Add(this.ddlCompanyVehicle);
            this.panel8.Controls.Add(this.txtTokenNo);
            this.panel8.Controls.Add(this.lblTokenNo);
            this.panel8.Controls.Add(this.radLabel30);
            this.panel8.Controls.Add(this.ddlBookingType);
            this.panel8.Controls.Add(this.txtPaymentRef);
            this.panel8.Controls.Add(this.radLabel29);
            this.panel8.Controls.Add(this.chkQuotation);
            this.panel8.Controls.Add(this.radLabel2);
            this.panel8.Controls.Add(this.ddlCompany);
            this.panel8.Controls.Add(this.ddlSearchDateType);
            this.panel8.Controls.Add(this.btnclearSearchFilter);
            this.panel8.Controls.Add(this.txtOrderNo);
            this.panel8.Controls.Add(this.radLabel10);
            this.panel8.Controls.Add(this.txtRefNumber);
            this.panel8.Controls.Add(this.radLabel9);
            this.panel8.Controls.Add(this.btnViewJob);
            this.panel8.Controls.Add(this.radLabel25);
            this.panel8.Controls.Add(this.ddlStatus);
            this.panel8.Controls.Add(this.radLabel24);
            this.panel8.Controls.Add(this.ddlDriver);
            this.panel8.Controls.Add(this.radLabel23);
            this.panel8.Controls.Add(this.ddlPaymentType);

            this.panel8.Controls.Add(this.radLabel35);
            this.panel8.Controls.Add(this.ddlJourneyType);

            this.panel8.Controls.Add(this.txtEmail);
            this.panel8.Controls.Add(this.lblEmail);

            this.panel8.Controls.Add(this.txtMobileNo);
            this.panel8.Controls.Add(this.radLabel22);
            this.panel8.Controls.Add(this.txtPhoneNo);
            this.panel8.Controls.Add(this.radLabel21);
            this.panel8.Controls.Add(this.radLabel20);
            this.panel8.Controls.Add(this.ddlCust);
            this.panel8.Controls.Add(this.radLabel19);
            this.panel8.Controls.Add(this.ddlVehicleType);
            this.panel8.Controls.Add(this.opt_JOneWay);
            this.panel8.Controls.Add(this.opt_JReturnWay);
            this.panel8.Controls.Add(this.radLabel18);
            this.panel8.Controls.Add(this.txtVia);
            this.panel8.Controls.Add(this.radLabel17);
            this.panel8.Controls.Add(this.txtPickup);
            this.panel8.Controls.Add(this.radLabel16);
            this.panel8.Controls.Add(this.dtp_RecentJobs_EndDate);
            this.panel8.Controls.Add(this.radLabel15);
            this.panel8.Controls.Add(this.dtp_recentJob_StartDate);
            this.panel8.Controls.Add(this.radLabel14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 4);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1490, 263);
            this.panel8.TabIndex = 1;
            // 
            // txtDestination
            // 
            this.txtDestination.AutoSize = false;
            this.txtDestination.BackColor = System.Drawing.Color.White;
            this.txtDestination.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(127, 119);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDestination.Multiline = true;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(173, 50);
            this.txtDestination.TabIndex = 209;
            this.txtDestination.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtDestination.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtDestination.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSearchResults.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResults.ForeColor = System.Drawing.Color.Red;
            this.lblSearchResults.Location = new System.Drawing.Point(0, 261);
            this.lblSearchResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(2, 2);
            this.lblSearchResults.TabIndex = 245;
            this.lblSearchResults.Visible = false;
            // 
            // chkAvailableRecordings
            // 
            this.chkAvailableRecordings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAvailableRecordings.ForeColor = System.Drawing.Color.Red;
            this.chkAvailableRecordings.Location = new System.Drawing.Point(1184, 15);
            this.chkAvailableRecordings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAvailableRecordings.Name = "chkAvailableRecordings";
            this.chkAvailableRecordings.Size = new System.Drawing.Size(150, 18);
            this.chkAvailableRecordings.TabIndex = 244;
            this.chkAvailableRecordings.Text = "Available Recordings";
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel32.Location = new System.Drawing.Point(609, 142);
            this.radLabel32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(69, 19);
            this.radLabel32.TabIndex = 243;
            this.radLabel32.Text = "Vehicle No";
            // 
            // ddlCompanyVehicle
            // 
            this.ddlCompanyVehicle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompanyVehicle.Location = new System.Drawing.Point(709, 141);
            this.ddlCompanyVehicle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompanyVehicle.Name = "ddlCompanyVehicle";
            this.ddlCompanyVehicle.Size = new System.Drawing.Size(253, 21);
            this.ddlCompanyVehicle.TabIndex = 242;
            this.ddlCompanyVehicle.Enter += new System.EventHandler(this.ddlCompanyVehicle_Enter);
            // 
            // txtTokenNo
            // 
            this.txtTokenNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenNo.Location = new System.Drawing.Point(127, 202);
            this.txtTokenNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTokenNo.Name = "txtTokenNo";
            this.txtTokenNo.Size = new System.Drawing.Size(173, 21);
            this.txtTokenNo.TabIndex = 241;
            this.txtTokenNo.TabStop = false;
            this.txtTokenNo.Visible = false;
            // 
            // lblTokenNo
            // 
            this.lblTokenNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenNo.Location = new System.Drawing.Point(26, 205);
            this.lblTokenNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTokenNo.Name = "lblTokenNo";
            this.lblTokenNo.Size = new System.Drawing.Size(57, 19);
            this.lblTokenNo.TabIndex = 240;
            this.lblTokenNo.Text = "Token #";
            this.lblTokenNo.Visible = false;
            // 
            // radLabel30
            // 
            this.radLabel30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel30.Location = new System.Drawing.Point(313, 143);
            this.radLabel30.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel30.Name = "radLabel30";
            this.radLabel30.Size = new System.Drawing.Size(87, 19);
            this.radLabel30.TabIndex = 239;
            this.radLabel30.Text = "Booking Type";
            // 
            // ddlBookingType
            // 
            this.ddlBookingType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBookingType.Location = new System.Drawing.Point(418, 144);
            this.ddlBookingType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlBookingType.Name = "ddlBookingType";
            this.ddlBookingType.Size = new System.Drawing.Size(173, 21);
            this.ddlBookingType.TabIndex = 238;
            // 
            // txtPaymentRef
            // 
            this.txtPaymentRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentRef.Location = new System.Drawing.Point(709, 118);
            this.txtPaymentRef.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPaymentRef.Name = "txtPaymentRef";
            this.txtPaymentRef.Size = new System.Drawing.Size(253, 21);
            this.txtPaymentRef.TabIndex = 237;
            this.txtPaymentRef.TabStop = false;
            // 
            // radLabel29
            // 
            this.radLabel29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel29.Location = new System.Drawing.Point(608, 116);
            this.radLabel29.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel29.Name = "radLabel29";
            this.radLabel29.Size = new System.Drawing.Size(86, 19);
            this.radLabel29.TabIndex = 236;
            this.radLabel29.Text = "Payment Ref.";
            // 
            // chkQuotation
            // 
            this.chkQuotation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQuotation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkQuotation.Location = new System.Drawing.Point(924, 12);
            this.chkQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkQuotation.Name = "chkQuotation";
            this.chkQuotation.Size = new System.Drawing.Size(116, 18);
            this.chkQuotation.TabIndex = 235;
            this.chkQuotation.Text = "With Quotation";
            this.chkQuotation.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(313, 165);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(54, 19);
            this.radLabel2.TabIndex = 234;
            this.radLabel2.Text = "Account";
            // 
            // ddlCompany
            // 
            this.ddlCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCompany.Location = new System.Drawing.Point(418, 166);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(173, 21);
            this.ddlCompany.TabIndex = 233;
            // 
            // ddlSearchDateType
            // 
            this.ddlSearchDateType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearchDateType.Location = new System.Drawing.Point(3, 6);
            this.ddlSearchDateType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSearchDateType.Name = "ddlSearchDateType";
            this.ddlSearchDateType.Size = new System.Drawing.Size(125, 21);
            this.ddlSearchDateType.TabIndex = 232;
            this.ddlSearchDateType.Text = "Booking Date";
            // 
            // btnclearSearchFilter
            // 
            this.btnclearSearchFilter.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.btnclearSearchFilter.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnclearSearchFilter.Location = new System.Drawing.Point(1174, 137);
            this.btnclearSearchFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnclearSearchFilter.Name = "btnclearSearchFilter";
            this.btnclearSearchFilter.Size = new System.Drawing.Size(128, 62);
            this.btnclearSearchFilter.TabIndex = 231;
            this.btnclearSearchFilter.Text = "Clear Filter";
            this.btnclearSearchFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnclearSearchFilter.Click += new System.EventHandler(this.btnclearSearchFilter_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnclearSearchFilter.GetChildAt(0))).Text = "Clear Filter";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnclearSearchFilter.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(418, 189);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(171, 21);
            this.txtOrderNo.TabIndex = 230;
            this.txtOrderNo.TabStop = false;
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(314, 190);
            this.radLabel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(61, 19);
            this.radLabel10.TabIndex = 229;
            this.radLabel10.Text = "Order No";
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNumber.Location = new System.Drawing.Point(127, 173);
            this.txtRefNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(173, 21);
            this.txtRefNumber.TabIndex = 228;
            this.txtRefNumber.TabStop = false;
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(27, 176);
            this.radLabel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(82, 19);
            this.radLabel9.TabIndex = 227;
            this.radLabel9.Text = "Ref. Number";
            // 
            // btnViewJob
            // 
            this.btnViewJob.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnViewJob.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnViewJob.Location = new System.Drawing.Point(1014, 137);
            this.btnViewJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewJob.Name = "btnViewJob";
            this.btnViewJob.Size = new System.Drawing.Size(128, 62);
            this.btnViewJob.TabIndex = 226;
            this.btnViewJob.Text = "View Jobs";
            this.btnViewJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewJob.Click += new System.EventHandler(this.radButton9_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewJob.GetChildAt(0))).Text = "View Jobs";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnViewJob.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel25
            // 
            this.radLabel25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel25.Location = new System.Drawing.Point(608, 89);
            this.radLabel25.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel25.Name = "radLabel25";
            this.radLabel25.Size = new System.Drawing.Size(44, 19);
            this.radLabel25.TabIndex = 225;
            this.radLabel25.Text = "Status";
            // 
            // ddlStatus
            // 
            this.ddlStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStatus.Location = new System.Drawing.Point(709, 88);
            this.ddlStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(142, 21);
            this.ddlStatus.TabIndex = 224;
            // 
            // radLabel24
            // 
            this.radLabel24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel24.Location = new System.Drawing.Point(608, 67);
            this.radLabel24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel24.Name = "radLabel24";
            this.radLabel24.Size = new System.Drawing.Size(42, 19);
            this.radLabel24.TabIndex = 223;
            this.radLabel24.Text = "Driver";
            // 
            // ddlDriver
            // 
            this.ddlDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriver.Location = new System.Drawing.Point(709, 64);
            this.ddlDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDriver.Name = "ddlDriver";
            this.ddlDriver.Size = new System.Drawing.Size(173, 21);
            this.ddlDriver.TabIndex = 222;
            // 
            // radLabel23
            // 
            this.radLabel23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel23.Location = new System.Drawing.Point(608, 44);
            this.radLabel23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(58, 19);
            this.radLabel23.TabIndex = 221;
            this.radLabel23.Text = "Payment";
            // 
            // ddlPaymentType
            // 
            this.ddlPaymentType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPaymentType.Location = new System.Drawing.Point(709, 41);
            this.ddlPaymentType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlPaymentType.Name = "ddlPaymentType";
            this.ddlPaymentType.Size = new System.Drawing.Size(142, 21);
            this.ddlPaymentType.TabIndex = 220;


            // 
            this.radLabel35.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel35.Location = new System.Drawing.Point(608, 164);
            this.radLabel35.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel35.Name = "radLabel35";
            this.radLabel35.Size = new System.Drawing.Size(58, 19);
            this.radLabel35.TabIndex = 221;
            this.radLabel35.Text = "Journey Type";


            this.ddlJourneyType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlJourneyType.Location = new System.Drawing.Point(709, 164);
            this.ddlJourneyType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlJourneyType.Name = "ddlJourneyType";
            this.ddlJourneyType.Size = new System.Drawing.Size(142, 21);
            this.ddlJourneyType.TabIndex = 246;


            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(418, 115);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 21);
            this.txtEmail.TabIndex = 219;
            this.txtEmail.TabStop = false;
            // 
            // radLabel22
            // 
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(314, 114);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEmail.Name = "radLabelemail";
            this.lblEmail.Size = new System.Drawing.Size(65, 19);
            this.lblEmail.TabIndex = 218;
            this.lblEmail.Text = "Email";




            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(418, 89);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(173, 21);
            this.txtMobileNo.TabIndex = 219;
            this.txtMobileNo.TabStop = false;
            // 
            // radLabel22
            // 
            this.radLabel22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel22.Location = new System.Drawing.Point(314, 90);
            this.radLabel22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel22.Name = "radLabel22";
            this.radLabel22.Size = new System.Drawing.Size(65, 19);
            this.radLabel22.TabIndex = 218;
            this.radLabel22.Text = "Mobile No";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(418, 65);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(173, 21);
            this.txtPhoneNo.TabIndex = 217;
            this.txtPhoneNo.TabStop = false;
            // 
            // radLabel21
            // 
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.Location = new System.Drawing.Point(314, 66);
            this.radLabel21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(64, 19);
            this.radLabel21.TabIndex = 216;
            this.radLabel21.Text = "Phone No";
            // 
            // radLabel20
            // 
            this.radLabel20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel20.Location = new System.Drawing.Point(313, 42);
            this.radLabel20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel20.Name = "radLabel20";
            this.radLabel20.Size = new System.Drawing.Size(63, 19);
            this.radLabel20.TabIndex = 215;
            this.radLabel20.Text = "Customer";
            // 
            // ddlCust
            // 
            this.ddlCust.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCust.Location = new System.Drawing.Point(418, 41);
            this.ddlCust.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCust.Name = "ddlCust";
            this.ddlCust.Size = new System.Drawing.Size(173, 21);
            this.ddlCust.TabIndex = 214;
            // 
            // radLabel19
            // 
            this.radLabel19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel19.Location = new System.Drawing.Point(26, 44);
            this.radLabel19.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Size = new System.Drawing.Size(82, 19);
            this.radLabel19.TabIndex = 213;
            this.radLabel19.Text = "Vehicle Type";
            // 
            // ddlVehicleType
            // 
            this.ddlVehicleType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleType.Location = new System.Drawing.Point(127, 41);
            this.ddlVehicleType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlVehicleType.Name = "ddlVehicleType";
            this.ddlVehicleType.Size = new System.Drawing.Size(170, 21);
            this.ddlVehicleType.TabIndex = 212;
            // 
            // opt_JOneWay
            // 
            this.opt_JOneWay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opt_JOneWay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_JOneWay.Location = new System.Drawing.Point(675, 11);
            this.opt_JOneWay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt_JOneWay.Name = "opt_JOneWay";
            this.opt_JOneWay.Size = new System.Drawing.Size(75, 19);
            this.opt_JOneWay.TabIndex = 211;
            this.opt_JOneWay.Text = "One Way";
            this.opt_JOneWay.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // opt_JReturnWay
            // 
            this.opt_JReturnWay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_JReturnWay.Location = new System.Drawing.Point(777, 11);
            this.opt_JReturnWay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.opt_JReturnWay.Name = "opt_JReturnWay";
            this.opt_JReturnWay.Size = new System.Drawing.Size(111, 19);
            this.opt_JReturnWay.TabIndex = 210;
            this.opt_JReturnWay.Text = "Return Journey";
            // 
            // radLabel18
            // 
            this.radLabel18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.Location = new System.Drawing.Point(3, 119);
            this.radLabel18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(107, 19);
            this.radLabel18.TabIndex = 208;
            this.radLabel18.Text = "Destination Point";
            // 
            // txtVia
            // 
            this.txtVia.AutoSize = false;
            this.txtVia.BackColor = System.Drawing.Color.White;
            this.txtVia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVia.Location = new System.Drawing.Point(972, 42);
            this.txtVia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVia.Multiline = true;
            this.txtVia.Name = "txtVia";
            this.txtVia.Size = new System.Drawing.Size(170, 50);
            this.txtVia.TabIndex = 207;
            this.txtVia.TabStop = false;
            this.txtVia.Visible = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtVia.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtVia.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel17
            // 
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.Location = new System.Drawing.Point(894, 42);
            this.radLabel17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(59, 19);
            this.radLabel17.TabIndex = 206;
            this.radLabel17.Text = "Via Point";
            this.radLabel17.Visible = false;
            // 
            // txtPickup
            // 
            this.txtPickup.AutoSize = false;
            this.txtPickup.BackColor = System.Drawing.Color.White;
            this.txtPickup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPickup.Location = new System.Drawing.Point(127, 66);
            this.txtPickup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPickup.Multiline = true;
            this.txtPickup.Name = "txtPickup";
            this.txtPickup.Size = new System.Drawing.Size(170, 50);
            this.txtPickup.TabIndex = 205;
            this.txtPickup.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtPickup.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPickup.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.Location = new System.Drawing.Point(28, 66);
            this.radLabel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(79, 19);
            this.radLabel16.TabIndex = 204;
            this.radLabel16.Text = "Pickup Point";
            // 
            // dtp_RecentJobs_EndDate
            // 
            this.dtp_RecentJobs_EndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_RecentJobs_EndDate.Format = DateTimePickerFormat.Custom;
            this.dtp_RecentJobs_EndDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_RecentJobs_EndDate.Location = new System.Drawing.Point(463, 9);
            this.dtp_RecentJobs_EndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_RecentJobs_EndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_RecentJobs_EndDate.Name = "dtp_RecentJobs_EndDate";
            this.dtp_RecentJobs_EndDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_RecentJobs_EndDate.Size = new System.Drawing.Size(164, 21);
            this.dtp_RecentJobs_EndDate.TabIndex = 203;
            this.dtp_RecentJobs_EndDate.TabStop = false;
            this.dtp_RecentJobs_EndDate.Value = null;
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(391, 10);
            this.radLabel15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(61, 19);
            this.radLabel15.TabIndex = 202;
            this.radLabel15.Text = "End Date";
            // 
            // dtp_recentJob_StartDate
            // 
            this.dtp_recentJob_StartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_recentJob_StartDate.Format = DateTimePickerFormat.Custom;
            this.dtp_recentJob_StartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_recentJob_StartDate.Location = new System.Drawing.Point(209, 9);
            this.dtp_recentJob_StartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_recentJob_StartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_recentJob_StartDate.Name = "dtp_recentJob_StartDate";
            this.dtp_recentJob_StartDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_recentJob_StartDate.Size = new System.Drawing.Size(175, 21);
            this.dtp_recentJob_StartDate.TabIndex = 201;
            this.dtp_recentJob_StartDate.TabStop = false;
            this.dtp_recentJob_StartDate.Value = null;
            // 
            // radLabel14
            // 
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(129, 10);
            this.radLabel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(67, 19);
            this.radLabel14.TabIndex = 200;
            this.radLabel14.Text = "Start Date";
            // 
            // Pg_AllJobs
            // 
            this.Pg_AllJobs.Controls.Add(this.grdAllJobs);
            this.Pg_AllJobs.Controls.Add(this.radPanel9);
            this.Pg_AllJobs.ItemSize = new System.Drawing.SizeF(98F, 29F);
            this.Pg_AllJobs.Location = new System.Drawing.Point(10, 10);
            this.Pg_AllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_AllJobs.Name = "Pg_AllJobs";
            this.Pg_AllJobs.Size = new System.Drawing.Size(1496, 480);
            this.Pg_AllJobs.Text = "Recent Jobs";
            // 
            // grdAllJobs
            // 
            this.grdAllJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAllJobs.Location = new System.Drawing.Point(0, 209);
            this.grdAllJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdAllJobs.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.grdAllJobs.Name = "grdAllJobs";
            this.grdAllJobs.Size = new System.Drawing.Size(1496, 271);
            this.grdAllJobs.TabIndex = 5;
            this.grdAllJobs.Text = "myGridView1";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdAllJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdAllJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // radPanel9
            // 
            this.radPanel9.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel9.Controls.Add(this.btnRecentShowAll);
            this.radPanel9.Controls.Add(this.btnRecentFind);
            this.radPanel9.Controls.Add(this.txtPassengerRecent);
            this.radPanel9.Controls.Add(this.txtMobileRecent);
            this.radPanel9.Controls.Add(this.radLabel8);
            this.radPanel9.Controls.Add(this.txtPhoneRecent);
            this.radPanel9.Controls.Add(this.radLabel12);
            this.radPanel9.Controls.Add(this.label13);
            this.radPanel9.Controls.Add(this.dtpToDateRecent);
            this.radPanel9.Controls.Add(this.label9);
            this.radPanel9.Controls.Add(this.dtpFromDateRecent);
            this.radPanel9.Controls.Add(this.label12);
            this.radPanel9.Controls.Add(this.label11);
            this.radPanel9.Controls.Add(this.txtSearchRec);
            this.radPanel9.Controls.Add(this.label10);
            this.radPanel9.Controls.Add(this.ddlBookingStatus);
            this.radPanel9.Controls.Add(this.ddlRecentColumn);
            this.radPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel9.Location = new System.Drawing.Point(0, 0);
            this.radPanel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel9.Name = "radPanel9";
            this.radPanel9.Size = new System.Drawing.Size(1496, 209);
            this.radPanel9.TabIndex = 113;
            // 
            // btnRecentShowAll
            // 
            this.btnRecentShowAll.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecentShowAll.Location = new System.Drawing.Point(659, 105);
            this.btnRecentShowAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecentShowAll.Name = "btnRecentShowAll";
            this.btnRecentShowAll.Size = new System.Drawing.Size(129, 50);
            this.btnRecentShowAll.TabIndex = 228;
            this.btnRecentShowAll.Text = "Clear Filter";
            this.btnRecentShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRecentShowAll.Click += new System.EventHandler(this.btnRecentShowAll_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentShowAll.GetChildAt(0))).Text = "Clear Filter";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentShowAll.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRecentFind
            // 
            this.btnRecentFind.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnRecentFind.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecentFind.Location = new System.Drawing.Point(512, 105);
            this.btnRecentFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecentFind.Name = "btnRecentFind";
            this.btnRecentFind.Size = new System.Drawing.Size(129, 50);
            this.btnRecentFind.TabIndex = 227;
            this.btnRecentFind.Text = "Find Jobs";
            this.btnRecentFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecentFind.Click += new System.EventHandler(this.btnRecentFind_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRecentFind.GetChildAt(0))).Text = "Find Jobs";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnRecentFind.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassengerRecent
            // 
            this.txtPassengerRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassengerRecent.Location = new System.Drawing.Point(161, 94);
            this.txtPassengerRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassengerRecent.Name = "txtPassengerRecent";
            this.txtPassengerRecent.Size = new System.Drawing.Size(173, 21);
            this.txtPassengerRecent.TabIndex = 224;
            this.txtPassengerRecent.TabStop = false;
            // 
            // txtMobileRecent
            // 
            this.txtMobileRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileRecent.Location = new System.Drawing.Point(162, 162);
            this.txtMobileRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileRecent.Name = "txtMobileRecent";
            this.txtMobileRecent.Size = new System.Drawing.Size(173, 21);
            this.txtMobileRecent.TabIndex = 223;
            this.txtMobileRecent.TabStop = false;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(19, 164);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(83, 19);
            this.radLabel8.TabIndex = 222;
            this.radLabel8.Text = "Mobile No :";
            // 
            // txtPhoneRecent
            // 
            this.txtPhoneRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneRecent.Location = new System.Drawing.Point(162, 129);
            this.txtPhoneRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhoneRecent.Name = "txtPhoneRecent";
            this.txtPhoneRecent.Size = new System.Drawing.Size(173, 21);
            this.txtPhoneRecent.TabIndex = 221;
            this.txtPhoneRecent.TabStop = false;
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel12.Location = new System.Drawing.Point(19, 132);
            this.radLabel12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(80, 19);
            this.radLabel12.TabIndex = 220;
            this.radLabel12.Text = "Phone No :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "Customer Name :";
            // 
            // dtpToDateRecent
            // 
            this.dtpToDateRecent.CustomFormat = "dd/MM/yyyy";
            this.dtpToDateRecent.Format = DateTimePickerFormat.Custom;

            this.dtpToDateRecent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDateRecent.Location = new System.Drawing.Point(350, 7);
            this.dtpToDateRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToDateRecent.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDateRecent.Name = "dtpToDateRecent";
            this.dtpToDateRecent.Size = new System.Drawing.Size(119, 24);
            this.dtpToDateRecent.TabIndex = 27;
            this.dtpToDateRecent.TabStop = false;
            this.dtpToDateRecent.Value = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(275, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Till Date";
            // 
            // dtpFromDateRecent
            // 
            this.dtpFromDateRecent.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDateRecent.Format = DateTimePickerFormat.Custom;
            this.dtpFromDateRecent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDateRecent.Location = new System.Drawing.Point(120, 9);
            this.dtpFromDateRecent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromDateRecent.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDateRecent.Name = "dtpFromDateRecent";
            this.dtpFromDateRecent.Size = new System.Drawing.Size(128, 24);
            this.dtpFromDateRecent.TabIndex = 25;
            this.dtpFromDateRecent.TabStop = false;
            this.dtpFromDateRecent.Value = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "From Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(500, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Booking Status:";
            // 
            // txtSearchRec
            // 
            this.txtSearchRec.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchRec.Location = new System.Drawing.Point(120, 55);
            this.txtSearchRec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchRec.Name = "txtSearchRec";
            this.txtSearchRec.Size = new System.Drawing.Size(211, 21);
            this.txtSearchRec.TabIndex = 20;
            this.txtSearchRec.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Search by:";
            // 
            // ddlBookingStatus
            // 
            this.ddlBookingStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBookingStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBookingStatus.Location = new System.Drawing.Point(637, 7);
            this.ddlBookingStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlBookingStatus.Name = "ddlBookingStatus";
            this.ddlBookingStatus.Size = new System.Drawing.Size(156, 21);
            this.ddlBookingStatus.TabIndex = 22;
            this.ddlBookingStatus.Text = "Ongoing";
            // 
            // ddlRecentColumn
            // 
            this.ddlRecentColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRecentColumn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRecentColumn.Location = new System.Drawing.Point(345, 53);
            this.ddlRecentColumn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlRecentColumn.Name = "ddlRecentColumn";
            this.ddlRecentColumn.Size = new System.Drawing.Size(129, 21);
            this.ddlRecentColumn.TabIndex = 21;
            this.ddlRecentColumn.Text = "Refrence No";
            // 
            // Pg_DrvBookingStats
            // 
            this.Pg_DrvBookingStats.Controls.Add(this.pnlChart);
            this.Pg_DrvBookingStats.ItemSize = new System.Drawing.SizeF(156F, 29F);
            this.Pg_DrvBookingStats.Location = new System.Drawing.Point(10, 10);
            this.Pg_DrvBookingStats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_DrvBookingStats.Name = "Pg_DrvBookingStats";
            this.Pg_DrvBookingStats.Size = new System.Drawing.Size(1496, 480);
            this.Pg_DrvBookingStats.Text = "Driver Booking Stats";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.splitContainer1);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1496, 480);
            this.pnlChart.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdStats);
            this.splitContainer1.Panel1.Controls.Add(this.pnlStatsHeader);
            this.splitContainer1.Size = new System.Drawing.Size(1496, 480);
            this.splitContainer1.SplitterDistance = 692;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 10;
            // 
            // grdStats
            // 
            this.grdStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStats.Location = new System.Drawing.Point(0, 105);
            this.grdStats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdStats.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.grdStats.Name = "grdStats";
            this.grdStats.Size = new System.Drawing.Size(692, 375);
            this.grdStats.TabIndex = 1;
            this.grdStats.Text = "myGridView4";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdStats.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdStats.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // pnlStatsHeader
            // 
            this.pnlStatsHeader.Controls.Add(this.optToday);
            this.pnlStatsHeader.Controls.Add(this.pnlMonthWise);
            this.pnlStatsHeader.Controls.Add(this.optMonthWise);
            this.pnlStatsHeader.Controls.Add(this.optDriverWise);
            this.pnlStatsHeader.Controls.Add(this.btnPreview);
            this.pnlStatsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlStatsHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatsHeader.Name = "pnlStatsHeader";
            this.pnlStatsHeader.Size = new System.Drawing.Size(692, 105);
            this.pnlStatsHeader.TabIndex = 2;
            // 
            // optToday
            // 
            this.optToday.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optToday.Location = new System.Drawing.Point(315, 17);
            this.optToday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optToday.Name = "optToday";
            this.optToday.Size = new System.Drawing.Size(68, 22);
            this.optToday.TabIndex = 19;
            this.optToday.Text = "Today";
            this.optToday.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optMonthWise_ToggleStateChanged);
            // 
            // pnlMonthWise
            // 
            this.pnlMonthWise.Controls.Add(this.label1);
            this.pnlMonthWise.Controls.Add(this.dtpStatsFromDate);
            this.pnlMonthWise.Controls.Add(this.label2);
            this.pnlMonthWise.Controls.Add(this.dtpStatsTillDate);
            this.pnlMonthWise.Enabled = false;
            this.pnlMonthWise.Location = new System.Drawing.Point(3, 50);
            this.pnlMonthWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMonthWise.Name = "pnlMonthWise";
            this.pnlMonthWise.Size = new System.Drawing.Size(419, 47);
            this.pnlMonthWise.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dtpStatsFromDate
            // 
            this.dtpStatsFromDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStatsFromDate.Format = DateTimePickerFormat.Custom;
            this.dtpStatsFromDate.Location = new System.Drawing.Point(44, 11);
            this.dtpStatsFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStatsFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsFromDate.Name = "dtpStatsFromDate";
            this.dtpStatsFromDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsFromDate.Size = new System.Drawing.Size(173, 21);
            this.dtpStatsFromDate.TabIndex = 1;
            this.dtpStatsFromDate.TabStop = false;
            this.dtpStatsFromDate.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Till";
            // 
            // dtpStatsTillDate
            // 
            this.dtpStatsTillDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStatsTillDate.Format = DateTimePickerFormat.Custom;
            this.dtpStatsTillDate.Location = new System.Drawing.Point(246, 11);
            this.dtpStatsTillDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStatsTillDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsTillDate.Name = "dtpStatsTillDate";
            this.dtpStatsTillDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStatsTillDate.Size = new System.Drawing.Size(170, 21);
            this.dtpStatsTillDate.TabIndex = 3;
            this.dtpStatsTillDate.TabStop = false;
            this.dtpStatsTillDate.Value = null;
            // 
            // optMonthWise
            // 
            this.optMonthWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMonthWise.Location = new System.Drawing.Point(203, 17);
            this.optMonthWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optMonthWise.Name = "optMonthWise";
            this.optMonthWise.Size = new System.Drawing.Size(85, 22);
            this.optMonthWise.TabIndex = 17;
            this.optMonthWise.Text = "Monthly";
            this.optMonthWise.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.optMonthWise_ToggleStateChanged);
            // 
            // optDriverWise
            // 
            this.optDriverWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optDriverWise.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDriverWise.Location = new System.Drawing.Point(10, 17);
            this.optDriverWise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optDriverWise.Name = "optDriverWise";
            this.optDriverWise.Size = new System.Drawing.Size(156, 22);
            this.optDriverWise.TabIndex = 16;
            this.optDriverWise.Text = "Login Driver Only";
            this.optDriverWise.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(429, 30);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(239, 68);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPreview.GetChildAt(0))).Text = "Preview";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPreview.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_Quotations
            // 
            this.Pg_Quotations.Controls.Add(this.grdQuotations);
            this.Pg_Quotations.Controls.Add(this.radPanel2);
            this.Pg_Quotations.ItemSize = new System.Drawing.SizeF(91F, 29F);
            this.Pg_Quotations.Location = new System.Drawing.Point(10, 10);
            this.Pg_Quotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Quotations.Name = "Pg_Quotations";
            this.Pg_Quotations.Size = new System.Drawing.Size(1496, 480);
            this.Pg_Quotations.Text = "Quotations";
            // 
            // grdQuotations
            // 
            this.grdQuotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuotations.Location = new System.Drawing.Point(0, 42);
            this.grdQuotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdQuotations.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.grdQuotations.Name = "grdQuotations";
            this.grdQuotations.Size = new System.Drawing.Size(1496, 438);
            this.grdQuotations.TabIndex = 111;
            this.grdQuotations.Text = "myGridView1";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdQuotations.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdQuotations.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.radPanel2.Controls.Add(this.btnShowAllQuotation);
            this.radPanel2.Controls.Add(this.dtpToQuotation);
            this.radPanel2.Controls.Add(this.label6);
            this.radPanel2.Controls.Add(this.dtpFromQuotation);
            this.radPanel2.Controls.Add(this.label7);
            this.radPanel2.Controls.Add(this.btnFindQuotations);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1496, 42);
            this.radPanel2.TabIndex = 113;
            // 
            // btnShowAllQuotation
            // 
            this.btnShowAllQuotation.Location = new System.Drawing.Point(496, 6);
            this.btnShowAllQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowAllQuotation.Name = "btnShowAllQuotation";
            this.btnShowAllQuotation.Size = new System.Drawing.Size(90, 30);
            this.btnShowAllQuotation.TabIndex = 15;
            this.btnShowAllQuotation.Tag = "";
            this.btnShowAllQuotation.Text = "Show All ";
            this.btnShowAllQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAllQuotation.Click += new System.EventHandler(this.btnShowAllQuotation_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnShowAllQuotation.GetChildAt(0))).Text = "Show All ";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllQuotation.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllQuotation.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnShowAllQuotation.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToQuotation
            // 
            this.dtpToQuotation.CustomFormat = "dd/MM/yyyy";
            this.dtpToQuotation.Format = DateTimePickerFormat.Custom;
            this.dtpToQuotation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToQuotation.Location = new System.Drawing.Point(258, 6);
            this.dtpToQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpToQuotation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToQuotation.Name = "dtpToQuotation";
            this.dtpToQuotation.Size = new System.Drawing.Size(119, 24);
            this.dtpToQuotation.TabIndex = 14;
            this.dtpToQuotation.TabStop = false;
            this.dtpToQuotation.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "To";
            // 
            // dtpFromQuotation
            // 
            this.dtpFromQuotation.CustomFormat = "dd/MM/yyyy";
            this.dtpFromQuotation.Format = DateTimePickerFormat.Custom;
            this.dtpFromQuotation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromQuotation.Location = new System.Drawing.Point(103, 7);
            this.dtpFromQuotation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFromQuotation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromQuotation.Name = "dtpFromQuotation";
            this.dtpFromQuotation.Size = new System.Drawing.Size(119, 24);
            this.dtpFromQuotation.TabIndex = 12;
            this.dtpFromQuotation.TabStop = false;
            this.dtpFromQuotation.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Date From";
            // 
            // btnFindQuotations
            // 
            this.btnFindQuotations.Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            this.btnFindQuotations.Location = new System.Drawing.Point(405, 6);
            this.btnFindQuotations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindQuotations.Name = "btnFindQuotations";
            this.btnFindQuotations.Size = new System.Drawing.Size(69, 30);
            this.btnFindQuotations.TabIndex = 7;
            this.btnFindQuotations.Tag = "";
            this.btnFindQuotations.Text = "Find";
            this.btnFindQuotations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindQuotations.Click += new System.EventHandler(this.btnFindQuotations_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.pic_Search;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnFindQuotations.GetChildAt(0))).Text = "Find";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindQuotations.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindQuotations.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnFindQuotations.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pg_NoShow
            // 
            this.Pg_NoShow.Controls.Add(this.grdNoShowJobs);
            this.Pg_NoShow.ItemSize = new System.Drawing.SizeF(77F, 29F);
            this.Pg_NoShow.Location = new System.Drawing.Point(10, 10);
            this.Pg_NoShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_NoShow.Name = "Pg_NoShow";
            this.Pg_NoShow.Size = new System.Drawing.Size(1496, 480);
            this.Pg_NoShow.Text = "No Show";
            // 
            // grdNoShowJobs
            // 
            this.grdNoShowJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNoShowJobs.Location = new System.Drawing.Point(0, 0);
            this.grdNoShowJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdNoShowJobs.MasterTemplate.ViewDefinition = tableViewDefinition9;
            this.grdNoShowJobs.Name = "grdNoShowJobs";
            this.grdNoShowJobs.Size = new System.Drawing.Size(1496, 480);
            this.grdNoShowJobs.TabIndex = 8;
            this.grdNoShowJobs.Text = "myGridView1";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdNoShowJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdNoShowJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";
            // 
            // Pg_Cancelled
            // 
            this.Pg_Cancelled.Controls.Add(this.grdCancelledJobs);
            this.Pg_Cancelled.ItemSize = new System.Drawing.SizeF(82F, 29F);
            this.Pg_Cancelled.Location = new System.Drawing.Point(12, 12);
            this.Pg_Cancelled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Cancelled.Name = "Pg_Cancelled";
            this.Pg_Cancelled.Size = new System.Drawing.Size(1514, 454);
            this.Pg_Cancelled.Text = "Cancelled";
            // 
            // grdCancelledJobs
            // 
            this.grdCancelledJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCancelledJobs.Location = new System.Drawing.Point(0, 0);
            this.grdCancelledJobs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdCancelledJobs.MasterTemplate.ViewDefinition = tableViewDefinition10;
            chkTodayCancelled = new CheckBox();
            this.grdCancelledJobs.Controls.Add(chkTodayCancelled);
            this.grdCancelledJobs.Name = "grdCancelledJobs";
            this.grdCancelledJobs.Size = new System.Drawing.Size(1514, 454);
            this.grdCancelledJobs.TabIndex = 10;
            this.grdCancelledJobs.Text = "Cancelled Bookings";
            ((Telerik.WinControls.UI.GridTableElement)(this.grdCancelledJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).NumberOfColors = 1;
            ((Telerik.WinControls.UI.GridTableElement)(this.grdCancelledJobs.GetChildAt(0).GetChildAt(0).GetChildAt(2))).Text = "No data to display";



            // 
            // chkTodayCancelled
            // 
            this.chkTodayCancelled.AutoSize = true;
            this.chkTodayCancelled.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkTodayCancelled.ForeColor = System.Drawing.Color.Blue;
            this.chkTodayCancelled.Location = new System.Drawing.Point(0, 1);
            this.chkTodayCancelled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTodayCancelled.Name = "chkTodayCancelled";
            this.chkTodayCancelled.Size = new System.Drawing.Size(61, 17);
            this.chkTodayCancelled.TabIndex = 212;
            this.chkTodayCancelled.Text = "Today";
            this.chkTodayCancelled.UseVisualStyleBackColor = true;
            this.chkTodayCancelled.CheckedChanged += new System.EventHandler(this.chkTodayCancelled_CheckedChanged);

            // 
            // frmBookingDashBoard
            // 
            this.AllowDrop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1517, 875);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormTitle = "DashBoard";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBookingDashBoard";
            this.Text = "DashBoard";
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.radPageView1, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).EndInit();
            this.radPanel8.ResumeLayout(false);
            this.radPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel54)).EndInit();
            this.pnlDriverOnBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnBoardDriver)).EndInit();
            this.pnlDriverWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverPricePlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOnPlotDrivers)).EndInit();
            this.pnlOnPlotDrivers.ResumeLayout(false);
            this.pnlOnPlotDrivers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnPlotDrivers)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.Pg_PendingJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingJobs)).EndInit();
            this.grdPendingJobs.ResumeLayout(false);
            this.grdPendingJobs.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActions)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortTodayDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShowDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintJobInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDespatchJob)).EndInit();
            this.Pg_PreBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubCompanyPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortPickupDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optSortDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDatePreBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDatePreBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindPreBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlColumns)).EndInit();
            this.Pg_RecentJobs.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecentJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel8)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvailableRecordings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTokenNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTokenNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSearchDateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclearSearchFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentType)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlJourneyType)).EndInit();


            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JOneWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt_JReturnWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_RecentJobs_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_recentJob_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            this.Pg_AllJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).EndInit();
            this.radPanel9.ResumeLayout(false);
            this.radPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentShowAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecentFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassengerRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDateRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDateRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBookingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRecentColumn)).EndInit();
            this.Pg_DrvBookingStats.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStats.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStats)).EndInit();
            this.pnlStatsHeader.ResumeLayout(false);
            this.pnlStatsHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optToday)).EndInit();
            this.pnlMonthWise.ResumeLayout(false);
            this.pnlMonthWise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatsTillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optMonthWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDriverWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).EndInit();
            this.Pg_Quotations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAllQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFindQuotations)).EndInit();
            this.Pg_NoShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoShowJobs)).EndInit();
            this.Pg_Cancelled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelledJobs)).EndInit();
            this.ResumeLayout(false);



            grdOnPlotDrivers.GridColor = Color.Gainsboro;
            grdOnPlotDrivers.RowsDefaultCellStyle.BackColor = Color.Red;


            grdDriverWaiting.CellFormatting += new CellFormattingEventHandler(grdDriver_CellFormattingLayout2);
            grdOnBoardDriver.CellFormatting += new CellFormattingEventHandler(grdOnBoardDriver_CellFormattingLayout2);

            grdOnPlotDrivers.CellFormatting += new DataGridViewCellFormattingEventHandler(grdOnPlotDrivers_CellFormattingLayout2);
            grdOnPlotDrivers.CellPainting += GrdOnPlotDrivers_CellPainting;
            grdOnPlotDrivers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOnPlotDrivers_CellMouseEnter);

            grdDriverWaiting.TableElement.BackColor = GridBackColor;
            grdDriverWaiting.TableElement.NumberOfColors = 1;


            grdOnBoardDriver.TableElement.BackColor = GridBackColor;
            grdOnBoardDriver.TableElement.NumberOfColors = 1;



            grdPendingJobs.TableElement.BackColor = GridBackColor;
            grdPendingJobs.TableElement.NumberOfColors = 1;

            grdPreBookings.TableElement.BackColor = GridBackColor;
            grdPreBookings.TableElement.NumberOfColors = 1;

            grdRecentJobs.TableElement.BackColor = GridBackColor;
            grdRecentJobs.TableElement.NumberOfColors = 1;


            grdAllJobs.TableElement.BackColor = GridBackColor;
            grdAllJobs.TableElement.NumberOfColors = 1;

            grdStats.TableElement.BackColor = GridBackColor;
            grdStats.TableElement.NumberOfColors = 1;


            grdQuotations.TableElement.BackColor = GridBackColor;
            grdQuotations.TableElement.NumberOfColors = 1;


            grdNoShowJobs.TableElement.BackColor = GridBackColor;
            grdNoShowJobs.TableElement.NumberOfColors = 1;


            grdCancelledJobs.TableElement.BackColor = GridBackColor;
            grdCancelledJobs.TableElement.NumberOfColors = 1;


        }



        private void GrdOnPlotDrivers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (grdOnPlotDrivers.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToStr() == "-14634326")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Green, 2))
                    {
                        Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                    e.Handled = true;
                }
            }
        }




        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage Pg_PendingJobs;
        private Telerik.WinControls.UI.RadPageViewPage Pg_RecentJobs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadPanel panel1;
        private Telerik.WinControls.UI.RadGridView grdPendingJobs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Telerik.WinControls.UI.RadPanel panel7;
        private Telerik.WinControls.UI.RadPanel panel8;
        private Telerik.WinControls.UI.RadGridView grdRecentJobs;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private UI.MyDatePicker dtp_RecentJobs_EndDate;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private UI.MyDatePicker dtp_recentJob_StartDate;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadTextBox txtDestination;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadTextBox txtVia;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadTextBox txtPickup;
        private Telerik.WinControls.UI.RadRadioButton opt_JReturnWay;
        private Telerik.WinControls.UI.RadRadioButton opt_JOneWay;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        private Telerik.WinControls.UI.RadDropDownList ddlVehicleType;
        private Telerik.WinControls.UI.RadTextBox txtMobileNo;
        private Telerik.WinControls.UI.RadLabel radLabel22;

        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private Telerik.WinControls.UI.RadLabel lblEmail;

        private Telerik.WinControls.UI.RadTextBox txtPhoneNo;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel radLabel20;
        private Telerik.WinControls.UI.RadDropDownList ddlCust;
        private Telerik.WinControls.UI.RadLabel radLabel25;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
        private Telerik.WinControls.UI.RadLabel radLabel24;
        private Telerik.WinControls.UI.RadDropDownList ddlDriver;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadDropDownList ddlPaymentType;
        private Telerik.WinControls.UI.RadButton btnViewJob;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadPageViewPage Pg_Stats;
        private Telerik.WinControls.UI.RadPanel radPanel8;
        private Telerik.WinControls.UI.RadLabel radLabel43;
        private Telerik.WinControls.UI.RadLabel radLabel44;
        private Telerik.WinControls.UI.RadLabel radLabel45;
        private Telerik.WinControls.UI.RadLabel radLabel46;
        private Telerik.WinControls.UI.RadLabel radLabel47;
        private Telerik.WinControls.UI.RadLabel radLabel48;
        private Telerik.WinControls.UI.RadLabel radLabel49;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadLabel radLabel50;
        private Telerik.WinControls.UI.RadLabel radLabel51;
        private Telerik.WinControls.UI.RadLabel radLabel52;
        private Telerik.WinControls.UI.RadLabel radLabel53;
        private Telerik.WinControls.UI.RadLabel radLabel54;
        private Telerik.WinControls.UI.RadToggleButton btnHideMap;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadPageViewPage Pg_PreBookings;
        private Telerik.WinControls.UI.RadGridView grdPreBookings;
        private System.Windows.Forms.Panel panel4;
        private Telerik.WinControls.UI.RadPageViewPage Pg_AllJobs;
        private Telerik.WinControls.UI.RadGridView grdAllJobs;
        private System.Windows.Forms.Panel panel5;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPanel pnlActions;
        private Telerik.WinControls.UI.RadButton btnNewJob;
        private Telerik.WinControls.UI.RadButton btnShowMap;
        private Telerik.WinControls.UI.RadButton btnDespatchJob;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadPageViewPage Pg_DrvBookingStats;
        private System.Windows.Forms.Panel pnlChart;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadGridView grdStats;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart DriverChart;
        private Telerik.WinControls.UI.RadToggleButton btnHideBooking;
        private Telerik.WinControls.UI.RadButton btnDeleteSelected;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadTextBox txtRefNumber;
        public System.Windows.Forms.Timer timer_WebBooking;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnShowAllPreBooking;
        private UI.MyDatePicker dtpToDatePreBook;
        private System.Windows.Forms.Label label4;
        private UI.MyDatePicker dtpFromDatePreBook;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnFindPreBooking;
        private Telerik.WinControls.UI.RadTextBox txtOrderNo;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadPanel radPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlDriverWaiting;
        private Telerik.WinControls.UI.RadGridView grdDriverWaiting;
        private System.Windows.Forms.Panel pnlDriverOnBoard;
        private Telerik.WinControls.UI.RadGridView grdOnBoardDriver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdOnPlotDrivers;
        private Telerik.WinControls.UI.RadPanel pnlOnPlotDrivers;
        private System.Windows.Forms.Label lblDriverWaiting;
        private System.Windows.Forms.WebBrowser Map_PendingGoogle;
        private System.Windows.Forms.Label lblOnPlot;
        private Telerik.WinControls.UI.RadPageViewPage Pg_Quotations;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnShowAllQuotation;
        private UI.MyDatePicker dtpToQuotation;
        private System.Windows.Forms.Label label6;
        private UI.MyDatePicker dtpFromQuotation;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadButton btnFindQuotations;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadGridView grdQuotations;
        private Telerik.WinControls.UI.RadButton btnEmail;
        private System.Windows.Forms.Panel pnlStatsHeader;
        private System.Windows.Forms.Panel pnlMonthWise;
        private System.Windows.Forms.Label label1;
        private UI.MyDatePicker dtpStatsFromDate;
        private System.Windows.Forms.Label label2;
        private UI.MyDatePicker dtpStatsTillDate;
        private Telerik.WinControls.UI.RadRadioButton optMonthWise;
        private Telerik.WinControls.UI.RadRadioButton optDriverWise;
        private Telerik.WinControls.UI.RadButton btnPreview;
        private System.Windows.Forms.Timer tmrAlert;
        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadDropDownList ddlColumns;
        private System.Windows.Forms.Label label8;
        private Telerik.WinControls.UI.RadSplitButton btnSMS;
        // new layout controls
        private Telerik.WinControls.UI.RadSplitButton btnOption;

        private new Telerik.WinControls.UI.RadButton btnShuttle;

        public Telerik.WinControls.UI.RadMenuItem chkEnableAutoDespatch;
        public Telerik.WinControls.UI.RadMenuItem chkEnableBidding;
        private Telerik.WinControls.UI.RadMenuItem btnAirportArrivals_new;
        private Telerik.WinControls.UI.RadMenuItem btnHideMap_new;
        private Telerik.WinControls.UI.RadMenuItem btnHideBooking_new;

        private Telerik.WinControls.UI.RadRadioButtonElement chkEnableAutoDespatchNormalMode;
        private Telerik.WinControls.UI.RadRadioButtonElement chkEnableAutoDespatchQuiteMode;
        private Telerik.WinControls.UI.RadRadioButtonElement chkEnableAutoDespatchBusyMode;

        //


        private Telerik.WinControls.UI.RadMenuItem btnwritesms;
        private Telerik.WinControls.UI.RadMenuItem btnInbox;
        private Telerik.WinControls.UI.RadSplitButton btnLostProperty;
        private Telerik.WinControls.UI.RadMenuItem btnAddLostProperty;
        private Telerik.WinControls.UI.RadMenuItem btnLostPropertyList;
        private Telerik.WinControls.UI.RadPanel radPanel9;
        private Telerik.WinControls.UI.RadButton btnRecentShowAll;
        private Telerik.WinControls.UI.RadButton btnRecentFind;
        private Telerik.WinControls.UI.RadTextBox txtPassengerRecent;
        private Telerik.WinControls.UI.RadTextBox txtMobileRecent;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBox txtPhoneRecent;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private System.Windows.Forms.Label label13;
        private UI.MyDatePicker dtpToDateRecent;
        private System.Windows.Forms.Label label9;
        private UI.MyDatePicker dtpFromDateRecent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Telerik.WinControls.UI.RadDropDownList ddlBookingStatus;
        private Telerik.WinControls.UI.RadTextBox txtSearchRec;
        private Telerik.WinControls.UI.RadDropDownList ddlRecentColumn;
        private System.Windows.Forms.Label label10;
        private Telerik.WinControls.UI.RadMenuItem btnComplaints;
        private Telerik.WinControls.UI.RadPanel pnlNotification;
        private Telerik.WinControls.UI.RadLabel lblNotification;
        private Telerik.WinControls.UI.RadMenuItem btnPDAInbox;
        private Telerik.WinControls.UI.RadButton btnRecover;
        private Telerik.WinControls.UI.RadMenuItem btnMessageAllDrivers;
        private Telerik.WinControls.UI.RadRadioButton optToday;
        private System.Windows.Forms.Timer timer_Lic;
        private Telerik.WinControls.UI.RadButton btnclearSearchFilter;
        private Telerik.WinControls.UI.RadDropDownList ddlSearchDateType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlCompany;
        private Telerik.WinControls.UI.RadSplitButton btnPrintJobInfo;
        private Telerik.WinControls.UI.RadMenuItem btnViewPrint;
        private Telerik.WinControls.UI.RadMenuItem btnEmailPrint;
        private Telerik.WinControls.UI.RadPageViewPage Pg_NewWebBookings;
        private Telerik.WinControls.UI.RadPageViewPage Pg_PendingWebBookings;
        private Telerik.WinControls.UI.RadGridView grdWebBookingsNew;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadGridView grdWebBookingsPending;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadButton btnRefreshWaitingWebBooking;
        private Telerik.WinControls.UI.RadButton btnRefreshPendingWebBooking;
        private System.Windows.Forms.ListBox lst_cdr;
        private Telerik.WinControls.UI.RadLabel lblProgressBar;
        private Telerik.WinControls.UI.RadPageViewPage Pg_DeclinedWebBookings;
        private Telerik.WinControls.UI.RadGridView grdRejectedWebBookings;
        private Telerik.WinControls.UI.RadLabel radLabel26;
        private Telerik.WinControls.UI.RadPageViewPage Pg_BookingHistory;
        private Telerik.WinControls.UI.RadLabel radLabel27;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton btnLastRecords;
        private Telerik.WinControls.UI.RadButton btnNextRecord;
        private Telerik.WinControls.UI.RadButton btnPreviousRecords;
        private Telerik.WinControls.UI.RadButton btnFirstRecords;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadButton btnShowAllBookingHistory;
        private Telerik.WinControls.UI.RadButton radButton1;
        private UI.MyDatePicker dtpToDate;
        private System.Windows.Forms.Label label14;
        private UI.MyDatePicker dtpFromDate;
        private System.Windows.Forms.Label label15;
        private Telerik.WinControls.UI.RadButton btnFindBookingHistory;
        private Telerik.WinControls.UI.RadTextBox txtsearchBookingHistory;
        private Telerik.WinControls.UI.RadDropDownList ddlColumnBookingHistory;
        private System.Windows.Forms.Label label16;
        private Telerik.WinControls.UI.RadLabel lblProgressBookingHistory;
        private System.Windows.Forms.CheckBox chkShowAllocatedJobs;
        private System.Windows.Forms.RadioButton ChkShowAllJobs;
        private System.Windows.Forms.RadioButton chkShowACJobs;
        private System.Windows.Forms.RadioButton chkShowCashJobs;
        private Telerik.WinControls.UI.RadDropDownList ddlShowDue;
        private Telerik.WinControls.UI.RadButton btnRentPay;
        private Telerik.WinControls.UI.RadLabel txtNewWebBookingTotal;
        private Telerik.WinControls.UI.RadLabel txtPendingWebBookingTotal;
        private Telerik.WinControls.UI.RadLabel txtDeclinedWebBookingTotal;
        private System.Windows.Forms.CheckBox chkShowAllocatedTodayJobs;
        private System.Windows.Forms.Label label17;
        private Telerik.WinControls.UI.RadRadioButton optSortPickupDate;
        private Telerik.WinControls.UI.RadRadioButton optSortDriver;
        private Telerik.WinControls.UI.RadRadioButton optSortTodayPickup;
        private Telerik.WinControls.UI.RadRadioButton optSortTodayDriver;
        private Telerik.WinControls.UI.RadPageViewPage pg_biddingjobs;
        private Telerik.WinControls.UI.RadLabel radLabel28;
        private Telerik.WinControls.UI.RadGridView grdBiddingJobs;
        private System.Windows.Forms.Button btnRefreshDrvBidding;
        private Telerik.WinControls.UI.RadCheckBox chkQuotation;
        private System.Windows.Forms.Button btnAirportArrivals;
        private Telerik.WinControls.UI.RadButton btnPrintSelected;
        private System.Windows.Forms.CheckBox chkShowAuthorization;
        private Telerik.WinControls.UI.RadTextBox txtPaymentRef;
        private Telerik.WinControls.UI.RadLabel radLabel29;
        private Telerik.WinControls.UI.RadLabel radLabel30;
        private Telerik.WinControls.UI.RadDropDownList ddlBookingType;
        private Telerik.WinControls.UI.RadTextBox txtTokenNo;
        private Telerik.WinControls.UI.RadLabel lblTokenNo;
        private Telerik.WinControls.UI.RadDropDownList ddlSubCompany;
        //private Telerik.WinControls.UI.RadPageViewPage Pg_PoolJobs;
        //private Telerik.WinControls.UI.RadPanel radPanel5;
        //private Telerik.WinControls.UI.RadButton btnShowAllJobsPool;
        //private UI.MyDatePicker dtpTillJobsPool;
        //private System.Windows.Forms.Label label18;
        //private UI.MyDatePicker dtpFromJobsPool;
        //private System.Windows.Forms.Label label19;
        //private Telerik.WinControls.UI.RadButton btnSearchJobsPool;
        //private Telerik.WinControls.UI.RadLabel radLabel31;
        //private Telerik.WinControls.UI.RadGridView grdJobsPool;

        private Telerik.WinControls.UI.RadPageViewPage Pg_PoolJobs;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadButton btnShowAllJobsPool;
        private UI.MyDatePicker dtpTillJobsPool;
        private System.Windows.Forms.Label label18;
        private UI.MyDatePicker dtpFromJobsPool;
        private System.Windows.Forms.Label label19;
        private Telerik.WinControls.UI.RadButton btnSearchJobsPool;
        private Telerik.WinControls.UI.RadLabel radLabel31;
        private Telerik.WinControls.UI.RadGridView grdJobsPool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadGridView grdAcceptorPooljobs;
        private Telerik.WinControls.UI.RadPanel radPanel6;
        private Telerik.WinControls.UI.RadLabel lblPoolJobs;
        private System.Windows.Forms.Panel pnlTransferredPool;
        private Telerik.WinControls.UI.RadLabel lblTransferredJobs;
        private System.Windows.Forms.Label lblError;



        private Telerik.WinControls.UI.RadLabel radLabel32;
        private Telerik.WinControls.UI.RadDropDownList ddlCompanyVehicle;
        private Telerik.WinControls.UI.RadCheckBox chkAvailableRecordings;
        private Telerik.WinControls.UI.RadLabel lblSearchResults;
        private Telerik.WinControls.UI.RadPanel panel2;
        private System.Windows.Forms.DataGridView grdDriverPricePlot;
        private System.Windows.Forms.Label label20;
        private Telerik.WinControls.UI.RadPageViewPage Pg_NoShow;
        private Telerik.WinControls.UI.RadGridView grdNoShowJobs;
        private Telerik.WinControls.UI.RadLabel radLabel33;
        private Telerik.WinControls.UI.RadPageViewPage Pg_Cancelled;
        private Telerik.WinControls.UI.RadGridView grdCancelledJobs;
        private Telerik.WinControls.UI.RadLabel radLabel34;
        private RadTextBox txtCommand;
        private Label label21;
        private RadDropDownList ddlJobsSortBy;
        private CheckBox chkTodayCancelled;

        private Telerik.WinControls.UI.RadLabel radLabel35;
        
        private RadDropDownList ddlJourneyType;
        private RadDropDownList ddlSubCompanyPreBooking;
    }
}