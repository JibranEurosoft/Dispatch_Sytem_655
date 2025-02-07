using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
   public class Trip
    {
        public long TripId;
        public string TripNo;
        public bool followSequence;
        public List<Jobs> jobs;
        public int DriverId;
        public int TripStatusId;
        public string Message;
    }

    public class Jobs
    {
        public string PickupDateTime;
        public string Cust;
        public int Passengers;
        public string Pickup;
        public string Destination;
        public string BookingNo;
        public string Special;
        public string Payment;
        public string Journey;
        public decimal Fares;
        public string Account;
        public string Vehicle;
        public string Lug;
        public string BookingType;
        public string JobId;
        public string SubCompanyId;
        public int Did;
        public bool ShowFares;
        public bool HideAccountName;

        public int JStatus;


    }


    public class AppJobStatus
    {

        public static  int ACCEPT = 4;
        public static  int ONROUTE = 5;
        public static  int ARRIVED = 6;
        public static  int POB = 7;
        public static  int STC = 8;
        public static  int NOPICKUP = 13;
        public static  int NOSHOW = 10;
        public static  int CLEAR = 2;
        public static  int REJECT = 11;



    }

}
