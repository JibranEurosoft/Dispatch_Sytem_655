using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_AppMain
{
   public  class ScheduleMessage
    {
		public int Id { get; set; }

		public System.Nullable<System.DateTime> FromDateTime { get; set; }

		public System.Nullable<System.DateTime> TillDateTime { get; set; }

		public System.Nullable<int> Interval { get; set; }

		public System.Nullable<int> ScheduleFor { get; set; }

		public string Message { get; set; }

	}
}
