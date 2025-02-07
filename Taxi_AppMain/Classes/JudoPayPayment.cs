using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class JudopayPayment
    {
        public long BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string UpdateUrl { get; set; }
        public string JudoId { get; set; }
        public string APIToken { get; set; }
        public string APISecret { get; set; }
        public string yourPaymentReference { get; set; }
        public string yourConsumerReference { get; set; }
        public bool IsRegisterCard { get; set; }

        public string Description { get; set; }


        public string BookingNo { get; set; }
        public string CardToken { get; set; }
        public bool ResponseInJson { get; set; }

        public string UserName { get; set; }

        public int SendType { get; set; }

        public string SubCompanyName { get; set; }

        public long ReturnBookingId { get; set; }
        public string ReturnBookingNo { get; set; }

        public decimal OneWayAmount { get; set; }
        public decimal ReturnAmount { get; set; }

        public DateTime? PickupDateTime { get; set; }


        public DateTime? ReturnPickupDateTime { get; set; }

        public string SendToJudoPay(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendToJudoPay?value=" + data;
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


        public string GetToJudoPay(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/GetToJudoPay?value=" + data;
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


                if (rtn.Contains("\""))
                    rtn = rtn.Replace("\"", "").Trim();

            }
            catch (Exception ex)
            {

            }

            return rtn;
        }


        public string SendToJudoPreAuth(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendToJudoPreAuth?value=" + data;
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


        public string ProcessByTokenToJudoPay(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/ProcessByTokenToJudoPay?value=" + data;
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


                if (rtn.Contains("\""))
                    rtn = rtn.Replace("\"", "").Trim();

            }
            catch (Exception ex)
            {

            }

            return rtn;
        }

    }
}
