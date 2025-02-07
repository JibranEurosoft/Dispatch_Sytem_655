using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class ClsOnlineBooking
    {
        public long Id;
        public string BookingNo;
        public DateTime? BookingDate;

        public DateTime? PickupDateTime;
        public string CustomerName;
        public string CustomerMobileNo;
        public string CustomerPhoneNo;
        public string CustomerEmail;


        

        public string FromAddress;
        public string FromDoorNo;
        public string FromStreet;
        public string ToAddress;
        public string ToDoorNo;
        public string ToStreet;
        public int? BookingStatusId;
        public int? BookingTypeId;
        public string CompanyName;
        public string VehicleType;
            public string ViaString;
        public string PaymentType;
        public decimal? FareRate;
        public decimal? Parking;
        public decimal? Waiting;
        public decimal? Extra;
        public decimal? CompanyPrice;
        public string SpecialRequirements;




     }
}
