using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Taxi_AppMain
{
    class IVRCaller
    {
        public IVRCaller()
        {


        }
        public static IVRInfo SaveIVRInfo(IVRInfo obj)
        {
        


            try
            {
                try
                {
                    string Urls = "http://eurlic.co.uk/license/api/Cab/SaveIVRInfo";
                    var baseAddress = new Uri(Urls);
                    var json = string.Empty;
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                   


                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Urls);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Proxy = null;
                    httpWebRequest.Headers.Add("Authorization", "Basic " + "Y2FidHJlYXN1cmU6Y2FidHJlYXN1cmU5ODcwIUAj");
                    //   string usernamePassword = Base64Encode("cabtreasure:cabtreasure9870!@#");
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
                        obj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IVRInfo>(result);
                    }

                }
                catch (Exception ex)
                {
                   

                }


            
            }
            catch (Exception ex)
            {
              


            }


            return obj;

        }


        public static IVRInfo GetIVRInfo(IVRInfo obj)
        {
          
           

           
                try
                {
                    string Urls = "http://eurlic.co.uk/license/api/Cab/GetIVRInfo";
                    var baseAddress = new Uri(Urls);
                    var json = string.Empty;
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(Urls);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Proxy = null;
                    httpWebRequest.Headers.Add("Authorization", "Basic " + "Y2FidHJlYXN1cmU6Y2FidHJlYXN1cmU5ODcwIUAj");
                    //   string usernamePassword = Base64Encode("cabtreasure:cabtreasure9870!@#");
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
                    obj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IVRInfo>(result);
                    }

                }
                catch (Exception ex)
                {
                  


                }

             return obj;

        }

    }
}
