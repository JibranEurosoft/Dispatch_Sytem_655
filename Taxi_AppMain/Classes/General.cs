using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DAL;
using Taxi_Model;
using System.Linq.Expressions;
using Utils;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using UI;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;
using System.Threading;

using System.Data.Linq;
using System.Text.RegularExpressions;
using Taxi_BLL;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Microsoft.Reporting.WinForms;
using Taxi_AppMain.Classes;
using System.Xml;
using System.Data;
using System.Net;


using DotNetCoords;

using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;

namespace Taxi_AppMain
{
    public class General
    {
      
       public static int? CallerIdType = null;

        public class stp_GetPlotDetailsForBookingResult
        {
            public int Bookings;
            public int Vehicles;
            public int Clear;
            public int Busy;
            public string Plot;


        }


        #region CommandRegion
        public static void RunTrackDriverCommand(int driverId)
        {
            

            using (TaxiDataContext db = new TaxiDataContext())
            {

               

                
                 

                    var objLogin = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId);

                    if (objLogin == null)
                    {
                        ENUtils.ShowMessage("Driver is not Login");

                    }
                    else
                    {
                        long jobId = objLogin.CurrentJobId.ToLong();



                        rptJobRouthPathGoogle rpt = new rptJobRouthPathGoogle(jobId > 0 ? db.Bookings.FirstOrDefault(c => c.Id == jobId) : null, true, driverId);
                        rpt.ShowDialog();
                        rpt.Dispose();

                        GC.Collect();


                    }
               
            }
        }


        public static void RunBreakCommand(int driverid)
        {
            if (General.GetQueryable<Fleet_DriverQueueList>(null).Count(c => c.Status == true && c.DriverId == driverid) == 0)
                return;




            int statusId = Enums.Driver_WORKINGSTATUS.ONBREAK;

            using (TaxiDataContext db = new TaxiDataContext())
            {

                var obj = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverid);


                if (obj != null && (obj.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.AVAILABLE || obj.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ONBREAK))
                {
                    if (obj.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ONBREAK)
                        statusId = Enums.Driver_WORKINGSTATUS.AVAILABLE;

                    db.stp_ChangeDriverStatus(driverid, statusId);

                    new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                  
                    try
                    {

                     

                        string msg = "onbreak--x";
                        if (statusId == Enums.Driver_WORKINGSTATUS.AVAILABLE)
                            msg = "available--x";

                        

                            General.SendMessageToPDA("request pda=" + driverid + "=" + 0 + "="
                                                    + "Message>>" + msg + ">>" + String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "=4").Result.ToBool();

                        

                        


                    }
                    catch (Exception ex)
                    {


                    }


                }
            }


        }


        public static void RunForceArrivedCommand(int driverId)
        {
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


                    new Thread(delegate ()
                    {
                        General.SendMessageToPDA(msg);


                    }).Start();

                    System.Threading.Thread.Sleep(1000);
                    
                }
                else
                {
                    MessageBox.Show("No Current Job Found");

                }


            }
        }


        public static bool RunRemoveRestrictionCommand(int driverId)
        {

            bool IsRun = false;






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

                        IsRun = true;
                      
                    }

                }
                else
                {
                    MessageBox.Show("No Current Job Found");

                }


            }

            return IsRun;
        }

        public static bool RunLogoutDriverCommand(int driverId)
        {
            bool IsRun = false;
            long Id = 0;

            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    Id = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Status == true && c.DriverId == driverId
                    && (c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.AVAILABLE || c.DriverWorkStatusId == Enums.Driver_WORKINGSTATUS.ONBREAK)).DefaultIfEmpty().Id;
                }

                if (Id > 0)
                {


                    ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard"))
                        .ForceLogoutDriver(Id, driverId, false);

                    Thread.Sleep(500);
                    new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                    IsRun = true;
                }
            }
            catch
            {

            }

            return IsRun;
        }


        public static bool RunLoginDriverCommand(int driverId)
        {
            bool isRun = false;
            try
            {
               

                using (TaxiDataContext db = new TaxiDataContext())
                {



                    if (db.Fleet_DriverQueueLists.Count(c => c.Status == true && c.DriverId == driverId) == 0)
                    {

                        if (db.Fleet_Driver_PDASettings.Where(c => c.DriverId == driverId && c.HasCompanyCars != null && c.HasCompanyCars == true).Count() > 0)
                        {



                        }
                        else
                        {

                            db.stp_LoginLogoutDriver(driverId, true, null);
                        }
                        new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_DASHBOARD_DRIVER);
                        isRun = true;
                    }
                }


                // (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard") as frmBookingDashBoard).RefreshDashBoardDrivers();

            }
            catch
            {


            }

            return isRun;
        }

        public static bool RunSinbinDriverCommand(int driverId)
        {


            try
            {

                frmSinBin frm = new frmSinBin(driverId);
                frm.ShowDialog();
                frm.Dispose();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public static bool RunViewBookingCommand(int driverId)
        {
            bool isRun = false;
            try
            {
               
              

                long currentJobId = General.GetQueryable<Fleet_DriverQueueList>(a => a.Status == true && a.DriverId == driverId).FirstOrDefault().DefaultIfEmpty().CurrentJobId.ToLong();

                if (currentJobId > 0)
                {

                    isRun = true;
                    General.ShowBookingForm(currentJobId.ToInt(), true, "", "", Enums.BOOKING_TYPES.LOCAL);
                }
                else
                {
                    MessageBox.Show("No Current Job Found");
                }
            }
            catch (Exception ex)
            {


            }

            return isRun;
        }

        public static bool RunSMSMessageCommand(int driverId)
        {
            bool isRun = false;
            try
            {

                string mobileNo = General.GetObject<Fleet_Driver>(c => c.Id == driverId).DefaultIfEmpty().MobileNo.ToStr();



                frmSMSAll frm = new frmSMSAll(mobileNo);
                frm.ShowDialog();
                frm.Dispose();
                isRun = true;
            }
            catch
            {

            }
          

                return isRun;
            
        }


        public static bool RunDriverInformationCommand(int driverId)
        {

            frmSearchDriver frm = new frmSearchDriver(driverId);
            frm.ShowDialog();
            frm.Dispose();

            return true;
        }

        public static bool RunCompletedJobsCommand(int driverId)
        {
            frmDriverEarning frm = new frmDriverEarning();
            frm.SelectedDriverId = driverId;
            frm.ShowDialog();
            frm.Dispose();

            return true;
        }

        public static bool RunPDAMessageCommand(int driverId)
        {

            frmMessages frm = new frmMessages(driverId);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            frm.Dispose();

            return true;
        }

        public static bool RunForcePOBCommand(int driverId)
        {
            bool isRun = false;
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


                    new Thread(delegate ()
                    {
                        General.SendMessageToPDA(msg);


                    }).Start();

                    System.Threading.Thread.Sleep(1000);
                    isRun = true;
                }
                else
                {
                    MessageBox.Show("No Current Job Found");

                }


            }


            return isRun;

        }

        public static bool RunNoShowCommand(int driverId)
        {
            bool isRun = false;

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

            if (jobId > 0)
            {




                //using (TaxiDataContext db = new TaxiDataContext())
                //{
                //    jobId = db.Fleet_DriverQueueLists.FirstOrDefault(c => c.Id == list.FirstOrDefault().Id).DefaultIfEmpty().CurrentJobId.ToLong();

                //}




                if (jobId != 0)
                {

                    string driverNo = "";



                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        driverNo=db.Fleet_Drivers.Where(c => c.Id == driverId).Select(c => c.DriverNo).FirstOrDefault();

                    }


                        General.ReCallBookingWithStatus(jobId.ToLong(), driverId.ToInt(), Enums.BOOKINGSTATUS.NOPICKUP, Enums.Driver_WORKINGSTATUS.AVAILABLE);
                    Thread.Sleep(500);






                    General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_ACTIVEBOOKINGS_DASHBOARD + "=" + jobId + "=syncdrivers");


                    if (Application.OpenForms.OfType<Form>().Count(c => c.Name == "frmBookingsList") > 0)
                    {
                        (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingsList") as frmBookingsList).SetRefreshWhenActive("");
                    }


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), "Controller Pressed NO Pickup from Driver (" + driverNo + ")");
                    }

                    isRun = true;
                   // UpdateChanges(true);
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

            return isRun;
        }


        public static bool RunRecallJobCommand(int driverId)
        {

            bool isRun = false;
            try
            {
               

                int statusId = 0;
                long jobId = 0;
                string driverNO = string.Empty;
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
                    return false;
                }
                else
                {
                    if (statusId == Enums.Driver_WORKINGSTATUS.NOTAVAILABLE || statusId == Enums.Driver_WORKINGSTATUS.SOONTOCLEAR)
                    {

                        MessageBox.Show("Job cannot be Re-Call as driver is on " + "POB or STC Status.");
                        return false;

                    }
                }


                if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to Re-Call a Booking ? ", "", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                {

                    new Thread(delegate ()
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

                    isRun = true;
                  


                }

            }
            catch
            {


            }
            return isRun;


        }


        public static void RunClearCommand(int driverId)
        {
           
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

          

                if (Id > 0)
                {
               
                    ClearJobByController(Id);                

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



        #endregion


        public static string DespatchPreJobs(long advancejobid)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";




                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                URL = baseUrl + "/api/Supplier/DispatchAllocatedJobs?value=" + advancejobid.ToStr();


                WebRequest request = HttpWebRequest.Create(URL);

                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;


                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }

            return rtn;
        }


        public static decimal GetETADistance(string origin, string destination, string key,string vias="")
        {
            decimal res = 0.00m;
            try
            {

                if (origin.ToStr().Trim() == destination.ToStr().Trim())
                    return res;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var obj = new
                {
                    originLat = Convert.ToDouble(origin.Split(',')[0]),
                    originLng = Convert.ToDouble(origin.Split(',')[1]),
                    destLat = Convert.ToDouble(destination.Split(',')[0]),
                    destLng = Convert.ToDouble(destination.Split(',')[1]),
                    defaultclientid = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(),
                    keys = key,
                    MapType = AppVars.objPolicyConfiguration.MapType.ToInt(),
                    sourceType = "dispatch",
                    routeType = AppVars.routemode.ToStr(),
                    vias
                };


                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                string API =Program.objLic.AppServiceUrl+"GetETADistance" + "?json=" + json;

                try
                {


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                    request.ContentType = "application/json; charset=utf-8";
                    request.Accept = "application/json";
                    request.Method = WebRequestMethods.Http.Post;
                    request.Proxy = null;
                    request.ContentLength = 0;



                    using (WebResponse responsea = request.GetResponse())
                    {

                        using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                        {
                            res = sr.ReadToEnd().ToDecimal();
                        }
                    }

                }
                catch(Exception ex)
                {
                    if(ex.Message.ToLower().Contains("ssl"))
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API.Replace("https","http"));
                        request.ContentType = "application/json; charset=utf-8";
                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Post;
                        request.Proxy = null;
                        request.ContentLength = 0;



                        using (WebResponse responsea = request.GetResponse())
                        {

                            using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                            {
                                res = sr.ReadToEnd().ToDecimal();
                            }
                        }
                    }


                }

            }
            catch(Exception ex)
            {
                try
                {
                    File.AppendAllText(Application.StartupPath + "\\GetETADistance_exception.txt", DateTime.Now.ToStr() + "," + ex.Message + Environment.NewLine);

                }
                catch
                {


                }

            }
            return res;

        }

        public static string GetETATime(string origin, string destination, string key)
        {
            string res = "";
            try
            {
                var obj = new
                {
                    originLat = Convert.ToDouble(origin.Split(',')[0]),
                    originLng = Convert.ToDouble(origin.Split(',')[1]),
                    destLat = Convert.ToDouble(destination.Split(',')[0]),
                    destLng = Convert.ToDouble(destination.Split(',')[1]),
                    defaultclientid = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(),
                    keys = key,
                    MapType = AppVars.objPolicyConfiguration.MapType.ToInt(),
                     sourceType = "dispatch"

                };


                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                string API = Program.objLic.AppServiceUrl+ "GetETA" + "?json=" + json;


                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                    request.ContentType = "application/json; charset=utf-8";
                    request.Accept = "application/json";
                    request.Method = WebRequestMethods.Http.Post;
                    request.Proxy = null;
                    request.ContentLength = 0;

                    using (WebResponse responsea = request.GetResponse())
                    {

                        using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                        {
                            res = sr.ReadToEnd().ToStr();
                        }
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message.ToLower().Contains("ssl"))
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API.Replace("https", "http"));
                        request.ContentType = "application/json; charset=utf-8";
                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Post;
                        request.Proxy = null;
                        request.ContentLength = 0;



                        using (WebResponse responsea = request.GetResponse())
                        {

                            using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                            {
                                res = sr.ReadToEnd().ToStr();
                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {

            }
            return res;

        }


        public static string GetPlaces(string location,  string keyword,string key, decimal radius)
        {
            string res = "";
            try
            {
                var obj = new
                {
                    originLat = Convert.ToDouble(location.Split(',')[0]),
                    originLng = Convert.ToDouble(location.Split(',')[1]),              
                    defaultclientid = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(),
                    keys = key,
                    MapType = AppVars.objPolicyConfiguration.MapType.ToInt(),
                    sourceType="dispatch",
                    keywordSearch=keyword,
                    radius=radius
                };


                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                string API = Program.objLic.AppServiceUrl+"GetPlaces" + "?json=" + json;


                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                    request.ContentType = "application/json; charset=utf-8";
                    request.Accept = "application/json";
                    request.Method = WebRequestMethods.Http.Post;
                    request.Proxy = null;
                    request.ContentLength = 0;

                    using (WebResponse responsea = request.GetResponse())
                    {

                        using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                        {

                            res = sr.ReadToEnd().ToStr();
                        }
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message.ToLower().Contains("ssl"))
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API.Replace("https", "http"));
                        request.ContentType = "application/json; charset=utf-8";
                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Post;
                        request.Proxy = null;
                        request.ContentLength = 0;



                        using (WebResponse responsea = request.GetResponse())
                        {

                            using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                            {
                                res = sr.ReadToEnd().ToStr();
                            }
                        }
                    }

                }

              

            }
            catch (Exception ex)
            {

            }
            return res;

        }



        public static void UpdateSupplierStatus(long jobId,int driverId,int bookingStatusId, string status,string reason)
        {
            try
            {
                if (jobId > 0)
                {


                    try
                    {
                        string URL = "";


                        var json = new { JobId = jobId, Status = status, BookingStatusId = bookingStatusId, UserName = AppVars.LoginObj.UserName.ToStr(), DriverId = driverId, Reason = reason };




                        string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                        URL = baseUrl + "/api/Supplier/UpdateSupplierStatus?mesg=" + Newtonsoft.Json.JsonConvert.SerializeObject(json);
                        WebRequest request = HttpWebRequest.Create(URL);
                        request.Headers.Add("Authorization", "");
                        request.ContentType= "application/json";
                        System.Net.WebRequest.DefaultWebProxy = null;
                        request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                        WebResponse response = request.GetResponse();
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                            string rtn = reader.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                }
            }
            catch
            {

            }
        }


        public static void DispatchTrip(long tripId,string json)
        {
            try
            {
                if (tripId > 0)
                {


                    try
                    {
                        string URL = "";



                      

                      
                        string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                        URL = baseUrl + "/api/Supplier/dispatchtrip?json=" + json;
                        WebRequest request = HttpWebRequest.Create(URL);
                        request.Headers.Add("Authorization", "");
                        
                        System.Net.WebRequest.DefaultWebProxy = null;
                        request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                        WebResponse response = request.GetResponse();
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                          string  rtn = reader.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                }
            }
            catch
            {

            }
        }

        public static void ClearJobByController(long Id)
        {
            try
            {
                if (Id != 0)
                {

                    
                        UpdateClearManualJob(Id);

                   
                  
                }
            }
            catch
            {

            }
        }


        public static string GetRegisterCardTransactionDetails(long receiptId)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";










                //   string json = Newtonsoft.Json.JsonConvert.SerializeObject(c);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/GetRegisterCardTransactionDetails?receiptId=" + receiptId.ToStr();
                WebRequest request = HttpWebRequest.Create(URL);
                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }



            }
            catch (Exception ex)
            {
            }
            return rtn;
        }


        public static string GetTransactionDetails(long receiptId)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";



              

                 
            



                //   string json = Newtonsoft.Json.JsonConvert.SerializeObject(c);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                   URL = baseUrl + "/api/Supplier/GetTransactionDetails?receiptId=" + receiptId.ToStr();
                    WebRequest request = HttpWebRequest.Create(URL);
                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }


                
            }
            catch (Exception ex)
            {
            }
            return rtn;
        }

        public static string UpdateClearManualJob(long queueId,int paymenttypeid=0,string transactionid="",string isval="")
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";



                var c = new
                {
                    QueueId = queueId,
                    ClearBy = AppVars.LoginObj.UserName.ToStr(),
                    PaymentTypeId = paymenttypeid,
                    Transactionid = transactionid,
                    IsValidate = isval
                };
                
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(c);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/manualclearjob?json=" + json;
                WebRequest request = HttpWebRequest.Create(URL);
                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
            }
            return rtn;
        }


        public static payload UploadFile(string fileNamePrefix, string filePath)
        {
            payload res = null;
            try
            {
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                string url = baseUrl + "/api/Supplier/UploadFile/";

                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                string base64Text = Convert.ToBase64String(imageArray);
                var uri = new Uri(url);

                if (fileNamePrefix.Contains("/"))
                    fileNamePrefix = fileNamePrefix.Replace("/", "").Trim();

                if (fileNamePrefix.Contains("\""))
                    fileNamePrefix = fileNamePrefix.Replace("\"", "").Trim();


                if (fileNamePrefix.Contains("!"))
                    fileNamePrefix = fileNamePrefix.Replace("!", "").Trim();

                if (fileNamePrefix.Contains("<"))
                    fileNamePrefix = fileNamePrefix.Replace("<", "").Trim();

                if (fileNamePrefix.Contains(">"))
                    fileNamePrefix = fileNamePrefix.Replace(">", "").Trim();

                if (fileNamePrefix.Contains("|"))
                    fileNamePrefix = fileNamePrefix.Replace("|", "").Trim();

                if (fileNamePrefix.Contains("*"))
                    fileNamePrefix = fileNamePrefix.Replace("*", "").Trim();

                if (fileNamePrefix.Contains(":"))
                    fileNamePrefix = fileNamePrefix.Replace(":", "").Trim();

                if (fileNamePrefix.Contains("$"))
                    fileNamePrefix = fileNamePrefix.Replace("$", "").Trim();

                if (fileNamePrefix.Contains("?"))
                    fileNamePrefix = fileNamePrefix.Replace("?", "").Trim();

                if (fileNamePrefix.Contains("&"))
                    fileNamePrefix = fileNamePrefix.Replace("&", "").Trim();

                var payload = new
                {
                    imageName = fileNamePrefix,
                    file = base64Text,
                    BaseUrl = baseUrl

                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpClient httpClient = new HttpClient();
                var stringContent = new StringContent
                (Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(uri, stringContent).Result;
                httpClient.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;


                res = Newtonsoft.Json.JsonConvert.DeserializeObject<payload>(sd);
            }
            catch
            {

            }
            return res;
         
        }

        public static payload UploadEscortFile(string fileNamePrefix, string filePath)
        {
            payload res = null;
            try
            {
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                string url = baseUrl + "/api/Supplier/UploadEscortFile/";

                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                string base64Text = Convert.ToBase64String(imageArray);
                var uri = new Uri(url);

                if (fileNamePrefix.Contains("/"))
                    fileNamePrefix = fileNamePrefix.Replace("/", "").Trim();

                if (fileNamePrefix.Contains("\""))
                    fileNamePrefix = fileNamePrefix.Replace("\"", "").Trim();


                if (fileNamePrefix.Contains("!"))
                    fileNamePrefix = fileNamePrefix.Replace("!", "").Trim();

                if (fileNamePrefix.Contains("<"))
                    fileNamePrefix = fileNamePrefix.Replace("<", "").Trim();

                if (fileNamePrefix.Contains(">"))
                    fileNamePrefix = fileNamePrefix.Replace(">", "").Trim();

                if (fileNamePrefix.Contains("|"))
                    fileNamePrefix = fileNamePrefix.Replace("|", "").Trim();

                if (fileNamePrefix.Contains("*"))
                    fileNamePrefix = fileNamePrefix.Replace("*", "").Trim();

                if (fileNamePrefix.Contains(":"))
                    fileNamePrefix = fileNamePrefix.Replace(":", "").Trim();

                if (fileNamePrefix.Contains("$"))
                    fileNamePrefix = fileNamePrefix.Replace("$", "").Trim();

                if (fileNamePrefix.Contains("?"))
                    fileNamePrefix = fileNamePrefix.Replace("?", "").Trim();

                if (fileNamePrefix.Contains("&"))
                    fileNamePrefix = fileNamePrefix.Replace("&", "").Trim();

                var payload = new
                {
                    imageName = fileNamePrefix,
                    file = base64Text,
                    BaseUrl = baseUrl

                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpClient httpClient = new HttpClient();
                var stringContent = new StringContent
                (Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(uri, stringContent).Result;
                httpClient.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;


                res = Newtonsoft.Json.JsonConvert.DeserializeObject<payload>(sd);
            }
            catch
            {

            }
            return res;

        }


        public static string GetVTRACKMileage(DateTime startDate,DateTime endDate,string vehicleReg,string clientId)
        {
           
            try
            {
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                string url = "https://api-eurosofttech.co.uk/general/api/vtrack-api";

                

                var payload = new
                {
                    fromDateTime =string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", DateTime.Now.AddMinutes(-360)),
                    toDateTime = string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", DateTime.Now.AddMinutes(-260)),
                    VehicleReg = "MGZ 9067",
                    clientId= "62794dac2b9600fd90308cfc"
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpClient httpClient = new HttpClient();
                var stringContent = new StringContent
                (Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(url, stringContent).Result;
                httpClient.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;


              //  res = Newtonsoft.Json.JsonConvert.DeserializeObject<payload>(sd);
            }
            catch(Exception ex)
            {

            }
            return "";

        }


        public class payload
        {

            public string message { get; set; }
            public string filePath { get; set; }
        }

        public static string UpdateFlightAlert(string flightNo, string date, string info, DateTime arrivalTime)
        {


            string rtn = "";

            try
            {


                if (AppVars.listUserRights.Count(c => c.functionId == "ENABLE FLIGHT ALERT") ==0)
                    return "";
                

                new Thread(delegate ()
                {
                    try
                    {

                        string arrival = "", departure = "";
                        if (info.Contains(","))
                        {
                            arrival = info.Split(',')[0];
                            departure = info.Split(',')[1];

                        }

                        FlightAlert alert = new FlightAlert();
                        alert.obj.FlightNo = flightNo;
                        alert.obj.IsTest = false;
                        alert.obj.Arrival = "";
                        alert.obj.departure = "";
                        
                        alert.obj.date = date.Split(' ')[0].Trim();

                        string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                        alert.obj.alertUrl = baseUrl + "/api/Supplier/PostAlert";



                        if (arrivalTime.Year < 2019)
                            alert.obj.departure = departure;
                        else
                            alert.obj.Arrival = arrival;
                        
                        alert.CallAPI();
                    }
                    catch(Exception ex)
                    {

                    }
                }).Start();

            }
            catch
            {

            }
            return rtn;
        }

        public static string CalculateETA(string origin, string destination)
        {

            string estimatedTime = string.Empty;
            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return "";



            decimal miles = 0.00m;

            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();





            try
            {

                if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                {

                }
                else
                {
                    origin += ", UK";
                }


                if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                {


                }
                else
                {
                    destination += ", UK";
                }



                if (string.IsNullOrEmpty(directionKey))
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                        if (directionKey.Length == 0)
                            directionKey = " ";
                        else
                            directionKey = "&key=" + directionKey;
                    }

                }



                if (AppVars.objPolicyConfiguration.MapType.ToInt() == 1)
                {
                    string URL = "";

                    URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&alternatives=true&units=imperial" + directionKey + "&sensor=false";
                    URL = string.Format(URL, origin, destination);



                    WebRequest request = HttpWebRequest.Create(URL);

                    request.Headers.Add("Authorization", "");
                    System.Net.WebRequest.DefaultWebProxy = null;
                    request.Proxy = System.Net.WebRequest.DefaultWebProxy;



                    WebResponse response = request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                        RootObject responseData = parser.Deserialize<RootObject>(reader.ReadToEnd());
                        if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                        {

                            var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                            //if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                            //{
                            //    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                            //}
                            //else
                            //{
                            //    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                            //}




                            estimatedTime = (objShortest.legs[0].duration.text.ToStr());

                        }
                    }
                }
                else
                {

                    //               public class clsETA
                    //{
                    //    public double? originLat;
                    //    public double? originLng;
                    //    public double? destLat;
                    //    public double? destLng;
                    //    public string keys;
                    //    public string defaultclientid;
                    //    public string token;

                    //}
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                 //   var json = new { originLat=origin.Split(',')[0], originLng= origin.Split(',')[1], destLat= destination.Split(',')[0], destLng= destination.Split(',')[1], defaultclientid=AppVars.objPolicyConfiguration.DefaultClientId.ToStr(), token="", keys = "3AFVxo9lo4YV4NVnqgz1,uCIGBo3LGjk4d02fxXGtvw,avsHjHri-tP5Su5wV7xyPBWwmdqOtEKK2Atn0xgDnrM" };
                    clsETA obj = new clsETA();
                    obj.originLat =Convert.ToDouble( origin.Split(',')[0]);
                    obj.originLng = Convert.ToDouble(origin.Split(',')[1]);
                    obj.destLat = Convert.ToDouble(destination.Split(',')[0]);
                    obj.destLng = Convert.ToDouble(destination.Split(',')[1]);
                    obj.defaultclientid = AppVars.objPolicyConfiguration.DefaultClientId.ToStr();
                    obj.keys = "3AFVxo9lo4YV4NVnqgz1,uCIGBo3LGjk4d02fxXGtvw,avsHjHri-tP5Su5wV7xyPBWwmdqOtEKK2Atn0xgDnrM";
                    //   obj.originLat = Convert.ToDouble(origin.Split(',')[0]);

                 string  json=  new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                    string  API = "https://cabtreasureappapi.co.uk/CabTreasureWebApi/Home/GetETA" + "?json=" + json;


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                    request.ContentType = "application/json; charset=utf-8";
                    request.Accept = "application/json";
                    request.Method = WebRequestMethods.Http.Post;
                    request.Proxy = null;
                    request.ContentLength = 0;

                    WebResponse responsea = request.GetResponse();

                    StreamReader sr = new StreamReader(responsea.GetResponseStream());
                    string res = sr.ReadToEnd();

                    return res;

                }
            }
            catch(Exception ex)
            {



            }

            return estimatedTime;
        }

        public static List<WeekDay> GetWeekDays2()
        {
            List<WeekDay> list = new List<WeekDay>();
            list.Add(new WeekDay { Id = 1, Name = "Monday" });
            list.Add(new WeekDay { Id = 2, Name = "Tuesday" });
            list.Add(new WeekDay { Id = 3, Name = "Wednesday" });
            list.Add(new WeekDay { Id = 4, Name = "Thursday" });
            list.Add(new WeekDay { Id = 5, Name = "Friday" });
            list.Add(new WeekDay { Id = 6, Name = "Saturday" });
            list.Add(new WeekDay { Id = 0, Name = "Sunday" });
            return list;
        }



        public static List<WeekDay> GetWeekDays()
        {
            List<WeekDay> list = new List<WeekDay>();
            list.Add(new  WeekDay{  Id=1, Name="Mon"  });
            list.Add(new WeekDay { Id = 2, Name = "Tues" });
            list.Add(new WeekDay { Id = 3, Name = "Wed" });
            list.Add(new WeekDay { Id = 4, Name = "Thurs" });
            list.Add(new WeekDay { Id = 5, Name = "Fri" });
            list.Add(new WeekDay { Id = 6, Name = "Sat" });
            list.Add(new WeekDay { Id = 7, Name = "Sun" });
            //            1   Mon
            //2   Tues
            //3   Wed
            //4   Thurs
            //5   Fri
            //6   Sat
            //7   Sun

            return list;
        }

        public static string ResetPool()
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

               


                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                URL = baseUrl + "/api/Supplier/ResetApp?value=" + "test";


                WebRequest request = HttpWebRequest.Create(URL);

                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;


                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }

            return rtn;
        }

        public static string GetDriverTrackingHistory(string val)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

              

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                URL = baseUrl + "/api/Supplier/GetDriverTrackingHistory?mesg=" + val;


                WebRequest request = HttpWebRequest.Create(URL);

                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;


                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }

            return rtn;
        }

        public static string UpdateAutoDispatchMode(int mode, string data = "")
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                if (data.Length == 0)
                {
                    data = mode.ToStr() + "|" + AppVars.LoginObj.UserName.ToStr() + "|" + Environment.MachineName.ToStr();
                }


                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();

                URL = baseUrl + "/api/Supplier/changeAutoDispatchMode?value=" + data;


                WebRequest request = HttpWebRequest.Create(URL);

                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;


                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    rtn = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }

            return rtn;
        }



        public static string DownloadRecordingFile(string FolderPath, string BaseURL, string ClientUserName, string UniqueID, string CallerId,DateTime bookingDate)
        {





            try
            {

                if(CallerIdType==null)
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        CallerIdType= db.CallerIdType_Configurations.Select(c => c.VOIPCLIType).FirstOrDefault().DefaultIfEmpty().ToInt();
                    }
                }


                if (CallerIdType == 2)  // YESTECH
                {
                    TCS.Call.MakeCall c = new TCS.Call.MakeCall();
                   return  c.YESTECH_GetRecordingFile(FolderPath, BaseURL, "", UniqueID, bookingDate, AppVars.objPolicyConfiguration.CallRecordingToken);

                }

                else
                {

                    string fileName = UniqueID + "_" + CallerId + ".wav";
                    string FileUrl = BaseURL.Trim().TrimEnd('/') + "/" + ClientUserName + "/" + fileName;
                    //string FloderPath = System.IO.Directory.GetCurrentDirectory() + "\\" + "Recordings";

                    if (!System.IO.Directory.Exists(FolderPath))
                    {
                        System.IO.Directory.CreateDirectory(FolderPath);
                    }

              //      ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                    //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                 //   System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Tls12;


                    using (WebClient wc = new WebClient())
                    {
                        
                        wc.DownloadFile(
                            // Param1 = Link of file
                            new System.Uri(FileUrl),
                            // Param2 = Path to save
                            FolderPath + "\\" + fileName
                        );
                    }



                    return FolderPath + "\\" + fileName;

                }
            }
            catch (Exception exe)
            {
            }

            return string.Empty;
        }

        private bool client_RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                //Check to make sure the domain is correct
                X509Certificate2 certificate_details = (X509Certificate2)certificate;
                if (certificate_details.Thumbprint == "91A92CA60555DB51BEDDFE1AE4ECE54C8EBEBA97")
                {
                    #region Fingerprint for certificate
                    string storedFingerprint = "" +
                    "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                    "64617465732e626c75656172726f77646576656c6f706d656e742e636f6d3110300e06035504080c0747656f72676961311f" +
                    "301d060355040a0c16426c7565204172726f7720446576656c6f706d656e74310b3009060355040613025553312f302d0609" +
                    "2a864886f70d0109011620737570706f727440626c75656172726f77646576656c6f706d656e742e636f6d31123010060355" +
                    "04070c09436c6576656c616e64301e170d3136303232393231313733335a170d3137303232383231313733335a3081b03129" +
                    "302706035504030c20757064617465732e626c75656172726f77646576656c6f706d656e742e636f6d3110300e0603550408" +
                    "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                    "0613025553312f302d06092a864886f70d0109011620737570706f727440626c75656172726f77646576656c6f706d656e74" +
                    "2e636f6d3112301006035504070c09436c6576656c616e6430820122300d06092a864886f70d01010105000382010f003082" +
                    "010a0282010100a1cdf5af6f1bba5cc8495d8061895f39858fde814f5581266505bf4cbe0b26506278bc247963bb7c42f0b8" +
                    "b00638871932ed7d0a3c6562be8e5b513f24da2768051acde875b53bf94c8ea2cec397145db206b2524c42a2019a0bfa14e2" +
                    "a7ef0d311235e07b7e0363345fd7f397e365c0865b1b8fa8ad7eebdc1fcdce360db04f2822438621534ae10744155a710641" +
                    "9a69c16745974a37c5b06917036351b92c06540a6c70aa776c143eef6f7b8ec31c0c40a9eab8a399c9065bea688ea7bd1db2" +
                    "30af56d2ca0f8983f9e8dacb5613755fbcd8229d7042668a9130468a7480a2afde8c18bab895472ddf1ed2c49291c04e8cc2" +
                    "ff24db33d231b3a2498c03a5650203010001a34d304b301d0603551d0e0416041476b5c2c82ff138b87c0e2d6c046af4c634" +
                    "55040a0c16426c75652048c1f54dcb82e3487d1fc31c07ee1313fba9204c7b3232ba9204c7b323a021abcbda85bfca9c9931" +
                    "092a864886f70d01010b050003820101001ab0dfd318cc2e93a997445d0950ffcb63544c58fe1ded6e234aa7ccdcb5c890b1" +
                    "61b51ae08c1f54dcb3fbeca9c9932bde91d202b89c0b6f0af1a370017fa9f6a021abcbda85bfecebebc6d6067d4dc1e51ec5" +
                    "02cf95867516a84f01410cf80d7af4f0d3e9a86cf7b0323dba9204c7b3232c58b2289032a12aaa1ec4f64065da8bbde4fe47" +
                    "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                    "de819522bb7ef870595d9738a6acdd39b7fcf6f36948ef2b404c2b6d7ebe577555148ad90013a5c2e812b2b907c808288040" +
                    "0db6702407585328f7e6c84b40451384391783001174d0";
                    #endregion

                    //Use the following to get the server's fingerprint to be saved and compared against
                    StringBuilder hex = new StringBuilder(certificate_details.RawData.Length * 2);
                    foreach (byte b in certificate_details.RawData)
                        hex.AppendFormat("{0:x2}", b);
                    string serverFingerprint = hex.ToString();

                    if (serverFingerprint == storedFingerprint) return true;
                    else return false;
                }
                else return false;
            }
            else if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            else
                return false;
        }



        public static string DecryptSysCon(string dataString)
        {
            return Cryptography.Decrypt(dataString, "Y2FidHJlYXN1cmU6Y2FidHJlYXN1cmU5ODcwIUAj", true);

        }

        public static string EncryptSysCon(string dataString)
        {
            return Cryptography.Encrypt(dataString, "Y2FidHJlYXN1cmU6Y2FidHJlYXN1cmU5ODcwIUAj", true);

        }


        public static bool VerifyLicense(string defaultClientId)
        {
            bool verify = false;
            

            try
            {
                try
                {
                    string Urls = "http://eurlic.co.uk/license/api/Cab/VerifyLicense";
                    var baseAddress = new Uri(Urls);
                    var json = string.Empty;
                    json = "{\"DefaultClientID\":" + "\"" + defaultClientId + "\"" + "}";


                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Urls);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Proxy = null;
                    httpWebRequest.Headers.Add("Authorization", "Basic " + "Y2FidHJlYXN1cmU6Y2FidHJlYXN1cmU5ODcwIUAj");
                    //   string usernamePassword = Base64Encode("cabtreasure:cabtreasure9870!@#");
                       //string usernamePassword = Base64Encode("cabtreasure:cabtreasurecloud9870!@#");
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {


                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Program.objLic = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<ClsLic>(result);


                        //if(Program.objLic.AppServiceUrl.ToStr().Trim().Length==0)
                        //{
                            Program.objLic.AppServiceUrl = "https://www.treasureonlineapi.co.uk/CabTreasureWebApi/Home/";


                     //   }
                    }

                }
                catch (Exception ex)
                {
                    Program.objLic.IsValid = false;
                    Program.objLic.Reason = ex.Message;


                }


                if (Program.objLic.IsValid)
                {
                    verify = true;

                    if (Program.objLic.ExpiryDateTime.ToStr().Trim().Length > 0)
                    AppVars.LicenseExpiryDate = "License will Expire on " + string.Format("{0:dd/MMM/yyyy HH:mm}", Program.objLic.ExpiryDateTime.ToDateTimeorNull());

                    string serialized = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(Program.objLic);
                    try
                    {

                        File.WriteAllText(Application.StartupPath + "\\SysCon.dat", General.EncryptSysCon(serialized));
                    }
                    catch
                    {


                    }
                }
                else
                {

                    if (Program.objLic.Reason.ToStr().Trim().Length > 0)
                    {


                        if(Program.objLic.ExpiryDateTime.ToStr().Trim().Length > 0)
                             AppVars.LicenseExpiryDate = "License will Expire on " + string.Format("{0:dd/MMM/yyyy HH:mm}", Program.objLic.ExpiryDateTime.ToDateTimeorNull());


                        if (File.Exists(Application.StartupPath + "\\SysCon.dat"))
                        {

                            string data = File.ReadAllText(Application.StartupPath + "\\SysCon.dat");

                            Program.objLic = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<ClsLic>(General.DecryptSysCon(data));

                        
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Program.objLic.IsValid = false;
                Program.objLic.Reason = ex.Message;


            }


            return verify;

        }

        public static decimal GetFixFareRate(int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
    , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool CanCheckZoneWise, DateTime? pickupTime
            , ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist
            , ref string estimatedTime, int? fromZoneId, int? toZoneId, ref bool IsMoreFareWise, ref int farecalculateby, int subCompanyId
            ,ref decimal companyPrice)
        {

            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;

            //
            tempFromPostCode = GetPostCodeMatch(tempFromPostCode);
            tempToPostCode = GetPostCodeMatch(tempToPostCode);

            //bool surchargeRateFromAmountWise = false;
            //bool surchargeRateToAmountWise = false;

            //decimal surchargeRateFrom = 0.00m;
            //decimal surchargeRateTo = 0.00m;

            // bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

                //if ((tempFromPostCode.Length > 0 || fromZoneId.ToInt() > 0) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                //  //  surchargeRateFrom = GetSurchargeRate(tempFromPostCode, fromZoneId, pickupTime.ToDateTime(), ref surchargeRateFromAmountWise);
                //}

                //if ((tempToPostCode.Length > 0 || toZoneId.ToInt() > 0) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                //  //  surchargeRateTo = GetSurchargeRate(tempToPostCode, toZoneId, pickupTime.ToDateTime(), ref surchargeRateToAmountWise);
                //}

                //if (tempFromPostCode.Length > 0 && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                //    surchargeRateFrom = GetSurchargeRate(tempFromPostCode, ref surchargeRateFromAmountWise);
                //}

                //if (tempToPostCode.Length > 0 && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                //    surchargeRateTo = GetSurchargeRate(tempToPostCode, ref surchargeRateToAmountWise);
                //}


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                //int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();

                //if (vehicleTypeId != defaultVehicleId)
                //{

                //    if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                //    {





                //        if (IsMoreFareWise == false)
                //        {
                //            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                //                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.FromZoneId == fromZoneId || c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                //                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.ToZoneId == toZoneId || c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                //                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                //                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                //                                                     )
                //                                               && c.Fare.VehicleTypeId == defaultVehicleId
                //                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                //                                          )
                //            {

                //                vehicleTypeId = defaultVehicleId;
                //                IsMoreFareWise = true;
                //            }
                //        }


                //    }
                //    else
                //    {

                //        if (AppVars.objPolicyConfiguration.EnableZoneWiseFares.ToBool() == false)
                //        {


                //            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                //                                                      ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                //                                                            && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                //                                                            || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                //                                                            && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                //                                                               )
                //                                                         && c.Fare.VehicleTypeId == vehicleTypeId
                //                                                          && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                //                && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                //                                                              && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0))
                //            {

                //                vehicleTypeId = defaultVehicleId;
                //                IsMoreFareWise = true;
                //            }
                //        }
                //    }


                //}





                List<Fare_ChargesDetail> list = null;

                fromVal = fromVal.Replace("  ", " ");
                toVal = toVal.Replace("  ", " ");


                  if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length >0)
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)) )) || c.OriginId == tempFromLocId)
                                                                       && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()     ) || ( c.ToAddress.ToUpper().EndsWith(tempToPostCode)  )     )) || c.DestinationId == tempToLocId))

                                                                          )

                                                                     && c.Fare.VehicleTypeId == vehicleTypeId

                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                            //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                      ).ToList();

                    }

                    if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) ||(tempFromLocId==0 && (c.FromAddress.ToUpper().EndsWith(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                    || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                            // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();


                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }

                    }

                    if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                    {
                        if (tempFromLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                   && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                   || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                   && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                        }

                        if ((list == null || list.Count == 0) && tempToLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }



                        if ((list == null || list.Count == 0))
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }

                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }


                    }

                

                //if ((tempFromLocId == 0 && string.IsNullOrEmpty(startFromPostCode)) || (tempToLocId == 0 && string.IsNullOrEmpty(startToPostCode)))
                //    obj = null;


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }



                Fare_ChargesDetail obj = null;
                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {

                            if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                                && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                if (obj == null)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                              && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                }
                            }

                            if (obj == null)
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId);

                            if (obj == null)
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                            //    farecalculateby = 4;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {


                                if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                    && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                    if (obj == null)
                                    {
                                        obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                  && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                    }

                                }

                                if (obj == null)
                                    obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                                if (obj == null)
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);


                                companyFareExist = true;
                                //     farecalculateby = 4;
                            }


                        }
                    }
                    else
                    {
                        if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                            && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));



                            if (obj == null)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                          && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                            }
                        }

                        if (obj == null)
                            obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                        if (obj == null)
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);

                        //    farecalculateby = 4;
                    }

                }

                //if (list != null)
                //{
                //    if (companyId != 0)
                //    {
                //        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                //        {
                //            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                //            companyFareExist = true;


                //        }
                //        else
                //        {

                //            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                //            {
                //                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                //                companyFareExist = true;

                //            }


                //        }
                //    }
                //    else
                //    {
                //        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                //    }

                //}


                if (obj != null)
                {

                    rtnFare = obj.Rate.ToDecimal();

                    if (obj.CompanyRate.ToDecimal() > 0)
                        companyPrice = obj.CompanyRate.ToDecimal();

                    deadMileage = 0;

                    farecalculateby = 4;

                }




                //if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                //{

                //    decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                //    decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                //    rtnFare = rtnFare + fareSurchargePercent;

                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                //{

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                //{
                //    surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                //{
                //    surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}



            }
            catch
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }



        public static decimal GetFixFareRateOnly(int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
                  , string tempToPostCode, DateTime? pickupTime, int fromLocTypeId, int toLocTypeId, int subCompanyId
           , ref decimal companyPrice)
        {

            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;

            //
            tempFromPostCode = GetPostCodeMatch(tempFromPostCode);
            tempToPostCode = GetPostCodeMatch(tempToPostCode);

          

            // bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

            


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
              

                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];

                }

             


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
              


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                


                List<Fare_ChargesDetail> list = null;

                fromVal = fromVal.Replace("  ", " ");
                toVal = toVal.Replace("  ", " ");


                if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                {

                    list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))) || c.OriginId == tempFromLocId)
                                                                   && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))) || c.DestinationId == tempToLocId))

                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId

                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                               //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                }

                if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                {
                    list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                              && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                             // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();


                  

                }

                if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                {
                    if (tempFromLocId > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                               && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                               || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                               && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                  )

                                                             && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                              ).ToList();

                    }

                    if ((list == null || list.Count == 0) && tempToLocId > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();

                    }



                    if ((list == null || list.Count == 0))
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();

                    }

                  


                }



              


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }



                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                           // companyFareExist = true;


                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                              //  companyFareExist = true;

                            }


                        }
                    }
                    else
                    {
                        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                    }

                }


                if (obj != null)
                {

                    rtnFare = obj.Rate.ToDecimal();

                    if (obj.CompanyRate.ToDecimal() > 0)
                        companyPrice = obj.CompanyRate.ToDecimal();

                 

                 

                }







            }
            catch
            {


              
            }
            return rtnFare;
        }


        public static void ShowEmailForm(ReportViewer viewer, string fileTitle, string email, Gen_SubCompany objSubCompany,bool showDialog)
        {
            frmEmail frm = new frmEmail(viewer, fileTitle, email, objSubCompany);
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (showDialog)
                frm.ShowDialog();
            else
                frm.Show();
        }


        public static void LoadConfiguration()
        {

            AppVars.objPolicyConfiguration = GetObject<Gen_SysPolicy_Configuration>(c => c.SysPolicyId == 1);


        }

        public static void AddUserLog(string message,int logType)
        {

            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {

                    db.stp_AddUserLogs(AppVars.LoginObj.LuserId.ToInt(), message, logType);

                }
            }
            catch
            {


            }

        }


        public static void AddBookingLog(long jobId,string logMessage)
        {
            if (jobId == 0)
                return;

            using (TaxiDataContext db = new TaxiDataContext())
            {
                db.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), logMessage);


            }


        }

        public static void SaveSentEmail(string msg, string subject, string sentTo)
        {
            try
            {


                using (TaxiDataContext db = new TaxiDataContext())
                {

                    SentEmail obj = new SentEmail();
                    obj.SentOn = DateTime.Now;
                    obj.SentTo = sentTo.ToStr().Trim();
                    obj.EmailBody = msg;
                    obj.Subject = subject.ToStr();
                    obj.SentBy = AppVars.LoginObj.UserName.ToStr();
                  
                    db.SentEmails.InsertOnSubmit(obj);
                    db.SubmitChanges();

                }
            }
            catch (Exception ex)
            {


            }


        }

        public static void SaveSentSMS(string msg, string toNumbers)
        {
            try
            {


                using (TaxiDataContext db = new TaxiDataContext())
                {
                   

                    SentSM objSms = new SentSM();
                    objSms.SentOn = DateTime.Now;
                    objSms.SentTo = toNumbers.ToStr().Trim();
                    objSms.SMSBody = msg;
                    objSms.SentBy = AppVars.LoginObj.UserName.ToStr();

                    db.SentSMs.InsertOnSubmit(objSms);




                    db.SubmitChanges();

                }
            }
            catch (Exception ex)
            {


            }

        }


        public static void SaveTemplate(string msg, string toNumbers)
        {
            try
            {

                if (msg.ToStr().Trim().Length > 6 || msg.ToStr().Trim().WordCount() > 1)
                {

                    using (Taxi_Model.TaxiDataContext context = new TaxiDataContext())
                    {
                        int c = context.Fleet_DriverTemplets.Where(w => w.Templets == msg).ToList().Count();

                        if (c == 0)
                        {
                            Fleet_DriverTemplet d = new Fleet_DriverTemplet();
                            d.Templets = msg;
                            d.SysPolicyId = 1;
                            context.Fleet_DriverTemplets.InsertOnSubmit(d);
                            context.SubmitChanges();


                        }



                    }
                }


                //using (TaxiDataContext db = new TaxiDataContext())
                //{


                //    SentSM objSms = new SentSM();
                //    objSms.SentOn = DateTime.Now;
                //    objSms.SentTo = toNumbers.ToStr().Trim();
                //    objSms.SMSBody = msg;
                //    objSms.SentBy = AppVars.LoginObj.UserName.ToStr();

                //    db.SentSMs.InsertOnSubmit(objSms);




                //    db.SubmitChanges();

                //}
            }
            catch (Exception ex)
            {


            }

        }


        public static bool ReCallPreBooking(long jobId, int driverId,bool recallOnly=false)
        {

            try
            {
                bool rtn = true;

                if(recallOnly==false)
                (new TaxiDataContext()).stp_RecoverPreJob(jobId, Enums.BOOKINGSTATUS.WAITING, driverId, "", AppVars.LoginObj.UserName.ToStr());




                if (AppVars.objPolicyConfiguration.MapType.ToInt() == 1)
                {
                    //For TCP Connection
                    if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                    {

                        rtn = General.SendMessageToPDA("request pda=" + driverId + "=" + jobId + "=Cancelled Pre Job>>" + jobId + "=2").Result.ToBool();
                    }

                }
                else
                {

                    //For TCP Connection
                    if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                    {

                        rtn = General.SendMessageToPDA("request pda=" + driverId + "=" + jobId + "=Cancelled Pre Job>>" + jobId + "=2").Result.ToBool();
                    }


                }

                return rtn;

            }
            catch (Exception ex)
            {


                //  ENUtils.ShowMessage(ex.Message);
                return false;

            }




        }



        public static string DecryptConnectionString(string connString)
        {
            return Cryptography.Decrypt(connString, "tcloudX@@!", true);

        }

        public static List<object[]> ShowCustomerBunch(IList list, string pkColumn)
        {

            Taxi_AppMain.frmCustomerBunch frm = new Taxi_AppMain.frmCustomerBunch(list, pkColumn, true);

            frm.ShowDialog();

            return frm.ListofData;

        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn == null) return null;
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null) return null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }






        public static string GetCLIFirstExtensions()
        {
            try
            {

                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Service.xml"))
                {

                    string machineName = System.Environment.MachineName.ToStr().ToLower();

                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Windows.Forms.Application.StartupPath + "\\Service.xml");


                    return doc.GetElementsByTagName("extensions").OfType<XmlNode>().FirstOrDefault()
                                .ChildNodes.OfType<XmlNode>().Where(c => c.FirstChild.InnerText.ToStr().ToLower().Trim() == machineName)
                                .Select(c => c.LastChild.InnerText).FirstOrDefault<string>();


                }
                else
                    return null;

            }
            catch (Exception ex)
            {

                return null;

            }


        }




        public static void AddLog(string logMessage, string logFrom)
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.CommandTimeout = 5;
                    db.stp_AddLog(logMessage, AppVars.LoginObj.LoginName, logFrom);

                  
                }
            }
            catch (Exception ex)
            {


            }
        }

        //public static TU CopyPropertiesTo<T, TU>( T source, TU dest)
        //{
        //    var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
        //    var destProps = typeof(TU).GetProperties()
        //            .Where(x => x.CanWrite)
        //            .ToList();

        //    foreach (var sourceProp in sourceProps)
        //    {
        //        if (destProps.Any(x => x.Name == sourceProp.Name))
        //        {
        //            var p = destProps.First(x => x.Name == sourceProp.Name);
        //            if (p.CanWrite && (p.PropertyType==typeof(object))==false)
        //            { // check if the property can be set or no.
        //                try
        //                {
        //                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
        //                }
        //                catch
        //                {

        //                }
        //            }
        //        }

        //    }

        //    return dest;

        //}

        

        public static void ShowEmailForm(ReportViewer viewer, string fileTitle)
        {
            frmEmail frm = new frmEmail(viewer, fileTitle);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        public static void ShowEmailForm(ReportViewer viewer, string fileTitle, string email)
        {
            frmEmail frm = new frmEmail(viewer, fileTitle, email);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public static void ShowEmailForm(ReportViewer viewer, string fileTitle, string email,bool showDialog)
        {
            frmEmail frm = new frmEmail(viewer, fileTitle, email);
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (showDialog)
                frm.ShowDialog();
            else
                frm.Show();
        }





        //public static bool SendPDATestMessage(string msg)
        //{


        //    bool rtn = false;



        //    byte[] data = Encoding.UTF8.GetBytes(msg);
        //    try
        //    {
        //        using (TcpClient tcpClient = new TcpClient())
        //        {
        //            try
        //            {

        //                tcpClient.SendTimeout = 3000;
        //                tcpClient.ReceiveTimeout = 2000;


        //                IPAddress ip = null;

        //                if (IPAddress.TryParse(AppVars.objPolicyConfiguration.ListenerIP.ToStr(), out ip))
        //                    tcpClient.Connect(new IPEndPoint(ip, 1101));
        //                else
        //                    tcpClient.Connect(AppVars.objPolicyConfiguration.ListenerIP.ToStr(), 1101);


        //                tcpClient.GetStream().Write(data, 0, data.Length);

        //                Byte[] inputBuffer = new Byte[200];
        //                int bytes = tcpClient.GetStream().Read(inputBuffer, 0, inputBuffer.Length);
        //                string dataValue = Encoding.UTF8.GetString(inputBuffer, 0, bytes);
        //                tcpClient.Close();


        //                if (dataValue.ToStr() == "ok" || dataValue.ToStr().StartsWith("ok"))
        //                {
        //                    rtn = true;
        //                }
        //                else
        //                    rtn = false;
        //            }
        //            catch (Exception ex)
        //            {

                       

                       

        //            }

        //        }

        //      //  GC.Collect();
        //    }
        //    catch (Exception eex)
        //    {
        //        rtn = false;
        //    }

        //    return rtn;


        //}

        public static bool ClickACallDriver(int driverId,string numberj)
        {
            bool rtn = false;
            if (driverId > 0)
            {



                try
                {
                    if (numberj.ToStr().Trim().Length == 0)
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            db.CommandTimeout = 5;
                            db.DeferredLoadingEnabled = false;
                            numberj = db.Fleet_Drivers.Where(c => c.Id == driverId).Select(c => c.MobileNo).FirstOrDefault().ToStr();



                        }
                    }

                    rtn= ClickACall(numberj, "", "");
                }
                catch
                {


                }
            }

            return rtn;
        }

        public static void ClickACallCustomer(long jobId)
        {

            if (jobId > 0)
            {
                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.CommandTimeout = 5;
                        db.DeferredLoadingEnabled = false;
                        var obj = db.Bookings.Where(c => c.Id == jobId).Select(c => new { c.CustomerMobileNo, c.CustomerPhoneNo, c.SubcompanyId }).FirstOrDefault();

                        if (obj != null && (obj.CustomerMobileNo.ToStr().Trim().Length > 0 || obj.CustomerPhoneNo.ToStr().Trim().Length > 0))
                        {
                            string calleridToShow = "";
                            if (obj.SubcompanyId != null)
                            {
                                calleridToShow = db.Gen_SubCompanies.Where(c => c.Id == obj.SubcompanyId).Select(c => c.TelephoneNo).FirstOrDefault().ToStr();

                                ClickACall(obj.CustomerMobileNo, obj.CustomerPhoneNo, calleridToShow);


                                string msg = obj.CustomerMobileNo.ToStr().Trim();

                                if(string.IsNullOrEmpty(msg))
                                {
                                    msg = obj.CustomerPhoneNo.ToStr().Trim();
                                }

                                if(msg.ToStr().Trim().Length > 0)
                                   db.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), "Call To Customer - " + msg);
                            }
                        }

                    }

                }
                catch
                {

                }

            }

        }

        public static bool ClickACall(string number, string number2, string calleridToShow)
        {

           return   (((frmMainMenu)(Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmMainMenu")))).ClickACall(number, number2, calleridToShow);

        }



        public static DateTime? LastKilledOn = null;

        public async static Task<bool> SendMessageToPDA(string msg)
        {
            frmMainMenu ObjfrmMainMenu = ((frmMainMenu)(Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmMainMenu")));
            HubConnection Connection = ObjfrmMainMenu.Connection;
            IHubProxy HubProxy = ObjfrmMainMenu.HubProxy;

         
            bool rtn = true;

            try
            {
                if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    Connection.Start();

                    Thread.Sleep(5000);
                }
                else if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting
                            || Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting)
                {
                    Thread.Sleep(5000);
                    //     Connection.Stop();
                    //Connection.Start();
                }
                HubProxy.Invoke("MessageToPDA", msg);
                //  result = HubProxy.Invoke<bool>("MessageToPDA", msg).Result;

                //if (frmMainMenu.Acknowledgement == "ok")
                //    rtn = true;

                //   GC.Collect();
            }
            catch (Exception ex)
            {
                File.AppendAllText("tcpcatchlog.txt", DateTime.Now.ToStr() + ": Exception: " + ex.Message + " Inner Exception: " + ex.InnerException + Environment.NewLine);
                rtn = false;
            }

            return rtn;
        }

        public async static Task<bool> SendMessageToPDA(string msg, string driverId)
        {
            frmMainMenu ObjfrmMainMenu = ((frmMainMenu)(Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmMainMenu")));
            HubConnection Connection = ObjfrmMainMenu.Connection;
            IHubProxy HubProxy = ObjfrmMainMenu.HubProxy;

            bool result;
            bool rtn = true;

            try
            {
                if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    Connection.Start();

                    Thread.Sleep(5000);
                }
                else if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting
                            || Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting)
                {

                    Thread.Sleep(5000);
                    // Connection.Stop();
                    //  await Connection.Start();
                }

                result= HubProxy.Invoke<bool>("MessageToPDAByDriverID", msg, driverId).Result;

             //   if (frmMainMenu.Acknowledgement == "ok")
                 //   rtn = true;

             //   GC.Collect();
            }
            catch (Exception ex)
            {
                File.AppendAllText("tcpcatchlog.txt", DateTime.Now.ToStr() + ": Exception: " + ex.Message + " Inner Exception: " + ex.InnerException + Environment.NewLine);
                rtn = false;
            }

            return rtn;
        }




        public async static Task<bool> RefreshData(string msg)
        {
            frmMainMenu ObjfrmMainMenu = ((frmMainMenu)(Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmMainMenu")));
            HubConnection Connection = ObjfrmMainMenu.Connection;
            IHubProxy HubProxy = ObjfrmMainMenu.HubProxy;

            bool result = false;
           

            try
            {
                if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                {
                    Connection.Start();

                    Thread.Sleep(5000);
                }
                else if (Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting
                            || Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting)
                {
                    Thread.Sleep(5000);
                    //     Connection.Stop();
                    //Connection.Start();
                }
                result= HubProxy.Invoke<bool>("RefreshData", msg).Result;
                //  result = HubProxy.Invoke<bool>("MessageToPDA", msg).Result;

                //if (frmMainMenu.Acknowledgement == "ok")
                //    rtn = true;

                //   GC.Collect();
            }
            catch (Exception ex)
            {
                File.AppendAllText("tcpcatchlog.txt", DateTime.Now.ToStr() + ": Exception: " + ex.Message + " Inner Exception: " + ex.InnerException + Environment.NewLine);
               // rtn = false;
            }

            return result;
        }

      

     

        public static string GetSharedDocumentsPath()
        {
            string fullPath = GetSharedNetworkPath() + "\\Taxi\\";

            return fullPath;

        }


        public static void SendEmail(string subject, string Emailmessage, string FromEmail, string ToEmail)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            ///    NetworkCredential mailAuthentication = new NetworkCredential("eurosofttech@hotmail.com", "123123123A");
            NetworkCredential mailAuthentication = new NetworkCredential("danish@eurosofttech.co.uk", "Admin1234");

            message.To.Add(new MailAddress(ToEmail));
            message.From = new MailAddress(FromEmail);
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = Emailmessage;
            smtp.UseDefaultCredentials = false;
            //       smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //   smtp.Host = "smtp.live.com";
            smtp.Host = "smtp.eurosofttech.co.uk";
            smtp.Port = 587;
            smtp.Credentials = mailAuthentication;
            smtp.Send(message);


        }



        public static decimal GetSurchargeRate(string postCode, ref bool IsAmountWise)
        {
            decimal value = 0.00m;
            string[] splitPostCode = postCode.Split(new char[] { ' ' });
            if (splitPostCode.Count() > 0)
            {
                string postcode = CheckIfSpecialPostCode(splitPostCode[0].Trim().ToUpper());

                Gen_SysPolicy_SurchargeRate obj = General.GetObject<Gen_SysPolicy_SurchargeRate>(c => c.SysPolicyId != null && c.PostCode.Trim().ToLower() == postcode.ToLower());

                if (obj != null)
                {

                    IsAmountWise = obj.IsAmountWise.ToBool();


                    if (IsAmountWise)
                    {
                        value = obj.Amount.ToDecimal();
                    }
                    else
                    {
                        value = obj.Percentage.ToDecimal();
                    }

                }
            }

            return value;

        }

        public static decimal GetSurchargeRate(string postCode, int? ZoneId, DateTime dt, ref bool IsAmountWise )
        {
            decimal value = 0.00m;

            try
            {
                string[] splitPostCode = postCode.Split(new char[] { ' ' });
                if (splitPostCode.Count() > 0)
                {
                    string postcode = CheckIfSpecialPostCode(splitPostCode[0].Trim().ToUpper());

                    Gen_SysPolicy_SurchargeRate obj = null;

                    if (ZoneId.ToInt() == 0)
                    {
                        obj = General.GetObject<Gen_SysPolicy_SurchargeRate>(c => c.SysPolicyId != null && c.PostCode.Trim().ToLower() == postcode.ToLower());

                    }
                    else
                    {
                        obj = General.GetObject<Gen_SysPolicy_SurchargeRate>(c => c.SysPolicyId != null && (c.PostCode.Trim().ToLower() == postcode.ToLower() || c.zoneid == ZoneId));


                    }
                    if (obj != null)
                    {

                        if (obj.EnableSurcharge.ToBool())
                        {
                            //if(dt==null)
                            //   dt = DateTime.Now;


                            bool applySurg = false;
                            if (obj.CriteriaBy.ToInt() == 1)
                            {
                                if (dt >= obj.ApplicableFromDateTime && dt <= obj.ApplicableToDateTime)
                                    applySurg = true;

                            }
                            else if (obj.CriteriaBy.ToInt() == 2)
                            {
                                if (dt.ToDate() >= obj.ApplicableFromDateTime.ToDate() && dt.ToDate() <= obj.ApplicableToDateTime.ToDate())
                                    applySurg = true;

                            }
                            else if (obj.CriteriaBy.ToInt() == 3)
                            {
                                int day = dt.Date.DayOfWeek.ToInt();


                                if ((day >= obj.ApplicableFromDay.ToInt() && day <= obj.ApplicableToDay.ToInt())
                                    &&
                                       (dt.TimeOfDay >= obj.ApplicableFromDateTime.ToDateTime().TimeOfDay && dt.TimeOfDay <= obj.ApplicableToDateTime.ToDateTime().TimeOfDay))
                                    applySurg = true;

                            }


                            if (applySurg)
                            {
                                IsAmountWise = obj.IsAmountWise.ToBool();


                                if (IsAmountWise)
                                {
                                    value = obj.Amount.ToDecimal();
                                }
                                else
                                {
                                    value = obj.Percentage.ToDecimal();
                                }
                            }
                        }

                    }
                }


            }
            catch
            {

            }

            return value;

        }



        public static decimal GetSurchargeRate(string postCode,int? ZoneId,DateTime dt, ref bool IsAmountWise
            , ref decimal surchargeParking,ref decimal surchargeExtra,ref bool IsoutofTown)
        {
            decimal value = 0.00m;

            try
            {

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    string[] splitPostCode = postCode.Split(new char[] { ' ' });
                    if (splitPostCode.Count() > 0)
                    {
                        string postcode = CheckIfSpecialPostCode(splitPostCode[0].Trim().ToUpper());

                      //  Gen_SysPolicy_SurchargeRate obj = null;

                       var list=db.Gen_SysPolicy_SurchargeRates.Where(c => c.SysPolicyId != null &&  c.zoneid == ZoneId).ToList();

                        foreach (Gen_SysPolicy_SurchargeRate obj in list.OrderByDescending(c=>c.CriteriaBy))
                        {



                            if (obj != null)
                            {

                                if (obj.EnableSurcharge.ToBool())
                                {



                                    bool applySurg = false;
                                    if (obj.CriteriaBy.ToInt() == 1)
                                    {
                                        if (dt >= obj.ApplicableFromDateTime && dt <= obj.ApplicableToDateTime)
                                            applySurg = true;

                                    }
                                    else if (obj.CriteriaBy.ToInt() == 2)
                                    {
                                        if (dt.ToDate() >= obj.ApplicableFromDateTime.ToDate() && dt.ToDate() <= obj.ApplicableToDateTime.ToDate())
                                            applySurg = true;

                                    }
                                    else if (obj.CriteriaBy.ToInt() == 3)
                                    {
                                        int day = dt.Date.DayOfWeek.ToInt();

                                        TimeSpan zeroSpan = new TimeSpan(23, 59, 59);

                                        if ((day >= obj.ApplicableFromDay.ToInt() && day <= obj.ApplicableToDay.ToInt())
                                            &&
                                               (dt.TimeOfDay >= obj.ApplicableFromDateTime.ToDateTime().TimeOfDay && dt.TimeOfDay <= obj.ApplicableToDateTime.ToDateTime().TimeOfDay))


                                            applySurg = true;

                                      else  if ((day >= obj.ApplicableFromDay.ToInt() && day <= obj.ApplicableToDay.ToInt())
                                          && (obj.ApplicableFromDateTime.ToDateTime().TimeOfDay.Hours>12 && obj.ApplicableToDateTime.ToDateTime().TimeOfDay.Hours<12 &&
                                          dt.TimeOfDay >= obj.ApplicableFromDateTime.ToDateTime().TimeOfDay && dt.TimeOfDay <= zeroSpan )
                                          )

                                            applySurg = true;
                                        else if ((day >= obj.ApplicableFromDay.ToInt() && day <= obj.ApplicableToDay.ToInt())
                                       && (obj.ApplicableFromDateTime.ToDateTime().TimeOfDay.Hours > 12 && obj.ApplicableToDateTime.ToDateTime().TimeOfDay.Hours < 12 
                                       && dt.TimeOfDay.Hours<12 &&  dt.TimeOfDay >=new TimeSpan(0,0,0) && dt.TimeOfDay <= obj.ApplicableToDateTime.ToDateTime().TimeOfDay)
                                       )

                                            applySurg = true; 

                                    }


                                    if (applySurg)
                                    {
                                        IsAmountWise = obj.IsAmountWise.ToBool();


                                        if (IsAmountWise)
                                        {
                                            value = obj.Amount.ToDecimal();
                                        }
                                        else
                                        {
                                            value = obj.Percentage.ToDecimal();

                                            if (obj.Holidays.ToStr() == "-")
                                            {
                                                value = -value;

                                            }
                                        }

                                        surchargeParking = obj.Parking.ToDecimal();


                                        if (obj.ApplyOutofTown.ToBool())
                                        {
                                            if (db.Gen_Zones.Where(c => c.Id == ZoneId && (c.BlockDropOff != null && c.BlockDropOff == true)).Count() > 0)
                                            {
                                                surchargeExtra = obj.Waiting.ToDecimal();
                                                IsoutofTown = true;
                                            }


                                        }
                                        else
                                            surchargeExtra = obj.Waiting.ToDecimal();

                                        break;

                                    }
                                }

                            }

                        }


                    }

                }
            }
            catch
            {

            }

            return value;

        }








        public static stp_getCoordinatesByAddressResult GetCoordinatesByAddress(string address,string postcode,TaxiDataContext dbX=null)
        {

            if (address.ToStr().Trim().Length == 0 && postcode.ToStr().Trim().Length == 0)
                return null;

            stp_getCoordinatesByAddressResult pickupCoord = null;
          

            try
            {

                //TEMPORARY REMOVED=> PUT IT BACK ,  JUST COMMENT THESE LINES BECAUSE OF MOUNT CARS
                //if (AppVars.objPolicyConfiguration.ViaPointExtraCharges.ToDecimal() > 0)
                //{
                //    var coord = GetDistance.PostCodeToLongLat(address, "GB");
                //    if (coord != null)
                //    {
                //        pickupCoord = new stp_getCoordinatesByAddressResult() { Latitude = coord.Value.Latitude, Longtiude = coord.Value.Longitude };
                //    }                   
                //}


                //if(AppVars.objPolicyConfiguration.TcpConnectionType.ToInt()==3)
                //{

                //    DigiMapSearch c = new DigiMapSearch();




                //    pickupCoord = c.SearchSingleAddress("ymSKdoxaNIhRnn2", "address", address);


                //}


                if (pickupCoord == null)
                {
                    if (dbX == null)
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {
                            
                            pickupCoord = db.stp_getCoordinatesByAddress(address, General.GetPostCodeMatch(postcode)).FirstOrDefault();
                        }
                    }
                    else
                    {
                       
                            pickupCoord = dbX.stp_getCoordinatesByAddress(address, General.GetPostCodeMatch(postcode)).FirstOrDefault();
                        
                    }

                }
            }
            catch
            {


            }
            return pickupCoord;
        }


        public static void GetKey()
        {
            if (AppVars.googleKey.ToStr().Length == 0)
            {

                using (TaxiDataContext dbX = new TaxiDataContext())
                {
                    dbX.CommandTimeout = 5;
                    AppVars.googleKey = "&key=" + dbX.ExecuteQuery<string>("select apikey from mapkeys where maptype='google'").FirstOrDefault();


                }
            }
        }

        public static decimal GetFareRate(int subCompanyId, int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
                 , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool CanCheckZoneWise, DateTime? pickupTime, ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist, ref string estimatedTime)
        {
            string miles = "";
            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;


            //   bool surchargeRateFromAmountWise = false;
            //   bool surchargeRateToAmountWise = false;

            //  decimal surchargeRateFrom = 0.00m;
            //  decimal surchargeRateTo = 0.00m;

            bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

                if (tempFromPostCode.Length > 0 && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                  //  surchargeRateFrom = GetSurchargeRate(tempFromPostCode, ref surchargeRateFromAmountWise);
                }

                if (tempToPostCode.Length > 0 && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                  //  surchargeRateTo = GetSurchargeRate(tempToPostCode, ref surchargeRateToAmountWise);
                }


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    if (toArr.Count() > 1)
                        ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();
                List<Fare_ChargesDetail> list = null;
                if ((IsVia == false && milesList.Count == 0) || (IsVia && AppVars.objPolicyConfiguration.ViaPointFareCalculationType.ToBool() == false))
                {


                    if (vehicleTypeId != defaultVehicleId)
                    {

                        if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                        {

                            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == defaultVehicleId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                                                          )
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }


                        }
                        else
                        {


                            if (
                                //(General.GetQueryable<Fare_ChargesDetail>(c =>


                                //                                      ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                //                                            && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                //                                            || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                //                                            && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                //                                               )
                                //                                         && c.Fare.VehicleTypeId == vehicleTypeId
                                //                                          && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                (General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                              && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }
                        }


                    }









                    if (list == null || (list != null && list.Count() == 0))
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()))) || c.OriginId == tempFromLocId)
                                                                       && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))) || c.DestinationId == tempToLocId))

                                                                          )

                                                                     && c.Fare.VehicleTypeId == vehicleTypeId

                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                      ).ToList();

                    }

                    if (list == null || (list != null && list.Count() == 0))
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                    || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                 // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();


                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }

                    }

                    if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                    {
                        if (tempFromLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                   && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                   || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                   && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                        }

                        if ((list == null || list.Count == 0) && tempToLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }



                        if ((list == null || list.Count == 0))
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }

                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }


                    }

                }

                //if ((tempFromLocId == 0 && string.IsNullOrEmpty(startFromPostCode)) || (tempToLocId == 0 && string.IsNullOrEmpty(startToPostCode)))
                //    obj = null;


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }


                stp_getCoordinatesByAddressResult pickupCoord = null;
                stp_getCoordinatesByAddressResult destCoord = null;

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        //pickupCoord = db.stp_getCoordinatesByAddress(fromVal, tempFromPostCode).FirstOrDefault();
                        //destCoord = db.stp_getCoordinatesByAddress(toVal, tempToPostCode).FirstOrDefault();

                        pickupCoord = General.GetCoordinatesByAddress(fromVal, tempFromPostCode, db);
                        destCoord = General.GetCoordinatesByAddress(toVal, tempToPostCode, db);
                    }
                }
                catch
                {


                }


                string originString = string.Empty;
                string destString = string.Empty;
                if (pickupCoord != null && pickupCoord.Latitude != null && pickupCoord.Latitude != 0)
                {
                    originString = pickupCoord.Latitude + "," + pickupCoord.Longtiude;
                }

                if (destCoord != null && destCoord.Latitude != null && destCoord.Latitude != 0)
                {
                    destString = destCoord.Latitude + "," + destCoord.Longtiude;
                }


                //if (IsVia || milesList.Count > 0)
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime, true).ToStr();
                //else
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime).ToStr();


                if (IsVia || milesList.Count > 0)
                    miles = CalculateDistance(originString, destString, ref estimatedTime, true).ToStr();
                else
                    miles = CalculateDistance(originString, destString, ref estimatedTime).ToStr();




                milesList.Add(miles.ToDecimal());


                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                                companyFareExist = true;

                            }


                        }
                    }
                    else
                    {
                        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                    }

                }


                if (obj != null && AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false)
                {

                    rtnFare = obj.Rate.ToDecimal();
                    deadMileage = 0;
                }
                else
                {

                    if ((string.IsNullOrEmpty(tempFromPostCode) && string.IsNullOrEmpty(originString)) || (string.IsNullOrEmpty(tempToPostCode) && string.IsNullOrEmpty(destString)))
                    {
                        errorMsg = "Error";
                        return 0;
                    }



                    if (IsVia)
                        return rtnFare;

                    if (deadMileage > 0)
                    {

                        string fromBasePostCode = General.GetPostCodeMatch(AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper().Trim());
                        decimal deadMileageDistance = General.CalculateDistance(fromBasePostCode, tempFromPostCode);

                        deadMileage = deadMileageDistance - deadMileage;

                        if (deadMileage < 0)
                            deadMileage = 0;


                        milesList.Add(deadMileage.ToDecimal());

                    }

                    // Calculate Fare Mileage Wise                
                    //  ISingleResult<ClsFares> objFare = General.SP_CalculateFares(vehicleTypeId.ToIntorNull(), companyId.ToIntorNull(), milesList.Sum().ToStr(), pickupTime);
                    decimal totalMiles = milesList.Sum();




                    // var objFare = new TaxiDataContext().stp_CalculateGeneralFares(vehicleTypeId, companyId, totalMiles, pickupTime);
                    if (AppVars.objPolicyConfiguration.EnablePeakOffPeakFares.ToBool() && AppVars.objPolicyConfiguration.FareMeterType.ToInt() < 2)
                    {
                        pickupTime = string.Format("{0:dd/MM/yyyy HH:mm}", new DateTime(1900, 1, 1, 0, 0, 0).ToDate() + pickupTime.Value.TimeOfDay).ToDateTime();

                    }


                    ISingleResult<stp_CalculateGeneralFaresBySubCompanyResult> objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId);


                    if (objFare != null)
                    {
                        var f = objFare.FirstOrDefault();

                        if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                        {


                            if (AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false || obj == null ||
                                (f.totalFares.ToDecimal() > obj.Rate.ToDecimal() && (fromLocTypeId != Enums.LOCATION_TYPES.AIRPORT && toLocTypeId != Enums.LOCATION_TYPES.AIRPORT)))
                            {
                                rtnFare = f.totalFares.ToDecimal();

                                companyFareExist = f.CompanyFareExist.ToBool();
                            }
                            else
                            {

                                if (obj != null)
                                    rtnFare = obj.Rate.ToDecimal();
                                else
                                {
                                    rtnFare = f.totalFares.ToDecimal();
                                    companyFareExist = f.CompanyFareExist.ToBool();
                                }

                            }

                        }
                        else
                            errorMsg = "Error";



                    }
                    else
                        errorMsg = "Error";






                    if (deadMileage > 0)
                    {
                        deadMileage = 0;

                        if (milesList.Count > 1)
                            milesList.RemoveAt(1);

                    }

                    if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                    {

                       // decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == vehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                        if ( totalMiles > 0)
                        {

                            //  rtnFare = Math.Ceiling((rtnFare);
                            rtnFare = Math.Ceiling(rtnFare);
                        }
                    }
                    else
                    {

                        decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                        if (roundUp > 0)
                        {
                            // fareVal = (decimal)Math.Ceiling(fareVal / roundUp) * roundUp;

                            rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;

                        }


                        // rtnFare = (decimal)Math.Ceiling(rtnFare / 0.5m) * 0.5m;


                    }

                }






                if (IsMoreFareWise)
                {

                    decimal AddedAmount = 0.00m;
                    string op = string.Empty;

                    Gen_SysPolicy_FaresSetting objFare = null;

                    //if (companyId != null)
                    //{
                    //    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId && (c.IsCompanyWise!=null && c.IsCompanyWise==true));
                    //}
                    //else
                    //{

                    //   if(objFare==null)
                    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId);
                    //  }
                    if (objFare != null)
                    {
                        op = objFare.Operator.ToStr();


                        if (objFare.IsAmountWise == false)
                        {
                            AddedAmount = (rtnFare * objFare.Percentage.ToDecimal()) / 100;
                        }
                        else
                        {
                            AddedAmount = objFare.Amount.ToDecimal();

                        }

                    }


                    switch (op)
                    {
                        case "+":
                            rtnFare = rtnFare + AddedAmount;
                            break;

                        case "-":
                            rtnFare = rtnFare - AddedAmount;
                            break;

                        default:
                            rtnFare = rtnFare + AddedAmount;
                            break;
                    }



                }


                //if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                //{

                //    decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                //    decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                //    rtnFare = rtnFare + fareSurchargePercent;

                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                //{

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                //{
                //    surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                //{
                //    surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}



            }
            catch (Exception ex)
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }

        public static decimal GetFareRate(int subCompanyId, int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
                       , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool CanCheckZoneWise, DateTime? pickupTime, ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist, ref string estimatedTime, ref decimal companyPrice, int? fromZoneId, int? toZoneId,ref decimal agentComm,ref decimal agentcharge)
        {
            string miles = "";
            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;


          

            bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

                if ((tempFromPostCode.Length > 0 || fromZoneId.ToInt() > 0) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                 //   surchargeRateFrom = GetSurchargeRate(tempFromPostCode, fromZoneId, pickupTime.ToDateTime(), ref surchargeRateFromAmountWise);
                }

                if ((tempToPostCode.Length > 0 || toZoneId.ToInt() > 0) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                  //  surchargeRateTo = GetSurchargeRate(tempToPostCode, toZoneId, pickupTime.ToDateTime(), ref surchargeRateToAmountWise);
                }


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    if (fromArr.Count() > 1)
                    {
                        fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];
                    }

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId ==test 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    if (toArr.Count() > 1)
                        ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();
                List<Fare_ChargesDetail> list = null;
                if ((IsVia == false && milesList.Count == 0) || (IsVia && AppVars.objPolicyConfiguration.ViaPointFareCalculationType.ToBool() == false))
                {


                    if (vehicleTypeId != defaultVehicleId)
                    {

                        if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                        {

                            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == defaultVehicleId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                                                          )
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }


                        }
                        else
                        {


                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                if (tempFromPostCode.Length > 0 && tempToPostCode.Length > 0 &&

                                       (db.Fare_ChargesDetails.Where(c =>



                                                                    c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                    &&
                                    (db.Fare_OtherCharges.Where(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                                  && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))


                                //(General.GetQueryable<Fare_ChargesDetail>(c =>


                                //                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                //                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                //                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                //                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                //                                     )
                                //                               && c.Fare.VehicleTypeId == vehicleTypeId
                                //                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                //&& (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                //                                              && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))
                                {

                                    vehicleTypeId = defaultVehicleId;
                                    IsMoreFareWise = true;
                                }
                                else if (tempFromPostCode.Length == 0 || tempToPostCode.Length == 0)
                                {
                                    if ((db.Fare_OtherCharges.Where(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                                  && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))
                                    {
                                        vehicleTypeId = defaultVehicleId;
                                        IsMoreFareWise = true;

                                    }

                                }
                            }
                        }


                    }






                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        if ((list == null || (list != null && list.Count() == 0)) && (fromZoneId.ToInt()>0 && toZoneId.ToInt()>0))
                        {



                            list = db.Fare_ChargesDetails.Where(c =>
                                                                (
                                                                 (c.OriginLocationTypeId == 100 && c.FromZoneId == fromZoneId
                                                                && c.DestinationLocationTypeId == 100 && c.ToZoneId == toZoneId)

                                                                || (c.OriginLocationTypeId == 100 && c.FromZoneId == toZoneId
                                                                && c.DestinationLocationTypeId == 100 && c.ToZoneId == fromZoneId)

                                                                )

                                                                && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null)

                                                                 ).ToList();


                            if (list != null && list.Count > 0)
                            {
                                errorMsg = "Reverse found";

                            }

                        }


                        if ((list == null || (list != null && list.Count() == 0)) && (fromZoneId.ToInt() > 0 && tempToPostCode.Length > 0))
                        {



                            list = db.Fare_ChargesDetails.Where(c =>
                                                                (
                                                                 ( c.FromZoneId == fromZoneId
                                                              && (( (c.ToAddress.Equals(ToSingleHalfPostCode) || c.ToAddress.Equals(toHalfPostCode) || c.ToAddress.Equals(startToPostCode) || c.ToAddress.Equals(tempToPostCode))) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))

                                                                                                                                                                                  

                                                                )
                                                                )


                                                                //&& c.Fare.VehicleTypeId == vehicleTypeId
                                                                //&& (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null)

                                                                 ).ToList();


                            if (list != null && list.Count > 0)
                            {
                                errorMsg = "Reverse found";

                            }

                        }



                        if ((list == null || (list != null && list.Count() == 0)) && (toZoneId.ToInt() > 0 && tempFromPostCode.Length > 0))
                        {



                            list = db.Fare_ChargesDetails.Where(c =>
                                                                (

                                                         (((c.FromAddress.Equals(fromSingleHalfPostCode) || c.FromAddress.Equals(fromHalfPostCode) || c.FromAddress.Equals(startFromPostCode) || c.FromAddress.Equals(tempFromPostCode))) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))


                                                              
                                                                && c.ToZoneId==toZoneId)

                                                                

                                                                //&& c.Fare.VehicleTypeId == vehicleTypeId
                                                                //&& (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null)

                                                                 ).ToList();


                            if (list != null && list.Count > 0)
                            {
                                errorMsg = "Reverse found";

                            }

                        }


                        if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                        {







                            list = db.Fare_ChargesDetails.Where(c => ((((((c.OriginLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.FromAddress.Equals(fromSingleHalfPostCode) || c.FromAddress.Equals(fromHalfPostCode) || c.FromAddress.Equals(startFromPostCode) || c.FromAddress.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))))
                                                                           && ((((c.DestinationLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.ToAddress.Equals(ToSingleHalfPostCode) || c.ToAddress.Equals(toHalfPostCode) || c.ToAddress.Equals(startToPostCode) || c.ToAddress.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode))))))
                                                                      ||

                                                                      (
                                                                            ((c.OriginLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.FromAddress.Equals(ToSingleHalfPostCode) || c.FromAddress.Equals(toHalfPostCode) || c.FromAddress.Equals(startToPostCode) || c.FromAddress.Equals(tempToPostCode))) || ((c.FromAddress.ToUpper().EndsWith(tempToPostCode))))
                                                                  && ((c.DestinationLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.ToAddress.Equals(fromSingleHalfPostCode) || c.ToAddress.Equals(fromHalfPostCode) || c.ToAddress.Equals(startFromPostCode) || c.ToAddress.Equals(tempFromPostCode))) || ((c.ToAddress.ToUpper().EndsWith(tempFromPostCode)))
                                                                  )
                                                                  )
                                                                     
                                                                              )



                                                                          ).ToList();







                        }

                        if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                        {
                            //list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempFromPostCode))) || c.OriginId == tempFromLocId)
                            //                                            && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempToPostCode))) || c.DestinationId == tempToLocId))

                            //                                            || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempToPostCode))) || c.OriginId == tempToLocId)
                            //                                            && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                            //                                               )

                            //                                          && c.Fare.VehicleTypeId == vehicleTypeId
                            //                                          && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                            //                                                                                                         // && (c.Fare.CompanyId == companyId || companyId == 0)

                            //                                           ).ToList();


                            list = db.Fare_ChargesDetails.Where(c => ((((c.OriginLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.FromAddress.Equals(fromSingleHalfPostCode) || c.FromAddress.Equals(fromHalfPostCode) || c.FromAddress.Equals(startFromPostCode) || c.FromAddress.Equals(tempFromPostCode))) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))
                                                                  && ((c.DestinationLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.ToAddress.Equals(ToSingleHalfPostCode) || c.ToAddress.Equals(toHalfPostCode) || c.ToAddress.Equals(startToPostCode) || c.ToAddress.Equals(tempToPostCode))) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))

                                                                  || ((c.OriginLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.FromAddress.Equals(ToSingleHalfPostCode) || c.FromAddress.Equals(toHalfPostCode) || c.FromAddress.Equals(startToPostCode) || c.FromAddress.Equals(tempToPostCode))) || ((c.FromAddress.ToUpper().EndsWith(tempToPostCode))))
                                                                  && ((c.DestinationLocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.ToAddress.Equals(fromSingleHalfPostCode) || c.ToAddress.Equals(fromHalfPostCode) || c.ToAddress.Equals(startFromPostCode) || c.ToAddress.Equals(tempFromPostCode))) || ((c.ToAddress.ToUpper().EndsWith(tempFromPostCode)))))
                                                                     )

                                                                && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null)

                                                                 ).ToList();


                            if (list != null && list.Count > 0)
                            {
                                errorMsg = "Reverse found";

                            }

                        }


                     




                        // for milennium executives
                        if (list != null && list.Count > 0)
                        {

                            if (companyId == 0)
                            {

                                list = list.Where(c => c.Fare.VehicleTypeId == vehicleTypeId && c.Fare.CompanyId == null).ToList();
                            }
                            else
                            {
                                if (list.Count(c => c.Fare.VehicleTypeId == vehicleTypeId && c.Fare.CompanyId == companyId) > 0)
                                    list = list.Where(c => c.Fare.VehicleTypeId == vehicleTypeId && c.Fare.CompanyId == companyId).ToList();
                                else if (list.Count(c => c.Fare.VehicleTypeId == vehicleTypeId) > 0)
                                {
                                    companyId = 0;
                                    list = list.Where(c => c.Fare.VehicleTypeId == vehicleTypeId).ToList();
                                }

                                else if (list.Count(c => c.Fare.VehicleTypeId == defaultVehicleId && c.Fare.CompanyId == companyId) > 0)
                                {
                                   
                                    list = list.Where(c => c.Fare.VehicleTypeId == defaultVehicleId && c.Fare.CompanyId == companyId).ToList();
                                }
                                else if (list.Count(c => c.Fare.VehicleTypeId == defaultVehicleId) > 0)
                                {
                                    companyId = 0;
                                    list = list.Where(c => c.Fare.VehicleTypeId == defaultVehicleId).ToList();
                                }

                            }



                        }
                    }
                    // END milennium executives

                }
                else
                {

                    if ((IsVia == false && milesList.Count > 0 && AppVars.objPolicyConfiguration.ViaPointFareCalculationType.ToBool() && vehicleTypeId != defaultVehicleId))
                    {

                        using (TaxiDataContext db = new TaxiDataContext())
                        {

                            if (CanCheckZoneWise && AppVars.objPolicyConfiguration.EnableZoneWiseFares.ToBool() == false)
                            {
                                if (db.Gen_SysPolicy_FaresSettings.Where(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId && (c.Amount > 0 || c.Percentage > 0)).Count() > 0)
                                {
                                    vehicleTypeId = defaultVehicleId;


                                }
                            }
                            else
                            {

                                if (db.Gen_SysPolicy_FaresSettings.Where(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId && (c.Amount > 0 || c.Percentage > 0)).Count() > 0)
                                {
                                    vehicleTypeId = defaultVehicleId;
                                    IsMoreFareWise = true;

                                }
                                else

                                {
                                    if(db.Fares.Count(c=>c.VehicleTypeId==vehicleTypeId && ( (companyId==0 && c.CompanyId==null) || c.CompanyId==companyId))==0)
                                    vehicleTypeId = defaultVehicleId;
                                }
                            }
                        }

                    }


                }

            


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }




                stp_getCoordinatesByAddressResult pickupCoord = null;
                stp_getCoordinatesByAddressResult destCoord = null;

                try
                {

                    //TEMPORARY REMOVED=> PUT IT BACK ,  JUST COMMENT THESE LINES BECAUSE OF MOUNT CARS
                    //if(AppVars.objPolicyConfiguration.ViaPointExtraCharges.ToDecimal()>0)
                    //{
                    //    var coord=   GetDistance.PostCodeToLongLat(fromVal, "GB");
                    //    if(coord!=null)
                    //    {
                    //        pickupCoord = new stp_getCoordinatesByAddressResult() { Latitude = coord.Value.Latitude, Longtiude = coord.Value.Longitude };

                    //    }

                    //     coord = GetDistance.PostCodeToLongLat(toVal, "GB");
                    //    if (coord != null)
                    //    {
                    //        destCoord = new stp_getCoordinatesByAddressResult() { Latitude = coord.Value.Latitude, Longtiude = coord.Value.Longitude };

                    //    }
                    //}

                    pickupCoord = General.GetCoordinatesByAddress(fromVal, General.GetPostCodeMatch(tempFromPostCode));
                    destCoord = General.GetCoordinatesByAddress(toVal, General.GetPostCodeMatch(tempToPostCode));

                    //using (TaxiDataContext db = new TaxiDataContext())
                    //{
                    //    if(pickupCoord==null)
                    //    pickupCoord = db.stp_getCoordinatesByAddress(fromVal, General.GetPostCodeMatch(tempFromPostCode)).FirstOrDefault();


                    //    if(destCoord==null)
                    //    destCoord = db.stp_getCoordinatesByAddress(toVal, General.GetPostCodeMatch(tempToPostCode)).FirstOrDefault();
                    //}
                }
                catch
                {


                }



                string originString = string.Empty;
                string destString = string.Empty;
                if (pickupCoord != null && pickupCoord.Latitude != null && pickupCoord.Latitude != 0)
                {
                    originString = pickupCoord.Latitude + "," + pickupCoord.Longtiude;
                }

                if (destCoord != null && destCoord.Latitude != null && destCoord.Latitude != 0)
                {
                    destString = destCoord.Latitude + "," + destCoord.Longtiude;
                }


                //if (IsVia || milesList.Count > 0)
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime, true).ToStr();
                //else
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime).ToStr();



                if (CanCheckZoneWise == false)
                {
                    if (IsVia || milesList.Count > 0)
                        miles = CalculateDistance(originString, destString, ref estimatedTime, true).ToStr();
                    else
                        miles = CalculateDistance(originString, destString, ref estimatedTime).ToStr();

                    milesList.Add(miles.ToDecimal());

                }





                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {

                            if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                                && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                if (obj == null)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                              && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                }
                            }

                            if(obj==null)
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId);

                            if (obj == null)
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                        //    farecalculateby = 4;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {


                                if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                    && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                    if(obj==null)
                                    {
                                        obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                  && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                    }

                                }

                                if(obj==null)
                                obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                                if (obj == null)
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);


                                companyFareExist = true;
                           //     farecalculateby = 4;
                            }


                        }
                    }
                    else
                    {
                        if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null 
                            && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));



                            if (obj == null)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                          && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                            }
                        }

                        if(obj==null)
                        obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                        if (obj == null)
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);

                    //    farecalculateby = 4;
                    }

                }


                if (obj != null && AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false)
                {


                    rtnFare = obj.Rate.ToDecimal();
                    companyPrice = obj.CompanyRate.ToDecimal();
                    agentComm = obj.PeakTimeRate.ToDecimal();
                    agentcharge = obj.OffPeakTimeRate.ToDecimal();

                    deadMileage = 0;
                    errorMsg = "fixed";
                }
                else
                {

                    if ((string.IsNullOrEmpty(tempFromPostCode) && string.IsNullOrEmpty(originString)) || (string.IsNullOrEmpty(tempToPostCode) && string.IsNullOrEmpty(destString)))
                    {
                        errorMsg = "Error";
                        return 0;
                    }



                    if (IsVia)
                        return rtnFare;

                    if (deadMileage > 0)
                    {

                        string fromBasePostCode = General.GetPostCodeMatch(AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper().Trim());
                        decimal deadMileageDistance = General.CalculateDistance(fromBasePostCode, tempFromPostCode);

                        deadMileage = deadMileageDistance - deadMileage;

                        if (deadMileage < 0)
                            deadMileage = 0;


                        milesList.Add(deadMileage.ToDecimal());

                    }

                    // Calculate Fare Mileage Wise                
                    //  ISingleResult<ClsFares> objFare = General.SP_CalculateFares(vehicleTypeId.ToIntorNull(), companyId.ToIntorNull(), milesList.Sum().ToStr(), pickupTime);
                    decimal totalMiles = milesList.Sum();


                    if (AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal() > 0)
                    {

                        totalMiles = Math.Ceiling(totalMiles / AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal()) * AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal();

                    }



                    // var objFare = new TaxiDataContext().stp_CalculateGeneralFares(vehicleTypeId, companyId, totalMiles, pickupTime);
                    if (AppVars.objPolicyConfiguration.EnablePeakOffPeakFares.ToBool() && AppVars.objPolicyConfiguration.FareMeterType.ToInt() <2)
                    {
                        pickupTime = string.Format("{0:dd/MM/yyyy HH:mm}", new DateTime(1900, 1, 1, 0, 0, 0).ToDate() + pickupTime.Value.TimeOfDay).ToDateTime();

                    }




                    //   ISingleResult<stp_CalculateGeneralFaresBySubCompanyResult> objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId);

                    Clsstp_CalculateGeneralFaresBySubCompany objFare = null;


                    try
                    {
                        objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5},{6}"
                              , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise, fromZoneId).FirstOrDefault();
                    }
                    catch
                    {
                        objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                                , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise).FirstOrDefault();


                    }

                    //if (Debugger.IsAttached)
                    //objFare=  new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5},{6}"
                    //          , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise,fromZoneId).FirstOrDefault();
                    //else
                    //    objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                    //             , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise).FirstOrDefault();

                    if (objFare != null)
                    {
                        var f = objFare;

                        if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                        {


                            if (AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false || obj == null ||
                                (f.totalFares.ToDecimal() > obj.Rate.ToDecimal() && (fromLocTypeId != Enums.LOCATION_TYPES.AIRPORT && toLocTypeId != Enums.LOCATION_TYPES.AIRPORT)))
                            {
                                rtnFare = f.totalFares.ToDecimal();
                                companyPrice = f.totalCost.ToDecimal();


                                if (companyPrice == 0)
                                    companyPrice = rtnFare;
                                else
                                {
                                    rtnFare = f.totalCost.ToDecimal();
                                    companyPrice = f.totalFares.ToDecimal();



                                }

                                companyFareExist = f.CompanyFareExist.ToBool();
                            }
                            else
                            {

                                if (obj != null)
                                {
                                    rtnFare = obj.Rate.ToDecimal();
                                    companyPrice = obj.CompanyRate.ToDecimal();
                                }
                                else
                                {
                                    rtnFare = f.totalFares.ToDecimal();
                                    companyFareExist = f.CompanyFareExist.ToBool();
                                }

                            }

                        }
                        else
                            errorMsg = "Error";



                    }
                    else
                        errorMsg = "Error";






                    if (deadMileage > 0)
                    {
                        deadMileage = 0;

                        if (milesList.Count > 1)
                            milesList.RemoveAt(1);

                    }

                    if (AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt() == actualVehicleTypeId
                        || (IsMoreFareWise == false && rtnFare > 0))
                    {
                        if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                        {

                         //   decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == vehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                            if (totalMiles > 0)
                            {

                                if (companyPrice > 0)
                                {
                                    companyPrice = Math.Ceiling(companyPrice);

                                }
                                //  rtnFare = Math.Ceiling((rtnFare);
                                rtnFare = Math.Ceiling(rtnFare);


                            }
                        }
                        else
                        {



                            decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                            if (roundUp > 0)
                            {
                                // fareVal = (decimal)Math.Ceiling(fareVal / roundUp) * roundUp;

                                rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;


                                if (companyPrice > 0)
                                {
                                    companyPrice = (decimal)Math.Ceiling(companyPrice / roundUp) * roundUp;

                                }
                            }


                            if (AppVars.objPolicyConfiguration.AutoShowBookingNearestDrv.ToBool())
                            {

                                rtnFare = (decimal)Math.Round(rtnFare, 0);

                                if (companyPrice > 0)
                                {
                                    companyPrice = (decimal)Math.Round(companyPrice, 0);

                                }
                            }



                            // rtnFare = (decimal)Math.Ceiling(rtnFare / 0.5m) * 0.5m;


                        }

                    }

                }






                if (IsMoreFareWise)
                {

                    decimal AddedAmount = 0.00m;
                    decimal addedcompanypriceamount = 0.00m;
                    string op = string.Empty;

                    Gen_SysPolicy_FaresSetting objFare = null;

                    //if (companyId != null)
                    //{
                    //    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId && (c.IsCompanyWise!=null && c.IsCompanyWise==true));
                    //}
                    //else
                    //{

                    //   if(objFare==null)
                    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId);
                    //  }
                    if (objFare != null)
                    {
                        op = objFare.Operator.ToStr();


                        if (objFare.IsAmountWise == false)
                        {
                            AddedAmount = (rtnFare * objFare.Percentage.ToDecimal()) / 100;


                            addedcompanypriceamount = (companyPrice * objFare.Percentage.ToDecimal()) / 100;
                        }
                        else
                        {
                            AddedAmount = objFare.Amount.ToDecimal();

                        }

                    }


                    switch (op)
                    {
                        case "+":
                            rtnFare = rtnFare + AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice + addedcompanypriceamount;

                            }
                            break;

                        case "-":
                            rtnFare = rtnFare - AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice - addedcompanypriceamount;

                            }
                            break;

                        default:
                            rtnFare = rtnFare + AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice + addedcompanypriceamount;

                            }
                            break;
                    }




                    if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                    {


                        rtnFare = Math.Ceiling(rtnFare);

                        if (companyPrice > 0)
                        {
                            companyPrice = Math.Ceiling(companyPrice);

                        }

                    }
                    else
                    {

                        decimal roundUp2 = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                        if (roundUp2 > 0)
                        {
                            rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp2) * roundUp2;


                            if (companyPrice > 0)
                            {
                                companyPrice = (decimal)Math.Ceiling(companyPrice / roundUp2) * roundUp2;

                            }


                        }

                        if (AppVars.objPolicyConfiguration.AutoShowBookingNearestDrv.ToBool())
                        {

                            rtnFare = (decimal)Math.Round(rtnFare, 0);

                            if (companyPrice > 0)
                            {
                                companyPrice = (decimal)Math.Round(companyPrice, 0);

                            }
                        }
                    }

                }



                //if (obj == null) // surcharge should add only on mileage fares
                //{

                //if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                //{

                //    decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                //    decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                //    rtnFare = rtnFare + fareSurchargePercent;

                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                //{

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                //{
                //    surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                //{
                //    surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}


                //  }





            }
            catch (Exception ex)
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }




        public static decimal GetFareRate(int subCompanyId, int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
                  , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool excludeStartRate, DateTime? pickupTime, ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist, ref string estimatedTime, ref decimal companyPrice)
        {
            string miles = "";
            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;


            bool surchargeRateFromAmountWise = false;
            bool surchargeRateToAmountWise = false;

            decimal surchargeRateFrom = 0.00m;
            decimal surchargeRateTo = 0.00m;

            bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

                if (tempFromPostCode.Length > 0 && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                    surchargeRateFrom = GetSurchargeRate(tempFromPostCode, ref surchargeRateFromAmountWise);
                }

                if (tempToPostCode.Length > 0 && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                    surchargeRateTo = GetSurchargeRate(tempToPostCode, ref surchargeRateToAmountWise);
                }


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    if (fromArr.Count() > 1)
                    {
                        fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];
                    }

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    if (toArr.Count() > 1)
                        ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();
                List<Fare_ChargesDetail> list = null;
                if ((IsVia == false && milesList.Count == 0) || (IsVia && AppVars.objPolicyConfiguration.ViaPointFareCalculationType.ToBool() == false))
                {


                    if (vehicleTypeId != defaultVehicleId)
                    {

                        if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                        {

                            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == defaultVehicleId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                                                          )
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }


                        }
                        else
                        {


                            if (tempFromPostCode.Length > 0 && tempToPostCode.Length > 0 &&
                                //(General.GetQueryable<Fare_ChargesDetail>(c =>


                                //                                      ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                //                                            && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                //                                            || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                //                                            && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                //                                               )
                                //                                         && c.Fare.VehicleTypeId == vehicleTypeId
                                //                                          && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                (General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == vehicleTypeId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                                && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                              && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }
                            else if (tempFromPostCode.Length == 0 || tempToPostCode.Length == 0)
                            {
                                if ((General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                              && (c.Fare.CompanyId == companyId || companyId == 0 || c.Fare.CompanyId == null)).Count() == 0))
                                {
                                    vehicleTypeId = defaultVehicleId;
                                    IsMoreFareWise = true;

                                }

                            }
                        }


                    }









                    if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))) || c.OriginId == tempFromLocId)
                                                                       && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))) || c.DestinationId == tempToLocId))

                                                                          )

                                                                     && c.Fare.VehicleTypeId == vehicleTypeId

                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                      ).ToList();

                    }

                    if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                    || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                 // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();


                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }

                    }

                    if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                    {
                        if (tempFromLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                   && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                   || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                   && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                        }

                        if ((list == null || list.Count == 0) && tempToLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }



                        if ((list == null || list.Count == 0))
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }

                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }


                    }

                }
                else
                {

                    if ((IsVia == false && milesList.Count > 0 && AppVars.objPolicyConfiguration.ViaPointFareCalculationType.ToBool() && vehicleTypeId != defaultVehicleId))
                    {
                        vehicleTypeId = defaultVehicleId;
                        IsMoreFareWise = true;

                    }


                }

                //if ((tempFromLocId == 0 && string.IsNullOrEmpty(startFromPostCode)) || (tempToLocId == 0 && string.IsNullOrEmpty(startToPostCode)))
                //    obj = null;


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }




                stp_getCoordinatesByAddressResult pickupCoord = null;
                stp_getCoordinatesByAddressResult destCoord = null;

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        //pickupCoord = db.stp_getCoordinatesByAddress(fromVal, General.GetPostCodeMatch(tempFromPostCode)).FirstOrDefault();
                        //destCoord = db.stp_getCoordinatesByAddress(toVal, General.GetPostCodeMatch(tempToPostCode)).FirstOrDefault();


                        pickupCoord =General.GetCoordinatesByAddress(fromVal, General.GetPostCodeMatch(tempFromPostCode),db);
                        destCoord = General.GetCoordinatesByAddress(toVal, General.GetPostCodeMatch(tempToPostCode),db);
                    }
                }
                catch
                {


                }



                string originString = string.Empty;
                string destString = string.Empty;
                if (pickupCoord != null && pickupCoord.Latitude != null && pickupCoord.Latitude != 0)
                {
                    originString = pickupCoord.Latitude + "," + pickupCoord.Longtiude;
                }

                if (destCoord != null && destCoord.Latitude != null && destCoord.Latitude != 0)
                {
                    destString = destCoord.Latitude + "," + destCoord.Longtiude;
                }


                //if (IsVia || milesList.Count > 0)
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime, true).ToStr();
                //else
                //    miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime).ToStr();


                if (IsVia || milesList.Count > 0)
                    miles = CalculateDistance(originString, destString, ref estimatedTime, true).ToStr();
                else
                    miles = CalculateDistance(originString, destString, ref estimatedTime).ToStr();




                milesList.Add(miles.ToDecimal());


                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                                companyFareExist = true;

                            }


                        }
                    }
                    else
                    {
                        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                    }

                }


                if (obj != null && AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false)
                {

                    rtnFare = obj.Rate.ToDecimal();
                    companyPrice = obj.CompanyRate.ToDecimal();
                    deadMileage = 0;
                    errorMsg = "fixed";
                }
                else
                {

                    if ((string.IsNullOrEmpty(tempFromPostCode) && string.IsNullOrEmpty(originString)) || (string.IsNullOrEmpty(tempToPostCode) && string.IsNullOrEmpty(destString)))
                    {
                        errorMsg = "Error";
                        return 0;
                    }



                    if (IsVia)
                        return rtnFare;

                    if (deadMileage > 0)
                    {

                        string fromBasePostCode = General.GetPostCodeMatch(AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper().Trim());
                        decimal deadMileageDistance = General.CalculateDistance(fromBasePostCode, tempFromPostCode);

                        deadMileage = deadMileageDistance - deadMileage;

                        if (deadMileage < 0)
                            deadMileage = 0;


                        milesList.Add(deadMileage.ToDecimal());

                    }

                    // Calculate Fare Mileage Wise                
                    //  ISingleResult<ClsFares> objFare = General.SP_CalculateFares(vehicleTypeId.ToIntorNull(), companyId.ToIntorNull(), milesList.Sum().ToStr(), pickupTime);
                    decimal totalMiles = milesList.Sum();


                    if (AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal() > 0)
                    {

                        totalMiles = Math.Ceiling(totalMiles / AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal()) * AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal();

                    }



                    // var objFare = new TaxiDataContext().stp_CalculateGeneralFares(vehicleTypeId, companyId, totalMiles, pickupTime);
                    if (AppVars.objPolicyConfiguration.EnablePeakOffPeakFares.ToBool() && AppVars.objPolicyConfiguration.FareMeterType.ToInt() < 2)
                    {
                        pickupTime = string.Format("{0:dd/MM/yyyy HH:mm}", new DateTime(1900, 1, 1, 0, 0, 0).ToDate() + pickupTime.Value.TimeOfDay).ToDateTime();

                    }


                    Clsstp_CalculateGeneralFaresBySubCompany objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                       , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, excludeStartRate).FirstOrDefault();

                    //   ISingleResult<stp_CalculateGeneralFaresBySubCompanyResult> objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId);


                    if (objFare != null)
                    {
                        var f = objFare;

                        if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                        {


                            if (AppVars.objPolicyConfiguration.PreferredMileageFares.ToBool() == false || obj == null ||
                                (f.totalFares.ToDecimal() > obj.Rate.ToDecimal() && (fromLocTypeId != Enums.LOCATION_TYPES.AIRPORT && toLocTypeId != Enums.LOCATION_TYPES.AIRPORT)))
                            {
                                rtnFare = f.totalFares.ToDecimal();
                                companyPrice = f.totalFares.ToDecimal();
                                companyFareExist = f.CompanyFareExist.ToBool();
                            }
                            else
                            {

                                if (obj != null)
                                {
                                    rtnFare = obj.Rate.ToDecimal();
                                    companyPrice = obj.CompanyRate.ToDecimal();
                                }
                                else
                                {
                                    rtnFare = f.totalFares.ToDecimal();
                                    companyFareExist = f.CompanyFareExist.ToBool();
                                }

                            }

                        }
                        else
                            errorMsg = "Error";



                    }
                    else
                        errorMsg = "Error";






                    if (deadMileage > 0)
                    {
                        deadMileage = 0;

                        if (milesList.Count > 1)
                            milesList.RemoveAt(1);

                    }

                    if (AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt() == actualVehicleTypeId
                        || ( (AppVars.objPolicyConfiguration.BookingFormType.ToInt()==1 || IsMoreFareWise == false) && rtnFare > 0))
                    {
                        if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                        {

                            decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == actualVehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                            if (startRateTillMiles > 0 && totalMiles > startRateTillMiles)
                            {

                                if (companyPrice > 0)
                                {
                                    companyPrice = Math.Ceiling(companyPrice);

                                }
                                //  rtnFare = Math.Ceiling((rtnFare);
                                rtnFare = Math.Ceiling(rtnFare);

                               
                            }
                            else
                            {
                                if (startRateTillMiles > 0 && totalMiles <= startRateTillMiles && AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt() != actualVehicleTypeId)
                                {
                                    rtnFare = General.GetObject<Fleet_VehicleType>(c => c.Id == actualVehicleTypeId).DefaultIfEmpty().StartRate.ToDecimal();
                                    companyPrice = rtnFare;

                                    IsMoreFareWise = false;
                                }


                            }
                        }
                        else
                        {



                            decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                            if (roundUp > 0)
                            {
                                // fareVal = (decimal)Math.Ceiling(fareVal / roundUp) * roundUp;

                                rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;


                                if (companyPrice > 0)
                                {
                                    companyPrice = (decimal)Math.Ceiling(companyPrice / roundUp) * roundUp;

                                }
                            }


                            if (AppVars.objPolicyConfiguration.AutoShowBookingNearestDrv.ToBool())
                            {

                                rtnFare = (decimal)Math.Round(rtnFare, 0);

                                if (companyPrice > 0)
                                {
                                    companyPrice = (decimal)Math.Round(companyPrice, 0);

                                }
                            }



                            // rtnFare = (decimal)Math.Ceiling(rtnFare / 0.5m) * 0.5m;


                        }

                    }

                }






                if (IsMoreFareWise)
                {

                    decimal AddedAmount = 0.00m;
                    string op = string.Empty;

                    Gen_SysPolicy_FaresSetting objFare = null;

                    //if (companyId != null)
                    //{
                    //    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId && (c.IsCompanyWise!=null && c.IsCompanyWise==true));
                    //}
                    //else
                    //{

                    //   if(objFare==null)
                    objFare = General.GetObject<Gen_SysPolicy_FaresSetting>(c => c.SysPolicyId != null && c.VehicleTypeId == actualVehicleTypeId);
                    //  }
                    if (objFare != null)
                    {
                        op = objFare.Operator.ToStr();


                        if (objFare.IsAmountWise == false)
                        {
                            AddedAmount = (rtnFare * objFare.Percentage.ToDecimal()) / 100;
                        }
                        else
                        {
                            AddedAmount = objFare.Amount.ToDecimal();

                        }

                    }


                    switch (op)
                    {
                        case "+":
                            rtnFare = rtnFare + AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice - AddedAmount;

                            }
                            break;

                        case "-":
                            rtnFare = rtnFare - AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice - AddedAmount;

                            }
                            break;

                        default:
                            rtnFare = rtnFare + AddedAmount;
                            if (companyPrice > 0)
                            {
                                companyPrice = companyPrice - AddedAmount;

                            }
                            break;
                    }




                    if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                    {


                        rtnFare = Math.Ceiling(rtnFare);

                        if (companyPrice > 0)
                        {
                            companyPrice = Math.Ceiling(companyPrice);

                        }

                    }
                    else
                    {

                        decimal roundUp2 = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                        if (roundUp2 > 0)
                        {
                            rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp2) * roundUp2;


                            if (companyPrice > 0)
                            {
                                companyPrice = (decimal)Math.Ceiling(companyPrice / roundUp2) * roundUp2;

                            }


                        }

                        if (AppVars.objPolicyConfiguration.AutoShowBookingNearestDrv.ToBool())
                        {

                            rtnFare = (decimal)Math.Round(rtnFare, 0);

                            if (companyPrice > 0)
                            {
                                companyPrice = (decimal)Math.Round(companyPrice, 0);

                            }
                        }
                    }

                }



                if (obj == null)
                {

                    if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                    {

                        decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                        decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                        rtnFare = rtnFare + fareSurchargePercent;

                    }
                    else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                    {

                        rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                    }
                    else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                    {
                        surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                        rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                    }
                    else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                    {
                        surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                        rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                    }


                }





            }
            catch (Exception ex)
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }






        public static decimal GetSimpleFareRateWithRoundTrip(int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
          , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool CanCheckZoneWise, DateTime? pickupTime, ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist, ref string estimatedTime, int? fromZoneId, int? toZoneId, ref bool IsMoreFareWise, ref int farecalculateby, int subCompanyId, DateTime? returnPickupDate, int returnVehicleTypeId, ref decimal returnFares, ref decimal companyPrice, decimal manualMiles = 0.00m)
        {

            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;


            //bool surchargeRateFromAmountWise = false;
            //bool surchargeRateToAmountWise = false;

            //decimal surchargeRateFrom = 0.00m;
            //decimal surchargeRateTo = 0.00m;

            // bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;


            try
            {

                //if ((tempFromPostCode.Length > 0) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                //    surchargeRateFrom = GetSurchargeRate(tempFromPostCode, ref surchargeRateFromAmountWise);
                //}

                //if ((tempToPostCode.Length > 0 ) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                //{
                //    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                //    surchargeRateTo = GetSurchargeRate(tempToPostCode, ref surchargeRateToAmountWise);
                //}

                if ((tempFromPostCode.Length > 0 || fromZoneId.ToInt() > 0) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                    //  surchargeRateFrom = GetSurchargeRate(tempFromPostCode, fromZoneId, pickupTime.ToDateTime(), ref surchargeRateFromAmountWise);
                }

                if ((tempToPostCode.Length > 0 || toZoneId.ToInt() > 0) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                    //   surchargeRateTo = GetSurchargeRate(tempToPostCode, toZoneId, pickupTime.ToDateTime(), ref surchargeRateToAmountWise);
                }


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode) && (fromLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);


                    if(fromArr.Count()>1)
                    fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode) && (toLocTypeId != Enums.LOCATION_TYPES.TOWN))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    if(toArr.Count()>1)
                    ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();

                if (vehicleTypeId != defaultVehicleId && CanCheckZoneWise == false)
                {

                    if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                    {





                        if (IsMoreFareWise == false)
                        {
                            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.FromZoneId == fromZoneId || c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.ToZoneId == toZoneId || c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == defaultVehicleId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                                                          )
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }
                        }


                    }
                    else
                    {


                        //if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                        //                                          ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                        //                                                && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                        //                                                || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                        //                                                && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                        //                                                   )
                        //                                             && c.Fare.VehicleTypeId == vehicleTypeId
                        //                                              && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                        //    && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                        //                                                  && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0))



                        if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                                 
                                                                     (c.Fare.VehicleTypeId == vehicleTypeId
                                                                      && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null))).Count() == 0)

                            && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                          && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null)
                                                                          
                                                                          ).Count() == 0))
                        {

                            vehicleTypeId = defaultVehicleId;
                            IsMoreFareWise = true;
                        }
                    }


                }





                List<Fare_ChargesDetail> list = null;



                if (CanCheckZoneWise == false)
                {
                    if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()) || (c.FromAddress.ToUpper().EndsWith(tempFromPostCode)))) || c.OriginId == tempFromLocId)
                                                                       && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()) || (c.ToAddress.ToUpper().EndsWith(tempToPostCode)))) || c.DestinationId == tempToLocId))

                                                                          )

                                                                     && c.Fare.VehicleTypeId == vehicleTypeId

                                                                    && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                   //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                      ).ToList();

                    }

                    if ((list == null || (list != null && list.Count() == 0)) && tempFromPostCode.Length > 0 && tempToPostCode.Length > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                    || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (tempToLocId == 0 && (c.FromAddress.ToUpper().EndsWith(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (tempFromLocId == 0 && (c.ToAddress.ToUpper().EndsWith(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  && (c.Fare.CompanyId == companyId || c.Fare.CompanyId == null) // need to comment later (this is not for all clients)- make a check on settings
                                                                                                                                 // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();


                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }

                    }

                    if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                    {
                        if (tempFromLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                   && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                   || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                   && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                        }

                        if ((list == null || list.Count == 0) && tempToLocId > 0)
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }



                        if ((list == null || list.Count == 0))
                        {
                            list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                    || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                    && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                       )

                                                                  && c.Fare.VehicleTypeId == vehicleTypeId
                                                                   // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                                   ).ToList();

                        }

                        if (list != null && list.Count > 0)
                        {
                            errorMsg = "Reverse found";

                        }


                    }




                }



                //TEMPORARY REMOVED=> PUT IT BACK ,  JUST COMMENT THESE LINES BECAUSE OF MOUNT CARS
                //if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2 || AppVars.objPolicyConfiguration.ViaPointExtraCharges.ToDecimal()>0)
                //{
                //    tempFromPostCode = fromVal;
                //    tempToPostCode = toVal;
                //}



                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {

                            if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                                && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                if (obj == null)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId
                              && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                }
                            }

                            if (obj == null)
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId && c.Fare.SubCompanyId == subCompanyId);

                            if (obj == null)
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                            //    farecalculateby = 4;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {


                                if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                                {
                                    obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                    && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));


                                    if (obj == null)
                                    {
                                        obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                                  && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                                    }

                                }

                                if (obj == null)
                                    obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                                if (obj == null)
                                    obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);


                                companyFareExist = true;
                                //     farecalculateby = 4;
                            }


                        }
                    }
                    else
                    {
                        if (list.Count > 1 && tempToPostCode.ToStr().Contains(" ") && tempToPostCode.ToStr().Length > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                            && (c.ToAddress.EndsWith(tempToPostCode) || c.FromAddress.EndsWith(tempToPostCode)));



                            if (obj == null)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null
                          && (c.ToAddress.EndsWith(tempFromPostCode) || c.FromAddress.EndsWith(tempFromPostCode)));


                            }
                        }

                        if (obj == null)
                            obj = list.FirstOrDefault(c => c.Fare.SubCompanyId == subCompanyId && c.Fare.CompanyId == null);

                        if (obj == null)
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);

                        //    farecalculateby = 4;
                    }

                }

                //if (list != null)
                //{
                //    if (companyId != 0)
                //    {
                //        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                //        {
                //            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                //            companyFareExist = true;
                //        }
                //        else
                //        {

                //            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                //            {
                //                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                //              //  companyFareExist = true;

                //            }


                //        }
                //    }
                //    else
                //    {
                //        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                //    }

                //}


                if (obj != null)
                {

                    rtnFare = obj.Rate.ToDecimal();
                    deadMileage = 0;
                    farecalculateby = 4;

                    if(companyFareExist && companyId>0)
                    {
                        companyPrice = obj.CompanyRate.ToDecimal();


                    }

                }
                else
                {
                    if (tempFromPostCode.ToStr().Length == 0)
                        tempFromPostCode = fromVal;


                    if (tempToPostCode.ToStr().Length == 0)
                        tempToPostCode = toVal;

                    if (string.IsNullOrEmpty(tempFromPostCode) || string.IsNullOrEmpty(tempToPostCode))
                    {
                        errorMsg = "Error";
                        return 0;
                    }



                    //if (AppVars.objPolicyConfiguration.DeadMileage.ToDecimal() > 0)
                    //{
                    //    //   string basePostCode = GetPostCodeMatch(AppVars.objPolicyConfiguration.BaseAddress.ToStr().ToUpper());

                    //    string basePostCode = AppVars.objPolicyConfiguration.DefaultCounty.ToStr();


                    //    decimal towntoPickup = General.CalculateDistance(basePostCode, tempFromPostCode);
                    //    decimal destToTown = (General.CalculateDistance(tempToPostCode, basePostCode));

                    //    decimal journeyMilage = General.CalculateDistance(tempFromPostCode, tempToPostCode);


                    //    if (towntoPickup > AppVars.objPolicyConfiguration.DeadMileage.ToDecimal()
                    //        && destToTown > AppVars.objPolicyConfiguration.DeadMileage.ToDecimal())
                    //    {

                    //        journeyMilage = (towntoPickup + journeyMilage + destToTown) / 2;
                    //        farecalculateby = 3;
                    //    }
                    //    else
                    //        farecalculateby = 2;


                    //    journeyMilage = Math.Round(journeyMilage, 1);
                    //    milesList.Add(journeyMilage);





                    //}
                    //else
                    //{
                    //    decimal journeyMilage = General.CalculateDistance(tempFromPostCode, tempToPostCode);
                    //    journeyMilage = Math.Round(journeyMilage, 1);
                    //    milesList.Add(journeyMilage);
                    //}
                    if (AppVars.objPolicyConfiguration.DeadMileageType.ToInt() > 0)
                    {

                       // string basePostCode = AppVars.objPolicyConfiguration.DefaultCounty.ToStr();

                        decimal deadMileageX = AppVars.objPolicyConfiguration.DeadMileage.ToDecimal();
                        int DeadMileageType = AppVars.objPolicyConfiguration.DeadMileageType.ToInt();
                        string basePostCode = AppVars.objPolicyConfiguration.DefaultCounty.ToStr();

                        if (subCompanyId == AppVars.objSubCompany.Id)
                        {
                            basePostCode = AppVars.objSubCompany.DefaultCounty.ToStr();
                            DeadMileageType = AppVars.objSubCompany.DeadMileageType.ToInt();
                            deadMileageX = AppVars.objSubCompany.DeadMileage.ToDecimal();

                        }
                        else
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                var objSub = db.Gen_SubCompanies.Where(c => c.Id == subCompanyId).Select(args => new { args.DeadMileage, args.DeadMileageType, args.DefaultCounty }).FirstOrDefault();
                                basePostCode = objSub.DefaultCounty.ToStr();
                                DeadMileageType = objSub.DeadMileageType.ToInt();
                                deadMileageX = objSub.DeadMileage.ToDecimal();

                            }
                        }

                        if (DeadMileageType > 0)
                        {
                            decimal towntoPickup = General.CalculateDistance(basePostCode, fromVal);
                            decimal destToTown = 0.00m;


                            if (DeadMileageType == 3)
                                destToTown = deadMileageX + 1;
                            else
                                destToTown = (General.CalculateDistance(toVal, basePostCode));


                            //  destToTown = (General.CalculateDistance(tempToPostCode, basePostCode));



                            decimal journeyMilage = General.CalculateDistance(fromVal, toVal);

                            if (deadMileageX == 0
                              || (towntoPickup > deadMileageX
                                && destToTown > deadMileageX)

                                )
                            {

                                if (DeadMileageType == 1)    //METHOD 1
                                {
                                    journeyMilage = (towntoPickup + journeyMilage + destToTown) / 2;
                                }
                                else if (DeadMileageType == 2)    //METHOD 2
                                {
                                    journeyMilage = ((towntoPickup / 2) + journeyMilage + (destToTown / 2));
                                }
                                else if (DeadMileageType == 3)   //METHOD 3
                                {
                                    journeyMilage = (towntoPickup + journeyMilage);
                                }
                                else if (DeadMileageType == 4)   //METHOD 4
                                {
                                    journeyMilage = ( (towntoPickup / 2) + journeyMilage);
                                }
                                else if (DeadMileageType == 5)   //METHOD 5
                                {
                                    if (towntoPickup < destToTown)
                                        journeyMilage = (((towntoPickup * 65) / 100) + journeyMilage);
                                    else
                                        journeyMilage = (((destToTown * 65) / 100) + journeyMilage);
                                }


                                farecalculateby = 3;
                            }
                            else
                                farecalculateby = 2;


                            journeyMilage = Math.Round(journeyMilage, 1);
                            milesList.Add(journeyMilage);

                        }
                        else
                        {
                            decimal journeyMilage = General.CalculateDistance(fromVal, toVal);
                            journeyMilage = Math.Round(journeyMilage, 1);
                            milesList.Add(journeyMilage);
                            farecalculateby = 2;
                        }
                    }
                    else
                    {
                        if (CanCheckZoneWise == false || milesList.Count==0)
                        {
                            decimal journeyMilage = General.CalculateDistance(fromVal, toVal);
                            journeyMilage = Math.Round(journeyMilage, 1);
                            milesList.Add(journeyMilage);
                        }
                       
                        farecalculateby = 2;

                    }

                    // Calculate Fare Mileage Wise                
                    //  ISingleResult<ClsFares> objFare = General.SP_CalculateFares(vehicleTypeId.ToIntorNull(), companyId.ToIntorNull(), milesList.Sum().ToStr(), pickupTime);
                    decimal totalMiles = milesList.Sum();


                    if (AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal() > 0)
                    {

                        totalMiles = Math.Ceiling(totalMiles / AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal()) * AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal();

                    }


                    if (manualMiles > 0)
                        totalMiles = manualMiles;


                    if (AppVars.objPolicyConfiguration.EnablePeakOffPeakFares.ToBool())
                    {


                        if( IsMoreFareWise && rtnFare==0)
                        {

                            using (TaxiDataContext db = new TaxiDataContext())
                            {


                                if (vehicleTypeId != defaultVehicleId)
                                {
                                    if (db.Fare_OtherCharges.Where(c => c.Fare.VehicleTypeId == vehicleTypeId && c.Fare.SubCompanyId == subCompanyId).Count() == 0)
                                        vehicleTypeId = defaultVehicleId;
                                    else
                                        IsMoreFareWise = false;
                                }

                                if (returnVehicleTypeId != defaultVehicleId && returnPickupDate != null)
                                {
                                    if (db.Fare_OtherCharges.Where(c => c.Fare.VehicleTypeId == returnVehicleTypeId && c.Fare.SubCompanyId == subCompanyId).Count() == 0)
                                        returnVehicleTypeId = defaultVehicleId;
                                    else
                                        IsMoreFareWise = false;


                                }
                            }


                            //vehicleTypeId = defaultVehicleId;
                        }
                   

                        Clsstp_CalculateGeneralFaresBySubCompany objFare = null;
                        //Clsstp_CalculateGeneralFaresBySubCompany objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                        // , vehicleTypeId, companyId, totalMiles,pickupTime, subCompanyId, CanCheckZoneWise).FirstOrDefault();


                        try
                        {
                            objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5},{6}"
                             , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise, fromZoneId.ToInt().ToStr()).FirstOrDefault();
                        }
                        catch
                        {
                            objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                          , vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId, CanCheckZoneWise).FirstOrDefault();


                        }

                        if (objFare != null)
                        {
                            var f = objFare;
                            //var objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(vehicleTypeId, companyId, totalMiles, pickupTime, subCompanyId);




                            //if (objFare != null)
                            //{
                            //    var f = objFare.FirstOrDefault();

                            if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                            {
                                rtnFare = f.totalFares.ToDecimal();

                                companyFareExist = f.CompanyFareExist.ToBool();
                            }
                            else
                                errorMsg = "Error";
                        }
                        else
                            errorMsg = "Error";





                        if (returnPickupDate != null)
                        {

                            if ( returnVehicleTypeId.ToInt() > 0 && returnVehicleTypeId != vehicleTypeId && returnPickupDate != null && General.GetQueryable<Fare>(c => c.VehicleTypeId == returnVehicleTypeId).Count() == 0)
                            {
                                returnVehicleTypeId = vehicleTypeId;
                            }
                           
                            if (returnVehicleTypeId == 0)
                                returnVehicleTypeId = vehicleTypeId;


                            //   objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                            //  , vehicleTypeId, companyId, totalMiles,pickupTime, subCompanyId, CanCheckZoneWise).FirstOrDefault();

                            try
                            {
                                objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5},{6}"
                                 , returnVehicleTypeId, companyId, totalMiles, returnPickupDate, subCompanyId, CanCheckZoneWise, toZoneId.ToInt().ToStr()).FirstOrDefault();
                            }
                            catch
                            {
                                objFare = new TaxiDataContext().ExecuteQuery<Clsstp_CalculateGeneralFaresBySubCompany>("exec stp_CalculateGeneralFaresBySubCompany {0},{1},{2},{3},{4},{5}"
                              , returnVehicleTypeId, companyId, totalMiles, returnPickupDate, subCompanyId, CanCheckZoneWise).FirstOrDefault();


                            }




                            if (objFare != null)
                            {
                                var f = objFare;
                                //objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(returnVehicleTypeId, companyId, totalMiles, returnPickupDate, subCompanyId);




                                //if (objFare != null)
                                //{
                                //    var f = objFare.FirstOrDefault();

                                if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                                {
                                    returnFares = f.totalFares.ToDecimal();

                                    companyFareExist = f.CompanyFareExist.ToBool();
                                }
                                else
                                    errorMsg = "Error";
                            }
                            else
                                errorMsg = "Error";

                        }

                        if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                        {
                            //decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == vehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                            if ( totalMiles>0 )
                            {
                                //  rtnFare = Math.Ceiling((rtnFare);
                                rtnFare = Math.Ceiling(rtnFare);

                                returnFares = Math.Ceiling(returnFares);
                            }
                        }
                        else
                        {
                            decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();
                            if (roundUp > 0)
                            {
                                rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;
                                returnFares = (decimal)Math.Ceiling(returnFares / roundUp) * roundUp;
                            }
                        }

                    }
                    else
                    {

                        var objFare = new TaxiDataContext().stp_CalculateGeneralFares(vehicleTypeId, companyId, totalMiles, pickupTime);

                        if (objFare != null)
                        {
                            var f = objFare.FirstOrDefault();

                            if ((f.Result == null || f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                            {
                                rtnFare = f.totalFares.ToDecimal();

                                companyFareExist = f.CompanyFareExist.ToBool();
                            }
                            else
                                errorMsg = "Error";
                        }
                        else
                            errorMsg = "Error";

                    }

                    if (deadMileage > 0)
                    {
                        deadMileage = 0;

                        if (milesList.Count > 1)
                            milesList.RemoveAt(1);

                    }

                    if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                    {

                    //    decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == vehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                        if (totalMiles > 0)
                        {

                            //  rtnFare = Math.Ceiling((rtnFare);
                            rtnFare = Math.Ceiling(rtnFare);
                            returnFares = Math.Ceiling(returnFares);
                        }
                    }
                    else
                    {
                        decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                        if (roundUp > 0)
                        {

                            rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;


                            returnFares = (decimal)Math.Ceiling(returnFares / roundUp) * roundUp;
                        }

                    }

                }


                //if (obj == null)
                //{

                //if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                //{

                //    decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                //    decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                //    rtnFare = rtnFare + fareSurchargePercent;

                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                //{

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                //{
                //    surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}
                //else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                //{
                //    surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                //    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                //}


                //}



            }
            catch
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }





        public static decimal GetSimpleFareRateBySubCompany(int companyId, int vehicleTypeId, int tempFromLocId, int tempToLocId, string tempFromPostCode
             , string tempToPostCode, ref string errorMsg, ref List<decimal> milesList, bool IsVia, bool CanCheckZoneWise, DateTime? pickupTime, ref decimal deadMileage, int fromLocTypeId, int toLocTypeId, ref bool companyFareExist, ref string estimatedTime, int? fromZoneId, int? toZoneId, ref bool IsMoreFareWise, int? subcompanyId)
        {
            string miles = "";
            decimal rtnFare = 0.00m;
            string fromVal = tempFromPostCode;
            string toVal = tempToPostCode;


            bool surchargeRateFromAmountWise = false;
            bool surchargeRateToAmountWise = false;

            decimal surchargeRateFrom = 0.00m;
            decimal surchargeRateTo = 0.00m;

            // bool IsMoreFareWise = false;
            int actualVehicleTypeId = vehicleTypeId;
            try
            {

                if (tempFromPostCode.Length > 0)
                {
                    tempFromPostCode = General.GetPostCodeMatch(tempFromPostCode);
                    surchargeRateFrom = GetSurchargeRate(tempFromPostCode, ref surchargeRateFromAmountWise);
                }

                if (tempToPostCode.Length > 0)
                {
                    tempToPostCode = General.GetPostCodeMatch(tempToPostCode);
                    surchargeRateTo = GetSurchargeRate(tempToPostCode, ref surchargeRateToAmountWise);
                }


                string fromSingleHalfPostCode = string.Empty;
                string fromHalfPostCode = string.Empty;
                string startFromPostCode = "";
                //if (tempFromLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempFromPostCode))
                {
                    string[] fromArr = tempFromPostCode.Split(new char[] { ' ' });
                    startFromPostCode = fromArr[0];

                    fromHalfPostCode = startFromPostCode;

                    startFromPostCode = General.CheckIfSpecialPostCode(startFromPostCode);

                    fromSingleHalfPostCode = fromArr[0] + " " + fromArr[1][0];

                }

                //   }


                string ToSingleHalfPostCode = string.Empty;
                string toHalfPostCode = string.Empty;
                string startToPostCode = "";
                //if (tempToLocId == 0)
                //{


                if (!string.IsNullOrEmpty(tempToPostCode))
                {
                    string[] toArr = tempToPostCode.Split(new char[] { ' ' });

                    startToPostCode = toArr[0];
                    toHalfPostCode = startToPostCode;
                    startToPostCode = General.CheckIfSpecialPostCode(startToPostCode);

                    ToSingleHalfPostCode = toArr[0] + " " + toArr[1][0];
                }
                //}

                int defaultVehicleId = AppVars.objPolicyConfiguration.DefaultVehicleTypeId.ToInt();

                if (vehicleTypeId != defaultVehicleId)
                {

                    if (AppVars.objPolicyConfiguration.ApplyPercentageWiseFareOn.ToBool())
                    {





                        if (IsMoreFareWise == false)
                        {
                            if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                            ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.FromZoneId == fromZoneId || c.OriginId == tempFromLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode)))))
                                                                  && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.ToZoneId == toZoneId || c.DestinationId == tempToLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))))))

                                                                  || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || (c.OriginId == tempToLocId || (c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode)))))
                                                                  && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationId == tempFromLocId || (c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))))))
                                                                     )
                                                               && c.Fare.VehicleTypeId == defaultVehicleId
                                                                && (c.Fare.CompanyId == companyId || companyId == 0)).Count() > 0)

                                                          )
                            {

                                vehicleTypeId = defaultVehicleId;
                                IsMoreFareWise = true;
                            }
                        }


                    }
                    else
                    {


                        if ((General.GetQueryable<Fare_ChargesDetail>(c =>


                                                                  ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                        && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                        || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                        && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                           )
                                                                     && c.Fare.VehicleTypeId == vehicleTypeId
                                                                      && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0)

                            && (General.GetQueryable<Fare_OtherCharge>(c => c.Fare.VehicleTypeId == vehicleTypeId
                                                                          && (c.Fare.CompanyId == companyId || companyId == 0)).Count() == 0))
                        {

                            vehicleTypeId = defaultVehicleId;
                            IsMoreFareWise = true;
                        }
                    }


                }





                List<Fare_ChargesDetail> list = null;


                if (list == null || (list != null && list.Count() == 0))
                {
                    //int? zoneId = fromZoneId;
                    if (fromZoneId != 0)
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => (((c.FromZoneId == fromZoneId)
                                                                       && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()))) || c.DestinationId == tempToLocId))

                                                                          )

                                                                     && c.Fare.VehicleTypeId == vehicleTypeId
                                                                      //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                      ).ToList();
                    }
                    else if (toZoneId != 0)
                    {

                        list = General.GetQueryable<Fare_ChargesDetail>(c => (((c.FromZoneId == toZoneId)
                                                                 && ((tempFromLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == fromVal.ToLower()))) || c.DestinationId == tempFromLocId))

                                                                    )

                                                               && c.Fare.VehicleTypeId == vehicleTypeId
                                                                //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                ).ToList();

                        //list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()))) || c.OriginId == tempFromLocId)
                        //                                       && c.ToZoneId == toZoneId)

                        //                                          )

                        //                                     && c.Fare.VehicleTypeId == vehicleTypeId


                        //                                      ).ToList();

                    }
                }


                if (list == null || (list != null && list.Count() == 0))
                {

                    list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && ((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || (c.OriginLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.FromAddress.ToLower() == fromVal.ToLower()))) || c.OriginId == tempFromLocId)
                                                                   && ((tempToLocId == 0 && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || (c.DestinationLocationTypeId == Enums.LOCATION_TYPES.ADDRESS && c.ToAddress.ToLower() == toVal.ToLower()))) || c.DestinationId == tempToLocId))

                                                                      )

                                                                 && c.Fare.VehicleTypeId == vehicleTypeId
                                                                  //&& (c.Fare.CompanyId == companyId || companyId == 0)

                                                                  ).ToList();

                }

                if (list == null || (list != null && list.Count() == 0))
                {
                    list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                                || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                                && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();


                    if (list != null && list.Count > 0)
                    {
                        errorMsg = "Reverse found";

                    }

                }

                if ((tempFromLocId != 0 || tempToLocId != 0) && (list == null || (list != null && list.Count() == 0)))
                {
                    if (tempFromLocId > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                               && ((tempToLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode))) || c.DestinationId == tempToLocId))

                                                               || (((tempToLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))) || c.OriginId == tempToLocId)
                                                               && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                  )

                                                             && c.Fare.VehicleTypeId == vehicleTypeId
                                                              // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                              ).ToList();

                    }

                    if ((list == null || list.Count == 0) && tempToLocId > 0)
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((tempFromLocId == 0 && c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))) || c.OriginId == tempFromLocId)
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                && ((tempFromLocId == 0 && c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode))) || c.DestinationId == tempFromLocId))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();

                    }



                    if ((list == null || list.Count == 0))
                    {
                        list = General.GetQueryable<Fare_ChargesDetail>(c => ((((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(fromHalfPostCode) || c.Gen_Location1.PostCode.Equals(startFromPostCode) || c.Gen_Location1.PostCode.Equals(tempFromPostCode))))
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(toHalfPostCode) || c.Gen_Location.PostCode.Equals(startToPostCode) || c.Gen_Location.PostCode.Equals(tempToPostCode)))))

                                                                || (((c.Gen_Location1.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location1.PostCode.Equals(ToSingleHalfPostCode) || c.Gen_Location1.PostCode.Equals(toHalfPostCode) || c.Gen_Location1.PostCode.Equals(startToPostCode) || c.Gen_Location1.PostCode.Equals(tempToPostCode))))
                                                                && ((c.Gen_Location.LocationTypeId == Enums.LOCATION_TYPES.POSTCODE && (c.Gen_Location.PostCode.Equals(fromSingleHalfPostCode) || c.Gen_Location.PostCode.Equals(fromHalfPostCode) || c.Gen_Location.PostCode.Equals(startFromPostCode) || c.Gen_Location.PostCode.Equals(tempFromPostCode)))))
                                                                   )

                                                              && c.Fare.VehicleTypeId == vehicleTypeId
                                                               // && (c.Fare.CompanyId == companyId || companyId == 0)

                                                               ).ToList();

                    }

                    if (list != null && list.Count > 0)
                    {
                        errorMsg = "Reverse found";

                    }


                }



                //if ((tempFromLocId == 0 && string.IsNullOrEmpty(startFromPostCode)) || (tempToLocId == 0 && string.IsNullOrEmpty(startToPostCode)))
                //    obj = null;


                if (AppVars.objPolicyConfiguration.AddFareCalculationType.ToInt() == 2)
                {
                    tempFromPostCode = fromVal;
                    tempToPostCode = toVal;
                }


                miles = CalculateDistance(tempFromPostCode, tempToPostCode, ref estimatedTime).ToStr();



                milesList.Add(miles.ToDecimal());


                Fare_ChargesDetail obj = null;

                if (list != null)
                {
                    if (companyId != 0)
                    {
                        if (list.Count(c => c.Fare.CompanyId == companyId) > 0)
                        {
                            obj = list.FirstOrDefault(c => c.Fare.CompanyId == companyId);

                            companyFareExist = true;
                        }
                        else
                        {

                            if (General.GetQueryable<Taxi_Model.Fare>(c => c.CompanyId == companyId).Count() == 0)
                            {
                                obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                                companyFareExist = true;

                            }


                        }
                    }
                    else
                    {
                        obj = list.FirstOrDefault(c => c.Fare.CompanyId == null);
                    }

                }


                if (obj != null)
                {

                    rtnFare = obj.Rate.ToDecimal();
                    deadMileage = 0;
                }
                else
                {

                    if (string.IsNullOrEmpty(tempFromPostCode) || string.IsNullOrEmpty(tempToPostCode))
                    {
                        errorMsg = "Error";
                        return 0;
                    }






                    // Calculate Fare Mileage Wise                
                    //  ISingleResult<ClsFares> objFare = General.SP_CalculateFares(vehicleTypeId.ToIntorNull(), companyId.ToIntorNull(), milesList.Sum().ToStr(), pickupTime);
                    decimal totalMiles = milesList.Sum();

                    var objFare = new TaxiDataContext().stp_CalculateGeneralFaresBySubCompany(vehicleTypeId, companyId, totalMiles, pickupTime, subcompanyId);

                    if (objFare != null)
                    {
                        var f = objFare.FirstOrDefault();

                        if ((f.Result == "Success" || f.Result.ToStr().IsNumeric()))
                        {
                            rtnFare = f.totalFares.ToDecimal();

                            companyFareExist = f.CompanyFareExist.ToBool();
                        }
                        else
                            errorMsg = "Error";
                    }
                    else
                        errorMsg = "Error";



                    if (deadMileage > 0)
                    {
                        deadMileage = 0;

                        if (milesList.Count > 1)
                            milesList.RemoveAt(1);

                    }

                    if (AppVars.objPolicyConfiguration.RoundMileageFares.ToBool())
                    {

                     //   decimal startRateTillMiles = General.GetObject<Fleet_VehicleType>(c => c.Id == vehicleTypeId).DefaultIfEmpty().StartRateValidMiles.ToDecimal();
                        if ( totalMiles > 0)
                        {

                            //  rtnFare = Math.Ceiling((rtnFare);
                            rtnFare = Math.Ceiling(rtnFare);
                        }
                    }
                    else
                    {
                        decimal roundUp = AppVars.objPolicyConfiguration.RoundUpTo.ToDecimal();

                        if (roundUp > 0)
                        {

                            rtnFare = (decimal)Math.Ceiling(rtnFare / roundUp) * roundUp;
                        }

                    }

                }

                if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == false)
                {

                    decimal totalSurchargePercentage = surchargeRateFrom + surchargeRateTo;

                    decimal fareSurchargePercent = (rtnFare * totalSurchargePercentage) / 100;
                    rtnFare = rtnFare + fareSurchargePercent;

                }
                else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == true)
                {

                    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                }
                else if (surchargeRateFromAmountWise == true && surchargeRateToAmountWise == false)
                {
                    surchargeRateTo = (rtnFare * surchargeRateTo) / 100;

                    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                }
                else if (surchargeRateFromAmountWise == false && surchargeRateToAmountWise == true)
                {
                    surchargeRateFrom = (rtnFare * surchargeRateFrom) / 100;

                    rtnFare = rtnFare + surchargeRateFrom + surchargeRateTo;
                }



            }
            catch
            {


                //   MessageBox.Show(ex.Message);
            }
            return rtnFare;
        }

        public static void GetZoneName(ref string zoneName, string postCode)
        {

            if (AppVars.objPolicyConfiguration.EnablePDA.ToBool() == false)
                return;

            //   string postCode = General.GetPostCode(postCode);

            Gen_Coordinate objCoord = General.GetObject<Gen_Coordinate>(c => c.PostCode == postCode);

            if (objCoord != null)
            {

                double latitude = 0, longitude = 0;

                latitude = Convert.ToDouble(objCoord.Latitude);
                longitude = Convert.ToDouble(objCoord.Longitude);



                var plot = (from a in General.GetQueryable<Gen_Zone>(c => (c.ShapeType!=null && c.ShapeType=="circle")
                             ||  (c.MinLatitude != null && (latitude >= c.MinLatitude && latitude <= c.MaxLatitude)
                                                   && (longitude <= c.MaxLongitude && longitude >= c.MinLongitude)))

                            select a.Id).ToArray<int>();




                if (plot.Count() > 0)
                {
                    var list = (from p in plot
                                join a in General.GetQueryable<Gen_Zone_PolyVertice>(null) on p equals a.ZoneId
                                select a).ToList();




                    foreach (int plotId in plot)
                    {
                        if (FindPoint(latitude, longitude, list.Where(c => c.ZoneId == plotId).ToList()))
                        {
                            zoneName = list.Where(c => c.ZoneId == plotId).FirstOrDefault().DefaultIfEmpty().Gen_Zone.ZoneName.ToStr();
                            break;

                        }
                    }
                }



            }

        }


        public static bool is_in_circle(double circle_x, double circle_y, double r, double x, double y)
        {

            double d = new LatLng(Convert.ToDouble(circle_x), Convert.ToDouble(circle_y)).DistanceMiles(new LatLng(Convert.ToDouble(x), Convert.ToDouble(y)));

            //double d = Math.Sqrt(((circle_x - x) * (circle_x - x)) + ((circle_y - y) * (circle_y - y)));
            return d <= r;
        }

        public static bool FindPoint(double pointLat, double pointLng, List<Gen_Zone_PolyVertice> PontosPolig)
        {//                             X               y               
            int sides = PontosPolig.Count();
            int j = sides - 1;
            bool pointStatus = false;


            if (sides == 1)
            {

                double radius = Convert.ToDouble(PontosPolig[0].Diameter) / 2;
                double lat = Convert.ToDouble(PontosPolig[0].Latitude);
                double lng = Convert.ToDouble(PontosPolig[0].Longitude);
               
                pointStatus = is_in_circle(pointLat, pointLng, radius, lat, lng);
               
            }
            else
            {

                for (int i = 0; i < sides; i++)
                {
                    if (PontosPolig[i].Longitude < pointLng && PontosPolig[j].Longitude >= pointLng ||
                        PontosPolig[j].Longitude < pointLng && PontosPolig[i].Longitude >= pointLng)
                    {
                        if (PontosPolig[i].Latitude + (pointLng - PontosPolig[i].Longitude) /
                            (PontosPolig[j].Longitude - PontosPolig[i].Longitude) * (PontosPolig[j].Latitude - PontosPolig[i].Latitude) < pointLat)
                        {
                            pointStatus = !pointStatus;
                        }
                    }
                    j = i;
                }
            }
            return pointStatus;
        }



        public static string directionKey = string.Empty;

        public static decimal CalculateDistance(string origin, string destination)
        {

            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return 0.00m;

            decimal miles = 0.00m;


            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();



            if ((LastCalcDestination.Length > 0 && LastCalcDestination.Length > 0
              && origin == LastCalcOrigin && destination == LastCalcDestination) && LastCalcMileage > 0)
            {


                miles = LastCalcMileage;

                return miles;

            }


            try
            {

                stp_getCoordinatesByAddressResult pickupCoord = null;
                stp_getCoordinatesByAddressResult destCoord = null;
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    pickupCoord = GetCoordinatesByAddress(origin, GetPostCodeMatch(origin), db);
                    destCoord = GetCoordinatesByAddress(destination, GetPostCodeMatch(destination), db);

                }
                    //using (TaxiDataContext db = new TaxiDataContext())
                    //{

                    //    pickupCoord = db.stp_getCoordinatesByAddress(origin, GetPostCodeMatch(origin)).FirstOrDefault();
                    //    destCoord = db.stp_getCoordinatesByAddress(destination, GetPostCodeMatch(destination)).FirstOrDefault();

                    //}


                    string originString = string.Empty;
                string destString = string.Empty;
                if (pickupCoord != null && pickupCoord.Latitude != null && pickupCoord.Latitude != 0)
                {
                    originString = pickupCoord.Latitude + "," + pickupCoord.Longtiude;
                }

                if (destCoord != null && destCoord.Latitude != null && destCoord.Latitude != 0)
                {
                    destString = destCoord.Latitude + "," + destCoord.Longtiude;


                }




                bool exist = false;



           

                // offlinedistance
                if (AppVars.objPolicyConfiguration.EnableOfflineDistance.ToBool() && exist == false)
                {
                    string time = string.Empty;
                    miles = AppVars.frmMDI.GetDistanceAndTime(origin, destination, ref time);
                    exist = true;
                    LastCalcOrigin = origin;
                    LastCalcDestination = destination;
                    LastCalcMileage = miles;
                    LastCalEstTime = time;

                }
              
                if (exist == false)
                {
                   

                    if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                    {

                    }
                    else if (originString.Length > 0)
                    {
                        origin = originString;

                    }
                    else
                    {
                        origin += ", UK";
                    }


                    if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                    {


                    }
                    else if (destString.Length > 0)
                    {

                        destination = destString;
                    }
                    else
                    {
                        destination += ", UK";
                    }


                    if (string.IsNullOrEmpty(directionKey))
                    {
                        using (TaxiDataContext db = new TaxiDataContext())
                        {

                            directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                            if (directionKey.Length == 0)
                                directionKey = " ";
                            else
                                directionKey = "&key=" + directionKey;
                        }

                    }


                   

                    if (AppVars.objPolicyConfiguration.MapType == 2)
                    {
                        ClsHereMap c = new ClsHereMap();
                        c.StartingPoint = origin;
                        c.EndingPoint = destination;
                        //  c.ViaString = via;
                        var resp = c.GenerateRoute(false);
                        string coordinates = string.Empty;
                        coordinates = resp.Coordinates;
                        miles = resp.Distance;



                    }
                    else
                    {

                        string alternatives = AppVars.objPolicyConfiguration.PreferredShortestDistance.ToBool() ? "&alternatives=true" : "";

                        string URL = "";


                        URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}" + alternatives + "&units=imperial" + directionKey + "&sensor=false";
                        URL = string.Format(URL, origin, destination);



                        try
                        {
                            WebRequest request = HttpWebRequest.Create(URL);

                            request.Headers.Add("Authorization", "");
                            System.Net.WebRequest.DefaultWebProxy = null;
                            request.Proxy = System.Net.WebRequest.DefaultWebProxy;



                            WebResponse response = request.GetResponse();
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                                string responseStringData = reader.ReadToEnd();
                                RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                                if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                                {

                                    var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                    if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                                    }
                                    else
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                    }



                                    //if (AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal() > 0)
                                    //{

                                    //    miles = Math.Ceiling(miles / AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal()) * AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal();

                                    //}


                                    //  miles = objShortest.legs[0].distance.value;
                                    LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                    LastCalcDestination = destination.Replace(", UK", "").Trim();
                                    LastCalcMileage = miles;
                                    LastCalEstTime = string.Empty;


                                }
                            }
                        }
                        catch
                        {



                        }


                    }
                  


                  
                }

                // }

            }
            catch
            {



            }

            return miles;
        }


        public static string GetHereApiFormattedUrl(string url, int keyIndex = 0)
        {
            try
            {

                if (AppVars.etaKey.ToStr().Trim().Length > 0 && AppVars.etaKey.ToStr().Where(c => (c == ',')).Count() == 2)
                {

                    if (keyIndex == 0)
                    {
                        return string.Format(url, AppVars.etaKey.Split(new char[] { ',' })[0], AppVars.etaKey.Split(new char[] { ',' })[1]);
                    }
                    else
                        return string.Format(url, AppVars.etaKey.Split(new char[] { ',' })[2]);



                }
                else
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        if (db.ExecuteQuery<long>("select len(APIKey)- len(replace(APIKey,',','')) from MapKeys where MapType='here'").FirstOrDefault() == 2)
                        {
                            AppVars.etaKey = db.ExecuteQuery<string>("select apikey from MapKeys where MapType='here'").FirstOrDefault();

                            if (keyIndex == 0)
                            {
                                return string.Format(url, AppVars.etaKey.Split(new char[] { ',' })[0], AppVars.etaKey.Split(new char[] { ',' })[1]);
                            }
                            else
                                return string.Format(url, AppVars.etaKey.Split(new char[] { ',' })[2]);
                       //     return AppVars.etaKey.Split(new char[] { ',' })[2];

                        }
                        else
                            return url;
                    }
                }
            }
            catch
            {
                return url;
            }

        }


        public static void GetETAKey()
        {
            try
            {

                if (AppVars.etaKey.ToStr().Trim().Length == 0)
                {

                    using (TaxiDataContext db = new TaxiDataContext())
                    {

                        AppVars.etaKey = db.ExecuteQuery<string>("select apikey from MapKeys where MapType='here'").FirstOrDefault();




                    }
                }
            }
            catch
            {
             
            }

        }

        public static decimal CalculateDistance(string origin, string destination, ref string estimatedTime, bool isVia)
        {

            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return 0.00m;



            decimal miles = 0.00m;

            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();


            if ((LastCalcDestination.Length > 0 && LastCalcDestination.Length > 0
                && origin == LastCalcOrigin && destination == LastCalcDestination) && LastCalcMileage > 0)
            {


                miles = LastCalcMileage;

                estimatedTime = LastCalEstTime;

                return miles;

            }


            try
            {
                bool exist = false;



                //if (File.Exists(@Application.StartupPath + "\\PostCodeDistance\\" + origin + "_" + destination + ".csv"))
                //{
                //    try
                //    {
                //        string val = File.ReadAllText(@Application.StartupPath + "\\PostCodeDistance\\" + origin + "_" + destination + ".csv").ToStr();

                //        if (val.Contains(","))
                //        {
                //            string[] arr = val.Split(',');

                //            if (arr.Count() == 1)
                //            {
                //                miles = arr[0].ToDecimal();

                //            }
                //            else if (arr.Count() > 1)
                //            {
                //                miles = arr[0].ToDecimal();
                //                estimatedTime += arr[1].ToStr() + " mins";
                //            }

                //            exist = true;
                //        }
                //    }
                //    catch
                //    {


                //    }


                //}

                // offlinedistance
                if (AppVars.objPolicyConfiguration.EnableOfflineDistance.ToBool() && exist == false)
                {

                    miles = AppVars.frmMDI.GetDistanceAndTime(origin, destination, ref estimatedTime);
                    exist = true;
                    LastCalcOrigin = origin;
                    LastCalcDestination = destination;
                    LastCalcMileage = miles;
                    LastCalEstTime = estimatedTime;
                }





                if (exist == false)
                {


                    if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                    {

                    }
                    else
                    {
                        origin += ", UK";
                    }


                    if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                    {


                    }
                    else
                    {
                        destination += ", UK";
                    }

                    //origin += ", UK";
                    //destination += ", UK";


                    if (AppVars.objPolicyConfiguration.MapType == 2)
                    {
                        ClsHereMap c = new ClsHereMap();
                        c.StartingPoint = origin;
                        c.EndingPoint = destination;
                        //  c.ViaString = via;
                        var resp = c.GenerateRoute(false);
                        string coordinates = string.Empty;
                        coordinates = resp.Coordinates;
                        miles = resp.Distance;



                    }
                    else
                    {

                        if (string.IsNullOrEmpty(directionKey))
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                                if (directionKey.Length == 0)
                                    directionKey = " ";
                                else
                                    directionKey = "&key=" + directionKey;
                            }
                        }

                        string useAlternatives = isVia ? "" : "alternatives=true";


                        if (AppVars.objPolicyConfiguration.PreferredShortestDistance.ToBool() == false)
                            useAlternatives = "";


                        string URL = "";

                        URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}" + useAlternatives + "&units=imperial" + directionKey + "&sensor=false";
                        URL = string.Format(URL, origin, destination);

                        WebRequest request = HttpWebRequest.Create(URL);

                        request.Headers.Add("Authorization", "");
                        System.Net.WebRequest.DefaultWebProxy = null;
                        request.Proxy = System.Net.WebRequest.DefaultWebProxy;



                        WebResponse response = request.GetResponse();
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                            RootObject responseData = parser.Deserialize<RootObject>(reader.ReadToEnd());
                            if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                            {

                                var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                                {
                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                                }
                                else
                                {
                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                }

                                //if (AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal() > 0)
                                //{

                                //    miles = Math.Ceiling(miles / AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal()) * AppVars.objPolicyConfiguration.RoundJourneyMiles.ToDecimal();

                                //}

                                estimatedTime += (objShortest.legs[0].duration.value / 60) + " mins";

                                //  miles = objShortest.legs[0].distance.value;
                                LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                LastCalcDestination = destination.Replace(", UK", "").Trim();
                                LastCalcMileage = miles;
                                LastCalEstTime = string.Empty;

                                exist = true;
                            }
                        }


                        if (exist == false && miles == 0)
                        {
                            Thread.Sleep(500);
                            response = HttpWebRequest.Create(URL).GetResponse();
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                                RootObject responseData = parser.Deserialize<RootObject>(reader.ReadToEnd());
                                if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                                {

                                    var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                    estimatedTime += (objShortest.legs[0].duration.value / 60) + " mins";

                                    //  miles = objShortest.legs[0].distance.value;
                                    LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                    LastCalcDestination = destination.Replace(", UK", "").Trim();
                                    LastCalcMileage = miles;
                                    LastCalEstTime = string.Empty;

                                    exist = true;
                                }
                            }

                        }




                    }

                }



              

               
            }
            catch
            {



            }

            return miles;
        }

      


        public static decimal CalculateDistance(string origin, string destination, ref string estimatedTime)
        {

            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return 0.00m;



            decimal miles = 0.00m;

            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();


            if ((LastCalcDestination.Length > 0 && LastCalcDestination.Length > 0
                && origin == LastCalcOrigin && destination == LastCalcDestination) && LastCalcMileage > 0)
            {


                miles = LastCalcMileage;

                estimatedTime = LastCalEstTime;

                return miles;

            }


            try
            {
                bool exist = false;



                //if (File.Exists(@Application.StartupPath + "\\PostCodeDistance\\" + origin + "_" + destination + ".csv"))
                //{
                //    try
                //    {
                //        string val = File.ReadAllText(@Application.StartupPath + "\\PostCodeDistance\\" + origin + "_" + destination + ".csv").ToStr();

                //        if (val.Contains(","))
                //        {
                //            string[] arr = val.Split(',');

                //            if (arr.Count() == 1)
                //            {
                //                miles = arr[0].ToDecimal();

                //            }
                //            else if (arr.Count() > 1)
                //            {
                //                miles = arr[0].ToDecimal();
                //                estimatedTime += arr[1].ToStr() + " mins";
                //            }

                //            exist = true;
                //        }
                //    }
                //    catch
                //    {


                //    }


                //}

                // offlinedistance
                if (AppVars.objPolicyConfiguration.EnableOfflineDistance.ToBool() && exist == false)
                {

                    miles = AppVars.frmMDI.GetDistanceAndTime(origin, destination, ref estimatedTime);
                    exist = true;
                    LastCalcOrigin = origin;
                    LastCalcDestination = destination;
                    LastCalcMileage = miles;
                    LastCalEstTime = estimatedTime;
                }
               

                if (exist == false)
                {
                    if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                    {

                    }
                    else
                    {
                        origin += ", UK";
                    }


                    if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                    {


                    }
                    else
                    {
                        destination += ", UK";
                    }


                    if (AppVars.objPolicyConfiguration.MapType == 2)
                    {
                        ClsHereMap c = new ClsHereMap();
                        c.StartingPoint = origin;
                        c.EndingPoint = destination;
                        //  c.ViaString = via;
                        var resp = c.GenerateRoute(false);
                        string coordinates = string.Empty;
                        coordinates = resp.Coordinates;
                        miles = resp.Distance;



                    }
                    else
                    {

                        if (string.IsNullOrEmpty(directionKey))
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                                if (directionKey.Length == 0)
                                    directionKey = " ";
                                else
                                    directionKey = "&key=" + directionKey;
                            }

                        }


                        string alternatives = AppVars.objPolicyConfiguration.PreferredShortestDistance.ToBool() ? "&alternatives=true" : "";




                        string URL = "";

                        URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}" + alternatives + "&units=imperial" + directionKey + "&sensor=false";
                        URL = string.Format(URL, origin, destination);



                        WebRequest request = HttpWebRequest.Create(URL);

                        request.Headers.Add("Authorization", "");
                        System.Net.WebRequest.DefaultWebProxy = null;
                        request.Proxy = System.Net.WebRequest.DefaultWebProxy;

                        WebResponse response = request.GetResponse();
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                            RootObject responseData = parser.Deserialize<RootObject>(reader.ReadToEnd());
                            if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                            {

                                // https://geocoder.ls.hereapi.com/6.2/geocode.json?apiKey=avsHjHri-tP5Su5wV7xyPBWwmdqOtEKK2Atn0xgDnrM&searchtext=12%20%20HIGHCLERE%20ASCOT%20SL5%200AA

                                var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                                {
                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                                }
                                else
                                {
                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                }




                                estimatedTime += (objShortest.legs[0].duration.value / 60) + " mins";

                                //  miles = objShortest.legs[0].distance.value;
                                LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                LastCalcDestination = destination.Replace(", UK", "").Trim();
                                LastCalcMileage = miles;
                                LastCalEstTime = string.Empty;

                                exist = true;
                            }
                        }


                        if (exist == false && miles == 0)
                        {
                            Thread.Sleep(500);
                            response = HttpWebRequest.Create(URL).GetResponse();
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                                RootObject responseData = parser.Deserialize<RootObject>(reader.ReadToEnd());
                                if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                                {

                                    var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                    miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                    estimatedTime += (objShortest.legs[0].duration.value / 60) + " mins";

                                    //  miles = objShortest.legs[0].distance.value;
                                    LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                    LastCalcDestination = destination.Replace(", UK", "").Trim();
                                    LastCalcMileage = miles;
                                    LastCalEstTime = string.Empty;

                                    exist = true;
                                }
                            }

                        }



                    }

                  

                }



               
            }
            catch
            {



            }

            return miles;
        }



        public static decimal CalculateDistanceByIncludingVia(string origin, string destination, string[] viaList)
        {

            //  objShortest=null

            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return 0.00m;

            decimal miles = 0.00m;


            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();






            try
            {

                stp_getCoordinatesByAddressResult pickupCoord = null;
                stp_getCoordinatesByAddressResult destCoord = null;

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    pickupCoord = General.GetCoordinatesByAddress(origin, GetPostCodeMatch(origin),db);
                    destCoord = General.GetCoordinatesByAddress(destination, GetPostCodeMatch(destination),db);
                //    if (pickupCoord==null)
                //    pickupCoord = db.stp_getCoordinatesByAddress(origin, GetPostCodeMatch(origin)).FirstOrDefault();
                //    destCoord = db.stp_getCoordinatesByAddress(destination, GetPostCodeMatch(destination)).FirstOrDefault();

                }


                string originString = string.Empty;
                string destString = string.Empty;
                if (pickupCoord != null && pickupCoord.Latitude != null && pickupCoord.Latitude != 0)
                {
                    originString = pickupCoord.Latitude + "," + pickupCoord.Longtiude;
                }

                if (destCoord != null && destCoord.Latitude != null && destCoord.Latitude != 0)
                {
                    destString = destCoord.Latitude + "," + destCoord.Longtiude;


                }

                bool exist = false;

                if (exist == false)
                {


                    if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                    {

                    }
                    else if (originString.Length > 0)
                    {
                        origin = originString;

                    }
                    else
                    {
                        origin += ", UK";
                    }


                    if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                    {


                    }
                    else if (destString.Length > 0)
                    {

                        destination = destString;
                    }
                    else
                    {
                        destination += ", UK";
                    }


                    if (AppVars.objPolicyConfiguration.MapType == 2)
                    {
                        ClsHereMap c = new ClsHereMap();
                        c.StartingPoint = origin;
                        c.EndingPoint = destination;
                         
                        if(viaList!=null && viaList.Count()>0)
                        {
                            string via = string.Empty;
                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                foreach (var item in viaList)
                                {
                                    var a = General.GetCoordinatesByAddress(item, General.GetPostCodeMatch(item), db);
                                    //  db.stp_getCoordinatesByAddress(item, General.GetPostCodeMatch(item)).FirstOrDefault();

                                    if (a != null)
                                    {
                                        via += a.Latitude + "," + a.Longtiude + "|";


                                    }
                                    else
                                    {
                                        var post = General.GetPostCodeMatch(item);

                                        if (post.Length > 0)
                                            via += post + "|";
                                        else
                                            via += item + "|";
                                    }
                                }

                            }

                            if (via.EndsWith("|"))
                                via = via.TrimEnd('|');


                            c.ViaString = via;

                        }

                        var resp = c.GenerateRoute(false);
                        string coordinates = string.Empty;
                        coordinates = resp.Coordinates;
                        miles = resp.Distance;



                    }
                    else
                    {


                        if (string.IsNullOrEmpty(directionKey))
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                                if (directionKey.Length == 0)
                                    directionKey = " ";
                                else
                                    directionKey = "&key=" + directionKey;
                            }

                        }



                        string URL = "";

                        string via = string.Empty;
                        if (viaList != null && viaList.Count() > 0)
                        {




                            using (TaxiDataContext db = new TaxiDataContext())
                            {
                                foreach (var item in viaList)
                                {
                                    var a = General.GetCoordinatesByAddress(item, General.GetPostCodeMatch(item), db);
                                    //  db.stp_getCoordinatesByAddress(item, General.GetPostCodeMatch(item)).FirstOrDefault();

                                    if (a != null)
                                    {
                                        via += a.Latitude + "," + a.Longtiude + "|";


                                    }
                                    else
                                    {
                                        var post = General.GetPostCodeMatch(item);

                                        if (post.Length > 0)
                                            via += post + "|";
                                        else
                                            via += item + "|";
                                    }
                                }

                            }

                            if (via.EndsWith("|"))
                                via = via.TrimEnd('|');

                            if (via.Length > 0)
                            {

                                URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&waypoints={2}&alternatives=true&units=imperial" + directionKey + "&sensor=false";
                                URL = string.Format(URL, origin, destination, via);

                            }
                            else
                            {

                                URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&alternatives=true&units=imperial" + directionKey + "&sensor=false";
                                URL = string.Format(URL, origin, destination);
                            }
                        }
                        else
                        {
                            URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&alternatives=true&units=imperial" + directionKey + "&sensor=false";
                            URL = string.Format(URL, origin, destination);
                        }


                        try
                        {
                            string coordinates = string.Empty;





                            WebRequest request = HttpWebRequest.Create(URL);

                            request.Headers.Add("Authorization", "");
                            System.Net.WebRequest.DefaultWebProxy = null;
                            request.Proxy = System.Net.WebRequest.DefaultWebProxy;


                            System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();

                            WebResponse response = request.GetResponse();
                            string responseStringData = string.Empty;
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {

                                responseStringData = reader.ReadToEnd();



                            }


                            RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                            if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                            {

                                var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();


                                if (objShortest.legs.Count > 0)
                                {
                                    foreach (var leg in objShortest.legs)
                                    {
                                        if (leg.distance.text.ToStr().EndsWith(" mi"))
                                        {
                                            miles += Math.Round(Convert.ToDecimal((Convert.ToDouble((leg.distance.text.Replace(" mi", "").Trim())))), 1);

                                        }
                                        else
                                        {
                                            miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((leg.distance.value)) / 1609.344)), 1);
                                        }
                                    }

                                    //foreach (var leg in objShortest.legs)
                                    //{
                                    //    if (leg.distance.text.ToStr().EndsWith(" mi"))
                                    //    {
                                    //        miles += Convert.ToDecimal(leg.distance.value);

                                    //    }
                                    //    else
                                    //    {
                                    //        miles += Convert.ToDecimal(leg.distance.value);
                                    //    }
                                    //}

                                    //miles = (Convert.ToDouble( miles) * 0.00062137).ToDecimal();
                                    //if (miles < 0.1m)
                                    //    miles = Convert.ToDecimal(Math.Round((miles), 2));
                                    //else
                                    //    miles = Convert.ToDecimal(Math.Round((miles), 1));

                                }
                                else
                                {


                                    if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                                    }
                                    else
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                    }
                                }


                            }
                            
                        }
                        catch
                        {



                        }

                    }





                }



            }
            catch
            {



            }

            return miles;
        }


        public static string BingKey = string.Empty;
        public static string LastCalcOrigin = string.Empty;
        public static string LastCalcDestination = string.Empty;
        public static decimal LastCalcMileage = 0.00m;
        public static string LastCalEstTime = string.Empty;




        public static string CalculateEstimatedTime(string origin, string destination, string via)
        {
            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();

            string time = string.Empty;

            string url2 = "http://maps.googleapis.com/maps/api/directions/xml?origin=" + origin + ", UK&destination=" + destination + ", UK" + via + "&sensor=false";

          //  string url2 = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&mode=driving&units=imperial";


            using (System.Data.DataSet ds = new System.Data.DataSet())
            {
                using (XmlTextReader reader = new XmlTextReader(url2))
                {

                    ds.ReadXml(reader);
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() == "ZERO_RESULTS" || ds.Tables[0].Rows[0]["status"].ToString() == "INVALID_REQUEST" || ds.Tables[0].Rows[0]["status"].ToString() == "NOT_FOUND")
                {

                    return string.Empty;
                }
                else
                {


                    if (string.IsNullOrEmpty(via))
                    {
                        DataTable dt = ds.Tables["duration"];
                        DataRow row = dt.Rows.OfType<DataRow>().LastOrDefault();
                        time = row.ItemArray[1].ToString();
                        dt.Dispose();
                        dt = null;
                    }
                    //else
                    //{
                    //    var rows = ds.Tables["duration"].Rows.OfType<DataRow>().Where(c => c[2].ToStr() == string.Empty);

                    //    time = (Math.Round((rows.Sum(c => Convert.ToDouble(c[0])) / 60), 0)).ToStr();
                    //    time += " mins";
                    //}
                }
            }


            return time;
        }

        public static string CalculateEstimatedTime(string origin, string destination,ref string locationName)
        {
            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();

            string time = string.Empty;

            string URL = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin +"&destination=" + destination + "&key="+AppVars.googleKey+ "&sensor=false";

            //  string url2 = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&mode=driving&units=imperial";


            //using (System.Data.DataSet ds = new System.Data.DataSet())
            //{
            //    using (XmlTextReader reader = new XmlTextReader(url2))
            //    {

            //        ds.ReadXml(reader);
            //    }
            //    if (ds.Tables[0].Rows[0]["status"].ToString() == "ZERO_RESULTS" || ds.Tables[0].Rows[0]["status"].ToString() == "INVALID_REQUEST" || ds.Tables[0].Rows[0]["status"].ToString() == "NOT_FOUND")
            //    {

            //        return string.Empty;
            //    }
            //    else
            //    {



            //            DataTable dt = ds.Tables["duration"];
            //            DataRow row = dt.Rows.OfType<DataRow>().LastOrDefault();
            //            time = row.ItemArray[1].ToString();
            //            dt.Dispose();
            //            dt = null;

            //        //else
            //        //{
            //        //    var rows = ds.Tables["duration"].Rows.OfType<DataRow>().Where(c => c[2].ToStr() == string.Empty);

            //        //    time = (Math.Round((rows.Sum(c => Convert.ToDouble(c[0])) / 60), 0)).ToStr();
            //        //    time += " mins";
            //        //}
            //    }
            //}

            try
            {
                WebRequest request = HttpWebRequest.Create(URL);

                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;



                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string responseStringData = reader.ReadToEnd();
                    RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                    if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                    {

                        var objShortest = responseData.routes.OrderBy(x => x.legs[0].duration.value).FirstOrDefault();

                       

                    }
                }
            }
            catch
            {



            }


            return time;
        }


        public static IList GetStationsList()
        {

            var list = (from a in General.GetQueryable<Gen_Location>(null)
                        where a.LocationTypeId == Enums.LOCATION_TYPES.UNDERGROUNDSTATION
                        orderby a.LocationName
                        select new
                        {
                            Id = a.Id,
                            Location = a.LocationName

                        }).ToList();

            return list;

        }

        public static IList GetAirportsList()
        {

            var list = (from a in General.GetQueryable<Gen_Location>(null)
                        where a.LocationTypeId == Enums.LOCATION_TYPES.AIRPORT
                        orderby a.LocationName
                        select new
                        {
                            Id = a.Id,
                            Location = a.LocationName

                        }).ToList();

            return list;



        }


        public static List<Gen_ServiceCharge> GetServiceChargesList()
        {

           return General.GetQueryable<Gen_ServiceCharge>(null).ToList();
                      

          



        }



        public static void AddCheckBoxColumn(string name, RadGridView grid)
        {
            GridViewCheckBoxColumn col = new GridViewCheckBoxColumn();
            col.Width = 40;
            col.HeaderText = "";
            col.Name = name;
            grid.Columns.Add(col);

        }



        public static string CheckIfSpecialPostCode(string postcode)
        {
            try
            {

                if (((postcode.StartsWith("EC") || postcode.StartsWith("WC") || postcode.StartsWith("SE1") ||
                          postcode.StartsWith("SW1")) && postcode.Length == 4) || postcode.StartsWith("W1") && postcode.Length == 3)
                {

                    if (char.IsLetter(postcode[postcode.Length - 1]))
                    {
                        postcode = postcode.Remove(postcode.Length - 1);
                    }
                }
            }
            catch
            {


            }

            return postcode;

        }



        public static void ReCallBookingFromOnBoardGrid(long jobId, int driverId, bool toRefreshAllPC = false)
        {

            try
            {
             

                General.ReCallBookingWithStatus(jobId.ToLong(), driverId.ToInt(), Enums.BOOKINGSTATUS.WAITING, Enums.Driver_WORKINGSTATUS.AVAILABLE, Enums.BOOKINGSTATUS.NOSHOW);
              
                General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_ACTIVEBOOKINGS_DASHBOARD + "=" + jobId + "=syncdrivers");
               
              
            }
            catch 
            {

               



            }

        }














        public static bool ReCallBooking(long jobId, int driverId,bool toAllRefresh=false)
        {

            try
            {

                bool rtn = true;



                General.ReCallBookingWithStatus(jobId.ToLong(), driverId.ToInt(), Enums.BOOKINGSTATUS.WAITING, Enums.Driver_WORKINGSTATUS.AVAILABLE,Enums.BOOKINGSTATUS.NOSHOW);

                General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_ACTIVEBOOKINGS_DASHBOARD + "=" + jobId + "=syncdrivers");


                //if (toAllRefresh == false)
                //    (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard") as frmBookingDashBoard).RefreshData();
                //else
                //    General.SendMessageToPDA("request broadcast=" + RefreshTypes.REFRESH_REQUIRED_DASHBOARD + "=" + jobId);

                if (Application.OpenForms.OfType<Form>().Count(c => c.Name == "frmBookingsList") > 0)
                {
                    (Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingsList") as frmBookingsList).SetRefreshWhenActive("");
                }
                return rtn;
            }
            catch (Exception ex)
            {

                return false;
               


            }

        }

   


        public static void FreezeTopRank(long jobId, int driverId, int? bookingStatusId, int? driverStatusId)
        {
            try
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                    db.ExecuteQuery<int>("exec stp_UpdateJobEnd {0},{1},{2},{3},{4},{5},{6}", jobId, driverId, bookingStatusId.ToIntorNull(), driverStatusId.ToIntorNull(), -1, "", "-1");
                }

            }
            catch
            {

            }


        }


        public static void ReCallBookingWithStatus(long jobId, int driverId,int? bookingStatusId,int? driverStatusId,int? recoverJob=null)
        {

            try
            {



              //  bool rtn = true;

                int rankChanged = 0;

                if (AppVars.objPolicyConfiguration.EnableBookingOtherCharges.ToBool()
                    && (bookingStatusId == Enums.BOOKINGSTATUS.NOPICKUP || bookingStatusId == Enums.BOOKINGSTATUS.CANCELLED || recoverJob.ToInt()==Enums.BOOKINGSTATUS.NOSHOW))
                {

                    FreezeTopRank(jobId, driverId, bookingStatusId.ToIntorNull(), driverStatusId.ToIntorNull());
                    rankChanged = 1;
                }
                else
                {
                    (new TaxiDataContext()).stp_UpdateJob(jobId, driverId, bookingStatusId, driverStatusId, AppVars.objPolicyConfiguration.SinBinTimer.ToInt());
                }



                General.SendMessageToPDA("request pda=" + driverId + "=" + jobId + "=Cancelled Job>>" + jobId + "=2=" + rankChanged);
                    


                if (AppVars.objPolicyConfiguration.DespatchOfflineJobs.ToBool())
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.stp_SaveOfflineMessage(jobId, driverId, "", AppVars.LoginObj.LoginName.ToStr(), "Cancelled Job>>" + jobId + "=2");
                    }

                }

            
            }
            catch (Exception ex)
            {

              //  return false;
              

            }

        }



        public static bool ReCallDespatchBooking(long jobId, int driverId)
        {

            try
            {

                bool rtn = true;

                using (TaxiDataContext db = new TaxiDataContext())
                {

                    db.stp_RunProcedure("update fleet_driverqueuelist set currentjobid=null,driverworkstatusid=1 where driverid=" + driverId);


                }
                

                if (AppVars.objPolicyConfiguration.MapType.ToInt() == 1)
                {

                    //For TCP Connection
                    if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                    {

                        rtn = General.SendMessageToPDA("request pda=" + driverId + "=" + jobId + "=Cancelled Job>>" + jobId + "=2").Result.ToBool();
                    }


                }
                else
                {

                    //For TCP Connection
                    if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                    {

                        rtn = General.SendMessageToPDA("request pda=" + driverId + "=" + jobId + "=Cancelled Job>>" + jobId + "=2").Result.ToBool();
                    }

                }


               

                return rtn;
            }
            catch (Exception ex)
            {

                return false;
                //   ENUtils.ShowMessage(ex.Message);


            }

        }


   
        public static void ShowCompanyInvoiceForm(long id)
        {


            frmInvoice frm = new frmInvoice();
            frm.OnDisplayRecord(id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmInvoice1");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);

        }


        public static void ShowEscortInvoiceForm(long id)
        {


            frmEscortInvoice frm = new frmEscortInvoice();
            frm.OnDisplayRecord(id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmEscortInvoice1");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);

        }


     


        public static void ShowPreCompanyInvoiceForm(long id)
        {


            frmPreAccInvoice frm = new frmPreAccInvoice();
            frm.OnDisplayRecord(id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmPreAccInvoice1");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);

        }

        public static void ShowCustomerInvoiceForm(long id)
        {


            frmCustomerInvoice frm = new frmCustomerInvoice();
            frm.OnDisplayRecord(id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmCustomerInvoice1");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);

        }




        public static void ShowPreCustomerInvoiceForm(long id)
        {


            frmPreCustomerInvoice frm = new frmPreCustomerInvoice();
            frm.OnDisplayRecord(id);


            DockWindow doc = UI.MainMenuForm.MainMenuFrm.GetDockByName("frmPreCustomerInvoice1");

            if (doc != null)
            {
                doc.Close();
            }

            MainMenuForm.MainMenuFrm.ShowForm(frm);

        }




        public static void DisposeForm(Form frm)
        {

            frm.Dispose();

        }


        public static bool SendAdvanceBookingSMS(string toNumber, ref string returnMsg, string advanceText,int smsType)
        {
            bool rtn = true;

            try
            {
                if (string.IsNullOrEmpty(toNumber)) return false;


                string companyName = AppVars.objSubCompany.CompanyName.ToStr().Trim();
                string companyTelNo = AppVars.objSubCompany.TelephoneNo.ToStr().Trim();

                string text = advanceText.ToStr();


                if (string.IsNullOrEmpty(text))
                {
                    returnMsg = "* Advance Booking Text not exist in System Policy.";

                }
                else
                {
                    int idx = -1;
                    if (toNumber.StartsWith("044") == true)
                    {
                        idx = toNumber.IndexOf("044");
                        toNumber = toNumber.Substring(idx + 3);
                        toNumber = toNumber.Insert(0, "+44");


                    }

                    if (toNumber.StartsWith("07"))
                    {
                        toNumber = toNumber.Substring(1);
                    }

                    if (toNumber.StartsWith("0440") == false || toNumber.StartsWith("+440") == false)
                        toNumber = toNumber.Insert(0, "+44");



                    string message = string.Empty;

                    // Send To Customer
                    Thread thread= new Thread(delegate ()
                    {
                        rtn = SendAdvanceSMS(toNumber, text, smsType);
                    });

                    thread.Priority = ThreadPriority.Lowest;
                    thread.Start();




                }


                if (AppVars.objPolicyConfiguration.DisablePopupNotifications.ToBool() == false)
                {

                    RadDesktopAlert advanceBookingText = new RadDesktopAlert();


                    if (rtn == false)
                    {
                        advanceBookingText.CaptionText = "Advance Booking Confirmation Text Send Failed...";

                        advanceBookingText.ContentText = returnMsg.Insert(0, "* ");
                    }
                    else
                    {
                        advanceBookingText.CaptionText = "Advance Booking Confirmation Text.";
                        advanceBookingText.ContentText = "Confirmation Text has been Sent Successfully ";
                    }

                    advanceBookingText.Show();
                }
                return rtn;

            }
            catch (Exception ex)
            {
                return false;

            }
        }



        //public static bool SendAdvanceBookingSMS(string toNumber, ref string returnMsg, string advanceText)
        //{
        //    bool rtn = true;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(toNumber)) return false;


        //        string companyName = AppVars.objSubCompany.CompanyName.ToStr().Trim();
        //        string companyTelNo = AppVars.objSubCompany.TelephoneNo.ToStr().Trim();

        //        string text = advanceText.ToStr();


        //        if (string.IsNullOrEmpty(text))
        //        {
        //            returnMsg = "* Advance Booking Text not exist in System Policy.";

        //        }
        //        else
        //        {
        //            int idx = -1;
        //            if (toNumber.StartsWith("044") == true)
        //            {
        //                idx = toNumber.IndexOf("044");
        //                toNumber = toNumber.Substring(idx + 3);
        //                toNumber = toNumber.Insert(0, "+44");


        //            }

        //            if (toNumber.StartsWith("07"))
        //            {
        //                toNumber = toNumber.Substring(1);
        //            }

        //            if (toNumber.StartsWith("0440") == false || toNumber.StartsWith("+440") == false)
        //                toNumber = toNumber.Insert(0, "+44");



        //            string message = string.Empty;

        //            // Send To Customer
        //            Thread thread = new Thread(delegate()
        //            {
        //                rtn = SendAdvanceSMS(toNumber, text);
        //            });

        //            thread.Priority = ThreadPriority.Lowest;
        //            thread.Start();




        //        }


        //        RadDesktopAlert advanceBookingText = new RadDesktopAlert();


        //        if (rtn == false)
        //        {
        //            advanceBookingText.CaptionText = "Advance Booking Confirmation Text Send Failed...";

        //            advanceBookingText.ContentText = returnMsg.Insert(0, "* ");
        //        }
        //        else
        //        {
        //            advanceBookingText.CaptionText = "Advance Booking Confirmation Text.";
        //            advanceBookingText.ContentText = "Confirmation Text has been Sent Successfully ";
        //        }

        //        advanceBookingText.Show();

        //        return rtn;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;

        //    }
        //}


        public static bool SendAdvanceSMS(string mobileNo, string message,int smsType)
        {
            System.Threading.Thread.Sleep(1000);
            EuroSMS objSMS = new EuroSMS();
            string returnMsg = "";

            objSMS.BookingSMSAccountType = smsType;
            objSMS.ToNumber = mobileNo;
            objSMS.Message = message;
            return objSMS.Send(ref returnMsg);
        }

        //public static bool CancelBooking(long bookingId)
        //{




        //    bool rtn = false;
        //    if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to cancel this Booking ?", "Cancel Booking", MessageBoxButtons.YesNo))
        //    {

        //        frmCancelReason frm = new frmCancelReason(bookingId);
        //        frm.ShowDialog();
        //        frm.Dispose();             

        //        General.RefreshListWithoutSelected<frmBookingsList>("frmBookingsList1");
        //        General.RefreshListWithoutSelected<frmBookingDashBoard>("frmBookingDashBoard1");

        //        rtn = true;

        //    }
        //    return rtn;
        //}


        public static bool ConfirmQuotation(long bookingId)
        {
            bool rtn = false;
            if (DialogResult.Yes == RadMessageBox.Show("Are you sure you want to confirm this Quotation ?", "Confirm Quotation", MessageBoxButtons.YesNo))
            {
                BookingBO objMaster = new BookingBO();

                objMaster.GetByPrimaryKey(bookingId);
                objMaster.Edit();
                objMaster.Current.IsQuotation = false;


                if (objMaster.Current.BookingStatusId.ToInt() == Enums.BOOKINGSTATUS.CANCELLED)
                {
                    objMaster.Current.BookingStatusId = 1;

                    objMaster.Current.CancelReason="";
                    objMaster.Current.JobCancelledBy = "";
                    objMaster.Current.JobCancelledOn = null;

                }
                objMaster.Save();

                General.AddBookingLog(objMaster.Current.Id, "Quotation " + objMaster.Current.BookingNo + " Confirmed by " + AppVars.LoginObj.UserName);


                if (AppVars.objPolicyConfiguration.SendDirectBookingConfirmationEmail.ToBool())
                {
                    try
                    {
                        if (objMaster.PrimaryKeyValue != null)
                        {
                            frmEmailBooking frm = new frmEmailBooking(objMaster.Current, true, "Confirmation");
                            //,result== DialogResult.Yes?true:false);
                            frm.IsOpenedFromBooking = true;

                            frm.Dispose();
                            //new Thread(delegate()
                            //{


                            //   // JATEmail.SendDirectBookingConfirmationEmail(objMaster.Current);
                            //}).Start();

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                rtn = true;
            }
            return rtn;
        }





        public static void ClearDriverCurrentJob(long Id)
        {

            try
            {
                DriverQueueBO objDriverQueueBO = new DriverQueueBO();
                objDriverQueueBO.GetByPrimaryKey(Id);

                if (objDriverQueueBO.Current != null)
                {
                    long? jobId = objDriverQueueBO.Current.CurrentJobId;

                    objDriverQueueBO.Current.QueueDateTime = DateTime.Now;
                    objDriverQueueBO.Current.CurrentJobId = null;
                    objDriverQueueBO.Current.CurrentDestinationPostCode = string.Empty;
                    objDriverQueueBO.Current.DriverWorkStatusId = Enums.Driver_WORKINGSTATUS.AVAILABLE;
                    objDriverQueueBO.Current.WaitSinceOn = DateTime.Now;

                    objDriverQueueBO.Save();


                    if (AppVars.objPolicyConfiguration.MapType.ToInt() == 1)
                    {
                        //For TCP Connection
                        if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                        {
                            if (AppVars.objPolicyConfiguration.EnablePDA.ToBool() && objDriverQueueBO.Current.Fleet_Driver.DefaultIfEmpty().HasPDA.ToBool())
                            {
                                if (jobId != null)
                                {
                                    string msg = "request pda=" + objDriverQueueBO.Current.DriverId + "=" + jobId + "=<<Cleared Job>>" + jobId + "=3";
                                    General.SendMessageToPDA(msg);
                                }
                            }
                        }

                    }
                    else
                    {
                        //For TCP Connection
                        if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                        {
                            if (AppVars.objPolicyConfiguration.EnablePDA.ToBool() && objDriverQueueBO.Current.Fleet_Driver.DefaultIfEmpty().HasPDA.ToBool())
                            {
                                if (jobId != null)
                                {
                                    string msg = "request pda=" + objDriverQueueBO.Current.DriverId + "=" + jobId + "=<<Cleared Job>>" + jobId + "=3";
                                    General.SendMessageToPDA(msg);
                                }
                            }
                        }

                    }


                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        db.stp_BookingLog(jobId, AppVars.LoginObj.UserName.ToStr(), "Job is Manually cleared by Controller (" + AppVars.LoginObj.UserName.ToStr() + ")");

                        db.stp_UpdateJobStatus(jobId, Enums.BOOKINGSTATUS.DISPATCHED);


                        try
                        {
                            var bookingDetails = db.Bookings.Where(c => c.Id == jobId && c.PaymentTypeId == Enums.PAYMENT_TYPES.CREDIT_CARD && c.POBDateTime!=null)
                                                .Select(args => new { args.BookingNo, args.CustomerCreditCardDetails }).FirstOrDefault();

                            if (bookingDetails != null && bookingDetails.CustomerCreditCardDetails.ToStr().Trim().Length > 0)
                            {
                                var paymentDetails = GetPaymentDetails(bookingDetails.BookingNo.ToStr(), bookingDetails.CustomerCreditCardDetails.ToStr());


                                if (paymentDetails.ToStr().Trim().Length > 0)
                                {
                                    var r = paymentDetails.ToStr().Trim().Replace("\\", "").ToStr().Trim().Substring(1);
                                    r = r.Remove(r.LastIndexOf('"'));

                                    Taxi_AppMain_Judo.PaymentReceipt objCls = Newtonsoft.Json.JsonConvert.DeserializeObject<Taxi_AppMain_Judo.PaymentReceipt>(r.ToStr().Trim());
                                    if ((objCls.Result.ToStr().ToLower() == "success"))
                                    {


                                        string transId = objCls.Message.ToStr().Replace(" ", "").Trim();
                                        decimal fares = objCls.OriginalAmount.ToDecimal();

                                        db.ExecuteQuery<int>("exec stp_manualClearJob {0},{1},{2},{3}", jobId, fares, transId, AppVars.LoginObj.UserName);
                                        //string query = "update booking set farerate=" + fares + ",PaymentComments='" + transId + "',paymenttypeid=6 where id=" + jobId;
                                        //db.ExecuteQuery<int>(query);

                                        //query= " insert into booking_payment(authcode,status,netfares,totalamount,paymentgatewayId,bookingId)values('"+transId+"','paid'," + fares + "," + fares + ",6,"+jobId+")";
                                        //db.ExecuteQuery<int>(query);
                                    }
                                }

                            }
                        }
                        catch(Exception ex)
                        {

                        }

                    }




                }
            }
            catch
            {


            }
        }


        public static string GetPaymentDetails(string bookingNo,string cardToken)
        {
            string rtn = "";
            var objJudo = General.GetObject<Gen_SysPolicy_PaymentDetail>(c => c.PaymentGatewayId == 6);

            try
            {
               
                Taxi_AppMain_Judo.JudoProperties obj = new Taxi_AppMain_Judo.JudoProperties();
                obj.Acc_SecretKey = objJudo.MerchantID.ToStr();
                obj.Acc_Token = objJudo.MerchantPassword.ToStr();
                obj.judoId = objJudo.PaypalID;
                obj.cardNumber = "";
                obj.currency = "GBP";
                obj.cv2 = "";
                obj.expiryDate = ""; // 1220
                                     //  obj.yourConsumerReference = Guid.NewGuid().ToString();
                obj.yourPaymentReference = bookingNo;
                obj.amount = 1.00;


                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                using (WebClient client = new WebClient())
                {
                    client.Proxy = null;
                    client.Headers.Add("API-Version: 5.0");
                    client.Headers.Add("Content-Type", "application/json");



                    rtn = client.DownloadString("http://shadowcars.co.uk/api/Jobs/GetPaymentDetails?jsonString=" + json);

                    var r = rtn.Replace("\\", "").ToStr().Trim().Substring(1);
                    r = r.Remove(r.LastIndexOf('"'));

                }

            }
            catch(Exception ex)
            {

            }
            return rtn;

        }


        public static void LogoutDriver(long id)
        {
            try
            {

                DriverQueueBO objMaster = new DriverQueueBO();
                objMaster.GetByPrimaryKey(id);

                if (objMaster.Current != null)
                {
                    objMaster.Current.Status = false;
                    objMaster.Current.DriverWorkStatusId = Enums.Driver_WORKINGSTATUS.AVAILABLE;
                    objMaster.Current.LogoutDateTime = DateTime.Now;
                    objMaster.Save();

                    //     AppVars.frmDashBoard.LoadDriverWaitingGrid();
                }
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);


            }
        }

        public static void BroadCastRefreshWaitingDrivers()
        {

            new BroadcasterData().BroadCastToAll(RefreshTypes.REFRESH_WAITING_AND_DASBOARD);

        }

        public static void BroadCastRefresh(string refreshType)
        {

            new BroadcasterData().BroadCastToAll(refreshType);

        }


        //public static void RefreshWaitingDrivers()
        //{
        //    ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard")).RefreshWaitingDrivers();
         

        //}

        //public static void RefreshDriversGrids()
        //{
        //    ((frmBookingDashBoard)System.Windows.Forms.Application.OpenForms.OfType<Form>().FirstOrDefault(c => c.Name == "frmBookingDashBoard")).RefreshWaitingAndOnBoardDrivers();
         

        //}




        public static void UpdateDriverQueue(long Id, long? jobId, string destinationPostCode)
        {

            DriverQueueBO objDriverQue = new DriverQueueBO();

            objDriverQue.GetByPrimaryKey(Id);
            if (objDriverQue.Current != null)
            {
                objDriverQue.Current.CurrentJobId = jobId;
                objDriverQue.Current.CurrentDestinationPostCode = destinationPostCode;

                objDriverQue.Current.QueueDateTime = DateTime.Now;

                objDriverQue.Save();

            }

        }


        public static void OnDespatchUpdateDriverQueue(long Id, long? jobId, string destinationPostCode)
        {



            DriverQueueBO objDriverQue = new DriverQueueBO();

            //  int MaxQueueNo = General.GetQueryable<Fleet_DriverQueueList>(c => c.Status == true).Max(s => s.QueueNo).DefaultIfEmpty().ToInt();

            objDriverQue.GetByPrimaryKey(Id);
            if (objDriverQue.Current != null)
            {
                objDriverQue.Current.CurrentJobId = jobId;
                objDriverQue.Current.CurrentDestinationPostCode = destinationPostCode;

                objDriverQue.Current.QueueDateTime = DateTime.Now;
                //   objDriverQue.Current.QueueNo = MaxQueueNo + 1;
                objDriverQue.Current.DriverWorkStatusId = Enums.Driver_WORKINGSTATUS.NOTAVAILABLE;
                objDriverQue.Save();

            }

        }


        public static void UpdateDriverQueue(int? driverId)
        {

            DriverQueueBO objDriverQue = new DriverQueueBO();



            Fleet_DriverQueueList objthisDriver = General.GetObject<Fleet_DriverQueueList>(c => c.Status == true && c.DriverId == driverId);

            if (objthisDriver != null)
            {
                objDriverQue.GetByPrimaryKey(objthisDriver.Id);
                if (objDriverQue.Current != null)
                {
                    objDriverQue.Current.QueueDateTime = DateTime.Now;
                    //    objDriverQue.Current.QueueNo = MaxQueueNo + 1;
                    objDriverQue.Save();

                }
            }

        }

        public static IList GetHospitalsList()
        {

            var list = (from a in General.GetQueryable<Gen_Location>(null)
                        where a.LocationTypeId == Enums.LOCATION_TYPES.HOSPITAL
                        orderby a.LocationName
                        select new
                        {
                            Id = a.Id,
                            Location = a.LocationName

                        }).ToList();
            return list;

        }

        public static IList GetHotelsList()
        {

            var list = (from a in General.GetQueryable<Gen_Location>(null)
                        where a.LocationTypeId == Enums.LOCATION_TYPES.HOTELS
                        orderby a.LocationName
                        select new
                        {
                            Id = a.Id,
                            Location = a.LocationName

                        }).ToList();
            return list;

        }


        public static IList GetTownsList()
        {

            var list = (from a in General.GetQueryable<Gen_Location>(null)
                        where a.LocationTypeId == Enums.LOCATION_TYPES.TOWN
                        orderby a.LocationName
                        select new
                        {
                            Id = a.Id,
                            Location = a.LocationName

                        }).ToList();
            return list;

        }


        public static bool ShowDespatchFOJForm(Booking obj)
        {
            bool rtn = false;

            frmDespatchJob frm = new frmDespatchJob(obj, true);

            frm.ShowDialog();


            if (frm.SmsThread != null)
                frm.SmsThread.Start();

            rtn = frm.SuccessDespatched;

            frm.Dispose();

            return rtn;

        }




        public static bool ShowReDespatchForm(Booking obj)
        {
            bool rtn = false;

            frmDespatchJob frm = new frmDespatchJob(obj);
            frm.ReDespatchJob = true;
            frm.ShowDialog();



            if (frm.SmsThread != null)
                frm.SmsThread.Start();

            rtn = frm.SuccessDespatched;

            frm.Dispose();

            return rtn;

        }


        public static bool ShowDespatchForm(Booking obj)
        {
            bool rtn = false;

            frmDespatchJob frm = new frmDespatchJob(obj);

            frm.ShowDialog();



            if (frm.SmsThread != null)
                frm.SmsThread.Start();

            rtn = frm.SuccessDespatched;

            frm.Dispose();

            return rtn;

        }


        public static bool ShowDespatchForm(long jobId, int? driverId)
        {

            bool rtn = false;

            frmDespatchJob frm = new frmDespatchJob(jobId, AppVars.BLData.Get<Booking>(c => c.Id == jobId), driverId
                                        , AppVars.BLData.Get<Fleet_Driver>(c => c.Id == driverId), false);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            if (frm.SmsThread != null)
                frm.SmsThread.Start();

            rtn = frm.SuccessDespatched;

            frm.Dispose();


            return rtn;
        }



        public static int? ShowLocationForm(int? locTypeId)
        {


            frmLocations frm = new frmLocations(locTypeId);
            frm.ControlBox = true;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();

            return frm.LocationId;

        }

        public static List<object[]> ShowCustomerInvoiceBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, DateTime? fromDate, DateTime? tillDate)
        {
            var list1 = General.GetGeneralList<Booking>(_condition).Where(b => b.BookingDate.ToDate() >= fromDate && b.BookingDate.ToDate() <= tillDate);
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
                            PickupPoint = b.FromAddress,
                            Destination = b.ToAddress,
                            Charges = b.CustomerPrice.ToDecimal(),

                            CompanyId = b.CompanyId,
                            CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.ParkingCharges.ToDecimal(),
                            Waiting = b.WaitingCharges.ToDecimal(),
                            ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                            MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Total = b.TotalCharges.ToDecimal(),
                            PaymentTypeId = b.PaymentTypeId


                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }

        public static List<object[]> ShowBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, DateTime? fromDate, DateTime? tillDate)
        {
            var list1 = General.GetGeneralList<Booking>(_condition).Where(b => b.BookingDate.ToDate() >= fromDate && b.BookingDate.ToDate() <= tillDate);
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
                            PickupPoint = b.FromAddress,
                            Destination = b.ToAddress,
                            Charges = b.FareRate.ToDecimal(),

                            CompanyId = b.CompanyId,
                            CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.ParkingCharges.ToDecimal(),
                            Waiting = b.WaitingCharges.ToDecimal(),
                            ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                            MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Total = b.TotalCharges.ToDecimal()


                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }


        public static List<object[]> ShowEscortInvoiceBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, Func<Booking, bool> _condition2)
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
                            Charges = b.EscortPrice.ToDecimal(),
                            CompanyId = b.CompanyId,
                            CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.ParkingCharges.ToDecimal(),
                            Waiting = b.WaitingCharges.ToDecimal(),
                            ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                            MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Description = "",
                            Total = b.EscortPrice.ToDecimal(),
                            //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                            BookedBy = b.BookedBy.ToStr(),
                            Fare = b.FareRate.ToDecimal(),

                            AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                            PaymentTypeId = b.PaymentTypeId
                        }).OrderBy(c=>c.PickupDate).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }





        public static List<object[]> ShowBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, Func<Booking, bool> _condition2)
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
                            Total = b.TotalCharges.ToDecimal(),
                            //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                            BookedBy = b.BookedBy.ToStr(),
                            Fare = b.FareRate.ToDecimal(),

                            AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                            PaymentTypeId = b.PaymentTypeId
                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }


        public static List<object[]> ShowBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, Func<Booking, bool> _condition2, string templateName)
        {

            Taxi_AppMain.frmLister frm = null;
            if (templateName == "Template13" || templateName == "Template24")
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
                                PaymentTypeId = b.PaymentTypeId
                            }).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }
            else if (templateName == "Template14")
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
                                //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                BookedBy = b.BookedBy.ToStr(),
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                PaymentTypeId = b.PaymentTypeId
                            }).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }
            else
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
                                Total = b.TotalCharges.ToDecimal(),
                                //  BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                BookedBy = b.BookedBy.ToStr(),
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                                PaymentTypeId = b.PaymentTypeId
                            }).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();


            }



            return (frm != null ? frm.ListofData : null);

        }



        public static List<object[]> ShowCourierBookingMultiLister(Expression<Func<Booking, bool>> _condition, Expression<Func<Invoice_Charge, bool>> _invoiceCondition, string[] hiddenColumns, Func<Booking, bool> _condition2)
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
                            Charges = 0,
                            CompanyId = b.CompanyId,
                            CompanyName = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.ParkingCharges.ToDecimal(),
                            Waiting = b.WaitingCharges.ToDecimal(),
                            ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                            MeetAndGreet = b.MeetAndGreetCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Description = "",
                            Total = b.TotalCharges.ToDecimal(),
                            BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                            Fare = b.FareRate.ToDecimal(),

                            AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                            PaymentTypeId = b.PaymentTypeId,
                            
                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }



        public static List<object[]> ShowDriverTransactionBookingMultiLister(Expression<Func<Booking, bool>> _condition, string[] hiddenColumns, Func<Booking, bool> _condition2)
        {
            var list1 = General.GetGeneralList<Booking>(_condition).Where(_condition2);


            var list = (from b in list1

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
                            Account = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.CongtionCharges.ToDecimal(),
                            Waiting = b.MeetAndGreetCharges.ToDecimal(),
                            ExtraDrop = b.ParkingCharges.ToDecimal(),
                            MeetAndGreet = b.WaitingCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Description = "",
                            Total = b.FareRate.ToDecimal() + b.CongtionCharges.ToDecimal() + b.MeetAndGreetCharges.ToDecimal(),
                            BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                            Fare = b.FareRate.ToDecimal(),

                            AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                            b.IsCommissionWise,
                            b.DriverCommissionType,
                            b.DriverCommission,
                            b.AgentCommission

                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }


        public static List<object[]> ShowDriverRentTransactionExpensesBookingMultiLister(Expression<Func<Booking, bool>> _condition, string[] hiddenColumns, Func<Booking, bool> _condition2)
        {

            TaxiDataContext db = new TaxiDataContext();

            var list1 = db.GetTable<Booking>().Where(_condition).Where(_condition2);
            var rentList =db.GetTable<DriverRent_Charge>().Where(c => c.BookingId != null && c.TransId != null);
      
            var list = (from b in list1
                        join b1 in rentList on b.Id equals b1.BookingId into table2
                        from b1 in table2.DefaultIfEmpty()
                     
                        where (b1 == null)
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
                            Account = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.CongtionCharges,
                            Waiting = b.MeetAndGreetCharges,
                            ExtraDrop = b.ParkingCharges,
                            MeetAndGreet = b.MeetAndGreetCharges,
                            Congtion = b.CongtionCharges,
                            Description = "",
                            Total = b.FareRate + b.CongtionCharges + b.MeetAndGreetCharges,
                            BookedBy = "",
                            Fare = b.FareRate,

                            AccountType =0,
                            b.IsCommissionWise,
                            b.DriverCommissionType,
                            b.DriverCommission,
                            b.AgentCommission,
                            DropOffCharge = 0.00m,
                            PickupCharge = 0.00m,
                            PaymentTypeId = b.PaymentTypeId

                        }).ToList();


            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            frm.Dispose();
            db.Dispose();

            return frm.ListofData;

        }


        public static List<object[]> ShowDriverRentTransactionExpensesWithWaitingBookingMultiLister(Expression<Func<Booking, bool>> _condition, string[] hiddenColumns, Func<Booking, bool> _condition2)
        {

            Taxi_AppMain.frmLister frm = null;
            using (TaxiDataContext db = new TaxiDataContext())
            {

                var list1 = db.GetTable<Booking>().Where(_condition);
                var rentList = db.GetTable<DriverRent_Charge>().Where(c => c.BookingId != null );

                var list = (from b in list1
                            join b1 in rentList on b.Id equals b1.BookingId into table2

                            join b2 in db.Fleet_VehicleTypes on b.VehicleTypeId equals b2.Id
                            join bs in db.BookingStatus on b.BookingStatusId equals bs.Id

                            join pt in db.Gen_PaymentTypes on b.PaymentTypeId equals pt.Id

                            join b3 in db.Gen_Companies on b.CompanyId equals b3.Id into table3

                            from b1 in table2.DefaultIfEmpty()
                            from b3 in table3.DefaultIfEmpty()

                            where (b1 == null)
                            select new
                            {
                                Id = b.Id,
                                BookingDate = b.BookingDate,
                                PickupDate = b.PickupDateTime,
                                RefNo = b.BookingNo,
                                Vehicle = b2.VehicleType,
                                OrderNo = b.OrderNo,
                                PupilNo = b.PupilNo,
                                Passenger = b.CustomerName,
                                PickupPoint =  b.FromAddress,
                                Destination =  b.ToAddress,
                                //  Charges = b.FareRate.ToDecimal(),
                                Charges = b.CompanyPrice,
                                CompanyId = b.CompanyId,
                                Account = b3.CompanyName,
                                Parking = b.CongtionCharges,
                                Waiting = b.MeetAndGreetCharges,
                                ExtraDrop = b.ParkingCharges,
                                MeetAndGreet = b.MeetAndGreetCharges,
                                Congtion = b.CongtionCharges,
                                Description = "",
                                Total = b.FareRate,  // 19 index
                                BookedBy = "",
                                Fare = b.FareRate,

                                AccountType = 0,
                                b.IsCommissionWise,
                                b.DriverCommissionType,
                                b.DriverCommission,
                                b.AgentCommission,
                                DropOffCharge = 0.00m,
                                PickupCharge = 0.00m,
                                PaymentTypeId = b.PaymentTypeId,
                                ExtrCharges = b.ExtraDropCharges,
                                BookingFee=b.ServiceCharges,
                                b.BookingStatusId,
                                bs.StatusName,
                                pt.PaymentType
                            }).ToList();


                frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();

                frm.Dispose();
            }

            return frm.ListofData;

        }

            public static List<object[]> ShowDriverCommTransactionBookingMultiLister(Expression<Func<Booking, bool>> _condition, string[] hiddenColumns, Expression<Func<Booking, bool>> _condition2)
        {


            // TaxiDataContext db = new TaxiDataContext();
            // var list1 =db.GetTable<Booking>().Where(_condition).Where(_condition2);


            //var list2 =db.GetTable<Fleet_DriverCommision_Charge>();

            //var list = (from b in list1
            //            join c in list2 on b.Id equals c.BookingId into table2
            //            from c in table2.DefaultIfEmpty()
            //            where (c == null)

            //            select new
            //            {
            //                Id = b.Id,
            //                BookingDate = b.BookingDate,
            //                PickupDate = b.PickupDateTime,

            //                RefNo = b.BookingNo,
            //                Vehicle = b.Fleet_VehicleType.VehicleType,
            //                OrderNo = b.OrderNo,
            //                PupilNo = b.PupilNo,
            //                Passenger = b.CustomerName,
            //                PickupPoint = !string.IsNullOrEmpty(b.FromDoorNo) ? b.FromDoorNo + " - " + b.FromAddress : b.FromAddress,
            //                Destination = !string.IsNullOrEmpty(b.ToDoorNo) ? b.ToDoorNo + " - " + b.ToAddress : b.ToAddress,
            //                //  Charges = b.FareRate.ToDecimal(),
            //                Charges = b.CompanyPrice!=null ? b.CompanyPrice:0.00m,
            //                CompanyId = b.CompanyId,
            //                Account = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
            //                Parking =b.CongtionCharges!=null ? b.CongtionCharges:0.00m,
            //                Waiting = b.MeetAndGreetCharges,
            //                ExtraDrop = b.ParkingCharges,
            //                MeetAndGreet = b.WaitingCharges,
            //                Congtion = b.CongtionCharges,
            //                Description = "",
            //                Total = b.FareRate + b.CongtionCharges + b.MeetAndGreetCharges,
            //                BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
            //                Fare = b.FareRate,

            //                AccountType = b.CompanyId != null && b.Gen_Company.AccountTypeId!=null ? b.Gen_Company.AccountTypeId : 0,
            //                b.IsCommissionWise,
            //                b.DriverCommissionType,
            //                b.DriverCommission,
            //                b.AgentCommission
            //            }).ToList();


            var list1 = General.GetGeneralList<Booking>(_condition2);


            var list2 = General.GetGeneralList<Fleet_DriverCommision_Charge>(null);


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
                            Account = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                            Parking = b.CongtionCharges.ToDecimal(),
                            Waiting = b.MeetAndGreetCharges.ToDecimal(),
                            ExtraDrop = b.ParkingCharges.ToDecimal(),
                            MeetAndGreet = b.WaitingCharges.ToDecimal(),
                            Congtion = b.CongtionCharges.ToDecimal(),
                            Description = "",
                            Total = b.FareRate.ToDecimal() + b.CongtionCharges.ToDecimal() + b.MeetAndGreetCharges.ToDecimal(),
                            BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                            Fare = b.FareRate.ToDecimal(),

                            AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : 0,
                            b.IsCommissionWise,
                            b.DriverCommissionType,
                            b.DriverCommission,
                            b.AgentCommission
                        }).ToList();


            //  db.Dispose();

            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


            frm.HiddenColumns = hiddenColumns;
            frm.ShowDialog();

            return frm.ListofData;

        }





      



        public static List<object[]> ShowDriverCommTransactionExpense2BookingMultiLister(Expression<Func<Booking, bool>> condition, string[] hiddenColumns, Expression<Func<Booking, bool>> condition2)
        {
            List<object[]> obj = null;

            using (TaxiDataContext db = new TaxiDataContext())
            {

                var list1 =db.Bookings.Where(condition2).ToList();


                var list2 = db.Fleet_DriverCommision_Charges.ToList();


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
                                Account = b.CompanyId != null ? b.Gen_Company.CompanyName : "",
                                Parking = b.CongtionCharges.ToDecimal(),
                                Waiting = b.MeetAndGreetCharges.ToDecimal(),
                                ExtraDrop = b.ExtraDropCharges.ToDecimal(),
                                MeetAndGreet = b.WaitingCharges.ToDecimal(),
                                Congtion = b.CongtionCharges.ToDecimal(),
                                Description = "",
                                Total = b.FareRate.ToDecimal() + b.CongtionCharges.ToDecimal() + b.MeetAndGreetCharges.ToDecimal(),
                                BookedBy = b.DepartmentId != null ? b.Gen_Company_Department.DepartmentName.ToStr() : "",
                                Fare = b.FareRate.ToDecimal(),

                                AccountType = b.CompanyId != null ? b.Gen_Company.AccountTypeId.ToInt() : Enums.ACCOUNT_TYPE.CASH,
                                b.IsCommissionWise,
                                b.DriverCommissionType,
                                b.DriverCommission,
                                AgentCommission=  b.AgentCommission.ToDecimal()+b.CashRate.ToDecimal(),
                                // DropOffCharge = d1 != null ?  d1.Charges:d1.Id>0? d1.Id:01,
                                DropOffCharge =0.00m,
                                PickupCharge =  0.00m,
                                PaymentTypeId = b.PaymentTypeId,
                                Payment = b.Gen_PaymentType.PaymentType,
                                ServiceCharges = b.ServiceCharges.ToDecimal(),
                                PickupPlot = b.ZoneId != null ? b.Gen_Zone1.ZoneName : "",
                                DropOffPlot = b.DropOffZoneId != null ? b.Gen_Zone.ZoneName : "",
                                Promotion = b.TipAmount,
                                b.BookingStatusId,
                                b.BookingStatus.StatusName,
                                  AccountNoComm = b.CompanyId != null ? b.Gen_Company.DayAndNightWise : false
                            }).OrderBy(c => c.PickupDate).ToList();
                //eventStatus.onWaitingList ? "waitinglist" : "accepted";

                //  db.Dispose();

                Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, "Id", true, hiddenColumns);


                frm.HiddenColumns = hiddenColumns;
                frm.ShowDialog();
                obj = frm.ListofData;

            }
            return obj;

        }






        public static bool SP_SendMessage(int? senderId, int? receiverId, string senderName, string receiverName, string messageBody
                 , DateTime? createdDate, string sendFrom, string receiverMobileNo, string receiverPDAMobileNo, bool sendAlsoPDA)
        {


            bool rtn = true;

            using (Taxi_Model.TaxiDataContext db = new TaxiDataContext())
            {
                if (receiverId != null && receiverId != 0 && sendAlsoPDA == true)
                {
                    db.stp_SendMessage(senderId, receiverId, senderName, receiverName, messageBody, sendFrom);
                }

                if (sendAlsoPDA == false)
                {


                    if (string.IsNullOrEmpty(receiverMobileNo))
                        return true;



                    if (Debugger.IsAttached == false)
                    {


                        int idx = -1;
                        if (receiverMobileNo.StartsWith("044") == true)
                        {
                            idx = receiverMobileNo.IndexOf("044");
                            receiverMobileNo = receiverMobileNo.Substring(idx + 3);
                            receiverMobileNo = receiverMobileNo.Insert(0, "+44");
                        }

                        if (receiverMobileNo.StartsWith("07"))
                        {
                            receiverMobileNo = receiverMobileNo.Substring(1);
                        }

                        if (receiverMobileNo.StartsWith("044") == false || receiverMobileNo.StartsWith("+44") == false)
                            receiverMobileNo = receiverMobileNo.Insert(0, "+44");
                    }


                    EuroSMS objSMS = new EuroSMS();

                    objSMS.ToNumber = receiverMobileNo;
                    objSMS.Message = messageBody;
                    objSMS.Send(ref messageBody);
                }
                else
                {

                    //if (messageBody.Contains("\r\n"))
                    //{
                    //    messageBody = messageBody.Replace("\r\n", " ").Trim();
                    //}

                    if (messageBody.Contains("&"))
                    {
                        messageBody = messageBody.Replace("&", "And");
                    }

                    if (messageBody.Contains(">"))
                        messageBody = messageBody.Replace(">", " ");


                    if (messageBody.Contains("="))
                        messageBody = messageBody.Replace("=", " ");


                    if (AppVars.objPolicyConfiguration.MapType.ToInt() == 1)
                    {

                        // For TCP Connection
                        if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                        {
                            rtn = General.SendMessageToPDA("request pda=" + receiverId + "=" + 0 + "="
                                            + "Message>>" + messageBody + ">>" + String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "=4").Result.ToBool();
                        }

                    }
                    else
                    {
                        // For TCP Connection
                        if (AppVars.objPolicyConfiguration.IsListenAll.ToBool())
                        {
                            rtn = General.SendMessageToPDA("request pda=" + receiverId + "=" + 0 + "="
                                           + "Message>>" + messageBody + ">>" + String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "=4").Result.ToBool();
                        }


                    }




                }


            }

            return rtn;
        }




        public static void SP_SaveBid(long jobId, int? driverId, decimal bidRate, int? bidStatusId)
        {

            using (Taxi_Model.TaxiDataContext db = new TaxiDataContext())
            {
                db.stp_UpdateBid(jobId, driverId, bidRate, bidStatusId);


            }
        }





        public static string RemoveUK(ref string address)
        {


            if (address.ToUpper().EndsWith(", UK"))
            {
                address = address.Remove(address.ToUpper().LastIndexOf(", UK"));
            }

            return address;
        }




        public static void ShowGoogleMap_RouteDirections(WebBrowser map, string PickupPoint, string[] ViaLocs, string DestinationPoint)
        {

            if (map == null)
            {
                map = new WebBrowser();

            }

            PickupPoint = GetPostCodeMatch(PickupPoint);
            DestinationPoint = GetPostCodeMatch(DestinationPoint);


            bool IsPickupAlpha = PickupPoint.IsAlpha();
            bool IsDestAlpha = DestinationPoint.IsAlpha();

            if (IsPickupAlpha || IsDestAlpha)
            {
                return;

            }

            PickupPoint = PickupPoint.Replace(" ", "+") + "+UK";
            DestinationPoint = DestinationPoint.Replace(" ", "+") + "+UK";
            //  PickupPoint += "+to:";
            string via = string.Empty;
            if (ViaLocs.Count() > 0)
            {
                ViaLocs = ViaLocs.Select(c => GetPostCodeMatch(c)).Where(c => c.Length > 0).ToArray<string>();
                if (ViaLocs.Count() == 0)
                {
                    //   ENUtils.ShowMessage("Map not found");
                    return;

                }
                via = string.Join("|", ViaLocs.Select(c => GetPostCodeMatch(c) + "+UK").ToArray<string>());
            }

            if (PickupPoint == string.Empty || DestinationPoint == string.Empty)
            {

                return;
            }




            PickupPoint = PickupPoint.Replace("to:", "|").Trim();

            string src = string.Empty;

            if (via.Length > 0)
            {

                src = "<html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"></head><body<iframe" +
                                     " width=\"960\"" +
                                     " height=\"710\"" +
                                     " \frameborder=\"0\" style=\"border:0;margin-left:-10;margin-top:-10;margin-right:-10\"" +
                                     " src=\"https://www.google.com/maps/embed/v1/directions?key=AIzaSyAFkZHqTas4EKYEEsk8J3aQh0zQJ-tsWmY&origin=" +
                                        PickupPoint + "&waypoints=" + via + "&destination=" + DestinationPoint + "&avoid=tolls|highways" + "\">" +
                                   "</iframe></body></html>";
            }
            else
            {
                src = "<html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"></head><body><iframe" +
                                   " width=\"960\"" +
                                   " height=\"710\"" +
                                   " \frameborder=\"0\" style=\"border:0;margin-left:-10;margin-top:-10;margin-right:-10\"" +
                                   " src=\"https://www.google.com/maps/embed/v1/directions?key=AIzaSyAFkZHqTas4EKYEEsk8J3aQh0zQJ-tsWmY&origin=" +
                                      PickupPoint + "&destination=" + DestinationPoint + "&avoid=tolls|highways" + "\">" +
                                 "</iframe></body></html>";


            }

            map.DocumentText = src;



        }







        public static void LoadZoneList()
        {

            if (AppVars.objPolicyConfiguration.EnablePOI.ToBool())
            {
                using (TaxiDataContext db = new TaxiDataContext())
                {
                  AppVars.zonesList=  db.stp_GetLocalizationDetails().Where(c => c.DetailId != null).Select(c => c.PostCode).ToArray<string>();

                }

            }
            else
            {

                AppVars.zonesList = General.GetQueryable<Gen_Zone_AssociatedPostCode>(c => c.PostCode != null && c.PostCode != "").OrderBy(c => c.Gen_Zone.OrderNo)
                                     .OrderBy(c => c.OrderNo).Select(a => a.PostCode).ToArray<string>();

            }

        }






        public static string GetPostCode(string value)
        {

            if (value.ToStr().Contains(","))
            {
                value = value.Replace(",", "").Trim();
            }

            if (value.ToStr().Contains(" "))
            {
                value = value.Replace(" ", " ").Trim();
            }

            string postCode = "";

            //   string ukAddress = @"[[:alnum:]][a-zA-Z0-9_\.\#\' \-]{2,60}$";
            string ukAddress = @"^(GIR 0AA)|((([A-PR-UWYZ][0-9][0-9]?)|(([A-PR-UWYZ][A-HK-Y][0-9][0-9]?)|(([A-PR-UWYZ][0-9][A-HJKSTUW])|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY])))) [0-9][A-BD-HJLNP-UW-Z]{2})$";
            // string ukAddress = @"^(GIR 0AA|[A-PR-UWYZ]([0-9]{1,2}| ([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]| [ABEHMNPRV-Y]))|[0-9][A-HJKPS-UW]) [0-9][ABD-HJLNP-UW-Z]{2})$";


            Regex reg = new Regex(ukAddress);
            Match em = reg.Match(value);

            if (em != null)
                postCode = em.Value;

            if (em.Value == "")
            {
                ukAddress = @"[A-Z]{1,2}[0-9R][0-9A-Z]?";
                reg = new Regex(ukAddress);
                em = reg.Match(value);

                postCode = em.Value;

            }

            return postCode;

        }

        public static string GetPostCodeMatch(string value)
        {



            string postCode = "";

            General.RemoveUK(ref value);

            if (value.ToStr().Contains(","))
            {
                value = value.Replace(",", "").Trim();
            }

            if (value.ToStr().Contains(" "))
            {
                value = value.Replace(" ", " ").Trim();
            }

           


            string ukAddress = @"^(GIR 0AA)|((([A-PR-UWYZ][0-9][0-9]?)|(([A-PR-UWYZ][A-HK-Y][0-9][0-9]?)|(([A-PR-UWYZ][0-9][A-HJKSTUW])|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY])))) [0-9][A-BD-HJLNP-UW-Z]{2})$";


            Regex reg = new Regex(ukAddress);
            Match em = reg.Match(value);

            if (em != null)
                postCode = em.Value;

            if (em.Value == "")
            {
                ukAddress = @"[A-Z]{1,2}[0-9R][0-9A-Z]?";
                reg = new Regex(ukAddress);
                MatchCollection mat = reg.Matches(value);


                foreach (Match item in mat)
                {
                    if (item.Value.ToStr().IsAlpha() == false)
                        postCode += item.Value.ToStr() + " ";

                }

            }



            return postCode.Trim();

        }




        public static string GetPostCodeMatchOpt(string value)
        {



            string postCode = "";

            General.RemoveUK(ref value);

            if (value.ToStr().Contains(","))
            {
                value = value.Replace(",", "").Trim();
            }

            if (value.ToStr().Contains(" "))
            {
                value = value.Replace(" ", " ").Trim();
            }



            string ukAddress = @"^([A-PR-UWYZ](([0-9](([0-9]|[A-HJKSTUW])?)?)|([A-HK-Y][0-9]([0-9]|[ABEHMNPRVWXY])?)) ?[0-9][ABD-HJLNP-UW-Z]{2})$";

         //   string ukAddress = @"^(GIR 0AA)|((([A-PR-UWYZ][0-9][0-9]?)|(([A-PR-UWYZ][A-HK-Y][0-9][0-9]?)|(([A-PR-UWYZ][0-9][A-HJKSTUW])|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY]))))([ ]?)[0-9][A-BD-HJLNP-UW-Z]{2})$";


            Regex reg = new Regex(ukAddress);
            Match em = reg.Match(value);

            if (em != null)
                postCode = em.Value;

            if (em.Value == "")
            {

                string halfPostcode = string.Empty;

                ukAddress = @"[A-Z]{1,2}[0-9R][0-9A-Z]?";
                reg = new Regex(ukAddress);
                MatchCollection mat = reg.Matches(value);

                foreach (Match item in mat)
                {
                    if (item.Value.ToStr().IsAlpha() == false)
                        halfPostcode += item.Value.ToStr();

                }

                if (value.WordCount() == 1)
                {
                    //if(value.EndsWith(" "))
                    //{
                    //    postCode = halfPostcode + " ";

                    //}
                    //else
                         postCode = halfPostcode;

                }
                else if (halfPostcode.Length > 0 && value.WordCount() == 2)
                {
                    if ( value.Trim().Length <= 8 && value.Trim().Contains(" ") 
                        &&  value.Trim().Split(new char[] { ' ' })[1].IsAlpha()==false)
                    {

                        if (value.StartsWith(halfPostcode))
                            postCode = value.Trim();
                        else if (value.EndsWith(halfPostcode))
                            postCode = halfPostcode;
                    }
                    else if(halfPostcode.IsAlpha()==false)
                        postCode = halfPostcode;

                }

            }



            return postCode.Trim();

        }



        public static string GetFullPostCodeMatch(string value)
        {
            string postCode = "";


            General.RemoveUK(ref value);


            string ukAddress = @"([A-Z][A-Z][0-9] [0-9]?)|([A-Z][A-Z][0-9][0-9] [0-9]?)|([A-Z][0-9][0-9] [0-9]?)|([A-Z][0-9] [0-9]?)|([A-Z][A-Z][0-9][A-Z] [0-9]?)|([A-Z][0-9][A-Z] [0-9]?)";





            Regex reg = new Regex(ukAddress);
            Match em = reg.Match(value);

            if (em != null)
                postCode = em.Value;

            if (em.Value == "")
            {

                reg = new Regex(ukAddress);
                MatchCollection mat = reg.Matches(value);


                foreach (Match item in mat)
                {
                    if (item.Value.ToStr().IsAlpha() == false)
                        postCode += item.Value.ToStr() + " ";

                }

                // postCode = em.Value;

            }



            return postCode.Trim();

        }


        public static List<T> GetGeneralList<T>(Expression<Func<T, bool>> condition) where T : class
        {
            if (condition == null)
            {
                return new BLInfo<T, Taxi_Model.TaxiDataContext>().GetAll<T>().ToList();
            }
            else
            {

                return new BLInfo<T, Taxi_Model.TaxiDataContext>()
                         .GetAll<T>(condition).ToList();
            }
        }


        public static IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> condition) where T : class
        {
            if(condition==null)
                return new BLInfo<T, Taxi_Model.TaxiDataContext>().GetAll<T>();

            else
            return new BLInfo<T, Taxi_Model.TaxiDataContext>()
                     .GetAll<T>(condition);

        }

        public static void ShowBookingForm(bool showOnDialog)
        {

            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2();
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {

                frmBooking frm = new frmBooking();


                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();
            }
            //   frm.AllowShowFocusCues = false;

        }


        
        public static bool ShowBookingForm(int id, bool showOnDialog, string name, string phone, int? bookingTypeId)
        {

            try
            {
               
               

                    if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
                    {
                        frmBooking2 frm = new frmBooking2(name, phone, null, false);
                        frm.PickBookingTypeId = bookingTypeId;
                        if (id != 0)
                        {
                            frm.OnDisplayRecord(id);
                        }
                        frm.ControlBox = true;
                        frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                        frm.MaximizeBox = false;

                        if (showOnDialog)
                        {
                            frm.ShowDialog();

                         
                           
                        }
                        else
                            frm.Show();



                         return frm.saved;
                    }
                    else
                    {

                        frmBooking frm = new frmBooking(name, phone, null, false);
                        frm.PickBookingTypeId = bookingTypeId;
                        if (id != 0)
                        {
                            frm.OnDisplayRecord(id);
                        }
                        frm.ControlBox = true;
                        frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                        frm.MaximizeBox = false;

                        if (showOnDialog)
                        {
                            frm.ShowDialog();
                        }
                        else
                            frm.Show();

                    return false;
                }
                
            }
            catch (Exception ex)
            {
                ENUtils.ShowMessage(ex.Message);
                return false;
            }


        }


        public static void ShowBookingForm(int id, bool showOnDialog, string name, string phone, string doorNo, string address, int? bookingTypeId)
        {
            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2(name, phone, doorNo, address, null, false);
                frm.PickBookingTypeId = bookingTypeId;

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {


                frmBooking frm = new frmBooking(name, phone, doorNo, address, null, false);
                frm.PickBookingTypeId = bookingTypeId;

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();

            }

            //    frm.AllowShowFocusCues = false;

        }


        public static void ShowBookingForm(int id, bool showOnDialog, string name, string phone, string mobileNo, string doorNo, string address, string email)
        {

            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2(name, phone, mobileNo, doorNo, address, email, null, false);

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {

                frmBooking frm = new frmBooking(name, phone, mobileNo, doorNo, address, email, null, false);

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();
            }
            //     frm.AllowShowFocusCues = false;

        }




        public static void ShowBookingForm(int id, bool showOnDialog, string name, string phone, string mobileNo, string doorNo, string address, string email,string excludeddrivers,string notes)
        {

            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2(name, phone, mobileNo, doorNo, address, email, null, false);

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;


                if (excludeddrivers.ToStr().Trim().Length > 0)
                {
                    frm.btnExcludeDrivers.Tag = excludeddrivers.ToStr().Trim();

                }

                frm.CustomerPermanentNotes = notes;


                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {

                frmBooking frm = new frmBooking(name, phone, mobileNo, doorNo, address, email, null, false);

                if (id != 0)
                {
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();
            }
            //     frm.AllowShowFocusCues = false;

        }


        public static bool CheckCompanyInformation()
        {
            bool exist = true;
            if (AppVars.objSubCompany.TelephoneNo.ToStr().Trim() == string.Empty)
            {
                exist = false;

                ENUtils.ShowMessage("InComplete Company Information.." + Environment.NewLine +
                                    "Please Enter Company Information");


                frmSysPolicy frm = new frmSysPolicy(1);
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.ControlBox = true;
                frm.MaximizeBox = false;
                frm.Size = new Size(750, 600);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }

            return exist;

        }

        public static void ShowBookingForm(int id, bool showOnDialog, string name, string phone, int? fromLocTypeId, int? toLocTypeId,
                                           int? fromLocId, int? toLocId, string fromAddress, string toAddress, decimal fare, bool IsReverse, string doorNo)
        {

            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2(name, phone, fromLocTypeId, toLocTypeId, fromLocId, toLocId, fromAddress, toAddress, fare, IsReverse, doorNo);
                frm.OnDisplayRecord(id);

                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {

                frmBooking frm = new frmBooking(name, phone, fromLocTypeId, toLocTypeId, fromLocId, toLocId, fromAddress, toAddress, fare, IsReverse, doorNo);
                frm.OnDisplayRecord(id);

                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();
            }

            //   frm.AllowShowFocusCues = false;

        }



        public static void ShowBookingForm(int id, bool showOnDialog, string name, string phone, int? fromLocTypeId, int? toLocTypeId,
                                           int? fromLocId, int? toLocId, string fromAddress, string toAddress, decimal fare, bool IsReverse, string fromdoorNo, string toDoorNo, int? bookingTypeId, string email)
        {

            if (AppVars.objPolicyConfiguration.BookingFormType.ToInt() == 2)
            {
                frmBooking2 frm = new frmBooking2(name, phone, fromLocTypeId, toLocTypeId, fromLocId, toLocId, fromAddress, toAddress, fare, IsReverse, fromdoorNo, toDoorNo, email, null, false);
                frm.PickBookingTypeId = bookingTypeId;

                if (id != 0)
                {
                    // Booking objB=  General.GetObject<Booking>(c => c.Id == id);
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();


            }
            else
            {

                frmBooking frm = new frmBooking(name, phone, fromLocTypeId, toLocTypeId, fromLocId, toLocId, fromAddress, toAddress, fare, IsReverse, fromdoorNo, toDoorNo, email, null, false);
                frm.PickBookingTypeId = bookingTypeId;

                if (id != 0)
                {
                    // Booking objB=  General.GetObject<Booking>(c => c.Id == id);
                    frm.OnDisplayRecord(id);
                }
                frm.ControlBox = true;
                frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                frm.MaximizeBox = false;

                if (showOnDialog)
                {
                    frm.ShowDialog();
                }
                else
                    frm.Show();
            }

            //     frm.AllowShowFocusCues = false;

        }






        public static T GetObject<T>(Expression<Func<T, bool>> condition) where T : class
        {
           
                return new TaxiDataContext().GetTable<T>().FirstOrDefault(condition);
     

            //return new BLInfo<T, Taxi_Model.TaxiDataContext>()
            //         .Get<T>(condition);

        }



        public static void RefreshList<T>(string formName) where T : SetupBase
        {

            DockWindow dock = UI.MainMenuForm.MainMenuFrm.GetDockByName(formName);
            if (dock != null)
            {
                dock.Select();

                if (dock.ActiveControl != null)
                {
                    SetupBase frm = (T)dock.ActiveControl;
                    frm.PopulateData();
                }
            }

        }


        public static void RefreshListWithoutSelected<T>(string formName) where T : SetupBase
        {

            DockWindow dock = UI.MainMenuForm.MainMenuFrm.GetDockByName(formName);
            if (dock != null)
            {


                if (dock.Controls.Count == 1 && dock.Controls[0] != null)
                {
                    SetupBase frm = (T)dock.Controls[0];
                    frm.PopulateData();
                }
            }

        }

        public static void RefreshListWithoutSelectedOnRefreshData<T>(string formName) where T : SetupBase
        {

            DockWindow dock = UI.MainMenuForm.MainMenuFrm.GetDockByName(formName);
            if (dock != null)
            {


                if (dock.Controls.Count == 1 && dock.Controls[0] != null)
                {
                    SetupBase frm = (T)dock.Controls[0];
                    frm.RefreshData();
                }
            }

        }





        public static SetupBase GetForm<T>(string formName) where T : SetupBase
        {
            SetupBase frm = null;
            DockWindow dock = UI.MainMenuForm.MainMenuFrm.GetDockByName(formName);
            if (dock != null)
            {
                dock.Select();

                if (dock.ActiveControl != null)
                {
                    frm = (T)dock.ActiveControl;
                    //frm.PopulateData();
                }
            }

            return frm;
        }


        public static List<object[]> ShowFormMultiLister(IList list, string pkColumn)
        {

            Taxi_AppMain.frmLister frm = new Taxi_AppMain.frmLister(list, pkColumn, true);

            frm.ShowDialog();


            return frm.ListofData;

        }




        public static List<object[]> ShowMultiLister(IList list, string pkColumn)
        {

            UI.frmLister frm = new UI.frmLister(list, pkColumn, true);

            frm.ShowDialog();


            return frm.ListofData;

        }


        public static object[] ShowLister(IList list, string pkColumn)
        {

            UI.frmLister frm = new UI.frmLister(list, pkColumn, false);

            frm.ShowDialog();


            return frm.RowData;

        }


        public static object[] ShowFormLister(IList list, string pkColumn)
        {

            frmLister frm = new frmLister(list, pkColumn, false);

            frm.ShowDialog();


            return frm.RowData;

        }



        public static object[] ShowFormLister(IList list, string pkColumn, bool IsAutoSizeRows)
        {

            frmLister frm = new frmLister(list, pkColumn, false);
            frm.IsAutoSizeRows = true;
            frm.ShowDialog();


            return frm.RowData;

        }




        public static object[] ShowLister(IList list, string pkColumn, string[] hiddenColumns)
        {

            UI.frmLister frm = new UI.frmLister(list, pkColumn, false, hiddenColumns);

            frm.ShowDialog();


            return frm.RowData;

        }


        public static object[] ShowLister(IList list, string pkColumn, string[] hiddenColumns, string[] bestfitCols)
        {

            UI.frmLister frm = new UI.frmLister(list, pkColumn, false, hiddenColumns, bestfitCols);

            frm.ShowDialog();


            return frm.RowData;

        }



        public static string GetSharedNetworkPath()
        {
            string path = @"";
            Gen_SysPolicy_Configuration obj = GetQueryable<Gen_SysPolicy_Configuration>(null).FirstOrDefault();

            if (obj != null && !string.IsNullOrEmpty(obj.SharedNetworkPath))
                path += obj.SharedNetworkPath;

            return path;


        }




        public static string GetDocumentsFolderPath(int id)
        {
            string fullPath = GetSharedNetworkPath() + "\\TAXI\\Driver" + id.ToStr();

            return fullPath;


        }

    


   

        public static decimal CalculateDistanceVia(string origin, string destination)
        {


            if (origin.ToStr().Trim().Length == 0 || destination.ToStr().Trim().Length == 0)
                return 0.00m;

            decimal miles = 0.00m;


            if (origin.Contains("&"))
                origin = origin.Replace("&", "AND").Trim();


            if (destination.Contains("&"))
                destination = destination.Replace("&", "AND").Trim();



            if ((LastCalcDestination.Length > 0 && LastCalcDestination.Length > 0
              && origin == LastCalcOrigin && destination == LastCalcDestination) && LastCalcMileage > 0)
            {


                miles = LastCalcMileage;

                return miles;

            }


            try
            {

                bool exist = false;





                // offlinedistance
                if (AppVars.objPolicyConfiguration.EnableOfflineDistance.ToBool() && exist == false)
                {
                    string time = string.Empty;
                    miles = AppVars.frmMDI.GetDistanceAndTime(origin, destination, ref time);
                    exist = true;
                    LastCalcOrigin = origin;
                    LastCalcDestination = destination;
                    LastCalcMileage = miles;
                    LastCalEstTime = time;

                }

                if (exist == false)
                {
                    if (origin.Contains(".") && origin.Contains(",") && origin.Split(new char[] { ',' }).Count() == 2)
                    {

                    }
                 
                    else
                    {
                        origin += ", UK";
                    }


                    if (destination.Contains(".") && destination.Contains(",") && destination.Split(new char[] { ',' }).Count() == 2)
                    {


                    }
                  
                    else
                    {
                        destination += ", UK";
                    }

                    //  origin += ", UK";
                    // destination += ", UK";


                    if (AppVars.objPolicyConfiguration.MapType == 2)
                    {
                        ClsHereMap c = new ClsHereMap();
                        c.StartingPoint = origin;
                        c.EndingPoint = destination;
                        //  c.ViaString = via;
                        var resp = c.GenerateRoute(false);
                        string coordinates = string.Empty;
                        coordinates = resp.Coordinates;
                        miles = resp.Distance;



                    }
                    else
                    {

                        if (string.IsNullOrEmpty(directionKey))
                        {
                            using (TaxiDataContext db = new TaxiDataContext())
                            {

                                directionKey = db.ExecuteQuery<string>("select APIKey from mapkeys where maptype='google'").FirstOrDefault().ToStr().Trim();


                                if (directionKey.Length == 0)
                                    directionKey = " ";
                                else
                                    directionKey = "&key=" + directionKey;
                            }
                        }




                        string URL = "";
                        string alternatives = "";

                        URL = "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&units=imperial" + alternatives + directionKey + "&sensor=false";
                        URL = string.Format(URL, origin, destination);



                        try
                        {
                            WebRequest request = HttpWebRequest.Create(URL);

                            request.Headers.Add("Authorization", "");
                            System.Net.WebRequest.DefaultWebProxy = null;
                            request.Proxy = System.Net.WebRequest.DefaultWebProxy;



                            WebResponse response = request.GetResponse();
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                                string responseStringData = reader.ReadToEnd();
                                RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                                if (responseData != null && responseData.routes != null && responseData.routes.Count > 0)
                                {

                                    var objShortest = responseData.routes.OrderBy(x => x.legs[0].distance.value).FirstOrDefault();

                                    if (objShortest.legs[0].distance.text.ToStr().EndsWith(" mi"))
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.text.Replace(" mi", "").Trim())))), 1);

                                    }
                                    else
                                    {
                                        miles = Math.Round(Convert.ToDecimal((Convert.ToDouble((objShortest.legs[0].distance.value)) / 1609.344)), 1);
                                    }

                                    //  miles = objShortest.legs[0].distance.value;
                                    LastCalcOrigin = origin.Replace(", UK", "").Trim();
                                    LastCalcDestination = destination.Replace(", UK", "").Trim();
                                    LastCalcMileage = miles;
                                    LastCalEstTime = string.Empty;


                                }
                            }
                        }
                        catch
                        {



                        }


                    }
                  


                  
                }

               

            }
            catch
            {



            }

            return miles;
        }


        public static int? GetZoneIdTest(string address)
        {

          







            if (address.ToStr().Trim().Length == 0)
                return null;






            int? zoneId = null;

            try
            {
                if (address == "AS DIRECTED")
                {
                    zoneId = General.GetObject<Gen_Zone>(c => c.ZoneName == address).DefaultIfEmpty().Id;

                    if (zoneId == 0)
                        zoneId = null;
                }
                else
                {


                    if (zoneId == null)
                    {

                     
                        if (zoneId == null)
                        {

                            stp_getCoordinatesByAddressResult objCoord = null;

                            objCoord = new stp_getCoordinatesByAddressResult();
                            objCoord.Latitude =Convert.ToDouble( address.Split(',')[0]);
                            objCoord.Longtiude = Convert.ToDouble(address.Split(',')[1]);

                          

                            // Gen_Coordinate objCoord = General.GetObject<Gen_Coordinate>(c => c.PostCode == postCode);
                            if (objCoord != null)
                            {
                                double latitude = 0, longitude = 0;

                                latitude = Convert.ToDouble(objCoord.Latitude);
                                longitude = Convert.ToDouble(objCoord.Longtiude);






                                using (TaxiDataContext db = new TaxiDataContext())
                                {
                                    db.DeferredLoadingEnabled = false;

                                    var plot = (from a in db.Gen_Zones.Where(c => (c.ShapeType != null && c.ShapeType == "circle") || (c.MinLatitude != null && (latitude >= c.MinLatitude && latitude <= c.MaxLatitude)
                                                                       && (longitude <= c.MaxLongitude && longitude >= c.MinLongitude)))
                                                orderby a.PlotKind

                                                select new
                                                {
                                                    a.Id,
                                                    a.JobDueTime
                                                    ,
                                                    a.BlockDropOff
                                                }
                                              ).ToList();
                                    // select a.Id).ToArray<int>();
                                    //    }

                                    if (plot.Count() > 0)
                                    {
                                        using (TaxiDataContext DB = new TaxiDataContext())
                                        {
                                            foreach (var item in plot)
                                            {

                                                if (FindPoint(latitude, longitude, DB.Gen_Zone_PolyVertices.Where(c => c.ZoneId == item.Id).ToList()))
                                                {
                                                    zoneId = item.Id;
                                                    //   leadZoneDueTime = item.JobDueTime;
                                                    //IsOutoftownPlot = item.BlockDropOff.ToBool();
                                                    break;
                                                }
                                            }
                                        }


                                    }

                                }
                            }
                        }
                    }

                }


            }
            catch
            {


            }

            return zoneId;

        }



        public static int? GetZoneId(string address)
        {

            //if (AppVars.objPolicyConfiguration.EnablePDA.ToBool() == false)
            //    return null;

            //if (address != "AS DIRECTED" && string.IsNullOrEmpty(General.GetPostCodeMatch(address)))
            //    return null;

            //if (address.Contains(", UK"))
            //    address = address.Remove(address.LastIndexOf(", UK"));



            //int? zoneId = null;

            //try
            //{
            //    if (address == "AS DIRECTED")
            //    {

            //        zoneId = General.GetObject<Gen_Zone>(c => c.ZoneName == address).DefaultIfEmpty().Id;

            //        if (zoneId == 0)
            //            zoneId = null;
            //    }
            //    else
            //    {

            //      //  zoneId = AppVars.listOfAddress.FirstOrDefault(c => c.AddressLine1.Contains(address.ToStr().ToUpper())).DefaultIfEmpty().ZoneId;
            //        if (zoneId == null)
            //        {


            //            string postCode = General.GetPostCode(address);


            //            if (address.Contains(","))
            //            {

            //                string addr = address.Substring(0, address.LastIndexOf(',')).Trim();

            //                if (addr.ToStr().Trim() != string.Empty)
            //                {

            //                    zoneId = General.GetObject<Gen_Location>(c => c.PostCode == postCode && c.LocationName == addr).DefaultIfEmpty().ZoneId;
            //                }
            //            }


            //            if (zoneId == null)
            //            {

            //                Gen_Coordinate objCoord = General.GetObject<Gen_Coordinate>(c => c.PostCode == postCode);


            //                if (objCoord != null)
            //                {

            //                    double latitude = 0, longitude = 0;

            //                    latitude = Convert.ToDouble(objCoord.Latitude);
            //                    longitude = Convert.ToDouble(objCoord.Longitude);



            //                    var plot = (from a in General.GetQueryable<Gen_Zone>(c =>(c.ShapeType!=null && c.ShapeType=="circle")
            //                      ||  ( c.MinLatitude != null && (latitude >= c.MinLatitude && latitude <= c.MaxLatitude)
            //                                                       && (longitude <= c.MaxLongitude && longitude >= c.MinLongitude)))
            //                                orderby a.PlotKind

            //                                select a.Id).ToArray<int>();


            //                    if (plot.Count() > 0)
            //                    {
            //                        var list = (from p in plot
            //                                    join a in General.GetQueryable<Gen_Zone_PolyVertice>(null) on p equals a.ZoneId
            //                                    select a).ToList();




            //                        foreach (int plotId in plot)
            //                        {
            //                            if (FindPoint(latitude, longitude, list.Where(c => c.ZoneId == plotId).ToList()))
            //                            {
            //                                zoneId = plotId;
            //                                break;

            //                            }
            //                        }
            //                    }
            //                    else
            //                    {

            //                        if (AppVars.objPolicyConfiguration.PriorityPostCodes.ToStr().Length > 0)
            //                        {
            //                            string[] arr = AppVars.objPolicyConfiguration.PriorityPostCodes.Split(new char[] { ',' });



            //                            if (objCoord.PostCode.ToStr().Contains(" ") && arr.Contains(objCoord.PostCode.Split(new char[] { ' ' })[0]))
            //                            {


            //                                var zone = (from a in General.GetQueryable<Gen_Zone_PolyVertice>(null).AsEnumerable()


            //                                            select new
            //                                            {

            //                                                a.Gen_Zone.Id,
            //                                                a.Gen_Zone.ZoneName,
            //                                                DistanceMin = new LatLng(Convert.ToDouble(a.Latitude), Convert.ToDouble(a.Longitude)).DistanceMiles(new LatLng(Convert.ToDouble(objCoord.Latitude), Convert.ToDouble(objCoord.Longitude))),


            //                                            }).OrderBy(c => c.DistanceMin).FirstOrDefault();



            //                                if (zone != null)
            //                                    zoneId = zone.Id;
            //                            }


            //                        }


            //                    }

            //                }
            //            }
            //        }


            //    }


            //}
            //catch (Exception ex)
            //{


            //}

            //return zoneId;









            if (address.ToStr().Trim().Length == 0)
                return null;

            


            if (address != "AS DIRECTED" && string.IsNullOrEmpty(General.GetPostCodeMatch(address)))
            {
                int? zId = null;

                try
                {
                    using (TaxiDataContext db = new TaxiDataContext())
                    {
                        zId = db.Gen_Locations.FirstOrDefault(c => c.LocationName == address || (c.FullLocationName != null && c.FullLocationName == address)).DefaultIfEmpty().ZoneId;
                    }
                }
                catch
                {


                }

                if (zId != null)
                    return zId;
                else
                    return null;
            }


            if (address.Contains(", UK"))
                address = address.Remove(address.LastIndexOf(", UK"));



            int? zoneId = null;

            try
            {
                if (address == "AS DIRECTED")
                {
                    zoneId = General.GetObject<Gen_Zone>(c => c.ZoneName == address).DefaultIfEmpty().Id;

                    if (zoneId == 0)
                        zoneId = null;
                }
                else
                {
                   

                    if (zoneId == null)
                    {

                        string postCode = General.GetPostCode(address);


                        if (address.Contains(",") && AppVars.objPolicyConfiguration.PriorityPostCodes.ToStr().Trim().Length > 0)
                        {

                            string addr = address.Substring(0, address.LastIndexOf(',')).Trim();

                            if (addr.ToStr().Trim() != string.Empty)
                            {
                                zoneId = General.GetObject<Gen_Location>(c => c.PostCode == postCode && c.LocationName == addr).DefaultIfEmpty().ZoneId;
                            }
                        }

                        if (zoneId == null)
                        {

                            stp_getCoordinatesByAddressResult objCoord = null;


                            try
                            {
                                using (TaxiDataContext db = new TaxiDataContext())
                                {
                                    objCoord = db.stp_getCoordinatesByAddress(address, postCode).FirstOrDefault();


                                }
                            }
                            catch
                            {

                            }


                            // Gen_Coordinate objCoord = General.GetObject<Gen_Coordinate>(c => c.PostCode == postCode);
                            if (objCoord != null)
                            {
                                double latitude = 0, longitude = 0;

                                latitude = Convert.ToDouble(objCoord.Latitude);
                                longitude = Convert.ToDouble(objCoord.Longtiude);






                                using (TaxiDataContext db = new TaxiDataContext())
                                {
                                    db.DeferredLoadingEnabled = false;

                                    var plot = (from a in db.Gen_Zones.Where(c => (c.ShapeType != null && c.ShapeType == "circle") || (c.MinLatitude != null && (latitude >= c.MinLatitude && latitude <= c.MaxLatitude)
                                                                       && (longitude <= c.MaxLongitude && longitude >= c.MinLongitude)))
                                                orderby a.PlotKind

                                                select new
                                                {
                                                    a.Id,
                                                    a.JobDueTime
                                                    ,
                                                    a.BlockDropOff
                                                }
                                              ).ToList();
                                    // select a.Id).ToArray<int>();
                                    //    }

                                    if (plot.Count() > 0)
                                    {
                                        using (TaxiDataContext DB = new TaxiDataContext())
                                        {
                                            foreach (var item in plot)
                                            {

                                                if (FindPoint(latitude, longitude, DB.Gen_Zone_PolyVertices.Where(c => c.ZoneId == item.Id).ToList()))
                                                {
                                                    zoneId = item.Id;
                                                    //   leadZoneDueTime = item.JobDueTime;
                                                    //IsOutoftownPlot = item.BlockDropOff.ToBool();
                                                    break;
                                                }
                                            }
                                        }


                                    }

                                }
                            }
                        }
                    }

                }


            }
            catch 
            {


            }

            return zoneId;

        }

        //public static bool FindPoint(double pointLat, double pointLng, List<Gen_Zone_PolyVertice> PontosPolig)
        //{//                             X               y               
        //    int sides = PontosPolig.Count();
        //    int j = sides - 1;
        //    bool pointStatus = false;

        //    for (int i = 0; i < sides; i++)
        //    {
        //        if (PontosPolig[i].Longitude < pointLng && PontosPolig[j].Longitude >= pointLng ||
        //            PontosPolig[j].Longitude < pointLng && PontosPolig[i].Longitude >= pointLng)
        //        {
        //            if (PontosPolig[i].Latitude + (pointLng - PontosPolig[i].Longitude) /
        //                (PontosPolig[j].Longitude - PontosPolig[i].Longitude) * (PontosPolig[j].Latitude - PontosPolig[i].Latitude) < pointLat)
        //            {
        //                pointStatus = !pointStatus;
        //            }
        //        }
        //        j = i;
        //    }
        //    return pointStatus;
        //}


        public static List<Gen_Coordinate> GetCoordinatesListNullDistance()
        {
            List<Gen_Coordinate> list = new List<Gen_Coordinate>();

            using (TaxiDataContext db = new TaxiDataContext())
            {
                var postcodes = db.Bookings.Where(c => c.FromPostCode.StartsWith("CO")).Select(ARGS => ARGS.FromPostCode).Distinct().ToArray<string>();

             list=   db.Gen_Coordinates.Where(c => c.DistanceMiles == null).Where(a => postcodes.Contains(a.PostCode)).ToList();


            }

            return list;



        }


        public static void CancelWebBooking(string mobileNo,string refNo)
        {


            try
            {

                //if (AppVars.objPolicyConfiguration.PDANewWeekMessageByDay.ToStr().Trim().ToLower() == "new")
                //{
                //    new DataClassesOnlineVehicleDataContext().spUpdateBookingConfirmationFromApp3(0, refNo.ToLong(), "cancelfromsystem", 0.00m, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0.00m);
                //}
                //else
                //{
                //    new WebDataClassesDataContext().spUpdateBookingConfirmationFromApp3(0, refNo.ToLong(), "cancelfromsystem", 0.00m, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0.00m);
                //}



                if (mobileNo.Length > 6)
                {

                    string rtnMsg = string.Empty;
                    EuroSMS objSMS = new EuroSMS();
                    objSMS.Message = "Your Booking " + refNo + " has been Cancelled from our System";

                    string mobNo = mobileNo;
                    if (Debugger.IsAttached == false)
                    {

                        int idx = -1;
                        if (mobNo.StartsWith("044") == true)
                        {
                            idx = mobNo.IndexOf("044");
                            mobNo = mobNo.Substring(idx + 3);
                            mobNo = mobNo.Insert(0, "+44");
                        }

                        if (mobNo.StartsWith("07"))
                        {
                            mobNo = mobNo.Substring(1);
                        }

                        if (mobNo.StartsWith("044") == false || mobNo.StartsWith("+44") == false)
                            mobNo = mobNo.Insert(0, "+44");
                    }

                    objSMS.ToNumber = mobNo.Trim();
                    objSMS.Send(ref rtnMsg);
                }

            }
            catch (Exception ex)
            {


            }


        }


        public static string GetETADistanceWithDuration(string origin, string destination, string key, string vias = "")
        {
            string res = "";
            try
            {

                if (key.ToStr().Trim().Length == 0)
                    GetETAKey();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                if (AppVars.routemode == null && AppVars.objPolicyConfiguration.PreferredShortestDistance.ToBool() == false)
                    AppVars.routemode = "fastest;car";

                var obj = new
                {
                    originLat = Convert.ToDouble(origin.Split(',')[0]),
                    originLng = Convert.ToDouble(origin.Split(',')[1]),
                    destLat = Convert.ToDouble(destination.Split(',')[0]),
                    destLng = Convert.ToDouble(destination.Split(',')[1]),
                    defaultclientid = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(),
                    keys = key,
                    MapType = AppVars.objPolicyConfiguration.MapType.ToInt(),
                    sourceType = "dispatch",
                    routeType = AppVars.routemode.ToStr(),
                    vias
                };


                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                string API = Program.objLic.AppServiceUrl + "GetETADistanceWithDuration" + "?json=" + json;

                try
                {


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
                    request.ContentType = "application/json; charset=utf-8";
                    request.Accept = "application/json";
                    request.Method = WebRequestMethods.Http.Post;
                    request.Proxy = null;
                    request.ContentLength = 0;



                    using (WebResponse responsea = request.GetResponse())
                    {

                        using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                        {
                            res = sr.ReadToEnd().ToStr();
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("ssl"))
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API.Replace("https", "http"));
                        request.ContentType = "application/json; charset=utf-8";
                        request.Accept = "application/json";
                        request.Method = WebRequestMethods.Http.Post;
                        request.Proxy = null;
                        request.ContentLength = 0;



                        using (WebResponse responsea = request.GetResponse())
                        {

                            using (StreamReader sr = new StreamReader(responsea.GetResponseStream()))
                            {
                                res = sr.ReadToEnd().ToStr();
                            }
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText(Application.StartupPath + "\\GetETADistance_exception.txt", DateTime.Now.ToStr() + "," + ex.Message + Environment.NewLine);

                }
                catch
                {


                }

            }
            return res;

        }







        #region  ROUTE API Classes and Properties
        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class StartLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Distance2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Polyline
        {
            public string points { get; set; }
        }

        public class StartLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Step
        {
            public Distance2 distance { get; set; }
            public Duration2 duration { get; set; }
            public EndLocation2 end_location { get; set; }
            public string html_instructions { get; set; }
            public Polyline polyline { get; set; }
            public StartLocation2 start_location { get; set; }
            public string travel_mode { get; set; }
            public string maneuver { get; set; }
        }

        public class Leg
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string end_address { get; set; }
            public EndLocation end_location { get; set; }
            public string start_address { get; set; }
            public StartLocation start_location { get; set; }
            public List<Step> steps { get; set; }
            public List<object> via_waypoint { get; set; }
        }

        public class OverviewPolyline
        {
            public string points { get; set; }
        }

        public class Route
        {
            public Bounds bounds { get; set; }
            public string copyrights { get; set; }
            public List<Leg> legs { get; set; }
            public OverviewPolyline overview_polyline { get; set; }
            public string summary { get; set; }
            public List<object> warnings { get; set; }
            public List<object> waypoint_order { get; set; }
            public int RouteIndex { get; set; }
        }

        public class RootObject
        {
            public List<Route> routes { get; set; }
            public string status { get; set; }
        }
        public class RouteInformation
        {
            public List<string> Duration;
            public List<string> Distance;
            public List<double> Price;
        }

        #endregion

    }
}
