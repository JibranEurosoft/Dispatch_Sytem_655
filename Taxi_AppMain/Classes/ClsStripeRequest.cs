using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripePayment
{
    public class ClsStripeRequest
    {
        public class CardDetailsEx
        {
            public string CardAddressCity;
            public string CardAddressLine1;
            public double amount;
            public string cardNumber;
            public string expiryDate;
            public string expiryMonth;
            public string expiryYear;
            public string cv2;
            public string currency;
            public string mobileNumber;
            public string RecieptemailAddress;
            public bool TestMode;
            public string paymentgateway;
            public string merchantid;
            public string merchantpassword;
            public string signature;
            public string cardtext;
            public string customerEmailAddress;
        }
    }
}
