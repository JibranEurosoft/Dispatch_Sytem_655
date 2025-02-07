using System.Windows.Forms;

namespace Taxi_AppMain
{
    partial class frmDriver
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

        private void InitializePdaSettingsPanel()
        {
            //if (pnlSettings == null)
            //{
          

                //((System.ComponentModel.ISupportInitialize)(this.chkDisableChangeDest)).EndInit();
                // ((System.ComponentModel.ISupportInitialize)(this.chkDisableRejectJob)).EndInit();
//
                DisplayPDASettingsPanel();

            }


        


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition7 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radpageview1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblAccComm = new Telerik.WinControls.UI.RadLabel();
            this.numAccComm = new Telerik.WinControls.UI.RadSpinEditor();
            this.chkAccComm = new Telerik.WinControls.UI.RadCheckBox();
            this.numMinComm = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel51 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numTrainingCompletedHours = new Telerik.WinControls.UI.RadSpinEditor();
            this.numTrainingReqHours = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel48 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel49 = new Telerik.WinControls.UI.RadLabel();
            this.numMaxCommission = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblMaxCommission = new Telerik.WinControls.UI.RadLabel();
            this.ddlCategory = new UI.MyDropDownList();
            this.lblSubCompany = new Telerik.WinControls.UI.RadLabel();
            this.radLabel47 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel46 = new Telerik.WinControls.UI.RadLabel();
            this.txtSurName = new Telerik.WinControls.UI.RadTextBox();
            this.numPDARent = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblpdarent = new Telerik.WinControls.UI.RadLabel();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.radLabel45 = new Telerik.WinControls.UI.RadLabel();
            this.txtLogBookDocPath = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel44 = new Telerik.WinControls.UI.RadLabel();
            this.txtVehicleLogBookNo = new Telerik.WinControls.UI.RadTextBox();
            this.numRentLimit = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel43 = new Telerik.WinControls.UI.RadLabel();
            this.numInitialBalance = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel42 = new Telerik.WinControls.UI.RadLabel();
            this.pic_Driver = new UI.UserControls.MyPictureBox();
            this.ddlSubCompany = new System.Windows.Forms.ComboBox();
            this.radLabel29 = new Telerik.WinControls.UI.RadLabel();
            this.dtpVehEndOn = new UI.MyDatePicker();
            this.btnAssignedNew = new System.Windows.Forms.Button();
            this.radLabel28 = new Telerik.WinControls.UI.RadLabel();
            this.dtpVehAssignedOn = new UI.MyDatePicker();
            this.ddlVehicleColor = new UI.MyDropDownList();
            this.txtVehNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.ddlVehicleType = new UI.MyDropDownList();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel25 = new Telerik.WinControls.UI.RadLabel();
            this.txtVehModel = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel22 = new Telerik.WinControls.UI.RadLabel();
            this.txtVehOwner = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.txtVehMake = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel24 = new Telerik.WinControls.UI.RadLabel();
            this.btnPrintDriver = new Telerik.WinControls.UI.RadSplitButton();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuDriverLog = new Telerik.WinControls.UI.RadMenuItem();
            this.numDriverRentComm = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblDriverType = new Telerik.WinControls.UI.RadLabel();
            this.ddlDriverType = new UI.MyDropDownList();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.numVAT = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel50 = new Telerik.WinControls.UI.RadLabel();
            this.chkBidding = new Telerik.WinControls.UI.RadCheckBox();
            this.chkActiveDriver = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtWebLoginPwd = new Telerik.WinControls.UI.RadTextBox();
            this.chkHasPDA = new Telerik.WinControls.UI.RadCheckBox();
            this.chkHasRentPaid = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtDriverNo = new Telerik.WinControls.UI.RadTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEndDrier = new Telerik.WinControls.UI.RadCheckBox();
            this.btnClearAvail = new System.Windows.Forms.Button();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.dtpEndingDate = new UI.MyDatePicker();
            this.btnAddAvailability = new System.Windows.Forms.Button();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.dtpAvailDate = new UI.MyDatePicker();
            this.grdAvailability = new UI.MyGridView();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.txtAddress = new UI.AutoCompleteTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtNI = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdDocuments = new UI.MyGridView();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.dtpDOB = new UI.MyDatePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtDriverName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.txtMobileNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtTelephoneNo = new Telerik.WinControls.UI.RadTextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.pg_Shifts = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdDriverShifts = new Telerik.WinControls.UI.RadGridView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtAffiliateKey = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel52 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_Comments = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel34 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_PDADeposits = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel33 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_DataAllowance = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel31 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_NetworkAPN = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel38 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_Model = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel41 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel36 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_Number = new Telerik.WinControls.UI.RadTextBox();
            this.txt_SIM_Make = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel37 = new Telerik.WinControls.UI.RadLabel();
            this.dtp_SIM_PDADateGiven = new UI.MyDatePicker();
            this.radLabel40 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel39 = new Telerik.WinControls.UI.RadLabel();
            this.txt_SIM_NetworkName = new Telerik.WinControls.UI.RadTextBox();
            this.txt_SIM_IMEI = new Telerik.WinControls.UI.RadTextBox();
            this.pg_pdasettings = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnlSettings = new System.Windows.Forms.GroupBox();
            this.ddlHidePickupAndDestinationType = new System.Windows.Forms.ComboBox();
            this.chkShowDestAfterPOB = new System.Windows.Forms.CheckBox();
            this.chkVoiceOnClearMeter = new System.Windows.Forms.CheckBox();
            this.chkDisableJobAuth = new System.Windows.Forms.CheckBox();
            this.chkEnablePriceBidding = new System.Windows.Forms.CheckBox();
            this.chkEnableDriverConnect = new System.Windows.Forms.CheckBox();
            this.chkDisableSTC = new System.Windows.Forms.CheckBox();
            this.chkEnableManualFares = new System.Windows.Forms.CheckBox();
            this.chkDisableFareOnAccJob = new System.Windows.Forms.CheckBox();
            this.chkDisableAlarm = new System.Windows.Forms.CheckBox();
            this.chkEnableOptionalManualFares = new System.Windows.Forms.CheckBox();
            this.chkDisableNoPickup = new System.Windows.Forms.CheckBox();
            this.txtPDAVer = new System.Windows.Forms.Label();
            this.btnUpdateSettings = new Telerik.WinControls.UI.RadButton();
            this.chkDisableOnBreak = new System.Windows.Forms.CheckBox();
            this.chkShiftOverLogout = new System.Windows.Forms.CheckBox();
            this.chkShowSpecReq = new System.Windows.Forms.CheckBox();
            this.chkShowJobAsAlert = new System.Windows.Forms.CheckBox();
            this.chkDisableBase = new System.Windows.Forms.CheckBox();
            this.chkShowFareonExtraCharges = new System.Windows.Forms.CheckBox();
            this.chkEnableLogoutOnReject = new System.Windows.Forms.CheckBox();
            this.chkHidePickupAndDest = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numJobTimeout = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBiddingMessage = new System.Windows.Forms.Label();
            this.txtFareMessage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numBreakDuration = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDisableMeterAccJob = new System.Windows.Forms.CheckBox();
            this.chkEnableMeterWaitingCharges = new System.Windows.Forms.CheckBox();
            this.chkEnableOptionalMeter = new System.Windows.Forms.CheckBox();
            this.chkShowSoundOnZoneChange = new System.Windows.Forms.CheckBox();
            this.chkDisableChangeJobPlot = new System.Windows.Forms.CheckBox();
            this.chkDisableRank = new System.Windows.Forms.CheckBox();
            this.chkDisablePanic = new System.Windows.Forms.CheckBox();
            this.chkIgnoreArriveAction = new System.Windows.Forms.CheckBox();
            this.chkMessageStay = new System.Windows.Forms.CheckBox();
            this.ShowPlotOnJobOffer = new System.Windows.Forms.CheckBox();
            this.chkShowAlertOnJobLater = new System.Windows.Forms.CheckBox();
            this.chkShowCustomerMobileNo = new System.Windows.Forms.CheckBox();
            this.chkShowNavigation = new System.Windows.Forms.CheckBox();
            this.chkShowCompletedJobs = new System.Windows.Forms.CheckBox();
            this.chkShowPlots = new System.Windows.Forms.CheckBox();
            this.chkEnableAutoRotate = new System.Windows.Forms.CheckBox();
            this.chkEnableCompanyCars = new System.Windows.Forms.CheckBox();
            this.chkEnableJ15Jobs = new System.Windows.Forms.CheckBox();
            this.chkEnableCallCustomer = new System.Windows.Forms.CheckBox();
            this.chkEnableJobExtraCharges = new System.Windows.Forms.CheckBox();
            this.chkEnableRecoverJob = new System.Windows.Forms.CheckBox();
            this.chkEnableLogoutAuthorization = new System.Windows.Forms.CheckBox();
            this.chkEnableFlagDown = new System.Windows.Forms.CheckBox();
            this.chkEnableFareMeter = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkEnableBidding = new System.Windows.Forms.CheckBox();
            this.ddlNavigation = new System.Windows.Forms.ComboBox();
            this.chkDisableChangeDest = new System.Windows.Forms.CheckBox();
            this.chkDisableRejectJob = new System.Windows.Forms.CheckBox();
            this.Pg_notes = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.grdLister = new Telerik.WinControls.UI.RadGridView();
            this.btnNew = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.txtNotes = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel35 = new Telerik.WinControls.UI.RadLabel();
            this.pg_complaint = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdDriverComplaints = new Telerik.WinControls.UI.RadGridView();
            this.Pg_Attributes = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdDriverAttributes = new Telerik.WinControls.UI.RadGridView();
            this.Pg_Rating = new Telerik.WinControls.UI.RadPageViewPage();
            this.CompanyVehicle = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdCompanyVehicles = new Telerik.WinControls.UI.RadGridView();
            this.pg_charges = new Telerik.WinControls.UI.RadPageViewPage();
            this.grdDebitCreditNotes = new Telerik.WinControls.UI.RadGridView();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.DrirverRating = new Telerik.WinControls.UI.RadMenuItem();
            this.object_8d9a8a89_3408_492c_97b0_6d603c29a72e = new Telerik.WinControls.RootRadElement();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radpageview1)).BeginInit();
            this.radpageview1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAccComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingCompletedHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingReqHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPDARent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblpdarent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogBookDocPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleLogBookNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRentLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVehEndOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVehAssignedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDriverRentComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDriverType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriverType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBidding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebLoginPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasPDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasRentPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverNo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEndDrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndingDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAvailDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailability.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephoneNo)).BeginInit();
            this.pg_Shifts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverShifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverShifts.MasterTemplate)).BeginInit();
            this.radPageViewPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAffiliateKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Comments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_PDADeposits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_DataAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_NetworkAPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Model)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Make)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_SIM_PDADateGiven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_NetworkName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_IMEI)).BeginInit();
            this.pg_pdasettings.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJobTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakDuration)).BeginInit();
            this.Pg_notes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).BeginInit();
            this.pg_complaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverComplaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverComplaints.MasterTemplate)).BeginInit();
            this.Pg_Attributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes.MasterTemplate)).BeginInit();
            this.CompanyVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyVehicles.MasterTemplate)).BeginInit();
            this.pg_charges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDebitCreditNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDebitCreditNotes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveOn
            // 
            this.btnSaveOn.Location = new System.Drawing.Point(898, 250);
            this.btnSaveOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnOnNew
            // 
            this.btnOnNew.Location = new System.Drawing.Point(896, 251);
            this.btnOnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(970, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Size = new System.Drawing.Size(77, 38);
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(895, 633);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Location = new System.Drawing.Point(791, 633);
            this.btnSaveAndNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // radpageview1
            // 
            this.radpageview1.Controls.Add(this.radPageViewPage1);
            this.radpageview1.Controls.Add(this.pg_Shifts);
            this.radpageview1.Controls.Add(this.radPageViewPage2);
            this.radpageview1.Controls.Add(this.radPageViewPage3);
            this.radpageview1.Controls.Add(this.radPageViewPage4);
            this.radpageview1.Controls.Add(this.pg_pdasettings);
            this.radpageview1.Controls.Add(this.Pg_notes);
            this.radpageview1.Controls.Add(this.pg_complaint);
            this.radpageview1.Controls.Add(this.Pg_Attributes);
            this.radpageview1.Controls.Add(this.Pg_Rating);
            this.radpageview1.Controls.Add(this.CompanyVehicle);
            this.radpageview1.Controls.Add(this.pg_charges);
            this.radpageview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radpageview1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radpageview1.Location = new System.Drawing.Point(0, 38);
            this.radpageview1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radpageview1.Name = "radpageview1";
            this.radpageview1.SelectedPage = this.radPageViewPage1;
            this.radpageview1.Size = new System.Drawing.Size(1050, 722);
            this.radpageview1.TabIndex = 108;
            this.radpageview1.Text = "radPageView1";
            this.radpageview1.PageIndexChanged += new System.EventHandler<Telerik.WinControls.UI.RadPageViewIndexChangedEventArgs>(this.radpageview1_PageIndexChanged);
            this.radpageview1.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.radpageview1_SelectedPageChanging);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radpageview1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.radPanel1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1029, 675);
            this.radPageViewPage1.Text = "Driver Info";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radPanel1.Controls.Add(this.lblAccComm);
            this.radPanel1.Controls.Add(this.numAccComm);
            this.radPanel1.Controls.Add(this.chkAccComm);
            this.radPanel1.Controls.Add(this.numMinComm);
            this.radPanel1.Controls.Add(this.radLabel51);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.txtRating);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Controls.Add(this.numTrainingCompletedHours);
            this.radPanel1.Controls.Add(this.numTrainingReqHours);
            this.radPanel1.Controls.Add(this.radLabel48);
            this.radPanel1.Controls.Add(this.radLabel49);
            this.radPanel1.Controls.Add(this.numMaxCommission);
            this.radPanel1.Controls.Add(this.lblMaxCommission);
            this.radPanel1.Controls.Add(this.ddlCategory);
            this.radPanel1.Controls.Add(this.lblSubCompany);
            this.radPanel1.Controls.Add(this.radLabel47);
            this.radPanel1.Controls.Add(this.radLabel46);
            this.radPanel1.Controls.Add(this.txtSurName);
            this.radPanel1.Controls.Add(this.numPDARent);
            this.radPanel1.Controls.Add(this.lblpdarent);
            this.radPanel1.Controls.Add(this.btnClear);
            this.radPanel1.Controls.Add(this.btnView);
            this.radPanel1.Controls.Add(this.btnBrowse);
            this.radPanel1.Controls.Add(this.radLabel45);
            this.radPanel1.Controls.Add(this.txtLogBookDocPath);
            this.radPanel1.Controls.Add(this.radLabel44);
            this.radPanel1.Controls.Add(this.txtVehicleLogBookNo);
            this.radPanel1.Controls.Add(this.numRentLimit);
            this.radPanel1.Controls.Add(this.radLabel43);
            this.radPanel1.Controls.Add(this.numInitialBalance);
            this.radPanel1.Controls.Add(this.radLabel42);
            this.radPanel1.Controls.Add(this.pic_Driver);
            this.radPanel1.Controls.Add(this.ddlSubCompany);
            this.radPanel1.Controls.Add(this.radLabel29);
            this.radPanel1.Controls.Add(this.dtpVehEndOn);
            this.radPanel1.Controls.Add(this.btnAssignedNew);
            this.radPanel1.Controls.Add(this.radLabel28);
            this.radPanel1.Controls.Add(this.dtpVehAssignedOn);
            this.radPanel1.Controls.Add(this.ddlVehicleColor);
            this.radPanel1.Controls.Add(this.txtVehNo);
            this.radPanel1.Controls.Add(this.radLabel14);
            this.radPanel1.Controls.Add(this.ddlVehicleType);
            this.radPanel1.Controls.Add(this.radLabel17);
            this.radPanel1.Controls.Add(this.radLabel25);
            this.radPanel1.Controls.Add(this.txtVehModel);
            this.radPanel1.Controls.Add(this.radLabel22);
            this.radPanel1.Controls.Add(this.txtVehOwner);
            this.radPanel1.Controls.Add(this.radLabel23);
            this.radPanel1.Controls.Add(this.txtVehMake);
            this.radPanel1.Controls.Add(this.radLabel24);
            this.radPanel1.Controls.Add(this.btnPrintDriver);
            this.radPanel1.Controls.Add(this.numDriverRentComm);
            this.radPanel1.Controls.Add(this.lblDriverType);
            this.radPanel1.Controls.Add(this.ddlDriverType);
            this.radPanel1.Controls.Add(this.radLabel16);
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Controls.Add(this.panel1);
            this.radPanel1.Controls.Add(this.txtAddress);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radLabel8);
            this.radPanel1.Controls.Add(this.txtNI);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.grdDocuments);
            this.radPanel1.Controls.Add(this.radLabel21);
            this.radPanel1.Controls.Add(this.radLabel7);
            this.radPanel1.Controls.Add(this.dtpDOB);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.txtDriverName);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.txtEmail);
            this.radPanel1.Controls.Add(this.radLabel9);
            this.radPanel1.Controls.Add(this.txtMobileNo);
            this.radPanel1.Controls.Add(this.radLabel10);
            this.radPanel1.Controls.Add(this.txtTelephoneNo);
            this.radPanel1.Controls.Add(this.btnSaveChanges);
            this.radPanel1.Location = new System.Drawing.Point(-1, 4);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1025, 680);
            this.radPanel1.TabIndex = 108;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 1F;
            // 
            // lblAccComm
            // 
            this.lblAccComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccComm.Location = new System.Drawing.Point(775, 319);
            this.lblAccComm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAccComm.Name = "lblAccComm";
            this.lblAccComm.Size = new System.Drawing.Size(93, 18);
            this.lblAccComm.TabIndex = 266;
            this.lblAccComm.Text = "Acc Comm. %";
            this.lblAccComm.Visible = false;
            // 
            // numAccComm
            // 
            this.numAccComm.DecimalPlaces = 2;
            this.numAccComm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAccComm.InterceptArrowKeys = false;
            this.numAccComm.Location = new System.Drawing.Point(874, 313);
            this.numAccComm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numAccComm.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAccComm.Name = "numAccComm";
            // 
            // 
            // 
            this.numAccComm.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numAccComm.RootElement.StretchVertically = true;
            this.numAccComm.ShowUpDownButtons = false;
            this.numAccComm.Size = new System.Drawing.Size(46, 26);
            this.numAccComm.TabIndex = 264;
            this.numAccComm.TabStop = false;
            this.numAccComm.Visible = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numAccComm.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // chkAccComm
            // 
            this.chkAccComm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAccComm.Location = new System.Drawing.Point(572, 317);
            this.chkAccComm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAccComm.Name = "chkAccComm";
            // 
            // 
            // 
            this.chkAccComm.RootElement.StretchHorizontally = true;
            this.chkAccComm.RootElement.StretchVertically = true;
            this.chkAccComm.Size = new System.Drawing.Size(213, 22);
            this.chkAccComm.TabIndex = 265;
            this.chkAccComm.Text = "Different Comm on Acc Job";
            this.chkAccComm.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAccComm_ToggleStateChanged);
            // 
            // numMinComm
            // 
            this.numMinComm.DecimalPlaces = 2;
            this.numMinComm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinComm.InterceptArrowKeys = false;
            this.numMinComm.Location = new System.Drawing.Point(712, 161);
            this.numMinComm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMinComm.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinComm.Name = "numMinComm";
            // 
            // 
            // 
            this.numMinComm.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numMinComm.RootElement.StretchVertically = true;
            this.numMinComm.ShowUpDownButtons = false;
            this.numMinComm.Size = new System.Drawing.Size(73, 26);
            this.numMinComm.TabIndex = 262;
            this.numMinComm.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numMinComm.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // radLabel51
            // 
            this.radLabel51.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel51.Location = new System.Drawing.Point(624, 164);
            this.radLabel51.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel51.Name = "radLabel51";
            this.radLabel51.Size = new System.Drawing.Size(73, 18);
            this.radLabel51.TabIndex = 261;
            this.radLabel51.Text = "Min. Comm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(947, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 260;
            this.label3.Text = "\\5";
            this.label3.Visible = false;
            // 
            // txtRating
            // 
            this.txtRating.AutoSize = true;
            this.txtRating.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.txtRating.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtRating.Location = new System.Drawing.Point(846, 60);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(102, 58);
            this.txtRating.TabIndex = 259;
            this.txtRating.Text = "0.0";
            this.txtRating.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(869, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 258;
            this.label1.Text = "Rating";
            this.label1.Visible = false;
            // 
            // numTrainingCompletedHours
            // 
            this.numTrainingCompletedHours.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTrainingCompletedHours.InterceptArrowKeys = false;
            this.numTrainingCompletedHours.Location = new System.Drawing.Point(222, 731);
            this.numTrainingCompletedHours.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numTrainingCompletedHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTrainingCompletedHours.Name = "numTrainingCompletedHours";
            // 
            // 
            // 
            this.numTrainingCompletedHours.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numTrainingCompletedHours.RootElement.StretchVertically = true;
            this.numTrainingCompletedHours.ShowUpDownButtons = false;
            this.numTrainingCompletedHours.Size = new System.Drawing.Size(61, 26);
            this.numTrainingCompletedHours.TabIndex = 257;
            this.numTrainingCompletedHours.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numTrainingCompletedHours.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // numTrainingReqHours
            // 
            this.numTrainingReqHours.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTrainingReqHours.InterceptArrowKeys = false;
            this.numTrainingReqHours.Location = new System.Drawing.Point(222, 702);
            this.numTrainingReqHours.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numTrainingReqHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTrainingReqHours.Name = "numTrainingReqHours";
            // 
            // 
            // 
            this.numTrainingReqHours.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numTrainingReqHours.RootElement.StretchVertically = true;
            this.numTrainingReqHours.ShowUpDownButtons = false;
            this.numTrainingReqHours.Size = new System.Drawing.Size(61, 26);
            this.numTrainingReqHours.TabIndex = 256;
            this.numTrainingReqHours.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numTrainingReqHours.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // radLabel48
            // 
            this.radLabel48.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel48.ForeColor = System.Drawing.Color.Purple;
            this.radLabel48.Location = new System.Drawing.Point(5, 734);
            this.radLabel48.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel48.Name = "radLabel48";
            this.radLabel48.Size = new System.Drawing.Size(169, 18);
            this.radLabel48.TabIndex = 255;
            this.radLabel48.Text = "Training Completed Hours";
            // 
            // radLabel49
            // 
            this.radLabel49.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel49.ForeColor = System.Drawing.Color.Purple;
            this.radLabel49.Location = new System.Drawing.Point(5, 704);
            this.radLabel49.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel49.Name = "radLabel49";
            this.radLabel49.Size = new System.Drawing.Size(158, 18);
            this.radLabel49.TabIndex = 254;
            this.radLabel49.Text = "Training Required Hours";
            // 
            // numMaxCommission
            // 
            this.numMaxCommission.DecimalPlaces = 2;
            this.numMaxCommission.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxCommission.InterceptArrowKeys = false;
            this.numMaxCommission.Location = new System.Drawing.Point(712, 134);
            this.numMaxCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMaxCommission.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxCommission.Name = "numMaxCommission";
            // 
            // 
            // 
            this.numMaxCommission.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numMaxCommission.RootElement.StretchVertically = true;
            this.numMaxCommission.ShowUpDownButtons = false;
            this.numMaxCommission.Size = new System.Drawing.Size(73, 26);
            this.numMaxCommission.TabIndex = 251;
            this.numMaxCommission.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numMaxCommission.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // lblMaxCommission
            // 
            this.lblMaxCommission.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCommission.Location = new System.Drawing.Point(625, 137);
            this.lblMaxCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMaxCommission.Name = "lblMaxCommission";
            this.lblMaxCommission.Size = new System.Drawing.Size(72, 18);
            this.lblMaxCommission.TabIndex = 250;
            this.lblMaxCommission.Text = "Max Comm:";
            // 
            // ddlCategory
            // 
            this.ddlCategory.Caption = null;
            this.ddlCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCategory.Location = new System.Drawing.Point(644, 288);
            this.ddlCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Property = null;
            this.ddlCategory.ShowDownArrow = true;
            this.ddlCategory.Size = new System.Drawing.Size(141, 21);
            this.ddlCategory.TabIndex = 249;
            // 
            // lblSubCompany
            // 
            this.lblSubCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblSubCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCompany.Location = new System.Drawing.Point(694, 5);
            this.lblSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSubCompany.Name = "lblSubCompany";
            this.lblSubCompany.Size = new System.Drawing.Size(99, 19);
            this.lblSubCompany.TabIndex = 223;
            this.lblSubCompany.Text = "Sub Company";
            // 
            // radLabel47
            // 
            this.radLabel47.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel47.Location = new System.Drawing.Point(572, 290);
            this.radLabel47.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel47.Name = "radLabel47";
            this.radLabel47.Size = new System.Drawing.Size(63, 18);
            this.radLabel47.TabIndex = 248;
            this.radLabel47.Text = "Category";
            // 
            // radLabel46
            // 
            this.radLabel46.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel46.Location = new System.Drawing.Point(371, 105);
            this.radLabel46.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel46.Name = "radLabel46";
            this.radLabel46.Size = new System.Drawing.Size(56, 18);
            this.radLabel46.TabIndex = 247;
            this.radLabel46.Text = "SurName";
            // 
            // txtSurName
            // 
            this.txtSurName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurName.Location = new System.Drawing.Point(471, 106);
            this.txtSurName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurName.MaxLength = 30;
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(147, 21);
            this.txtSurName.TabIndex = 246;
            this.txtSurName.TabStop = false;
            // 
            // numPDARent
            // 
            this.numPDARent.DecimalPlaces = 2;
            this.numPDARent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPDARent.InterceptArrowKeys = false;
            this.numPDARent.Location = new System.Drawing.Point(712, 191);
            this.numPDARent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPDARent.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPDARent.Name = "numPDARent";
            // 
            // 
            // 
            this.numPDARent.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numPDARent.RootElement.StretchVertically = true;
            this.numPDARent.ShowUpDownButtons = false;
            this.numPDARent.Size = new System.Drawing.Size(73, 26);
            this.numPDARent.TabIndex = 237;
            this.numPDARent.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numPDARent.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // lblpdarent
            // 
            this.lblpdarent.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpdarent.Location = new System.Drawing.Point(637, 193);
            this.lblpdarent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblpdarent.Name = "lblpdarent";
            this.lblpdarent.Size = new System.Drawing.Size(58, 18);
            this.lblpdarent.TabIndex = 236;
            this.lblpdarent.Text = "PDA Rent";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(513, 641);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(59, 30);
            this.btnClear.TabIndex = 235;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(447, 641);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(59, 30);
            this.btnView.TabIndex = 234;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(377, 641);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 30);
            this.btnBrowse.TabIndex = 233;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // radLabel45
            // 
            this.radLabel45.AutoSize = false;
            this.radLabel45.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel45.Location = new System.Drawing.Point(310, 616);
            this.radLabel45.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel45.Name = "radLabel45";
            this.radLabel45.Size = new System.Drawing.Size(108, 44);
            this.radLabel45.TabIndex = 232;
            this.radLabel45.Text = "Vehicle Log Book Document";
            // 
            // txtLogBookDocPath
            // 
            this.txtLogBookDocPath.Enabled = false;
            this.txtLogBookDocPath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogBookDocPath.Location = new System.Drawing.Point(426, 619);
            this.txtLogBookDocPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogBookDocPath.MaxLength = 100;
            this.txtLogBookDocPath.Name = "txtLogBookDocPath";
            this.txtLogBookDocPath.Size = new System.Drawing.Size(146, 21);
            this.txtLogBookDocPath.TabIndex = 231;
            this.txtLogBookDocPath.TabStop = false;
            // 
            // radLabel44
            // 
            this.radLabel44.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel44.Location = new System.Drawing.Point(0, 619);
            this.radLabel44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel44.Name = "radLabel44";
            this.radLabel44.Size = new System.Drawing.Size(112, 18);
            this.radLabel44.TabIndex = 230;
            this.radLabel44.Text = "Vehicle Log Book #";
            // 
            // txtVehicleLogBookNo
            // 
            this.txtVehicleLogBookNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleLogBookNo.Location = new System.Drawing.Point(136, 618);
            this.txtVehicleLogBookNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehicleLogBookNo.MaxLength = 100;
            this.txtVehicleLogBookNo.Name = "txtVehicleLogBookNo";
            this.txtVehicleLogBookNo.Size = new System.Drawing.Size(146, 21);
            this.txtVehicleLogBookNo.TabIndex = 229;
            this.txtVehicleLogBookNo.TabStop = false;
            // 
            // numRentLimit
            // 
            this.numRentLimit.DecimalPlaces = 2;
            this.numRentLimit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRentLimit.InterceptArrowKeys = false;
            this.numRentLimit.Location = new System.Drawing.Point(710, 224);
            this.numRentLimit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numRentLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRentLimit.Name = "numRentLimit";
            // 
            // 
            // 
            this.numRentLimit.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numRentLimit.RootElement.StretchVertically = true;
            this.numRentLimit.ShowUpDownButtons = false;
            this.numRentLimit.Size = new System.Drawing.Size(73, 26);
            this.numRentLimit.TabIndex = 228;
            this.numRentLimit.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numRentLimit.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // radLabel43
            // 
            this.radLabel43.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel43.Location = new System.Drawing.Point(636, 226);
            this.radLabel43.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel43.Name = "radLabel43";
            this.radLabel43.Size = new System.Drawing.Size(62, 18);
            this.radLabel43.TabIndex = 227;
            this.radLabel43.Text = "Rent Limit";
            // 
            // numInitialBalance
            // 
            this.numInitialBalance.DecimalPlaces = 2;
            this.numInitialBalance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInitialBalance.InterceptArrowKeys = false;
            this.numInitialBalance.Location = new System.Drawing.Point(712, 258);
            this.numInitialBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numInitialBalance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numInitialBalance.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numInitialBalance.Name = "numInitialBalance";
            // 
            // 
            // 
            this.numInitialBalance.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numInitialBalance.RootElement.StretchVertically = true;
            this.numInitialBalance.ShowUpDownButtons = false;
            this.numInitialBalance.Size = new System.Drawing.Size(73, 26);
            this.numInitialBalance.TabIndex = 226;
            this.numInitialBalance.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numInitialBalance.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // radLabel42
            // 
            this.radLabel42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel42.Location = new System.Drawing.Point(601, 261);
            this.radLabel42.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel42.Name = "radLabel42";
            this.radLabel42.Size = new System.Drawing.Size(97, 18);
            this.radLabel42.TabIndex = 225;
            this.radLabel42.Text = "Initial Balance";
            // 
            // pic_Driver
            // 
            this.pic_Driver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Driver.FileName = null;
            this.pic_Driver.FilePath = null;
            this.pic_Driver.Location = new System.Drawing.Point(790, 132);
            this.pic_Driver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pic_Driver.Name = "pic_Driver";
            this.pic_Driver.ShowActionPanel = false;
            this.pic_Driver.Size = new System.Drawing.Size(233, 177);
            this.pic_Driver.TabIndex = 9;
            // 
            // ddlSubCompany
            // 
            this.ddlSubCompany.BackColor = System.Drawing.Color.White;
            this.ddlSubCompany.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ddlSubCompany.FormattingEnabled = true;
            this.ddlSubCompany.Location = new System.Drawing.Point(813, 2);
            this.ddlSubCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlSubCompany.Name = "ddlSubCompany";
            this.ddlSubCompany.Size = new System.Drawing.Size(212, 24);
            this.ddlSubCompany.TabIndex = 222;
            // 
            // radLabel29
            // 
            this.radLabel29.Enabled = false;
            this.radLabel29.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel29.Location = new System.Drawing.Point(286, 517);
            this.radLabel29.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel29.Name = "radLabel29";
            this.radLabel29.Size = new System.Drawing.Size(51, 18);
            this.radLabel29.TabIndex = 224;
            this.radLabel29.Text = "End On";
            // 
            // dtpVehEndOn
            // 
            this.dtpVehEndOn.CustomFormat = "dd/MM/yyyy";
            this.dtpVehEndOn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVehEndOn.Location = new System.Drawing.Point(358, 516);
            this.dtpVehEndOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpVehEndOn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVehEndOn.Name = "dtpVehEndOn";
            this.dtpVehEndOn.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVehEndOn.Size = new System.Drawing.Size(113, 21);
            this.dtpVehEndOn.TabIndex = 223;
            this.dtpVehEndOn.TabStop = false;
            this.dtpVehEndOn.Value = null;
            // 
            // btnAssignedNew
            // 
            this.btnAssignedNew.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAssignedNew.Enabled = false;
            this.btnAssignedNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignedNew.Location = new System.Drawing.Point(481, 512);
            this.btnAssignedNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAssignedNew.Name = "btnAssignedNew";
            this.btnAssignedNew.Size = new System.Drawing.Size(87, 32);
            this.btnAssignedNew.TabIndex = 222;
            this.btnAssignedNew.Text = "End Vehicle";
            this.btnAssignedNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssignedNew.UseVisualStyleBackColor = false;
            this.btnAssignedNew.Click += new System.EventHandler(this.btnAssignedNew_Click);
            // 
            // radLabel28
            // 
            this.radLabel28.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel28.Location = new System.Drawing.Point(10, 516);
            this.radLabel28.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel28.Name = "radLabel28";
            this.radLabel28.Size = new System.Drawing.Size(83, 18);
            this.radLabel28.TabIndex = 221;
            this.radLabel28.Text = "Assigned On";
            // 
            // dtpVehAssignedOn
            // 
            this.dtpVehAssignedOn.CustomFormat = "dd/MM/yyyy";
            this.dtpVehAssignedOn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVehAssignedOn.Location = new System.Drawing.Point(135, 515);
            this.dtpVehAssignedOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpVehAssignedOn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVehAssignedOn.Name = "dtpVehAssignedOn";
            this.dtpVehAssignedOn.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVehAssignedOn.Size = new System.Drawing.Size(127, 21);
            this.dtpVehAssignedOn.TabIndex = 220;
            this.dtpVehAssignedOn.TabStop = false;
            this.dtpVehAssignedOn.Value = null;
            // 
            // ddlVehicleColor
            // 
            this.ddlVehicleColor.Caption = null;
            this.ddlVehicleColor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleColor.Location = new System.Drawing.Point(135, 568);
            this.ddlVehicleColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlVehicleColor.Name = "ddlVehicleColor";
            this.ddlVehicleColor.Property = null;
            this.ddlVehicleColor.ShowDownArrow = true;
            this.ddlVehicleColor.Size = new System.Drawing.Size(146, 21);
            this.ddlVehicleColor.TabIndex = 219;
            // 
            // txtVehNo
            // 
            this.txtVehNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehNo.Location = new System.Drawing.Point(426, 546);
            this.txtVehNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehNo.MaxLength = 100;
            this.txtVehNo.Name = "txtVehNo";
            this.txtVehNo.Size = new System.Drawing.Size(143, 21);
            this.txtVehNo.TabIndex = 209;
            this.txtVehNo.TabStop = false;
            // 
            // radLabel14
            // 
            this.radLabel14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel14.Location = new System.Drawing.Point(310, 545);
            this.radLabel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(69, 19);
            this.radLabel14.TabIndex = 218;
            this.radLabel14.Text = "Vehicle No";
            // 
            // ddlVehicleType
            // 
            this.ddlVehicleType.Caption = null;
            this.ddlVehicleType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleType.Location = new System.Drawing.Point(135, 543);
            this.ddlVehicleType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlVehicleType.Name = "ddlVehicleType";
            this.ddlVehicleType.Property = null;
            this.ddlVehicleType.ShowDownArrow = true;
            this.ddlVehicleType.Size = new System.Drawing.Size(146, 21);
            this.ddlVehicleType.TabIndex = 208;
            // 
            // radLabel17
            // 
            this.radLabel17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel17.Location = new System.Drawing.Point(10, 545);
            this.radLabel17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(76, 18);
            this.radLabel17.TabIndex = 217;
            this.radLabel17.Text = "Vehicle Type";
            // 
            // radLabel25
            // 
            this.radLabel25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel25.Location = new System.Drawing.Point(310, 594);
            this.radLabel25.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel25.Name = "radLabel25";
            this.radLabel25.Size = new System.Drawing.Size(81, 18);
            this.radLabel25.TabIndex = 216;
            this.radLabel25.Text = "Vehicle Model";
            // 
            // txtVehModel
            // 
            this.txtVehModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehModel.Location = new System.Drawing.Point(426, 593);
            this.txtVehModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehModel.MaxLength = 100;
            this.txtVehModel.Name = "txtVehModel";
            this.txtVehModel.Size = new System.Drawing.Size(143, 21);
            this.txtVehModel.TabIndex = 212;
            this.txtVehModel.TabStop = false;
            // 
            // radLabel22
            // 
            this.radLabel22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel22.Location = new System.Drawing.Point(310, 571);
            this.radLabel22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel22.Name = "radLabel22";
            this.radLabel22.Size = new System.Drawing.Size(42, 18);
            this.radLabel22.TabIndex = 215;
            this.radLabel22.Text = "Owner";
            // 
            // txtVehOwner
            // 
            this.txtVehOwner.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehOwner.Location = new System.Drawing.Point(426, 570);
            this.txtVehOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehOwner.MaxLength = 100;
            this.txtVehOwner.Name = "txtVehOwner";
            this.txtVehOwner.Size = new System.Drawing.Size(143, 21);
            this.txtVehOwner.TabIndex = 210;
            this.txtVehOwner.TabStop = false;
            // 
            // radLabel23
            // 
            this.radLabel23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel23.Location = new System.Drawing.Point(10, 594);
            this.radLabel23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(78, 18);
            this.radLabel23.TabIndex = 214;
            this.radLabel23.Text = "Vehicle Make";
            // 
            // txtVehMake
            // 
            this.txtVehMake.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehMake.Location = new System.Drawing.Point(135, 593);
            this.txtVehMake.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehMake.MaxLength = 100;
            this.txtVehMake.Name = "txtVehMake";
            this.txtVehMake.Size = new System.Drawing.Size(146, 21);
            this.txtVehMake.TabIndex = 211;
            this.txtVehMake.TabStop = false;
            // 
            // radLabel24
            // 
            this.radLabel24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel24.Location = new System.Drawing.Point(10, 575);
            this.radLabel24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel24.Name = "radLabel24";
            this.radLabel24.Size = new System.Drawing.Size(37, 19);
            this.radLabel24.TabIndex = 213;
            this.radLabel24.Text = "Color";
            // 
            // btnPrintDriver
            // 
            this.btnPrintDriver.Enabled = false;
            this.btnPrintDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDriver.Image = global::Taxi_AppMain.Properties.Resources.Print1;
            this.btnPrintDriver.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrintDriver.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem3,
            this.mnuDriverLog});
            this.btnPrintDriver.Location = new System.Drawing.Point(643, 555);
            this.btnPrintDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrintDriver.Name = "btnPrintDriver";
            this.btnPrintDriver.Size = new System.Drawing.Size(113, 54);
            this.btnPrintDriver.TabIndex = 206;
            this.btnPrintDriver.Text = "Print";
            this.btnPrintDriver.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintDriver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Print1;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).Text = "Print";
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadSplitButtonElement)(this.btnPrintDriver.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintDriver.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintDriver.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Driver Info Report";
            this.radMenuItem1.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "Driver OnBreak Record";
            this.radMenuItem3.Click += new System.EventHandler(this.btnBrekReport_Click);
            // 
            // mnuDriverLog
            // 
            this.mnuDriverLog.Name = "mnuDriverLog";
            this.mnuDriverLog.Text = "Audit Log";
            this.mnuDriverLog.Click += new System.EventHandler(this.mnuDriverLog_Click);
            // 
            // numDriverRentComm
            // 
            this.numDriverRentComm.DecimalPlaces = 2;
            this.numDriverRentComm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDriverRentComm.InterceptArrowKeys = false;
            this.numDriverRentComm.Location = new System.Drawing.Point(472, 230);
            this.numDriverRentComm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numDriverRentComm.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDriverRentComm.Name = "numDriverRentComm";
            // 
            // 
            // 
            this.numDriverRentComm.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numDriverRentComm.RootElement.StretchVertically = true;
            this.numDriverRentComm.ShowUpDownButtons = false;
            this.numDriverRentComm.Size = new System.Drawing.Size(73, 26);
            this.numDriverRentComm.TabIndex = 107;
            this.numDriverRentComm.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numDriverRentComm.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // lblDriverType
            // 
            this.lblDriverType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverType.Location = new System.Drawing.Point(357, 235);
            this.lblDriverType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDriverType.Name = "lblDriverType";
            this.lblDriverType.Size = new System.Drawing.Size(85, 18);
            this.lblDriverType.TabIndex = 106;
            this.lblDriverType.Text = "Weekly Rent";
            // 
            // ddlDriverType
            // 
            this.ddlDriverType.Caption = null;
            this.ddlDriverType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriverType.Location = new System.Drawing.Point(471, 197);
            this.ddlDriverType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDriverType.Name = "ddlDriverType";
            this.ddlDriverType.Property = null;
            this.ddlDriverType.ShowDownArrow = true;
            this.ddlDriverType.Size = new System.Drawing.Size(147, 21);
            this.ddlDriverType.TabIndex = 105;
            this.ddlDriverType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlDriverType_SelectedIndexChanged);
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel16.Location = new System.Drawing.Point(366, 198);
            this.radLabel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(78, 18);
            this.radLabel16.TabIndex = 104;
            this.radLabel16.Text = "Driver Type";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.numVAT);
            this.radGroupBox1.Controls.Add(this.radLabel50);
            this.radGroupBox1.Controls.Add(this.chkBidding);
            this.radGroupBox1.Controls.Add(this.chkActiveDriver);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.txtWebLoginPwd);
            this.radGroupBox1.Controls.Add(this.chkHasPDA);
            this.radGroupBox1.Controls.Add(this.chkHasRentPaid);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel18);
            this.radGroupBox1.Controls.Add(this.txtPassword);
            this.radGroupBox1.Controls.Add(this.txtDriverNo);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Login Details";
            this.radGroupBox1.Location = new System.Drawing.Point(9, 5);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            this.radGroupBox1.Size = new System.Drawing.Size(773, 92);
            this.radGroupBox1.TabIndex = 101;
            this.radGroupBox1.Text = "Login Details";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor3 = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor4 = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "Login Details";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).ForeColor = System.Drawing.Color.White;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVAT
            // 
            this.numVAT.DecimalPlaces = 2;
            this.numVAT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVAT.InterceptArrowKeys = false;
            this.numVAT.Location = new System.Drawing.Point(685, 27);
            this.numVAT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numVAT.Name = "numVAT";
            // 
            // 
            // 
            this.numVAT.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numVAT.RootElement.StretchVertically = true;
            this.numVAT.ShowUpDownButtons = false;
            this.numVAT.Size = new System.Drawing.Size(68, 26);
            this.numVAT.TabIndex = 230;
            this.numVAT.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numVAT.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            // 
            // radLabel50
            // 
            this.radLabel50.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel50.Location = new System.Drawing.Point(633, 30);
            this.radLabel50.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel50.Name = "radLabel50";
            this.radLabel50.Size = new System.Drawing.Size(40, 18);
            this.radLabel50.TabIndex = 229;
            this.radLabel50.Text = "Vat %";
            // 
            // chkBidding
            // 
            this.chkBidding.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBidding.Location = new System.Drawing.Point(476, 26);
            this.chkBidding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkBidding.Name = "chkBidding";
            // 
            // 
            // 
            this.chkBidding.RootElement.StretchHorizontally = true;
            this.chkBidding.RootElement.StretchVertically = true;
            this.chkBidding.Size = new System.Drawing.Size(94, 22);
            this.chkBidding.TabIndex = 209;
            this.chkBidding.Text = "Bidding";
            this.chkBidding.Visible = false;
            // 
            // chkActiveDriver
            // 
            this.chkActiveDriver.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.chkActiveDriver.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chkActiveDriver.Location = new System.Drawing.Point(664, 62);
            this.chkActiveDriver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkActiveDriver.Name = "chkActiveDriver";
            // 
            // 
            // 
            this.chkActiveDriver.RootElement.StretchHorizontally = true;
            this.chkActiveDriver.RootElement.StretchVertically = true;
            this.chkActiveDriver.Size = new System.Drawing.Size(100, 22);
            this.chkActiveDriver.TabIndex = 208;
            this.chkActiveDriver.Text = "Active";
            this.chkActiveDriver.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.chkActiveDriver_ToggleStateChanging);
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(294, 62);
            this.radLabel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(66, 18);
            this.radLabel5.TabIndex = 104;
            this.radLabel5.Text = "PIN Code :";
            // 
            // txtWebLoginPwd
            // 
            this.txtWebLoginPwd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebLoginPwd.Location = new System.Drawing.Point(376, 60);
            this.txtWebLoginPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWebLoginPwd.MaxLength = 6;
            this.txtWebLoginPwd.Name = "txtWebLoginPwd";
            this.txtWebLoginPwd.Size = new System.Drawing.Size(118, 21);
            this.txtWebLoginPwd.TabIndex = 103;
            this.txtWebLoginPwd.TabStop = false;
            // 
            // chkHasPDA
            // 
            this.chkHasPDA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHasPDA.Location = new System.Drawing.Point(283, 26);
            this.chkHasPDA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHasPDA.Name = "chkHasPDA";
            // 
            // 
            // 
            this.chkHasPDA.RootElement.StretchHorizontally = true;
            this.chkHasPDA.RootElement.StretchVertically = true;
            this.chkHasPDA.Size = new System.Drawing.Size(85, 22);
            this.chkHasPDA.TabIndex = 102;
            this.chkHasPDA.Text = "Has PDA";
            // 
            // chkHasRentPaid
            // 
            this.chkHasRentPaid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHasRentPaid.Location = new System.Drawing.Point(376, 26);
            this.chkHasRentPaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHasRentPaid.Name = "chkHasRentPaid";
            // 
            // 
            // 
            this.chkHasRentPaid.RootElement.StretchHorizontally = true;
            this.chkHasRentPaid.RootElement.StretchVertically = true;
            this.chkHasRentPaid.Size = new System.Drawing.Size(94, 22);
            this.chkHasRentPaid.TabIndex = 101;
            this.chkHasRentPaid.Text = "Rent Paid";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(3, 30);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(66, 18);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "Driver No";
            // 
            // radLabel18
            // 
            this.radLabel18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.Location = new System.Drawing.Point(3, 62);
            this.radLabel18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(96, 18);
            this.radLabel18.TabIndex = 100;
            this.radLabel18.Text = "PDA Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(132, 60);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(145, 21);
            this.txtPassword.TabIndex = 99;
            this.txtPassword.TabStop = false;
            // 
            // txtDriverNo
            // 
            this.txtDriverNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverNo.Location = new System.Drawing.Point(132, 26);
            this.txtDriverNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDriverNo.MaxLength = 30;
            this.txtDriverNo.Name = "txtDriverNo";
            this.txtDriverNo.Size = new System.Drawing.Size(145, 21);
            this.txtDriverNo.TabIndex = 1;
            this.txtDriverNo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEndDrier);
            this.panel1.Controls.Add(this.btnClearAvail);
            this.panel1.Controls.Add(this.radLabel15);
            this.panel1.Controls.Add(this.dtpEndingDate);
            this.panel1.Controls.Add(this.btnAddAvailability);
            this.panel1.Controls.Add(this.radLabel13);
            this.panel1.Controls.Add(this.dtpAvailDate);
            this.panel1.Controls.Add(this.grdAvailability);
            this.panel1.Controls.Add(this.radLabel11);
            this.panel1.Location = new System.Drawing.Point(576, 342);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 205);
            this.panel1.TabIndex = 96;
            // 
            // chkEndDrier
            // 
            this.chkEndDrier.BackColor = System.Drawing.Color.Transparent;
            this.chkEndDrier.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEndDrier.ForeColor = System.Drawing.Color.Black;
            this.chkEndDrier.Location = new System.Drawing.Point(252, 33);
            this.chkEndDrier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEndDrier.Name = "chkEndDrier";
            // 
            // 
            // 
            this.chkEndDrier.RootElement.StretchHorizontally = true;
            this.chkEndDrier.RootElement.StretchVertically = true;
            this.chkEndDrier.Size = new System.Drawing.Size(97, 23);
            this.chkEndDrier.TabIndex = 102;
            this.chkEndDrier.Text = "End Driver";
            this.chkEndDrier.TextWrap = true;
            this.chkEndDrier.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkEndDrier_ToggleStateChanged);
            // 
            // btnClearAvail
            // 
            this.btnClearAvail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearAvail.Location = new System.Drawing.Point(365, 59);
            this.btnClearAvail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearAvail.Name = "btnClearAvail";
            this.btnClearAvail.Size = new System.Drawing.Size(62, 28);
            this.btnClearAvail.TabIndex = 99;
            this.btnClearAvail.Text = "New";
            this.btnClearAvail.UseVisualStyleBackColor = true;
            this.btnClearAvail.Click += new System.EventHandler(this.btnClearAvail_Click);
            // 
            // radLabel15
            // 
            this.radLabel15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel15.Location = new System.Drawing.Point(15, 64);
            this.radLabel15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(73, 18);
            this.radLabel15.TabIndex = 101;
            this.radLabel15.Text = "Ending Date";
            // 
            // dtpEndingDate
            // 
            this.dtpEndingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndingDate.Location = new System.Drawing.Point(140, 63);
            this.dtpEndingDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndingDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndingDate.Name = "dtpEndingDate";
            this.dtpEndingDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndingDate.Size = new System.Drawing.Size(105, 20);
            this.dtpEndingDate.TabIndex = 97;
            this.dtpEndingDate.TabStop = false;
            this.dtpEndingDate.Value = null;
            // 
            // btnAddAvailability
            // 
            this.btnAddAvailability.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAddAvailability.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAvailability.Location = new System.Drawing.Point(261, 59);
            this.btnAddAvailability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddAvailability.Name = "btnAddAvailability";
            this.btnAddAvailability.Size = new System.Drawing.Size(84, 28);
            this.btnAddAvailability.TabIndex = 98;
            this.btnAddAvailability.Text = "Add";
            this.btnAddAvailability.UseVisualStyleBackColor = true;
            this.btnAddAvailability.Click += new System.EventHandler(this.btnAddAvailability_Click);
            // 
            // radLabel13
            // 
            this.radLabel13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel13.Location = new System.Drawing.Point(15, 33);
            this.radLabel13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(102, 18);
            this.radLabel13.TabIndex = 100;
            this.radLabel13.Text = "Became Available";
            // 
            // dtpAvailDate
            // 
            this.dtpAvailDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAvailDate.Location = new System.Drawing.Point(140, 32);
            this.dtpAvailDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpAvailDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAvailDate.Name = "dtpAvailDate";
            this.dtpAvailDate.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAvailDate.Size = new System.Drawing.Size(105, 20);
            this.dtpAvailDate.TabIndex = 96;
            this.dtpAvailDate.TabStop = false;
            this.dtpAvailDate.Value = null;
            // 
            // grdAvailability
            // 
            this.grdAvailability.AutoCellFormatting = false;
            this.grdAvailability.EnableCheckInCheckOut = false;
            this.grdAvailability.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAvailability.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdAvailability.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdAvailability.Location = new System.Drawing.Point(0, 95);
            this.grdAvailability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdAvailability.MasterTemplate.AllowAddNewRow = false;
            this.grdAvailability.MasterTemplate.AllowEditRow = false;
            this.grdAvailability.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdAvailability.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdAvailability.Name = "grdAvailability";
            this.grdAvailability.PKFieldColumnName = "";
            this.grdAvailability.ShowGroupPanel = false;
            this.grdAvailability.ShowImageOnActionButton = true;
            this.grdAvailability.Size = new System.Drawing.Size(441, 108);
            this.grdAvailability.TabIndex = 94;
            this.grdAvailability.Text = "myGridView1";
            // 
            // radLabel11
            // 
            this.radLabel11.AutoSize = false;
            this.radLabel11.BackColor = System.Drawing.Color.Purple;
            this.radLabel11.BorderVisible = true;
            this.radLabel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.ForeColor = System.Drawing.Color.White;
            this.radLabel11.Location = new System.Drawing.Point(0, 0);
            this.radLabel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(441, 22);
            this.radLabel11.TabIndex = 95;
            this.radLabel11.Text = "Availability";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel11.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel11.GetChildAt(0))).Text = "Availability";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel11.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel11.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel11.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel11.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = false;
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.DefaultHeight = 120;
            this.txtAddress.DefaultWidth = 0;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForceListBoxToUpdate = false;
            this.txtAddress.FormerValue = "";
            this.txtAddress.Location = new System.Drawing.Point(128, 197);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.SelectedItem = null;
            this.txtAddress.Size = new System.Drawing.Size(222, 52);
            this.txtAddress.TabIndex = 93;
            this.txtAddress.TabStop = false;
            this.txtAddress.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtAddress.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAddress.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(12, 197);
            this.radLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(53, 19);
            this.radLabel4.TabIndex = 91;
            this.radLabel4.Text = "Address";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(427, 169);
            this.radLabel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(19, 18);
            this.radLabel8.TabIndex = 89;
            this.radLabel8.Text = "NI";
            // 
            // txtNI
            // 
            this.txtNI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNI.Location = new System.Drawing.Point(471, 166);
            this.txtNI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNI.MaxLength = 30;
            this.txtNI.Name = "txtNI";
            this.txtNI.Size = new System.Drawing.Size(148, 21);
            this.txtNI.TabIndex = 88;
            this.txtNI.TabStop = false;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.radLabel3.BorderVisible = true;
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.White;
            this.radLabel3.Location = new System.Drawing.Point(9, 265);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(560, 22);
            this.radLabel3.TabIndex = 87;
            this.radLabel3.Text = "Expiry Details";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel3.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel3.GetChildAt(0))).Text = "Expiry Details";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // grdDocuments
            // 
            this.grdDocuments.AutoCellFormatting = false;
            this.grdDocuments.EnableCheckInCheckOut = false;
            this.grdDocuments.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDocuments.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdDocuments.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdDocuments.Location = new System.Drawing.Point(10, 287);
            this.grdDocuments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDocuments.MasterTemplate.AllowAddNewRow = false;
            this.grdDocuments.MasterTemplate.AllowEditRow = false;
            this.grdDocuments.MasterTemplate.ShowRowHeaderColumn = false;
            this.grdDocuments.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.PKFieldColumnName = "";
            this.grdDocuments.ShowGroupPanel = false;
            this.grdDocuments.ShowImageOnActionButton = true;
            this.grdDocuments.Size = new System.Drawing.Size(559, 197);
            this.grdDocuments.TabIndex = 10;
            this.grdDocuments.Text = "myGridView1";
            // 
            // radLabel21
            // 
            this.radLabel21.AutoSize = false;
            this.radLabel21.BackColor = System.Drawing.Color.DarkSlateGray;
            this.radLabel21.BorderVisible = true;
            this.radLabel21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel21.ForeColor = System.Drawing.Color.White;
            this.radLabel21.Location = new System.Drawing.Point(9, 486);
            this.radLabel21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(560, 22);
            this.radLabel21.TabIndex = 83;
            this.radLabel21.Text = "Assigned Vehicle";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel21.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel21.GetChildAt(0))).Text = "Assigned Vehicle";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel21.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel21.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel21.GetChildAt(0).GetChildAt(1))).BottomWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radLabel21.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(624, 106);
            this.radLabel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(31, 18);
            this.radLabel7.TabIndex = 61;
            this.radLabel7.Text = "DOB";
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(668, 105);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDOB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Size = new System.Drawing.Size(115, 20);
            this.dtpDOB.TabIndex = 4;
            this.dtpDOB.TabStop = false;
            this.dtpDOB.Value = null;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(12, 106);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 18);
            this.radLabel1.TabIndex = 58;
            this.radLabel1.Text = "Driver Name";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverName.Location = new System.Drawing.Point(128, 105);
            this.txtDriverName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDriverName.MaxLength = 100;
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(222, 21);
            this.txtDriverName.TabIndex = 2;
            this.txtDriverName.TabStop = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(12, 137);
            this.radLabel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(36, 18);
            this.radLabel6.TabIndex = 46;
            this.radLabel6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(128, 135);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 21);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TabStop = false;
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(370, 134);
            this.radLabel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(69, 18);
            this.radLabel9.TabIndex = 44;
            this.radLabel9.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(471, 135);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobileNo.MaxLength = 30;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(147, 21);
            this.txtMobileNo.TabIndex = 6;
            this.txtMobileNo.TabStop = false;
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(12, 167);
            this.radLabel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(82, 18);
            this.radLabel10.TabIndex = 42;
            this.radLabel10.Text = "Telephone No";
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephoneNo.Location = new System.Drawing.Point(128, 166);
            this.txtTelephoneNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelephoneNo.MaxLength = 30;
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(222, 21);
            this.txtTelephoneNo.TabIndex = 5;
            this.txtTelephoneNo.TabStop = false;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.Image = global::Taxi_AppMain.Properties.Resources.save_Tick;
            this.btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveChanges.Location = new System.Drawing.Point(824, 554);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(111, 56);
            this.btnSaveChanges.TabIndex = 207;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // pg_Shifts
            // 
            this.pg_Shifts.Controls.Add(this.grdDriverShifts);
            this.pg_Shifts.ItemSize = new System.Drawing.SizeF(49F, 27F);
            this.pg_Shifts.Location = new System.Drawing.Point(12, 44);
            this.pg_Shifts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_Shifts.Name = "pg_Shifts";
            this.pg_Shifts.Size = new System.Drawing.Size(1025, 770);
            this.pg_Shifts.Text = "Shifts";
            // 
            // grdDriverShifts
            // 
            this.grdDriverShifts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDriverShifts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDriverShifts.Location = new System.Drawing.Point(49, 52);
            this.grdDriverShifts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverShifts.MasterTemplate.AllowAddNewRow = false;
            this.grdDriverShifts.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdDriverShifts.Name = "grdDriverShifts";
            this.grdDriverShifts.ShowGroupPanel = false;
            this.grdDriverShifts.Size = new System.Drawing.Size(426, 542);
            this.grdDriverShifts.TabIndex = 4;
            this.grdDriverShifts.Text = "Attributes";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(87F, 27F);
            this.radPageViewPage2.Location = new System.Drawing.Point(12, 44);
            this.radPageViewPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1025, 770);
            this.radPageViewPage2.Text = "Driver Shifts";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(108F, 27F);
            this.radPageViewPage3.Location = new System.Drawing.Point(12, 44);
            this.radPageViewPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(1025, 770);
            this.radPageViewPage3.Text = "Vehicles History";
            // 
            // radPageViewPage4
            // 
            this.radPageViewPage4.Controls.Add(this.radGroupBox2);
            this.radPageViewPage4.ItemSize = new System.Drawing.SizeF(112F, 27F);
            this.radPageViewPage4.Location = new System.Drawing.Point(10, 36);
            this.radPageViewPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPageViewPage4.Name = "radPageViewPage4";
            this.radPageViewPage4.Size = new System.Drawing.Size(1029, 790);
            this.radPageViewPage4.Text = "PDA/SIM Details";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox2.Controls.Add(this.txtAffiliateKey);
            this.radGroupBox2.Controls.Add(this.radLabel52);
            this.radGroupBox2.Controls.Add(this.txt_SIM_Comments);
            this.radGroupBox2.Controls.Add(this.radLabel34);
            this.radGroupBox2.Controls.Add(this.txt_SIM_PDADeposits);
            this.radGroupBox2.Controls.Add(this.radLabel33);
            this.radGroupBox2.Controls.Add(this.txt_SIM_DataAllowance);
            this.radGroupBox2.Controls.Add(this.radLabel31);
            this.radGroupBox2.Controls.Add(this.txt_SIM_NetworkAPN);
            this.radGroupBox2.Controls.Add(this.radLabel32);
            this.radGroupBox2.Controls.Add(this.radLabel38);
            this.radGroupBox2.Controls.Add(this.txt_SIM_Model);
            this.radGroupBox2.Controls.Add(this.radLabel41);
            this.radGroupBox2.Controls.Add(this.radLabel36);
            this.radGroupBox2.Controls.Add(this.txt_SIM_Number);
            this.radGroupBox2.Controls.Add(this.txt_SIM_Make);
            this.radGroupBox2.Controls.Add(this.radLabel37);
            this.radGroupBox2.Controls.Add(this.dtp_SIM_PDADateGiven);
            this.radGroupBox2.Controls.Add(this.radLabel40);
            this.radGroupBox2.Controls.Add(this.radLabel39);
            this.radGroupBox2.Controls.Add(this.txt_SIM_NetworkName);
            this.radGroupBox2.Controls.Add(this.txt_SIM_IMEI);
            this.radGroupBox2.HeaderText = "PDA/SIM Details";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 26);
            this.radGroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            this.radGroupBox2.Size = new System.Drawing.Size(614, 481);
            this.radGroupBox2.TabIndex = 123;
            this.radGroupBox2.Text = "PDA/SIM Details";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox2.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(12, 25, 12, 12);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox2.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox2.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "PDA/SIM Details";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).BackColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radGroupBox2.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAffiliateKey
            // 
            this.txtAffiliateKey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAffiliateKey.Location = new System.Drawing.Point(177, 435);
            this.txtAffiliateKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAffiliateKey.MaxLength = 200;
            this.txtAffiliateKey.Name = "txtAffiliateKey";
            this.txtAffiliateKey.Size = new System.Drawing.Size(421, 21);
            this.txtAffiliateKey.TabIndex = 126;
            this.txtAffiliateKey.TabStop = false;
            // 
            // radLabel52
            // 
            this.radLabel52.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel52.Location = new System.Drawing.Point(29, 436);
            this.radLabel52.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel52.Name = "radLabel52";
            this.radLabel52.Size = new System.Drawing.Size(118, 18);
            this.radLabel52.TabIndex = 127;
            this.radLabel52.Text = "SUM UP Affiliate Key";
            // 
            // txt_SIM_Comments
            // 
            this.txt_SIM_Comments.AutoSize = false;
            this.txt_SIM_Comments.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_Comments.Location = new System.Drawing.Point(175, 331);
            this.txt_SIM_Comments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_Comments.MaxLength = 1000;
            this.txt_SIM_Comments.Multiline = true;
            this.txt_SIM_Comments.Name = "txt_SIM_Comments";
            this.txt_SIM_Comments.Size = new System.Drawing.Size(423, 76);
            this.txt_SIM_Comments.TabIndex = 124;
            this.txt_SIM_Comments.TabStop = false;
            // 
            // radLabel34
            // 
            this.radLabel34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel34.Location = new System.Drawing.Point(82, 332);
            this.radLabel34.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel34.Name = "radLabel34";
            this.radLabel34.Size = new System.Drawing.Size(64, 18);
            this.radLabel34.TabIndex = 125;
            this.radLabel34.Text = "Comments";
            // 
            // txt_SIM_PDADeposits
            // 
            this.txt_SIM_PDADeposits.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_PDADeposits.Location = new System.Drawing.Point(175, 286);
            this.txt_SIM_PDADeposits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_PDADeposits.MaxLength = 30;
            this.txt_SIM_PDADeposits.Name = "txt_SIM_PDADeposits";
            this.txt_SIM_PDADeposits.Size = new System.Drawing.Size(222, 21);
            this.txt_SIM_PDADeposits.TabIndex = 122;
            this.txt_SIM_PDADeposits.TabStop = false;
            // 
            // radLabel33
            // 
            this.radLabel33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel33.Location = new System.Drawing.Point(65, 287);
            this.radLabel33.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel33.Name = "radLabel33";
            this.radLabel33.Size = new System.Drawing.Size(79, 18);
            this.radLabel33.TabIndex = 123;
            this.radLabel33.Text = "PDA Deposits";
            // 
            // txt_SIM_DataAllowance
            // 
            this.txt_SIM_DataAllowance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_DataAllowance.Location = new System.Drawing.Point(175, 254);
            this.txt_SIM_DataAllowance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_DataAllowance.MaxLength = 30;
            this.txt_SIM_DataAllowance.Name = "txt_SIM_DataAllowance";
            this.txt_SIM_DataAllowance.Size = new System.Drawing.Size(222, 21);
            this.txt_SIM_DataAllowance.TabIndex = 119;
            this.txt_SIM_DataAllowance.TabStop = false;
            // 
            // radLabel31
            // 
            this.radLabel31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel31.Location = new System.Drawing.Point(51, 255);
            this.radLabel31.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel31.Name = "radLabel31";
            this.radLabel31.Size = new System.Drawing.Size(90, 18);
            this.radLabel31.TabIndex = 120;
            this.radLabel31.Text = "Data Allowance";
            // 
            // txt_SIM_NetworkAPN
            // 
            this.txt_SIM_NetworkAPN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_NetworkAPN.Location = new System.Drawing.Point(175, 222);
            this.txt_SIM_NetworkAPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_NetworkAPN.MaxLength = 50;
            this.txt_SIM_NetworkAPN.Name = "txt_SIM_NetworkAPN";
            this.txt_SIM_NetworkAPN.Size = new System.Drawing.Size(223, 21);
            this.txt_SIM_NetworkAPN.TabIndex = 118;
            this.txt_SIM_NetworkAPN.TabStop = false;
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel32.Location = new System.Drawing.Point(65, 223);
            this.radLabel32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(78, 18);
            this.radLabel32.TabIndex = 121;
            this.radLabel32.Text = "Network APN";
            // 
            // radLabel38
            // 
            this.radLabel38.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel38.Location = new System.Drawing.Point(113, 33);
            this.radLabel38.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel38.Name = "radLabel38";
            this.radLabel38.Size = new System.Drawing.Size(37, 18);
            this.radLabel38.TabIndex = 114;
            this.radLabel38.Text = "IMEI";
            // 
            // txt_SIM_Model
            // 
            this.txt_SIM_Model.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_Model.Location = new System.Drawing.Point(175, 95);
            this.txt_SIM_Model.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_Model.MaxLength = 30;
            this.txt_SIM_Model.Name = "txt_SIM_Model";
            this.txt_SIM_Model.Size = new System.Drawing.Size(222, 21);
            this.txt_SIM_Model.TabIndex = 109;
            this.txt_SIM_Model.TabStop = false;
            // 
            // radLabel41
            // 
            this.radLabel41.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel41.Location = new System.Drawing.Point(111, 96);
            this.radLabel41.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel41.Name = "radLabel41";
            this.radLabel41.Size = new System.Drawing.Size(39, 18);
            this.radLabel41.TabIndex = 111;
            this.radLabel41.Text = "Model";
            // 
            // radLabel36
            // 
            this.radLabel36.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel36.Location = new System.Drawing.Point(72, 192);
            this.radLabel36.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel36.Name = "radLabel36";
            this.radLabel36.Size = new System.Drawing.Size(75, 18);
            this.radLabel36.TabIndex = 117;
            this.radLabel36.Text = "SIM Number";
            // 
            // txt_SIM_Number
            // 
            this.txt_SIM_Number.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_Number.Location = new System.Drawing.Point(175, 190);
            this.txt_SIM_Number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_Number.MaxLength = 30;
            this.txt_SIM_Number.Name = "txt_SIM_Number";
            this.txt_SIM_Number.Size = new System.Drawing.Size(148, 21);
            this.txt_SIM_Number.TabIndex = 116;
            this.txt_SIM_Number.TabStop = false;
            // 
            // txt_SIM_Make
            // 
            this.txt_SIM_Make.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_Make.Location = new System.Drawing.Point(175, 64);
            this.txt_SIM_Make.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_Make.MaxLength = 50;
            this.txt_SIM_Make.Name = "txt_SIM_Make";
            this.txt_SIM_Make.Size = new System.Drawing.Size(223, 21);
            this.txt_SIM_Make.TabIndex = 107;
            this.txt_SIM_Make.TabStop = false;
            // 
            // radLabel37
            // 
            this.radLabel37.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel37.Location = new System.Drawing.Point(48, 127);
            this.radLabel37.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel37.Name = "radLabel37";
            this.radLabel37.Size = new System.Drawing.Size(93, 18);
            this.radLabel37.TabIndex = 115;
            this.radLabel37.Text = "PDA Date Given";
            // 
            // dtp_SIM_PDADateGiven
            // 
            this.dtp_SIM_PDADateGiven.CustomFormat = "dd/MM/yyyy";
            this.dtp_SIM_PDADateGiven.Location = new System.Drawing.Point(175, 127);
            this.dtp_SIM_PDADateGiven.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_SIM_PDADateGiven.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_SIM_PDADateGiven.Name = "dtp_SIM_PDADateGiven";
            this.dtp_SIM_PDADateGiven.NullDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_SIM_PDADateGiven.Size = new System.Drawing.Size(147, 20);
            this.dtp_SIM_PDADateGiven.TabIndex = 108;
            this.dtp_SIM_PDADateGiven.TabStop = false;
            this.dtp_SIM_PDADateGiven.Value = null;
            // 
            // radLabel40
            // 
            this.radLabel40.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel40.Location = new System.Drawing.Point(27, 156);
            this.radLabel40.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel40.Name = "radLabel40";
            this.radLabel40.Size = new System.Drawing.Size(112, 18);
            this.radLabel40.TabIndex = 112;
            this.radLabel40.Text = "SIM Network Name";
            // 
            // radLabel39
            // 
            this.radLabel39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel39.Location = new System.Drawing.Point(115, 65);
            this.radLabel39.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel39.Name = "radLabel39";
            this.radLabel39.Size = new System.Drawing.Size(35, 18);
            this.radLabel39.TabIndex = 113;
            this.radLabel39.Text = "Make";
            // 
            // txt_SIM_NetworkName
            // 
            this.txt_SIM_NetworkName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_NetworkName.Location = new System.Drawing.Point(175, 158);
            this.txt_SIM_NetworkName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_NetworkName.MaxLength = 30;
            this.txt_SIM_NetworkName.Name = "txt_SIM_NetworkName";
            this.txt_SIM_NetworkName.Size = new System.Drawing.Size(147, 21);
            this.txt_SIM_NetworkName.TabIndex = 110;
            this.txt_SIM_NetworkName.TabStop = false;
            // 
            // txt_SIM_IMEI
            // 
            this.txt_SIM_IMEI.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SIM_IMEI.Location = new System.Drawing.Point(175, 32);
            this.txt_SIM_IMEI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SIM_IMEI.MaxLength = 100;
            this.txt_SIM_IMEI.Name = "txt_SIM_IMEI";
            this.txt_SIM_IMEI.Size = new System.Drawing.Size(314, 21);
            this.txt_SIM_IMEI.TabIndex = 106;
            this.txt_SIM_IMEI.TabStop = false;
            // 
            // pg_pdasettings
            // 
            this.pg_pdasettings.Controls.Add(this.pnlSettings);
            this.pg_pdasettings.ItemSize = new System.Drawing.SizeF(90F, 27F);
            this.pg_pdasettings.Location = new System.Drawing.Point(10, 36);
            this.pg_pdasettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_pdasettings.Name = "pg_pdasettings";
            this.pg_pdasettings.Size = new System.Drawing.Size(1029, 790);
            this.pg_pdasettings.Text = "PDA Settings";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.ddlHidePickupAndDestinationType);
            this.pnlSettings.Controls.Add(this.chkShowDestAfterPOB);
            this.pnlSettings.Controls.Add(this.chkVoiceOnClearMeter);
            this.pnlSettings.Controls.Add(this.chkDisableJobAuth);
            this.pnlSettings.Controls.Add(this.chkEnablePriceBidding);
            this.pnlSettings.Controls.Add(this.chkEnableDriverConnect);
            this.pnlSettings.Controls.Add(this.chkDisableSTC);
            this.pnlSettings.Controls.Add(this.chkEnableManualFares);
            this.pnlSettings.Controls.Add(this.chkDisableFareOnAccJob);
            this.pnlSettings.Controls.Add(this.chkDisableAlarm);
            this.pnlSettings.Controls.Add(this.chkEnableOptionalManualFares);
            this.pnlSettings.Controls.Add(this.chkDisableNoPickup);
            this.pnlSettings.Controls.Add(this.txtPDAVer);
            this.pnlSettings.Controls.Add(this.btnUpdateSettings);
            this.pnlSettings.Controls.Add(this.chkDisableOnBreak);
            this.pnlSettings.Controls.Add(this.chkShiftOverLogout);
            this.pnlSettings.Controls.Add(this.chkShowSpecReq);
            this.pnlSettings.Controls.Add(this.chkShowJobAsAlert);
            this.pnlSettings.Controls.Add(this.chkDisableBase);
            this.pnlSettings.Controls.Add(this.chkShowFareonExtraCharges);
            this.pnlSettings.Controls.Add(this.chkEnableLogoutOnReject);
            this.pnlSettings.Controls.Add(this.chkHidePickupAndDest);
            this.pnlSettings.Controls.Add(this.label7);
            this.pnlSettings.Controls.Add(this.numJobTimeout);
            this.pnlSettings.Controls.Add(this.label8);
            this.pnlSettings.Controls.Add(this.txtBiddingMessage);
            this.pnlSettings.Controls.Add(this.txtFareMessage);
            this.pnlSettings.Controls.Add(this.label6);
            this.pnlSettings.Controls.Add(this.numBreakDuration);
            this.pnlSettings.Controls.Add(this.label5);
            this.pnlSettings.Controls.Add(this.chkDisableMeterAccJob);
            this.pnlSettings.Controls.Add(this.chkEnableMeterWaitingCharges);
            this.pnlSettings.Controls.Add(this.chkEnableOptionalMeter);
            this.pnlSettings.Controls.Add(this.chkShowSoundOnZoneChange);
            this.pnlSettings.Controls.Add(this.chkDisableChangeJobPlot);
            this.pnlSettings.Controls.Add(this.chkDisableRank);
            this.pnlSettings.Controls.Add(this.chkDisablePanic);
            this.pnlSettings.Controls.Add(this.chkIgnoreArriveAction);
            this.pnlSettings.Controls.Add(this.chkMessageStay);
            this.pnlSettings.Controls.Add(this.ShowPlotOnJobOffer);
            this.pnlSettings.Controls.Add(this.chkShowAlertOnJobLater);
            this.pnlSettings.Controls.Add(this.chkShowCustomerMobileNo);
            this.pnlSettings.Controls.Add(this.chkShowNavigation);
            this.pnlSettings.Controls.Add(this.chkShowCompletedJobs);
            this.pnlSettings.Controls.Add(this.chkShowPlots);
            this.pnlSettings.Controls.Add(this.chkEnableAutoRotate);
            this.pnlSettings.Controls.Add(this.chkEnableCompanyCars);
            this.pnlSettings.Controls.Add(this.chkEnableJ15Jobs);
            this.pnlSettings.Controls.Add(this.chkEnableCallCustomer);
            this.pnlSettings.Controls.Add(this.chkEnableJobExtraCharges);
            this.pnlSettings.Controls.Add(this.chkEnableRecoverJob);
            this.pnlSettings.Controls.Add(this.chkEnableLogoutAuthorization);
            this.pnlSettings.Controls.Add(this.chkEnableFlagDown);
            this.pnlSettings.Controls.Add(this.chkEnableFareMeter);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.chkEnableBidding);
            this.pnlSettings.Controls.Add(this.ddlNavigation);
            this.pnlSettings.Controls.Add(this.chkDisableChangeDest);
            this.pnlSettings.Controls.Add(this.chkDisableRejectJob);
            this.pnlSettings.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSettings.Location = new System.Drawing.Point(13, 21);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(989, 671);
            this.pnlSettings.TabIndex = 12;
            this.pnlSettings.TabStop = false;
            this.pnlSettings.Text = "Settings";
            // 
            // ddlHidePickupAndDestinationType
            // 
            this.ddlHidePickupAndDestinationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHidePickupAndDestinationType.FormattingEnabled = true;
            this.ddlHidePickupAndDestinationType.Items.AddRange(new object[] {
            "Hide All",
            "Show Pickup Only",
            "Show Pickup/Vehicle",
            "Show Pickup/Destination"});
            this.ddlHidePickupAndDestinationType.Location = new System.Drawing.Point(676, 295);
            this.ddlHidePickupAndDestinationType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlHidePickupAndDestinationType.Name = "ddlHidePickupAndDestinationType";
            this.ddlHidePickupAndDestinationType.Size = new System.Drawing.Size(186, 22);
            this.ddlHidePickupAndDestinationType.TabIndex = 61;
            this.ddlHidePickupAndDestinationType.Visible = false;
            // 
            // chkShowDestAfterPOB
            // 
            this.chkShowDestAfterPOB.AutoSize = true;
            this.chkShowDestAfterPOB.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowDestAfterPOB.Location = new System.Drawing.Point(240, 633);
            this.chkShowDestAfterPOB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowDestAfterPOB.Name = "chkShowDestAfterPOB";
            this.chkShowDestAfterPOB.Size = new System.Drawing.Size(205, 22);
            this.chkShowDestAfterPOB.TabIndex = 66;
            this.chkShowDestAfterPOB.Text = "Show Job Details After POB";
            this.chkShowDestAfterPOB.UseVisualStyleBackColor = true;
            // 
            // chkVoiceOnClearMeter
            // 
            this.chkVoiceOnClearMeter.AutoSize = true;
            this.chkVoiceOnClearMeter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkVoiceOnClearMeter.ForeColor = System.Drawing.Color.Blue;
            this.chkVoiceOnClearMeter.Location = new System.Drawing.Point(693, 107);
            this.chkVoiceOnClearMeter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkVoiceOnClearMeter.Name = "chkVoiceOnClearMeter";
            this.chkVoiceOnClearMeter.Size = new System.Drawing.Size(151, 21);
            this.chkVoiceOnClearMeter.TabIndex = 59;
            this.chkVoiceOnClearMeter.Text = "Voice on Clear Meter";
            this.chkVoiceOnClearMeter.UseVisualStyleBackColor = true;
            // 
            // chkDisableJobAuth
            // 
            this.chkDisableJobAuth.AutoSize = true;
            this.chkDisableJobAuth.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableJobAuth.Location = new System.Drawing.Point(478, 587);
            this.chkDisableJobAuth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisableJobAuth.Name = "chkDisableJobAuth";
            this.chkDisableJobAuth.Size = new System.Drawing.Size(134, 22);
            this.chkDisableJobAuth.TabIndex = 60;
            this.chkDisableJobAuth.Text = "Disable Job Auth";
            this.chkDisableJobAuth.UseVisualStyleBackColor = true;
            // 
            // chkEnablePriceBidding
            // 
            this.chkEnablePriceBidding.AutoSize = true;
            this.chkEnablePriceBidding.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnablePriceBidding.Location = new System.Drawing.Point(17, 522);
            this.chkEnablePriceBidding.Name = "chkEnablePriceBidding";
            this.chkEnablePriceBidding.Size = new System.Drawing.Size(154, 22);
            this.chkEnablePriceBidding.TabIndex = 56;
            this.chkEnablePriceBidding.Text = "Enable Price Bidding";
            this.chkEnablePriceBidding.UseVisualStyleBackColor = true;
            // 
            // chkEnableDriverConnect
            // 
            this.chkEnableDriverConnect.AutoSize = true;
            this.chkEnableDriverConnect.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableDriverConnect.Location = new System.Drawing.Point(240, 568);
            this.chkEnableDriverConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnableDriverConnect.Name = "chkEnableDriverConnect";
            this.chkEnableDriverConnect.Size = new System.Drawing.Size(170, 22);
            this.chkEnableDriverConnect.TabIndex = 65;
            this.chkEnableDriverConnect.Text = "Enable Driver Connect";
            this.chkEnableDriverConnect.UseVisualStyleBackColor = true;
            // 
            // chkDisableSTC
            // 
            this.chkDisableSTC.AutoSize = true;
            this.chkDisableSTC.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableSTC.Location = new System.Drawing.Point(478, 448);
            this.chkDisableSTC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisableSTC.Name = "chkDisableSTC";
            this.chkDisableSTC.Size = new System.Drawing.Size(104, 22);
            this.chkDisableSTC.TabIndex = 5;
            this.chkDisableSTC.Text = "Disable STC";
            this.chkDisableSTC.UseVisualStyleBackColor = true;
            this.chkDisableSTC.Visible = false;
            // 
            // chkEnableManualFares
            // 
            this.chkEnableManualFares.AutoSize = true;
            this.chkEnableManualFares.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableManualFares.Location = new System.Drawing.Point(17, 481);
            this.chkEnableManualFares.Name = "chkEnableManualFares";
            this.chkEnableManualFares.Size = new System.Drawing.Size(161, 22);
            this.chkEnableManualFares.TabIndex = 55;
            this.chkEnableManualFares.Text = "Enable Manual Fares";
            this.chkEnableManualFares.UseVisualStyleBackColor = true;
            // 
            // chkDisableFareOnAccJob
            // 
            this.chkDisableFareOnAccJob.AutoSize = true;
            this.chkDisableFareOnAccJob.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableFareOnAccJob.Location = new System.Drawing.Point(478, 481);
            this.chkDisableFareOnAccJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisableFareOnAccJob.Name = "chkDisableFareOnAccJob";
            this.chkDisableFareOnAccJob.Size = new System.Drawing.Size(183, 22);
            this.chkDisableFareOnAccJob.TabIndex = 4;
            this.chkDisableFareOnAccJob.Text = "Disable Fare on A/C Job";
            this.chkDisableFareOnAccJob.UseVisualStyleBackColor = true;
            this.chkDisableFareOnAccJob.Visible = false;
            // 
            // chkDisableAlarm
            // 
            this.chkDisableAlarm.AutoSize = true;
            this.chkDisableAlarm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableAlarm.Location = new System.Drawing.Point(478, 520);
            this.chkDisableAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisableAlarm.Name = "chkDisableAlarm";
            this.chkDisableAlarm.Size = new System.Drawing.Size(140, 22);
            this.chkDisableAlarm.TabIndex = 2;
            this.chkDisableAlarm.Text = "Disable Set Alarm";
            this.chkDisableAlarm.UseVisualStyleBackColor = true;
            this.chkDisableAlarm.Visible = false;
            // 
            // chkEnableOptionalManualFares
            // 
            this.chkEnableOptionalManualFares.AutoSize = true;
            this.chkEnableOptionalManualFares.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableOptionalManualFares.Location = new System.Drawing.Point(50, 503);
            this.chkEnableOptionalManualFares.Name = "chkEnableOptionalManualFares";
            this.chkEnableOptionalManualFares.Size = new System.Drawing.Size(81, 18);
            this.chkEnableOptionalManualFares.TabIndex = 55;
            this.chkEnableOptionalManualFares.Text = "(Optional)";
            this.chkEnableOptionalManualFares.UseVisualStyleBackColor = true;
            // 
            // chkDisableNoPickup
            // 
            this.chkDisableNoPickup.AutoSize = true;
            this.chkDisableNoPickup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableNoPickup.Location = new System.Drawing.Point(478, 553);
            this.chkDisableNoPickup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisableNoPickup.Name = "chkDisableNoPickup";
            this.chkDisableNoPickup.Size = new System.Drawing.Size(140, 22);
            this.chkDisableNoPickup.TabIndex = 1;
            this.chkDisableNoPickup.Text = "Disable No Pickup";
            this.chkDisableNoPickup.UseVisualStyleBackColor = true;
            this.chkDisableNoPickup.Visible = false;
            // 
            // txtPDAVer
            // 
            this.txtPDAVer.AutoSize = true;
            this.txtPDAVer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDAVer.Location = new System.Drawing.Point(517, 70);
            this.txtPDAVer.Name = "txtPDAVer";
            this.txtPDAVer.Size = new System.Drawing.Size(170, 18);
            this.txtPDAVer.TabIndex = 54;
            this.txtPDAVer.Text = "Current PDA Version :";
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.Location = new System.Drawing.Point(680, 515);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(184, 67);
            this.btnUpdateSettings.TabIndex = 53;
            this.btnUpdateSettings.Text = "Update Settings >>";
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdateSettings.GetChildAt(0))).Text = "Update Settings >>";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdateSettings.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDisableOnBreak
            // 
            this.chkDisableOnBreak.AutoSize = true;
            this.chkDisableOnBreak.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableOnBreak.Location = new System.Drawing.Point(478, 331);
            this.chkDisableOnBreak.Name = "chkDisableOnBreak";
            this.chkDisableOnBreak.Size = new System.Drawing.Size(133, 22);
            this.chkDisableOnBreak.TabIndex = 52;
            this.chkDisableOnBreak.Text = "Disable OnBreak";
            this.chkDisableOnBreak.UseVisualStyleBackColor = true;
            // 
            // chkShiftOverLogout
            // 
            this.chkShiftOverLogout.AutoSize = true;
            this.chkShiftOverLogout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShiftOverLogout.Location = new System.Drawing.Point(241, 508);
            this.chkShiftOverLogout.Name = "chkShiftOverLogout";
            this.chkShiftOverLogout.Size = new System.Drawing.Size(162, 22);
            this.chkShiftOverLogout.TabIndex = 51;
            this.chkShiftOverLogout.Text = "Logout on Shift Over";
            this.chkShiftOverLogout.UseVisualStyleBackColor = true;
            // 
            // chkShowSpecReq
            // 
            this.chkShowSpecReq.AutoSize = true;
            this.chkShowSpecReq.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowSpecReq.Location = new System.Drawing.Point(241, 476);
            this.chkShowSpecReq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowSpecReq.Name = "chkShowSpecReq";
            this.chkShowSpecReq.Size = new System.Drawing.Size(199, 22);
            this.chkShowSpecReq.TabIndex = 3;
            this.chkShowSpecReq.Text = "Show Special Req on Front";
            this.chkShowSpecReq.UseVisualStyleBackColor = true;
            this.chkShowSpecReq.Visible = false;
            // 
            // chkShowJobAsAlert
            // 
            this.chkShowJobAsAlert.AutoSize = true;
            this.chkShowJobAsAlert.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowJobAsAlert.Location = new System.Drawing.Point(240, 598);
            this.chkShowJobAsAlert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowJobAsAlert.Name = "chkShowJobAsAlert";
            this.chkShowJobAsAlert.Size = new System.Drawing.Size(142, 22);
            this.chkShowJobAsAlert.TabIndex = 0;
            this.chkShowJobAsAlert.Text = "Show Job as Alert";
            this.chkShowJobAsAlert.UseVisualStyleBackColor = true;
            this.chkShowJobAsAlert.Visible = false;
            // 
            // chkDisableBase
            // 
            this.chkDisableBase.AutoSize = true;
            this.chkDisableBase.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableBase.Location = new System.Drawing.Point(478, 418);
            this.chkDisableBase.Name = "chkDisableBase";
            this.chkDisableBase.Size = new System.Drawing.Size(109, 22);
            this.chkDisableBase.TabIndex = 50;
            this.chkDisableBase.Text = "Disable Base";
            this.chkDisableBase.UseVisualStyleBackColor = true;
            // 
            // chkShowFareonExtraCharges
            // 
            this.chkShowFareonExtraCharges.AutoSize = true;
            this.chkShowFareonExtraCharges.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowFareonExtraCharges.Location = new System.Drawing.Point(241, 539);
            this.chkShowFareonExtraCharges.Name = "chkShowFareonExtraCharges";
            this.chkShowFareonExtraCharges.Size = new System.Drawing.Size(220, 22);
            this.chkShowFareonExtraCharges.TabIndex = 49;
            this.chkShowFareonExtraCharges.Text = "Show Fares on Extra Charges";
            this.chkShowFareonExtraCharges.UseVisualStyleBackColor = true;
            // 
            // chkEnableLogoutOnReject
            // 
            this.chkEnableLogoutOnReject.AutoSize = true;
            this.chkEnableLogoutOnReject.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableLogoutOnReject.Location = new System.Drawing.Point(17, 447);
            this.chkEnableLogoutOnReject.Name = "chkEnableLogoutOnReject";
            this.chkEnableLogoutOnReject.Size = new System.Drawing.Size(212, 22);
            this.chkEnableLogoutOnReject.TabIndex = 48;
            this.chkEnableLogoutOnReject.Text = "Enable Logout on Reject Job";
            this.chkEnableLogoutOnReject.UseVisualStyleBackColor = true;
            // 
            // chkHidePickupAndDest
            // 
            this.chkHidePickupAndDest.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHidePickupAndDest.Location = new System.Drawing.Point(478, 285);
            this.chkHidePickupAndDest.Name = "chkHidePickupAndDest";
            this.chkHidePickupAndDest.Size = new System.Drawing.Size(197, 43);
            this.chkHidePickupAndDest.TabIndex = 47;
            this.chkHidePickupAndDest.Text = "Hide Details On Job Offer";
            this.chkHidePickupAndDest.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(784, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 46;
            this.label7.Text = "(secs)";
            // 
            // numJobTimeout
            // 
            this.numJobTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numJobTimeout.Location = new System.Drawing.Point(713, 247);
            this.numJobTimeout.Name = "numJobTimeout";
            this.numJobTimeout.Size = new System.Drawing.Size(66, 22);
            this.numJobTimeout.TabIndex = 45;
            this.numJobTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(670, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 18);
            this.label8.TabIndex = 44;
            this.label8.Text = "Job Notification Timeout";
            // 
            // txtBiddingMessage
            // 
            this.txtBiddingMessage.AutoSize = true;
            this.txtBiddingMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBiddingMessage.ForeColor = System.Drawing.Color.Red;
            this.txtBiddingMessage.Location = new System.Drawing.Point(140, 76);
            this.txtBiddingMessage.Name = "txtBiddingMessage";
            this.txtBiddingMessage.Size = new System.Drawing.Size(283, 14);
            this.txtBiddingMessage.TabIndex = 43;
            this.txtBiddingMessage.Text = "Problem on getting Bidding Info from Server";
            this.txtBiddingMessage.Visible = false;
            // 
            // txtFareMessage
            // 
            this.txtFareMessage.AutoSize = true;
            this.txtFareMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtFareMessage.ForeColor = System.Drawing.Color.Red;
            this.txtFareMessage.Location = new System.Drawing.Point(32, 131);
            this.txtFareMessage.Name = "txtFareMessage";
            this.txtFareMessage.Size = new System.Drawing.Size(238, 14);
            this.txtFareMessage.TabIndex = 42;
            this.txtFareMessage.Text = "Problem on getting Fares from Server";
            this.txtFareMessage.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(784, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 41;
            this.label6.Text = "(Mins)";
            // 
            // numBreakDuration
            // 
            this.numBreakDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBreakDuration.Location = new System.Drawing.Point(713, 196);
            this.numBreakDuration.Name = "numBreakDuration";
            this.numBreakDuration.Size = new System.Drawing.Size(66, 22);
            this.numBreakDuration.TabIndex = 40;
            this.numBreakDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 39;
            this.label5.Text = "Break Duration :";
            // 
            // chkDisableMeterAccJob
            // 
            this.chkDisableMeterAccJob.AutoSize = true;
            this.chkDisableMeterAccJob.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkDisableMeterAccJob.ForeColor = System.Drawing.Color.Blue;
            this.chkDisableMeterAccJob.Location = new System.Drawing.Point(307, 107);
            this.chkDisableMeterAccJob.Name = "chkDisableMeterAccJob";
            this.chkDisableMeterAccJob.Size = new System.Drawing.Size(189, 21);
            this.chkDisableMeterAccJob.TabIndex = 38;
            this.chkDisableMeterAccJob.Text = "Disable Meter For Acc Jobs";
            this.chkDisableMeterAccJob.UseVisualStyleBackColor = true;
            // 
            // chkEnableMeterWaitingCharges
            // 
            this.chkEnableMeterWaitingCharges.AutoSize = true;
            this.chkEnableMeterWaitingCharges.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkEnableMeterWaitingCharges.ForeColor = System.Drawing.Color.Blue;
            this.chkEnableMeterWaitingCharges.Location = new System.Drawing.Point(510, 107);
            this.chkEnableMeterWaitingCharges.Name = "chkEnableMeterWaitingCharges";
            this.chkEnableMeterWaitingCharges.Size = new System.Drawing.Size(165, 21);
            this.chkEnableMeterWaitingCharges.TabIndex = 37;
            this.chkEnableMeterWaitingCharges.Text = "Meter Waiting Charges";
            this.chkEnableMeterWaitingCharges.UseVisualStyleBackColor = true;
            // 
            // chkEnableOptionalMeter
            // 
            this.chkEnableOptionalMeter.AutoSize = true;
            this.chkEnableOptionalMeter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkEnableOptionalMeter.ForeColor = System.Drawing.Color.Blue;
            this.chkEnableOptionalMeter.Location = new System.Drawing.Point(177, 107);
            this.chkEnableOptionalMeter.Name = "chkEnableOptionalMeter";
            this.chkEnableOptionalMeter.Size = new System.Drawing.Size(115, 21);
            this.chkEnableOptionalMeter.TabIndex = 36;
            this.chkEnableOptionalMeter.Text = "Optional Meter";
            this.chkEnableOptionalMeter.UseVisualStyleBackColor = true;
            // 
            // chkShowSoundOnZoneChange
            // 
            this.chkShowSoundOnZoneChange.AutoSize = true;
            this.chkShowSoundOnZoneChange.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowSoundOnZoneChange.Location = new System.Drawing.Point(478, 257);
            this.chkShowSoundOnZoneChange.Name = "chkShowSoundOnZoneChange";
            this.chkShowSoundOnZoneChange.Size = new System.Drawing.Size(182, 22);
            this.chkShowSoundOnZoneChange.TabIndex = 31;
            this.chkShowSoundOnZoneChange.Text = "Sound On Zone Change";
            this.chkShowSoundOnZoneChange.UseVisualStyleBackColor = true;
            // 
            // chkDisableChangeJobPlot
            // 
            this.chkDisableChangeJobPlot.AutoSize = true;
            this.chkDisableChangeJobPlot.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableChangeJobPlot.Location = new System.Drawing.Point(478, 233);
            this.chkDisableChangeJobPlot.Name = "chkDisableChangeJobPlot";
            this.chkDisableChangeJobPlot.Size = new System.Drawing.Size(181, 22);
            this.chkDisableChangeJobPlot.TabIndex = 30;
            this.chkDisableChangeJobPlot.Text = "Disable Change Job Plot";
            this.chkDisableChangeJobPlot.UseVisualStyleBackColor = true;
            // 
            // chkDisableRank
            // 
            this.chkDisableRank.AutoSize = true;
            this.chkDisableRank.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableRank.Location = new System.Drawing.Point(478, 197);
            this.chkDisableRank.Name = "chkDisableRank";
            this.chkDisableRank.Size = new System.Drawing.Size(152, 22);
            this.chkDisableRank.TabIndex = 29;
            this.chkDisableRank.Text = "Disable Driver Rank";
            this.chkDisableRank.UseVisualStyleBackColor = true;
            // 
            // chkDisablePanic
            // 
            this.chkDisablePanic.AutoSize = true;
            this.chkDisablePanic.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisablePanic.Location = new System.Drawing.Point(478, 161);
            this.chkDisablePanic.Name = "chkDisablePanic";
            this.chkDisablePanic.Size = new System.Drawing.Size(158, 22);
            this.chkDisablePanic.TabIndex = 28;
            this.chkDisablePanic.Text = "Disable Panic Button";
            this.chkDisablePanic.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreArriveAction
            // 
            this.chkIgnoreArriveAction.AutoSize = true;
            this.chkIgnoreArriveAction.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreArriveAction.Location = new System.Drawing.Point(241, 414);
            this.chkIgnoreArriveAction.Name = "chkIgnoreArriveAction";
            this.chkIgnoreArriveAction.Size = new System.Drawing.Size(156, 22);
            this.chkIgnoreArriveAction.TabIndex = 27;
            this.chkIgnoreArriveAction.Text = "Ignore Arrive Action";
            this.chkIgnoreArriveAction.UseVisualStyleBackColor = true;
            // 
            // chkMessageStay
            // 
            this.chkMessageStay.AutoSize = true;
            this.chkMessageStay.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMessageStay.Location = new System.Drawing.Point(241, 447);
            this.chkMessageStay.Name = "chkMessageStay";
            this.chkMessageStay.Size = new System.Drawing.Size(189, 22);
            this.chkMessageStay.TabIndex = 26;
            this.chkMessageStay.Text = "Message Stay on Screen";
            this.chkMessageStay.UseVisualStyleBackColor = true;
            // 
            // ShowPlotOnJobOffer
            // 
            this.ShowPlotOnJobOffer.AutoSize = true;
            this.ShowPlotOnJobOffer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPlotOnJobOffer.Location = new System.Drawing.Point(241, 343);
            this.ShowPlotOnJobOffer.Name = "ShowPlotOnJobOffer";
            this.ShowPlotOnJobOffer.Size = new System.Drawing.Size(176, 22);
            this.ShowPlotOnJobOffer.TabIndex = 25;
            this.ShowPlotOnJobOffer.Text = "Show Plot on Job Offer";
            this.ShowPlotOnJobOffer.UseVisualStyleBackColor = true;
            // 
            // chkShowAlertOnJobLater
            // 
            this.chkShowAlertOnJobLater.AutoSize = true;
            this.chkShowAlertOnJobLater.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAlertOnJobLater.Location = new System.Drawing.Point(241, 308);
            this.chkShowAlertOnJobLater.Name = "chkShowAlertOnJobLater";
            this.chkShowAlertOnJobLater.Size = new System.Drawing.Size(174, 22);
            this.chkShowAlertOnJobLater.TabIndex = 24;
            this.chkShowAlertOnJobLater.Text = "Show Alert On JobLate";
            this.chkShowAlertOnJobLater.UseVisualStyleBackColor = true;
            // 
            // chkShowCustomerMobileNo
            // 
            this.chkShowCustomerMobileNo.AutoSize = true;
            this.chkShowCustomerMobileNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowCustomerMobileNo.Location = new System.Drawing.Point(241, 271);
            this.chkShowCustomerMobileNo.Name = "chkShowCustomerMobileNo";
            this.chkShowCustomerMobileNo.Size = new System.Drawing.Size(197, 22);
            this.chkShowCustomerMobileNo.TabIndex = 23;
            this.chkShowCustomerMobileNo.Text = "Show Customer Mobile No";
            this.chkShowCustomerMobileNo.UseVisualStyleBackColor = true;
            // 
            // chkShowNavigation
            // 
            this.chkShowNavigation.AutoSize = true;
            this.chkShowNavigation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowNavigation.Location = new System.Drawing.Point(241, 233);
            this.chkShowNavigation.Name = "chkShowNavigation";
            this.chkShowNavigation.Size = new System.Drawing.Size(133, 22);
            this.chkShowNavigation.TabIndex = 22;
            this.chkShowNavigation.Text = "Show Navigation";
            this.chkShowNavigation.UseVisualStyleBackColor = true;
            // 
            // chkShowCompletedJobs
            // 
            this.chkShowCompletedJobs.AutoSize = true;
            this.chkShowCompletedJobs.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowCompletedJobs.Location = new System.Drawing.Point(241, 197);
            this.chkShowCompletedJobs.Name = "chkShowCompletedJobs";
            this.chkShowCompletedJobs.Size = new System.Drawing.Size(169, 22);
            this.chkShowCompletedJobs.TabIndex = 21;
            this.chkShowCompletedJobs.Text = "Show Completed Jobs";
            this.chkShowCompletedJobs.UseVisualStyleBackColor = true;
            // 
            // chkShowPlots
            // 
            this.chkShowPlots.AutoSize = true;
            this.chkShowPlots.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPlots.Location = new System.Drawing.Point(241, 161);
            this.chkShowPlots.Name = "chkShowPlots";
            this.chkShowPlots.Size = new System.Drawing.Size(96, 22);
            this.chkShowPlots.TabIndex = 20;
            this.chkShowPlots.Text = "Show Plots";
            this.chkShowPlots.UseVisualStyleBackColor = true;
            // 
            // chkEnableAutoRotate
            // 
            this.chkEnableAutoRotate.AutoSize = true;
            this.chkEnableAutoRotate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableAutoRotate.Location = new System.Drawing.Point(17, 414);
            this.chkEnableAutoRotate.Name = "chkEnableAutoRotate";
            this.chkEnableAutoRotate.Size = new System.Drawing.Size(196, 22);
            this.chkEnableAutoRotate.TabIndex = 19;
            this.chkEnableAutoRotate.Text = "Enable AutoRotate Screen";
            this.chkEnableAutoRotate.UseVisualStyleBackColor = true;
            // 
            // chkEnableCompanyCars
            // 
            this.chkEnableCompanyCars.AutoSize = true;
            this.chkEnableCompanyCars.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableCompanyCars.Location = new System.Drawing.Point(17, 379);
            this.chkEnableCompanyCars.Name = "chkEnableCompanyCars";
            this.chkEnableCompanyCars.Size = new System.Drawing.Size(170, 22);
            this.chkEnableCompanyCars.TabIndex = 18;
            this.chkEnableCompanyCars.Text = "Enable Company Cars";
            this.chkEnableCompanyCars.UseVisualStyleBackColor = true;
            // 
            // chkEnableJ15Jobs
            // 
            this.chkEnableJ15Jobs.AutoSize = true;
            this.chkEnableJ15Jobs.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableJ15Jobs.Location = new System.Drawing.Point(17, 343);
            this.chkEnableJ15Jobs.Name = "chkEnableJ15Jobs";
            this.chkEnableJ15Jobs.Size = new System.Drawing.Size(187, 22);
            this.chkEnableJ15Jobs.TabIndex = 17;
            this.chkEnableJ15Jobs.Text = "Enable J15 And J30 Jobs";
            this.chkEnableJ15Jobs.UseVisualStyleBackColor = true;
            // 
            // chkEnableCallCustomer
            // 
            this.chkEnableCallCustomer.AutoSize = true;
            this.chkEnableCallCustomer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableCallCustomer.Location = new System.Drawing.Point(17, 308);
            this.chkEnableCallCustomer.Name = "chkEnableCallCustomer";
            this.chkEnableCallCustomer.Size = new System.Drawing.Size(163, 22);
            this.chkEnableCallCustomer.TabIndex = 16;
            this.chkEnableCallCustomer.Text = "Enable Call Customer";
            this.chkEnableCallCustomer.UseVisualStyleBackColor = true;
            // 
            // chkEnableJobExtraCharges
            // 
            this.chkEnableJobExtraCharges.AutoSize = true;
            this.chkEnableJobExtraCharges.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableJobExtraCharges.Location = new System.Drawing.Point(17, 271);
            this.chkEnableJobExtraCharges.Name = "chkEnableJobExtraCharges";
            this.chkEnableJobExtraCharges.Size = new System.Drawing.Size(193, 22);
            this.chkEnableJobExtraCharges.TabIndex = 15;
            this.chkEnableJobExtraCharges.Text = "Enable Job Extra Charges";
            this.chkEnableJobExtraCharges.UseVisualStyleBackColor = true;
            // 
            // chkEnableRecoverJob
            // 
            this.chkEnableRecoverJob.AutoSize = true;
            this.chkEnableRecoverJob.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableRecoverJob.Location = new System.Drawing.Point(17, 233);
            this.chkEnableRecoverJob.Name = "chkEnableRecoverJob";
            this.chkEnableRecoverJob.Size = new System.Drawing.Size(154, 22);
            this.chkEnableRecoverJob.TabIndex = 14;
            this.chkEnableRecoverJob.Text = "Enable Recover Job";
            this.chkEnableRecoverJob.UseVisualStyleBackColor = true;
            // 
            // chkEnableLogoutAuthorization
            // 
            this.chkEnableLogoutAuthorization.AutoSize = true;
            this.chkEnableLogoutAuthorization.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableLogoutAuthorization.Location = new System.Drawing.Point(17, 197);
            this.chkEnableLogoutAuthorization.Name = "chkEnableLogoutAuthorization";
            this.chkEnableLogoutAuthorization.Size = new System.Drawing.Size(206, 22);
            this.chkEnableLogoutAuthorization.TabIndex = 13;
            this.chkEnableLogoutAuthorization.Text = "Enable Logout Authorization";
            this.chkEnableLogoutAuthorization.UseVisualStyleBackColor = true;
            // 
            // chkEnableFlagDown
            // 
            this.chkEnableFlagDown.AutoSize = true;
            this.chkEnableFlagDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableFlagDown.Location = new System.Drawing.Point(17, 161);
            this.chkEnableFlagDown.Name = "chkEnableFlagDown";
            this.chkEnableFlagDown.Size = new System.Drawing.Size(141, 22);
            this.chkEnableFlagDown.TabIndex = 12;
            this.chkEnableFlagDown.Text = "Enable Flag Down";
            this.chkEnableFlagDown.UseVisualStyleBackColor = true;
            // 
            // chkEnableFareMeter
            // 
            this.chkEnableFareMeter.AutoSize = true;
            this.chkEnableFareMeter.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableFareMeter.Location = new System.Drawing.Point(17, 106);
            this.chkEnableFareMeter.Name = "chkEnableFareMeter";
            this.chkEnableFareMeter.Size = new System.Drawing.Size(141, 22);
            this.chkEnableFareMeter.TabIndex = 11;
            this.chkEnableFareMeter.Text = "Enable FareMeter";
            this.chkEnableFareMeter.UseVisualStyleBackColor = true;
            this.chkEnableFareMeter.CheckedChanged += new System.EventHandler(this.chkEnableFareMeter_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Navigation App :";
            // 
            // chkEnableBidding
            // 
            this.chkEnableBidding.AutoSize = true;
            this.chkEnableBidding.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableBidding.Location = new System.Drawing.Point(17, 72);
            this.chkEnableBidding.Name = "chkEnableBidding";
            this.chkEnableBidding.Size = new System.Drawing.Size(119, 22);
            this.chkEnableBidding.TabIndex = 8;
            this.chkEnableBidding.Text = "Enable Bidding";
            this.chkEnableBidding.UseVisualStyleBackColor = true;
            // 
            // ddlNavigation
            // 
            this.ddlNavigation.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlNavigation.FormattingEnabled = true;
            this.ddlNavigation.Items.AddRange(new object[] {
            "All",
            "Google Navigation",
            "Waze Navigation",
            "Here we Go Navigation",
            "None"});
            this.ddlNavigation.Location = new System.Drawing.Point(141, 27);
            this.ddlNavigation.Name = "ddlNavigation";
            this.ddlNavigation.Size = new System.Drawing.Size(336, 26);
            this.ddlNavigation.TabIndex = 9;
            // 
            // chkDisableChangeDest
            // 
            this.chkDisableChangeDest.BackColor = System.Drawing.Color.Transparent;
            this.chkDisableChangeDest.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableChangeDest.Location = new System.Drawing.Point(480, 390);
            this.chkDisableChangeDest.Name = "chkDisableChangeDest";
            this.chkDisableChangeDest.Size = new System.Drawing.Size(236, 22);
            this.chkDisableChangeDest.TabIndex = 1;
            this.chkDisableChangeDest.Text = "Disable Change Job Destination";
            this.chkDisableChangeDest.UseVisualStyleBackColor = false;
            // 
            // chkDisableRejectJob
            // 
            this.chkDisableRejectJob.BackColor = System.Drawing.Color.Transparent;
            this.chkDisableRejectJob.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisableRejectJob.Location = new System.Drawing.Point(480, 360);
            this.chkDisableRejectJob.Name = "chkDisableRejectJob";
            this.chkDisableRejectJob.Size = new System.Drawing.Size(146, 22);
            this.chkDisableRejectJob.TabIndex = 0;
            this.chkDisableRejectJob.Text = "Disable Reject Job";
            this.chkDisableRejectJob.UseVisualStyleBackColor = false;
            // 
            // Pg_notes
            // 
            this.Pg_notes.Controls.Add(this.radPanel3);
            this.Pg_notes.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.Pg_notes.Location = new System.Drawing.Point(12, 44);
            this.Pg_notes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_notes.Name = "Pg_notes";
            this.Pg_notes.Size = new System.Drawing.Size(1025, 770);
            this.Pg_notes.Text = "Driver Notes";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.grdLister);
            this.radPanel3.Controls.Add(this.btnNew);
            this.radPanel3.Controls.Add(this.btnAdd);
            this.radPanel3.Controls.Add(this.txtNotes);
            this.radPanel3.Controls.Add(this.radLabel35);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel3.Location = new System.Drawing.Point(0, 0);
            this.radPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1025, 769);
            this.radPanel3.TabIndex = 0;
            // 
            // grdLister
            // 
            this.grdLister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdLister.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLister.Location = new System.Drawing.Point(0, 141);
            this.grdLister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdLister.MasterTemplate.AllowAddNewRow = false;
            this.grdLister.MasterTemplate.AllowDeleteRow = false;
            this.grdLister.MasterTemplate.AllowEditRow = false;
            this.grdLister.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdLister.Name = "grdLister";
            this.grdLister.ShowGroupPanel = false;
            this.grdLister.Size = new System.Drawing.Size(1025, 628);
            this.grdLister.TabIndex = 52;
            this.grdLister.Text = "radGridView1";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(898, 39);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(108, 66);
            this.btnNew.TabIndex = 51;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnNew.GetChildAt(0))).Text = "New";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnNew.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Taxi_AppMain.Properties.Resources.AddBig;
            this.btnAdd.Location = new System.Drawing.Point(765, 39);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 66);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.AddBig;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Text = "Add";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAdd.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtNotes
            // 
            this.txtNotes.AutoSize = false;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(84, 38);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(657, 69);
            this.txtNotes.TabIndex = 49;
            this.txtNotes.TabStop = false;
            // 
            // radLabel35
            // 
            this.radLabel35.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel35.Location = new System.Drawing.Point(10, 64);
            this.radLabel35.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radLabel35.Name = "radLabel35";
            this.radLabel35.Size = new System.Drawing.Size(61, 27);
            this.radLabel35.TabIndex = 48;
            this.radLabel35.Text = "Notes";
            // 
            // pg_complaint
            // 
            this.pg_complaint.Controls.Add(this.grdDriverComplaints);
            this.pg_complaint.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pg_complaint.Location = new System.Drawing.Point(12, 44);
            this.pg_complaint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_complaint.Name = "pg_complaint";
            this.pg_complaint.Size = new System.Drawing.Size(1025, 770);
            this.pg_complaint.Text = "Complaints";
            // 
            // grdDriverComplaints
            // 
            this.grdDriverComplaints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDriverComplaints.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDriverComplaints.Location = new System.Drawing.Point(0, 0);
            this.grdDriverComplaints.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverComplaints.MasterTemplate.AllowAddNewRow = false;
            this.grdDriverComplaints.MasterTemplate.AllowDeleteRow = false;
            this.grdDriverComplaints.MasterTemplate.AllowEditRow = false;
            this.grdDriverComplaints.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.grdDriverComplaints.Name = "grdDriverComplaints";
            this.grdDriverComplaints.ShowGroupPanel = false;
            this.grdDriverComplaints.Size = new System.Drawing.Size(1025, 770);
            this.grdDriverComplaints.TabIndex = 53;
            this.grdDriverComplaints.Text = "radGridView1";
            // 
            // Pg_Attributes
            // 
            this.Pg_Attributes.Controls.Add(this.grdDriverAttributes);
            this.Pg_Attributes.ItemSize = new System.Drawing.SizeF(73F, 27F);
            this.Pg_Attributes.Location = new System.Drawing.Point(10, 36);
            this.Pg_Attributes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Attributes.Name = "Pg_Attributes";
            this.Pg_Attributes.Size = new System.Drawing.Size(1029, 790);
            this.Pg_Attributes.Text = "Attributes";
            // 
            // grdDriverAttributes
            // 
            this.grdDriverAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDriverAttributes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDriverAttributes.Location = new System.Drawing.Point(14, 18);
            this.grdDriverAttributes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDriverAttributes.MasterTemplate.AllowAddNewRow = false;
            this.grdDriverAttributes.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.grdDriverAttributes.Name = "grdDriverAttributes";
            this.grdDriverAttributes.ShowGroupPanel = false;
            this.grdDriverAttributes.Size = new System.Drawing.Size(426, 542);
            this.grdDriverAttributes.TabIndex = 3;
            this.grdDriverAttributes.Text = "Attributes";
            // 
            // Pg_Rating
            // 
            this.Pg_Rating.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.Pg_Rating.Location = new System.Drawing.Point(12, 44);
            this.Pg_Rating.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pg_Rating.Name = "Pg_Rating";
            this.Pg_Rating.Size = new System.Drawing.Size(1025, 770);
            this.Pg_Rating.Text = "Rating";
            // 
            // CompanyVehicle
            // 
            this.CompanyVehicle.Controls.Add(this.grdCompanyVehicles);
            this.CompanyVehicle.ItemSize = new System.Drawing.SizeF(114F, 27F);
            this.CompanyVehicle.Location = new System.Drawing.Point(12, 44);
            this.CompanyVehicle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompanyVehicle.Name = "CompanyVehicle";
            this.CompanyVehicle.Size = new System.Drawing.Size(1025, 770);
            this.CompanyVehicle.Text = "Company Vehicle";
            this.CompanyVehicle.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdCompanyVehicles
            // 
            this.grdCompanyVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdCompanyVehicles.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCompanyVehicles.Location = new System.Drawing.Point(3, 33);
            this.grdCompanyVehicles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdCompanyVehicles.MasterTemplate.AllowAddNewRow = false;
            this.grdCompanyVehicles.MasterTemplate.ViewDefinition = tableViewDefinition7;
            this.grdCompanyVehicles.Name = "grdCompanyVehicles";
            this.grdCompanyVehicles.ShowGroupPanel = false;
            this.grdCompanyVehicles.Size = new System.Drawing.Size(565, 542);
            this.grdCompanyVehicles.TabIndex = 4;
            this.grdCompanyVehicles.Text = "Attributes";
            // 
            // pg_charges
            // 
            this.pg_charges.Controls.Add(this.grdDebitCreditNotes);
            this.pg_charges.ItemSize = new System.Drawing.SizeF(62F, 27F);
            this.pg_charges.Location = new System.Drawing.Point(12, 44);
            this.pg_charges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pg_charges.Name = "pg_charges";
            this.pg_charges.Size = new System.Drawing.Size(1025, 770);
            this.pg_charges.Text = "Charges";
            // 
            // grdDebitCreditNotes
            // 
            this.grdDebitCreditNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDebitCreditNotes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDebitCreditNotes.Location = new System.Drawing.Point(0, 0);
            this.grdDebitCreditNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // 
            // 
            this.grdDebitCreditNotes.MasterTemplate.AllowAddNewRow = false;
            this.grdDebitCreditNotes.MasterTemplate.AllowDeleteRow = false;
            this.grdDebitCreditNotes.MasterTemplate.AllowEditRow = false;
            this.grdDebitCreditNotes.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.grdDebitCreditNotes.Name = "grdDebitCreditNotes";
            this.grdDebitCreditNotes.ShowGroupPanel = false;
            this.grdDebitCreditNotes.Size = new System.Drawing.Size(1025, 770);
            this.grdDebitCreditNotes.TabIndex = 54;
            this.grdDebitCreditNotes.Text = "radGridView1";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "";
            // 
            // DrirverRating
            // 
            this.DrirverRating.Name = "DrirverRating";
            this.DrirverRating.Text = "";
            // 
            // object_8d9a8a89_3408_492c_97b0_6d603c29a72e
            // 
            this.object_8d9a8a89_3408_492c_97b0_6d603c29a72e.Name = "object_8d9a8a89_3408_492c_97b0_6d603c29a72e";
            this.object_8d9a8a89_3408_492c_97b0_6d603c29a72e.StretchHorizontally = true;
            this.object_8d9a8a89_3408_492c_97b0_6d603c29a72e.StretchVertically = true;
            // 
            // radTextBox1
            // 
            this.radTextBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBox1.Location = new System.Drawing.Point(133, 39);
            this.radTextBox1.MaxLength = 50;
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(191, 21);
            this.radTextBox1.TabIndex = 47;
            this.radTextBox1.TabStop = false;
            // 
            // frmDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 760);
            this.Controls.Add(this.radpageview1);
            this.FixedExitButtonOnTopRight = true;
            this.FormTitle = "Driver";
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDriver";
            this.ShowExitButton = true;
            this.ShowHeader = true;
            this.ShowSaveAndCloseButton = true;
            this.ShowSaveAndNewButton = true;
            this.Text = "Driver";
            this.Load += new System.EventHandler(this.frmDriver_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDriver_KeyDown);
            this.Controls.SetChildIndex(this.radpageview1, 0);
            this.Controls.SetChildIndex(this.btnSaveAndClose, 0);
            this.Controls.SetChildIndex(this.btnSaveOn, 0);
            this.Controls.SetChildIndex(this.btnOnNew, 0);
            this.Controls.SetChildIndex(this.btnSaveAndNew, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radpageview1)).EndInit();
            this.radpageview1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAccComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingCompletedHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrainingReqHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaxCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPDARent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblpdarent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogBookDocPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleLogBookNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRentLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVehEndOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVehAssignedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlVehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDriverRentComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDriverType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriverType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBidding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebLoginPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasPDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasRentPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverNo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEndDrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndingDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAvailDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailability.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephoneNo)).EndInit();
            this.pg_Shifts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverShifts.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverShifts)).EndInit();
            this.radPageViewPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAffiliateKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Comments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_PDADeposits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_DataAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_NetworkAPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Model)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_Make)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_SIM_PDADateGiven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_NetworkName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SIM_IMEI)).EndInit();
            this.pg_pdasettings.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJobTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakDuration)).EndInit();
            this.Pg_notes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).EndInit();
            this.pg_complaint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverComplaints.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverComplaints)).EndInit();
            this.Pg_Attributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDriverAttributes)).EndInit();
            this.CompanyVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyVehicles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyVehicles)).EndInit();
            this.pg_charges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDebitCreditNotes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDebitCreditNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadPageView radpageview1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadSpinEditor numDriverRentComm;
        private Telerik.WinControls.UI.RadLabel lblDriverType;
        private UI.MyDropDownList ddlDriverType;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtWebLoginPwd;
        private Telerik.WinControls.UI.RadCheckBox chkHasPDA;
        private Telerik.WinControls.UI.RadCheckBox chkHasRentPaid;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadTextBox txtDriverNo;
        private System.Windows.Forms.Panel panel1;
        private UI.MyGridView grdAvailability;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private UI.AutoCompleteTextBox txtAddress;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBox txtNI;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private UI.MyGridView grdDocuments;
        private UI.UserControls.MyPictureBox pic_Driver;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private UI.MyDatePicker dtpDOB;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtDriverName;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadTextBox txtMobileNo;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox txtTelephoneNo;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadGridView grdShifts;
        private System.Windows.Forms.Panel panel4;
        private UI.MyDatePicker dtpTOTime;
        private UI.MyDatePicker dtpFromTime;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private System.Windows.Forms.Button btnAddShift;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        private Telerik.WinControls.UI.RadLabel radLabel20;
        private Telerik.WinControls.UI.RadLabel radLabel26;
        private UI.MyDropDownList ddlShifts;
        private Telerik.WinControls.UI.RadLabel radLabel27;
        private Telerik.WinControls.UI.RadSplitButton btnPrintDriver;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private Telerik.WinControls.UI.RadLabel lblSubCompany;
        private System.Windows.Forms.ComboBox ddlSubCompany;
        private System.Windows.Forms.Button btnSaveChanges;
        private Telerik.WinControls.UI.RadCheckBox chkActiveDriver;
        private Telerik.WinControls.UI.RadCheckBox chkEndDrier;
        private System.Windows.Forms.Button btnClearAvail;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private UI.MyDatePicker dtpEndingDate;
        private System.Windows.Forms.Button btnAddAvailability;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private UI.MyDatePicker dtpAvailDate;
        private UI.MyDropDownList ddlVehicleColor;
        private Telerik.WinControls.UI.RadTextBox txtVehNo;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private UI.MyDropDownList ddlVehicleType;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadLabel radLabel25;
        private Telerik.WinControls.UI.RadTextBox txtVehModel;
        private Telerik.WinControls.UI.RadLabel radLabel22;
        private Telerik.WinControls.UI.RadTextBox txtVehOwner;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadTextBox txtVehMake;
        private Telerik.WinControls.UI.RadLabel radLabel24;
        private Telerik.WinControls.UI.RadLabel radLabel29;
        private UI.MyDatePicker dtpVehEndOn;
        private System.Windows.Forms.Button btnAssignedNew;
        private Telerik.WinControls.UI.RadLabel radLabel28;
        private UI.MyDatePicker dtpVehAssignedOn;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadLabel radLabel30;
        private UI.MyGridView grdVehicles;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_Comments;
        private Telerik.WinControls.UI.RadLabel radLabel34;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_PDADeposits;
        private Telerik.WinControls.UI.RadLabel radLabel33;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_DataAllowance;
        private Telerik.WinControls.UI.RadLabel radLabel31;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_NetworkAPN;
        private Telerik.WinControls.UI.RadLabel radLabel32;
        private Telerik.WinControls.UI.RadLabel radLabel38;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_Model;
        private Telerik.WinControls.UI.RadLabel radLabel41;
        private Telerik.WinControls.UI.RadLabel radLabel36;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_Number;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_Make;
        private Telerik.WinControls.UI.RadLabel radLabel37;
        private UI.MyDatePicker dtp_SIM_PDADateGiven;
        private Telerik.WinControls.UI.RadLabel radLabel40;
        private Telerik.WinControls.UI.RadLabel radLabel39;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_NetworkName;
        private Telerik.WinControls.UI.RadTextBox txt_SIM_IMEI;
        private Telerik.WinControls.UI.RadPageViewPage pg_pdasettings;
        private System.Windows.Forms.GroupBox pnlSettings;
        private Telerik.WinControls.UI.RadButton btnUpdateSettings;
        private System.Windows.Forms.CheckBox chkDisableOnBreak;
        private System.Windows.Forms.CheckBox chkShiftOverLogout;
        private System.Windows.Forms.CheckBox chkDisableBase;
        private System.Windows.Forms.CheckBox chkShowFareonExtraCharges;
        private System.Windows.Forms.CheckBox chkEnableLogoutOnReject;
        private System.Windows.Forms.CheckBox chkHidePickupAndDest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numJobTimeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtBiddingMessage;
        private System.Windows.Forms.Label txtFareMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numBreakDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDisableMeterAccJob;
        private System.Windows.Forms.CheckBox chkEnableMeterWaitingCharges;
        private System.Windows.Forms.CheckBox chkEnableOptionalMeter;
        private System.Windows.Forms.CheckBox chkShowSoundOnZoneChange;
        private System.Windows.Forms.CheckBox chkDisableChangeJobPlot;
        private System.Windows.Forms.CheckBox chkDisableRank;
        private System.Windows.Forms.CheckBox chkDisablePanic;
        private System.Windows.Forms.CheckBox chkIgnoreArriveAction;
        private System.Windows.Forms.CheckBox chkMessageStay;
        private System.Windows.Forms.CheckBox ShowPlotOnJobOffer;
        private System.Windows.Forms.CheckBox chkShowAlertOnJobLater;
        private System.Windows.Forms.CheckBox chkShowCustomerMobileNo;
        private System.Windows.Forms.CheckBox chkShowNavigation;
        private System.Windows.Forms.CheckBox chkShowCompletedJobs;
        private System.Windows.Forms.CheckBox chkShowPlots;
        private System.Windows.Forms.CheckBox chkEnableAutoRotate;
        private System.Windows.Forms.CheckBox chkEnableCompanyCars;
        private System.Windows.Forms.CheckBox chkEnableJ15Jobs;
        private System.Windows.Forms.CheckBox chkEnableCallCustomer;
        private System.Windows.Forms.CheckBox chkEnableJobExtraCharges;
        private System.Windows.Forms.CheckBox chkEnableRecoverJob;
        private System.Windows.Forms.CheckBox chkEnableLogoutAuthorization;
        private System.Windows.Forms.CheckBox chkEnableFlagDown;
        private System.Windows.Forms.CheckBox chkEnableFareMeter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEnableBidding;
        private System.Windows.Forms.ComboBox ddlNavigation;
        private System.Windows.Forms.Label txtPDAVer;
        private Telerik.WinControls.UI.RadLabel lblRangeWiseCommission;
        private Telerik.WinControls.UI.RadGridView grdRangeWiseComm;
        private System.Windows.Forms.CheckBox chkDisableChangeDest;
        private System.Windows.Forms.CheckBox chkDisableRejectJob;
        private Telerik.WinControls.UI.RadPageViewPage Pg_notes;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel35;
        private Telerik.WinControls.RootRadElement object_8d9a8a89_3408_492c_97b0_6d603c29a72e;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadTextBox txtNotes;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnNew;
        private Telerik.WinControls.UI.RadGridView grdLister;
        private System.Windows.Forms.CheckBox chkShowJobAsAlert;
        private System.Windows.Forms.CheckBox chkShowSpecReq;
        private System.Windows.Forms.CheckBox chkDisableAlarm;
        private System.Windows.Forms.CheckBox chkDisableNoPickup;
        private System.Windows.Forms.CheckBox chkDisableFareOnAccJob;
        private System.Windows.Forms.CheckBox chkDisableSTC;
        private Telerik.WinControls.UI.RadSpinEditor numInitialBalance;
        private Telerik.WinControls.UI.RadLabel radLabel42;
        private Telerik.WinControls.UI.RadPageViewPage pg_complaint;
        private Telerik.WinControls.UI.RadGridView grdDriverComplaints;
        private Telerik.WinControls.UI.RadSpinEditor numRentLimit;
        private Telerik.WinControls.UI.RadLabel radLabel43;
        private Telerik.WinControls.UI.RadLabel radLabel44;
        private Telerik.WinControls.UI.RadTextBox txtVehicleLogBookNo;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnView;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private Telerik.WinControls.UI.RadLabel radLabel45;
        private Telerik.WinControls.UI.RadTextBox txtLogBookDocPath;
        private Telerik.WinControls.UI.RadCheckBox chkBidding;
        private Telerik.WinControls.UI.RadSpinEditor numPDARent;
        private Telerik.WinControls.UI.RadLabel lblpdarent;

        private System.Windows.Forms.CheckBox chkEnablePriceBidding;
        private System.Windows.Forms.CheckBox chkEnableManualFares;
        private System.Windows.Forms.CheckBox chkEnableOptionalManualFares;
        private Telerik.WinControls.UI.RadPageViewPage pg_charges;
        private Telerik.WinControls.UI.RadGridView grdDebitCreditNotes;
        private Telerik.WinControls.UI.RadLabel radLabel46;
        private Telerik.WinControls.UI.RadTextBox txtSurName;
        private System.Windows.Forms.CheckBox chkVoiceOnClearMeter;
        private System.Windows.Forms.CheckBox chkDisableJobAuth;
        private Telerik.WinControls.UI.RadPageViewPage Pg_Attributes;
        private Telerik.WinControls.UI.RadGridView grdDriverAttributes;
        private UI.MyDropDownList ddlCategory;
        private Telerik.WinControls.UI.RadLabel radLabel47;
        private System.Windows.Forms.ComboBox ddlHidePickupAndDestinationType;
        private Telerik.WinControls.UI.RadSpinEditor numMaxCommission;
        private Telerik.WinControls.UI.RadLabel lblMaxCommission;
        private Telerik.WinControls.UI.RadMenuItem mnuDriverLog;
        private Telerik.WinControls.UI.RadSpinEditor numTrainingCompletedHours;
        private Telerik.WinControls.UI.RadSpinEditor numTrainingReqHours;
        private Telerik.WinControls.UI.RadLabel radLabel48;
        private Telerik.WinControls.UI.RadLabel radLabel49;
        private Telerik.WinControls.UI.RadPageViewPage CompanyVehicle;
        private Telerik.WinControls.UI.RadGridView grdCompanyVehicles;
        private Telerik.WinControls.UI.RadMenuItem DrirverRating;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtRating;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadPageViewPage Pg_Rating;
        private UI.MyGridView grdRating;
        private Telerik.WinControls.UI.RadPageViewPage pg_Shifts;
        private Telerik.WinControls.UI.RadGridView grdDriverShifts;
        private System.Windows.Forms.CheckBox chkEnableDriverConnect;
        private Telerik.WinControls.UI.RadSpinEditor numVAT;
        private Telerik.WinControls.UI.RadLabel radLabel50;
        private System.Windows.Forms.CheckBox chkShowDestAfterPOB;
        private Telerik.WinControls.UI.RadSpinEditor numMinComm;
        private Telerik.WinControls.UI.RadLabel radLabel51;
        private Telerik.WinControls.UI.RadTextBox txtAffiliateKey;
        private Telerik.WinControls.UI.RadLabel radLabel52;
        private Telerik.WinControls.UI.RadSpinEditor numAccComm;
        private Telerik.WinControls.UI.RadLabel lblAccComm;
        private Telerik.WinControls.UI.RadCheckBox chkAccComm;
        //   private ShaperRater.Rater RateDriver;



    }
}