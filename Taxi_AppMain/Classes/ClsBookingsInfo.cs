using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{

    public class BookingSummary
    {
        public string label;
        public string value;
        public string fieldname;
        public string isvisible;
        public string isedit;


       
    }

    public class ClsBookingsInfo
    {

        public List<Taxi_Model.stp_GetBookingsDataResult> listofBookings = null;
        public string flightnumber;
        public long JobId;
        public string BookingNo;
        public string NewPickupDate;
        public string soundfilename;
        public bool shownotification;
        public bool shownotificationimage;
        public int notificationappearon = 0;
        public string notificationtitle;
        public string notificationcontent;
        public string notificationcolor;
        public string notificationimage;
        public int notificationautoclosedelay;
    }
}
