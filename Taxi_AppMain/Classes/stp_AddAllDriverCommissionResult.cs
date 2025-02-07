using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public class stp_AddAllDriverCommissionResult
    {
        public stp_AddAllDriverCommissionResult()
        {
            
        }

        [Column(Storage = "_Id", DbType = "Int NOT NULL")]
        public int Id { get; set; }
        [Column(Storage = "_Driver", DbType = "VarChar(131)")]
        public string Driver { get; set; }
        [Column(Storage = "_PDARent", DbType = "Decimal(18,2) NOT NULL")]
        public decimal PDARent { get; set; }
        [Column(Storage = "_DriverCommissionPerBooking", DbType = "Decimal(18,0)")]
        public decimal? DriverCommissionPerBooking { get; set; }
        [Column(Storage = "_Email", DbType = "VarChar(50)")]
        public string Email { get; set; }
        [Column(Storage = "_OldBalance", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OldBalance { get; set; }
        [Column(Storage = "_InitialBalance", DbType = "Decimal(18,2) NOT NULL")]
        public decimal InitialBalance { get; set; }
        [Column(Storage = "_JobsTotal", DbType = "Decimal(18,2) NOT NULL")]
        public decimal JobsTotal { get; set; }
        [Column(Storage = "_RentDue", DbType = "Decimal(18,2) NOT NULL")]
        public decimal RentDue { get; set; }
        [Column(Storage = "_CommissionId", DbType = "BigInt NOT NULL")]
        public long CommissionId { get; set; }
        [Column(Storage = "_CollectionCharges", DbType = "Decimal(18,2)")]
        public decimal? CollectionCharges { get; set; }
        [Column(Storage = "_VAT", DbType = "Decimal(18,2) NOT NULL")]
        public decimal VAT { get; set; }
    }
}
