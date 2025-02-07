using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Taxi_AppMain
{
    //Request Classes
    public class SumupPaymentRequest
    {


        public SumupPaymentRequest()
        {
            GateWayCredentials = new GateWayCredentials();
            CheckoutsData = new CheckoutsData();
            PaymentData = new PaymentData();
           
        }

        public int PaymentGatewayId { get; set; }
        public string RequestMode { get; set; }
        public GateWayCredentials GateWayCredentials { get; set; }
        public CheckoutsData CheckoutsData { get; set; }
        public PaymentData PaymentData { get; set; }
    }

    public class GateWayCredentials
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }        
    }

    public class PaymentData
    {
        public string payment_type { get; set; }
        public card card { get; set; }
       
    }

    public class card
    {
        public string cvv { get; set; }
        public string expiry_month { get; set; }
        public string expiry_year { get; set; }
        public string number { get; set; }
        public string name { get; set; }        
    }

    public class CheckoutsData
    {
        public int JobId { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string pay_to_email { get; set; }
        public string description { get; set; }
        
    }

 
    public class PaymentGatewayResponse<T>
    {
        private T _responseData;
        private int _responseCode;
        private bool _status = true;
        private string _responseText = string.Empty;
        public PaymentGatewayResponse()
        {
        }
        public PaymentGatewayResponse(ref T responseData)
        {
            _responseData = responseData;
        }
      
        public bool HasError
        {
            get { return _status; }
            set { _status = value; }
        }
        
        public int ResponseCode
        {
            get { return _responseCode; }
            set { _responseCode = value; }
        }
      
        public string ResponseText
        {
            get { return _responseText; }
            set { _responseText = value; }
        }
       
        public T ResponseData
        {
            get { return _responseData; }
            set { _responseData = value; }
        }
    }

    public class SummupCardPaymentResponse
    {
        public string Transaction_Id { get; set; }
        public string Transaction_Code { get; set; }
    }


}
