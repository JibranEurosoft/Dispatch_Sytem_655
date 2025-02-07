using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SMSAPI
{
  public  class SMS_ClickATell
    {
        string url = "http://api.clickatell.com/http/sendmsg";
        string userName;
        string password;
        string apikey;
        string senderName;
        string ToNumber;
        string SMSMessage;

        public string seven_bit_message(string username, string password, string api_id, string from, string to, string message)
        {
            int concat = 1;

            if (message.Length > 150 && message.Length < 300)
                concat = 2;
            else if (message.Length > 300 && message.Length < 450)
                concat = 3;
            else if (message.Length > 450)
                concat = 4;

            string data = "";
            //data += "user=" + HttpUtility.UrlEncode(username, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            //data += "&password=" + HttpUtility.UrlEncode(password, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            //data += "&api_id=" + HttpUtility.UrlEncode(api_id, System.Text.Encoding.GetEncoding("ISO-8859-1"));

            //if (!string.IsNullOrEmpty(from))
            //{
            //    data += "&from=" + HttpUtility.UrlEncode(from, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            //}


            //data += "&to=" + HttpUtility.UrlEncode(to, System.Text.Encoding.GetEncoding("ISO-8859-1"));

            //data += "&text=" + HttpUtility.UrlEncode(character_resolve(message), System.Text.Encoding.GetEncoding("ISO-8859-1"));
            //data += "&concat=" + HttpUtility.UrlEncode(concat.ToStr(), System.Text.Encoding.GetEncoding("ISO-8859-1"));

            return data;
        }


        //public string seven_bit_message(string username, string password, string msisdn, string message)
        //{




        //    string data = "";
        //    data += "username=" + HttpUtility.UrlEncode(username, System.Text.Encoding.GetEncoding("ISO-8859-1"));
        //    data += "&password=" + HttpUtility.UrlEncode(password, System.Text.Encoding.GetEncoding("ISO-8859-1"));
        //    data += "&message=" + HttpUtility.UrlEncode(character_resolve(message), System.Text.Encoding.GetEncoding("ISO-8859-1"));
        //    data += "&msisdn=" + msisdn;
        //    data += "&want_report=1";
        //    data += "&sender=" + HttpUtility.UrlEncode(character_resolve(AppVars.objSMSConfiguration.BuikSMSCaption.ToStr()), System.Text.Encoding.GetEncoding("ISO-8859-1"));

        //    return data;
        //}

        public string character_resolve(string body)
        {
            Hashtable chrs = new Hashtable();
            chrs.Add('Ω', "Û");
            chrs.Add('Θ', "Ô");
            chrs.Add('Δ', "Ð");
            chrs.Add('Φ', "Þ");
            chrs.Add('Γ', "¬");
            chrs.Add('Λ', "Â");
            chrs.Add('Π', "º");
            chrs.Add('Ψ', "Ý");
            chrs.Add('Σ', "Ê");
            chrs.Add('Ξ', "±");

            string ret_str = "";
            foreach (char c in body)
            {
                if (chrs.ContainsKey(c))
                {
                    ret_str += chrs[c];
                }
                else
                {
                    ret_str += c;
                }
            }
            return ret_str;
        }

   
        public string Send()
        {

            string result = null;
            try
            {
                string data = seven_bit_message(userName, password, apikey,
                                                  senderName,ToNumber, SMSMessage);



                byte[] buffer = Encoding.Default.GetBytes(data);

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);



                WebReq.Method = "POST";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                WebReq.ContentLength = buffer.Length;
                WebReq.Proxy = null;
                Stream PostData = WebReq.GetRequestStream();

                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();




                Stream Response = WebResp.GetResponseStream();
                StreamReader _Response = new StreamReader(Response);
                result = _Response.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                //Console.WriteLine(ex.Message);
            }


            if (result.StartsWith("ERR"))
            {

                if (result.StartsWith("ERR: 001") == true)
                {


                }
                else
                {


                }

            }
            return result.Trim() + "\n";
        }



    }
}
