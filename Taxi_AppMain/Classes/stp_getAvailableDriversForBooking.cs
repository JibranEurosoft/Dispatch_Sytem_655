using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_getavailabledriversForBooking
    {
        public stp_getavailabledriversForBooking() { }

    
        public int driverid { get; set; }
       
        public string driverno { get; set; }
       
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }

        public double latitude { get; set; }
   
        public double longitude { get; set; }
      
        public double speed { get; set; }
    
        public int? driverworkstatusid { get; set; }
   
        public decimal distance { get; set; }
    }
}
