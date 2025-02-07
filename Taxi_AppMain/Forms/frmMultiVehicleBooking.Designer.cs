using System.Windows.Forms;

namespace Taxi_AppMain
{
    partial class frmMultiVehicleBooking
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
            this.lblDespatchHeading = new System.Windows.Forms.Label();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnAddBooking = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.chkDestination = new Telerik.WinControls.UI.RadCheckBox();
            this.chkOrigin = new Telerik.WinControls.UI.RadCheckBox();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.numExtra = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.numParking = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblcompanyFares = new Telerik.WinControls.UI.RadLabel();
            this.numCompanyFares = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.numReturnFare = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnCalculateFare = new Telerik.WinControls.UI.RadButton();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.numFareRate = new Telerik.WinControls.UI.RadSpinEditor();
            this.ddlDriver = new UI.MyDropDownList();
            this.radLabel22 = new Telerik.WinControls.UI.RadLabel();
            this.txtFromAddress = new UI.AutoCompleteTextBox();
            this.ddlFromLocation = new UI.DJComboBox();
            this.ddlFromLocType = new System.Windows.Forms.ComboBox();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.lblFromLoc = new Telerik.WinControls.UI.RadLabel();
            this.lblFromDoorFlightNo = new Telerik.WinControls.UI.RadLabel();
            this.txtToAddress = new UI.AutoCompleteTextBox();
            this.lblFromStreetComing = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.txtFromFlightDoorNo = new Telerik.WinControls.UI.RadTextBox();
            this.txtToPostCode = new Telerik.WinControls.UI.RadTextBox();
            this.txtFromStreetComing = new Telerik.WinControls.UI.RadTextBox();
            this.txtToStreetComing = new Telerik.WinControls.UI.RadTextBox();
            this.txtFromPostCode = new Telerik.WinControls.UI.RadTextBox();
            this.txtToFlightDoorNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblToStreetComing = new Telerik.WinControls.UI.RadLabel();
            this.lblToLoc = new Telerik.WinControls.UI.RadLabel();
            this.ddlToLocType = new System.Windows.Forms.ComboBox();
            this.ddlToLocation = new UI.DJComboBox();
            this.lblToDoorFlightNo = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.ddlVehicleType = new System.Windows.Forms.ComboBox();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.grdBookings = new UI.MyGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.numTotalVehicles = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnMore = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanyFares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyFares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnFare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalculateFare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFareRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFromLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDoorFlightNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromStreetComing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromFlightDoorNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToPostCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromStreetComing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToStreetComing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromPostCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToFlightDoorNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToStreetComing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlToLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDoorFlightNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDespatchHeading
            // 
            this.lblDespatchHeading.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDespatchHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDespatchHeading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespatchHeading.ForeColor = System.Drawing.Color.Black;
            this.lblDespatchHeading.Location = new System.Drawing.Point(0, 0);
            this.lblDespatchHeading.Name = "lblDespatchHeading";
            this.lblDespatchHeading.Size = new System.Drawing.Size(818, 34);
            this.lblDespatchHeading.TabIndex = 1;
            this.lblDespatchHeading.Text = "Multi Vehicle";
            this.lblDespatchHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.Ivory;
            this.radPanel2.Controls.Add(this.btnClear);
            this.radPanel2.Controls.Add(this.btnAddBooking);
            this.radPanel2.Controls.Add(this.label1);
            this.radPanel2.Controls.Add(this.lblMap);
            this.radPanel2.Controls.Add(this.chkDestination);
            this.radPanel2.Controls.Add(this.chkOrigin);
            this.radPanel2.Controls.Add(this.radPanel3);
            this.radPanel2.Controls.Add(this.ddlDriver);
            this.radPanel2.Controls.Add(this.radLabel22);
            this.radPanel2.Controls.Add(this.txtFromAddress);
            this.radPanel2.Controls.Add(this.ddlFromLocation);
            this.radPanel2.Controls.Add(this.ddlFromLocType);
            this.radPanel2.Controls.Add(this.radLabel13);
            this.radPanel2.Controls.Add(this.lblFromLoc);
            this.radPanel2.Controls.Add(this.lblFromDoorFlightNo);
            this.radPanel2.Controls.Add(this.txtToAddress);
            this.radPanel2.Controls.Add(this.lblFromStreetComing);
            this.radPanel2.Controls.Add(this.radLabel9);
            this.radPanel2.Controls.Add(this.txtFromFlightDoorNo);
            this.radPanel2.Controls.Add(this.txtToPostCode);
            this.radPanel2.Controls.Add(this.txtFromStreetComing);
            this.radPanel2.Controls.Add(this.txtToStreetComing);
            this.radPanel2.Controls.Add(this.txtFromPostCode);
            this.radPanel2.Controls.Add(this.txtToFlightDoorNo);
            this.radPanel2.Controls.Add(this.lblToStreetComing);
            this.radPanel2.Controls.Add(this.lblToLoc);
            this.radPanel2.Controls.Add(this.ddlToLocType);
            this.radPanel2.Controls.Add(this.ddlToLocation);
            this.radPanel2.Controls.Add(this.lblToDoorFlightNo);
            this.radPanel2.Controls.Add(this.radLabel11);
            this.radPanel2.Controls.Add(this.ddlVehicleType);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 34);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(818, 285);
            this.radPanel2.TabIndex = 218;
            // 
            // btnClear
            // 
            this.btnClear.Image = global::Taxi_AppMain.Properties.Resources.delete;
            this.btnClear.Location = new System.Drawing.Point(708, 206);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 41);
            this.btnClear.TabIndex = 219;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.delete;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = "Clear";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAddBooking
            // 
            this.btnAddBooking.Image = global::Taxi_AppMain.Properties.Resources.add;
            this.btnAddBooking.Location = new System.Drawing.Point(582, 206);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(115, 41);
            this.btnAddBooking.TabIndex = 218;
            this.btnAddBooking.Text = "Add Booking";
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddBooking.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAddBooking.GetChildAt(0))).Text = "Add Booking";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnAddBooking.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(574, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 92);
            this.label1.TabIndex = 246;
            // 
            // lblMap
            // 
            this.lblMap.BackColor = System.Drawing.Color.Orange;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(373, 190);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(202, 92);
            this.lblMap.TabIndex = 245;
            // 
            // chkDestination
            // 
            this.chkDestination.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDestination.Location = new System.Drawing.Point(453, 13);
            this.chkDestination.Name = "chkDestination";
            this.chkDestination.Size = new System.Drawing.Size(132, 18);
            this.chkDestination.TabIndex = 244;
            this.chkDestination.Text = "Different destination";
            this.chkDestination.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkDestination_ToggleStateChanged);
            // 
            // chkOrigin
            // 
            this.chkOrigin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOrigin.Location = new System.Drawing.Point(298, 13);
            this.chkOrigin.Name = "chkOrigin";
            this.chkOrigin.Size = new System.Drawing.Size(138, 18);
            this.chkOrigin.TabIndex = 243;
            this.chkOrigin.Text = "Different Pickup Point";
            this.chkOrigin.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkOrigin_ToggleStateChanged);
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.Orange;
            this.radPanel3.Controls.Add(this.radLabel3);
            this.radPanel3.Controls.Add(this.numExtra);
            this.radPanel3.Controls.Add(this.radLabel2);
            this.radPanel3.Controls.Add(this.numParking);
            this.radPanel3.Controls.Add(this.lblcompanyFares);
            this.radPanel3.Controls.Add(this.numCompanyFares);
            this.radPanel3.Controls.Add(this.radLabel1);
            this.radPanel3.Controls.Add(this.numReturnFare);
            this.radPanel3.Controls.Add(this.btnCalculateFare);
            this.radPanel3.Controls.Add(this.radLabel5);
            this.radPanel3.Controls.Add(this.numFareRate);
            this.radPanel3.Location = new System.Drawing.Point(5, 190);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(369, 92);
            this.radPanel3.TabIndex = 242;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.radLabel3.ForeColor = System.Drawing.Color.Black;
            this.radLabel3.Location = new System.Drawing.Point(165, 65);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel3.Size = new System.Drawing.Size(125, 19);
            this.radLabel3.TabIndex = 225;
            this.radLabel3.Text = "Extra Charges  £";
            // 
            // numExtra
            // 
            this.numExtra.DecimalPlaces = 2;
            this.numExtra.EnableKeyMap = true;
            this.numExtra.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numExtra.ForeColor = System.Drawing.Color.Red;
            this.numExtra.InterceptArrowKeys = false;
            this.numExtra.Location = new System.Drawing.Point(296, 62);
            this.numExtra.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numExtra.Name = "numExtra";
            // 
            // 
            // 
            this.numExtra.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numExtra.RootElement.ForeColor = System.Drawing.Color.Red;
            this.numExtra.ShowBorder = true;
            this.numExtra.ShowUpDownButtons = false;
            this.numExtra.Size = new System.Drawing.Size(68, 24);
            this.numExtra.TabIndex = 224;
            this.numExtra.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numExtra.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numExtra.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numExtra.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numExtra.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Location = new System.Drawing.Point(165, 38);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Size = new System.Drawing.Size(132, 19);
            this.radLabel2.TabIndex = 223;
            this.radLabel2.Text = "Parking  £";
            // 
            // numParking
            // 
            this.numParking.DecimalPlaces = 2;
            this.numParking.EnableKeyMap = true;
            this.numParking.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numParking.ForeColor = System.Drawing.Color.Red;
            this.numParking.InterceptArrowKeys = false;
            this.numParking.Location = new System.Drawing.Point(296, 35);
            this.numParking.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numParking.Name = "numParking";
            // 
            // 
            // 
            this.numParking.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numParking.RootElement.ForeColor = System.Drawing.Color.Red;
            this.numParking.ShowBorder = true;
            this.numParking.ShowUpDownButtons = false;
            this.numParking.Size = new System.Drawing.Size(68, 24);
            this.numParking.TabIndex = 222;
            this.numParking.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numParking.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numParking.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numParking.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numParking.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblcompanyFares
            // 
            this.lblcompanyFares.AutoSize = false;
            this.lblcompanyFares.BackColor = System.Drawing.Color.Transparent;
            this.lblcompanyFares.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblcompanyFares.ForeColor = System.Drawing.Color.Black;
            this.lblcompanyFares.Location = new System.Drawing.Point(165, 6);
            this.lblcompanyFares.Name = "lblcompanyFares";
            // 
            // 
            // 
            this.lblcompanyFares.RootElement.ForeColor = System.Drawing.Color.Black;
            this.lblcompanyFares.Size = new System.Drawing.Size(132, 19);
            this.lblcompanyFares.TabIndex = 221;
            this.lblcompanyFares.Text = "Company Price  £";
            // 
            // numCompanyFares
            // 
            this.numCompanyFares.DecimalPlaces = 2;
            this.numCompanyFares.EnableKeyMap = true;
            this.numCompanyFares.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCompanyFares.ForeColor = System.Drawing.Color.Red;
            this.numCompanyFares.InterceptArrowKeys = false;
            this.numCompanyFares.Location = new System.Drawing.Point(296, 3);
            this.numCompanyFares.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCompanyFares.Name = "numCompanyFares";
            // 
            // 
            // 
            this.numCompanyFares.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numCompanyFares.RootElement.ForeColor = System.Drawing.Color.Red;
            this.numCompanyFares.ShowBorder = true;
            this.numCompanyFares.ShowUpDownButtons = false;
            this.numCompanyFares.Size = new System.Drawing.Size(68, 24);
            this.numCompanyFares.TabIndex = 220;
            this.numCompanyFares.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numCompanyFares.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numCompanyFares.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numCompanyFares.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numCompanyFares.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(3, 37);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Size = new System.Drawing.Size(93, 22);
            this.radLabel1.TabIndex = 218;
            this.radLabel1.Text = "R/Fares   £";
            // 
            // numReturnFare
            // 
            this.numReturnFare.DecimalPlaces = 2;
            this.numReturnFare.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numReturnFare.Location = new System.Drawing.Point(99, 35);
            this.numReturnFare.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numReturnFare.Name = "numReturnFare";
            // 
            // 
            // 
            this.numReturnFare.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numReturnFare.ShowBorder = true;
            this.numReturnFare.ShowUpDownButtons = false;
            this.numReturnFare.Size = new System.Drawing.Size(56, 24);
            this.numReturnFare.TabIndex = 219;
            this.numReturnFare.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numReturnFare.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numReturnFare.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numReturnFare.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numReturnFare.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnCalculateFare
            // 
            this.btnCalculateFare.Location = new System.Drawing.Point(9, 67);
            this.btnCalculateFare.Name = "btnCalculateFare";
            this.btnCalculateFare.Size = new System.Drawing.Size(139, 24);
            this.btnCalculateFare.TabIndex = 217;
            this.btnCalculateFare.Text = "Calculate";
            this.btnCalculateFare.Click += new System.EventHandler(this.btnCalculateFare_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCalculateFare.GetChildAt(0))).Text = "Calculate";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnCalculateFare.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnCalculateFare.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Location = new System.Drawing.Point(4, 6);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Size = new System.Drawing.Size(73, 22);
            this.radLabel5.TabIndex = 128;
            this.radLabel5.Text = "Fares   £";
            // 
            // numFareRate
            // 
            this.numFareRate.DecimalPlaces = 2;
            this.numFareRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFareRate.Location = new System.Drawing.Point(100, 4);
            this.numFareRate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numFareRate.Name = "numFareRate";
            // 
            // 
            // 
            this.numFareRate.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numFareRate.ShowBorder = true;
            this.numFareRate.ShowUpDownButtons = false;
            this.numFareRate.Size = new System.Drawing.Size(55, 24);
            this.numFareRate.TabIndex = 215;
            this.numFareRate.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numFareRate.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numFareRate.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numFareRate.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0.00";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numFareRate.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ddlDriver
            // 
            this.ddlDriver.Caption = null;
            this.ddlDriver.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDriver.Location = new System.Drawing.Point(405, 158);
            this.ddlDriver.Name = "ddlDriver";
            this.ddlDriver.Property = null;
            this.ddlDriver.ShowDownArrow = true;
            this.ddlDriver.Size = new System.Drawing.Size(208, 26);
            this.ddlDriver.TabIndex = 240;
            // 
            // radLabel22
            // 
            this.radLabel22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel22.Location = new System.Drawing.Point(297, 162);
            this.radLabel22.Name = "radLabel22";
            this.radLabel22.Size = new System.Drawing.Size(42, 19);
            this.radLabel22.TabIndex = 241;
            this.radLabel22.Text = "Driver";
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.BackColor = System.Drawing.Color.White;
            this.txtFromAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFromAddress.DefaultHeight = 150;
            this.txtFromAddress.DefaultWidth = 320;
            this.txtFromAddress.Enabled = false;
            this.txtFromAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromAddress.ForceListBoxToUpdate = false;
            this.txtFromAddress.FormerValue = "";
            this.txtFromAddress.Location = new System.Drawing.Point(404, 42);
            this.txtFromAddress.Multiline = true;
            this.txtFromAddress.Name = "txtFromAddress";
            // 
            // 
            // 
            this.txtFromAddress.RootElement.StretchVertically = true;
            this.txtFromAddress.SelectedItem = null;
            this.txtFromAddress.Size = new System.Drawing.Size(301, 47);
            this.txtFromAddress.TabIndex = 223;
            this.txtFromAddress.TabStop = false;
            this.txtFromAddress.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtFromAddress.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtFromAddress.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // ddlFromLocation
            // 
            this.ddlFromLocation.BackColor = System.Drawing.Color.White;
            this.ddlFromLocation.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFromLocation.Location = new System.Drawing.Point(405, 42);
            this.ddlFromLocation.Name = "ddlFromLocation";
            this.ddlFromLocation.NewValue = null;
            this.ddlFromLocation.OldValue = null;
            // 
            // 
            // 
            this.ddlFromLocation.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.ddlFromLocation.ShowDropDownArrow = Telerik.WinControls.ElementVisibility.Visible;
            this.ddlFromLocation.Size = new System.Drawing.Size(206, 23);
            this.ddlFromLocation.TabIndex = 220;
            this.ddlFromLocation.TabStop = false;
            // 
            // ddlFromLocType
            // 
            this.ddlFromLocType.Enabled = false;
            this.ddlFromLocType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFromLocType.Location = new System.Drawing.Point(114, 43);
            this.ddlFromLocType.Name = "ddlFromLocType";
            this.ddlFromLocType.Size = new System.Drawing.Size(113, 24);
            this.ddlFromLocType.TabIndex = 221;
            // 
            // radLabel13
            // 
            this.radLabel13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel13.Location = new System.Drawing.Point(5, 47);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(65, 18);
            this.radLabel13.TabIndex = 226;
            this.radLabel13.Text = "From Type";
            // 
            // lblFromLoc
            // 
            this.lblFromLoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromLoc.Location = new System.Drawing.Point(296, 44);
            this.lblFromLoc.Name = "lblFromLoc";
            this.lblFromLoc.Size = new System.Drawing.Size(95, 18);
            this.lblFromLoc.TabIndex = 227;
            this.lblFromLoc.Text = "From Location";
            // 
            // lblFromDoorFlightNo
            // 
            this.lblFromDoorFlightNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDoorFlightNo.Location = new System.Drawing.Point(5, 70);
            this.lblFromDoorFlightNo.Name = "lblFromDoorFlightNo";
            this.lblFromDoorFlightNo.Size = new System.Drawing.Size(83, 18);
            this.lblFromDoorFlightNo.TabIndex = 228;
            this.lblFromDoorFlightNo.Text = "From Door No";
            // 
            // txtToAddress
            // 
            this.txtToAddress.BackColor = System.Drawing.Color.White;
            this.txtToAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToAddress.DefaultHeight = 90;
            this.txtToAddress.DefaultWidth = 320;
            this.txtToAddress.Enabled = false;
            this.txtToAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToAddress.ForceListBoxToUpdate = false;
            this.txtToAddress.FormerValue = "";
            this.txtToAddress.Location = new System.Drawing.Point(404, 105);
            this.txtToAddress.Multiline = true;
            this.txtToAddress.Name = "txtToAddress";
            // 
            // 
            // 
            this.txtToAddress.RootElement.StretchVertically = true;
            this.txtToAddress.SelectedItem = null;
            this.txtToAddress.Size = new System.Drawing.Size(301, 47);
            this.txtToAddress.TabIndex = 232;
            this.txtToAddress.TabStop = false;
            this.txtToAddress.Values = null;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txtToAddress.GetChildAt(0))).StretchVertically = true;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToAddress.GetChildAt(0).GetChildAt(2))).ForeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToAddress.GetChildAt(0).GetChildAt(2))).ForeColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToAddress.GetChildAt(0).GetChildAt(2))).ForeColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToAddress.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            // 
            // lblFromStreetComing
            // 
            this.lblFromStreetComing.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromStreetComing.Location = new System.Drawing.Point(296, 69);
            this.lblFromStreetComing.Name = "lblFromStreetComing";
            this.lblFromStreetComing.Size = new System.Drawing.Size(71, 18);
            this.lblFromStreetComing.TabIndex = 229;
            this.lblFromStreetComing.Text = "From Street";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(5, 109);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(51, 18);
            this.radLabel9.TabIndex = 236;
            this.radLabel9.Text = "To Type";
            // 
            // txtFromFlightDoorNo
            // 
            this.txtFromFlightDoorNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromFlightDoorNo.Location = new System.Drawing.Point(114, 69);
            this.txtFromFlightDoorNo.MaxLength = 30;
            this.txtFromFlightDoorNo.Name = "txtFromFlightDoorNo";
            this.txtFromFlightDoorNo.Size = new System.Drawing.Size(113, 21);
            this.txtFromFlightDoorNo.TabIndex = 224;
            this.txtFromFlightDoorNo.TabStop = false;
            // 
            // txtToPostCode
            // 
            this.txtToPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToPostCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToPostCode.Location = new System.Drawing.Point(405, 106);
            this.txtToPostCode.MaxLength = 100;
            this.txtToPostCode.Name = "txtToPostCode";
            this.txtToPostCode.Size = new System.Drawing.Size(223, 21);
            this.txtToPostCode.TabIndex = 230;
            this.txtToPostCode.TabStop = false;
            // 
            // txtFromStreetComing
            // 
            this.txtFromStreetComing.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromStreetComing.Location = new System.Drawing.Point(405, 69);
            this.txtFromStreetComing.MaxLength = 100;
            this.txtFromStreetComing.Name = "txtFromStreetComing";
            this.txtFromStreetComing.Size = new System.Drawing.Size(223, 21);
            this.txtFromStreetComing.TabIndex = 225;
            this.txtFromStreetComing.TabStop = false;
            // 
            // txtToStreetComing
            // 
            this.txtToStreetComing.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToStreetComing.Location = new System.Drawing.Point(404, 132);
            this.txtToStreetComing.MaxLength = 100;
            this.txtToStreetComing.Name = "txtToStreetComing";
            this.txtToStreetComing.Size = new System.Drawing.Size(224, 21);
            this.txtToStreetComing.TabIndex = 235;
            this.txtToStreetComing.TabStop = false;
            // 
            // txtFromPostCode
            // 
            this.txtFromPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFromPostCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromPostCode.Location = new System.Drawing.Point(404, 44);
            this.txtFromPostCode.MaxLength = 100;
            this.txtFromPostCode.Name = "txtFromPostCode";
            this.txtFromPostCode.Size = new System.Drawing.Size(224, 21);
            this.txtFromPostCode.TabIndex = 222;
            this.txtFromPostCode.TabStop = false;
            // 
            // txtToFlightDoorNo
            // 
            this.txtToFlightDoorNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToFlightDoorNo.Location = new System.Drawing.Point(114, 132);
            this.txtToFlightDoorNo.MaxLength = 30;
            this.txtToFlightDoorNo.Name = "txtToFlightDoorNo";
            this.txtToFlightDoorNo.Size = new System.Drawing.Size(113, 21);
            this.txtToFlightDoorNo.TabIndex = 234;
            this.txtToFlightDoorNo.TabStop = false;
            // 
            // lblToStreetComing
            // 
            this.lblToStreetComing.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToStreetComing.Location = new System.Drawing.Point(295, 132);
            this.lblToStreetComing.Name = "lblToStreetComing";
            this.lblToStreetComing.Size = new System.Drawing.Size(57, 18);
            this.lblToStreetComing.TabIndex = 239;
            this.lblToStreetComing.Text = "To Street";
            // 
            // lblToLoc
            // 
            this.lblToLoc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToLoc.Location = new System.Drawing.Point(295, 107);
            this.lblToLoc.Name = "lblToLoc";
            this.lblToLoc.Size = new System.Drawing.Size(78, 18);
            this.lblToLoc.TabIndex = 237;
            this.lblToLoc.Text = "To Location";
            // 
            // ddlToLocType
            // 
            this.ddlToLocType.Enabled = false;
            this.ddlToLocType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlToLocType.Location = new System.Drawing.Point(114, 105);
            this.ddlToLocType.Name = "ddlToLocType";
            this.ddlToLocType.Size = new System.Drawing.Size(113, 24);
            this.ddlToLocType.TabIndex = 231;
            // 
            // ddlToLocation
            // 
            this.ddlToLocation.BackColor = System.Drawing.Color.White;
            this.ddlToLocation.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlToLocation.Location = new System.Drawing.Point(404, 107);
            this.ddlToLocation.Name = "ddlToLocation";
            this.ddlToLocation.NewValue = null;
            this.ddlToLocation.OldValue = null;
            // 
            // 
            // 
            this.ddlToLocation.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.ddlToLocation.ShowDropDownArrow = Telerik.WinControls.ElementVisibility.Visible;
            this.ddlToLocation.Size = new System.Drawing.Size(206, 23);
            this.ddlToLocation.TabIndex = 233;
            this.ddlToLocation.TabStop = false;
            // 
            // lblToDoorFlightNo
            // 
            this.lblToDoorFlightNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDoorFlightNo.Location = new System.Drawing.Point(5, 133);
            this.lblToDoorFlightNo.Name = "lblToDoorFlightNo";
            this.lblToDoorFlightNo.Size = new System.Drawing.Size(69, 18);
            this.lblToDoorFlightNo.TabIndex = 238;
            this.lblToDoorFlightNo.Text = "To Door No";
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.Location = new System.Drawing.Point(5, 13);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(92, 19);
            this.radLabel11.TabIndex = 124;
            this.radLabel11.Text = "Vehicle Type";
            // 
            // ddlVehicleType
            // 
            this.ddlVehicleType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlVehicleType.Location = new System.Drawing.Point(114, 11);
            this.ddlVehicleType.Name = "ddlVehicleType";
            this.ddlVehicleType.Size = new System.Drawing.Size(113, 24);
            this.ddlVehicleType.TabIndex = 123;
            // 
            // radPanel4
            // 
            this.radPanel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.radPanel4.Controls.Add(this.btnExit);
            this.radPanel4.Controls.Add(this.btnSave);
            this.radPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel4.Location = new System.Drawing.Point(0, 72);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(818, 47);
            this.radPanel4.TabIndex = 226;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Taxi_AppMain.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(705, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 37);
            this.btnExit.TabIndex = 221;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.exit;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnExit.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            this.btnSave.Location = new System.Drawing.Point(567, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 37);
            this.btnSave.TabIndex = 220;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::Taxi_AppMain.Properties.Resources.Tick3;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // grdBookings
            // 
            this.grdBookings.AutoCellFormatting = true;
            this.grdBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBookings.EnableCheckInCheckOut = false;
            this.grdBookings.EnableHotTracking = false;
            this.grdBookings.HeaderRowBackColor = System.Drawing.Color.SteelBlue;
            this.grdBookings.HeaderRowBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.grdBookings.Location = new System.Drawing.Point(0, 319);
            this.grdBookings.Name = "grdBookings";
            this.grdBookings.PKFieldColumnName = "";
            this.grdBookings.ShowImageOnActionButton = true;
            this.grdBookings.Size = new System.Drawing.Size(818, 0);
            this.grdBookings.TabIndex = 227;
            this.grdBookings.Text = "myGridView1";
            this.grdBookings.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdBookings_CellDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(246, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(220, 27);
            this.radLabel4.TabIndex = 228;
            this.radLabel4.Text = "Enter No of Vehicles :";
            // 
            // numTotalVehicles
            // 
            this.numTotalVehicles.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalVehicles.Location = new System.Drawing.Point(473, 2);
            this.numTotalVehicles.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTotalVehicles.Name = "numTotalVehicles";
            // 
            // 
            // 
            this.numTotalVehicles.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.numTotalVehicles.ShowBorder = true;
            this.numTotalVehicles.ShowUpDownButtons = false;
            this.numTotalVehicles.Size = new System.Drawing.Size(55, 28);
            this.numTotalVehicles.TabIndex = 229;
            this.numTotalVehicles.TabStop = false;
            ((Telerik.WinControls.UI.RadSpinElement)(this.numTotalVehicles.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.numTotalVehicles.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numTotalVehicles.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "0";
            //((Telerik.WinControls.UI.RadTextBoxItem)(this.numTotalVehicles.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 14F);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(680, -1);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(138, 34);
            this.btnMore.TabIndex = 230;
            this.btnMore.Text = "More Options (+)";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMore.GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnMore.GetChildAt(0))).Text = "More Options (+)";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMore.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnMore.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmMultiVehicleBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(818, 119);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.numTotalVehicles);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.grdBookings);
            this.Controls.Add(this.radPanel4);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.lblDespatchHeading);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMultiVehicleBooking";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Vehicle";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numParking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanyFares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompanyFares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnFare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalculateFare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFareRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFromLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDoorFlightNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromStreetComing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromFlightDoorNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToPostCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromStreetComing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToStreetComing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromPostCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToFlightDoorNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToStreetComing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlToLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDoorFlightNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    

        #endregion

        private System.Windows.Forms.Label lblDespatchHeading;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private ComboBox ddlVehicleType;
        private Telerik.WinControls.UI.RadButton btnAddBooking;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private UI.MyGridView grdBookings;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnClear;
        private UI.AutoCompleteTextBox txtFromAddress;
        private UI.DJComboBox ddlFromLocation;
        private ComboBox ddlFromLocType;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel lblFromLoc;
        private Telerik.WinControls.UI.RadLabel lblFromDoorFlightNo;
        private UI.AutoCompleteTextBox txtToAddress;
        private Telerik.WinControls.UI.RadLabel lblFromStreetComing;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadTextBox txtFromFlightDoorNo;
        private Telerik.WinControls.UI.RadTextBox txtToPostCode;
        private Telerik.WinControls.UI.RadTextBox txtFromStreetComing;
        private Telerik.WinControls.UI.RadTextBox txtToStreetComing;
        private Telerik.WinControls.UI.RadTextBox txtFromPostCode;
        private Telerik.WinControls.UI.RadTextBox txtToFlightDoorNo;
        private Telerik.WinControls.UI.RadLabel lblToStreetComing;
        private Telerik.WinControls.UI.RadLabel lblToLoc;
        private ComboBox ddlToLocType;
        private UI.DJComboBox ddlToLocation;
        private Telerik.WinControls.UI.RadLabel lblToDoorFlightNo;
        private UI.MyDropDownList ddlDriver;
        private Telerik.WinControls.UI.RadLabel radLabel22;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSpinEditor numFareRate;
        private Telerik.WinControls.UI.RadCheckBox chkDestination;
        private Telerik.WinControls.UI.RadCheckBox chkOrigin;
        private Telerik.WinControls.UI.RadButton btnCalculateFare;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor numReturnFare;
        private Telerik.WinControls.UI.RadLabel lblcompanyFares;
        private Telerik.WinControls.UI.RadSpinEditor numCompanyFares;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor numExtra;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor numParking;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadSpinEditor numTotalVehicles;
        private Telerik.WinControls.UI.RadButton btnMore;
    }
}