using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_AppMain
{
    public class IVRBookingDetails
    {
        public long BookingId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string PickUp { get; set; }

        public string Destination { get; set; }

       
    }


    public class GenNotification
    {
        public string NotificationLabel { get; set; }
        public string NotificationContent { get; set; }
       


        public object Data { get; set; }

        public string HtmlData { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool ShowButtons { get; set; }
        public object Tag { get; set; }
    }

    public class IVRNotificationClient
    {
        public string NotificationType { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime TimeStamp { get; set; }


        public string BookingJson { get; set; }
    }
    public class IVRNotification : IVRBookingDetails
    {
        public string BookingNumber { get; set; }

        public string PickUpDateTime { get; set; }

    }

    public class IVRInfo
    {
        public string ClientId;
        public string ClientName;
        public string ClientConn;
        public string IVRNumbers;
        public string CloudUrl;
        public bool ReleaseMode;
        public bool CalculateFares;
        public string Reason;
    }


    public class IVRResponse
    {
        public string ClientCode;
        public string DefaultClientId;
        public string IVRNumbers;
        public string IsReleaseMode;
        public string CalculateFares;

    }
}
