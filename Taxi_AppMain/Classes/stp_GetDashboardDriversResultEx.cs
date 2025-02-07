using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_GetDashboardDriversResultEx
    {
        public stp_GetDashboardDriversResultEx() { }

        [Column(Storage = "_QueueDateTime", DbType = "DateTime")]
        public DateTime? QueueDateTime { get; set; }
        [Column(Storage = "_OnJob", DbType = "VarChar(200)")]
        public string OnJob { get; set; }
        [Column(Storage = "_IsPanic", DbType = "Bit NOT NULL")]
        public bool IsPanic { get; set; }
        [Column(Storage = "_VehicleType", DbType = "VarChar(100)")]
        public string VehicleType { get; set; }
        [Column(Storage = "_HasPDA1", DbType = "Bit")]
        public bool? HasPDA1 { get; set; }
        [Column(Storage = "_VehicleTypeId1", DbType = "Int")]
        public int? VehicleTypeId1 { get; set; }
        [Column(Storage = "_CurrentJobId", DbType = "BigInt")]
        public long? CurrentJobId { get; set; }
        [Column(Storage = "_LoginFrom", DbType = "VarChar(20)")]
        public string LoginFrom { get; set; }
        [Column(Storage = "_DriverLoginId", DbType = "BigInt NOT NULL")]
        public long DriverLoginId { get; set; }
        [Column(Storage = "_backgroundcolor", DbType = "VarChar(30)")]
        public string backgroundcolor { get; set; }
        [Column(Storage = "_WaitSinceOn", DbType = "DateTime")]
        public DateTime? WaitSinceOn { get; set; }
        [Column(Storage = "_workstatus", DbType = "VarChar(50)")]
        public string workstatus { get; set; }
        [Column(Storage = "_VehicleTypeId", DbType = "Int")]
        public int? VehicleTypeId { get; set; }
        [Column(Storage = "_HasPDA", DbType = "Bit")]
        public bool? HasPDA { get; set; }
        [Column(Storage = "_DriverName", DbType = "VarChar(100)")]
        public string DriverName { get; set; }
        [Column(Storage = "_orderno", DbType = "Int")]
        public int? orderno { get; set; }
        [Column(Storage = "_plotdate", DbType = "DateTime")]
        public DateTime? plotdate { get; set; }
        [Column(Storage = "_driverno", DbType = "VarChar(30)")]
        public string driverno { get; set; }
        [Column(Storage = "_driverid", DbType = "Int NOT NULL")]
        public int driverid { get; set; }
        [Column(Storage = "_ShortName", DbType = "VarChar(50)")]
        public string ShortName { get; set; }
        [Column(Storage = "_ZoneName", DbType = "VarChar(50)")]
        public string ZoneName { get; set; }
        [Column(Storage = "_id", DbType = "Int NOT NULL")]
        public int id { get; set; }
        [Column(Storage = "_driverworkstatusid", DbType = "Int")]
        public int? driverworkstatusid { get; set; }
        [Column(Storage = "_LoginDateTime", DbType = "DateTime")]
        public DateTime? LoginDateTime { get; set; }


        [Column(Storage = "_VehicleID", DbType = "VarChar(100)")]
        public string VehicleID { get; set; }
    }
}
