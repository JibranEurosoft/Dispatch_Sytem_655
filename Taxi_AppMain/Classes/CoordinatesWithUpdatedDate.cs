using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{


    class GetBookingByDriverShifts
    {
        public long? Id { get; set; }
        public string BookingNo { get; set; }
        public DateTime? Pickupdatetime { get; set; }
        public DateTime? AcceptedDateTime { get; set; }
        public DateTime? Cleareddatetime { get; set; }
        public DateTime? POBDateTime { get; set; }
        public DateTime? STCDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }





    }


    public class CoordinatesWithUpdatedDate
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal? Speed { get; set; }
        public string ZoneId { get; set; }
        public int? driverid { get; set; }
        public long? JobId { get; set; }
    }
}
