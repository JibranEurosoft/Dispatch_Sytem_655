using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Taxi_AppMain
{
    public class HipPayments
    {
        public String cardnumber { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public String cvc { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string hostName { get; set; }
        public int amount { get; set; }
        public string purchase_currency { get; set; }
        public string merchant_order_id { get; set; }


        public string privateKey { get; set; }
        string OrderID = string.Empty;
        Gecko.GeckoWebBrowser browser = new Gecko.GeckoWebBrowser();
        public string Payment(bool IsTest)
        {

            string returnValue = string.Empty;
            try
            {

                //if (IsTest == true)
                //{
                //    privateKey = "private_9pM4A2j5PMfexAjShximK9Pd";
                //}
                //else
                //{
                //    ApiKey = "private_sSasEqZSQBkjHBKqftgEETtw";
                //}
                var payment = new
                {
                    Cardnumber = cardnumber,
                    Exp_month = exp_month,
                    exp_year = exp_year,
                    cvc = cvc,
                    CustomerName = CustomerName,
                    CustomerEmail = CustomerEmail,
                    amount = amount,
                    purchase_currency = purchase_currency,
                    merchant_order_id = merchant_order_id,
                    privatekey = privateKey
                };



                using (var client2 = new HttpClient())
                {

                    
                    client2.BaseAddress = new Uri("https://cabtreasureappapi.co.uk/CabTreasureWebApi/Home/MakeHipPayment");
             
                    HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, "?Cardnumber=" + payment.Cardnumber + "&Exp_month=" + payment.Exp_month + "&exp_year=" + payment.exp_year + "&cvc=" + payment.cvc + "&CustomerName=" + payment.CustomerName + "&CustomerEmail=" + payment.CustomerEmail + "&purchase_currency=" + payment.purchase_currency + "&amount=" + payment.amount + "&merchant_order_id=" + payment.merchant_order_id + "&privatekey=" + payment.privatekey);

                    Task<HttpResponseMessage> response2 = client2.SendAsync(request2);
                    var result2 = response2.Result;
                    var str2 = result2.Content.ReadAsStringAsync();
                    string data = string.Empty;
                    returnValue = str2.Result;
                  
                }

              

              

             //   returnValue = data;
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }


            return returnValue;
        }

        private void Browser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            if (e.Uri == browser.Document.Url)
            {

                if (e.Uri == new Uri("https://www.securesuite.co.uk/barclays/tdsecure/intro.jsp"))
                {
                    data = GetPaymentStatus(OrderID);
                }


            }
        }

        string data = string.Empty;


        public string GetPaymentStatus(string OrderID)
        {
            string returnValue = string.Empty;
            try
            {


                using (var client2 = new HttpClient())
                {

                    //client2.BaseAddress = new Uri("https://localhost:44389/Home/Hipsuccess");
                    client2.BaseAddress = new Uri("https://cabtreasureappapi.co.uk/CabTreasureWebApi/Home/Hipsuccess");
                    HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, "?OrderId=" + OrderID);


                    Task<HttpResponseMessage> response2 = client2.SendAsync(request2);
                    var result2 = response2.Result;
                    var str2 = result2.Content.ReadAsStringAsync();
                    string data = string.Empty;
                    returnValue = str2.Result;

                }
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }

            return returnValue;
        }

    }


    public class Order
    {
        public object order_id { get; set; }
    }
    public class Preflight
    {
        public bool requires_redirect { get; set; }
        public string redirect_user_to_url { get; set; }
        public string status { get; set; }
    }


 
   





    public class HipPaymentResponse
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public string @object { get; set; }
        public string source { get; set; }
        public Preflight preflight { get; set; }
        public Order order { get; set; }
        public string status { get; set; }
        public string order_status { get; set; }
        public string action { get; set; }
        public string order_id { get; set; }
        public int amount { get; set; }
        public string amount_formatted { get; set; }
        public string amount_currency { get; set; }
        public object settlement_amount { get; set; }
        public object settlement_amount_currency { get; set; }
        public string decline_reason { get; set; }
        public object settlement_exchange_rate { get; set; }
        public object authorization_code { get; set; }
        public bool test { get; set; }
        public DateTime created_at { get; set; }
    }
}
