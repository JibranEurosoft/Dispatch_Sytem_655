using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Utils;
using Telerik.WinControls;
using Taxi_Model;
using Taxi_BLL;
using System.Net;
using UI;

namespace Taxi_AppMain
{
    public partial class frmMultiVehicleBooking : Form
    {
        public decimal ReturnBookingFee = 0;

        public bool CustomLead = false;
        public int AdvbookingTypeId = 1;
        private decimal _ReturnCustomerFares;

        public decimal ReturnCustomerFares
        {
            get { return _ReturnCustomerFares; }
            set { _ReturnCustomerFares = value; }
        }

        public int ReturnPriority = 0;

        private string _ReturnSpecialReq;

        public string ReturnSpecialReq
        {
            get { return _ReturnSpecialReq; }
            set { _ReturnSpecialReq = value; }
        }


        private int? _ReturnVehicleTypeId;

        public int? ReturnVehicleTypeId
        {
            get { return _ReturnVehicleTypeId; }
            set { _ReturnVehicleTypeId = value; }
        }


        private Booking _objBooking;

        public Booking ObjBooking
        {
            get { return _objBooking; }
            set { _objBooking = value; }
        }

        public struct COLS
        {
            public static string SNO = "SNO";
            public static string VEHICLETYPEID = "VEHICLETYPEID";
            public static string VEHICLETYPENAME = "VEHICLETYPENAME";

            public static string DistanceMiles = "DistanceMiles";

            public static string FromLocTypeId = "FromLocTypeId";
            public static string FromLocId = "FromLocId";
            public static string FromAddress = "From";
            public static string ToLocTypeId = "ToLocTypeId";
            public static string ToLocId = "ToLocId";
            public static string ToAddress = "To";


            public static string FromPostCode = "FromPostCode";
            public static string FromDoor = "FromDoor";
            public static string FromStreet = "FromStreet";

            public static string ToPostCode = "ToPostCode";
            public static string ToDoor = "ToDoor";
            public static string ToStreet = "ToStreet";



            public static string Fare = "Fare";
            public static string RetFare = "RetFare";
            public static string CompanyPrice = "CompanyPrice";

            public static string DRIVERID = "DRIVERID";
            public static string DRIVERNAME = "DRIVERNAME";        

          
        }


        public frmMultiVehicleBooking(Booking obj)
        {
            InitializeComponent();
            FormatGrid();
      
            grdBookings.CommandCellClick += new CommandCellClickEventHandler(grid_CommandCellClick);
            grdBookings.RowsChanged += new GridViewCollectionChangedEventHandler(grdBookings_RowsChanged);
            this.ObjBooking = obj;


            Program.FillCombos();

            ComboFunctions.FillCombo(Program.dtCombos.Tables[0].Copy(), ddlFromLocType, "LocationType", "Id");
            ComboFunctions.FillCombo(Program.dtCombos.Tables[0].Copy(), ddlToLocType, "LocationType", "Id");



            ComboFunctions.FillCombo(Program.dtCombos.Tables[4].Copy(), ddlVehicleType, "VehicleType", "Id", false);

            ddlVehicleType.SelectedValue = obj.VehicleTypeId;

           


            if (obj.DriverId.ToInt() > 0)
            {
                ComboFunctions.FillDriverNoQueueCombo(ddlDriver);


                ddlDriver.SelectedValue = obj.DriverId;
            }
            else
            {
                ddlDriver.Enter += DdlDriver_Enter;
            }


            numFareRate.Value = obj.FareRate.ToDecimal();
            numParking.Value = obj.CongtionCharges.ToDecimal();
            numExtra.Value = obj.ExtraDropCharges.ToDecimal();

            numReturnFare.Value = obj.ReturnFareRate.ToDecimal();
            numCompanyFares.Value = obj.CompanyPrice.ToDecimal();

            SetLocation(obj.FromLocTypeId, obj.FromDoorNo, obj.FromAddress, obj.FromStreet, obj.FromPostCode, obj.FromLocId,
                         obj.ToLocTypeId, obj.ToDoorNo, obj.ToAddress, obj.ToStreet, obj.ToPostCode, obj.ToLocId);


    //        this.txtFromAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
     //       this.txtToAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);

            lblMap.Text = obj.DistanceString.ToStr();

           
           
            timer1.Tick+=new EventHandler(timer1_Tick);

           



            //if (AppVars.objPolicyConfiguration != null)
            //{

            //    MapType = AppVars.objPolicyConfiguration.MapType.ToInt();

            //}

            this.FormClosing += new FormClosingEventHandler(frmMultiVehicleBooking_FormClosing);


            txtFromAddress.ListBoxElement.Width = txtFromAddress.DefaultWidth;
            txtToAddress.ListBoxElement.Width = txtToAddress.DefaultWidth;
            EnablePOI = AppVars.objPolicyConfiguration.EnablePOI.ToBool();
            txtFromAddress.KeyPress += new KeyPressEventHandler(txtAddress_KeyPress);
            txtToAddress.KeyPress += new KeyPressEventHandler(txtAddress_KeyPress);

            this.Load += FrmMultiVehicleBooking_Load;
            ddlVehicleType.SelectedValueChanged += DdlVehicleType_SelectedValueChanged;
            this.KeyDown += FrmMultiVehicleBooking_KeyDown;

            this.Shown += FrmMultiVehicleBooking_Shown;
       
        }

        private void FrmMultiVehicleBooking_Shown(object sender, EventArgs e)
        {
            //DefaultAdvancedView(System.Diagnostics.Debugger.IsAttached || AppVars.listUserRights.Count(c => c.functionId == "ADVANCED MULTI-VEHICLE") > 0);
            DefaultAdvancedView(true);

        }

        private void DdlDriver_Enter(object sender, EventArgs e)
        {
            if (ddlDriver.DataSource == null)
                ComboFunctions.FillDriverNoQueueCombo(ddlDriver);
        }

        private bool? ReleaseMode = null;

        private void FrmMultiVehicleBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Home)
            {
                ReleaseMode = false;

                if (AddNoofVehicles())
                {
                    Saved = Save();

                    this.Close();
                }
                else
                {

                    if(grdBookings.Rows.Count>0)
                    {
                        Saved = Save();

                        if(Saved)
                        this.Close();
                    }

                }
            }
            else if(e.KeyCode== Keys.End)
            {
                ReleaseMode = true;
                if (AddNoofVehicles())
                {
                    Saved = Save();

                    this.Close();
                }
                else
                {
                    if (grdBookings.Rows.Count > 0)
                    {
                        Saved = Save();

                        if (Saved)
                            this.Close();
                    }
                }
            }
            else if(e.KeyCode== Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Add)
            {
                DefaultAdvancedView(false);
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                DefaultAdvancedView(true);
            }
        }


        private bool AddNoofVehicles()
        {
            if (numTotalVehicles.SpinElement.Text.Length == 0 || numTotalVehicles.SpinElement.Text=="0")
                return false;

            grdBookings.Rows.Clear();

            grdBookings.RowCount = numTotalVehicles.SpinElement.Text.ToInt();



            for (int i=0; i< numTotalVehicles.SpinElement.Text.ToInt(); i++)
                AddDefaultBookings(grdBookings.Rows[i]);

            return true;
        }

        private void DdlVehicleType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddlVehicleType.Tag == null)
            {
                fares = null;
                CalculateFares();
            }
        }

        private void DefaultAdvancedView(bool hide)
        {
            if(hide)
            {

                this.Size = new Size(834, 158);
                btnMore.Text = "More Options (+)";


                chkOrigin.Visible = false;
                chkDestination.Visible = false;
                ddlVehicleType.Enabled = false;
                numTotalVehicles.Enabled = true;
                numTotalVehicles.Focus();
                numTotalVehicles.SpinElement.TextBoxItem.Select(0, numTotalVehicles.SpinElement.Text.ToStr().Length);
                btnSave.Visible = false;
            }
            else
            {
                this.Size = new Size(834, 603);
                btnMore.Text = "Less Options (-)";


                chkOrigin.Visible = true;
                chkDestination.Visible = true;
                ddlVehicleType.Enabled = true;
                ddlVehicleType.Focus();
                numTotalVehicles.Value = 0;
                numTotalVehicles.Enabled = false;
                btnSave.Visible = true;

            }

            if (ddlVehicleType.SelectedValue.ToInt() != ObjBooking.VehicleTypeId.ToInt())
                SetDefaultVehicle(AppVars.objPolicyConfiguration.DefaultVehicleTypeId);

        }

        private void FrmMultiVehicleBooking_Load(object sender, EventArgs e)
        {
            

                
            


            if (AppVars.listUserRights.Count(c => c.functionId == "HIDE ACCOUNT FARES") > 0)
            {
                lblcompanyFares.Visible = false;
                numCompanyFares.Visible = false;
            
                grdBookings.Columns[COLS.CompanyPrice].IsVisible = false;

                grdBookings.Columns[COLS.CompanyPrice].VisibleInColumnChooser = false;

            }
        }

        void frmMultiVehicleBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (timer1 != null)
                {
                    timer1.Stop();
                    timer1.Dispose();
                    timer1 = null;

                    if (POIWorker != null)
                    {
                        if (POIWorker.IsBusy)
                        {

                            POIWorker.CancelAsync();
                        }


                        POIWorker.Dispose();
                        POIWorker = null;
                        GC.Collect();

                    }
                }
            }
            catch
            {


            }
        }


        private void SetLocation(int? fromLocTypeId, string fromDoorNo, string fromAddress, string fromStreet, string fromPostCode, int? fromLocId,
                                int? toLocTypeId, string ToDoorNo, string ToAddress, string ToStreet, string ToPostCode, int? ToLocId)
        {

            try
            {
                ddlFromLocType.SelectedValue = fromLocTypeId;
                ddlToLocType.SelectedValue = toLocTypeId;

                //if (fromLocTypeId == Enums.LOCATION_TYPES.BASE || fromLocTypeId == Enums.LOCATION_TYPES.ADDRESS)
                //{
                txtFromAddress.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtFromAddress.Text = fromAddress;
                txtFromFlightDoorNo.Text = fromDoorNo;
                txtFromAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                //}
                //else if (fromLocTypeId == Enums.LOCATION_TYPES.POSTCODE)
                //{
                //    txtFromPostCode.Text = fromPostCode;
                //    txtFromStreetComing.Text = fromStreet;
                //    txtFromFlightDoorNo.Text = fromDoorNo;
                //}
                //else if (fromLocTypeId == Enums.LOCATION_TYPES.AIRPORT)
                //{
                //    ddlFromLocation.SelectedValue = fromLocId;
                //    txtFromStreetComing.Text = fromStreet;
                //    txtFromFlightDoorNo.Text = fromDoorNo;
                //}
                //else
                //{
                //    ddlFromLocation.SelectedValue = fromLocId;

                //}


                // To

                //if (toLocTypeId == Enums.LOCATION_TYPES.BASE || toLocTypeId == Enums.LOCATION_TYPES.ADDRESS)
                //{
                txtToAddress.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                txtToAddress.Text = ToAddress;

                txtToFlightDoorNo.Text = ToDoorNo;

                txtToAddress.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                //}
                //else if (toLocTypeId == Enums.LOCATION_TYPES.POSTCODE)
                //{
                //    txtToPostCode.Text = ToPostCode;
                //    txtToStreetComing.Text = ToStreet;
                //    txtToFlightDoorNo.Text = ToDoorNo;
                //}
                //else if (toLocTypeId == Enums.LOCATION_TYPES.AIRPORT)
                //{
                //    ddlToLocation.SelectedValue = ToLocId;
                //    //txtFromStreetComing.Text = fromStreet;
                //    //txtFromFlightDoorNo.Text = fromDoorNo;
                //}
                //else
                //{
                //    ddlToLocation.SelectedValue = ToLocId;

                //}

            }
            catch
            {

            }

        }

        void grdBookings_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {
                ReBindSerials();


            }
        }

        private void ReBindSerials()
        {
            int sno=1;
            foreach (GridViewRowInfo row in grdBookings.Rows)
            {
                row.Cells[COLS.SNO].Value = sno++;
                
            }


        }


        private void grid_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            RadGridView grid = gridCell.GridControl;
            if (gridCell.ColumnInfo.Name == "btnDelete")
            {

                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    grid.CurrentRow.Delete();
                }
            }
          
        }

        private void FillFromLocations()
        {
            int locTypeId = ddlFromLocType.SelectedValue.ToInt();
            //if (locTypeId == Enums.LOCATION_TYPES.ADDRESS || locTypeId==Enums.LOCATION_TYPES.BASE)
            //{
                txtFromAddress.Visible = true;

                ddlFromLocation.SelectedValue = null;
                ddlFromLocation.Visible = false;

                txtFromPostCode.Text = string.Empty;
                txtFromPostCode.Visible = false;

                txtFromFlightDoorNo.Text = string.Empty;
                txtFromFlightDoorNo.Visible = false;

                txtFromStreetComing.Text = string.Empty;
                txtFromStreetComing.Visible = false;

                lblFromDoorFlightNo.Visible = false;
                lblFromStreetComing.Visible = false;

                lblFromLoc.Text = "Pickup Point";
            //}
            //else if (locTypeId == Enums.LOCATION_TYPES.POSTCODE)
            //{
            //    txtFromAddress.Text = string.Empty;
            //    txtFromAddress.Visible = false;

            //    ddlFromLocation.SelectedValue = null;
            //    ddlFromLocation.Visible = false;

            //    txtFromPostCode.Visible = true;
            //    txtFromFlightDoorNo.Visible = true;
            //    txtFromStreetComing.Visible = true;
            //    lblFromDoorFlightNo.Visible = true;
            //    lblFromStreetComing.Visible = true;

            //    lblFromLoc.Text = "From PostCode";

            //    lblFromDoorFlightNo.Text = "From Door No";
            //    lblFromStreetComing.Text = "From Street";

            //}

            //else if (locTypeId == Enums.LOCATION_TYPES.AIRPORT)
            //{
            //    txtFromAddress.Text = string.Empty;
            //    txtFromAddress.Visible = false;

            //    ddlFromLocation.Visible = true;

            //    txtFromPostCode.Text = string.Empty;
            //    txtFromPostCode.Visible = false;

            //    txtFromFlightDoorNo.Visible = true;
            //    txtFromStreetComing.Visible = true;
            //    lblFromDoorFlightNo.Visible = true;
            //    lblFromStreetComing.Visible = true;

            //    lblFromLoc.Text = "From Location";


            //    lblFromDoorFlightNo.Text = "Flight No";
            //    lblFromStreetComing.Text = "Coming From";
            //    ComboFunctions.FillLocationsCombo(ddlFromLocation, c => c.LocationTypeId == locTypeId);

            //}

            //else
            //{
            //    lblFromLoc.Text = "From Location";

            //    txtFromPostCode.Text = string.Empty;
            //    txtFromPostCode.Visible = false;

            //    txtFromFlightDoorNo.Text = string.Empty;
            //    txtFromFlightDoorNo.Visible = false;

            //    txtFromStreetComing.Text = string.Empty;
            //    txtFromStreetComing.Visible = false;


            //    lblFromDoorFlightNo.Visible = false;
            //    lblFromStreetComing.Visible = false;

            //    txtFromAddress.Text = string.Empty;
            //    txtFromAddress.Visible = false;

            //    ddlFromLocation.Visible = true;
            //    ComboFunctions.FillLocationsCombo(ddlFromLocation, c => c.LocationTypeId == locTypeId);
            //}
        }

        private void FillToLocations()
        {


            int locTypeId = ddlToLocType.SelectedValue.ToInt();

            //if (locTypeId == Enums.LOCATION_TYPES.ADDRESS || locTypeId==Enums.LOCATION_TYPES.BASE)
            //{
                lblToLoc.Text = "Destination";
                txtToAddress.Visible = true;

                ddlToLocation.SelectedValue = null;
                ddlToLocation.Visible = false;

                txtToPostCode.Text = string.Empty;
                txtToPostCode.Visible = false;

                txtToFlightDoorNo.Text = string.Empty;
                txtToFlightDoorNo.Visible = false;

                txtToStreetComing.Text = string.Empty;
                txtToStreetComing.Visible = false;


                lblToDoorFlightNo.Visible = false;
                lblToStreetComing.Visible = false;
            //}
            //else if (locTypeId == Enums.LOCATION_TYPES.POSTCODE)
            //{
            //    txtToAddress.Text = string.Empty;
            //    txtToAddress.Visible = false;

            //    ddlToLocation.SelectedValue = null;
            //    ddlToLocation.Visible = false;

            //    txtToPostCode.Visible = true;
            //    txtToFlightDoorNo.Visible = true;
            //    txtToStreetComing.Visible = true;
            //    lblToDoorFlightNo.Visible = true;
            //    lblToStreetComing.Visible = true;

            //    lblToLoc.Text = "To PostCode";

            //    lblToDoorFlightNo.Text = "To Door No";
            //    lblToStreetComing.Text = "To Street";

            //}


            //else
            //{
            //    txtToPostCode.Text = string.Empty;
            //    txtToPostCode.Visible = false;

            //    txtToFlightDoorNo.Text = string.Empty;
            //    txtToFlightDoorNo.Visible = false;

            //    txtToStreetComing.Text = string.Empty;
            //    txtToStreetComing.Visible = false;

            //    lblToDoorFlightNo.Visible = false;
            //    lblToStreetComing.Visible = false;

            //    txtToAddress.Text = string.Empty;
            //    txtToAddress.Visible = false;


            //    ddlToLocation.Visible = true;
            //    lblToLoc.Text = "To Location";
            //    ComboFunctions.FillLocationsCombo(ddlToLocation, c => c.LocationTypeId == locTypeId);

            //}
        }

 

        private void FormatGrid()
        {

            grdBookings.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdBookings.AllowAddNewRow = false;
            grdBookings.ShowGroupPanel = false;
            grdBookings.ShowRowHeaderColumn = false;
            grdBookings.AllowEditRow = false;
            grdBookings.EnableHotTracking = false;

            GridViewTextBoxColumn col = new GridViewTextBoxColumn();
            col.HeaderText = "Sno";
            col.Name = COLS.SNO;
            col.Width = 50;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;      
            col.Name = COLS.VEHICLETYPEID;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.DRIVERID;
            grdBookings.Columns.Add(col);



            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.DistanceMiles;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Vehicle Type";
            col.Width = 170;
            col.Name = COLS.VEHICLETYPENAME;
            grdBookings.Columns.Add(col);




            // Locations


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.FromPostCode;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.FromDoor;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.FromStreet;
            grdBookings.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.FromLocTypeId;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.FromLocId;
            grdBookings.Columns.Add(col);



            // To

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.ToPostCode;
            grdBookings.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.ToDoor;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.ToStreet;
            grdBookings.Columns.Add(col);
      

            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.ToLocTypeId;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.IsVisible = false;
            col.Name = COLS.ToLocId;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Pickup Point"; ;
            col.Name = COLS.FromAddress;
            col.Width = 210;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Destination";
            col.Name = COLS.ToAddress;
            col.Width = 210;
            grdBookings.Columns.Add(col);



            //


            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.Fare;
            col.Name = COLS.Fare;
            col.Width = 110;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Parking";
            col.Name = "Parking";
            col.Width = 110;
            col.IsVisible = false;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = "Extra";
            col.Name = "Extra";
            col.Width = 110;
            col.IsVisible = false;
            grdBookings.Columns.Add(col);


            col = new GridViewTextBoxColumn();
            col.HeaderText = COLS.RetFare;
            col.Name = COLS.RetFare;
            col.IsVisible = false;
            grdBookings.Columns.Add(col);

            col = new GridViewTextBoxColumn();
            col.HeaderText = "C. Price";
            col.Name = COLS.CompanyPrice;
            col.Width = 110;
            col.IsVisible = true;
            grdBookings.Columns.Add(col);


            
            col = new GridViewTextBoxColumn();
            col.HeaderText = "Driver";
            col.Width = 200;
            col.Name = COLS.DRIVERNAME;
            
            grdBookings.Columns.Add(col);


            grdBookings.AddDeleteColumn();
            grdBookings.Columns["btnDelete"].Width = 80;
       

        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            AddBooking();

        }

        private void AddBooking()
        {

            try
            {
                int? vehicleTypeId = ddlVehicleType.SelectedValue.ToIntorNull();
                int? driverId = ddlDriver.SelectedValue.ToIntorNull();
                string vehicleTypeName = ddlVehicleType.Text.ToStr().Trim();
                string driverName = ddlDriver.Text.ToStr().Trim();

                string fromLocName = ddlFromLocation.Text.ToStr().Trim();
                string toLocName = ddlToLocation.Text.ToStr().Trim();

                int? fromLocTypeId = ddlFromLocType.SelectedValue.ToIntorNull();
                int? toLocTypeId = ddlToLocType.SelectedValue.ToIntorNull();
                int? fromLocId = ddlFromLocation.SelectedValue.ToIntorNull();
                int? toLocId = ddlToLocation.SelectedValue.ToIntorNull();
                string fromAddress = txtFromAddress.Text.Trim();
                string toAddress = txtToAddress.Text.Trim();
                string fromPostCode = txtFromPostCode.Text.Trim();
                string toPostCode = txtToPostCode.Text.Trim();
                string fromDoorNo = txtFromFlightDoorNo.Text.Trim();
                string fromStreet = txtFromStreetComing.Text.Trim();

                string toDoorNo = txtToFlightDoorNo.Text.Trim();
                string toStreet = txtToStreetComing.Text.Trim();


            //    int fare = numFareRate.SpinElement.Text == string.Empty ? 0 : numFareRate.SpinElement.Text.ToInt();
                string distance = lblMap.Text.ToStr();

                decimal fare = numFareRate.Value.ToDecimal();

                string error = string.Empty;

                if (vehicleTypeId == null)
                {
                    error += "Required : Vehicle Type";
                }


                //if (fromLocTypeId == Enums.LOCATION_TYPES.POSTCODE)
                //{
                //    fromAddress = fromPostCode;
                //}
                //else if (fromLocTypeId != Enums.LOCATION_TYPES.POSTCODE && fromLocTypeId != Enums.LOCATION_TYPES.ADDRESS && fromLocTypeId != Enums.LOCATION_TYPES.BASE)
                //{
                //    fromAddress = fromLocName;
                //}


                if (string.IsNullOrEmpty(fromAddress.ToStr().Trim()))
                {

                    if (error != string.Empty)
                        error += Environment.NewLine;

                    error += "Required : Pickup Point";

                }



                //if (toLocTypeId == Enums.LOCATION_TYPES.POSTCODE)
                //{
                //    toAddress = toPostCode;
                //}
                //else if (toLocTypeId != Enums.LOCATION_TYPES.POSTCODE && toLocTypeId != Enums.LOCATION_TYPES.ADDRESS && toLocTypeId != Enums.LOCATION_TYPES.BASE)
                //{
                //    toAddress = toLocName;
                //}



                if (string.IsNullOrEmpty(toAddress.ToStr().Trim()))
                {

                    if (error != string.Empty)
                        error += Environment.NewLine;

                    error += "Required : Destination";

                }


                if (driverId != null)
                {
                    int rowIndex = grdBookings.CurrentRow != null ? grdBookings.CurrentRow.Index : -1;

                    if (grdBookings.Rows.Where(c => c.Cells[COLS.DRIVERID].Value != null).Count(c => c.Cells[COLS.DRIVERID].Value.ToInt() == driverId
                                        && (rowIndex == -1 || c.Index != rowIndex)) > 0)
                    {
                        if (error != string.Empty)
                            error += Environment.NewLine;

                        error += "Driver already exist..";

                    }

                }




                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;


                }

                GridViewRowInfo row = null;

                int sno = 0;
                GridViewRowInfo lastRow = grdBookings.Rows.LastOrDefault();
                if (lastRow != null)
                {
                    sno = lastRow.Cells[COLS.SNO].Value.ToInt();

                }

                if (grdBookings.CurrentRow != null && grdBookings.CurrentRow is GridViewNewRowInfo)
                {
                    grdBookings.CurrentRow = null;

                }

                if (grdBookings.CurrentRow != null)
                {
                    row = grdBookings.CurrentRow;
                }

                else
                {
                    row = grdBookings.Rows.AddNew();
                    row.Cells[COLS.SNO].Value = ++sno;
                }



                row.Cells[COLS.FromPostCode].Value = fromPostCode;




                row.Cells[COLS.FromLocTypeId].Value = fromLocTypeId;
                row.Cells[COLS.FromLocId].Value = fromLocId;

                row.Cells[COLS.FromAddress].Value = fromAddress;

                row.Cells[COLS.FromDoor].Value = fromDoorNo;
                row.Cells[COLS.FromStreet].Value = fromStreet;

                row.Cells[COLS.DistanceMiles].Value.ToStr();
                row.Cells[COLS.Fare].Value = fare;

                row.Cells["Parking"].Value = numParking.Value;
                row.Cells["Extra"].Value = numExtra.Value;

                row.Cells[COLS.RetFare].Value = numReturnFare.Value.ToDecimal();

                row.Cells[COLS.CompanyPrice].Value = numCompanyFares.Value.ToDecimal();



                row.Cells[COLS.ToAddress].Value = toAddress;


                row.Cells[COLS.ToPostCode].Value = toPostCode;
                row.Cells[COLS.ToStreet].Value = toStreet;
                row.Cells[COLS.ToDoor].Value = toDoorNo;

                row.Cells[COLS.ToLocTypeId].Value = toLocTypeId;
                row.Cells[COLS.ToLocId].Value = toLocId;

                row.Cells[COLS.VEHICLETYPEID].Value = vehicleTypeId;
                row.Cells[COLS.DRIVERID].Value = driverId;
                row.Cells[COLS.VEHICLETYPENAME].Value = vehicleTypeName;
                row.Cells[COLS.DRIVERNAME].Value = driverName;

              
                ClearBooking();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private bool AddDefaultBookings(GridViewRowInfo row)
        {

            try
            {
                int? vehicleTypeId = ObjBooking.VehicleTypeId;
                int? driverId = ddlDriver.SelectedValue.ToIntorNull();
                string vehicleTypeName = ddlVehicleType.Text.ToStr().Trim();
                string driverName = ddlDriver.Text.ToStr().Trim();

                string fromLocName = ddlFromLocation.Text.ToStr().Trim();
                string toLocName = ddlToLocation.Text.ToStr().Trim();

                int? fromLocTypeId = ddlFromLocType.SelectedValue.ToIntorNull();
                int? toLocTypeId = ddlToLocType.SelectedValue.ToIntorNull();
                int? fromLocId = ddlFromLocation.SelectedValue.ToIntorNull();
                int? toLocId = ddlToLocation.SelectedValue.ToIntorNull();
                string fromAddress = txtFromAddress.Text.Trim();
                string toAddress = txtToAddress.Text.Trim();
                string fromPostCode = txtFromPostCode.Text.Trim();
                string toPostCode = txtToPostCode.Text.Trim();
                string fromDoorNo = txtFromFlightDoorNo.Text.Trim();
                string fromStreet = txtFromStreetComing.Text.Trim();

                string toDoorNo = txtToFlightDoorNo.Text.Trim();
                string toStreet = txtToStreetComing.Text.Trim();


              
                string distance = lblMap.Text.ToStr();

                decimal fare = ObjBooking.FareRate.ToDecimal();

                string error = string.Empty;

             

             //   GridViewRowInfo row = null;

                int sno = row.Index;
             

                row.Cells[COLS.SNO].Value = ++sno;

                row.Cells[COLS.FromPostCode].Value = fromPostCode;




                row.Cells[COLS.FromLocTypeId].Value = fromLocTypeId;
                row.Cells[COLS.FromLocId].Value = fromLocId;

                row.Cells[COLS.FromAddress].Value = fromAddress;

                row.Cells[COLS.FromDoor].Value = fromDoorNo;
                row.Cells[COLS.FromStreet].Value = fromStreet;

                row.Cells[COLS.DistanceMiles].Value.ToStr();
                row.Cells[COLS.Fare].Value = fare;

                row.Cells["Parking"].Value = ObjBooking.CongtionCharges.ToDecimal();
                row.Cells["Extra"].Value = ObjBooking.ExtraDropCharges.ToDecimal();

                row.Cells[COLS.RetFare].Value = numReturnFare.Value.ToDecimal();

                row.Cells[COLS.CompanyPrice].Value = ObjBooking.CompanyPrice.ToDecimal();



                row.Cells[COLS.ToAddress].Value = toAddress;


                row.Cells[COLS.ToPostCode].Value = toPostCode;
                row.Cells[COLS.ToStreet].Value = toStreet;
                row.Cells[COLS.ToDoor].Value = toDoorNo;

                row.Cells[COLS.ToLocTypeId].Value = toLocTypeId;
                row.Cells[COLS.ToLocId].Value = toLocId;

                row.Cells[COLS.VEHICLETYPEID].Value = vehicleTypeId;
                row.Cells[COLS.DRIVERID].Value = driverId;
                row.Cells[COLS.VEHICLETYPENAME].Value = vehicleTypeName;
                row.Cells[COLS.DRIVERNAME].Value = driverName;

               

                return true;
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
                return false;

            }


        }

        string[] res = null;
        string searchTxt = "";
        bool IsKeyword = false;
        private bool EnablePOI = false;

  
        AutoCompleteTextBox aTxt = null;
      
      
     
       

   
   


       

     

        private void ShowAddresses()
        {

            var finalList = (from a in AppVars.zonesList
                             from b in res
                             where b.Contains(a)

                             select b).ToArray<string>();


            if (finalList.Count() > 0)
                finalList = finalList.Union(res).ToArray<string>();

            else
                finalList = res;


            aTxt.ListBoxElement.Items.Clear();
            aTxt.ListBoxElement.Items.AddRange(finalList);


            if (aTxt.ListBoxElement.Items.Count == 0)
                aTxt.ResetListBox();
            else
                aTxt.ShowListBox();


            if (searchTxt != aTxt.FormerValue.ToLower())
            {
                aTxt.FormerValue = aTxt.Text;

            }


        }




        private void ClearBooking()
        {



            if (chkOrigin.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ddlFromLocType.SelectedValue = Enums.LOCATION_TYPES.ADDRESS;
                txtFromAddress.Text = string.Empty;
                txtFromFlightDoorNo.Text = string.Empty;
                txtFromPostCode.Text = string.Empty;
                txtFromStreetComing.Text = string.Empty;
                ddlFromLocation.SelectedValue = null;

                numFareRate.Value = 0;
                lblMap.Text = string.Empty;
            }

            if (chkDestination.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ddlToLocType.SelectedValue= Enums.LOCATION_TYPES.ADDRESS;
                txtToAddress.Text = string.Empty;
                txtToFlightDoorNo.Text = string.Empty;
                txtToPostCode.Text = string.Empty;
                txtToStreetComing.Text = string.Empty;
                ddlToLocation.SelectedValue = null;

                numFareRate.Value = 0;
                lblMap.Text = string.Empty;
            }



            grdBookings.CurrentRow = null;
           // ddlVehicleType.Tag = 1;
            //ddlVehicleType.SelectedValue = AppVars.objPolicyConfiguration.DefaultVehicleTypeId;
            SetDefaultVehicle(AppVars.objPolicyConfiguration.DefaultVehicleTypeId);
            ddlDriver.SelectedValue = null;

           
        }

        private void SetDefaultVehicle(int? vehicleTypeId)
        {
            ddlVehicleType.Tag = 1;
            ddlVehicleType.SelectedValue = vehicleTypeId;



            ddlVehicleType.Focus();
            ddlVehicleType.Tag = null;
        }

        private void grdBookings_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            SelectBooking(e.Row);
        }

        private void SelectBooking(GridViewRowInfo row)
        {
            if (row is GridViewDataRowInfo)
            {
                ddlVehicleType.SelectedValue = row.Cells[COLS.VEHICLETYPEID].Value.ToInt();
                ddlDriver.SelectedValue = row.Cells[COLS.DRIVERID].Value.ToInt();


                SetLocation(row.Cells[COLS.FromLocTypeId].Value.ToIntorNull(), row.Cells[COLS.FromDoor].Value.ToStr(), row.Cells[COLS.FromAddress].Value.ToStr(),
                            row.Cells[COLS.FromStreet].Value.ToStr(), row.Cells[COLS.FromPostCode].Value.ToStr(), row.Cells[COLS.FromLocId].Value.ToIntorNull(),

                            row.Cells[COLS.ToLocTypeId].Value.ToIntorNull(), row.Cells[COLS.ToDoor].Value.ToStr(), row.Cells[COLS.ToAddress].Value.ToStr(),
                            row.Cells[COLS.ToStreet].Value.ToStr(), row.Cells[COLS.ToPostCode].Value.ToStr(), row.Cells[COLS.ToLocId].Value.ToIntorNull());

                numFareRate.Value = row.Cells[COLS.Fare].Value.ToDecimal();

                lblMap.Text = row.Cells[COLS.DistanceMiles].Value.ToStr();
            }




        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearBooking();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _Saved;

        public bool Saved
        {
            get { return _Saved; }
            set { _Saved = value; }
        }



        List<DateTime> listOfPickUpDateTime = new List<DateTime>();
        DateTime? nowDate;
        public long savedAdvanceBookingId = 0;
        private bool Save()
        {

            bool IsSuccess = true;
            try
            {
                bool enableAutoDespatch = ObjBooking.AutoDespatch.ToBool();

                bool IsCompanyWise = false;

                int? companyId = ObjBooking.CompanyId;

                if (companyId != null)
                {
                    IsCompanyWise = true;
                }


                int? bookingTypeId = Enums.BOOKING_TYPES.LOCAL;

                int? vehicleTypeId = ObjBooking.VehicleTypeId;
                int? paymentTypeId = ObjBooking.PaymentTypeId;
                int totalPassengers = ObjBooking.NoofPassengers.ToInt();
                int totalLuggages = ObjBooking.NoofLuggages.ToInt();
                int totalHandLuggages = ObjBooking.NoofHandLuggages.ToInt();
                string customerName = ObjBooking.CustomerName.ToStr();
                string customerPhoneNo = ObjBooking.CustomerPhoneNo.ToStr();
                string customerMobileNo = ObjBooking.CustomerMobileNo.ToStr().Trim();

                decimal fareRate = ObjBooking.FareRate.ToDecimal();
                decimal companyPrice = ObjBooking.CompanyPrice.ToDecimal();

                int? fromLocTypeId = ObjBooking.FromLocTypeId;
                int? toLocTypeId = ObjBooking.ToLocTypeId;

                int? fromLocId = ObjBooking.FromLocId;
                int? toLocId = ObjBooking.ToLocId;
                int? returnFromLocId =ObjBooking.ReturnFromLocId;



                string fromAddress = ObjBooking.FromAddress;
                string fromDoorNo = ObjBooking.FromDoorNo.ToStr();
                string fromStreet = ObjBooking.FromStreet.ToStr();
                string fromPostCode = ObjBooking.FromPostCode.ToStr();

                string toAddress = ObjBooking.ToAddress;
                string toDoorNo = ObjBooking.ToDoorNo.ToStr();
                string toStreet = ObjBooking.ToStreet.ToStr();
                string toPostCode = ObjBooking.ToPostCode.ToStr();


                DateTime? PickUpDateTime = ObjBooking.PickupDateTime;

                int? journeyTypeId = ObjBooking.JourneyTypeId;

                // AutoDespatch
              
                int? driverId = ddlDriver.SelectedValue.ToIntorNull();
                //


                //decimal extraMile = 0.00m;

                //if (AppVars.objPolicyConfiguration.AutoBookingDueAlert.ToBool())
                //{

                //    // need to comment
                //    if (ObjBooking.FromLocTypeId.ToInt() != Enums.LOCATION_TYPES.AIRPORT)
                //    {
                //        extraMile = General.CalculateDistanceFromBase(ObjBooking.FromAddress.ToStr().Trim().ToUpper());
                //    }

                //}

                BookingBO objMaster = null;

                nowDate = ObjBooking.BookingDate;

                bool AllSuccess = true;


                AdvanceBookingBO objAdvBO = new AdvanceBookingBO();
                objAdvBO.New();
                objAdvBO.Current.CustomerName = customerName;
                objAdvBO.Current.CustomerTelephoneNo = customerPhoneNo;
                objAdvBO.Current.CustomerMobileNo = customerMobileNo;
                objAdvBO.Current.CustomerEmail = ObjBooking.CustomerEmail.ToStr().Trim();
                objAdvBO.Current.FromAddress = ObjBooking.FromAddress.ToStr().Trim();
                objAdvBO.Current.ToAddress = ObjBooking.ToAddress.ToStr().Trim();
                objAdvBO.Current.AdvBookingTypeId = AdvbookingTypeId;


                objAdvBO.Current.AddOn = DateTime.Now;
                objAdvBO.Current.AddLog = AppVars.LoginObj.UserName.ToStr();
                objAdvBO.Current.AddBy = AppVars.LoginObj.LuserId.ToIntorNull();
                
                objAdvBO.Save();
                long? advanceBookingId = objAdvBO.Current.Id;
                savedAdvanceBookingId = advanceBookingId.ToLong();
                int cnt = 1;
                foreach (GridViewRowInfo row in grdBookings.Rows)
            	{
		 
	
                    try
                    {
                      
                        objMaster = new BookingBO();
                        objMaster.New();

                        objMaster.Current.CompanyId = companyId;
                        objMaster.Current.IsCompanyWise = IsCompanyWise;

                        objMaster.Current.BookingDate = nowDate;

                        objMaster.Current.BookingTypeId = bookingTypeId;


                        objMaster.Current.SubcompanyId = ObjBooking.SubcompanyId;

                        objMaster.Current.JourneyTypeId = journeyTypeId;
                        objMaster.Current.PaymentTypeId = paymentTypeId;
                      
                        objMaster.Current.CustomerName = customerName;
                        objMaster.Current.CustomerPhoneNo = customerPhoneNo;
                        objMaster.Current.CustomerMobileNo = customerMobileNo;
                        objMaster.Current.CustomerEmail = ObjBooking.CustomerEmail.ToStr().Trim();

                        int FromLocTypeId =row.Cells[COLS.FromLocTypeId].Value.ToInt();
                        int ToLocTypeId = row.Cells[COLS.ToLocTypeId].Value.ToInt();

                        objMaster.Current.FromLocTypeId = FromLocTypeId;
                        objMaster.Current.ToLocTypeId = ToLocTypeId;
                        objMaster.Current.FromLocId = row.Cells[COLS.FromLocId].Value.ToIntorNull();
                        objMaster.Current.ToLocId = row.Cells[COLS.ToLocId].Value.ToIntorNull();
                        objMaster.Current.ReturnFromLocId = returnFromLocId;

                     
                       objMaster.Current.FromAddress = row.Cells[COLS.FromAddress].Value.ToStr().Trim();
                       objMaster.Current.FromDoorNo = row.Cells[COLS.FromDoor].Value.ToStr().Trim();
                       objMaster.Current.FromStreet = row.Cells[COLS.FromStreet].Value.ToStr().Trim();
                       objMaster.Current.FromPostCode = row.Cells[COLS.FromPostCode].Value.ToStr().Trim();


                      
                       objMaster.Current.ToAddress = row.Cells[COLS.ToAddress].Value.ToStr().Trim();
                       objMaster.Current.ToDoorNo = row.Cells[COLS.ToDoor].Value.ToStr().Trim();
                       objMaster.Current.ToStreet = row.Cells[COLS.ToStreet].Value.ToStr().Trim();
                       objMaster.Current.ToPostCode = row.Cells[COLS.ToPostCode].Value.ToStr().Trim();


                       objMaster.Current.DistanceString = lblMap.Text.ToStr().Trim();
                       objMaster.Current.AutoDespatch = ObjBooking.AutoDespatch.ToBool();



                        objMaster.Current.PickupDateTime = PickUpDateTime;

                      

                        objMaster.Current.BookedBy = ObjBooking.BookedBy.ToStr();
                        if (CustomLead)
                        {

                            objMaster.Current.AutoDespatchTime = objMaster.Current.PickupDateTime.Value.AddMinutes(-ObjBooking.DeadMileage.ToDecimal().ToInt()).ToDateTime();
                            objMaster.Current.DeadMileage = ObjBooking.DeadMileage.ToDecimal();
                        }


                        objMaster.Current.FareRate = row.Cells[COLS.Fare].Value.ToDecimal();

                        objMaster.Current.ReturnPickupDateTime = ObjBooking.ReturnPickupDateTime.ToDateTimeorNull();
                        objMaster.Current.ReturnFareRate = row.Cells[COLS.RetFare].Value.ToDecimal();
                        objMaster.Current.CompanyPrice = row.Cells[COLS.CompanyPrice].Value.ToDecimal();

                        objMaster.Current.DriverId = row.Cells[COLS.DRIVERID].Value.ToIntorNull();
                        objMaster.Current.VehicleTypeId = row.Cells[COLS.VEHICLETYPEID].Value.ToIntorNull();

                        objMaster.Current.AutoDespatch = enableAutoDespatch;

                        objMaster.Current.IsCommissionWise = ObjBooking.IsCommissionWise.ToBool();
                        objMaster.Current.DriverCommission = ObjBooking.DriverCommission.ToDecimal();
                        objMaster.Current.DriverCommissionType =ObjBooking.DriverCommissionType.ToStr();

                        objMaster.Current.IsQuotation = ObjBooking.IsQuotation.ToBool();


                        objMaster.Current.AgentCommission = ObjBooking.AgentCommission.ToDecimal();
                        objMaster.Current.AgentCommissionPercent = ObjBooking.AgentCommissionPercent;
                        objMaster.Current.JobTakenByCompany = ObjBooking.JobTakenByCompany.ToBool();
                        objMaster.Current.FromFlightNo = ObjBooking.FromFlightNo.ToStr();

                        objMaster.Current.AddOn = DateTime.Now;
                        objMaster.Current.AddLog = AppVars.LoginObj.UserName.ToStr();
                        objMaster.Current.AddBy = AppVars.LoginObj.LuserId.ToIntorNull();


                        objMaster.Current.SpecialRequirements = ObjBooking.SpecialRequirements.ToStr();


                        objMaster.Current.ServiceCharges = ObjBooking.ServiceCharges.ToDecimal();


                        if (objMaster.Current.SpecialRequirements.ToStr().Contains("Multivehicle")==false)
                        {

                            objMaster.Current.SpecialRequirements = ("Multivehicle " + cnt + "/" + grdBookings.Rows.Count + " " +objMaster.Current.SpecialRequirements).Trim();

                        }

                        objMaster.ReturnSpecialRequirement = this.ReturnSpecialReq.ToStr();
                        objMaster.ReturnVehicleTypeId = this.ReturnVehicleTypeId;


                        if (objMaster.ReturnSpecialRequirement.ToStr().Contains("Multivehicle") == false)
                        {

                            objMaster.ReturnSpecialRequirement = ("Multivehicle " + cnt + "/" + grdBookings.Rows.Count + " " + objMaster.ReturnSpecialRequirement).Trim();

                        }

                        cnt++;

                        objMaster.Current.WaitingMins = ObjBooking.WaitingMins.ToDecimal();

                        objMaster.Current.CustomerPrice = ObjBooking.CustomerPrice.ToDecimal();
                        objMaster.ReturnCustomerPrice = this.ReturnBookingFee.ToDecimal();
                      

                        objMaster.Current.AutoDespatch = ObjBooking.AutoDespatch.ToBool();
                        objMaster.Current.IsBidding = ObjBooking.IsBidding.ToBool();


                        if (AppVars.objPolicyConfiguration.ShowAreaWithPlots.ToBool() && AppVars.objPolicyConfiguration.EnablePDA.ToBool())
                        {
                            if (objMaster.Current.FromPostCode.ToStr().Trim() == string.Empty)
                                objMaster.Current.FromPostCode = General.GetPostCodeMatch(objMaster.Current.FromAddress.ToStr().Trim());


                            
                                if ((LastPickupPostCode == string.Empty || LastPickupPostCode != objMaster.Current.FromAddress.ToStr().Trim()))
                                {

                                    objMaster.Current.ZoneId = General.GetZoneId(objMaster.Current.FromAddress.ToStr().ToUpper().Trim());
                                    LastPickupPostCode = objMaster.Current.FromAddress.ToStr().Trim();
                                    lastPickupZoneId = objMaster.Current.ZoneId;

                                   
                                }
                                else
                                {
                                   
                                    objMaster.Current.ZoneId = lastPickupZoneId;

                                  
                                }
                           


                            if (objMaster.Current.ToPostCode.ToStr().Trim() == string.Empty)
                                objMaster.Current.ToPostCode = General.GetPostCodeMatch(objMaster.Current.ToAddress.ToStr().Trim());


                            
                                if ((LastDropOffPostCode == string.Empty || LastDropOffPostCode != objMaster.Current.ToAddress.ToStr().Trim()))
                                {

                                    objMaster.Current.DropOffZoneId = General.GetZoneId(objMaster.Current.ToAddress.ToStr().Trim().ToUpper());
                                    LastDropOffPostCode = objMaster.Current.ToAddress.ToStr().Trim().ToUpper();
                                    lastDropOffZoneId = objMaster.Current.DropOffZoneId;
                                }
                                else
                                {
                                    objMaster.Current.DropOffZoneId = lastDropOffZoneId;
                                }
                           
                        }

                        objMaster.Current.JourneyTimeInMins = ObjBooking.JourneyTimeInMins.ToDecimal();
                        objMaster.Current.ExtraMile = ObjBooking.ExtraMile.ToDecimal();

                        objMaster.Current.AdvanceBookingId = advanceBookingId;
                        objMaster.Current.CallRefNo = ObjBooking.CallRefNo.ToStr().Trim();

                        objMaster.CheckServiceCharges = AppVars.objPolicyConfiguration.SendBookingCompletionEmail.ToBool();


                        objMaster.Current.CongtionCharges = row.Cells["Parking"].Value.ToDecimal();
                        objMaster.Current.ExtraDropCharges = row.Cells["Extra"].Value.ToDecimal();

                        if(objMaster.Current.CompanyId!=null)
                        {

                            objMaster.Current.ParkingCharges = row.Cells["Parking"].Value.ToDecimal();
                         
                        }

                        if (ObjBooking.EscortId != null)
                        {
                            
                            objMaster.Current.EscortId = ObjBooking.EscortId;
                        }

                        objMaster.Current.EscortPrice = ObjBooking.EscortPrice.ToDecimal();

                        if (ReleaseMode != null)
                        {
                            objMaster.Current.AutoDespatch = ReleaseMode.ToBool();
                            objMaster.Current.IsBidding = ReleaseMode.ToBool();

                        }

                        objMaster.Save();


                        if (objMaster.Current.DriverId != null)
                        {

                            frmDespatchJob frm = null;
                            if ( (objMaster.Current.BookingStatusId.ToInt() == Enums.BOOKINGSTATUS.WAITING
                                   || objMaster.Current.BookingStatusId == null))
                            {


                                frm = new frmDespatchJob(objMaster.Current);
                                frm.ShowDialog();

                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        if (objMaster.Errors.Count > 0)
                            ENUtils.ShowMessage(objMaster.ShowErrors());
                        else
                        {
                            ENUtils.ShowMessage(ex.Message);

                        }
                        AllSuccess = false;
                        break;
                    }

                }


                if (AllSuccess)
                {

                    // Advance Booking Confirmation Text
                    bool enableAdvBookingText = AppVars.objPolicyConfiguration.EnableAdvanceBookingSMSConfirmation.ToBool();

                    DateTime? pickupdateTime = PickUpDateTime;
                    if (enableAdvBookingText && pickupdateTime != null)
                    {
                        string pickupSpan = string.Format("{0:HH:mm}", pickupdateTime);

                        TimeSpan picktime = TimeSpan.Parse(pickupSpan);


                        string nowP = string.Format("{0:HH:mm}", nowDate);
                        TimeSpan nowSpantime = TimeSpan.Parse(nowP);


                     //   int afterMins = AppVars.objPolicyConfiguration.AdvanceBookingSMSConfirmationMins.ToInt();
                        //  int minDifference = picktime.Subtract(nowSpantime).Minutes;
                        //  int dayDiff = pickupdateTime.Value.Date.Subtract(DateTime.Now.Date).Days;
                        int afterMins = AppVars.objPolicyConfiguration.AdvanceBookingSMSConfirmationMins.ToInt();
                        double minDifference = pickupdateTime.Value.Subtract(DateTime.Now).TotalMinutes;
                        //  int dayDiff = pickupdateTime.Value.Date.Subtract(DateTime.Now.Date).Days;
                        if (afterMins == 0 || minDifference >= afterMins)
                        //   if (afterMins >= 0 && (dayDiff > 0 || minDifference >= afterMins))
                        {

                            string msg = AppVars.objPolicyConfiguration.AdvanceBookingSMSText.ToStr().Trim();
                            object propertyValue = string.Empty;

                            foreach (var tag in AppVars.listofSMSTags.Where(c => msg.Contains(c.TagMemberValue)))
                            {
                                switch (tag.TagObjectName)
                                {
                                    case "booking":

                                        if (tag.TagPropertyValue.Contains('.'))
                                        {

                                            string[] val = tag.TagPropertyValue.Split(new char[] { '.' });

                                            object parentObj = ObjBooking.GetType().GetProperty(val[0]).GetValue(ObjBooking, null);

                                            if (parentObj != null)
                                            {
                                                propertyValue = parentObj.GetType().GetProperty(val[1]).GetValue(parentObj, null);
                                            }
                                            else
                                                propertyValue = string.Empty;


                                            break;
                                        }
                                        else
                                        {
                                            propertyValue = ObjBooking.GetType().GetProperty(tag.TagPropertyValue).GetValue(ObjBooking, null);
                                        }


                                        if (string.IsNullOrEmpty(propertyValue.ToStr()) && !string.IsNullOrEmpty(tag.TagPropertyValue2))
                                        {
                                            propertyValue = ObjBooking.GetType().GetProperty(tag.TagPropertyValue2).GetValue(ObjBooking, null);
                                        }
                                        break;


                                    default:
                                        propertyValue = AppVars.objSubCompany.GetType().GetProperty(tag.TagPropertyValue).GetValue(AppVars.objSubCompany, null);
                                        break;

                                }


                                msg = msg.Replace(tag.TagMemberValue,
                                    tag.TagPropertyValuePrefix.ToStr() + string.Format(tag.TagDataFormat, propertyValue) + tag.TagPropertyValueSuffix.ToStr());

                            }


                            msg.Replace("\n\n", "\n");

                            string refMsg = "";
                            General.SendAdvanceBookingSMS(customerMobileNo, ref refMsg, msg, ObjBooking.SMSType.ToInt());

                        }
                    }



                    General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_REQUIRED_DASHBOARD + "=" + 0);

                    //
                }


            }
            catch (Exception ex)
            {

                ENUtils.ShowMessage(ex.Message);
                IsSuccess = false;
            }

            return IsSuccess;

        }

        private string LastPickupPostCode = string.Empty;
        private string LastDropOffPostCode = string.Empty;
        private int? lastPickupZoneId = null;
        private int? lastDropOffZoneId = null;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saved = Save();

            this.Close();
        }

        private void ddlFromLocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFromLocations();
        }

        private void ddlToLocType_SelectedIndexChanged(object sender,  EventArgs e)
        {
            FillToLocations();
        }

        private void chkOrigin_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ddlFromLocType.SelectedValue = Enums.LOCATION_TYPES.ADDRESS;
                txtFromAddress.Text = string.Empty;
                txtFromFlightDoorNo.Text = string.Empty;
                txtFromPostCode.Text = string.Empty;
                txtFromStreetComing.Text = string.Empty;
                ddlFromLocation.SelectedValue = null;

                txtFromAddress.Focus();
                numFareRate.Value = 0;
                txtFromAddress.Enabled = true;
                lblMap.Text = string.Empty;
                fares = null;
            }
            else
            {
                txtFromAddress.Enabled = false;
                txtFromAddress.Tag = 1;
                txtFromAddress.Text = ObjBooking.ToAddress.ToStr().Trim();
                txtFromAddress.Tag = null;
            }


            
        }

        private void chkDestination_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ddlToLocType.SelectedValue = Enums.LOCATION_TYPES.ADDRESS;
                txtToAddress.Text = string.Empty;
                txtToFlightDoorNo.Text = string.Empty;
                txtToPostCode.Text = string.Empty;
                txtToStreetComing.Text = string.Empty;
                ddlToLocation.SelectedValue = null;

                txtToAddress.Focus();

                numFareRate.Value = 0;
                lblMap.Text = string.Empty;
                fares = null;
                txtToAddress.Enabled = true;
            }

            else
            {
                txtToAddress.Enabled = false;
                txtToAddress.Tag = 1;
                txtToAddress.Text = ObjBooking.ToAddress.ToStr().Trim();
                txtToAddress.Tag = null;
            }
        }


       

        private bool CalculateFares()
        {
           
            int? vehicleTypeId = ddlVehicleType.SelectedValue.ToIntorNull();
            int companyId = ObjBooking.CompanyId.ToInt();
            int? fromLocationId = ddlFromLocation.SelectedValue.ToIntorNull();
            int? fromLocTypeId = ddlFromLocType.SelectedValue.ToInt();
            DateTime bookingDate = DateTime.Now.ToDate();

            int? toLocTypeId = ddlToLocType.SelectedValue.ToInt();
            int? toLocationId = ddlToLocation.SelectedValue.ToIntorNull();

            string fromLocName = ddlFromLocation.Text.Trim();
            string toLocName = ddlToLocation.Text.Trim();

            string fromAddress = txtFromAddress.Text.Trim();
            string toAddress = txtToAddress.Text.Trim();
            string fromPostCode = txtFromPostCode.Text.Trim();
            string toPostCode = txtToPostCode.Text.Trim();

            DateTime? pickupTime=ObjBooking.PickupDateTime;

            List<string> errors = new List<string>();

         

            if (vehicleTypeId == null)
            {
                errors.Add("Required : Vehicle Type");

            }

            if (fromLocationId == null && string.IsNullOrEmpty(fromPostCode) && string.IsNullOrEmpty(fromAddress))
            {

                errors.Add("Required : From Address");

            }


            if (toLocationId == null && string.IsNullOrEmpty(toPostCode) && string.IsNullOrEmpty(toAddress))
            {
                errors.Add("Required : To Address");

            }


            if (errors.Count > 0)
            {
                ENUtils.ShowMessage(string.Join(Environment.NewLine, errors.Select(c => c).ToArray<string>()));
                return false;
            }
            ClsGetFaresFromAPI.BookingInformationEx obj = new ClsGetFaresFromAPI.BookingInformationEx();
          
            obj.FromAddress = ObjBooking.FromAddress.ToStr();
          



            obj.ToAddress = ObjBooking.ToAddress.ToStr();
            obj.FromType = "Address";
            obj.ToType = "Address";


            if (ddlFromLocType.SelectedValue.ToInt() == Enums.LOCATION_TYPES.AIRPORT)
            {
                obj.FromType = "Airport";

            }

            if (ddlToLocType.SelectedValue.ToInt()==Enums.LOCATION_TYPES.AIRPORT)
            {
                obj.ToType = "Airport";

            }

            //  obj.VehicleTypeId = ddlVehicleType.SelectedValue.ToInt();
            obj.CompanyId = ObjBooking.CompanyId.ToInt();
            obj.PickupDateTime =string.Format("{0:dd/MM/yyyy HH:mm}", ObjBooking.PickupDateTime.ToDateTime());

            try
            {

                if (ObjBooking.Booking_ViaLocations.Count > 0)
                {
                    obj.Via = new ClsGetFaresFromAPI.ViaAddresses[ObjBooking.Booking_ViaLocations.Count];
                    int cnt = 0;
                    foreach (var item in ObjBooking.Booking_ViaLocations)
                    {
                        obj.Via[cnt] = new ClsGetFaresFromAPI.ViaAddresses();
                        obj.Via[cnt].Viatype = "Address";
                        obj.Via[cnt].Viaaddress = item.ViaLocValue.ToStr();
                        cnt++;

                    }


                }

            }
            catch
            {


            }

           

            if (chkOrigin.Checked)
                obj.FromAddress = txtFromAddress.Text.ToStr().Trim().ToUpper();

            if (chkDestination.Checked)
                obj.ToAddress = txtToAddress.Text.ToStr().Trim().ToUpper();


            if (obj.FromAddress.ToStr().Length == 0)
            {
                MessageBox.Show("Required : Pickup Address");


                return false;
            }


            if (obj.ToAddress.ToStr().Length == 0)
            {
                MessageBox.Show("Required : Drop-off Address");


                return false;
            }


        



            try
            {
               

                string value = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                if (value.Contains("&"))
                    value = value.Replace("&", "AND");


                ClsGetFaresFromAPI c = new ClsGetFaresFromAPI();
                string response=    c.GetBooking("GetAllFaresFromDispatch", "dispatch", AppVars.objPolicyConfiguration.DefaultClientId.ToStr(), value, "");

           

                ClsGetFaresFromAPI.ClsGetFaresFromAPIRoot objRoot = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsGetFaresFromAPI.ClsGetFaresFromAPIRoot>(response);

                 fares = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClsGetFaresFromAPI.ClsDispatchFares>>(objRoot.Data);


                var objFare= fares.FirstOrDefault(a => a.Name.ToLower() == ddlVehicleType.Text.Trim().ToLower());
              

                numFareRate.Value = objFare.Fare.ToDecimal();


                if (ObjBooking.JourneyTypeId.ToInt() == Enums.JOURNEY_TYPES.RETURN)
                    numReturnFare.Value = objFare.ReturnFare.ToDecimal();

                if (ObjBooking.CompanyId != null)
                    numCompanyFares.Value = objFare.CompanyPrice.ToDecimal();





                numParking.Value = objFare.Parking.ToDecimal();
                numExtra.Value = objFare.ExtraCharges.ToDecimal();

                if(chkOrigin.Checked || chkDestination.Checked)
                {
                    lblMap.Text = string.Empty;

                }

            }
            catch (Exception ex)
            {


            }
            return true;

        }
        List<ClsGetFaresFromAPI.ClsDispatchFares> fares = null;


      

        private void btnCalculateFare_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateFares();

             
           
            }
            catch (Exception ex)
            {

             

            }
        }

     




#region TextChanged

        void TextBoxElement_TextChanged(object sender, EventArgs e)
        {


            try
            {

                IsKeyword = false;

                InitializeTimer();
                timer1.Stop();

                aTxt = (AutoCompleteTextBox)sender;
                aTxt.ResetListBox();


                if(  aTxt.Tag!=null)
                    return;

                if (aTxt.Name == "txtFromAddress")
                    txtToAddress.SendToBack();

                else if (aTxt.Name == "txtToAddress")
                    txtToAddress.BringToFront();



               

                    InitializeSearchPOIWorker();

                    if (POIWorker.IsBusy)
                    {
                        POIWorker.CancelAsync();

                        POIWorker.Dispose();
                        POIWorker = null;
                        GC.Collect();
                        InitializeSearchPOIWorker();

                    }


                    AddressTextChangePOI();
               
            }
            catch (Exception ex)
            {

            }
        }

        BackgroundWorker POIWorker = null;
        private void InitializeSearchPOIWorker()
        {
            if (POIWorker == null)
            {
                POIWorker = new BackgroundWorker();
                POIWorker.WorkerSupportsCancellation = true;
                POIWorker.DoWork += new DoWorkEventHandler(POIWorker_DoWork);
                POIWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(POIWorker_RunWorkerCompleted);
            }



        }

        void POIWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
            try
            {
                if (e.Result == null || e.Cancelled || (sender as BackgroundWorker) == null)
                    return;



                ShowAddressesPOI((string[])e.Result);

            }
            catch
            {


            }
        }

        void POIWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            string searchValue = e.Argument.ToStr();
            try
            {
                if (POIWorker == null)
                {
                    e.Cancel = true;
                    return;


                }

                //   Console.WriteLine("Start work : " + searchValue);

                string postCode = General.GetPostCodeMatchOpt(searchValue);

                string doorNo = string.Empty;
                string place = string.Empty;

                if (!string.IsNullOrEmpty(postCode) && postCode.IsAlpha() == true)
                    postCode = string.Empty;

                string street = searchValue;

                if (postCode.Length > 0)
                {
                    street = street.Replace(postCode, "").Trim();
                }


                if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(postCode) && street.IsAlpha() == false && street.Length < 4 && searchValue.IndexOf(postCode) < searchValue.IndexOf(street))
                {
                    street = "";
                    postCode = searchTxt;
                }


                if (street.Length > 0)
                {

                    if (char.IsNumber(street[0]))
                    {

                        for (int i = 0; i <= 3; i++)
                        {
                            if (char.IsNumber(street[i]) || (doorNo.Length > 0 && doorNo.Length == i && char.IsLetter(street[i])))
                                doorNo += street[i];
                            else
                                break;
                        }
                    }
                }


                if (street.EndsWith("#"))
                {
                    street = street.Replace("#", "").Trim();
                    place = "p=";
                }

                if (doorNo.Length > 0 && place.Length == 0)
                {
                    street = street.Replace(doorNo, "").Trim();


                }


                if (postCode.Length == 0 && street.Length < 3)
                {
                    e.Cancel = true;
                    return;

                }


                if (street.Length > 1 || postCode.Length > 0)
                {
                    if (postCode.Length > 0)
                    {
                        if (doorNo.Length > 0 && postCode == General.GetPostCodeMatch(postCode))
                        {
                            doorNo = string.Empty;
                        }

                    }

                    if (postCode.Length >= 5 && postCode.Contains(" ") == false)
                    {
                        string resultPostCode = AppVars.listOfAddress.FirstOrDefault(a => a.PostalCode.Strip(' ') == postCode).DefaultIfEmpty().PostalCode.ToStr().Trim();


                        if (resultPostCode.Length >= 5 && resultPostCode.Contains(" "))
                        {
                            postCode = resultPostCode;

                        }

                    }


                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }



                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        e.Result = db.stp_GetByRoadLevelData(postCode, doorNo, street, place).Select(c => c.AddressLine1).ToArray<string>();

                    }

                    if (POIWorker == null || POIWorker.CancellationPending || ((sender as BackgroundWorker) == null || (sender as BackgroundWorker).CancellationPending))
                    {
                        e.Cancel = true;
                        return;
                    }




                    //   Console.WriteLine("end work : " + searchValue);

                }
            }
            catch
            {
                //     Console.WriteLine("Start work catch: " + searchValue);

            }
        }



  
        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (aTxt == null || IsKeyword)
                {

                    timer1.Stop();
                    return;
                }

                timer1.Stop();

                searchTxt = searchTxt.ToUpper();


               

                    if (POIWorker.IsBusy)
                        POIWorker.CancelAsync();



                    POIWorker.RunWorkerAsync(searchTxt);
               


            }
            catch (Exception ex)
            {


            }

        }


        private void StartAddressTimer(string text)
        {
            text = text.ToLower();
            searchTxt = text;
            InitializeTimer();
            timer1.Start();
        }

        private void InitializeTimer()
        {
            if (this.timer1 == null)
            {
                this.timer1 = new System.Windows.Forms.Timer();
                this.timer1.Tick += timer1_Tick;
                this.timer1.Interval = 500;
            }

        }



      




        private void AddressTextChangePOI()
        {
            string text = aTxt.Text;
            string doorNo = string.Empty;


            try
            {

                if (aTxt.SelectedItem != null && aTxt.ListBoxElement.SelectedItem != null && aTxt.SelectedItem.ToStr().ToLower() == aTxt.Text.ToLower()
                   && aTxt.Text.Length > 0 && aTxt.Text[0].ToStr().IsNumeric())
                {
                    aTxt.TextChanged -= TextBoxElement_TextChanged;
                    //  aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                    aTxt.Text = aTxt.ListBoxElement.SelectedItem.ToStr().Trim().ToUpper().Trim();

                    if (aTxt.Text.Contains(".") && aTxt.Text.IndexOf(".") < 3 && aTxt.Text.IndexOf(".") > 0 && char.IsNumber(aTxt.Text[aTxt.Text.IndexOf(".") - 1]))
                    {
                        aTxt.Text = aTxt.Text.Remove(0, aTxt.Text.IndexOf('.') + 1).Trim();
                    }

                    aTxt.SelectedItem = aTxt.Text.Trim();
                    aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                }



                if (text.ToStr().Trim().Length > 0)
                {

                    for (int i = 0; i <= 2; i++)
                    {
                        if (char.IsNumber(text[i]))
                            doorNo += text[i];
                        else
                            break;
                    }

                }




                if (text.Length > 1 && text != "BASX")
                {
                    if (text.EndsWith("   "))
                    {
                        //if (aTxt.Name == "txtFromAddress")
                        //{
                        //    FocusOnPickupPlot();
                        //}
                        //else if (aTxt.Name == "txtToAddress")
                        //{
                        //    FocusOnDropOffPlot();
                        //}
                        //return;
                    }


                    else if (aTxt.SelectedItem != null && aTxt.SelectedItem.ToLower() == aTxt.Text.ToLower())
                    {
                        aTxt.ListBoxElement.Items.Clear();
                        aTxt.ResetListBox();

                        string locName = aTxt.SelectedItem.ToLower();
                        int commaIndex = aTxt.SelectedItem.LastIndexOf(',');
                        if (commaIndex != -1)
                        {
                            locName = locName.Remove(commaIndex);
                        }


                        string formerValue = aTxt.FormerValue.ToLower().Trim();

                        int? loctypeId = 0;
                        Gen_Location loc = null;
                        if (AppVars.keyLocations.Contains(formerValue) || aTxt.FormerValue.EndsWith("  ")
                        || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 3 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                        {
                            if (aTxt.FormerValue.EndsWith("  ") || (aTxt.FormerValue.Length < 13 && aTxt.FormerValue.WordCount() == 2 && aTxt.FormerValue.Remove(aTxt.FormerValue.IndexOf(' ')).Trim().Length <= 2 && aTxt.FormerValue.Strip(' ').IsAlpha()))
                            {
                                loc = General.GetObject<Gen_Location>(c => c.LocationName.ToLower() == locName);
                            }
                            else
                                loc = General.GetObject<Gen_Location>(c => c.ShortCutKey == formerValue && c.LocationName.ToLower() == locName);

                            if (loc != null)
                            {
                                loctypeId = loc.LocationTypeId;
                            }
                        }

                        if (loctypeId != 0)
                        {

                            if (aTxt.Name == "txtFromAddress")
                            {

                                ddlFromLocType.SelectedValue = loctypeId;
                                RadListDataItem item = (RadListDataItem)ddlFromLocation.Items.FirstOrDefault(b => b.Text.ToUpper().Equals(aTxt.SelectedItem.ToUpper()));
                                if (item != null)
                                {
                                    ddlFromLocation.SelectedValue = item.Value;
                                    //if (commaIndex > 0 && ddlFromLocation.Text.ToUpper() != item.Text.ToUpper())
                                    //{
                                    //    SetPickupZone(item.Text);
                                    //}


                                    //if (loc != null && loc.ZoneId != null && ddlPickupPlot.SelectedValue == null)
                                    //{
                                    //    ddlPickupPlot.SelectedValue = loc.ZoneId;
                                    //}

                                    //if (ddlFromLocation.SelectedValue != null && AppVars.objPolicyConfiguration.AutoCalculateFares.ToBool())
                                    //{
                                    //    UpdateAutoCalculateFares();

                                    //}
                                }
                                else
                                {
                                    if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                                    {
                                        aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                        aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                        aTxt.Text = aTxt.Text.Trim();
                                        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                                        //if (aTxt.Name == "txtFromAddress")
                                        //{
                                        //    SetPickupZone(aTxt.Text);

                                        //    UpdateAutoCalculateFares();
                                        //}
                                    }
                                }

                                if (loctypeId != Enums.LOCATION_TYPES.POSTCODE || loctypeId != Enums.LOCATION_TYPES.ADDRESS
                                    || loctypeId != Enums.LOCATION_TYPES.AIRPORT || loctypeId != Enums.LOCATION_TYPES.BASE)
                                {

                                    txtToAddress.Focus();

                                }
                            }
                            else if (aTxt.Name == "txtToAddress")
                            {

                                ddlToLocType.SelectedValue = loctypeId;
                                RadListDataItem item = (RadListDataItem)ddlToLocation.Items.FirstOrDefault(b => b.Text.ToUpper().Equals(aTxt.SelectedItem.ToUpper()));
                                if (item != null)
                                {
                                    ddlToLocation.SelectedValue = item.Value;

                                    //if (commaIndex > 0 && ddlToLocation.Text.ToUpper() != item.Text.ToUpper())
                                    //{
                                    //    SetDropOffZone(item.Text);
                                    //}

                                    //if (loc != null && loc.ZoneId != null && ddlDropOffPlot.SelectedValue == null)
                                    //{
                                    //    ddlDropOffPlot.SelectedValue = loc.ZoneId;
                                    //}

                                    //if (ddlToLocation.SelectedValue != null && AppVars.objPolicyConfiguration.AutoCalculateFares.ToBool())
                                    //{
                                    //    UpdateAutoCalculateFares();
                                    //}
                                }
                                else
                                {
                                    if (loctypeId == Enums.LOCATION_TYPES.ADDRESS && aTxt.SelectedItem.ToStr().Length > 0)
                                    {
                                        aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                        aTxt.Text = doorNo + " " + aTxt.SelectedItem.ToStr().Trim();
                                        aTxt.Text = aTxt.Text.Trim();
                                        aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);

                                        //  SetDropOffZone(aTxt.Text);
                                        //   UpdateAutoCalculateFares();
                                    }

                                }

                                if (loctypeId == Enums.LOCATION_TYPES.POSTCODE || loctypeId == Enums.LOCATION_TYPES.ADDRESS)
                                {
                                    txtToFlightDoorNo.Focus();
                                }
                                //else
                                //{
                                //    ddlCustomerName.Focus();
                                //}
                            }
                        }
                        else if (aTxt.Text.Contains('.'))
                        {
                            // RemoveNumbering(doorNo);

                            if (aTxt.Name == "txtFromAddress")
                            {

                                //  SetPickupZone(aTxt.SelectedItem);
                                txtFromFlightDoorNo.Focus();

                            }

                            else if (aTxt.Name == "txtToAddress")
                            {
                                //  SetDropOffZone(aTxt.SelectedItem);
                                txtToFlightDoorNo.Focus();

                            }
                        }
                        //else if (!string.IsNullOrEmpty(doorNo))
                        //{
                        //    aTxt.TextChanged -= TextBoxElement_TextChanged;
                        //    aTxt.Text = aTxt.Text;
                        //    aTxt.TextChanged += TextBoxElement_TextChanged;
                        //}
                        //else
                        //{
                        //    if (aTxt.Name == "txtFromAddress")
                        //    {
                        //        SetPickupZone(aTxt.SelectedItem);
                        //    }

                        //    else if (aTxt.Name == "txtToAddress")
                        //    {
                        //        SetDropOffZone(aTxt.SelectedItem);

                        //    }

                        //    if (aTxt.SelectedItem.ToStr().Trim() != string.Empty)
                        //    {
                        //        UpdateAutoCalculateFares();
                        //    }
                        //}

                        aTxt.FormerValue = string.Empty;
                        CalculateFares();
                        return;
                    }

                    //if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                    //{

                        aTxt.Values = null;

                  //  }

                    text = text.ToLower();

                    if (AppVars.keyLocations.Contains(text) || (text.Length <= 4 && (text.EndsWith("  ") || (text[1] == ' ' || (text.Length > 2 && char.IsLetter(text[1]) && text[2] == ' ' && text.Trim().WordCount() == 2))))
                       || (text.Length < 13 && text.WordCount() == 2 && text.Remove(text.IndexOf(' ')).Trim().Length <= 3 && text.Strip(' ').IsAlpha()))
                    {


                        aTxt.ListBoxElement.Items.Clear();


                        string[] res = null;

                        if (text.EndsWith("  "))
                        {

                            text = text.Trim();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.StartsWith(text))
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                    ).ToArray<string>();


                        }
                        else
                        {
                            if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                            {
                                string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                                string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                                res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                            c.LocationName.ToLower().Contains(locName))
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                          ).ToArray<string>();

                            }
                            else
                            {


                                res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                           ).ToArray<string>();
                            }
                        }


                        if (res.Count() > 0)
                        {
                            IsKeyword = true;


                            var finalList = (from a in AppVars.zonesList
                                             from b in res
                                             where b.Contains(a)
                                             select b).ToArray<string>();


                            if (finalList.Count() > 0)
                                finalList = finalList.Union(res).ToArray<string>();

                            else
                                finalList = res;


                            aTxt.ListBoxElement.Items.AddRange(finalList);

                            aTxt.ShowListBox();
                        }


                        if (aTxt.Text != aTxt.FormerValue)
                        {
                            aTxt.FormerValue = aTxt.Text;
                        }
                    }


                   // if (MapType == Enums.MAP_TYPE.NONE) return;

                    StartAddressTimer(text);

                }
                else if (text.Length > 0)
                {
                    //if (MapType == Enums.MAP_TYPE.GOOGLEMAPS)
                    //{

                        aTxt.Values = null;

                  //  }
                    text = text.ToLower();

                    if (AppVars.keyLocations.Contains(text))
                    {

                        aTxt.ListBoxElement.Items.Clear();


                        string[] res = null;

                        if (text.EndsWith("  "))
                        {

                            text = text.Trim();

                            res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey.ToLower() == text)
                                   select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                    ).ToArray<string>();


                        }
                        else
                        {
                            if (text.Contains(' ') && text.Substring(text.IndexOf(' ')).Trim().Length > 1)
                            {
                                string shortcut = text.Remove(text.IndexOf(' ')).Trim();

                                string locName = text.Substring(text.IndexOf(' ')).Trim().ToLower();

                                res = (from a in General.GetQueryable<Gen_Location>(c => c.Gen_LocationType.ShortCutKey == shortcut &&
                                            c.LocationName.ToLower().Contains(locName))
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                          ).ToArray<string>();

                            }
                            else
                            {


                                res = (from a in General.GetQueryable<Gen_Location>(c => c.ShortCutKey == text)
                                       select (a.PostCode != string.Empty ? a.LocationName + ", " + a.PostCode : a.LocationName)
                                           ).ToArray<string>();
                            }
                        }


                        if (res.Count() > 0)
                        {
                            IsKeyword = true;


                            var finalList = (from a in AppVars.zonesList
                                             from b in res
                                             where b.Contains(a)
                                             select b).ToArray<string>();


                            if (finalList.Count() > 0)
                                finalList = finalList.Union(res).ToArray<string>();

                            else
                                finalList = res;


                            aTxt.ListBoxElement.Items.AddRange(finalList);

                            if (text == "." && finalList.Count() == 1)
                            {
                                aTxt.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                                aTxt.Text = finalList[0];
                                aTxt.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                                if (aTxt.Name == "txtFromAddress")
                                {

                                    // SetPickupZone(aTxt.Text);
                                    txtFromFlightDoorNo.Focus();

                                }

                                else if (aTxt.Name == "txtToAddress")
                                {
                                    //  SetDropOffZone(aTxt.Text);
                                    txtToFlightDoorNo.Focus();

                                }
                            }
                            else
                            {

                                aTxt.ShowListBox();
                            }
                        }


                        if (aTxt.Text != aTxt.FormerValue)
                        {
                            aTxt.FormerValue = aTxt.Text;
                        }

                        StartAddressTimer(text);
                    }


                }
                else
                {
                    //if (MapType == Enums.MAP_TYPE.NONE)
                    //    return;
                    aTxt.ResetListBox();
                    aTxt.ListBoxElement.Items.Clear();
                    aTxt.Values = null;

                }

            }
            catch
            {

            }

        }



     


        private void ShowAddressesPOI(string[] resValue)
        {
            int sno = 1;

            // var finalList = resValue;


            try
            {

                var finalList = (from a in AppVars.zonesList
                                 from b in resValue
                                 where b.Contains(a) && (b.Substring(b.IndexOf(a), a.Length) == a && (b.IndexOf(a) - 1) >= 0 && b[b.IndexOf(a) - 1] == ' ' && GeneralBLL.GetHalfPostCodeMatch(b) == a)

                                 select b).ToArray<string>();


                if (finalList.Count() > 0)
                {
                    finalList = finalList.Union(resValue).ToArray<string>();

                }
                else
                    finalList = resValue;



                if (finalList.Count() < 10)
                {
                    finalList = finalList.Select(args => (sno++) + ". " + args).ToArray();
                }


                aTxt.ListBoxElement.Items.Clear();
                aTxt.ListBoxElement.Items.AddRange(finalList);


                if (aTxt.ListBoxElement.Items.Count == 0)
                    aTxt.ResetListBox();
                else
                {


                    aTxt.ShowListBox();


                }

                if (searchTxt != aTxt.FormerValue.ToLower())
                {
                    aTxt.FormerValue = aTxt.Text;

                }
            }
            catch
            {

            }
        }


       

   


        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4'
                    || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7'
                    || e.KeyChar == '8' || e.KeyChar == '9')
                {




                    AutoCompleteTextBox txtData = (AutoCompleteTextBox)sender;
                    if (txtData.Text.StartsWith("W1"))
                        return;



                    if (txtData.Text.Length > 4 && txtData.ListBoxElement.Visible == true && txtData.ListBoxElement.Items.Count < 10)
                    {
                        string idx = e.KeyChar.ToStr();

                        txtData.TextChanged -= new EventHandler(TextBoxElement_TextChanged);
                        string item = txtData.ListBoxElement.Items[idx.ToInt() - 1].ToStr();

                        string doorNo = string.Empty;
                        for (int i = 0; i <= 2; i++)
                        {
                            if (char.IsNumber(txtData.FormerValue[i]))
                                doorNo += txtData.FormerValue[i];
                            else
                                break;

                        }


                        if (AppVars.objPolicyConfiguration.StripDoorNoOnAddress.ToBool())
                        {
                            txtData.Text = (item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }
                        else
                        {

                            txtData.Text = (doorNo + " " + item.Remove(0, item.IndexOf('.') + 1).Trim()).Trim();
                        }


                        //if (txtData.Name == "txtFromAddress")
                        //{
                        //    SetPickupZone(txtData.Text);
                        //    FocusOnFromDoor();
                        //}
                        //else if (txtData.Name == "txtToAddress")
                        //{
                        //    SetDropOffZone(txtData.Text);
                        //    FocusOnToDoor();
                        //}
                        //else if (txtData.Name == "txtViaAddress")
                        //{
                        //    txtData.ResetListBox();
                        //    AddViaPoint();

                        //}
                        txtData.TextChanged += new EventHandler(TextBoxElement_TextChanged);
                        e.Handled = true;

                        aTxt.ResetListBox();
                        aTxt.ListBoxElement.Items.Clear();


                     //   UpdateAutoCalculateFares();
                        //   txtViaAddress.Focus();
                    }



                }
            }
            catch (Exception ex)
            {


            }
        }







        #endregion

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 603)
            {
               
                DefaultAdvancedView(true);

              

            }
            else
            {
              
                DefaultAdvancedView(false);
            
            }
        }
    }
}
