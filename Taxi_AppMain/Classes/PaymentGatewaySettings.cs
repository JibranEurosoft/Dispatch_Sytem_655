using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class PaymentGatewaySettings
    {

        public int Id;
        public int? PaymentGatewayId;

        public bool? ShowPreAuthBySMS;
        public bool? ShowPreAuthByEmail;

        public bool? ShowRegisterBySMS;
        public bool? ShowRegisterByEmail;

        public bool? ShowPayBySMS;
        public bool? ShowPayByEmail;



    }
}
