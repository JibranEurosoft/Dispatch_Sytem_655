using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using Telerik.WinControls.UI;
using Taxi_BLL;
using Taxi_Model;
using DAL;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls;
using System.Linq.Expressions;
using Telerik.Data;
using Taxi_AppMain.Classes;

namespace Taxi_AppMain
{
    public partial class frmInvoice : UI.SetupBase
    {

        RadDropDownMenu menu_Job = null;

        private string companyEmail;


        private bool AutoInc = true;

        InvoiceBO objMaster = null;
       
        public struct COLS
        {
            public static string ID = "ID";
            public static string InvoiceId = "InvoiceId";
            public static string BookingId = "BookingId";

            public static string PickupDate = "PickupDate";
            public static string Vehicle = "Vehicle";
            public static string VehicleID = "VehicleID";
            public static string OrderNo = "OrderNo";
            public static string PupilNo = "PupilNo";
            public static string BookedBy = "BookedBy";

            public static string RefNumber = "RefNumber";

            public static string Passenger = "Passenger";

            public static string PickupPoint = "PickupPoint";
            public static string Destination = "Destination";

            public static string Charges = "Charges";
            public static string BOOKINGFEE = "BookingFee";


            public static string Parking = "Parking";
            public static string Waiting = "Waiting";
            public static string ExtraDrop = "ExtraDrop";
            public static string MeetAndGreet = "MeetAndGreet";
            public static string CongtionCharge = "CongtionCharge";
            public static string RemovalDescription = "RemovalDescription";
            public static string Total = "Total";

            public static string Payment_ID = "Payment_ID";

            public static string PaymentTypeId = "PaymentTypeId";
            public static string BookingStatusId = "BookingStatusId";

            public static string WaitingTime = "WaitingTime";
            public static string ViaString = "ViaString";
            public static string ESCORTPRICE = "EscortPrice";
        }
        public frmInvoice()
        {
            InitializeComponent();
            InitializeConstructor();
           
           
        }

        public frmInvoice(int Id)
        {
            InitializeComponent();
            InitializeConstructor();
         
            ddlCompany.SelectedValue = Id;
        }


        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {
                GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                if (cell == null)
                    return;

                else if (cell.GridControl.Name == "grdLister")
                {

                    if (menu_Job == null)
                    {
                        menu_Job = new RadDropDownMenu();                      

                        RadMenuItem viewJobItem1 = new RadMenuItem("View Job");
                        viewJobItem1.ForeColor = Color.DarkBlue;
                        viewJobItem1.BackColor = Color.Orange;
                        viewJobItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);

                        viewJobItem1.Click += new EventHandler(viewJobItem1_Click);
                        menu_Job.Items.Add(viewJobItem1);             

                    }

                    e.ContextMenu = menu_Job;
                    return;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        void viewJobItem1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    General.ShowBookingForm(grdLister.CurrentRow.Cells[COLS.BookingId].Value.ToInt(), true, "", "", Enums.BOOKING_TYPES.LOCAL);

                }
            }
            catch 
            {
               // ENUtils.ShowMessage(ex.Message);

            }
        }

        private void InitializeConstructor()
        {


           var obj= General.GetObject<Gen_SysPolicy_DocumentNumberSetup>(c => c.DocumentId == Enums.GEN_DOCUMENTS.INVOICENO && (c.AutoIncrement == null || c.AutoIncrement == false));

           if (obj != null)
           {
               txtInvoiceNo.ReadOnly = false;
               txtInvoiceNo.Enabled = true;
               this.AutoInc = false;
           }

            this.ddlCompany.InitializeSettings();
          

            ComboFunctions.FillCompanyForInvoiceCombo(ddlCompany);
              ComboFunctions.FillAccountTypeCombo(ddlAccountType,null);


            ComboFunctions.FillSubCompanyNameCombo(ddlSubCompany);


            if (ddlSubCompany.Items.Count == 1)
            {
                ddlSubCompany.SelectedIndex = 0;
                ddlSubCompany.Enabled = false;

            }
            else
            {
               

               ddlSubCompany.SelectedValue = AppVars.objSubCompany.Id;
            }

            ddlAccountType.SelectedValue = Enums.BOOKING_TYPES.LOCAL;
          

            dtpInvoiceDate.Value = DateTime.Now.ToDate();
            dtpDueDate.Value = DateTime.Now.ToDate().AddMonths(1);
            FormatChargesGrid();

            grdLister.ShowGroupPanel = false;
           // grdLister.AutoCellFormatting = true;
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdLister.ShowRowHeaderColumn = false;

            objMaster = new InvoiceBO();
            this.SetProperties((INavigation)objMaster);

            grdLister.AllowAddNewRow = false;


            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTillDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.LastDayOfMonthValue());

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            grdLister.ContextMenuOpening+=new ContextMenuOpeningEventHandler(grdLister_ContextMenuOpening);

            grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);


            ddlDepartment.SelectedValueChanged += DdlDepartment_SelectedValueChanged;

        }

        private void DdlDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
              if(ddlDepartment.SelectedValue!=null)
            {
                try
                {
                    long Id = ddlDepartment.SelectedValue.ToLong();
                    string note = string.Empty;
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        note = db.ExecuteQuery<string>("select InvoiceNote from gen_company_departments where id=" + Id).FirstOrDefault();
                    }

                    txtNotes.Text = note;
                }
                catch
                {

                }


            }
        }

        void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == COLS.VehicleID && e.CellElement is GridDataCellElement && e.CellElement.Text == "")
            {

                e.CellElement.Text = e.Row.Cells[COLS.Vehicle].Value.ToStr();


            }
        }

        void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridCommandCellElement gridCell = (GridCommandCellElement)sender;
                if (gridCell.ColumnInfo.Name == "btnUpdate")
                {

                    GridViewRowInfo row = gridCell.RowInfo;

                    if (row is GridViewDataRowInfo)
                    {

                        long id = row.Cells[COLS.BookingId].Value.ToLong();
                        int vehicleTypeId = row.Cells[COLS.VehicleID].Value.ToInt();
                        int? waitingMins = null;
                        decimal fare = row.Cells[COLS.Charges].Value.ToDecimal();
                        decimal parking = row.Cells[COLS.Parking].Value.ToDecimal();
                        decimal waiting = row.Cells[COLS.Waiting].Value.ToDecimal();
                        decimal extraDrop = row.Cells[COLS.ExtraDrop].Value.ToDecimal();
                        decimal bookingFee = row.Cells[COLS.BOOKINGFEE].Value.ToDecimal();

                        decimal? escortprice = null;

                        if (grdLister.Columns[COLS.ESCORTPRICE].IsVisible)
                            escortprice = row.Cells[COLS.ESCORTPRICE].Value.ToDecimal();

                        decimal TotalCharges = row.Cells[COLS.Total].Value.ToDecimal();
                        string Destination = row.Cells[COLS.Destination].Value.ToStr();
                        string PickupPoint = row.Cells[COLS.PickupPoint].Value.ToStr();
                        string Passenger = row.Cells[COLS.Passenger].Value.ToStr();
               
                        int? invoicepaymentId = row.Cells[COLS.Payment_ID].Value.ToIntorNull();


                        if(grdLister.Columns[COLS.WaitingTime].IsVisible)
                        waitingMins = row.Cells[COLS.WaitingTime].Value.ToInt();

                        if (Destination == "")
                         {
                                RadMessageBox.Show("Required: Destination");
                                return;
                         }
                         if (PickupPoint == "")
                         {
                             RadMessageBox.Show("Required: PickupPoint");
                             return;
                         }                              

                        string orderNo = row.Cells[COLS.OrderNo].Value.ToStr();

                        BookingBO objMaster = new BookingBO();
                        objMaster.GetByPrimaryKey(id);

                        if (objMaster.Current != null)
                        {
                            objMaster.Current.CompanyPrice = fare;
                            objMaster.Current.ParkingCharges = parking;
                            objMaster.Current.WaitingCharges = waiting;
                            objMaster.Current.ExtraDropCharges = extraDrop;
                            objMaster.Current.ServiceCharges = bookingFee;

                            objMaster.Current.TotalCharges = TotalCharges;
                            objMaster.Current.InvoicePaymentTypeId = invoicepaymentId;

                            objMaster.Current.OrderNo = orderNo;

                            objMaster.Current.ToAddress = Destination;
                            objMaster.Current.FromAddress = PickupPoint;
                            objMaster.Current.CustomerName = Passenger;


                            if(waitingMins!=null)
                            objMaster.Current.DriverWaitingMins = waitingMins;

                            if (escortprice != null)
                                objMaster.Current.EscortPrice = escortprice;

                            if (vehicleTypeId != 0)
                             {
                                 objMaster.Current.VehicleTypeId = vehicleTypeId;
                             }

                              

                             objMaster.CheckCustomerValidation = false;
                             objMaster.CheckDataValidation = false;
                             objMaster.DisableUpdateReturnJob = true;
                             objMaster.Save();
                           

                            CalculateTotal();


                            long index = grdLister.CurrentRow != null ? grdLister.CurrentRow.Cells["Id"].Value.ToLong() : -1;
                            int val = grdLister.TableElement.VScrollBar.Value;


                            Save();


                            if (index > 0)
                                grdLister.CurrentRow = grdLister.Rows.FirstOrDefault(c => c.Cells["Id"].Value.ToLong() == index);

                            grdLister.TableElement.VScrollBar.Value = val;
                        }
                    }
                }
            }
            catch
            {



            }
           
        }


        string TemplateName = "13";

        private void FormatChargesGrid()
        {

            try
            {

                GridViewTextBoxColumn col = new GridViewTextBoxColumn();


                col.IsVisible = false;
                col.Name = "Id";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = COLS.InvoiceId;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = COLS.PaymentTypeId;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = COLS.BookingId;
                grdLister.Columns.Add(col);

                GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
                colDt.Name = "PickupDate";
                colDt.ReadOnly = true;
                colDt.HeaderText = "Pickup Date-Time";
                colDt.SortOrder = RadSortOrder.Ascending;
                colDt.Sort(RadSortOrder.Ascending, true);
                grdLister.Columns.Add(colDt);



                col = new GridViewTextBoxColumn();
                // col.IsVisible = false;
                col.ReadOnly = true;
                col.HeaderText = "Job #";
                col.Name = "RefNumber";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Order No";
                col.Name = "OrderNo";
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Booked By";
                col.Name = COLS.BookedBy;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Pupil No";
                col.Name = "PupilNo";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Vehicle";
                col.Name = "Vehicle";
                grdLister.Columns.Add(col);




                GridViewComboBoxColumn colCombo = new GridViewComboBoxColumn();
                colCombo.Name = COLS.VehicleID;
              //  colCombo.IsVisible = false;
                colCombo.HeaderText = "Vehicle";
                colCombo.DataSource = General.GetQueryable<Fleet_VehicleType>(null).OrderBy(c => c.OrderNo).Select(args => new { Id = args.Id, VehicleType = args.VehicleType }).ToList();
                colCombo.DisplayMember = "VehicleType";
                colCombo.ValueMember = "Id";
                colCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
                colCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                colCombo.ReadOnly = false;
               
                grdLister.Columns.Add(colCombo);




                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = COLS.BookingStatusId;
                col.Name =COLS.BookingStatusId;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.Name = COLS.Passenger;
                col.ReadOnly = true;
                col.HeaderText = "Passenger";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Width = 900;
                col.IsVisible = false;
                col.ReadOnly = true;
                col.Name = COLS.RemovalDescription;
                col.HeaderText = "Description";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.HeaderText = "Pickup Point";
                col.Name = "PickupPoint";
                col.ReadOnly = true;
                grdLister.Columns.Add(col);


                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.HeaderText = "Via(s)";
                col.Name = COLS.ViaString;
                col.ReadOnly = true;
                grdLister.Columns.Add(col);



                col = new GridViewTextBoxColumn();
                col.HeaderText = "Destination";
                col.Name = "Destination";
                col.ReadOnly = true;
                grdLister.Columns.Add(col);


                UM_Form_Template template = General.GetObject<UM_Form_Template>(c => c.FormId != null && c.UM_Form.FormName == "frmInvoiceReport" && c.IsDefault == true);

                if (template != null)
                {
                    TemplateName = template.TemplateName.ToStr().Trim();
                }


                GridViewDecimalColumn colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Fare";
                colD.Name = "Charges";
                colD.Maximum = 9999999;
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);

                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Parking";
                colD.Name = "Parking";
                colD.IsVisible = TemplateName != "Template13" && TemplateName != "Template24";
   
                colD.Maximum = 9999999;
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);

                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Booking Fee";
                colD.Name = COLS.BOOKINGFEE;
                colD.Maximum = 1000;
                colD.IsVisible = AppVars.objPolicyConfiguration.PickCommissionDeductionFromJobsTotal.ToBool();
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);



                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 0;
                colD.Minimum = 0;
                colD.HeaderText = "W/T";
                colD.Name = "WaitingTime";
                colD.Maximum = 9999999;
                colD.IsVisible = TemplateName == "Template50";


                colD.VisibleInColumnChooser = colD.IsVisible;
                //  colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);


                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Waiting";
                colD.Name = "Waiting";
                colD.Maximum = 9999999;
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);


                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Extra Charges";
                colD.Name = "ExtraDrop";
                colD.Maximum = 9999999;
                colD.IsVisible = true;
             //   colD.IsVisible = TemplateName != "Template13";


                // colD.IsVisible = !IsTemplate13;
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);





                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.HeaderText = "Escort Price";
                colD.Name = COLS.ESCORTPRICE;
                colD.Maximum = 1000;
                colD.IsVisible = TemplateName.ToLower() == "template52";
                colD.FormatString = "{0:#,###0.00}";
                grdLister.Columns.Add(colD);



                colD = new GridViewDecimalColumn();
                colD.DecimalPlaces = 2;
                colD.Minimum = 0;
                colD.ReadOnly = true;
                colD.HeaderText = "Total";
                colD.Name = "Total";
                colD.Maximum = 9999999;
                colD.Expression = "Charges+Parking+Waiting+ExtraDrop+BookingFee";
                colD.FormatString = "{0:#,###0.00}";

               
                colD.Expression = "Charges+Parking+Waiting+ExtraDrop+BookingFee";


                if (TemplateName.ToLower() == "template52")
                    colD.Expression = "Charges+Parking+Waiting+ExtraDrop+BookingFee+EscortPrice";

                grdLister.Columns["ExtraDrop"].IsVisible = true;
               




                grdLister.Columns.Add(colD);


                GridViewComboBoxColumn colPayment = new GridViewComboBoxColumn();
                colPayment.IsVisible = false;
                colPayment.Name = COLS.Payment_ID;
                colPayment.HeaderText = "Status";
                colPayment.DataSource = General.GetQueryable<Invoice_PaymentType>(null).Where(c => c.Id == 1 || c.Id == 3).OrderBy(c => c.Id).ToList();
                colPayment.DisplayMember = "PaymentType";
                colPayment.ValueMember = "Id";
                colPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
                colPayment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                colPayment.ReadOnly = false;
                grdLister.Columns.Add(colPayment);


                (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
                (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


                grdLister.Columns["PickUpDate"].Width = 105;
                grdLister.Columns["RefNumber"].Width = 40;
                grdLister.Columns["Vehicle"].Width = 50;

                grdLister.Columns[COLS.VehicleID].Width = 60;

                grdLister.Columns[COLS.Passenger].Width = 60;
                grdLister.Columns["PickUpPoint"].Width = 80;
                grdLister.Columns["Destination"].Width = 80;

                grdLister.Columns["Charges"].Width = 50;
                grdLister.Columns["Parking"].Width = 45;
                grdLister.Columns["Waiting"].Width = 50;
                grdLister.Columns["ExtraDrop"].Width = 60;
              //  grdLister.Columns["MeetAndGreet"].Width = 50;
              // // grdLister.Columns["CongtionCharge"].Width = 60;
                grdLister.Columns["Total"].Width = 45;
                grdLister.Columns["OrderNo"].Width = 55;

                grdLister.Columns["PickUpDate"].HeaderText = "Pickup Date-Time";
                grdLister.Columns["RefNumber"].HeaderText = "Ref #";
                grdLister.Columns["PickUpPoint"].HeaderText = "Pickup Point";
                grdLister.Columns["ExtraDrop"].HeaderText = "Extra Charges";

              //  grdLister.Columns["MeetAndGreet"].HeaderText = "M & G";
              //  grdLister.Columns["CongtionCharge"].HeaderText = "Congestion";
                grdLister.Columns["Payment_ID"].Width = 70;



                AddUpdateColumn(grdLister);


                ConditionalFormattingObject objPaid = new ConditionalFormattingObject();
                objPaid.ApplyToRow = true;
                objPaid.RowBackColor = Color.LightGreen;
                objPaid.ConditionType = ConditionTypes.Equal;
                objPaid.TValue1 = "6";
                objPaid.TValue2 = "6";
                grdLister.Columns["PaymentTypeId"].ConditionalFormattingObjectList.Add(objPaid);


                // NOPICKUP BOOKING COLOR
                ConditionalFormattingObject objNoPickup = new ConditionalFormattingObject();
                objNoPickup.ApplyToRow = true;
                objNoPickup.RowBackColor = Color.FromArgb(-32640);
                objNoPickup.ConditionType = ConditionTypes.Equal;
                objNoPickup.TValue1 = "13";
                objNoPickup.TValue2 = "13";
                grdLister.Columns[COLS.BookingStatusId].ConditionalFormattingObjectList.Add(objNoPickup);


                // CANCELLED BOOKING COLOR
                ConditionalFormattingObject objCancelled = new ConditionalFormattingObject();
                objCancelled.ApplyToRow = true;
                objCancelled.RowBackColor = Color.Pink;
                objCancelled.ConditionType = ConditionTypes.Equal;
                objCancelled.TValue1 = "3";
                objCancelled.TValue2 = "3";
                grdLister.Columns[COLS.BookingStatusId].ConditionalFormattingObjectList.Add(objCancelled);



                grdLister.CellBeginEdit += new GridViewCellCancelEventHandler(grdLister_CellBeginEdit);
                grdLister.MultiSelect = true;


                if (TemplateName.ToStr().ToLower().Trim() == "template15" || TemplateName.ToStr().ToLower().Trim() == "template10" || TemplateName.ToStr().ToLower().Trim() == "template32" || TemplateName == "Template45"
                    
                    || TemplateName == "Template48" || TemplateName == "Template50" )
                {
                    ddlSplitBy.Visible = true;
                    lblSplitBy.Visible = true;
                    if (TemplateName.ToStr().ToLower().Trim() == "template10" || TemplateName.ToStr().ToLower().Trim() == "template32" || TemplateName == "Template45" || TemplateName == "Template48"
                    || TemplateName == "Template50" )
                    {
                        ddlSplitBy.Items.RemoveAt(2);
                    }


                    if (TemplateName == "Template50")
                    {
                        grdLister.Columns[COLS.ViaString].IsVisible = true;
                    }

                }




            }
            catch 
            {

            }



        }


        List<Fleet_VehicleType> listofVehicles = null;

        void grdLister_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            try
            {

                if (e.Column is GridViewComboBoxColumn)
                {

                    if (listofVehicles == null)
                    {

                        listofVehicles = (List<Fleet_VehicleType>)(e.Column as GridViewComboBoxColumn).DataSource;
                    }


                    e.Row.Cells[COLS.VehicleID].Value = listofVehicles.FirstOrDefault(c => c.VehicleType.ToStr().ToUpper() == e.Row.Cells[COLS.Vehicle].Value.ToStr().ToUpper()).DefaultIfEmpty().Id;







                }
            }
            catch 
            {


            }
        }

        protected override void OnClosed(EventArgs e)
        {
            General.RefreshListWithoutSelected<frmCompanyInvoiceList>("frmCompanyInvoiceList1");

        }


        public override void Save()
        {

            OnSave();
        }


        private void OnSave()
        {

            try
            {

                if (this.AutoInc == false && txtInvoiceNo.Text.Trim() == string.Empty)
                {
                    ENUtils.ShowMessage("Required : Invoice No");
                    return;

                }



                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();
                  //  objMaster.Current.InvoicePaymentTypeID = 1;
                    objMaster.Current.AddOn = DateTime.Now;
                    objMaster.Current.AddBy = AppVars.LoginObj.LuserId.ToIntorNull();
                    objMaster.Current.AddLog = AppVars.LoginObj.UserName.ToStr();
                }
                else
                {
                    objMaster.Edit();

                    objMaster.Current.EditOn = DateTime.Now;
                    objMaster.Current.EditBy = AppVars.LoginObj.LuserId.ToIntorNull();
                    objMaster.Current.EditLog = AppVars.LoginObj.UserName.ToStr();
                }

                objMaster.Current.BookingTypeId = ddlAccountType.SelectedValue.ToInt();
                objMaster.Current.InvoiceDate = dtpInvoiceDate.Value.ToDate();
                objMaster.Current.CompanyId = ddlCompany.SelectedValue.ToIntorNull();
                objMaster.Current.DepartmentId = ddlDepartment.SelectedValue.ToLongorNull();
                objMaster.Current.DepartmentWise = chkDepartmentWise.Checked;

              //  objMaster.Current.CostCenterId=ddlCostCenter.SelectedValue.ToIntorNull();
               // objMaster.Current.CostCenterWise=chkCostCenterWise.Checked;
                objMaster.Current.DueDate = dtpDueDate.Value.ToDate();


                objMaster.Current.Remarks = txtNotes.Text.Trim();

                try
                {
                    if (dtpDueDate.Value == null)
                    {
                        objMaster.Current.DueDate = objMaster.Current.InvoiceDate.Value.AddDays(30).ToDate();
                    }
                    else
                    {
                        objMaster.Current.DueDate = dtpDueDate.Value.ToDate();

                    }
                    if (chkAllFromDate.Checked)
                    {
                        objMaster.Current.FromDate = grdLister.Rows.Select(c => c.Cells[COLS.PickupDate].Value.ToDate()).OrderBy(c => c.Date).FirstOrDefault().ToDate();

                    }
                    else
                    {

                        objMaster.Current.FromDate = dtpFromDate.Value.ToDate();

                    }

                    if (dtpTillDate.Value == null)
                    {

                        objMaster.Current.TillDate = grdLister.Rows.Select(c => c.Cells[COLS.PickupDate].Value.ToDate()).OrderByDescending(c => c.Date).FirstOrDefault().ToDate();
                    }
                    else
                    {
                        objMaster.Current.TillDate = dtpTillDate.Value.ToDate();
                    }
                }
                catch
                {

                }

                objMaster.Current.InvoiceNo = txtInvoiceNo.Text.Trim();
                objMaster.Current.InvoiceTypeId = Enums.INVOICE_TYPE.ACCOUNT;

                objMaster.Current.InvoiceTotal = grdLister.Rows.Where(c=>c.Cells[COLS.PaymentTypeId].Value.ToInt()!=6)
                                    .Sum(c => c.Cells[COLS.Total].Value.ToDecimal());

                objMaster.Current.TotalInvoiceAmount = grdLister.Rows.Where(c => c.Cells[COLS.PaymentTypeId].Value.ToInt() != 6)
                                .Sum(c => c.Cells[COLS.Parking].Value.ToDecimal()+c.Cells[COLS.ExtraDrop].Value.ToDecimal());


                objMaster.Current.SubCompanyId = ddlSubCompany.SelectedValue.ToIntorNull();



            //   var distinctRows= grdLister.Rows.Select(c => c.Cells[COLS.BookingId].ToLong()).Distinct();

                objMaster.Current.OrderNo = txtOrderNo.Text.Trim();
               
             


                string[] skipProperties = { "Invoice", "Booking" };
                IList<Invoice_Charge> savedList = objMaster.Current.Invoice_Charges;
                List<Invoice_Charge> listofDetail = (from r in grdLister.Rows

                                                     select new Invoice_Charge
                                                            {
                                                                Id = r.Cells[COLS.ID].Value.ToLong(),
                                                                InvoiceId = r.Cells[COLS.InvoiceId].Value.ToLong(),
                                                                BookingId = r.Cells[COLS.BookingId].Value.ToLongorNull(),

                                                            }).ToList();


                Utils.General.SyncChildCollection(ref savedList, ref listofDetail, "Id", skipProperties);

                objMaster.Save();

                objMaster.GetByPrimaryKey(objMaster.PrimaryKeyValue);
                DisplayRecord();


            }
            catch (Exception ex)
            {
                if (objMaster.Errors.Count > 0)
                    ENUtils.ShowMessage(objMaster.ShowErrors());
                else
                {
                    ENUtils.ShowMessage(ex.Message);

                }
            }

        }


        public override void DisplayRecord()
        {
            try
            {


                if (objMaster.Current == null) return;

                
                btnExportPDF.Enabled = true;
                btnPrint.Enabled = true;
                btnSendEmail.Enabled = true;
               
                if (AppVars.listUserRights.Count(c => c.functionId == "EXPORT INVOICE BOOKING") > 0)
                {
                    btnExportToExcel2.Visible = true;
                    btnExportExcel.Visible = false;
                    btnExportToExcel2.Enabled = true;
                }
                else
                {
                    btnExportToExcel2.Visible = false;
                    btnExportExcel.Visible = true;
                    btnExportExcel.Enabled = true;
                }

                 
                txtInvoiceNo.ReadOnly = false;
                txtInvoiceNo.Text = objMaster.Current.InvoiceNo.ToStr();
                dtpInvoiceDate.Value = objMaster.Current.InvoiceDate.ToDate();


                txtNotes.Text = objMaster.Current.Remarks.ToStr();


                if (objMaster.Current.CompanyId != null)
                {

                    //var data = (List<Gen_Company>)ddlCompany.DataSource;
                    //data.Add(objMaster.Current.Gen_Company);
                    if (objMaster.Current.Gen_Company.IsClosed.ToBool())
                    {
                        ComboFunctions.FillCompanyForInvoiceCombo(ddlCompany, objMaster.Current.CompanyId.ToInt());
                    }

                }

                ddlCompany.SelectedValue = objMaster.Current.CompanyId;
                ddlCompany.Enabled = false;
                dtpDueDate.Value = objMaster.Current.DueDate.ToDate();
                ddlDepartment.SelectedValue = objMaster.Current.DepartmentId;
                chkDepartmentWise.Checked = objMaster.Current.DepartmentWise.ToBool();

              


                ddlSubCompany.SelectedValue = objMaster.Current.SubCompanyId;


                dtpFromDate.Value = objMaster.Current.FromDate.ToDateorNull();
                dtpTillDate.Value = objMaster.Current.TillDate.ToDateorNull();

                txtOrderNo.Text = objMaster.Current.OrderNo.ToStr().Trim();

                List<stp_GetInvoiceBookingsResultEx> list = null;

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    list = db.ExecuteQuery<stp_GetInvoiceBookingsResultEx>("exec stp_GetInvoiceBookings {0}",objMaster.Current.Id).ToList();
                }


                grdLister.RowCount = list.Count;
                grdLister.BeginUpdate();

                for (int i = 0; i < list.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.ID].Value = list[i].Id;
                    grdLister.Rows[i].Cells[COLS.InvoiceId].Value = list[i].InvoiceId;
                    grdLister.Rows[i].Cells[COLS.BookingId].Value = list[i].BookingId;




                    grdLister.Rows[i].Cells[COLS.Payment_ID].Value = list[i].InvoicePaymentTypeId;
                    grdLister.Rows[i].Cells[COLS.PickupDate].Value = list[i].PickupDateTime;
                    grdLister.Rows[i].Cells[COLS.OrderNo].Value = list[i].OrderNo;
                    grdLister.Rows[i].Cells[COLS.PupilNo].Value = list[i].PupilNo;

                    grdLister.Rows[i].Cells[COLS.BookedBy].Value = list[i].DepartmentName.ToStr();
                    //
                    grdLister.Rows[i].Cells[COLS.VehicleID].Value = list[i].VehicleTypeId.ToInt();

                    grdLister.Rows[i].Cells[COLS.Vehicle].Value = list[i].VehicleType;


                    grdLister.Rows[i].Cells[COLS.RefNumber].Value = list[i].BookingNo;

                    grdLister.Rows[i].Cells[COLS.Charges].Value = list[i].CompanyPrice.ToDecimal();


                    grdLister.Rows[i].Cells[COLS.Parking].Value = list[i].ParkingCharges.ToDecimal();
                    grdLister.Rows[i].Cells[COLS.PickupPoint].Value = list[i].FromAddress.ToStr();
                    grdLister.Rows[i].Cells[COLS.Destination].Value = list[i].ToAddress.ToStr();
                    grdLister.Rows[i].Cells[COLS.Waiting].Value = list[i].WaitingCharges.ToDecimal();

                    grdLister.Rows[i].Cells[COLS.ExtraDrop].Value = list[i].ExtraDropCharges.ToDecimal();

                    grdLister.Rows[i].Cells[COLS.BOOKINGFEE].Value = list[i].BookingFee.ToDecimal();

                  
                    grdLister.Rows[i].Cells[COLS.Total].Value = list[i].CompanyPrice.ToDecimal() + list[i].WaitingCharges.ToDecimal() + list[i].ParkingCharges.ToDecimal() + list[i].ExtraDropCharges.ToDecimal() + list[i].BookingFee.ToDecimal()+list[i].EscortPrice.ToDecimal();
                    

                    grdLister.Rows[i].Cells[COLS.Passenger].Value = list[i].CustomerName.ToStr().Trim();
                    grdLister.Rows[i].Cells[COLS.PaymentTypeId].Value = list[i].PaymentTypeId.ToInt();

                    grdLister.Rows[i].Cells[COLS.BookingStatusId].Value = list[i].BookingStatusId.ToInt();

                    grdLister.Rows[i].Cells[COLS.WaitingTime].Value = list[i].WaitingTime.ToInt();

                    grdLister.Rows[i].Cells[COLS.ViaString].Value = list[i].ViaString.ToStr();
                    grdLister.Rows[i].Cells[COLS.ESCORTPRICE].Value = list[i].EscortPrice.ToDecimal();
                }


                grdLister.CurrentRow = null;

                grdLister.EndUpdate();

                grdLister.ReadOnly = false;
                grdLister.AllowEditRow = true;

                txtInvoiceAmount.Text = objMaster.Current.InvoiceTotal.ToDecimal().ToStr();

                ShowAutoContinue();
                btnCreditNote.Visible = true;


                using (TaxiDataContext db = new TaxiDataContext())
                {

                    bool creditNotExist = db.InvoiceCreditNotes.Count(c => c.InvoiceId == objMaster.Current.Id) > 0;


                    if (creditNotExist)
                    {

                        btnCreditNote.BackColor = Color.LightGreen;
                        this.btnCreditNote.ContextMenuStrip = this.contextMenuCreditNote;

                    }

                    DisplaySummary(objMaster.Current.CompanyId.ToInt(), db);

                }

                ddlAccountType.SelectedValue = objMaster.Current.BookingTypeId;

            }
            catch
            {



            }

        }

        private void DisplaySummary(int companyId, TaxiDataContext db)
        {

            try
            {
                if (companyId != 0)
                {

                    var objCompany = db.Gen_Companies.Where(c => c.Id == companyId)
                         .Select(args => new { args.VatOnlyOnAdminFees, args.AdminFees, args.AdminFeeType, args.HasVat, args.DiscountPercentage }).FirstOrDefault();

                    if (objCompany != null)
                    {

                        decimal invoiceTotal = objMaster.Current.InvoiceTotal.ToDecimal();
                        decimal valueAddedTax = 0.00m;
                        decimal discountAmount = 0.00m;
                        decimal AdminFees = 0.00m;
                        decimal extras = 0.00m;




                       
                            if (TemplateName.ToLower() == "template10")
                            {
                                extras= grdLister.Rows.Sum(c => c.Cells[COLS.Parking].Value.ToDecimal() + c.Cells[COLS.ExtraDrop].Value.ToDecimal());

                                invoiceTotal = invoiceTotal - extras;

                            }

                       

                        if (objCompany.AdminFees > 0)
                        {


                            if (objCompany.AdminFeeType.ToStr().ToLower() == "percent")
                                AdminFees = (invoiceTotal * objCompany.AdminFees.ToDecimal()) / 100;
                            else
                                AdminFees = objCompany.AdminFees.ToDecimal();


                            AdminFees = Math.Round(AdminFees, 2);

                        }

                        if (objCompany.DiscountPercentage.ToDecimal() > 0)
                        {
                            discountAmount = (invoiceTotal * objCompany.DiscountPercentage.ToDecimal()) / 100;
                            // DiscountPercent = objCompany.DiscountPercentage.ToDecimal();
                            invoiceTotal = invoiceTotal - discountAmount;
                        }


                        if (objCompany.HasVat.ToBool())
                        {





                            if (objCompany.VatOnlyOnAdminFees.ToBool())
                            {
                                valueAddedTax = (AdminFees.ToDecimal() * 20) / 100;

                            }
                            else
                                valueAddedTax = ((invoiceTotal+ AdminFees) * 20) / 100;


                            valueAddedTax = Math.Round(valueAddedTax, 2);
                        }

                     


                    


                        decimal grandTotal =Math.Round ( ( (invoiceTotal + valueAddedTax + extras+ AdminFees) ).ToDecimal(),2);



                        txtNet.Text = string.Format("{0:f2}", invoiceTotal);
                        txtVat.Text = string.Format("{0:f2}", valueAddedTax);
                        txtAdminFee.Text = string.Format("{0:f2}", AdminFees);
                        txtInvoiceAmount.Text = string.Format("{0:f2}", grandTotal);


                        if(extras>0)
                        {
                            lblExtras.Visible = true;
                            numExtras.Visible = true;
                            numExtras.Text = string.Format("{0:f2}", extras);

                        }
                        else
                        {
                            lblExtras.Visible = false;
                            numExtras.Visible = false;
                        }

                       

                        if (valueAddedTax==0)
                        {
                            lblVat.Visible = false;
                            txtVat.Visible = false;

                        }
                        else
                        {
                            lblVat.Visible = true;
                            txtVat.Visible = true;

                        }

                        if (AdminFees==0)
                        {
                            lblAdminfee.Visible = false;
                            txtAdminFee.Visible = false;
                        }
                        else
                        {

                            lblAdminfee.Visible = true;
                            txtAdminFee.Visible = true;
                        }

                        if(invoiceTotal==grandTotal && valueAddedTax==0)
                        {
                            lblNet.Visible = false;
                            txtNet.Visible = false;

                        }
                        else
                        {
                            lblNet.Visible = true;
                            txtNet.Visible = true;
                        }


                    }

                }
            }
            catch
            {

            }
        }


        private void ShowAutoContinue()
        {

            if (ddlDepartment.SelectedValue != null)
            {
                chkAutoContinue.Visible = true;
                chkAutoContinue.Checked = true;
            }
        }

        private void AddUpdateColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 50;
            
            col.Name = "btnUpdate";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Update";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }

        private void AutoPickUp()
        {
            try
            {
                int companyId = ddlCompany.SelectedValue.ToInt();

                DateTime? fromDate = dtpFromDate.Value.ToDate();
                DateTime? tillDate = dtpTillDate.Value.ToDate();

                long departmentId = ddlDepartment.SelectedValue.ToLong();
              

                string error = string.Empty;
                if (companyId == 0)
                {
                    error += "Required : Company";
                }

                if (fromDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : From Date";
                }

                if (tillDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : To Date";


                }

                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;

                }



                string[] hiddenColumns = null;


                hiddenColumns = new string[] {  "Id", "CompanyId","CompanyName","Parking","Destination","Waiting","ExtraDrop","MeetAndGreet","Congtion",
                                                "Total","OrderNo","PupilNo","BookingDate","Description","Fare","AccountType","PaymentTypeId"};



                bool IsDepartmentWise = chkDepartmentWise.Checked;
             
                string orderNo = ddlOrderNo.SelectedValue.ToStr().Trim();


                Func<Booking, bool> _conditionDate = null;
                if (ddlPickType.SelectedIndex == 0)
                    _conditionDate = b => b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate;
                else
                    _conditionDate = b => b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate;


                bool ForProcessedJobs = AppVars.objPolicyConfiguration.RentForProcessedJobs.ToBool();





                Expression<Func<Booking,bool>> expPickBooking=null;
                Expression<Func<Invoice_Charge, bool>> _invoiceCondition = null;

                if(AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt()==0 || AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt()==1)
                {
                    expPickBooking = c => c.CompanyId == companyId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED) && (orderNo == "" || c.OrderNo == orderNo)
                                                                           && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
;
                }
                else if(AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt()==2) // Pick DISPATCHED AND NOPICKUP BOOKINGS
                {
                    expPickBooking = c => c.CompanyId == companyId &&
                                       (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || (c.PaymentTypeId != Enums.PAYMENT_TYPES.CASH && c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP))
                                     && (orderNo == "" || c.OrderNo == orderNo)
                                     && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
                                   ;

                                                                                                             



                }
                else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 3)
                {
                    expPickBooking = c => c.CompanyId == companyId && c.PaymentTypeId == Enums.PAYMENT_TYPES.BANK_ACCOUNT && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED) && (orderNo == "" || c.OrderNo == orderNo)
                                                                           && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
                       ;

                                                                                                             
                }
                else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 4) // Pick DISPATCHED AND NOPICKUP and cancelled BOOKINGS
                {
                    expPickBooking = c => c.CompanyId == companyId &&
                                       (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || ( c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP) || (c.BookingStatusId == Enums.BOOKINGSTATUS.CANCELLED))
                                     && (orderNo == "" || c.OrderNo == orderNo)
                                     && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
                                   ;





                }

                string templateName = "Template13";
                UM_Form_Template template = General.GetObject<UM_Form_Template>(c => c.FormId != null && c.UM_Form.FormName == "frmInvoiceReport" && c.IsDefault == true);



                if (template != null)
                {

                    TemplateName = template.TemplateName.ToStr().Trim();

                }
                GridViewRowInfo row;
                if (templateName == "Template13")
                {

                    var list1 = General.GetGeneralList<Booking>(expPickBooking).Where(_conditionDate);
                    var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                    var list = (from b in list1
                                join c in list2 on b.Id equals c.BookingId into table2
                                from c in table2.DefaultIfEmpty()
                                where (c == null)
                                select new
                                {
                                    Id = b.Id,


                                    BookingDate = b.BookingDate,
                                    PickupDate = b.PickupDateTime,

                                    RefNo = b.BookingNo,
                                    Vehicle = b.Fleet_VehicleType.VehicleType,
                                    OrderNo = b.OrderNo,
                                    PupilNo = b.PupilNo,
                                    Passenger = b.CustomerName,
                                    PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                    Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                    //  Charges = b.FareRate.ToDecimal(),
                                    Charges = b.CompanyPrice.ToDecimal(),
                                    CompanyId = b.CompanyId,
                                    CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                    Parking = b.ParkingCharges.ToDecimal(),
                                    Waiting = b.WaitingCharges.ToDecimal(),
                                    ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                    MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                    Congtion = b.CongtionCharges.ToDecimal(),
                                    Description = "",
                                    Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal()),
                                    //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                    BookedBy = b.BookedBy.ToStr(),
                                    Fare = b.FareRate.ToDecimal(),

                                    AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                    PaymentTypeId = b.PaymentTypeId,
                                    BookingStatusId = b.BookingStatusId.ToIntorNull()
                                }).ToList();


                    int cnt = list.Count;
                    grdLister.Rows.Clear();
                    
                    for (int i = 0; i < cnt; i++)
                    {

                        row = grdLister.Rows.AddNew();
                        row.Cells[COLS.BookingId].Value = list[i].Id.ToLongorNull();
                        row.Cells[COLS.RefNumber].Value = list[i].RefNo.ToStr();
                        row.Cells[COLS.PickupDate].Value = list[i].PickupDate.ToDateTime();
                        row.Cells[COLS.Vehicle].Value = list[i].Vehicle.ToStr();

                        row.Cells[COLS.OrderNo].Value = list[i].OrderNo.ToStr();
                        row.Cells[COLS.PupilNo].Value = list[i].PupilNo.ToStr();

                        row.Cells[COLS.Passenger].Value = list[i].Passenger.ToStr();
                        row.Cells[COLS.PickupPoint].Value = list[i].PickupPoint.ToStr();
                        row.Cells[COLS.Destination].Value = list[i].Destination.ToStr();
                        row.Cells[COLS.Charges].Value = list[i].Charges.ToDecimal();
                        row.Cells[COLS.Parking].Value = list[i].Parking.ToDecimal();
                        row.Cells[COLS.Waiting].Value = list[i].Waiting.ToDecimal();
                        row.Cells[COLS.ExtraDrop].Value = list[i].ExtraDrop.ToDecimal();

                        row.Cells[COLS.Total].Value = list[i].Total.ToDecimal();

                        row.Cells[COLS.RemovalDescription].Value = list[i].Destination.ToStr();

                        row.Cells[COLS.BookedBy].Value = list[i].BookedBy.ToStr();

                        row.Cells[COLS.PaymentTypeId].Value = list[i].PaymentTypeId.ToInt();

                        row.Cells[COLS.BookingStatusId].Value = list[i].BookingStatusId.ToInt();
                    }
                }
                else if (templateName == "Template14" || templateName == "Template23")
                {
                    var list1 = General.GetGeneralList<Booking>(expPickBooking).Where(_conditionDate);
                    var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                    var list = (from b in list1
                                join c in list2 on b.Id equals c.BookingId into table2
                                from c in table2.DefaultIfEmpty()
                                where (c == null)
                                select new
                                {
                                    Id = b.Id,


                                    BookingDate = b.BookingDate,
                                    PickupDate = b.PickupDateTime,

                                    RefNo = b.BookingNo,
                                    Vehicle = b.Fleet_VehicleType.VehicleType,
                                    OrderNo = b.OrderNo,
                                    PupilNo = b.PupilNo,
                                    Passenger = b.CustomerName,
                                    PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                    Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                    //  Charges = b.FareRate.ToDecimal(),
                                    Charges = b.CompanyPrice.ToDecimal(),
                                    CompanyId = b.CompanyId,
                                    CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                    Parking = b.ParkingCharges.ToDecimal(),
                                    Waiting = b.WaitingCharges.ToDecimal(),
                                    ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                    MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                    Congtion = b.CongtionCharges.ToDecimal(),
                                    Description = "",
                                    Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal() + b.ParkingCharges.ToDecimal() + b.ExtraDropCharges.ToDecimal()),
                                    //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                    BookedBy = b.BookedBy.ToStr(),
                                    Fare = b.FareRate.ToDecimal(),

                                    AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                    PaymentTypeId = b.PaymentTypeId,
                                    BookingStatusId = b.BookingStatusId.ToIntorNull()
                                }).ToList();
                    int cnt = list.Count;
                    grdLister.Rows.Clear();

                    for (int i = 0; i < cnt; i++)
                    {

                        row = grdLister.Rows.AddNew();
                        row.Cells[COLS.BookingId].Value = list[i].Id.ToLongorNull();
                        row.Cells[COLS.RefNumber].Value = list[i].RefNo.ToStr();
                        row.Cells[COLS.PickupDate].Value = list[i].PickupDate.ToDateTime();
                        row.Cells[COLS.Vehicle].Value = list[i].Vehicle.ToStr();

                        row.Cells[COLS.OrderNo].Value = list[i].OrderNo.ToStr();
                        row.Cells[COLS.PupilNo].Value = list[i].PupilNo.ToStr();

                        row.Cells[COLS.Passenger].Value = list[i].Passenger.ToStr();
                        row.Cells[COLS.PickupPoint].Value = list[i].PickupPoint.ToStr();
                        row.Cells[COLS.Destination].Value = list[i].Destination.ToStr();
                        row.Cells[COLS.Charges].Value = list[i].Charges.ToDecimal();
                        row.Cells[COLS.Parking].Value = list[i].Parking.ToDecimal();
                        row.Cells[COLS.Waiting].Value = list[i].Waiting.ToDecimal();
                        row.Cells[COLS.ExtraDrop].Value = list[i].ExtraDrop.ToDecimal();

                        row.Cells[COLS.Total].Value = list[i].Total.ToDecimal();

                        row.Cells[COLS.RemovalDescription].Value = list[i].Destination.ToStr();

                        row.Cells[COLS.BookedBy].Value = list[i].BookedBy.ToStr();

                        row.Cells[COLS.PaymentTypeId].Value = list[i].PaymentTypeId.ToInt();

                        row.Cells[COLS.BookingStatusId].Value = list[i].BookingStatusId.ToInt();
                    }
                }
                else
                {
                    var list1 = General.GetGeneralList<Booking>(expPickBooking).Where(_conditionDate);
                    var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                    var list = (from b in list1
                                join c in list2 on b.Id equals c.BookingId into table2
                                from c in table2.DefaultIfEmpty()
                                where (c == null)
                                select new
                                {
                                    Id = b.Id,
                                    BookingDate = b.BookingDate,
                                    PickupDate = b.PickupDateTime,
                                    RefNo = b.BookingNo,
                                    Vehicle = b.Fleet_VehicleType.VehicleType,
                                    OrderNo = b.OrderNo,
                                    PupilNo = b.PupilNo,
                                    Passenger = b.CustomerName,
                                    PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                    Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                    //  Charges = b.FareRate.ToDecimal(),
                                    Charges = b.CompanyPrice.ToDecimal(),
                                    CompanyId = b.CompanyId,
                                    CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                    Parking = b.ParkingCharges.ToDecimal(),
                                    Waiting = b.WaitingCharges.ToDecimal(),
                                    ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                    MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                    Congtion = b.CongtionCharges.ToDecimal(),
                                    Description = "",
                                    Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal() + b.ParkingCharges.ToDecimal()),
                                    //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                    BookedBy = b.BookedBy.ToStr(),
                                    Fare = b.FareRate.ToDecimal(),

                                    AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                    PaymentTypeId = b.PaymentTypeId,
                                    BookingStatusId = b.BookingStatusId.ToIntorNull()
                                }).ToList();
                    int cnt = list.Count;
                    grdLister.Rows.Clear();

                    for (int i = 0; i < cnt; i++)
                    {

                        row = grdLister.Rows.AddNew();
                        row.Cells[COLS.BookingId].Value = list[i].Id.ToLongorNull();
                        row.Cells[COLS.RefNumber].Value = list[i].RefNo.ToStr();
                        row.Cells[COLS.PickupDate].Value = list[i].PickupDate.ToDateTime();
                        row.Cells[COLS.Vehicle].Value = list[i].Vehicle.ToStr();

                        row.Cells[COLS.OrderNo].Value = list[i].OrderNo.ToStr();
                        row.Cells[COLS.PupilNo].Value = list[i].PupilNo.ToStr();

                        row.Cells[COLS.Passenger].Value = list[i].Passenger.ToStr();
                        row.Cells[COLS.PickupPoint].Value = list[i].PickupPoint.ToStr();
                        row.Cells[COLS.Destination].Value = list[i].Destination.ToStr();
                        row.Cells[COLS.Charges].Value = list[i].Charges.ToDecimal();
                        row.Cells[COLS.Parking].Value = list[i].Parking.ToDecimal();
                        row.Cells[COLS.Waiting].Value = list[i].Waiting.ToDecimal();
                        row.Cells[COLS.ExtraDrop].Value = list[i].ExtraDrop.ToDecimal();

                        row.Cells[COLS.Total].Value = list[i].Total.ToDecimal();

                        row.Cells[COLS.RemovalDescription].Value = list[i].Destination.ToStr();

                        row.Cells[COLS.BookedBy].Value = list[i].BookedBy.ToStr();

                        row.Cells[COLS.PaymentTypeId].Value = list[i].PaymentTypeId.ToInt();

                        row.Cells[COLS.BookingStatusId].Value = list[i].BookingStatusId.ToInt();
                    }
                }
                CalculateTotal();              

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
            }
        
        }
        private void btnPickBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //   int bookingTypeId = ddlBookingType.SelectedValue.ToInt();
                int companyId = ddlCompany.SelectedValue.ToInt();

                DateTime? fromDate = dtpFromDate.Value.ToDate();
                DateTime? tillDate = dtpTillDate.Value.ToDate() + new TimeSpan(23,59,59);

                if (chkAllFromDate.Checked)
                    fromDate = new DateTime(DateTime.Now.Year - 1, 1, 1);

                long departmentId = ddlDepartment.SelectedValue.ToLong();
               

                string error = string.Empty;
                if (companyId == 0)
                {
                    error += "Required : Company";
                }

                if (fromDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : From Date";
                }

                if (tillDate == null)
                {
                    if (string.IsNullOrEmpty(error))
                        error += Environment.NewLine;

                    error += "Required : To Date";


                }

                if (!string.IsNullOrEmpty(error))
                {
                    ENUtils.ShowMessage(error);
                    return;

                }



                string[] hiddenColumns = null;


                hiddenColumns = new string[] {  "Id", "CompanyId","CompanyName","Parking","Destination","Waiting","ExtraDrop","MeetAndGreet","Congtion",
                                                "Total","OrderNo","PupilNo","BookingDate","Description","Fare","AccountType","PaymentTypeId","BookingStatusId","BookingFee","WaitingTime"};



                bool IsDepartmentWise = chkDepartmentWise.Checked;
           

                string orderNo = ddlOrderNo.SelectedValue.ToStr().Trim();


                if (ddlOrderNo.Visible == false && txtOrderNo.Visible == true && orderNo.Length == 0 && txtOrderNo.Text.Length > 0)
                {
                    orderNo = txtOrderNo.Text.Trim();
                }

                Func<Booking, bool> _conditionDate = null;
                if (ddlPickType.SelectedIndex == 0)
                    _conditionDate = b => b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate;
                else
                    _conditionDate = b => b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate;


                bool ForProcessedJobs = AppVars.objPolicyConfiguration.RentForProcessedJobs.ToBool();
                
                Expression<Func<Booking,bool>> expPickBooking=null;


                if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 0 || AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 1)
                {
                    expPickBooking = c => c.CompanyId == companyId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED) && (orderNo == "" || c.OrderNo == orderNo)
                                                                           && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
                                                                          ;


                }
                else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 2) // Pick DISPATCHED AND NOPICKUP BOOKINGS
                {

               
                  
                        expPickBooking = c => c.CompanyId == companyId &&
                                           (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP)
                                          && (c.PickupDateTime >= fromDate && c.PickupDateTime <= tillDate)
                                           && (orderNo == "" || c.OrderNo == orderNo)
                                           && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false));

                   

                }
                else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 3)
                {
                    expPickBooking = c => c.CompanyId == companyId && c.PaymentTypeId == Enums.PAYMENT_TYPES.BANK_ACCOUNT && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED) && (orderNo == "" || c.OrderNo == orderNo)
                                                                           && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
                             ;


                }
                else if (AppVars.objPolicyConfiguration.PickBookingOnInvoicingType.ToInt() == 4) // Pick DISPATCHED AND NOPICKUP BOOKINGS
                {



                    expPickBooking = c => c.CompanyId == companyId &&
                                       (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED || c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || c.BookingStatusId == Enums.BOOKINGSTATUS.CANCELLED) 
                                      && (c.PickupDateTime >= fromDate && c.PickupDateTime <= tillDate)
                                       && (orderNo == "" || c.OrderNo == orderNo)
                                       && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false));



                }






                List<object[]> list = ShowBookingMultiLister(expPickBooking,a => a.Invoice.InvoiceTypeId!=Enums.INVOICE_TYPE.ESCORT_INVOICE , hiddenColumns, _conditionDate, TemplateName.ToStr());
                GridViewRowInfo row;

                int cnt = list.Count;


             

                var existBookingId = grdLister.Rows.Select(c => c.Cells[COLS.BookingId].Value.ToLong()).ToList<long>();
            
               list.RemoveAll(c => existBookingId.Contains(c[0].ToLong()));

                cnt = list.Count;

                for (int i = 0; i < cnt; i++)
                {
                  

                    row = grdLister.Rows.AddNew();


                    row.Cells[COLS.BookingId].Value = list[i][0].ToLongorNull();
                    row.Cells[COLS.RefNumber].Value = list[i][3].ToStr();
                    row.Cells[COLS.PickupDate].Value = list[i][2].ToDateTime();


                    row.Cells[COLS.Vehicle].Value = list[i][4].ToStr();




                    row.Cells[COLS.OrderNo].Value = list[i][5].ToStr();
                    row.Cells[COLS.PupilNo].Value = list[i][6].ToStr();

                    row.Cells[COLS.Passenger].Value = list[i][7].ToStr();


                    row.Cells[COLS.PickupPoint].Value = list[i][8].ToStr();
                    row.Cells[COLS.Destination].Value = list[i][9].ToStr();
                    row.Cells[COLS.Charges].Value = list[i][10].ToDecimal();
                    row.Cells[COLS.Parking].Value = list[i][13].ToDecimal();
                    row.Cells[COLS.Waiting].Value = list[i][14].ToDecimal();
                    row.Cells[COLS.ExtraDrop].Value = list[i][15].ToDecimal();
             

                    row.Cells[COLS.BOOKINGFEE].Value = list[i][26].ToDecimal();


                    row.Cells[COLS.Total].Value = list[i][19].ToDecimal();

                    row.Cells[COLS.RemovalDescription].Value = list[i][18].ToStr();

                    row.Cells[COLS.BookedBy].Value = list[i][20].ToStr();
                    
                    row.Cells[COLS.PaymentTypeId].Value = list[i][23].ToInt();                   
                   
                    row.Cells[COLS.BookingStatusId].Value = list[i][24].ToInt();


                    row.Cells[COLS.WaitingTime].Value = list[i][27].ToInt();
                    row.Cells[COLS.ViaString].Value = list[i][28].ToStr();


                    row.Cells[COLS.ESCORTPRICE].Value = list[i][29].ToDecimal();
                }

                CalculateTotal();
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }

      
        private List<object[]> ShowBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, Func<Booking, bool> _condition2, string templateName)
        {

            List<object[]> listofObjects = null;

            Taxi_AppMain.frmLister frm = null;
            if (templateName == "Template13" || TemplateName == "Template24")
            {
                var list1 = General.GetGeneralList<Booking>(_condition).Where(_condition2);
                var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                var list = (from b in list1
                            join c in list2 on b.Id equals c.BookingId into table2
                            from c in table2.DefaultIfEmpty()
                            where (c == null)
                            select new
                            {
                                Id = b.Id,


                                BookingDate = b.BookingDate,
                                PickupDate = b.PickupDateTime,

                                RefNo = b.BookingNo,
                                Vehicle = b.Fleet_VehicleType.VehicleType,
                                OrderNo = b.OrderNo,
                                PupilNo = b.PupilNo,
                                Passenger = b.CustomerName,
                                PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                //  Charges = b.FareRate.ToDecimal(),
                                Charges = b.CompanyPrice.ToDecimal(),
                                CompanyId = b.CompanyId,
                                CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                Parking = b.ParkingCharges.ToDecimal(),
                                Waiting = b.WaitingCharges.ToDecimal(),
                                ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                Congtion = b.CongtionCharges.ToDecimal(),
                                Description = "",
                                Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal()),
                                //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                BookedBy = b.BookedBy.ToStr(),
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                PaymentTypeId = b.PaymentTypeId,
                                BookingStatusId = b.BookingStatusId.ToIntorNull(),
                                PaymentType = b.Gen_PaymentType.PaymentType,
                                BookingFee=b.ServiceCharges.ToDecimal(),
                                WaitingTime = b.DriverWaitingMins,
                                b.ViaString,
                                b.EscortPrice,
                               Status= b.BookingStatus.StatusName
                            }).OrderBy(c => c.PickupDate).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }
            else if (templateName == "Template14" || templateName == "Template23")
            {
                var list1 = General.GetGeneralList<Booking>(_condition).Where(_condition2);
                var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                var list = (from b in list1
                            join c in list2 on b.Id equals c.BookingId into table2
                            from c in table2.DefaultIfEmpty()
                            where (c == null)
                            select new
                            {
                                Id = b.Id,


                                BookingDate = b.BookingDate,
                                PickupDate = b.PickupDateTime,

                                RefNo = b.BookingNo,
                                Vehicle = b.Fleet_VehicleType.VehicleType,
                                OrderNo = b.OrderNo,
                                PupilNo = b.PupilNo,
                                Passenger = b.CustomerName,
                                PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                //  Charges = b.FareRate.ToDecimal(),
                                Charges = b.CompanyPrice.ToDecimal(),
                                CompanyId = b.CompanyId,
                                CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                Parking = b.ParkingCharges.ToDecimal(),
                                Waiting = b.WaitingCharges.ToDecimal(),
                                ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                Congtion = b.CongtionCharges.ToDecimal(),
                                Description = "",
                                Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal() + b.ParkingCharges.ToDecimal() + b.ExtraDropCharges.ToDecimal()),
            
                                BookedBy = b.BookedBy.ToStr(),
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                PaymentTypeId = b.PaymentTypeId,
                                BookingStatusId=b.BookingStatusId.ToIntorNull(),
                                PaymentType = b.Gen_PaymentType.PaymentType,
                                BookingFee = b.ServiceCharges.ToDecimal(),
                                WaitingTime = b.DriverWaitingMins,
                                  b.ViaString,
                                b.EscortPrice,
                                Status = b.BookingStatus.StatusName
                            }).OrderBy(c => c.PickupDate).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }

            else if (templateName == "Template52")
            {
                var list1 = General.GetGeneralList<Booking>(_condition).Where(_condition2);
                var list2 = General.GetGeneralList<Invoice_Charge>(_invoiceCondition);

                var list = (from b in list1
                            join c in list2 on b.Id equals c.BookingId into table2
                            from c in table2.DefaultIfEmpty()
                            where (c == null)
                            select new
                            {
                                Id = b.Id,


                                BookingDate = b.BookingDate,
                                PickupDate = b.PickupDateTime,

                                RefNo = b.BookingNo,
                                Vehicle = b.Fleet_VehicleType.VehicleType,
                                OrderNo = b.OrderNo,
                                PupilNo = b.PupilNo,
                                Passenger = b.CustomerName,
                                PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                //  Charges = b.FareRate.ToDecimal(),
                                Charges = b.CompanyPrice.ToDecimal(),
                                CompanyId = b.CompanyId,
                                CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                Parking = b.ParkingCharges.ToDecimal(),
                                Waiting = b.WaitingCharges.ToDecimal(),
                                ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                                Congtion = b.CongtionCharges.ToDecimal(),
                                Description = "",
                                Total = (b.CompanyPrice.ToDecimal() + b.WaitingCharges.ToDecimal() + b.ParkingCharges.ToDecimal() + b.ExtraDropCharges.ToDecimal()+ b.EscortPrice.ToDecimal()),

                                BookedBy = b.BookedBy.ToStr(),
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                PaymentTypeId = b.PaymentTypeId,
                                BookingStatusId = b.BookingStatusId.ToIntorNull(),
                                PaymentType = b.Gen_PaymentType.PaymentType,
                                BookingFee = b.ServiceCharges.ToDecimal(),
                                WaitingTime = b.DriverWaitingMins,
                                b.ViaString,
                                b.EscortPrice,
                                Status = b.BookingStatus.StatusName
                            }).OrderBy(c => c.PickupDate).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }
            else
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var list1 = db.Bookings.Where(_condition).Where(_condition2);
                    var list2 = db.Invoice_Charges.Where(c => c.Invoice.InvoiceTypeId != Enums.INVOICE_TYPE.ESCORT_INVOICE);
                    
                   
                        var list = (from b in list1
                                    join c in list2 on b.Id equals c.BookingId into table2
                                    join v in db.Fleet_VehicleTypes on b.VehicleTypeId equals v.Id
                                    join p in db.Gen_PaymentTypes on b.PaymentTypeId equals p.Id
                                    from c in table2.DefaultIfEmpty()
                                    where (c == null)
                                    select new
                                    {
                                        Id = b.Id,


                                        BookingDate = b.BookingDate,
                                        PickupDate = b.PickupDateTime,

                                        RefNo = b.BookingNo,
                                        Vehicle = v.VehicleType,
                                        OrderNo = b.OrderNo,
                                        PupilNo = b.PupilNo,
                                        Passenger = b.CustomerName,
                                        PickupPoint = b.FromAddress,
                                        Destination = b.ToAddress,
                                        //  Charges = b.FareRate.ToDecimal(),
                                        Charges = b.CompanyPrice,
                                        CompanyId = b.CompanyId,
                                        CompanyName = "",
                                        Parking = b.ParkingCharges,
                                        Waiting = b.WaitingCharges,
                                        ExtraDrop = b.ExtraDropCharges,
                                        MeetAndGreet = b.MeetAndGreetCharges,
                                        Congtion = b.CongtionCharges,
                                        Description = "",
                                        Total = b.TotalCharges,
                                        //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                        BookedBy = b.BookedBy,
                                        Fare = b.FareRate,

                                        AccountType = 0,
                                        PaymentTypeId = b.PaymentTypeId,
                                        BookingStatusId = b.BookingStatusId,
                                        PaymentType = p.PaymentType,
                                        BookingFee = b.ServiceCharges.ToDecimal(),
                                        WaitingTime = b.DriverWaitingMins,
                                      b.ViaString,
                                        b.EscortPrice,
                                        Status = b.BookingStatus.StatusName
                                    }).OrderBy(c=>c.PickupDate).ToList();




                        frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);
                        frm.HiddenColumns = hiddenColumns;
                        frm.ShowDialog();
                    
                }

            }




            if (frm != null)
            {
                listofObjects = frm.ListofData;


                frm.Dispose();
                GC.Collect();

            }


            return listofObjects;

        }


        //private void btnPickBooking_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //    //   int bookingTypeId = ddlBookingType.SelectedValue.ToInt();
        //        int companyId = ddlCompany.SelectedValue.ToInt();

        //        DateTime? fromDate = dtpFromDate.Value.ToDate();
        //        DateTime? tillDate = dtpTillDate.Value.ToDate();

        //        long departmentId = ddlDepartment.SelectedValue.ToLong();
        //        int costcenterId = ddlCostCenter.SelectedValue.ToInt();


        //        string error = string.Empty;
        //        if (companyId == 0)
        //        {
        //            error += "Required : Company";
        //        }

        //        if (fromDate == null)
        //        {
        //            if (string.IsNullOrEmpty(error))
        //                error += Environment.NewLine;

        //            error += "Required : From Date";
        //        }

        //        if (tillDate == null)
        //        {
        //            if (string.IsNullOrEmpty(error))
        //                error += Environment.NewLine;

        //            error += "Required : To Date";


        //        }

        //        if (!string.IsNullOrEmpty(error))
        //        {
        //            ENUtils.ShowMessage(error);
        //            return;

        //        }



        //        string[] hiddenColumns = null;


        //        hiddenColumns = new string[] {  "Id", "CompanyId","CompanyName","Parking","Destination","Waiting","ExtraDrop","MeetAndGreet","Congtion",
        //                                        "Total","OrderNo","PupilNo","BookingDate","Description","Fare","AccountType","PaymentTypeId"};

                

        //        bool IsDepartmentWise = chkDepartmentWise.Checked;
        //        bool IsCostCenterWise = chkCostCenterWise.Checked;

        //        string orderNo = ddlOrderNo.SelectedValue.ToStr().Trim();


        //        Func<Booking, bool> _conditionDate = null;
        //        if (ddlPickType.SelectedIndex == 0)
        //            _conditionDate = b => b.PickupDateTime.Value.Date >= fromDate && b.PickupDateTime.Value.Date <= tillDate;
        //        else
        //            _conditionDate = b => b.BookingDate.Value.Date >= fromDate && b.BookingDate.Value.Date <= tillDate;


        //        List<object[]> list = General.ShowBookingMultiLister(c => c.CompanyId == companyId && (c.BookingStatusId == Enums.BOOKINGSTATUS.DISPATCHED) && (orderNo=="" || c.OrderNo==orderNo)
        //                                                                    && ((IsDepartmentWise && c.DepartmentId == departmentId) || (IsDepartmentWise == false))
        //                                                                      && ((IsCostCenterWise && c.CostCenterId == costcenterId) || (IsCostCenterWise == false))
        //                                                               ,
        //                                                                 a => a.InvoiceId != null,
        //                                                                hiddenColumns, _conditionDate,TemplateName.ToStr());
        //        GridViewRowInfo row;

        //        int cnt=list.Count;
                

        //        //foreach (object[] obj in list)
        //        //{
        //        //    long bookingId = obj[0].ToLong();

        //        //    if (grdLister.Rows.Count(c => c.Cells[COLS.BookingId].Value.ToLong() == bookingId) > 0)
        //        //        continue;

        //        //    row = grdLister.Rows.AddNew();


        //        //    row.Cells[COLS.BookingId].Value = obj[0].ToLongorNull();
        //        //    row.Cells[COLS.RefNumber].Value = obj[3].ToStr();
        //        //    row.Cells[COLS.PickupDate].Value = obj[2].ToDateTime();


        //        //    row.Cells[COLS.Vehicle].Value = obj[4].ToStr();


        //        //    row.Cells[COLS.OrderNo].Value = obj[5].ToStr();
        //        //    row.Cells[COLS.PupilNo].Value = obj[6].ToStr();

        //        //    row.Cells[COLS.Passenger].Value = obj[7].ToStr();


        //        //    row.Cells[COLS.PickupPoint].Value = obj[8].ToStr();
        //        //    row.Cells[COLS.Destination].Value = obj[9].ToStr();
        //        //    row.Cells[COLS.Charges].Value = obj[10].ToDecimal();
        //        //    row.Cells[COLS.Parking].Value = obj[13].ToDecimal();
        //        //    row.Cells[COLS.Waiting].Value = obj[14].ToDecimal();
        //        //    row.Cells[COLS.ExtraDrop].Value = obj[15].ToDecimal();
        //        //    row.Cells[COLS.MeetAndGreet].Value = obj[16].ToDecimal();
        //        //    row.Cells[COLS.CongtionCharge].Value = obj[17].ToDecimal();
        //        //    row.Cells[COLS.Total].Value = obj[19].ToDecimal();

        //        //    row.Cells[COLS.RemovalDescription].Value = obj[18].ToStr();

        //        //    row.Cells[COLS.BookedBy].Value = obj[20].ToStr();

        //        //}

        //        var  existBookingId=grdLister.Rows.Select(c=>c.Cells[COLS.BookingId].Value.ToLong()).ToList<long>();
        //        //int newCnt= list.Select(c=>c[0].ToLong()).Except(existBookingId).Count();
        //        //grdLister.RowCount += newCnt;



        //         list.RemoveAll(c => existBookingId.Contains(c[0].ToLong()));

        //         cnt = list.Count;

        //        for (int i = 0; i < cnt; i++)
        //        {
        //           // long bookingId = list[i][0].ToLong();

        //            //if (grdLister.Rows.Count(c => c.Cells[COLS.BookingId].Value.ToLong() == bookingId) > 0)
        //            //continue;

        //            row = grdLister.Rows.AddNew();


        //            row.Cells[COLS.BookingId].Value = list[i][0].ToLongorNull();
        //            row.Cells[COLS.RefNumber].Value = list[i][3].ToStr();
        //            row.Cells[COLS.PickupDate].Value = list[i][2].ToDateTime();


        //            row.Cells[COLS.Vehicle].Value = list[i][4].ToStr();


                   

        //            row.Cells[COLS.OrderNo].Value = list[i][5].ToStr();
        //            row.Cells[COLS.PupilNo].Value = list[i][6].ToStr();

        //            row.Cells[COLS.Passenger].Value = list[i][7].ToStr();


        //            row.Cells[COLS.PickupPoint].Value = list[i][8].ToStr();
        //            row.Cells[COLS.Destination].Value = list[i][9].ToStr();
        //            row.Cells[COLS.Charges].Value = list[i][10].ToDecimal();
        //            row.Cells[COLS.Parking].Value = list[i][13].ToDecimal();
        //            row.Cells[COLS.Waiting].Value = list[i][14].ToDecimal();
        //            row.Cells[COLS.ExtraDrop].Value = list[i][15].ToDecimal();
        //            row.Cells[COLS.MeetAndGreet].Value = list[i][16].ToDecimal();
        //            row.Cells[COLS.CongtionCharge].Value = list[i][17].ToDecimal();
                   
                    
                    
                   
        //            row.Cells[COLS.Total].Value = list[i][19].ToDecimal();

        //            row.Cells[COLS.RemovalDescription].Value = list[i][18].ToStr();

        //            row.Cells[COLS.BookedBy].Value = list[i][20].ToStr();


        //            row.Cells[COLS.PaymentTypeId].Value = list[i][23].ToInt();

        //        }

        //        CalculateTotal();
        //    }
        //    catch (Exception ex)
        //    {
        //        ENUtils.ShowMessage(ex.Message);

        //    }

        //}

        private void CalculateTotal()
        {

            txtInvoiceAmount.Text =string.Format("{0:£ #.##}",grdLister.Rows.Where(c=>c.Cells[COLS.PaymentTypeId].Value.ToInt()!=6)
                                                    .Sum(c => c.Cells[COLS.Total].Value.ToDecimal()));

        }

        private void ClearOrderNo()
        {
            ddlOrderNo.DataSource = null;

        }

        private void ddlCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            if (grdLister.Columns.Count == 0) return;

            int? companyId = ddlCompany.SelectedValue.ToIntorNull();


            if (companyId == null)
            {
                SetOrderNoColumn(false);
                SetPupilNoColumn(false);
                SetBookedByColumn(false);
                ClearDepartment();
              
                ClearOrderNo();
              
            }
            else
            {
                Gen_Company obj = General.GetObject<Gen_Company>(c => c.Id == companyId);
                if (obj != null)
                {
                    if(ddlSubCompany!=null && obj.SubCompanyId!=null)
                         this.ddlSubCompany.SelectedValue = obj.SubCompanyId;
                    this.companyEmail = obj.Email.ToStr().Trim();
                    FillDepartmentCombo(obj.Id);
                
                    bool orderNo = obj.HasOrderNo.ToBool();
                    bool pupilNo = obj.HasPupilNo.ToBool();

                    bool HasBookedBy = obj.HasBookedBy.ToBool();
                    SetOrderNoColumn(orderNo);
                    SetPupilNoColumn(pupilNo);
                    SetBookedByColumn(HasBookedBy);




                    if (obj.HasSingleOrderNo.ToBool())
                    {
                        lblOrderNo.Visible = true;
                        txtOrderNo.Visible = true;
                        grdLister.Columns[COLS.OrderNo].IsVisible = false;
                    }
                    else
                    {
                        lblOrderNo.Visible = false;
                        txtOrderNo.Visible = false;

                    }

                   

                    if (orderNo && obj.HasSingleOrderNo.ToBool()==false)
                    {

                        var list = General.GetQueryable<Booking>(c => c.CompanyId == obj.Id && (c.OrderNo != null && c.OrderNo != ""))
                                       .Select(args => new { Id = args.OrderNo, OrderNo = args.OrderNo }).Distinct().ToList();

                        ComboFunctions.FillCombo(list, ddlOrderNo, "OrderNo", "Id");

                        ddlOrderNo.Visible = true;
                        label5.Visible = true;
                    }
                    else
                    {
                        ddlOrderNo.Visible = false;
                        label5.Visible = false;
                    }


                    if(txtNotes.Text.Length==0 && obj.NoteForInvoice.ToStr().Trim().Length>0)
                    {
                        txtNotes.Text = obj.NoteForInvoice.ToStr().Trim();

                    }


                    try
                    {
                        ddlAccountType.SelectedValue = obj.AccountTypeId;
                    }
                    catch
                    {

                    }

                }
            }
        }

        private void ClearDepartment()
        {
            ddlDepartment.DataSource = null;

        }

        private void FillDepartmentCombo(int companyId)
        {
            ComboFunctions.FillCompanyDepartmentCombo(ddlDepartment, c => c.CompanyId == companyId);
        }


       

       


       



        private void SetOrderNoColumn(bool show)
        {

            grdLister.Columns[COLS.OrderNo].IsVisible = show;


            if (show)
            {
                grdLister.Columns["OrderNo"].Width = 80;

            }
        }

        private void SetBookedByColumn(bool show)
        {

            grdLister.Columns[COLS.BookedBy].IsVisible = show;


            if (show)
            {
                grdLister.Columns[COLS.BookedBy].Width = 100;

            }
        }

        private void SetPupilNoColumn(bool show)
        {

            grdLister.Columns[COLS.PupilNo].IsVisible = show;


            if (show)
            {
                grdLister.Columns[COLS.PupilNo].Width = 80;

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        public override void Print()
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;

            frmInvoiceReport frm = new frmInvoiceReport();
           // frm.HasSplitByDept = chkSplitByDept.Checked;
            frm.HasSplitByField = ddlSplitBy.Text;
            frm.ObjInvoice = objMaster.Current;
            var list = General.GetQueryable<vu_Invoice>(a => a.Id == id).OrderBy(c=>c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;

           

            frm.GenerateReport();
            frm.reportViewer1.ShowExportButton = btnExportExcel.Visible;

            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmInvoiceReport1");

            if (doc != null)
            {
                doc.Close();
            }

            UI.MainMenuForm.MainMenuFrm.ShowForm(frm);
          //  MainMenuForm.MainMenuFrm.ShowForm(frm);
        }

        private void ExportReport(string exportTo)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;

            frmInvoiceReport frm = new frmInvoiceReport();
           // frm.HasSplitByDept = chkSplitByDept.Checked;
            frm.HasSplitByField = ddlSplitBy.Text;
            frm.ObjInvoice = objMaster.Current;

            frm.ExportFileType = exportTo;
            var list = General.GetQueryable<vu_Invoice>(a => a.Id == id).OrderBy(c => c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;


            frm.GenerateReport();

            frm.ExportReport(objMaster.Current.InvoiceNo, exportTo);


        }

       

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            ExportReport("pdf");
        }

        private void ddlCompany_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            OnSave();
          
        }
        public override void OnNew()
        {
            txtInvoiceNo.Text = string.Empty;
            ComboFunctions.FillCompanyForInvoiceCombo(ddlCompany);
            chkDepartmentWise.Checked = false;
           
            grdLister.Rows.Clear();
            txtInvoiceAmount.Text = string.Empty;
            ddlCompany.Enabled = true;
            btnCreditNote.BackColor = Color.AliceBlue;

        }

        private void chkDepartmentWise_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (args.NewValue == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ddlDepartment.Enabled = true;
              //  chkAutoContinue.Visible = true;
            }
            else
            {

                ddlDepartment.Enabled = false;
                ddlDepartment.SelectedValue = null;
               // chkAutoContinue.Visible = false;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (objMaster.Current == null || objMaster.Current.Id == 0) return;
            long id = objMaster.Current.Id;

            frmInvoiceReport frm = new frmInvoiceReport();
          
            frm.HasSplitByField = ddlSplitBy.Text;
            frm.ObjInvoice = objMaster.Current;

            var list = General.GetQueryable<vu_Invoice>(a => a.Id == id).OrderBy(c=>c.PickupDate).ToList();
            int count = list.Count;

            frm.DataSource = list;

         

            frm.GenerateReport();

            frm.SendEmail(objMaster.Current.InvoiceNo,this.companyEmail);
        }

     





        private void ShowHideColumns(bool show)
        {

            grdLister.Columns[COLS.Charges].IsVisible = show;
            grdLister.Columns[COLS.CongtionCharge].IsVisible = show;
            grdLister.Columns[COLS.Destination].IsVisible = show;
            grdLister.Columns[COLS.ExtraDrop].IsVisible = show;
            grdLister.Columns[COLS.MeetAndGreet].IsVisible = show;
         //   grdLister.Columns[COLS.OrderNo].IsVisible = show;
            grdLister.Columns[COLS.Parking].IsVisible = show;
            grdLister.Columns[COLS.Passenger].IsVisible = show;
            grdLister.Columns[COLS.PickupDate].IsVisible = show;
            grdLister.Columns[COLS.PickupPoint].IsVisible = show;
            grdLister.Columns[COLS.Destination].IsVisible = show;
            grdLister.Columns[COLS.Vehicle].IsVisible = show;
            grdLister.Columns[COLS.RefNumber].IsVisible = show;
            grdLister.Columns[COLS.Waiting].IsVisible = show;
            grdLister.Columns[COLS.VehicleID].IsVisible = show;

            if (!show)
            {
                grdLister.Columns[COLS.Total].HeaderText = "Amount";
                grdLister.Columns[COLS.Total].Width = 70;

            }
            else
            {
                grdLister.Columns[COLS.Total].HeaderText = "Total";
                grdLister.Columns[COLS.Total].Width = 45;


            }
        }

      

        private void frmInvoice_Shown(object sender, EventArgs e)
        {
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            btnAddNewInvoice.Location = new Point(this.Width - 185, 0);
            btnAddNewInvoice.BringToFront();


            if (AppVars.listUserRights.Count(c => c.formName == "frmBookingsList" && c.functionId == "DISABLE EXPORT LIST") > 0)
            {
                btnExportExcel.Visible = false;
                btnExportPDF.Visible = false;
                btnExportToExcel2.Visible = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportReport("excel");
        }

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            objMaster.Clear();
            objMaster.PrimaryKeyValue = null;
            OnCreateNew();
        }


        private  void OnCreateNew()
        {
            txtInvoiceNo.Text = string.Empty;
          //  ComboFunctions.FillCompanyCombo(ddlCompany);
           
          //  chkCostCenterWise.Checked = false;
            grdLister.Rows.Clear();
            txtInvoiceAmount.Text = string.Empty;
            ddlCompany.Enabled = true;
            if (chkAutoContinue.Visible == true && chkAutoContinue.Checked)
            {
                int Index=ddlDepartment.SelectedIndex.ToInt();
                Index=(Index+1);
                ddlDepartment.SelectedIndex = Index;
                AutoPickUp();
            }
            else
            {
                chkDepartmentWise.Checked = false; 
            }

            btnCreditNote.BackColor = Color.AliceBlue;

        }

        private void chkAutoContinue_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAutoContinue.Checked)
            {
                ddlDepartment.Enabled = true;
            }
            else
            {
                ddlDepartment.SelectedValue = null;
            }
        }

        private void chkAllFromDate_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                dtpFromDate.Enabled = false;

            }
            else
            {

                dtpFromDate.Enabled = true;
            }
        }

        private void btnCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                frmInvoiceCreditNotes frm = new frmInvoiceCreditNotes();
                frm.OnDisplayRecord(objMaster.Current.Id);
                frm.ShowDialog();


                frm.Dispose();
            }
            catch (Exception ex)
            {


            }
        }

        private void deleteCreditNote_Click(object sender, EventArgs e)
        {
            using (TaxiDataContext db = new TaxiDataContext())
            {

                var objNote = db.InvoiceCreditNotes.FirstOrDefault(c => c.InvoiceId == objMaster.Current.Id);


                if (objNote!=null)
                {

                    db.InvoiceCreditNotes.DeleteOnSubmit(objNote);
                    db.SubmitChanges();
                    btnCreditNote.BackColor = Color.AliceBlue;

                }

            }

        }
        //RadGridViewExcelExporter exporter2 = null;

        private void InitializeExportGrid2()
        {
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();

            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();


            this.radGridView2.Location = new System.Drawing.Point(405, 60);
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.Size = new System.Drawing.Size(240, 150);
            this.radGridView2.TabIndex = 18;
            this.radGridView2.Text = "radGridView2";
            this.radGridView2.Visible = false;

            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();

            //this.radPanel1.Controls.Add(this.radGridView1);
        }


        private void radMenuExportBooking_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog2.FileName = objMaster.Current.InvoiceNo.ToStr() + "_bookings";
                saveFileDialog2.Filter = "Excel File (*.xls)|*.xls|AdvExcel File (*.xlsx)|*.xlsx";
                if (DialogResult.OK == saveFileDialog2.ShowDialog())
                {

                    if (radGridView2 == null)
                        InitializeExportGrid2();

                    radGridView2.Columns.Clear();
                  
                    // grdOperatorVehicleRecord.Columns["MonthCommencing"].IsVisible = false;
                    // grdOperatorVehicleRecord.Columns["OperatorLicenceNumber"].IsVisible = false;
                    //  grdOperatorVehicleRecord.Columns["OperatorName"].IsVisible = false;

                    radGridView2.Columns.Add(new GridViewTextBoxColumn("BookingNo", "BookingNo"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("InvoiceNo", "InvoiceNo"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("PickupDate", "PickupDate"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("PickupTime", "PickupTime"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("CustomerName", "CustomerName"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("FromAddress", "FromAddress"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("ToAddress", "ToAddress"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("OrderNo", "OrderNo"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("DepartmentName", "DepartmentName"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("PassengerType", "PassengerType"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("TotalCharges", "TotalCharges"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("BookerEmail", "BookerEmail"));
                    radGridView2.Columns.Add(new GridViewTextBoxColumn("CompanyCode", "CompanyCode"));


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        List<ClsExportInvoiceBookings> list1 = db.ExecuteQuery<ClsExportInvoiceBookings>("exec stp_GetInvoiceBookingsForExport {0}", objMaster.Current.Id).ToList();


                        var list = (from a in list1
                                    select new
                                    {
                                        BookingNo = a.BookingNo,
                                        InvoiceNo = txtInvoiceNo.Text,
                                        PickupDate = a.PickupDateTime,
                                        PickupTime = a.PickupDateTime,
                                        CustomerName = a.CustomerName,
                                        FromAddress = a.FromAddress,
                                        ToAddress = a.ToAddress,
                                        OrderNo = a.OrderNo,
                                        DepartmentName = a.DepartmentName,
                                        PassengerType = a.PassengerType,                                   
                                        TotalCharges = a.CompanyPrice.ToDecimal() + a.WaitingCharges.ToDecimal() + a.ParkingCharges.ToDecimal() + a.ExtraDropCharges.ToDecimal(),
                                      //TotalCharges = a.TotalCharges,
                                        BookerEmail = a.BookerEmail,
                                       a.CompanyCode

                                }).OrderBy(c=>c.PickupDate).ToList();
                    radGridView2.RowCount = list.Count;

                    for (int i = 0; i < list.Count; i++)
                    {
                        radGridView2.Rows[i].Cells["BookingNo"].Value = " " + list[i].BookingNo + " ";
                        radGridView2.Rows[i].Cells["InvoiceNo"].Value = " " + list[i].InvoiceNo + " ";
                        radGridView2.Rows[i].Cells["PickupDate"].Value = " " + list[i].PickupDate.ToDateTime().ToShortDateString() + " ";
                        radGridView2.Rows[i].Cells["PickupTime"].Value = " " + list[i].PickupTime.ToDateTime().ToShortTimeString() + " ";
                        radGridView2.Rows[i].Cells["CustomerName"].Value = " " + list[i].CustomerName + " ";
                        radGridView2.Rows[i].Cells["FromAddress"].Value = " " + list[i].FromAddress + " ";
                        radGridView2.Rows[i].Cells["ToAddress"].Value = " " + list[i].ToAddress + " ";
                        radGridView2.Rows[i].Cells["OrderNo"].Value = " " + list[i].OrderNo + " ";
                        radGridView2.Rows[i].Cells["DepartmentName"].Value = " " + list[i].DepartmentName + " ";
                        radGridView2.Rows[i].Cells["PassengerType"].Value = " " + list[i].PassengerType + " ";
                        radGridView2.Rows[i].Cells["TotalCharges"].Value = " " + list[i].TotalCharges.ToDecimal() + " ";
                        radGridView2.Rows[i].Cells["BookerEmail"].Value = " " + list[i].BookerEmail + " ";
                            radGridView2.Rows[i].Cells["CompanyCode"].Value = " " + list[i].CompanyCode + " ";
                        }
                    }
                    radGridView2.Columns["BookingNo"].HeaderText = "Booking Ref";
                    radGridView2.Columns["InvoiceNo"].HeaderText = "Invoice No";
                    radGridView2.Columns["PickupDate"].HeaderText = "Date";
                    radGridView2.Columns["PickupTime"].HeaderText = "Time";
                    radGridView2.Columns["CustomerName"].HeaderText = "Name";
                    radGridView2.Columns["FromAddress"].HeaderText = "Pickup";
                    radGridView2.Columns["ToAddress"].HeaderText = "Destination";
                    radGridView2.Columns["OrderNo"].HeaderText = "Order No";
                    radGridView2.Columns["DepartmentName"].HeaderText = "Department";
                    radGridView2.Columns["PassengerType"].HeaderText = "Passenger Type";
                    radGridView2.Columns["TotalCharges"].HeaderText = "Total Fare";
                    radGridView2.Columns["CompanyCode"].HeaderText = "Company Code";

                    this.btnExportToExcel2.Enabled = false;
                    ClsExportGridView exporter = new ClsExportGridView(radGridView2, saveFileDialog2.FileName);
                    exporter.ApplyCellFormatting = true;
                
                    exporter.ExportExcel();
                     

                    this.btnExportToExcel2.Enabled = true;
                    MessageBox.Show("Export successfully.");



                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

       

        private void radMenuExportToExcel_Click(object sender, EventArgs e)
        {
            ExportReport("excel");
        }
    }
}
