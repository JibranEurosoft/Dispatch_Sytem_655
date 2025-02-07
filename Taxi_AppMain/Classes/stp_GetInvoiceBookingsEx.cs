using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_GetInvoiceBookingsResultEx
    {
    

        [Column(Storage = "_VehicleType", DbType = "VarChar(100)")]
        public string VehicleType { get; set; }
        [Column(Storage = "_BookingStatusId", DbType = "Int")]
        public int? BookingStatusId { get; set; }
        [Column(Storage = "_PaymentTypeId", DbType = "Int")]
        public int? PaymentTypeId { get; set; }
        [Column(Storage = "_CustomerName", DbType = "VarChar(100)")]
        public string CustomerName { get; set; }
        [Column(Storage = "_TotalCharges", DbType = "Decimal(18,2)")]
        public decimal? TotalCharges { get; set; }
        [Column(Storage = "_ToAddress", DbType = "VarChar(200)")]
        public string ToAddress { get; set; }
        [Column(Storage = "_FromAddress", DbType = "VarChar(200)")]
        public string FromAddress { get; set; }
        [Column(Storage = "_ExtraDropCharges", DbType = "Decimal(18,2)")]
        public decimal? ExtraDropCharges { get; set; }
        [Column(Storage = "_WaitingCharges", DbType = "Decimal(18,2)")]
        public decimal? WaitingCharges { get; set; }
        [Column(Storage = "_DepartmentName", DbType = "VarChar(100)")]
        public string DepartmentName { get; set; }
        [Column(Storage = "_ParkingCharges", DbType = "Decimal(18,2)")]
        public decimal? ParkingCharges { get; set; }
        [Column(Storage = "_BookingNo", DbType = "VarChar(50)")]
        public string BookingNo { get; set; }
        [Column(Storage = "_VehicleTypeId", DbType = "Int")]
        public int? VehicleTypeId { get; set; }
        [Column(Storage = "_PupilNo", DbType = "VarChar(10)")]
        public string PupilNo { get; set; }
        [Column(Storage = "_OrderNo", DbType = "VarChar(50)")]
        public string OrderNo { get; set; }
        [Column(Storage = "_PickupDateTime", DbType = "DateTime")]
        public DateTime? PickupDateTime { get; set; }
        [Column(Storage = "_InvoicePaymentTypeId", DbType = "Int")]
        public int? InvoicePaymentTypeId { get; set; }
        [Column(Storage = "_InvoiceId", DbType = "BigInt NOT NULL")]
        public long InvoiceId { get; set; }
        [Column(Storage = "_BookingId", DbType = "BigInt")]
        public long? BookingId { get; set; }
        [Column(Storage = "_Id", DbType = "BigInt NOT NULL")]
        public long Id { get; set; }
        [Column(Storage = "_CompanyPrice", DbType = "Decimal(18,2)")]
        public decimal? CompanyPrice { get; set; }
        [Column(Storage = "_TipAmount", DbType = "Decimal(18,2)")]
        public decimal? TipAmount { get; set; }


        [Column(Storage = "_BookingFee", DbType = "Decimal(18,2)")]
        public decimal? BookingFee { get; set; }


        [Column(Storage = "_BookingBookedBy", DbType = "VarChar(100)")]
        public string BookingBookedBy { get; set; }


        [Column(Storage = "_ViaString", DbType = "VarChar(MAX)")]
        public string ViaString { get; set; }



        [Column(Storage = "_WaitingTime", DbType = "Int")]
        public int? WaitingTime { get; set; }



        [Column(Storage = "_EscortPrice", DbType = "Decimal(18,2)")]
        public decimal? EscortPrice { get; set; }
    }

}
