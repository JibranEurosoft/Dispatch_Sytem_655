using System;
using Utils;


namespace Taxi_AppMain
{
   public  class EuroSMS
    {
        private string _SMSUserName;

        public string SMSUserName
        {
            get { return _SMSUserName; }
            set { _SMSUserName = value; }
        }
        private string _SMSUserPassword;
        
        public string SMSUserPassword
        {
            get { return _SMSUserPassword; }
            set { _SMSUserPassword = value; }
        }

       public static string SMSFromCaption="";


       private int _BookingSMSAccountType;

       public int BookingSMSAccountType
       {
           get { return _BookingSMSAccountType; }
           set { _BookingSMSAccountType = value; }
       }

       public EuroSMS(string userName,string password,string fromCaption)
       {

           this.SMSUserName = userName;
           this.SMSUserPassword = password;
           SMSFromCaption = fromCaption;


       }
     
       public EuroSMS()
       {
          
       }

       private string _Message;

       public string Message
       {
           get { return _Message; }
           set { _Message = value; }
       }

       private string _ToNumber;

       public string ToNumber
       {
           get { return _ToNumber; }
           set {
          
               _ToNumber = value;
         
             }
       }

       private string _CountryCode;

       public string CountryCode
       {
           get { return _CountryCode; }
           set { _CountryCode = value; }
       }


      


       public bool Send(ref string returnMsg)
       {
           bool rtn = true;


         
           try
           {
                               
                       if (Message.Length > 450)
                       {
                           Message = Message.Substring(0, 447);
                           Message += "...";
                       }


                    General.SendMessageToPDA("request dispatchsms=" + this._ToNumber.ToStr() + "=" + this.Message);
                  
             
           }
           catch (Exception ex)
           {
               returnMsg = ex.Message;
              


               rtn = true;
           }


           return rtn;
       }


     
     


     
    }
}
