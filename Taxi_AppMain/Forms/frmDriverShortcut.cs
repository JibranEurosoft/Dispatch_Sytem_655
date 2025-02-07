using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using Utils;

using Taxi_Model;
using Taxi_BLL;

using System.Threading;


using Telerik.WinControls;



namespace Taxi_AppMain
{
    public partial class frmDriverShortcut : Telerik.WinControls.UI.RadForm
    {


        public frmDriverShortcut()
        {

            InitializeComponent();
          
       
            LoadData();

            ddl_Driver.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        
            this.ddl_Driver.TextChanged+=new EventHandler(ddl_Driver_TextChanged);
   
            this.KeyDown += new KeyEventHandler(frmDriverShortcut_KeyDown);
         
            this.Load += FrmDriverShortcut_Load;
        }

        private void FrmDriverShortcut_Load(object sender, EventArgs e)
        {
            btnCallDriver.Visible = AppVars.listUserRights.Count(c => c.functionId.ToUpper() == "CLICK TO CALL") > 0;
        }

        //void DropDownListElement_TextChanging(object sender, TextChangingEventArgs e)
        //{
        //    //this.ddl_Driver.DropDownListElement.TextBox.cle.Filter = ClearFilterItem;


        //    //this.ddl_Driver.Filter = FilterItem;

        //    string s = ddl_Driver.Text;

        //    this.ddl_Driver.FilterExpression = "DriverName LIKE '%" + s + "%'";
        //}




        //private bool FilterItem(RadListDataItem item)
        //{
        //    if (item == null)
        //        return false;

        //    if (item.Text.Contains(ddl_Driver.DropDownListElement.TextBox.TextBoxItem.Text))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void LoadData()
        {
            try
            {


             

                    ComboFunctions.FillDriverNoCombo(ddl_Driver, c => c.IsActive == true && (AppVars.DefaultDriverSubCompanyId == 0 || c.SubcompanyId == AppVars.DefaultDriverSubCompanyId));

            }
            catch(Exception ex)
            {

            }

        }
       

     

        private  void ddl_Driver_TextChanged(object sender, EventArgs e)
        {
            if (ddl_Driver.SelectedValue != null)
            {
                var obj = ddl_Driver.Items.FirstOrDefault(c => c.Value.ToInt() == ddl_Driver.SelectedValue.ToInt());

                if (obj != null && ddl_Driver.Text.Length > 0)
                {
                    ddl_Driver.TextChanged -= new EventHandler(ddl_Driver_TextChanged);
                    ddl_Driver.Text = obj.Text;
                    ddl_Driver.DropDownListElement.SelectAllText();

                    ddl_Driver.TextChanged += new EventHandler(ddl_Driver_TextChanged);
                }
            }

           

        }

  


        private void frmDriverShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }

                if (ddl_Driver.SelectedValue == null)
                    return;



                int driverId = ddl_Driver.SelectedValue.ToInt();


                 if (e.KeyCode == Keys.A)
                {
                    ClearJob();
                }
                 else if (e.KeyCode == Keys.B)
                 {

                     BreakDriver();
                 }
                 else if (e.KeyCode == Keys.E)
                 {
                     ForceArrived();
                 }
                else if (e.KeyCode == Keys.X)
                {
                    RemoveRestriction();
                }

                else if (e.KeyCode == Keys.F)
                 {

                     LogoutDriver();
                 }


                 else if (e.KeyCode == Keys.I)
                 {
                     DriverInformation();
                 }
                 else if (e.KeyCode == Keys.J)
                 {
                     CompletedJobs();
                 }
                 else if (e.KeyCode == Keys.K)
                 {
                     PDAMessage();
                 }

               
               
                else if (e.KeyCode == Keys.M)
                {
                    ForcePOB();
                }

                else if (e.KeyCode == Keys.N)
                {
                    NoShow();
                }

                 else if (e.KeyCode == Keys.R)
                 {
                     ReCallJob();
                 }
                
                else if (e.KeyCode == Keys.S)
                {

                    LoginDriver();
                }

                 if (e.KeyCode == Keys.T)
                 {
                     TrackDriver();

                 }
              

                else if (e.KeyCode == Keys.U)
                {
                    SinBinDriver();
                }


                 else if (e.KeyCode == Keys.V)
                 {
                     ViewBooking();


                 }     

               

                else if (e.KeyCode == Keys.Z)
                {
                    SMSMessage();
                }
                    


            }
       
            catch (Exception ex)
            {


            }

        }


        private void TrackDriver()
        {
            if (ddl_Driver.SelectedValue == null)
                ENUtils.ShowMessage("Select any Driver");

            try
            {
                int driverId = ddl_Driver.SelectedValue.ToInt();


                General.RunTrackDriverCommand(driverId);

                //using (TaxiDataContext db = new TaxiDataContext())
                //{
                //    var objLogin = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId);

                //    if (objLogin == null)
                //    {
                //        ENUtils.ShowMessage("Driver is not Login");

                //    }
                //    else
                //    {
                //        long jobId = objLogin.CurrentJobId.ToLong();

                   
                       
                //            rptJobRouthPathGoogle rpt = new rptJobRouthPathGoogle(jobId > 0 ? db.Bookings.FirstOrDefault(c => c.Id == jobId) : null, true, driverId);
                //            rpt.ShowDialog();
                //            rpt.Dispose();

                //            GC.Collect();
                      

                //    }
                //}
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }

   
        private void NoShow()
        {

            try
            {

                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    UpdateChanges(false);

                    int driverId = ddl_Driver.SelectedValue.ToInt();
                    var list = from a in General.GetQueryable<Fleet_DriverQueueList>(c => c.Id > 0)
                               where a.DriverId == driverId && a.Status == true && a.CurrentJobId != null
                               select new
                               {

                                   Id = a.Id,

                               };
                    long jobId = 0;

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        jobId = db.Fleet_DriverQueueLists.Where(a => a.DriverId == driverId && a.Status == true && a.CurrentJobId != null).Select(c => c.CurrentJobId).FirstOrDefault().ToLong();

                    }



                    string val = list.ToStr();

                    if (jobId>0)
                    {


                      

                        //using (TaxiDataContext db = new TaxiDataContext())
                        //{
                        //    jobId = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Id == list.FirstOrDefault().Id).DefaultIfEmpty().CurrentJobId.ToLong();

                        //}




                        if (jobId != 0)
                        {

                            string[] driverNo = (ddl_Driver.SelectedItem.Text).Split('-');

                           
                                

                            General.ReCallBookingWithStatus(jobId.ToLong(), driverId.ToInt(), Enums.BOOKINGSTATUS.NOPICKUP, Enums.Driver_WORKINGSTATUS.AVAILABLE);
                            Thread.Sleep(500);

                          

                          


                            General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_ACTIVEBOOKINGS_DASHBOARD + "=" + jobId + "=syncdrivers");


                            if (Application.OpenForms.OfType<Form>().Count(c => c.Name == "frmBookingsList") > 0)
                            {
                                (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingsList") as frmBookingsList).SetRefreshWhenActive("");
                            }


                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                db.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), "Controller Pressed NO Pickup from Driver (" + driverNo[0] + ")");
                            }

                            UpdateChanges(true);
                        }
                        else
                        {

                            MessageBox.Show("No Current Job Found");
                        }


                    }
                    else
                    {

                        MessageBox.Show("No Current Job Found");
                    }
                }
            }
            catch (Exception ex)
            {

               
            }
        }

        private void ReCallJob()
        {
            if (ddl_Driver.SelectedValue == null)
                return;
            try
            {
                UpdateChanges(false);
                int driverId = ddl_Driver.SelectedValue.ToInt();
              
                int statusId=0;
                long jobId=0;
                string driverNO=string.Empty;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    Fleet_DriverQueueList objLogin = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId);

                    if (objLogin != null)
                    {

                        statusId = objLogin.DriverWorkStatusId.ToInt();
                        jobId = objLogin.CurrentJobId.ToLong();
                        driverNO = objLogin.Fleet_Driver.DriverNo.ToStr();

                    }
                }


                if (jobId == 0)
                {

                     
                    MessageBox.Show("No Current Job Found");
                    return;
                }
                else
                {
                    if (statusId == Enums.Driver_WORKINGSTATUS.NOTAVAILABLE || statusId == Enums.Driver_WORKINGSTATUS.SOONTOCLEAR)
                    {

                        MessageBox.Show("Job cannot be Re-Call as driver is on " + "POB or STC Status.");
                        return;

                    }
                }


                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to Re-Call a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    new Thread(delegate()
                    {

                        try
                        {
                            General.ReCallBooking(jobId, driverId);
                        }
                        catch
                        {

                        }
                       
                    }).Start();


                    using (TaxiDataContext dbX = new TaxiDataContext())
                    {
                        dbX.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), "Recall Job from Driver (" + driverNO + ")");
                    }

                    UpdateChanges(true);
                    // new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD);


                }
                
            }
            catch
            {


            }
        }

        private void ClearJob()
        {
            try
            {
                UpdateChanges(false);

                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    int driverId = ddl_Driver.SelectedValue.ToInt();
                    long Id = 0;
                    try
                    {


                        try
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                Id = db.Fleet_DriverQueueLists.Where(a => a.DriverId == driverId && a.Status == true && a.CurrentJobId != null).Select(c => c.Id).FirstOrDefault().ToLong();

                            }
                        }
                        catch
                        {

                        }

                        //var list = from a in General.GetQueryable<Fleet_DriverQueueList>(c => c.Id > 0)
                        //           where a.DriverId == driverId && a.Status == true && a.CurrentJobId != null
                        //           select new
                        //           {

                        //               Id = a.Id,
                        //               currentjobId = a.CurrentJobId
                        //           };



                        if (Id > 0)
                        {
                            General.ClearJobByController(Id);

                            //new Thread(delegate ()
                            //{
                            //    General.ClearDriverCurrentJob(list.FirstOrDefault().Id);

                            //}).Start();


                            // System.Threading.Thread.Sleep(1000);

                            //   new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD);

                            UpdateChanges(true);

                        }
                        else
                        {
                            MessageBox.Show("No Current Job Found");

                        }
                    }
                    catch
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);

            }

        }


        private void ViewBooking()
        {
            try
            {

                int driverId = ddl_Driver.SelectedValue.ToInt();

                long currentJobId = General.GetQueryable<Fleet_DriverQueueList>(a => a.Status == true && a.DriverId == driverId).FirstOrDefault().DefaultIfEmpty().CurrentJobId.ToLong();

                if (currentJobId > 0)
                {

                    General.ShowBookingForm(currentJobId.ToInt(), true, "", "", Enums.BOOKING_TYPES.LOCAL);
                }
                else
                {
                    MessageBox.Show("No Current Job Found");
                }
            }
            catch(Exception ex)
            {


            }

        }


        private void ForceArrived()
        {




            if (ddl_Driver.SelectedValue == null)
                return;

            try
            {
                UpdateChanges(false);

                int driverId = ddl_Driver.SelectedValue.ToInt();

                string actionType = "";



                actionType = "<<Arrive Job>>";



                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var obj = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId && c.CurrentJobId != null && (c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ONROUTE));


                    if (obj != null)
                    {

                        int statusId = obj.DriverWorkStatusId.ToInt();

                        long jobId = obj.CurrentJobId.ToLong();

                        string msg = "request pda=" + driverId + "=" + jobId + "=" + actionType + jobId + "=11";


                        new Thread(delegate()
                        {
                            General.SendMessageToPDA(msg);


                        }).Start();

                        System.Threading.Thread.Sleep(1000);
                        UpdateChanges(true);
                    }
                    else
                    {
                        MessageBox.Show("No Current Job Found");

                    }


                }


            }
            catch
            {


            }
        }

        private void ForcePOB()
        {
            if (ddl_Driver.SelectedValue == null)
                return;

            try
            {
                UpdateChanges(false);

                int driverId = ddl_Driver.SelectedValue.ToInt();

                string actionType = "";



                actionType = "<<POB Job>>";



                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var obj = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId && c.CurrentJobId != null && (c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ONROUTE || c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ARRIVED));


                    if (obj != null)
                    {

                        int statusId = obj.DriverWorkStatusId.ToInt();

                        long jobId = obj.CurrentJobId.ToLong();

                        string msg = "request pda=" + driverId + "=" + jobId + "=" + actionType + jobId + "=11";


                        new Thread(delegate()
                        {
                            General.SendMessageToPDA(msg);


                        }).Start();

                        System.Threading.Thread.Sleep(1000);
                        UpdateChanges(true);
                    }
                    else
                    {
                        MessageBox.Show("No Current Job Found");

                    }


                }


            }
            catch
            {


            }

        }

        private void LoginDriver()
        {
            if (ddl_Driver.SelectedValue == null)
                return;
            try
            {
                int driverId=ddl_Driver.SelectedValue.ToInt();

                using (TaxiDataContext db = new TaxiDataContext())
                {



                    if(db.Fleet_DriverQueueLists.Count(c=>c.Status==true && c.DriverId==driverId)==0)
                    {

                        if (db.Fleet_Driver_PDASettings.Where(c => c.DriverId == driverId && c.HasCompanyCars != null && c.HasCompanyCars == true).Count() > 0)
                        {



                        }
                        else
                        {

                            db.stp_LoginLogoutDriver(driverId, true, null);
                        }
                        new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                        UpdateChanges(true);
                    }
                }

               
               // (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard") as frmBookingDashBoard).RefreshDashBoardDrivers();

            }
            catch
            {


            }


        }

        private void BreakDriver()
        {
            if (ddl_Driver.SelectedValue == null)
                return;
            try
            {
                UpdateChanges(false);

                if (General.GetQueryable<Fleet_DriverQueueList>(null).Count(c => c.Status == true && c.DriverId == ddl_Driver.SelectedValue.ToInt()) == 0)
                    return;
               

          

                int statusId=Enums.Driver_WORKINGSTATUS.ONBREAK;

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    var obj= db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == ddl_Driver.SelectedValue.ToInt()); 
                   

                    if(obj!=null && (obj.DriverWorkStatusId==Enums.Driver_WORKINGSTATUS.AVAILABLE || obj.DriverWorkStatusId==Enums.Driver_WORKINGSTATUS.ONBREAK))
                    {
                        if(obj.DriverWorkStatusId==Enums.Driver_WORKINGSTATUS.ONBREAK)
                            statusId=Enums.Driver_WORKINGSTATUS.AVAILABLE;

                         db.stp_ChangeDriverStatus(ddl_Driver.SelectedValue.ToInt(),statusId);

                         new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                        UpdateChanges(true);
                        try
                          {



                            string msg = "onbreak--x";
                            if (statusId == Enums.Driver_WORKINGSTATUS.AVAILABLE)
                                msg = "available--x";

                                   General.SendMessageToPDA("request pda=" + ddl_Driver.SelectedValue.ToInt() + "=" + 0 + "="
                                                          + "Message>>" + msg + ">>" + String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "=4").Result.ToBool();

                                 


                             


                          }
                          catch (Exception ex)
                          {


                          }
                         

                    }
                }
             

              
               
            }
            catch
            {


            }
        }


        private void CompletedJobs()
        {

            try
            {
                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");
                    return;
                }
                else
                {


                    frmDriverEarning frm = new frmDriverEarning();
                    frm.SelectedDriverId = ddl_Driver.SelectedValue.ToInt();
                    frm.ShowDialog();
                    frm.Dispose();
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void SMSMessage()
        {

            try
            {
                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    int driverId = ddl_Driver.SelectedValue.ToInt();



                    string mobileNo = General.GetObject<Fleet_Driver>(c => c.Id == driverId).DefaultIfEmpty().MobileNo.ToStr();



                    frmSMSAll frm = new frmSMSAll(mobileNo);
                    frm.ShowDialog();



                }

            }
            catch (Exception ex)
            {


            }
        }

        private void DriverInformation()
        {

            try
            {
                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    int driverId = ddl_Driver.SelectedValue.ToInt();
                    frmSearchDriver frm = new frmSearchDriver(driverId);
                    frm.ShowDialog();

                }

            }
            catch (Exception ex)
            {

            }
        }



        private void SinBinDriver()
        {

            if (ddl_Driver.SelectedValue == null)
            {
                ENUtils.ShowMessage("Select any Driver");

                return;
            }



            try
            {

                frmSinBin frm = new frmSinBin(ddl_Driver.SelectedValue.ToInt());
                frm.ShowDialog();
                frm.Dispose();

            }
            catch (Exception ex)
            {


            }
        }

        private void LogoutDriver()
        {
            try
            {
                UpdateChanges(false);
                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    int driverId = ddl_Driver.SelectedValue.ToInt();
                    long Id = 0;
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        Id = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId 
                        && (c.DriverWorkStatusId==Enums.Driver_WORKINGSTATUS.AVAILABLE || c.DriverWorkStatusId==Enums.Driver_WORKINGSTATUS.ONBREAK)).DefaultIfEmpty().Id;
                    }

                    if (Id > 0)
                    {


                        ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard"))
                            .ForceLogoutDriver(Id, ddl_Driver.SelectedValue.ToInt(), false);

                        Thread.Sleep(500);
                        new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                        UpdateChanges(true);
                    }
                  

                }
            }
            catch (Exception ex)
            {


            }

        }

        private void PDAMessage()
        {
            try
            {
                if (ddl_Driver.SelectedValue == null)
                {
                    ENUtils.ShowMessage("Select any Driver");

                    return;
                }
                else
                {
                    int driverId = ddl_Driver.SelectedValue.ToInt();
                    frmMessages frm = new frmMessages(driverId);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    frm.Dispose();
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void ShowDespatchForm(Booking obj)
        {
            try
            {
                bool rtn = false;

                frmDespatchJob frm = new frmDespatchJob(obj);

                frm.ShowDialog();



                if (frm.SmsThread != null)
                    frm.SmsThread.Start();

                rtn = frm.SuccessDespatched;

                frm.Dispose();

                GC.Collect();

            }
            catch (Exception ex)
            {


            }

        }


    

        private void btnTrack_Click(object sender, EventArgs e)
        {
     
                TrackDriver();
        }

    
        private void btnSMSMessage_Click(object sender, EventArgs e)
        {

            SMSMessage();
        }      

        private void btnRecoverJob_Click(object sender, EventArgs e)
        {
         
            ReCallJob();
          
        }
       
        private void btnDriverInformation_Click(object sender, EventArgs e)
        {
            DriverInformation();
           
        }

        private void btnSinBin_Click(object sender, EventArgs e)
        {
            SinBinDriver();
        }    


        private void btnLogoutDriver_Click(object sender, EventArgs e)
        {
           
            LogoutDriver();
        }
     
        private void btnPDAMessage_Click(object sender, EventArgs e)
        {
            PDAMessage();
        }

        

        private void btnViewBooking_Click(object sender, EventArgs e)
        {
            ViewBooking();
        }
      
       

        private void btnClearJob_Click(object sender, EventArgs e)
        {
           
            ClearJob();
        }

       

        private void btnNoShow_Click(object sender, EventArgs e)
        {
            NoShow();
        }

        private void btnMobile_Click(object sender, EventArgs e)
        {
          
            ForcePOB();
        }

        private void btnForceArrivw_Click(object sender, EventArgs e)
        {
            ForceArrived();
        }


      
      

        private void btnBreak_Click(object sender, EventArgs e)
        {
            BreakDriver();
        }

        private void btnJobsDriverEarning_Click(object sender, EventArgs e)
        {

            CompletedJobs();
           
        }


        private void UnPanic(int driverId)
        {
            if (driverId == 0)
                return;




            try
            {


                UpdateChanges(false);



                bool success = General.SendMessageToPDA("request pda=" + driverId + "=" + 0 + "="
                                            + "Message>>" + "unpanic" + ">>" + String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "=4").Result.ToBool();

                    if (success)
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.stp_PanicUnPanicDriver(driverId, false);

                        }

                        new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                       UpdateChanges(true);
                    }
                  


              

            
            }
            catch (Exception ex)
            {


            }



        }



        private void btnPlot_Click(object sender, EventArgs e)
        {
         
            UnPanic(ddl_Driver.SelectedValue.ToInt());
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDriver();
        }

        private void btnRemoveGeoFencing_Click(object sender, EventArgs e)
        {

          
            RemoveRestriction();

           
        }

        private void RemoveRestriction()
        {

            if (ddl_Driver.SelectedValue == null)
                return;

            try
            {
                UpdateChanges(false);

                int driverId = ddl_Driver.SelectedValue.ToInt();

               


              



                using (TaxiDataContext db = new TaxiDataContext())
                {
                    var obj = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true
                    && c.DriverId == driverId && c.CurrentJobId != null);


                    if (obj != null)
                    {

                        int statusId = obj.DriverWorkStatusId.ToInt();

                        long jobId = obj.CurrentJobId.ToLong();

                        //   string msg = "request pda=" + driverId + "=" + jobId + "=" + actionType + jobId + "=11";


                        var objBooking = db.Bookings.FirstOrDefault(c => c.Id == jobId);
                        if (objBooking != null)
                        {
                            objBooking.OnHoldWaitingMins = 1;
                            objBooking.Booking_Logs.Add(new Booking_Log { AfterUpdate = "Restriction Removed by Controller (" + AppVars.LoginObj.UserName.ToStr() + ")", User = AppVars.LoginObj.UserName.ToStr(), UpdateDate = DateTime.Now, BookingId = jobId });

                            db.SubmitChanges();

                            UpdateChanges(true);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No Current Job Found");

                    }


                }


            }
            catch
            {


            }

        }

        private void UpdateChanges(bool applied)
        {
            if (applied)
            {


                lblStatus.Visible = false;
                lblStatus.Visible = true;
                errorProvider1.SetError(lblStatus, "Changes applied successfully!");

            }
            else
            {
                lblStatus.Visible = false;

            }
        }

        private void btnCallDriver_Click(object sender, EventArgs e)
        {
            if(ddl_Driver.SelectedValue!=null)
            General.ClickACallDriver(ddl_Driver.SelectedValue.ToInt(), "");
        }
    }
}
