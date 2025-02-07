using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class FlightData
    {
        public DateTime ScheduleDateTime;
        public DateTime DelayedDateTime;
        public string ArrivalTerminal;
        public string ArrivingFrom;
        public string FlightNo;
        public string DefaultClientId;
        public string APIKey = "";
        public string Status = "";
        public string DateTime = "";
        public string Message = "";
        public int AllowanceMins = 0;
        public string FlightInformation;
        public string InputDateTime;
    }
}
