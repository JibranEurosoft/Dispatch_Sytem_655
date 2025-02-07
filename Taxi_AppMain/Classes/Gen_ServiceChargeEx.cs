using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
  
    public class Gen_ServiceChargeEx
    {
     

        public int Id { get; set; }
        public decimal? FromValue { get; set; }
        public decimal? ToValue { get; set; }
        public decimal? ServiceChargePercent { get; set; }
        public decimal? ServiceChargeAmount { get; set; }
        public bool? AmountWise { get; set; }
        public bool? IsAccount { get; set; }
        public int? SubCompanyId { get; set; }


        public decimal? AirportBookingFee { get; set; }


       
    }
}
