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

using Telerik.WinControls;
using System.Linq.Expressions;


namespace Taxi_AppMain
{
    public partial class frmTrip : UI.SetupBase
    {

        RadDropDownMenu menu_Job = null;

        private bool AutoInc = true;

        BookingGroupBO objMaster = null;
       
        public struct COLS
        {
            public static string Check = "Check";
            public static string ID = "ID";
            public static string BookingId = "BookingId";
            public static string PickupDate = "PickupDate";
            public static string Vehicle = "Vehicle";
            public static string Passenger = "Passenger";
            public static string VehicleID = "VehicleID";            
            public static string RefNumber = "RefNumber";
            public static string NoOfPax = "NoOfPax";
            public static string PickupPoint = "PickupPoint";
            public static string Destination = "Destination";
            public static string ShuttleNo = "ShuttleNo";
            public static string Status = "Status";

        }
        public frmTrip()
        {
            InitializeComponent();
            InitializeConstructor();
           
           
        }

        public frmTrip(int Id)
        {
            InitializeComponent();
            InitializeConstructor();
            
         
        }


        void grdLister_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {


                e.ContextMenu = null;
                //GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                //if (cell == null)
                //    return;

                //else if (cell.GridControl.Name == "grdLister")
                //{

                //    if (menu_Job == null)
                //    {
                //        menu_Job = new RadDropDownMenu();                      

                //        RadMenuItem viewJobItem1 = new RadMenuItem("View Job");
                //        viewJobItem1.ForeColor = Color.DarkBlue;
                //        viewJobItem1.BackColor = Color.Orange;
                //        viewJobItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                //        viewJobItem1.Click += new EventHandler(viewJobItem1_Click);
                //        menu_Job.Items.Add(viewJobItem1);

                        
                        
                //    }

                //    e.ContextMenu = menu_Job;
                //    return;
               // }
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


         

            dtpFromDate.Value = DateTime.Now.ToDate() + TimeSpan.Parse("00:00:00");
            dtpTillDate.Value = DateTime.Now.ToDate() + TimeSpan.Parse("23:59:59");


            dtpTripDate.Value = DateTime.Now.ToDate();
            
            FormatChargesGrid();
            FormatShuttleListGrid();
       

            dtpShuttleDate.Value = DateTime.Now;

            grdLister.ShowGroupPanel = false;           
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdLister.ShowRowHeaderColumn = false;

            grdTripList.ShowGroupPanel = false;
            grdTripList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdTripList.ShowRowHeaderColumn = false;

            objMaster = new BookingGroupBO();
            this.SetProperties((INavigation)objMaster);

            grdLister.AllowAddNewRow = false;

            grdLister.CommandCellClick += new CommandCellClickEventHandler(grdLister_CommandCellClick);
            grdLister.ContextMenuOpening+=new ContextMenuOpeningEventHandler(grdLister_ContextMenuOpening);

            grdLister.ViewCellFormatting += new CellFormattingEventHandler(grdLister_ViewCellFormatting);

            grdTripList.ContextMenuOpening += GrdTripList_ContextMenuOpening;
            grdTripList.CommandCellClick += GrdTripList_CommandCellClick;

        }

        private void GrdTripList_CommandCellClick(object sender, EventArgs e)
        {
            GridCommandCellElement gridCell = (GridCommandCellElement)sender;
            if (gridCell.ColumnInfo.Name == "btnDelete")
            {
               int Id = grdTripList.CurrentRow.Cells["Id"].Value.ToInt();

                if (Id > 0)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                      
                        int tripstatusid = db.ExecuteQuery<int>("select TripStatusId from BookingGroup  where Id = " + Id + "").FirstOrDefault();
                        if (tripstatusid == 1)
                        {
                            db.ExecuteQuery<int>("update Booking set GroupJobId = null , DriverId = null where GroupJobId = " + Id + "");
                            db.ExecuteQuery<int>("Delete from BookingGroup_Order  where GroupJobId = " + Id + "");
                            db.ExecuteQuery<int>("Delete from BookingGroup  where Id = " + Id + " ");                                                       
                            gridCell.RowInfo.Delete();

                            objMaster.Clear();
                            objMaster.PrimaryKeyValue = null;
                            OnCreateNew();
                        }

                        


                    }
                }
                

            }
        }

        private void GrdTripList_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {
                GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;
                if (cell == null)
                    return;

                else if (cell.GridControl.Name == "grdTripList")
                {

                    if (menu_Job == null)
                    {
                        menu_Job = new RadDropDownMenu();

                        RadMenuItem DispatchItem2 = new RadMenuItem("Assign Driver");
                        DispatchItem2.ForeColor = Color.DarkBlue;
                        DispatchItem2.BackColor = Color.Orange;
                        DispatchItem2.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        DispatchItem2.Click += DispatchItem2_Click;
                        DispatchItem2.Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items.Add(DispatchItem2);

                        RadMenuItem DispatchItem1 = new RadMenuItem("Dispatch Shuttle");
                        DispatchItem1.ForeColor = Color.DarkBlue;
                        DispatchItem1.BackColor = Color.Orange;
                        DispatchItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        DispatchItem1.Click += DispatchItem1_Click;
                        DispatchItem1.Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items.Add(DispatchItem1);



                        DispatchItem1 = new RadMenuItem("Send Future Shuttle");
                        DispatchItem1.ForeColor = Color.DarkBlue;
                        DispatchItem1.BackColor = Color.Orange;
                        DispatchItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        DispatchItem1.Click += DispatchItemPre_Click;
                        DispatchItem1.Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items.Add(DispatchItem1);



                        DispatchItem1 = new RadMenuItem("Cancel Shuttle");
                        DispatchItem1.ForeColor = Color.DarkBlue;
                        DispatchItem1.BackColor = Color.Orange;
                        DispatchItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        DispatchItem1.Click += CancelItem1_Click;
                        DispatchItem1.Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items.Add(DispatchItem1);




                        DispatchItem1 = new RadMenuItem("Recover Shuttle");
                        DispatchItem1.ForeColor = Color.DarkBlue;
                        DispatchItem1.BackColor = Color.Orange;
                        DispatchItem1.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        DispatchItem1.Click += RecoverItem1_Click;
                        DispatchItem1.Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items.Add(DispatchItem1);



                        menu_Job.Tag = "grdTripList";
                    }
                    else
                    {
                        menu_Job.Items[0].Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items[1].Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items[2].Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();
                        menu_Job.Items[3].Tag = cell.GridControl.CurrentRow.Cells["Id"].Value.ToLong();


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

        private void DispatchItem2_Click(object sender, EventArgs e)
        {
            AllocateDriver();

            Populate();
        }

        private bool VerifyCurrentRow()
        {
            bool rtn = true;

            if (grdTripList.CurrentView != null && grdTripList.CurrentView.CurrentRow == null)
            {
                
                 grdTripList.CurrentRow = grdTripList.Rows[0];
                
                
                if (grdTripList.CurrentView != null && grdTripList.CurrentView.CurrentRow == null)
                {

                    rtn = false;
                }

            }

            return rtn;


        }

        private void AllocateDriver()
        {
            try
            {

                if (menu_Job.Tag != null)
                {
                    long Id = 0;
                    int openFrom = 1;

                    if (menu_Job.Tag.ToStr() == "grdTripList" && grdTripList.CurrentRow != null && grdTripList.CurrentRow is GridViewDataRowInfo)
                    {
                        if (VerifyCurrentRow())
                        {
                            Id = grdTripList.CurrentRow.Cells["Id"].Value.ToLong();
                        }

                    }
                    

                    if (Id != 0)
                    {

                        frmAssignedDriver frmAllocate = new frmAssignedDriver(Id, openFrom);
                        frmAllocate.StartPosition = FormStartPosition.CenterScreen;
                        frmAllocate.ShowDialog();
                        frmAllocate.Dispose();
                    }

                }


            }
            catch (Exception ex)
            {
                //   ENUtils.ShowMessage(ex.Message);

            }

        }

        private void DispatchItem1_Click(object sender, EventArgs e)
        {
            DispatchTrip((sender as RadMenuItem).Tag.ToLong());
        }

        private void DispatchItemPre_Click(object sender, EventArgs e)
        {
            DispatchTrip((sender as RadMenuItem).Tag.ToLong(),0,17);
        }

        private void CancelItem1_Click(object sender, EventArgs e)
        {
            DispatchTrip((sender as RadMenuItem).Tag.ToLong(), Enums.BOOKING_TRIPSTATUS.CANCELLED);
        }

        private void RecoverItem1_Click(object sender, EventArgs e)
        {
            DispatchTrip((sender as RadMenuItem).Tag.ToLong(),5);
        }



        private void DispatchTrip(long tripId,int tripUpdateStatusId=0,int tripStatusId=0)
        {
            if (tripId == 0)
                return;

            Trip trip = null;
            using (TaxiDataContext db = new TaxiDataContext())
            {




                var objTrip = db.BookingGroups.FirstOrDefault(c => c.Id == tripId);

                if (objTrip.DriverId == null)
                {

                    MessageBox.Show("Please assign a driver");
                    return;
                }

                    if (objTrip.TripStatusId.ToInt()==Enums.BOOKING_TRIPSTATUS.CANCELLED)
                {
                    MessageBox.Show("Cannot Dispatch cancelled shuttle");
                    return;
                }
               else if (objTrip.TripStatusId.ToInt() == Enums.BOOKING_TRIPSTATUS.COMPLETED)
                {
                    MessageBox.Show("Cannot Dispatch completed shuttle");
                    return;
                }
                if (objTrip.TripStatusId.ToInt() == 5 || objTrip.TripStatusId.ToInt() ==6 || objTrip.TripStatusId.ToInt()==7)
                {
                    objTrip.TripStatusId = 1;

                }


                trip = new Trip();
                trip.TripStatusId = objTrip.TripStatusId.ToInt();


                if (tripStatusId > 0)
                    trip.TripStatusId = tripStatusId;
              


                trip.TripId = objTrip.Id;
                trip.TripNo = objTrip.GroupName.ToStr();
                trip.followSequence = objTrip.IsFollowSequence.ToBool();
                trip.DriverId = objTrip.DriverId.ToInt();


                if (tripUpdateStatusId > 0)
                {
                    trip.TripStatusId = tripUpdateStatusId;

                    if (trip.TripStatusId == Enums.BOOKING_TRIPSTATUS.CANCELLED)
                        trip.Message = "Your Shuttle has been cancelled by controller";
                   else if (trip.TripStatusId ==5)
                        trip.Message = "Your Shuttle has been recovered by controller";

                }             
            }



            if (trip != null)
            {
                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(trip);


                General.DispatchTrip(trip.TripId, json);


                if (tripUpdateStatusId > 0)
                {
                    Populate();
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

                        decimal? escortprice = null;

                        string Destination = row.Cells[COLS.Destination].Value.ToStr();
                        string PickupPoint = row.Cells[COLS.PickupPoint].Value.ToStr();
                        string Passenger = row.Cells[COLS.NoOfPax].Value.ToStr();

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


                        BookingBO objMaster = new BookingBO();
                        objMaster.GetByPrimaryKey(id);

                        if (objMaster.Current != null)
                        {

                            objMaster.Current.ToAddress = Destination;
                            objMaster.Current.FromAddress = PickupPoint;
                            objMaster.Current.CustomerName = Passenger;

                            if (waitingMins != null)
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

        private void MoveRow(bool moveUp)
        {
            GridViewRowInfo currentRow = grdLister.CurrentRow;
            if (currentRow == null)
            {
                return;
            }
            int index = moveUp ? currentRow.Index - 1 : currentRow.Index + 1;
            if (index < 0 || index >= grdLister.RowCount)
            {
                return;
            }
            grdLister.Rows.Move(index, currentRow.Index);
            grdLister.CurrentRow = grdLister.Rows[index];
        }

        private void FormatShuttleListGrid()
        {

            try
            {
               
                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = "Id";
                grdTripList.Columns.Add(col);

                
                col = new GridViewTextBoxColumn();
                // col.IsVisible = false;
                col.ReadOnly = true;
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.Width = 250;
                col.HeaderText = "Shuttle No";
                col.Name = "ShuttleNo";
                grdTripList.Columns.Add(col);

                GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
                colDt.Name = "ShuttleDateTime";
                colDt.ReadOnly = true;
                colDt.Width = 250;
                colDt.TextAlignment = ContentAlignment.MiddleCenter;
                colDt.HeaderText = "Shuttle Date-Time";
                colDt.SortOrder = RadSortOrder.Ascending;
                colDt.Sort(RadSortOrder.Ascending, true);
                grdTripList.Columns.Add(colDt);

                col = new GridViewTextBoxColumn();
                col.Name = "Driver";
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.ReadOnly = true;
                col.HeaderText = "Driver";
                col.Width = 250;
                grdTripList.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = "TotalNoOfPax";
                col.ReadOnly = true;
                col.HeaderText = "Total No Of Pax";
                col.Width = 250;
                col.TextAlignment = ContentAlignment.MiddleCenter;
                grdTripList.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = "TotalBooking";
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.ReadOnly = true;
                col.HeaderText = "Total Booking";
                col.Width = 250;
                grdTripList.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = "TripStatus";
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.ReadOnly = true;
                col.HeaderText = "Trip Status";
                col.Width = 250;
                grdTripList.Columns.Add(col);

                (grdTripList.Columns["ShuttleDateTime"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
                (grdTripList.Columns["ShuttleDateTime"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";
                                
                AddDeleteColumn(grdTripList);
                
                grdTripList.AllowAutoSizeColumns = true;
                grdTripList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdTripList.AllowAddNewRow = false;
                grdTripList.AllowRowReorder = true;
                grdTripList.ShowGroupPanel = false;
                grdTripList.AutoCellFormatting = true;
                grdTripList.ShowRowHeaderColumn = false;
                grdTripList.EnableFiltering = true;


            }
            catch
            {

            }
        }

        private void AddDeleteColumn(RadGridView grid)
        {
            GridViewCommandColumn col = new GridViewCommandColumn();
            col.Width = 100;
            col.Name = "btnDelete";
            col.UseDefaultText = true;
            col.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            col.DefaultText = "Delete";
            col.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            grid.Columns.Add(col);

        }


        private void Populate()
        {
            try
            {
                
                DateTime? FromShuttleDate = dtpShuttleDate.Value.ToDate() + TimeSpan.Parse("00:00:00");
                DateTime? ToShuttleDate = dtpShuttleDate.Value.ToDate() + TimeSpan.Parse("23:59:59");

                var list2 = General.GetGeneralList<BookingGroup>(c=>c.TripDate.Value.Date >= FromShuttleDate && c.TripDate.Value.Date <= ToShuttleDate);

                var list = (from b in list2
                            where (b.TripStatusId!=Enums.BOOKING_TRIPSTATUS.CANCELLED && b.TripStatusId!=Enums.BOOKING_TRIPSTATUS.COMPLETED)
                            orderby b.TripDate descending
                            select new
                            {

                                Id = b.Id,
                                ShuttleNo = b.GroupName,
                                ShuttleDateTime = b.TripDate,
                                Driver = b.DriverId,
                                TotalNoOfPax = b.TotalNoOfPassenger,
                                TotalBookings = b.TotalBookings,
                                TripStatus = b.TripStatusId,

                            }).ToList();


                grdTripList.Rows.Clear();

                GridViewRowInfo row;

                int cnt = list.Count;

                cnt = list.Count;

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    for (int i = 0; i < cnt; i++)
                    {

                        row = grdTripList.Rows.AddNew();

                        row.Cells["Id"].Value = list[i].Id.ToStr();
                        row.Cells["ShuttleNo"].Value = list[i].ShuttleNo.ToStr();
                        row.Cells["ShuttleDateTime"].Value = list[i].ShuttleDateTime.ToStr();
                        row.Cells["TotalNoOfPax"].Value = list[i].TotalNoOfPax.ToStr();
                        row.Cells["TotalBooking"].Value = list[i].TotalBookings.ToStr();
                       
                        string Driver = db.Fleet_Drivers.Where(c => c.Id == list[i].Driver.ToInt()).Select(c => c.DriverName).ToList().FirstOrDefault().ToStr();
                        if (Driver != string.Empty)
                            row.Cells["Driver"].Value = Driver;

                        string TripStatus = db.BookingTripStatus.Where(c => c.Id == list[i].TripStatus.ToInt()).Select(c => c.StatusName).FirstOrDefault().ToStr();
                        if (TripStatus != string.Empty)
                            row.Cells["TripStatus"].Value = TripStatus;

                    }
                }

                grdTripList.CurrentRow = null;
                grdTripList.EndUpdate();
                grdTripList.ReadOnly = false;
                grdTripList.AllowEditRow = true;


                grdTripList.Columns["ShuttleDateTime"].HeaderText = "Shuttle created time";
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }
        }


        private void FormatChargesGrid()
        {

            try
            {
                GridViewCheckBoxColumn chk = new GridViewCheckBoxColumn();
                chk.IsVisible = true;
                chk.Width = 20;
                chk.Name = COLS.Check;
                grdLister.Columns.Add(chk);

                GridViewTextBoxColumn col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = "Id";
                grdLister.Columns.Add(col);
               
                col = new GridViewTextBoxColumn();
                col.IsVisible = false;
                col.Name = COLS.BookingId;
                grdLister.Columns.Add(col);

                GridViewDateTimeColumn colDt = new GridViewDateTimeColumn();
                colDt.Name = "PickupDate";
                colDt.ReadOnly = true;
                colDt.Width = 70;
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
                col.HeaderText = "Passenger";
                col.Name = "Passenger";
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
                col.Name = COLS.NoOfPax;
                col.ReadOnly = true;
                col.HeaderText = "No of Pax";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.Name = COLS.ShuttleNo;
                col.ReadOnly = true;
                col.HeaderText = "Shuttle No";
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.HeaderText = "Pickup Point";
                col.Name = "PickupPoint";
                col.ReadOnly = true;
                grdLister.Columns.Add(col);

                col = new GridViewTextBoxColumn();
                col.HeaderText = "Destination";
                col.Name = "Destination";
                col.ReadOnly = true;
                grdLister.Columns.Add(col);



                col = new GridViewTextBoxColumn();
                col.HeaderText = "Status";
                col.Name = "Status";
                col.ReadOnly = true;
                grdLister.Columns.Add(col);


                (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).CustomFormat = "dd/MM/yyyy HH:mm";
                (grdLister.Columns["PickUpDate"] as GridViewDateTimeColumn).FormatString = "{0:dd/MM/yyyy HH:mm}";


                grdLister.Columns["PickUpDate"].Width = 60;
                grdLister.Columns["RefNumber"].Width = 30;
                grdLister.Columns["Vehicle"].Width = 30;

                grdLister.Columns[COLS.VehicleID].Width = 60;

                grdLister.Columns[COLS.NoOfPax].Width = 45;
                grdLister.Columns["PickUpPoint"].Width = 70;
                grdLister.Columns["Destination"].Width = 70;

                grdLister.Columns[COLS.Status].Width = 40;

                grdLister.Columns["PickUpDate"].HeaderText = "Pickup Date-Time";
                grdLister.Columns["RefNumber"].HeaderText = "Ref #";
                grdLister.Columns["PickUpPoint"].HeaderText = "Pickup Point";
                             
                grdLister.CellBeginEdit += new GridViewCellCancelEventHandler(grdLister_CellBeginEdit);
                grdLister.MultiSelect = true;

                grdLister.AllowAutoSizeColumns = true;
                grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                grdLister.AllowAddNewRow = false;
                grdLister.AllowRowReorder = true;
                grdLister.ShowGroupPanel = false;
                grdLister.AutoCellFormatting = true;
                grdLister.ShowRowHeaderColumn = false;
                grdLister.EnableFiltering = true;


                grdLister.EnableSorting = false;
                grdLister.AllowColumnChooser = false;
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

                if (e.Column is GridViewCheckBoxColumn)
                {

                    if (e.Row.Tag != null)
                        e.Cancel = true;
                    
                }
            }
            catch 
            {


            }
        }

        
        public override void Save()
        {
            OnSave();
            OnNew();
        }


        private void OnSave()
        {

            try
            {

                if (this.AutoInc == false && txtTripNo.Text.Trim() == string.Empty)
                {
                    ENUtils.ShowMessage("Required : Shuttle No");
                    return;
                }

                if (objMaster.PrimaryKeyValue == null)
                {
                    objMaster.New();

                    objMaster.Current.TripStatusId = Enums.BOOKING_TRIPSTATUS.WAITING;
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

                //objMaster.Current.VehicleTypeId = ddlVehicleType.SelectedValue.ToIntorNull();
                //objMaster.Current.CompanyId = ddlCompany.SelectedValue.ToIntorNull();
               // objMaster.Current.DriverId = ddlDriver.SelectedValue.ToIntorNull();
                objMaster.Current.TripDate = dtpTripDate.Value.ToDateTimeorNull();
                objMaster.Current.IsFollowSequence = chkFollowSequence.Checked;
                                     
                objMaster.Current.FromDate = dtpFromDate.Value.ToDateTime();                                       
                objMaster.Current.TillDate = dtpTillDate.Value.ToDateTime();                   
                objMaster.Current.TotalNoOfPassenger =  txtNoOfPax.Text.ToInt();
              

                string[] jobIds = grdLister.Rows.Where(c => c.Cells[COLS.Check].Value.ToBool() == true && c.Tag == null)
                    .Select(c => c.Cells["BookingId"].Value.ToStr())
                                            .ToArray<string>();

                if (jobIds.ToList().Count() == 0)
                {
                    ENUtils.ShowMessage("Please select atleast one job.");
                    return;
                }

                objMaster.Current.TotalBookings = jobIds.Count();
                objMaster.Save();            
                objMaster.GetByPrimaryKey(objMaster.PrimaryKeyValue);

                int groupJobId = objMaster.PrimaryKeyValue.ToInt();

                string arr = string.Join(",", jobIds);

                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.ExecuteQuery<int>("Update Booking set GroupJobId = NULL,bookingstatusid=1 where groupJobId = " + groupJobId + "");

                    string query = string.Empty;
                    if (objMaster.Current.DriverId != null)
                    {
                         query = "Update Booking set GroupJobId = " + groupJobId + " , driverid = " + objMaster.Current.DriverId + " where Id in  (" + arr + ")";
                    }
                    else
                    {
                        query = "Update Booking set GroupJobId = " + groupJobId + " , driverid = null where Id in  (" + arr + ")";
                    }
                    db.ExecuteQuery<int>(query);

                    db.ExecuteQuery<int>("delete from BookingGroup_Order where GroupJobId = "+ groupJobId + "");

                    for (int i = 0; i < grdLister.Rows.Count; i++)
                    {
                        if (grdLister.Rows[i].Cells[COLS.Check].Value.ToBool() == true)
                        {
                            int BookingId = grdLister.Rows[i].Cells[COLS.BookingId].Value.ToInt();
                            int OrderId = grdLister.Rows[i].Index;

                            db.ExecuteQuery<int>("insert into BookingGroup_Order Values (" + BookingId + "," + OrderId + ", "+ groupJobId + ")");

                        }
                        



                    }

  
                    if (objMaster.Current.TripStatusId.ToInt() == Enums.BOOKING_TRIPSTATUS.INPROGRESS)
                    {
                     
                        DispatchTrip(objMaster.Current.Id);
                    }


                }

                objMaster.Clear();
                objMaster.PrimaryKeyValue = null;
                OnCreateNew();

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

 
  
       
        private void btnPickBooking_Click(object sender, EventArgs e)
        {
            try
            {
                
             

                DateTime? fromDate = dtpFromDate.Value.ToDateTime();
                DateTime? tillDate = dtpTillDate.Value.ToDateTime();//+ new TimeSpan(23,59,59);
                           
                string error = string.Empty;
                
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


               
         
            
                
                Expression<Func<Booking,bool>> expPickBooking=null;

                expPickBooking = c =>
                                    (c.BookingStatusId == Enums.BOOKINGSTATUS.WAITING
                                    || c.BookingStatusId == Enums.BOOKINGSTATUS.ONROUTE
                                    || c.BookingStatusId == Enums.BOOKINGSTATUS.ARRIVED
                                    || c.BookingStatusId == Enums.BOOKINGSTATUS.POB
                                      || c.BookingStatusId == Enums.BOOKINGSTATUS.STC
                                        || c.BookingStatusId == Enums.BOOKINGSTATUS.REJECTED
                                          || c.BookingStatusId == Enums.BOOKINGSTATUS.PENDING_START
                                           || c.BookingStatusId == Enums.BOOKINGSTATUS.BID

                                    || c.BookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || c.BookingStatusId == Enums.BOOKINGSTATUS.COMPLETED)
                                   && (c.PickupDateTime >= fromDate && c.PickupDateTime <= tillDate);




          

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var bookings = db.Bookings.Where(expPickBooking).ToList();

                    var list = (from b in bookings
                          
                                select new
                                {
                                    Id = b.Id,
                                    PickupDate = b.PickupDateTime,
                                    RefNo = b.BookingNo,
                                    Vehicle = b.Fleet_VehicleType.VehicleType,
                                    Passenger = b.CustomerName,
                                    NoofPax = b.NoofPassengers,
                                    PickupPoint =  b.FromAddress,
                                    Destination =  b.ToAddress,
                                    GroupJobId = b.GroupJobId,
                                    ShuttleNo =b.GroupJobId!=null? b.BookingGroup.GroupName:"",
                                    Status=b.BookingStatus.StatusName,
                                    b.BookingStatusId
                                }).OrderBy(c => c.PickupDate).ToList();



                    GridViewRowInfo row;

                    int cnt = list.Count;

                    cnt = list.Count;

                    for (int i = 0; i < cnt; i++)
                    {


                        if (grdLister.Rows.Count(c => c.Cells[COLS.BookingId].Value.ToLong() == list[i].Id.ToLong()) > 0)
                            continue;

                        row = grdLister.Rows.AddNew();


                        row.Cells[COLS.BookingId].Value = list[i].Id.ToStr();
                        row.Cells[COLS.RefNumber].Value = list[i].RefNo.ToStr();
                        row.Cells[COLS.PickupDate].Value = list[i].PickupDate.ToDateTime();
                        row.Cells[COLS.Vehicle].Value = list[i].Vehicle.ToStr();
                        row.Cells[COLS.NoOfPax].Value = list[i].NoofPax.ToStr();
                        row.Cells[COLS.PickupPoint].Value = list[i].PickupPoint.ToStr();
                        row.Cells[COLS.Destination].Value = list[i].Destination.ToStr();
                        row.Cells[COLS.ShuttleNo].Value = list[i].ShuttleNo.ToStr();
                        row.Cells[COLS.Passenger].Value = list[i].Passenger.ToStr();
                        row.Cells[COLS.Status].Value = list[i].Status.ToStr();
                     


                        if (list[i].GroupJobId.ToInt() > 0 )
                        {
                            row.Cells[COLS.Check].Value = true;
                            row.Tag = "true";


                            row.Cells[COLS.ShuttleNo].Style.BackColor = Color.LightGreen;
                            row.Cells[COLS.ShuttleNo].Style.NumberOfColors = 1;
                        }
                        else if(list[i].BookingStatusId.ToInt()==Enums.BOOKINGSTATUS.COMPLETED || list[i].BookingStatusId.ToInt() == Enums.BOOKINGSTATUS.NOPICKUP)
                        {
                            row.Tag = "true";
                           

                        }
                        else
                        {
                            row.Cells[COLS.Check].Value = false;
                            row.Tag = null;
                            row.Cells[COLS.ShuttleNo].Style.BackColor = Color.White ;
                            row.Cells[COLS.ShuttleNo].Style.NumberOfColors = 4;
                        }
                    }

                    lblTotalNoPassenger.Text = "Total No of Passenger :";

                    int total = list.Sum(c => c.NoofPax).ToInt();

                    lblTotalNoPassenger.Visible = true;
                    lblTotalNoPassenger.Text = lblTotalNoPassenger.Text + " " + total.ToStr();

                    txtNoOfPax.Text = total.ToStr();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }

        public void DespatchJob()
        {
            try
            {

                if (AppVars.IsTelephonist)
                {
                    ENUtils.ShowMessage("Permission Denied");
                    return;
                }


                if (grdTripList.CurrentRow != null && grdTripList.CurrentRow is GridViewDataRowInfo)
                {

                    if (grdTripList.CurrentView != null && grdTripList.CurrentView.CurrentRow == null)
                    {
                        
                            grdTripList.CurrentRow = grdTripList.Rows[0];
                        
                        if (grdTripList.CurrentView != null && grdTripList.CurrentView.CurrentRow == null)
                        {

                            return;
                        }


                    }

                  //  OnDespatch(grdTripList.CurrentRow.Cells["Id"].Value.ToLong());



                }
            }
            catch (Exception ex)
            {


            }

        }


        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            OnSave();          
        }

        public override void OnNew()
        {
            txtTripNo.Text = string.Empty;
          
                    
            grdLister.Rows.Clear();
            lblTotalNoPassenger.Visible = false;
          
           
        }
        

        private void frmInvoice_Shown(object sender, EventArgs e)
        {
            grdLister.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

         //   btnAddNewShuttle.Location = new Point(this.Width - 185, 0);
          //  btnAddNewShuttle.BringToFront();
       
        }     

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            objMaster.Clear();
            objMaster.PrimaryKeyValue = null;
            OnCreateNew();
        }

        private  void OnCreateNew()
        {
            txtTripNo.Text = string.Empty;
          
            dtpFromDate.Value = DateTime.Now.ToDate() + TimeSpan.Parse("00:00:00");
            dtpTillDate.Value = DateTime.Now.ToDate() + TimeSpan.Parse("23:59:59");
            lblTotalNoPassenger.Visible = false;
            dtpShuttleDate.Value = DateTime.Now ;

            dtpTripDate.Value = DateTime.Now;
            grdLister.Rows.Clear();             
           
            
        }

        private void chkAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < grdLister.Rows.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.Check].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < grdLister.Rows.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.Check].Value = false;
                }
            }
        }

        private void grdTripList_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchShuttle_Click(object sender, EventArgs e)
        {
            
        }

        private void grdTripList_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                using (TaxiDataContext db = new TaxiDataContext())
                {

                int GroupJobId = grdTripList.CurrentRow.Cells["Id"].Value.ToInt();

                    objMaster.GetByPrimaryKey(grdTripList.CurrentRow.Cells["Id"].Value.ToInt());

                txtTripNo.Text = objMaster.Current.GroupName ;
                dtpTripDate.Value = objMaster.Current.TripDate.ToDateTime();


                
                
                dtpFromDate.Value = objMaster.Current.FromDate.ToDateTime();
                dtpTillDate.Value = objMaster.Current.TillDate.ToDateTime();
                
                if (objMaster.Current.IsFollowSequence == true)
                {
                    chkFollowSequence.Checked = true;
                }
                else
                {
                    chkFollowSequence.Checked = false;
                }

                    var list1 = General.GetGeneralList<Booking>(c=>c.GroupJobId == GroupJobId).ToList();
                    var list2 = db.ExecuteQuery<GroupJob_Order>("select BookingId, OrderId, GroupJobId from BookingGroup_Order where GroupJobId = " + GroupJobId + "").ToList();

                    var listBooking = (from b in list1
                                       join c in list2 on b.Id equals c.Bookingid 
                                       select new
                                       {
                                           Id = b.Id,
                                           PickupDate = b.PickupDateTime,
                                           RefNo = b.BookingNo,
                                           Vehicle = b.Fleet_VehicleType.VehicleType,
                                           Passenger = b.CustomerName,
                                           ShuttleNo = b.BookingGroup.GroupName,
                                           NoofPax = b.NoofPassengers,
                                           PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
                                           Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
                                           OrderId = c.OrderId,
                                           
                                           Status = b.BookingStatus.StatusName,
                                           b.BookingStatusId
                                       }).OrderBy(c => c.OrderId).ToList();


                grdLister.RowCount = listBooking.Count;
                grdLister.BeginUpdate();

                for (int i = 0; i < listBooking.Count; i++)
                {
                    grdLister.Rows[i].Cells[COLS.BookingId].Value = listBooking[i].Id;// list[i][0].ToLongorNull();
                    grdLister.Rows[i].Cells[COLS.RefNumber].Value = listBooking[i].RefNo;
                    grdLister.Rows[i].Cells[COLS.PickupDate].Value = listBooking[i].PickupDate;
                    grdLister.Rows[i].Cells[COLS.Vehicle].Value = listBooking[i].Vehicle;
                    grdLister.Rows[i].Cells[COLS.Passenger].Value = listBooking[i].Passenger;
                    grdLister.Rows[i].Cells[COLS.NoOfPax].Value = listBooking[i].NoofPax.ToInt();
                    grdLister.Rows[i].Cells[COLS.ShuttleNo].Value = listBooking[i].ShuttleNo;
                    grdLister.Rows[i].Cells[COLS.PickupPoint].Value = listBooking[i].PickupPoint.ToStr();
                    grdLister.Rows[i].Cells[COLS.Destination].Value = listBooking[i].Destination.ToStr();
                    grdLister.Rows[i].Cells[COLS.Check].Value = true;
                    grdLister.Rows[i].Cells[COLS.Status].Value = listBooking[i].Status.ToStr();
                 }

                    lblTotalNoPassenger.Text = "Total No of Passenger :";

                    int total = listBooking.Sum(c => c.NoofPax).ToInt();
                    
                    lblTotalNoPassenger.Visible = true;
                    lblTotalNoPassenger.Text = lblTotalNoPassenger.Text + " " + total.ToStr();

                    txtNoOfPax.Text = total.ToStr();

                grdLister.CurrentRow = null;
                grdLister.EndUpdate();
                grdLister.ReadOnly = false;
                grdLister.AllowEditRow = true;

                }

            }
            catch
            {


            }
        }

        private void dtpShuttleDate_ValueChanged(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveRow(true);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveRow(false);
        }
    }
}


public class GroupJob_Order
{
    public int Bookingid;
    public int OrderId;
    public int GroupJobId;
}