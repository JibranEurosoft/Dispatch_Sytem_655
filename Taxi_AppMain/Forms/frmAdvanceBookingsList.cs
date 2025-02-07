using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi_BLL;
using DAL;
using Taxi_Model;
using Telerik.WinControls.UI;
using Utils;
using Telerik.WinControls;
using Telerik.Data;
using Taxi_AppMain.Forms;
using System.Threading;
using Telerik.WinControls.UI.Docking;


namespace Taxi_AppMain
{
    public partial class frmAdvanceBookingsList : UI.SetupBase
    {

    
        public frmAdvanceBookingsList()
        {

         
          
            InitializeComponent();
            this.Load += new EventHandler(frmBookingsList_Load);
            grdLister.CellDoubleClick += new GridViewCellEventHandler(grdLister_CellDoubleClick);
  

         
            grdLister.ShowGroupPanel = false;

   
            grdLister.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
           grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);
          //  grdLister.VerticalScroll.LargeChange = 100;
         //   grdLister.TableElement.VScrollBar.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;



             grdLister.CommandCellClick+=new CommandCellClickEventHandler(grdLister_CommandCellClick);
        

            grdLister.Font = newFont;
            grdLister.TableElement.Font = newFont;

            grdLister.ContextMenuOpening += grdLister_ContextMenuOpening;
        }

        RadDropDownMenu EditFare = null;
        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {



                GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                if (cell == null)
                {
                    e.Cancel = true;
                    return;

                }
                else if (cell.GridControl.Name == "grdLister")
                {

                    if (EditFare == null)
                    {

                        //if (AppVars.listUserRights.Count(c=>c.functionId=="Dispatch Allocated Jobs") > 0)
                        //{

                            EditFare = new RadDropDownMenu();
                            EditFare.BackColor = Color.Orange;

                            RadMenuItem EditFareItem1 = new RadMenuItem("Dispatch Allocated Jobs");
                            EditFareItem1.ForeColor = Color.DarkBlue;
                            EditFareItem1.BackColor = Color.Orange;
                            EditFareItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        EditFareItem1.Name = "Allocated";
                            EditFareItem1.Click += new EventHandler(EditFareItem1_Click);
                            EditFare.Items.Add(EditFareItem1);



                        //RadMenuItem EditFareItem2 = new RadMenuItem("Delete");
                        //EditFareItem2.ForeColor = Color.DarkBlue;
                        //EditFareItem2.BackColor = Color.Orange;
                        //EditFareItem2.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        //EditFareItem2.Name = "Delete";
                        //EditFareItem2.Click += new EventHandler(EditFareItemDelete_Click);
                        //EditFare.Items.Add(EditFareItem2);


                        RadMenuItem EditFareItem2 = new RadMenuItem("Cancel");
                        EditFareItem2.ForeColor = Color.Red;
                        EditFareItem2.BackColor = Color.Orange;
                        EditFareItem2.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        EditFareItem2.Name = "Cancel";
                        EditFareItem2.Click += new EventHandler(EditFareItemCancel_Click);
                        EditFare.Items.Add(EditFareItem2);

                        // }
                    }


                    if (cell.RowInfo.Cells["AdvBookingTypeId"].Value.ToInt() == 4 || (cell.RowInfo.Cells["EndDate"].Value!=null && cell.RowInfo.Cells["EndDate"].Value.ToDateTime()<DateTime.Now.Date))
                    {
                      //  EditFare.Items["Delete"].Visibility = ElementVisibility.Visible;
                        EditFare.Items["Cancel"].Visibility = ElementVisibility.Collapsed;
                        EditFare.Items["Allocated"].Visibility = ElementVisibility.Collapsed;
                    }
                    else
                    {
                      //  EditFare.Items["Delete"].Visibility = ElementVisibility.Collapsed;

                        EditFare.Items["Cancel"].Visibility = ElementVisibility.Visible;
                        if (AppVars.listUserRights.Count(c=>c.functionId=="Dispatch Allocated Jobs")>0)
                        {

                            EditFare.Items["Allocated"].Visibility = ElementVisibility.Visible;
                        }
                        else

                            EditFare.Items["Allocated"].Visibility = ElementVisibility.Collapsed;

                    }

                    e.ContextMenu = EditFare;
                  
                }

            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        //void grdLister_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        // {
        //     if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
        //     {

                

        //             AdvanceBookingBO objMaster = new AdvanceBookingBO();
                 
        //             try
        //             {
        //                 objMaster.GetByPrimaryKey(grdLister.CurrentRow.Cells["Id"].Value.ToInt());
        //                 string customer=objMaster.Current.CustomerName.ToStr();
        //                 string from=objMaster.Current.FromAddress.ToStr();
        //                 string toAddress=objMaster.Current.ToAddress.ToStr();
        //              //   string totalJobs=objMaster.Current.Bookings.Count.ToStr();




        //                 new TaxiDataContext().stp_DeleteMultiBooking(objMaster.Current.Id, AppVars.LoginObj.UserName.ToStr());

                      
        //                // objMaster.Delete(objMaster.Current);




        //              //   new TaxiDataContext().stp_AddLog("MULTI BOOKING DELETED :Total bookings : "+totalJobs + " , CUST : " + customer + " , Pickup : " + from + " , Destination : " + toAddress, AppVars.LoginObj.UserName.ToStr(), AppVars.LoginObj.UserName.ToStr());

        //             }
        //             catch (Exception ex)
        //             {
        //                 if (objMaster.Errors.Count > 0)
        //                     ENUtils.ShowMessage(objMaster.ShowErrors());
        //                 else
        //                 {
        //                     ENUtils.ShowMessage(ex.Message);

        //                 }
        //                 e.Cancel = true;

        //             }
            
        //     }
         

        // }

        

         Font oldFont = new Font("Tahoma", 10, FontStyle.Regular);
         Font newFont = new Font("Tahoma", 10, FontStyle.Bold);


         private Color _HeaderRowBackColor = Color.SteelBlue;

         public Color HeaderRowBackColor
         {
             get { return _HeaderRowBackColor; }
             set { _HeaderRowBackColor = value; }
         }


         private Color _HeaderRowBorderColor = Color.DarkSlateBlue;

         public Color HeaderRowBorderColor
         {
             get { return _HeaderRowBorderColor; }
             set { _HeaderRowBorderColor = value; }
         }


        void EditFareItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    long advancejobid = grdLister.CurrentRow.Cells["Id"].Value.ToLong();
                    General.DespatchPreJobs(advancejobid);

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }
        void EditFareItemCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    long advancejobid = grdLister.CurrentRow.Cells["Id"].Value.ToLong();

                    string customer = grdLister.CurrentRow.Cells["Passenger"].Value.ToStr();


                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            string FinalQuery = "update Booking set BookingStatusId=3 where advancebookingid="+advancejobid+ " and bookingstatusid!=2";
                            db.stp_RunProcedure(FinalQuery);                           
                            db.ExecuteQuery<int>("update advancebooking set AdvBookingTypeId=4 where id=" + advancejobid);

                               db.stp_AddUserLogs(AppVars.LoginObj.LuserId.ToInt(), "Advance Booking of ["+ customer+"] Cancelled by Controller ("+AppVars.LoginObj.UserName.ToStr()+")",3);


                        grdLister.CurrentRow.Delete();

                    }


                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


        void EditFareItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
                {
                    long advancejobid = grdLister.CurrentRow.Cells["Id"].Value.ToLong();


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        var obj = db.AdvanceBookings.FirstOrDefault(c => c.Id == advancejobid);

                        if (obj != null)
                        {
                            obj.AdvBookingTypeId = 5;

                            db.SubmitChanges();


                            grdLister.CurrentRow.Delete();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }

        private void AddDeleteColumn(RadGridView grid)
         {
             GridViewCommandColumn col = new GridViewCommandColumn();
             col.BestFit();

             col.Name = "btnDelete";
             col.UseDefaultText = true;
             col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
             col.DefaultText = "Delete";
             col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            //if (AppVars.listUserRights.Count(c => c.formName == this.Name && c.functionId == "DELETE") == 0)
            //{
                col.IsVisible = false;
                col.VisibleInColumnChooser = false;
                

         //   }
            //else
            //    grdLister.RowsChanging += new GridViewCollectionChangingEventHandler(grdLister_RowsChanging);

            grid.Columns.Add(col);

         }


    
         void grdLister_ViewCellFormatting(object sender, CellFormattingEventArgs e)
         {
             

                 if (e.CellElement is GridHeaderCellElement)
                 {
                     //    e.CellElement
                     e.CellElement.BorderColor = _HeaderRowBorderColor;
                     e.CellElement.BorderColor2 = _HeaderRowBorderColor;
                     e.CellElement.BorderColor3 = _HeaderRowBorderColor;
                     e.CellElement.BorderColor4 = _HeaderRowBorderColor;


                     // e.CellElement.DrawBorder = false;
                     e.CellElement.BackColor = _HeaderRowBackColor;
                     e.CellElement.NumberOfColors = 1;
                     e.CellElement.Font = newFont;
                     e.CellElement.ForeColor = Color.White;
                     e.CellElement.DrawFill = true;

                     e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                 }

                 //else if (e.CellElement is GridFilterCellElement)
                 //{
                 //    e.CellElement.Font = oldFont;
                 //    e.CellElement.NumberOfColors = 1;
                 //    e.CellElement.BackColor = Color.White;
                 //    e.CellElement.RowElement.BackColor = Color.White;
                 //    e.CellElement.RowElement.NumberOfColors = 1;

                 //    e.CellElement.BorderColor = Color.DarkSlateBlue;
                 //    e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                 //    e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                 //    e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                 //    e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;
                 //}
                 //else if (e.CellElement is GridRowHeaderCellElement)
                 //{

                 //    if (e.CellElement is GridTableHeaderCellElement)
                 //    {

                 //        e.CellElement.BorderColor = _HeaderRowBorderColor;
                 //        e.CellElement.BorderColor2 = _HeaderRowBorderColor;
                 //        e.CellElement.BorderColor3 = _HeaderRowBorderColor;
                 //        e.CellElement.BorderColor4 = _HeaderRowBorderColor;


                 //        // e.CellElement.DrawBorder = false;
                 //        e.CellElement.BackColor = _HeaderRowBackColor;
                 //        e.CellElement.NumberOfColors = 1;
                 //        e.CellElement.Font = newFont;
                 //        e.CellElement.ForeColor = Color.White;
                 //        e.CellElement.DrawFill = true;

                 //        e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                 //    }
                 //    else if (e.CellElement is GridRowHeaderCellElement && e.Row is GridViewFilteringRowInfo)
                 //    {

                 //        e.CellElement.Font = oldFont;
                 //        e.CellElement.NumberOfColors = 1;
                 //        e.CellElement.BackColor = Color.White;
                 //        e.CellElement.RowElement.BackColor = Color.White;
                 //        e.CellElement.RowElement.NumberOfColors = 1;

                 //        e.CellElement.BorderColor = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                 //        e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                 //    }

                 //    else
                 //    {

                 //        e.CellElement.BackColor = Color.FromArgb(e.Row.Cells["SubCompanyBgColor"].Value.ToInt());
                 //        e.CellElement.NumberOfColors = 1;
                 //        e.CellElement.BorderColor = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor2 = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor3 = Color.DarkSlateBlue;
                 //        e.CellElement.BorderColor4 = Color.DarkSlateBlue;

                 //        e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;

                 //        e.CellElement.DrawFill = true;

                 //    }
                 //}


              
            // }
           
         }



         private void grid_CommandCellClick(object sender, EventArgs e)
         {
             GridCommandCellElement gridCell = (GridCommandCellElement)sender;
             string name = gridCell.ColumnInfo.Name.ToLower();

             GridViewRowInfo row = gridCell.RowElement.RowInfo;
             long id = row.Cells["Id"].Value.ToLong();

             int driverId = row.Cells["DriverId"].Value.ToInt();

             bool rtn = false;
             if (name == "btndelete")
             {
                 if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                 {

                     RadGridView grid = gridCell.GridControl;
                     grid.CurrentRow.Delete();
                 }
             }
             else if (name == "btnrecall")
             {
                 if (row.Cells["Status"].Value.ToStr() == "POB" || row.Cells["Status"].Value.ToStr() == "STC")
                     
                 {





                     ENUtils.ShowMessage("Job cannot be Re-Call as driver is on " + row.Cells["Status"].Value.ToStr() + " Status.");
                     return;

                 }
                 else if (row.Cells["StatusId"].Value.ToInt() == Enums.BOOKINGSTATUS.DISPATCHED || row.Cells["StatusId"].Value.ToInt() == Enums.BOOKINGSTATUS.CANCELLED)
                 {

                     
                     if (General.GetQueryable<Booking>(null).Count(c => c.Id == id && (c.AcceptedDateTime != null || c.Fleet_Driver != null && c.Fleet_Driver.HasPDA==true)) > 0)
                     {
                         ENUtils.ShowMessage("Job cannot be Re-Call as driver is on " + row.Cells["Status"].Value.ToStr() + " Status.");
                         return;

                     }

                 }


                 if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to Re-Call a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                 {

                     new Thread(delegate()
                     {
                         General.ReCallBooking(id, driverId);
                     }).Start(); 
                    
                 }
                 else
                 {

                     return;
                 }
                

             }
             else if (name == "btnredespatch")
             {

         

                rtn= General.ShowDespatchForm(General.GetObject<Booking>(c => c.Id == id));               
                
             }

             if (name == "btnrecall" || name == "btnredespatch")
             {
                 if(name == "btnredespatch" && rtn==false)
                     return;


                 Thread.Sleep(500);
                 PopulateData();

                 (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard") as frmBookingDashBoard).RefreshActiveData();


          

                // General.RefreshListWithoutSelected<frmBookingDashBoard>("frmBookingDashBoard1");
             }
         }


         

         private void AddCommandColumn(string name,string headerText,int width)
         {
             GridViewCommandColumn col = new GridViewCommandColumn();
             col.Width = width;
          
             col.UseDefaultText = true;
             col.DefaultText = headerText;
             col.Name = name;
             grdLister.Columns.Add(col);

         }



         void frmBookingsList_Load(object sender, EventArgs e)
         {


             this.InitializeForm("frmAdvanceBookingsList");

             ddlColumns.Items.Add("Passenger");
             ddlColumns.Items.Add("Telephone No");
             ddlColumns.Items.Add("Mobile No");
             ddlColumns.Items.Add("Pickup Point");
             ddlColumns.Items.Add("Destination");       


             ddlColumns.SelectedIndex = 0;

             PopulateData();

             AddDeleteColumn(grdLister);

             grdLister.Columns["Id"].IsVisible = false;
     

             UI.GridFunctions.SetFilter(grdLister);
             grdLister.Font = oldFont;


             (grdLister.Columns["AddOn"] as GridViewDateTimeColumn).SortOrder = RadSortOrder.Descending;

             grdLister.Columns["AddOn"].IsVisible = false;

             grdLister.Columns["RefNumber"].IsVisible=false;
            grdLister.Columns["AdvBookingTypeId"].IsVisible = false;

            grdLister.Columns["Passenger"].Width = 100;

             grdLister.Columns["ContactNo"].Width = 140;


             grdLister.Columns["From"].Width = 230;
             grdLister.Columns["From"].HeaderText = "Pickup Point";

             grdLister.Columns["To"].Width = 230;
             grdLister.Columns["To"].HeaderText = "Destination";


             grdLister.Columns["BookingDate"].Width = 100;
             grdLister.Columns["BookingDate"].HeaderText = "Booking Date";


            grdLister.Columns["EndDate"].Width = 130;
            grdLister.Columns["EndDate"].HeaderText = "End Date";
            (grdLister.Columns["EndDate"] as GridViewDateTimeColumn).CustomFormat = "dd-MMM-yyyy HH:mm";
            (grdLister.Columns["EndDate"] as GridViewDateTimeColumn).FormatString = "{0:dd-MMM-yyyy HH:mm}";




            ConditionalFormattingObject objCondition = new ConditionalFormattingObject();
            objCondition.ApplyToRow = true;
            objCondition.RowBackColor = Color.Red;
            objCondition.RowForeColor = Color.White;

            objCondition.CellBackColor = Color.Red;
            objCondition.CellForeColor = Color.White;

            objCondition.ConditionType = ConditionTypes.Equal;
            objCondition.TValue1 = "3";
            grdLister.Columns["AdvBookingTypeId"].ConditionalFormattingObjectList.Add(objCondition);
            grdLister.EnableHotTracking = false;




            
           


            HideInActive(true);


       

        }

        private void HideInActive(bool hide)
        {

            if (hide)
            {
                DateTime dtNow = DateTime.Now.AddMinutes(1);
                grdLister.Rows.Where(c => c.Cells["EndDate"].Value != null)
                    .ToList().ForEach(c => c.IsVisible = c.Cells["EndDate"].Value.ToDateTime() > dtNow);


                grdLister.Rows.Where(c => c.Cells["AdvBookingTypeId"].Value.ToInt()==4)
                    .ToList().ForEach(c => c.IsVisible = false);
            }
            else
            {
                grdLister.Rows
                   .ToList().ForEach(c => c.IsVisible = true);


                grdLister.Rows.Where(c => c.Cells["AdvBookingTypeId"].Value.ToInt() == 4)
                  .ToList().ForEach(c => c.IsVisible = true);


                DateTime dt = DateTime.Now;
                foreach (var item in grdLister.Rows.Where(c => c.Cells["EndDate"].Value.ToDateTime()<dt))
                {

                    if (item.Cells["EndDate"].Value != null )
                    {
                    

                            item.Cells["BookingDate"].Style.BackColor = Color.LightPink;
                            item.Cells["BookingDate"].Style.ForeColor = Color.Black;
                            item.Cells["BookingDate"].Style.CustomizeFill = true;


                            item.Cells["Passenger"].Style.BackColor = Color.LightPink;
                            item.Cells["Passenger"].Style.ForeColor = Color.Black;
                            item.Cells["Passenger"].Style.CustomizeFill = true;


                            item.Cells["ContactNo"].Style.BackColor = Color.LightPink;
                            item.Cells["ContactNo"].Style.ForeColor = Color.Black;
                            item.Cells["ContactNo"].Style.CustomizeFill = true;



                            item.Cells["From"].Style.BackColor = Color.LightPink;
                            item.Cells["From"].Style.ForeColor = Color.Black;
                            item.Cells["From"].Style.CustomizeFill = true;



                            item.Cells["To"].Style.BackColor = Color.LightPink;
                            item.Cells["To"].Style.ForeColor = Color.Black;
                            item.Cells["To"].Style.CustomizeFill = true;


                            item.Cells["EndDate"].Style.BackColor = Color.LightPink;
                            item.Cells["EndDate"].Style.ForeColor = Color.Black;
                            item.Cells["EndDate"].Style.CustomizeFill = true;

                       
                    }



                    
                }


                foreach (var item in grdLister.Rows.Where(c => c.Cells["AdvBookingTypeId"].Value.ToInt()==4))
                {

                    


                        item.Cells["BookingDate"].Style.BackColor = Color.LightPink;
                        item.Cells["BookingDate"].Style.ForeColor = Color.Black;
                        item.Cells["BookingDate"].Style.CustomizeFill = true;


                        item.Cells["Passenger"].Style.BackColor = Color.LightPink;
                        item.Cells["Passenger"].Style.ForeColor = Color.Black;
                        item.Cells["Passenger"].Style.CustomizeFill = true;


                        item.Cells["ContactNo"].Style.BackColor = Color.LightPink;
                        item.Cells["ContactNo"].Style.ForeColor = Color.Black;
                        item.Cells["ContactNo"].Style.CustomizeFill = true;



                        item.Cells["From"].Style.BackColor = Color.LightPink;
                        item.Cells["From"].Style.ForeColor = Color.Black;
                        item.Cells["From"].Style.CustomizeFill = true;



                        item.Cells["To"].Style.BackColor = Color.LightPink;
                        item.Cells["To"].Style.ForeColor = Color.Black;
                        item.Cells["To"].Style.CustomizeFill = true;


                        item.Cells["EndDate"].Style.BackColor = Color.LightPink;
                        item.Cells["EndDate"].Style.ForeColor = Color.Black;
                        item.Cells["EndDate"].Style.CustomizeFill = true;


                   




                }

            }
        }

         void grdLister_CellDoubleClick(object sender, GridViewCellEventArgs e)
         {
             ViewDetailForm();
         }

         private void ViewDetailForm()
         {

             if (grdLister.CurrentRow != null && grdLister.CurrentRow is GridViewDataRowInfo)
             {
                 ShowBookingForm(grdLister.CurrentRow.Cells["Id"].Value.ToLong());
             }
             else
             {
                 ENUtils.ShowMessage("Please select a record");
             }
         }


         private void ShowBookingForm(long id)
         {


             frmAdvanceBookingCustomization frm = new frmAdvanceBookingCustomization(id);
           
            frm.ControlBox = true;
            frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm.MaximizeBox = false;
            frm.ShowDialog();

            frm.Dispose();
            GC.Collect();

         }


      
     
       

        public override void RefreshData()
        {
            ClearFilter();
            PopulateData();
        }


        public override void PopulateData()
        {
            try
            {


              
                

                    string searchTxt = txtSearch.Text.ToLower().Trim();
                    string col = ddlColumns.Text.Trim().ToLower();

                    if (searchTxt.Length < 3)
                        searchTxt = string.Empty;


                    DateTime? fromDate = dtpFromDate.Value.ToDateTimeorNull();
                    DateTime? toDate = dtpToDate.Value.ToDateTimeorNull();

                    bool col_name = false;
                    bool col_refNo = false;
                    bool col_telNo = false;
                    bool col_mobileno = false;
                  
                    bool col_pickupPoint = false;
                    bool col_destination = false;
                   

                    if (col == "passenger")
                    {
                        col_name = true;
                    }
                    else if (col == "reference")
                    {
                        col_refNo = true;
                    }
                    else if (col == "telephone no")
                    {
                        col_telNo = true;
                    }

                    else if (col == "mobile no")
                    {
                        col_mobileno = true;
                    }

               
                    else if (col == "pickup point")
                    {
                        col_pickupPoint = true;
                    }

                    else if (col == "destination")
                    {
                        col_destination = true;
                    }



                if (string.IsNullOrEmpty(searchTxt) && fromDate == null && toDate == null)
                {

                    //var data1 = 
                    //     .OrderByDescending(c => c.AddOn);


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.DeferredLoadingEnabled = false;

                        string subCompanyId = AppVars.DefaultBookingSubCompanyId.ToStr();

                        var query = (from a in db.AdvanceBookings.Where(c => ( c.AdvBookingTypeId == null || c.AdvBookingTypeId == 2 || c.AdvBookingTypeId == 3 || c.AdvBookingTypeId==4 )
                                     && (AppVars.DefaultBookingSubCompanyId==0 || (c.AdvanceBookingNo!=null && c.AdvanceBookingNo== subCompanyId)))
                                         //   join b in db.Gen_Companies on a.CompanyId equals b.Id into table2
                                         // from b in table2.DefaultIfEmpty()
                                     select new
                                     {
                                         Id = a.Id,
                                         AddOn = a.AddOn,
                                         RefNumber = a.AdvanceBookingNo,
                                         BookingDate = a.AddOn,
                                       
                                         Passenger = a.CustomerName,
                                         OrderNo=a.OrderNo,
                                         ContactNo = a.CustomerTelephoneNo != null && a.CustomerTelephoneNo != "" ? a.CustomerMobileNo + " - " + a.CustomerTelephoneNo : a.CustomerMobileNo,
                                         From = a.FromAddress,
                                         To = a.ToAddress,
                                         a.AdvBookingTypeId,
                                         EndDate= a.PickupDateTime
                                     }).ToList();


                        //    grdLister.MasterTemplate.BeginUpdate();
                        grdLister.DataSource = query;
                    }

                    //   grdLister.MasterTemplate.EndUpdate();
                }
                else
                {




                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.DeferredLoadingEnabled = false;

                        var query = (from a in db.AdvanceBookings.Where(c => c.AdvBookingTypeId == null || c.AdvBookingTypeId == 2 || c.AdvBookingTypeId == 3 || c.AdvBookingTypeId == 4)


                                     where

                                     (fromDate != null ||


                                 (col_name && (a.CustomerName.ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                     || (col_refNo && (a.AdvanceBookingNo.ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                     || (col_telNo && (a.CustomerTelephoneNo.ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                     || (col_mobileno && (a.CustomerMobileNo.ToLower().Contains(searchTxt) || searchTxt == string.Empty))

                                     || (col_pickupPoint && (a.FromAddress.ToLower().Contains(searchTxt) || searchTxt == string.Empty))
                                     || (col_destination && (a.ToAddress.ToLower().Contains(searchTxt) || searchTxt == string.Empty))

                                 )



                                     select new
                                     {
                                         Id = a.Id,
                                         AddOn = a.AddOn,
                                         RefNumber = a.AdvanceBookingNo,
                                         BookingDate = a.AddOn,

                                         Passenger = a.CustomerName,
                                         OrderNo = a.OrderNo,
                                         ContactNo = a.CustomerTelephoneNo != null && a.CustomerTelephoneNo != "" ? a.CustomerMobileNo + " - " + a.CustomerTelephoneNo : a.CustomerMobileNo,
                                         From = a.FromAddress,
                                         To = a.ToAddress,
                                         a.AdvBookingTypeId,
                                            EndDate = a.PickupDateTime
                                     }).ToList();



                        //    grdLister.MasterTemplate.BeginUpdate();
                        grdLister.DataSource = query;
                    }
                    //    grdLister.MasterTemplate.EndUpdate();
                }


                if (grdLister.Rows.Count > 0 && grdLister.Columns["AdvBookingTypeId"].ConditionalFormattingObjectList.Count > 0)
                {
                    grdLister.CurrentRow = grdLister.Rows.LastOrDefault();

                    HideInActive((chkShowInActive.Checked==false));
                }
               
            }
            catch (Exception ex)
            {


            }
        
            
        }




      

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find();

            }
        }



      

        private void Find()
        {

        
           
            PopulateData();
        }


        private void ClearFilter()
        {

          
          
            this.dtpFromDate.Value = null;
            this.dtpToDate.Value = null;
            this.txtSearch.Text = string.Empty;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ClearFilter();
            PopulateData();
        }


        private void grdLister_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            string name = gridCell.ColumnInfo.Name.ToLower();

            GridViewRowInfo row = gridCell.RowElement.RowInfo;
            long id = row.Cells["Id"].Value.ToLong();

           

          //  bool rtn = false;
            if (name == "btndelete")
            {
                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to delete a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    RadGridView grid = gridCell.GridControl;
                    grid.CurrentRow.Delete();
                }
            }


           
        }

        private void chkShowInActive_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(args.ToggleState== Telerik.WinControls.Enumerations.ToggleState.On)
            {
                HideInActive(false);
            }
            else
            {

                HideInActive(true);
            }
        }
    }
}

