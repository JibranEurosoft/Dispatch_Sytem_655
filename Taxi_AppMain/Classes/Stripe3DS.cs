using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Taxi_Model;

namespace Taxi_AppMain
{
    public class Stripe3DS
    {
        public string OperatorName { get; set; }
        public string BookingId { get; set; }
        public decimal Amount { get; set; }
        public decimal ActualAmount { get; set; }

        public decimal OneWayAmount { get; set; }
        public decimal ReturnAmount { get; set; }

        public DateTime? PickupDateTime { get; set; }
        public DateTime? ReturnPickupDateTime { get; set; }


        public string Currency { get; set; }
        public string UpdatePaymentURL { get; set; }
        public string Description { get; set; }
        public string APIkey { get; set; }
        public string APISecret { get; set; }
        public string ImageUrl { get; set; }

        public string paymentIntentId { get; set; }
        public string status { get; set; }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }


        public string PreAuthUrl { get; set; }

        public  string EncodeBASE64(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                .Replace('/', '_');
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }

        public string GetAuthorizeToken()
        {

            string json = EncodeBASE64(Newtonsoft.Json.JsonConvert.SerializeObject(this));

            return   ToTinyURLS("https://api-eurosofttech.co.uk/StripePayment-api/home/StripeCheckout?data=" + json);

        }


        public string GetPayByLinkJson()
        {

            return   EncodeBASE64(Newtonsoft.Json.JsonConvert.SerializeObject(this));

         

        }

        public bool GetAndEmailAuthorizeToken(string subject,string body,string from,string to,Gen_SubCompany objSubcompany)
        {
            bool rtn = true;
            try
            {
                string json = EncodeBASE64(Newtonsoft.Json.JsonConvert.SerializeObject(this));

                string url = ToTinyURLS("https://api-eurosofttech.co.uk/StripePayment-api/home/StripeCheckout?data=" + json);

             //   Email.Send(subject, body + "<br/>" + url, from, to, objSubcompany);
            }
            catch(Exception ex)
            {
                rtn = false;
            }
            return rtn;
        
        }


        public  string SendPreAuthLink(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";


                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendPreAuthLink?value=" + data;


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
        public string SendPayByLink(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendPayByLink?value=" + data;
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


        protected string ToTinyURLS(string txt)
        {
            Regex regx = new Regex("https://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);

            MatchCollection mactches = regx.Matches(txt);

            foreach (Match match in mactches)
            {
                string tURL = MakeTinyUrl(match.Value);
                txt = txt.Replace(match.Value, tURL);
            }

            return txt;
        }

        public static string MakeTinyUrl(string Url)
        {
            string text;
            try
            {
                if (Url.Length <= 12)
                {
                    return Url;
                }
                if (!Url.ToLower().StartsWith("https") && !Url.ToLower().StartsWith("ftp"))
                {
                    Url = "https://" + Url;
                }

                WebRequest request = HttpWebRequest.Create("http://tinyurl.com/api-create.php?url=" + Url);
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {



                    text = reader.ReadToEnd();
                }
                return text;
                //
            }
            catch (Exception)
            {
                return Url;
            }
        }


    }
    public class StripeKonnectPay
    {
        public string OperatorName { get; set; }
        public string BookingId { get; set; }
        public decimal Amount { get; set; }
        public decimal ActualAmount { get; set; }

        public decimal OneWayAmount { get; set; }
        public decimal ReturnAmount { get; set; }

        public DateTime? PickupDateTime { get; set; }
        public DateTime? ReturnPickupDateTime { get; set; }


        public string Currency { get; set; }
        public string UpdatePaymentURL { get; set; }
        public string Description { get; set; }
        public string APIkey { get; set; }
        public string APISecret { get; set; }
        public string ImageUrl { get; set; }

        public string paymentIntentId { get; set; }
        public string status { get; set; }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }


        public string PreAuthUrl { get; set; }

        public string EncodeBASE64(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                .Replace('/', '_');
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }




        protected string ToTinyURLS(string txt)
        {
            Regex regx = new Regex("https://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);

            MatchCollection mactches = regx.Matches(txt);

            foreach (Match match in mactches)
            {
                string tURL = MakeTinyUrl(match.Value);
                txt = txt.Replace(match.Value, tURL);
            }

            return txt;
        }

        public static string MakeTinyUrl(string Url)
        {
            string text;
            try
            {
                if (Url.Length <= 12)
                {
                    return Url;
                }
                if (!Url.ToLower().StartsWith("https") && !Url.ToLower().StartsWith("ftp"))
                {
                    Url = "https://" + Url;
                }

                WebRequest request = HttpWebRequest.Create("http://tinyurl.com/api-create.php?url=" + Url);
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {



                    text = reader.ReadToEnd();
                }
                return text;
                //
            }
            catch (Exception)
            {
                return Url;
            }
        }




    }
    public class StripePaymentRequestDto
    {
        public bool isAuthorized { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public int countryId { get; set; }
        public string connectedAccountId { get; set; }
        public decimal applicationFee { get; set; }
        public decimal otherCharges { get; set; }
        public long bookingId { get; set; }
        public string bookingRef { get; set; }
        public long amount { get; set; }
        public decimal displayAmount { get; set; }
        [MaxLength(3)]
        public string currency { get; set; }
        public string description { get; set; }
        public string paymentMethodId { get; set; }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string lastfour { get; set; }
        public string expiry { get; set; }
        public string cardtype { get; set; }
        public string companyName { get; set; }
        public string defaultClientId { get; set; }
        public string location { get; set; }
        public string verificationWebhook { get; set; }
        public string paymentUpdateWebhook { get; set; }
        public string UpdatePaymentURL { get; set; }
        public string PreAuthUrl { get; set; }
        public string OperatorName { get; set; }
        public decimal? ReturnAmount { get; set; }
        public string PayByDispatch { get; set; }
        public StripePaymentRequestDto() { }

        public string EncodeBASE64(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                .Replace('/', '_');
        }

        public static string Decode(string text)
        {
            text = text.Replace('_', '/').Replace('-', '+');
            switch (text.Length % 4)
            {
                case 2:
                    text += "==";
                    break;
                case 3:
                    text += "=";
                    break;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }




        protected string ToTinyURLS(string txt)
        {
            Regex regx = new Regex("https://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);

            MatchCollection mactches = regx.Matches(txt);

            foreach (Match match in mactches)
            {
                string tURL = MakeTinyUrl(match.Value);
                txt = txt.Replace(match.Value, tURL);
            }

            return txt;
        }

        public static string MakeTinyUrl(string Url)
        {
            string text;
            try
            {
                if (Url.Length <= 12)
                {
                    return Url;
                }
                if (!Url.ToLower().StartsWith("https") && !Url.ToLower().StartsWith("ftp"))
                {
                    Url = "https://" + Url;
                }

                WebRequest request = HttpWebRequest.Create("http://tinyurl.com/api-create.php?url=" + Url);
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {



                    text = reader.ReadToEnd();
                }
                return text;
                //
            }
            catch (Exception)
            {
                return Url;
            }
        }
        public string GetAuthorizeTokenKP(StripePaymentRequestDto obj)
        {
            string StripeAPIBaseURL = System.Configuration.ConfigurationManager.AppSettings["StripeExpressBaseURL"];
            string json = EncodeBASE64(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

            return ToTinyURLS(StripeAPIBaseURL + "/checkout?data=" + json);
            //return ToTinyURLS("https://www.cabtreasure-stripe.co.uk/ExpressAccountTest/checkout?data=" + json);


        }

        public string SendPreAuthLinkKP(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";


                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendPreAuthLinkKP?value=" + data;
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
        public string SendPayByLinkKP(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendPayByLinkDriverAppKP?value=" + data;
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
        public string SendPayByLinkKPReturn(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/SendPayByLinkKP?value=" + data;
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
        public string ProcessPaymentWithRegisterCustomer(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/ProcessPaymentWithRegisterCustomer?value=" + data;

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
    public class PaymentCaptureDto
    {
        public long bookingId { get; set; }
        public string bookingRef { get; set; }
        public string description { get; set; }
        public int countryId { get; set; }
        public string connectedAccountId { get; set; }
        public decimal applicationFee { get; set; }
        public decimal otherCharges { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public long amount { get; set; }
        public decimal displayAmount { get; set; }
        [MaxLength(3)]
        public string currency { get; set; }
        public string defaultClientId { get; set; }
        public string location { get; set; }
        public string companyName { get; set; }
        public string paymentIntentId { get; set; }
        public string status { get; set; }

        public PaymentCaptureDto() { }

        public PaymentCaptureResponse CapturePayment(string data)
        {
            PaymentCaptureResponse resp = null;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/ProcessPreAuthPaymentKP?value=" + data;


                WebRequest request = HttpWebRequest.Create(URL);
                request.Headers.Add("Authorization", "");
                System.Net.WebRequest.DefaultWebProxy = null;
                request.Proxy = System.Net.WebRequest.DefaultWebProxy;

                WebResponse response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string rs = reader.ReadToEnd();
                    resp = new JavaScriptSerializer().Deserialize<PaymentCaptureResponse>(rs);

                }
            }
            catch (Exception ex)
            {

            }

            return resp;
        }

    }
    public class PaymentCaptureResponse
    {

        public string status { get; set; }

        public decimal amount { get; set; }
        public bool isSuccess { get; set; }
        public string paymentId { get; set; }
        public string error { get; set; }

    }
    public class RegisterCardDto
    {
        public int countryId { get; set; }
        public string connectedAccountId { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public string description { get; set; }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string companyName { get; set; }
        public string defaultClientId { get; set; }
        public string location { get; set; }
        public string PreAuthUrl { get; set; }
        public string UpdatePaymentURL { get; set; }
        public string paymentUpdateWebhook { get; set; }
        public bool sendLinkToCustomer { get; set; }
        public long DBCustomerID { get; set; }
        public RegisterCardDto() { }


        public string RegisterCard(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/RegisterCardKP?value=" + data;

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

    public class CanclePaymentDTO
    {

        public long bookingId { get; set; }
        public string bookingRef { get; set; }
        public string description { get; set; }
        public int countryId { get; set; }
        public string connectedAccountId { get; set; }
        public decimal applicationFee { get; set; }
        public decimal otherCharges { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public long amount { get; set; }
        public decimal displayAmount { get; set; }

        public string currency { get; set; }
        public string defaultClientId { get; set; }
        public string location { get; set; }
        public string companyName { get; set; }
        public string paymentIntentId { get; set; }
        public string status { get; set; }

        public string CanclePreAuthPayment(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/CancelPaymentKP?value=" + data;


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
    public class RefundPaymentDto
    {
        public long bookingId { get; set; }
        public string bookingRef { get; set; }
        public string description { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public long amount { get; set; }
        [MaxLength(3)]
        public string currency { get; set; }
        public string defaultClientId { get; set; }
        public string location { get; set; }
        public string companyName { get; set; }
        public string paymentIntentId { get; set; }
        public string status { get; set; }
        public bool isRefundApplicationFee { get; set; }
        public RefundPaymentDto() { }

        public string RefundPayment(string data)
        {
            string rtn = string.Empty;
            try
            {
                string URL = "";

                string baseUrl = System.Configuration.ConfigurationManager.AppSettings["huburl"].ToString();

                URL = baseUrl + "/api/Supplier/RefundPaymentKonnectPay?value=" + data;

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
