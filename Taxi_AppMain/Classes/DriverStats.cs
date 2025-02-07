using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_DriverStatsData
    {
     

        [Column(Storage = "_DriverId", DbType = "Int")]
        public int? DriverId { get; set; }
        [Column(Storage = "_DriverNo", DbType = "VarChar(30)")]
        public string DriverNo { get; set; }
        [Column(Storage = "_DriverName", DbType = "VarChar(100)")]

      
        public string DriverName { get; set; }
        [Column(Storage = "_JobsDone", DbType = "Int")]

        public string LoginTime { get; set; }
        public int? JobsDone { get; set; }
        [Column(Storage = "_Earned", DbType = "Decimal(0,0)")]
        public decimal? Earned { get; set; }
        [Column(Storage = "_WaitingSince", DbType = "VarChar(21)")]
        public string WaitingSince { get; set; }

      
    }
}
