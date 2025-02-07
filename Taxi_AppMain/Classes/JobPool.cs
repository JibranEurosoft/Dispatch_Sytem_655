using JobPoolAPICaller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi_Model;
using Utils;

namespace Taxi_AppMain
{

 

    public class JsonRoot
    {
        public object ContentEncoding { get; set; }
        public object ContentType { get; set; }
        public JobPoolAPICaller.TrackDriverDetail Data { get; set; }
        public int JsonRequestBehavior { get; set; }
        public object MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }


    public class JsonGRoot
    {
        public object ContentEncoding { get; set; }
        public object ContentType { get; set; }
        public object Data { get; set; }
        public int JsonRequestBehavior { get; set; }
        public object MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }


    public class JsonRootInner
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public JobPoolAPICaller.TrackDriver Data { get; set; }
    }

    public partial class PoolBooking
    {

        public long? PoolJobId;
        public long? JobId;
        public string JobProviderDefaultClientId;
        public string JobProviderClientName;
        public string JobAcceptorDefaultClientId;
        public string JobAcceptorClientName;
        public decimal JobPrice;
        public string JobStatus;
        public string PickupDatetime;
        public string PickupLocation;
        public string BookingJson;
        public string JobAcceptorConnectionString;
        public EventType EventType;
        public int SubCompanyId;
        public int VehicleTypeId;
        public string JobProviderClientCompanyNumber;
        public string VehicleName;
        public string UserName;

    }


    public enum EventType
    {
        UpdateBid = 0,
        AssignJob = 1,
        TransferredJob = 2,
        OfferedJob = 3,
        SendBackToOriginator = 4,
        UpdateJob = 5,
        CancelJob = 6,
        TrackDriver = 7,
        Recover=8
    }


    public class JobPool
    {
        public static string TransferJob(string clientId, long jobID, string userName)
        {
            string rtn = "";
            try
            {

                rtn = Transfer(new PoolBooking { JobProviderDefaultClientId = clientId, JobId = jobID, EventType = EventType.TransferredJob, UserName = userName });


            }
            catch (Exception exe)
            {
               
            }


            return rtn;
        }
        public static string SendBackToPool(string clientId, long jobID, string userName)
        {
            string rtn = "";
            try
            {



                rtn = SendBack(new PoolBooking { JobId = jobID, EventType = EventType.SendBackToOriginator, JobAcceptorDefaultClientId = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(), UserName = userName });

                


            }
            catch (Exception exe)
            {
               
            }


            return rtn;
        }

        public static string RecoverJob(string clientId, long jobID, string userName)
        {
            string rtn = "";
            try
            {



                rtn = Recover(new PoolBooking { JobId = jobID, EventType = EventType.Recover, JobAcceptorDefaultClientId = AppVars.objPolicyConfiguration.DefaultClientId.ToStr(), UserName = userName });




            }
            catch (Exception exe)
            {

            }


            return rtn;
        }

        public static string TrackDriver(string clientId, long jobID, string userName)
        {
            string rtn = "";

            try
            {


                try
                {

                  
                    rtn = Track(new PoolBooking() { JobId = jobID, EventType = EventType.TrackDriver });
                    


                }
                catch (Exception exe)
                {
                  
                }
            }
            catch (Exception ex)
            {
              

            }
            return rtn;

        }


        public static bool UpdateJob(string clientId, long jobID, string userName)
        {
            bool rtn = false;
            try
            {






                PoolBooking p = new PoolBooking();
              

                p.JobId = jobID;
                p.JobProviderDefaultClientId = clientId;
               
                p.EventType = EventType.UpdateJob;



                Update(p);





            }
            catch (Exception exe)
            {
                //  ENUtils.ShowMessage(exe.Message);
            }


            return rtn;
        }


        public static bool CancelJob(string clientId, long jobID, string userName)
        {
            bool rtn = false;
            try
            {



                PoolBooking p = new PoolBooking();
                p.JobId = jobID;
                p.JobProviderDefaultClientId = clientId;            
                
                p.EventType = EventType.CancelJob;             

                Cancel(p);








            }
            catch (Exception exe)
            {
               
            }


            return rtn;
        }




        private static string Transfer(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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

        private static string Cancel(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";





                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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

        private static string Update(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";



                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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

        private static string Track(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";





                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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

        private static string SendBack(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";





                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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

        private static string Recover(PoolBooking p)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";





                string json = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToStr();
                URL = baseUrl + "/api/Supplier/CallJobPool?json=" + json;
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








    }
}
