using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Taxi_Model;
using Taxi_BLL;
using Utils;

namespace Taxi_AppMain
{
    public partial class frmSearchBooking : RadForm
    {
        bool Complain = false;

        public bool IsBookingEditMode = false;


        public frmSearchBooking()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmSearchBooking_Shown);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;
        }

        public frmSearchBooking(string name, string phoneNo, string mobileNo,string email)
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmSearchBooking_Shown);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;

            txtCustomerName.Text = name.ToStr().ToLower().Trim();

            txtTelNo.Text = phoneNo.ToStr().Trim();

            txtMobileNo.Text = mobileNo.ToStr().Trim();
            this.custemail = email;
            //if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(phoneNo) || !string.IsNullOrEmpty(mobileNo))
            //{
                IsLoaded = true;
        

            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick1);

            // SearchBooking();
        }
        public frmSearchBooking(string MobileNo)
        {
            InitializeComponent();
            btnPickBooking.Visible = false;
            
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;



            txtMobileNo.Text = MobileNo.ToStr().Trim();
            IsLoaded = true;
            this.Shown += new EventHandler(frmSearchBooking_Shown);

          
            // SearchBooking();
        }



        private int _CompanyId;


        public frmSearchBooking(int companyId)
        {
            InitializeComponent();
        //    btnPickBooking.Visible = false;
         
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick1);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;

            pnlCriteria.Visible = false;
            btnPickDetails.Visible = false;

            this._CompanyId = companyId;
            this.Size = new Size(1024, 800);

            SearchAccountBooking();


            
            // SearchBooking();
        }
        public frmSearchBooking(int companyId,bool IsComplain)
        {
            InitializeComponent();
            //    btnPickBooking.Visible = false;

            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick1);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;

            pnlCriteria.Visible = false;

            this._CompanyId = companyId;
            this.Size = new Size(1024, 800);

            SearchAccountBooking();
            Complain = IsComplain;

            // SearchBooking();
        }
        private int _DriverId;
        public frmSearchBooking(int DriverId, bool IsComplain, bool IsDriver)
        {
            InitializeComponent();
            //    btnPickBooking.Visible = false;

            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick1);
            grdLister.ShowGroupPanel = false;
            grdLister.AllowAddNewRow = false;

            pnlCriteria.Visible = false;

            this._DriverId = DriverId;
            this.Size = new Size(1024, 800);

            SearchAccountBooking();
            Complain = IsComplain;

            // SearchBooking();
        }
        private void SearchAccountBooking()
        {
            try
            {
                var data1 = General.GetQueryable<Booking>(c => c.CompanyId==this._CompanyId || c.DriverId==_DriverId);

               


                var query = (from a in data1                           

                             select new
                             {
                                 Id = a.Id,

                                 PickupDate = a.PickupDateTime,

                                 FromTypeId = a.FromLocTypeId,
                                 FromId = a.FromLocId,

                                 From = a.FromDoorNo != string.Empty ? a.FromDoorNo + " - " + a.FromAddress : a.FromAddress,

                                 ToId = a.ToLocId,
                                 ToTypeId = a.ToLocTypeId,
                                 Via=a.ViaString,
                                 To = a.ToDoorNo != string.Empty ? a.ToDoorNo + " - " + a.ToAddress : a.ToAddress,
                                 Fare = a.FareRate,
                                 Fees= a.ServiceCharges,
                                 CustFare =a.CustomerPrice,
                                 Customer = a.CustomerName,
                                 MobileNo = a.CustomerMobileNo,
                                 TelNo = a.CustomerPhoneNo,
                                 Account=a.Gen_Company.CompanyName,
                                 CompanyFares=a.CompanyPrice,
                                 BookingTypeId = a.BookingTypeId,
                                 RefNo = a.BookingNo,
                                 Vechile = a.Fleet_VehicleType.VehicleType,
                                 Email = a.CustomerEmail,
                                 AccountId = a.CompanyId,
                                 Drv = a.DriverId != null ? a.Fleet_Driver.DriverNo : "",
                                 PermanentNotes = a.NoOfChilds,
                                 SpecialReq = a.SpecialRequirements,
                                 
                             }).OrderByDescending(c=>c.PickupDate).ToList();



                grdLister.DataSource = query;


                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["FromId"].IsVisible = false;
                grdLister.Columns["FromTypeId"].IsVisible = false;
                grdLister.Columns["ToId"].IsVisible = false;
                grdLister.Columns["TelNo"].IsVisible = false;
                grdLister.Columns["AccountId"].IsVisible = false;
                grdLister.Columns["CustFare"].IsVisible = false;
                grdLister.Columns["Account"].HeaderText = "A/C";
                 grdLister.Columns["CustFare"].HeaderText = "Cust. Fare";
                 grdLister.Columns["CompanyFares"].HeaderText= "A/C Fare";


                grdLister.Columns["PickupDate"].HeaderText = "Pickup Date-Time";             

                grdLister.Columns["From"].HeaderText = "Pickup Point";    

                grdLister.Columns["To"].HeaderText = "Destination";            


                grdLister.Columns["ToTypeId"].IsVisible = false;
                grdLister.Columns["BookingTypeId"].IsVisible = false;

                grdLister.Columns["RefNo"].IsVisible = false;
                grdLister.Columns["Vechile"].IsVisible = false;
                grdLister.Columns["Email"].IsVisible = false;
                grdLister.Columns["PermanentNotes"].IsVisible = false;
                grdLister.Columns["SpecialReq"].IsVisible = false;


                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdLister.Columns["PickupDate"].Width = 140;
                grdLister.Columns["From"].Width = 250;
                grdLister.Columns["To"].Width = 250;
                grdLister.Columns["MobileNo"].Width = 110;
                grdLister.Columns["Customer"].Width = 120;


                 grdLister.Columns["Account"].Width = 80;
                 grdLister.Columns["CustFare"].Width = 80;
                 grdLister.Columns["CompanyFares"].Width = 80;


                 grdLister.Columns["Via"].Width = 140;
                 grdLister.Columns["Drv"].Width = 60;
            }
            catch (Exception ex)
            {
             //   ENUtils.ShowMessage(ex.Message);

            }

        }


        void grdLister_CellDoubleClick1(object sender, GridViewCellEventArgs e)
        {
            //PickBooking();
            if (Complain == false)
            {
                PickBooking();
            }
            else
            {
                frmComplaint frm = (frmComplaint)Application.OpenForms.Cast<Form>().FirstOrDefault(c => c.Name == "frmComplaint");
                if (frm != null)
                {
                    if (grdLister.CurrentRow.IsCurrent == true)
                    {
                        long Id = grdLister.CurrentRow.Cells["Id"].Value.ToLong();
                        string RefNo = grdLister.CurrentRow.Cells["RefNo"].Value.ToStr();
                        frm.ComplainJobRef(Id, RefNo);
                        this.Close();
                    }
                    // frm.SMSTo(TemplateID, MessageTemplate, MobileNo, BunchName, TotalNo, PickUpTotal, BunchValues);
                }
            }
        }

        void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                //ViewDetailForm(e.Row);
                int Id = grdLister.CurrentRow.Cells["Id"].Value.ToInt();
            
                if (Id != 0)
                {
                    this.Dispose();
                    frmBooking frm = new frmBooking("", "",null,false);

                    frm.PickBookingTypeId = bookingTypeId;

                    frm.OnDisplayRecord(Id);
                   // frm.OnDisplayRecord(Id); // need to uncomment again
                    frm.ControlBox = true;
                    frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                    frm.MaximizeBox = false;

                    frm.Show();
                }
               
            
            }
            catch (Exception ex)
            {
                ENUtils.ShowErrorMessage(ex.Message);
            }
        }
        private void ViewDetailForm(GridViewRowInfo row)
        {
            try
            {

                if (row != null && row is GridViewDataRowInfo)
                {
                    frmBooking_Trash frm = new frmBooking_Trash(row.Cells["Id"].Value.ToInt());
                    frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    frm.Dispose();
                    frm.ShowDialog();
                }
                else
                {
                    ENUtils.ShowMessage("Please select a record");
                }
            }
            catch (Exception ex)
            {


            }
        }



        void frmSearchBooking_Shown(object sender, EventArgs e)
        {

            try
            {

                SearchBooking();
                IsLoaded = true;

                grdLister.Columns["Id"].IsVisible = false;
                grdLister.Columns["FromId"].IsVisible = false;
                grdLister.Columns["FromTypeId"].IsVisible = false;
                grdLister.Columns["ToId"].IsVisible = false;
                grdLister.Columns["TelNo"].IsVisible = false;

                grdLister.Columns["PickupDate"].HeaderText = "Pickup Date-Time";

                grdLister.Columns["From"].HeaderText = "Pickup Point";
                grdLister.Columns["To"].HeaderText = "Destination";


                grdLister.Columns["ToTypeId"].IsVisible = false;
                grdLister.Columns["BookingTypeId"].IsVisible = false;

                grdLister.Columns["RefNo"].IsVisible = false;
                grdLister.Columns["Vechile"].IsVisible = false;
                grdLister.Columns["Email"].IsVisible = false;
                grdLister.Columns["AccountId"].IsVisible = false;


                grdLister.Columns["BookingBackgroundColor"].IsVisible = false;

                grdLister.Columns["PermanentNotes"].IsVisible = false;
                  grdLister.Columns["SpecialReq"].IsVisible = false;
                
           
       //         grdLister.Columns["PickupDate"].Sort(RadSortOrder.Descending, true);


         //       grdLister.EnableSorting = true;

                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                txtCustomerName.Focus();

                if (IsBookingEditMode)
                {
                    btnPickBooking.Enabled = false;

                }


                grdLister.Columns["PickupDate"].Width = 105;
                grdLister.Columns["Customer"].Width = 68;
                grdLister.Columns["CompanyFares"].Width = 68;
                grdLister.Columns["Account"].Width = 80;
                grdLister.Columns["CustFare"].IsVisible =false;
                grdLister.Columns["MobileNo"].Width = 95;
                grdLister.Columns["From"].Width = 220;
                grdLister.Columns["Via"].Width = 130;
                grdLister.Columns["To"].Width = 220;
                grdLister.Columns["Vechile"].Width = 50;
                grdLister.Columns["Drv"].Width = 60;
                grdLister.Columns["CompanyFares"].Width = 50;


                grdLister.Columns["Account"].HeaderText = "A/C";
                grdLister.Columns["CustFare"].HeaderText = "Cust. Fare";
                grdLister.Columns["CompanyFares"].HeaderText = "A/C Fare";

                grdLister.ShowRowHeaderColumn = false;

                this.grdLister.ContextMenuOpening += new ContextMenuOpeningEventHandler(grdLister_ContextMenuOpening);



                var row = grdLister.Rows.FirstOrDefault(c => c.Cells["BookingTypeId"].Value.ToInt() == Enums.BOOKING_TYPES.IVR);


                if (row != null)
                {


                    ConditionalFormattingObject objConidtion = new ConditionalFormattingObject();
                    objConidtion.ApplyToRow = true;
                    objConidtion.RowBackColor = Color.FromArgb(row.Cells["BookingBackgroundColor"].Value.ToInt());
                    objConidtion.TValue1 = Enums.BOOKING_TYPES.IVR.ToStr();
                    objConidtion.ConditionType = ConditionTypes.Equal;
                    grdLister.Columns["BookingTypeId"].ConditionalFormattingObjectList.Add(objConidtion);

                }



                if (AppVars.AppTheme == "HighContrastBlack")
                {
                    grdLister.ForeColor = Color.White;
                    radLabel1.ForeColor = Color.White;
                    radLabel2.ForeColor = Color.White;
                    radLabel3.ForeColor = Color.White;
                    chkShowAddressOnly.ForeColor = Color.White;
                   
                }
            }
            catch (Exception ex)
            {
            //    ENUtils.ShowMessage(ex.Message);

            }
        }

        RadDropDownMenu objContextMenu = null;
        Booking objIndividualBooking = null;

        private bool IsLoaded = false;

        private string custemail = "";
        private void SearchBooking()
        {

            if(IsLoaded==false)
                return;

            try
            {

              

                string customerName = txtCustomerName.Text.Trim().ToLower();
                string telNo = txtTelNo.Text.Trim().ToLower();
                string mobNo = txtMobileNo.Text.Trim().ToLower();


                if (customerName.Length == 0 && telNo.Length == 0 && mobNo.Length == 0 && custemail.Length==0 )
                    mobNo = "#___#";


                if (chkShowAddressOnly.Checked)
                {
                    var data1 = General.GetQueryable<Customer>(null);
                    var query = (from a in data1
                                 where

                                  (a.MobileNo != null && a.MobileNo != null)
                                 && (customerName == string.Empty || a.Name.Trim().ToLower().StartsWith(customerName))
                                 &&

                                 (
                                 ((a.TelephoneNo.Trim() == telNo || telNo == string.Empty) && (a.MobileNo.Trim() == mobNo || mobNo == string.Empty))
                            || ((a.TelephoneNo.Trim() == mobNo || mobNo == string.Empty) && (a.MobileNo.Trim() == telNo || telNo == string.Empty))

                            )

                                 select new
                                 {
                                     Id = default(long),

                                     PickupDate = default(DateTime?),
                                     FromTypeId = default(int?),
                                     FromId = default(int?),
                                     From = a.Address1,
                                     ToId = default(int?),
                                     ToTypeId = default(int?),
                                     Via = "",
                                     To = a.CompanyId != null ? a.Gen_Company.Address : a.Address2,
                                     Fare = default(decimal?),
                                     Fees = default(decimal?),
                                     CustFare = default(decimal?),
                                     Customer = a.Name,
                                     MobileNo = a.MobileNo,
                                     TelNo = a.TelephoneNo,
                                     Account = a.Gen_Company.CompanyName,
                                     CompanyFares = default(decimal?),
                                     BookingTypeId = default(int?),
                                     RefNo = "",
                                     Vechile = "",
                                     Email = a.Email,
                                     Drv = "",
                                     AccountId = a.CompanyId,
                                     BookingBackgroundColor = default(int?),
                                     PermanentNotes = default(int?),
                                     SpecialReq = a.LikesAndDislikes,
                                 }).ToList();


                    query.RemoveAll(c => c.From == null && c.To == null);



                    var data2 = General.GetQueryable<Booking>(null);
                    var query2 = (from a in data2
                                  where

                                   (a.CustomerMobileNo != null && a.CustomerPhoneNo != null)
                                  && (customerName == string.Empty || a.CustomerName.Trim().ToLower().StartsWith(customerName))
                                  &&

                                  (
                                  ((a.CustomerPhoneNo.Trim() == telNo || telNo == string.Empty) && (a.CustomerMobileNo.Trim() == mobNo || mobNo == string.Empty))
                             || ((a.CustomerPhoneNo.Trim() == mobNo || mobNo == string.Empty) && (a.CustomerMobileNo.Trim() == telNo || telNo == string.Empty))
                              || (custemail == string.Empty || a.CustomerEmail == custemail)
                             )

                                  select new
                                  {
                                      Id = a.Id,

                                      PickupDate = a.PickupDateTime,
                                      FromTypeId = a.FromLocTypeId,
                                      FromId = a.FromLocId,
                                      From = a.FromDoorNo != string.Empty ? a.FromDoorNo + " - " + a.FromAddress : a.FromAddress,
                                      ToId = a.ToLocId,
                                      ToTypeId = a.ToLocTypeId,
                                      Via = a.ViaString,
                                      To = a.ToDoorNo != string.Empty ? a.ToDoorNo + " - " + a.ToAddress : a.ToAddress,
                                      Fare = a.FareRate,
                                      Fees = a.ServiceCharges,
                                      CustFare = a.CustomerPrice,
                                      Customer = a.CustomerName,
                                      MobileNo = a.CustomerMobileNo,
                                      TelNo = a.CustomerPhoneNo,
                                      Account = a.Gen_Company.CompanyName,
                                      CompanyFares = a.CompanyPrice,
                                      BookingTypeId = a.BookingTypeId,
                                      RefNo = a.BookingNo,
                                      Vechile = a.Fleet_VehicleType.VehicleType,
                                      Email = a.CustomerEmail,
                                      Drv = a.DriverId != null ? a.Fleet_Driver.DriverNo : "",
                                      AccountId = a.CompanyId,
                                      BookingBackgroundColor = a.BookingType.BackgroundColor,
                                      PermanentNotes = a.NoOfChilds,
                                      SpecialReq = a.SpecialRequirements,
                                  })
                                 .OrderByDescending(c => c.PickupDate).Take(100)
                                 .ToList();



                    query.AddRange(query2.AsEnumerable());


                    grdLister.DataSource = query;


                }
                else
                {
                    var data1 = General.GetQueryable<Booking>(null);
                    var query = (from a in data1
                                 where

                                  (a.CustomerMobileNo != null && a.CustomerPhoneNo != null)
                                 && (customerName == string.Empty || a.CustomerName.Trim().ToLower().StartsWith(customerName))
                                 &&

                                 (
                                 ((a.CustomerPhoneNo.Trim() == telNo || telNo == string.Empty) && (a.CustomerMobileNo.Trim() == mobNo || mobNo == string.Empty))
                            || ((a.CustomerPhoneNo.Trim() == mobNo || mobNo == string.Empty) && (a.CustomerMobileNo.Trim() == telNo || telNo == string.Empty))


                            )
                                 //
                                 select new
                                 {
                                     Id = a.Id,

                                     PickupDate = a.PickupDateTime,
                                     FromTypeId = a.FromLocTypeId,
                                     FromId = a.FromLocId,
                                     From = a.FromDoorNo != string.Empty ? a.FromDoorNo + " - " + a.FromAddress : a.FromAddress,
                                     ToId = a.ToLocId,
                                     ToTypeId = a.ToLocTypeId,
                                     Via = a.ViaString,
                                     To = a.ToDoorNo != string.Empty ? a.ToDoorNo + " - " + a.ToAddress : a.ToAddress,
                                     Fare = a.FareRate,
                                     Fees = a.ServiceCharges,
                                     CustFare = a.CustomerPrice,
                                     Customer = a.CustomerName,
                                     MobileNo = a.CustomerMobileNo,
                                     TelNo = a.CustomerPhoneNo,
                                     Account = a.Gen_Company.CompanyName,
                                     CompanyFares = a.CompanyPrice,
                                     BookingTypeId = a.BookingTypeId,
                                     RefNo = a.BookingNo,
                                     Vechile = a.Fleet_VehicleType.VehicleType,
                                     Email = a.CustomerEmail,
                                     Drv = a.DriverId != null ? a.Fleet_Driver.DriverNo : "",
                                     AccountId = a.CompanyId,
                                     BookingBackgroundColor = a.BookingType.BackgroundColor,
                                     PermanentNotes = a.NoOfChilds,
                                     SpecialReq = a.SpecialRequirements,
                                 }).OrderByDescending(c => c.PickupDate).Take(100).ToList();


                    if (this.custemail.ToStr().Trim().Length > 0 && mobNo.Length == 0 && telNo.Length == 0)
                    {
                        query.Clear();
                        query = (from a in data1
                                 where

                                                         a.CustomerEmail == custemail


                                 //
                                 select new
                                 {
                                     Id = a.Id,

                                     PickupDate = a.PickupDateTime,
                                     FromTypeId = a.FromLocTypeId,
                                     FromId = a.FromLocId,
                                     From = a.FromDoorNo != string.Empty ? a.FromDoorNo + " - " + a.FromAddress : a.FromAddress,
                                     ToId = a.ToLocId,
                                     ToTypeId = a.ToLocTypeId,
                                     Via = a.ViaString,
                                     To = a.ToDoorNo != string.Empty ? a.ToDoorNo + " - " + a.ToAddress : a.ToAddress,
                                     Fare = a.FareRate,
                                     Fees = a.ServiceCharges,
                                     CustFare = a.CustomerPrice,
                                     Customer = a.CustomerName,
                                     MobileNo = a.CustomerMobileNo,
                                     TelNo = a.CustomerPhoneNo,
                                     Account = a.Gen_Company.CompanyName,
                                     CompanyFares = a.CompanyPrice,
                                     BookingTypeId = a.BookingTypeId,
                                     RefNo = a.BookingNo,
                                     Vechile = a.Fleet_VehicleType.VehicleType,
                                     Email = a.CustomerEmail,
                                     Drv = a.DriverId != null ? a.Fleet_Driver.DriverNo : "",
                                     AccountId = a.CompanyId,
                                     BookingBackgroundColor = a.BookingType.BackgroundColor,
                                     PermanentNotes = a.NoOfChilds,
                                     SpecialReq = a.SpecialRequirements,
                                 }).OrderByDescending(c => c.PickupDate).Take(100).ToList();
                        //}


                        



                    }
                    grdLister.DataSource = query;
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }


       



        public int? bookingTypeId = Enums.BOOKING_TYPES.LOCAL;

        public string CustomerName = string.Empty;
        public string phoneNo = string.Empty;
        public string mobileNo = string.Empty;

        public int? fromLocTypeId = null;
        public int? fromLocId = null;
        public string from = string.Empty;
        public int? toLocTypeId = null;
        public int? toLocId = null;
        public string to = string.Empty;

        public decimal fare = 0.00m;
        public decimal Fees = 0.00m;
        public int? JobId = null;
        public string pickUpdate = string.Empty;
        public string RefNo = string.Empty;
        public string Vechile = string.Empty;
        public string CustEmail = string.Empty;


        public int IsPermanentNotes;
        public string SpecialReq;

        public bool IsSelected = false;


        public int? SelectedCompanyId;
        public decimal customerFare = 0.00m;
        public decimal companyFare = 0.00m;
        public string viaString = string.Empty;
     //   public string driverNo = string.Empty;

        private void btnPickBooking_Click(object sender, EventArgs e)
        {
            if (Complain == false)
            {
                PickBooking();
            }
            else
            {
                frmComplaint frm = (frmComplaint)Application.OpenForms.Cast<Form>().FirstOrDefault(c => c.Name == "frmComplaint");
                if (frm != null)
                {
                    if (grdLister.CurrentRow.IsCurrent == true)
                    {
                        long Id = grdLister.CurrentRow.Cells["Id"].Value.ToLong();
                        string RefNo = grdLister.CurrentRow.Cells["RefNo"].Value.ToStr();
                        frm.ComplainJobRef(Id,RefNo);
                        this.Close();
                    }
                   // frm.SMSTo(TemplateID, MessageTemplate, MobileNo, BunchName, TotalNo, PickUpTotal, BunchValues);
                }
            }
        }


        public string special, excludeddrivers, attributes;
        private void GetCustomer()
        {

            try
            {
                string custName = txtCustomerName.Text.Trim();
                string custMob = txtMobileNo.Text.Trim();
                string custTel = txtTelNo.Text.Trim();


                using (TaxiDataContext db = new TaxiDataContext())
                {

                    Customer objCust = null;
                    db.DeferredLoadingEnabled = false;
                    if (custMob.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.MobileNo == custMob).OrderByDescending(c => c.Id).FirstOrDefault();
                    }
                    else if (custTel.Length > 0)
                    {
                        objCust = db.Customers.Where(c => c.TelephoneNo == custTel).OrderByDescending(c => c.Id).FirstOrDefault();
                    }


                    if (objCust != null)
                    {
                        special = objCust.LikesAndDislikes.ToStr();
                        excludeddrivers = objCust.ExcludedDriverIds.ToStr();
                        attributes = string.Empty;

                    }

                }
            }
            catch
            {

            }
        }


        private void PickBooking()
        {



          


                GridViewRowInfo row = grdLister.CurrentRow;
            if (row != null && row is GridViewDataRowInfo)
            {
                GetCustomer();

                if (objIndividualBooking == null)
                {


                    CustomerName = row.Cells["Customer"].Value.ToStr();
                    phoneNo = row.Cells["TelNo"].Value.ToStr();
                    mobileNo = row.Cells["MobileNo"].Value.ToStr();

                    fromLocTypeId = row.Cells["FromTypeId"].Value.ToIntorNull();
                    fromLocId = row.Cells["FromId"].Value.ToIntorNull();

                  
                    from = row.Cells["From"].Value.ToStr();

                    toLocTypeId = row.Cells["ToTypeId"].Value.ToIntorNull();
                    toLocId = row.Cells["ToId"].Value.ToIntorNull();

                    if (fromLocId == 0)
                        fromLocId = null;

                    if (toLocId == 0)
                        toLocId = null;

                    if (fromLocTypeId == null)
                        fromLocTypeId = 7;

                    if (toLocTypeId == null)
                        toLocTypeId = 7;




                    to = row.Cells["To"].Value.ToStr();
                    fare = row.Cells["Fare"].Value.ToDecimal();
                    Fees = row.Cells["Fees"].Value.ToDecimal();
                    this.bookingTypeId = row.Cells["BookingTypeId"].Value.ToIntorNull();

                    JobId = row.Cells["Id"].Value.ToInt();
                    pickUpdate = row.Cells["PickupDate"].Value.ToStr();
                    RefNo = row.Cells["RefNo"].Value.ToStr();
                    Vechile = row.Cells["Vechile"].Value.ToStr();

                    CustEmail = row.Cells["Email"].Value.ToStr();

                    SelectedCompanyId = row.Cells["AccountId"].Value.ToIntorNull();
                    customerFare = row.Cells["CustFare"].Value.ToDecimal();
                    companyFare = row.Cells["CompanyFares"].Value.ToDecimal();

                    viaString = row.Cells["Via"].Value.ToStr();

                    IsPermanentNotes = row.Cells["PermanentNotes"].Value.ToInt();
                    SpecialReq = row.Cells["SpecialReq"].Value.ToStr();
                }
                else
                {
                    CustomerName = row.Cells["Customer"].Value.ToStr();
                    phoneNo = row.Cells["TelNo"].Value.ToStr();
                    mobileNo = row.Cells["MobileNo"].Value.ToStr();


                  
                     fromLocTypeId = objIndividualBooking.FromLocTypeId.ToIntorNull();
                     fromLocId = objIndividualBooking.FromLocId.ToIntorNull();
                     from = objIndividualBooking.FromAddress.ToStr().ToUpper().Trim();

                    string fromDoor = objIndividualBooking.FromDoorNo.ToStr().Trim();

                    if (fromDoor.Contains(" - "))
                        fromDoor = fromDoor.Substring(0, fromDoor.IndexOf(" - "));
                    else
                        fromDoor = string.Empty;





                     toLocTypeId = objIndividualBooking.ToLocTypeId.ToIntorNull();
                     toLocId = objIndividualBooking.ToLocId.ToIntorNull();
                     to = objIndividualBooking.ToAddress.ToStr().ToUpper().Trim();

                    string toDoor = objIndividualBooking.ToDoorNo.ToStr().Trim();
                    if (toDoor.Contains(" - "))
                        toDoor = toDoor.Substring(0, toDoor.IndexOf(" - "));
                    else
                        toDoor = string.Empty;
                  




                    if (from.Length == 0)
                    {
                        fromLocTypeId = row.Cells["FromTypeId"].Value.ToIntorNull();
                        fromLocId = row.Cells["FromId"].Value.ToIntorNull();


                        if (row.Cells["FromAdd"]!=null)
                        from = row.Cells["FromAdd"].Value.ToStr();

                        fromDoor = row.Cells["From"].Value.ToStr();
                        if (fromDoor.Contains(" - "))
                            fromDoor = fromDoor.Substring(0, fromDoor.IndexOf(" - "));
                        else
                            fromDoor = string.Empty;



                    }

                    if (to.Length == 0)
                    {

                        toDoor = row.Cells["To"].Value.ToStr();
                        if (toDoor.Contains(" - "))
                            toDoor = toDoor.Substring(0, toDoor.IndexOf(" - "));
                        else
                            toDoor = string.Empty;


                        toLocTypeId = row.Cells["ToTypeId"].Value.ToIntorNull();
                        toLocId = row.Cells["ToId"].Value.ToIntorNull();

                        if (row.Cells["ToAdd"]!=null)
                        to = row.Cells["ToAdd"].Value.ToStr();


                    }

                    if (fromLocId == 0)
                        fromLocId = null;



                    if (toLocId == 0)
                        toLocId = null;

                    if (fromLocTypeId == null)
                        fromLocTypeId = 7;

                    if (toLocTypeId == null)
                        toLocTypeId = 7;


                    fare = row.Cells["Fare"].Value.ToDecimal();
                    this.bookingTypeId = row.Cells["BookingTypeId"].Value.ToIntorNull();
                    Fees = row.Cells["Fees"].Value.ToDecimal();
                    JobId = row.Cells["Id"].Value.ToInt();
                    pickUpdate = row.Cells["PickupDate"].Value.ToStr();
                    RefNo = row.Cells["RefNo"].Value.ToStr();
                    Vechile = row.Cells["Vechile"].Value.ToStr();

                    CustEmail = row.Cells["Email"].Value.ToStr();

                    SelectedCompanyId = row.Cells["AccountId"].Value.ToIntorNull();
                    customerFare = row.Cells["CustFare"].Value.ToDecimal();
                    companyFare = row.Cells["CompanyFares"].Value.ToDecimal();

                    viaString = row.Cells["Via"].Value.ToStr();

                    IsPermanentNotes = row.Cells["PermanentNotes"].Value.ToInt();
                    SpecialReq = row.Cells["SpecialReq"].Value.ToStr();

                }
         
                this.IsSelected = true;

                this.Close();
            }
            else
            {
                ENUtils.ShowMessage("Please select a Booking");

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBooking();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeySearch(e.KeyCode);
        }

        private void OnKeySearch(Keys key)
        {
            if (key == Keys.Enter)
            {
                SearchBooking();
            }
            else if (key == Keys.Escape)
            {

                CloseForm();
            }

        }

        private void CloseForm()
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }



        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (objContextMenu == null)
            {
                objContextMenu = new RadDropDownMenu();
                objContextMenu.BackColor = Color.Orange;

                RadMenuItem EditFareItem1 = new RadMenuItem("Select as Pickup");
                EditFareItem1.ForeColor = Color.Black;
                EditFareItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                EditFareItem1.Click += new EventHandler(EditFareItem1_Click);
                objContextMenu.Items.Add(EditFareItem1);

                EditFareItem1 = new RadMenuItem("Select as Destination");
                EditFareItem1.ForeColor = Color.Black;
                EditFareItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                EditFareItem1.Click += new EventHandler(EditFareItem1_Click);
                objContextMenu.Items.Add(EditFareItem1);




                EditFareItem1 = new RadMenuItem("UnSelect All");
                EditFareItem1.ForeColor = Color.Black;
                EditFareItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                EditFareItem1.Click += new EventHandler(EditFareItem1_Click);
                objContextMenu.Items.Add(EditFareItem1);

                if (AppVars.AppTheme == "HighContrastBlack")
                {

                    foreach (var item in objContextMenu.Items)
                    {
                        item.ForeColor = Color.White;
                    }


                }
            }

             if (grdLister.CurrentColumn!=null && (grdLister.CurrentColumn.Name == "From" ||  grdLister.CurrentColumn.Name == "To"))
                    e.ContextMenu = objContextMenu;
        }

        void EditFareItem1_Click(object sender, EventArgs e)
        {
            if (grdLister.CurrentColumn != null && grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
            {
                RadMenuItem obj = (RadMenuItem)sender;

                if (objIndividualBooking == null)
                    objIndividualBooking = new Booking();

                if (obj.Text == "UnSelect All")
                {
                    objIndividualBooking = null;




                }

                else if (obj.Text == "Select as Pickup")
                {
                    if ( grdLister.CurrentColumn.Name == "From")
                    {
                        objIndividualBooking.FromAddress = grdLister.CurrentRow.Cells["From"].Value.ToStr();

                        objIndividualBooking.FromDoorNo = grdLister.CurrentRow.Cells["From"].Value.ToStr();
                        objIndividualBooking.FromLocTypeId = grdLister.CurrentRow.Cells["FromTypeId"].Value.ToIntorNull();
                        objIndividualBooking.FromLocId = grdLister.CurrentRow.Cells["FromId"].Value.ToIntorNull();

                    }
                    else if ( grdLister.CurrentColumn.Name == "To")
                    {
                        objIndividualBooking.FromAddress = grdLister.CurrentRow.Cells["To"].Value.ToStr();
                        objIndividualBooking.FromDoorNo = grdLister.CurrentRow.Cells["To"].Value.ToStr();


                        objIndividualBooking.FromLocTypeId = grdLister.CurrentRow.Cells["ToTypeId"].Value.ToIntorNull();
                        objIndividualBooking.FromLocId = grdLister.CurrentRow.Cells["ToId"].Value.ToIntorNull();

                    }

                }
                else if (obj.Text == "Select as Destination")
                {
                    if ( grdLister.CurrentColumn.Name == "To")
                    {
                        objIndividualBooking.ToAddress = grdLister.CurrentRow.Cells["To"].Value.ToStr();
                        objIndividualBooking.ToDoorNo = grdLister.CurrentRow.Cells["To"].Value.ToStr();


                        objIndividualBooking.ToLocTypeId = grdLister.CurrentRow.Cells["ToTypeId"].Value.ToIntorNull();
                        objIndividualBooking.ToLocId = grdLister.CurrentRow.Cells["ToId"].Value.ToIntorNull();

                    }
                    else if ( grdLister.CurrentColumn.Name == "From")
                    {
                        objIndividualBooking.ToAddress = grdLister.CurrentRow.Cells["From"].Value.ToStr();
                        objIndividualBooking.ToDoorNo = grdLister.CurrentRow.Cells["From"].Value.ToStr();


                        objIndividualBooking.ToLocTypeId = grdLister.CurrentRow.Cells["FromTypeId"].Value.ToIntorNull();
                        objIndividualBooking.ToLocId = grdLister.CurrentRow.Cells["FromId"].Value.ToIntorNull();

                    }

                }
            }
        }

        public bool IsPickDetails = false;
        private void btnPickDetails_Click(object sender, EventArgs e)
        {
            GridViewRowInfo row = grdLister.CurrentRow;
            if (row != null && row is GridViewDataRowInfo)
            {

                GetCustomer();
                if (objIndividualBooking == null)
                {


                    CustomerName = row.Cells["Customer"].Value.ToStr();
                    phoneNo = row.Cells["TelNo"].Value.ToStr();
                    mobileNo = row.Cells["MobileNo"].Value.ToStr();
                    CustEmail = row.Cells["Email"].Value.ToStr();

                    //fromLocTypeId = row.Cells["FromTypeId"].Value.ToIntorNull();
                    //fromLocId = row.Cells["FromId"].Value.ToIntorNull();
                    //from = row.Cells["From"].Value.ToStr();

                    //toLocTypeId = row.Cells["ToTypeId"].Value.ToIntorNull();
                    //toLocId = row.Cells["ToId"].Value.ToIntorNull();
                    //to = row.Cells["To"].Value.ToStr();
                    //fare = row.Cells["Fare"].Value.ToDecimal();
                    //this.bookingTypeId = row.Cells["BookingTypeId"].Value.ToIntorNull();

                    //JobId = row.Cells["Id"].Value.ToInt();
                    //pickUpdate = row.Cells["PickupDate"].Value.ToStr();
                    //RefNo = row.Cells["RefNo"].Value.ToStr();
                    //Vechile = row.Cells["Vechile"].Value.ToStr();

                   // CustEmail = row.Cells["Email"].Value.ToStr();

                    //SelectedCompanyId = row.Cells["AccountId"].Value.ToIntorNull();
                    //customerFare = row.Cells["CustFare"].Value.ToDecimal();
                    //companyFare = row.Cells["CompanyFares"].Value.ToDecimal();

                    //viaString = row.Cells["Via"].Value.ToStr();
                }
                else
                {
                    CustomerName = row.Cells["Customer"].Value.ToStr();
                    phoneNo = row.Cells["TelNo"].Value.ToStr();
                    mobileNo = row.Cells["MobileNo"].Value.ToStr();
                    CustEmail = row.Cells["Email"].Value.ToStr();



                    //fromLocTypeId = objIndividualBooking.FromLocTypeId.ToIntorNull();
                    //fromLocId = objIndividualBooking.FromLocId.ToIntorNull();
                    //from = objIndividualBooking.FromAddress.ToStr().ToUpper().Trim();

                    //string fromDoor = objIndividualBooking.FromDoorNo.ToStr().Trim();

                    //if (fromDoor.Contains(" - "))
                    //    fromDoor = fromDoor.Substring(0, fromDoor.IndexOf(" - "));
                    //else
                    //    fromDoor = string.Empty;





                    //toLocTypeId = objIndividualBooking.ToLocTypeId.ToIntorNull();
                    //toLocId = objIndividualBooking.ToLocId.ToIntorNull();
                    //to = objIndividualBooking.ToAddress.ToStr().ToUpper().Trim();

                    //string toDoor = objIndividualBooking.ToDoorNo.ToStr().Trim();
                    //if (toDoor.Contains(" - "))
                    //    toDoor = toDoor.Substring(0, toDoor.IndexOf(" - "));
                    //else
                    //    toDoor = string.Empty;





                    //if (from.Length == 0)
                    //{
                    //    fromLocTypeId = row.Cells["FromTypeId"].Value.ToIntorNull();
                    //    fromLocId = row.Cells["FromId"].Value.ToIntorNull();

                    //    from = row.Cells["FromAdd"].Value.ToStr();

                    //    fromDoor = row.Cells["From"].Value.ToStr();
                    //    if (fromDoor.Contains(" - "))
                    //        fromDoor = fromDoor.Substring(0, fromDoor.IndexOf(" - "));
                    //    else
                    //        fromDoor = string.Empty;



                    //}

                    //if (to.Length == 0)
                    //{

                    //    toDoor = row.Cells["To"].Value.ToStr();
                    //    if (toDoor.Contains(" - "))
                    //        toDoor = toDoor.Substring(0, toDoor.IndexOf(" - "));
                    //    else
                    //        toDoor = string.Empty;


                    //    toLocTypeId = row.Cells["ToTypeId"].Value.ToIntorNull();
                    //    toLocId = row.Cells["ToId"].Value.ToIntorNull();
                    //    to = row.Cells["ToAdd"].Value.ToStr();


                    //}


                    //fare = row.Cells["Fare"].Value.ToDecimal();
                    //this.bookingTypeId = row.Cells["BookingTypeId"].Value.ToIntorNull();

                    //JobId = row.Cells["Id"].Value.ToInt();
                    //pickUpdate = row.Cells["PickupDate"].Value.ToStr();
                    //RefNo = row.Cells["RefNo"].Value.ToStr();
                    //Vechile = row.Cells["Vechile"].Value.ToStr();

                   // CustEmail = row.Cells["Email"].Value.ToStr();

                    //SelectedCompanyId = row.Cells["AccountId"].Value.ToIntorNull();
                    //customerFare = row.Cells["CustFare"].Value.ToDecimal();
                    //companyFare = row.Cells["CompanyFares"].Value.ToDecimal();

                    //viaString = row.Cells["Via"].Value.ToStr();


                    IsPermanentNotes = row.Cells["PermanentNotes"].Value.ToInt();
                    SpecialReq = row.Cells["SpecialReq"].Value.ToStr();




                }

                IsPickDetails = true;
                this.IsSelected = true;

                this.Close();
            }
            else
            {
                ENUtils.ShowMessage("Please select a Booking");

            }
        }

        private void chkShowAddressOnly_CheckedChanged(object sender, EventArgs e)
        {
            SearchBooking();
        }
    }
}
