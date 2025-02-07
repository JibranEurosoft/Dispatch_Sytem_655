using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utils;

namespace Taxi_AppMain
{

    public class PostFlightDataForAlert
    {

        public string FlightNo = "";
        public string Arrival = "";
        public string departure { get; set; }
        public string date = "";
        public string alertUrl = "";
        public string clientId = "";
        public long jobId;
        public bool IsTest { get; set; }
    }



    public class FlightAlert
    {
        public PostFlightDataForAlert obj;
        public FlightAlert()
        {
            obj = new PostFlightDataForAlert();


        }
       
       
    
        public string date { get; set; }
        public bool IsTest { get; set; }

        public string CallAPI()
        {
            try
            {

                string FlightNo = obj.FlightNo;
                string departure = obj.departure.ToStr();
                string Arrival = obj.Arrival.ToStr();

                string FlightCode = Regex.Replace(FlightNo, @"\d", "");
                string FlightNum = Regex.Replace(FlightNo, @"\D", "");
                string FormattedFlightNo = FlightCode + "/" + FlightNum;
                FlightNo = FormattedFlightNo;

                obj.FlightNo = FlightNo;

                string appendDeparture = string.Empty;

                if (departure.ToStr().Trim().Length > 0)
                    appendDeparture = "&departure=" + departure.ToStr();

                string appendARRIVAL = "";

                if(Arrival.ToStr().Trim().Length>0)
                    appendARRIVAL=  "&Arrival=" + Arrival.ToStr();

             

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                string API = "https://cabtreasureappapi.co.uk/CabTreasureWebApi/Home/PostFlightData" + "?FlightNo=" + FlightNo + appendDeparture + appendARRIVAL + "&date=" + date + "&IsTest=" + IsTest;


                 API = "https://cabtreasureappapi.co.uk/CabTreasureWebApi/Home/PostFlightForAlert" + "?mesg="+json;

            
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
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }




    }
}
