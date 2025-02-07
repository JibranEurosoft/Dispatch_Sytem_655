#region Assembly Taxi_Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// F:\Projects\Cloud Despatch - V2017\Versions\Version2_till_644\Taxi_AppMain\bin\Debug\Taxi_Model.dll
#endregion

using System;
using System.Data.Linq.Mapping;

namespace Taxi_AppMain
{
    public class stp_GetBookingBaseResultEx
    {


        [Column(Storage = "_SubCompanyId", DbType = "Int")]
        public int? SubCompanyId { get; set; }
        [Column(Storage = "_TotalTravelledMiles", DbType = "Decimal(18,2)")]
        public decimal? TotalTravelledMiles { get; set; }
        [Column(Storage = "_ClearedDateTime", DbType = "DateTime")]
        public DateTime? ClearedDateTime { get; set; }
        [Column(Storage = "_STCDateTime", DbType = "DateTime")]
        public DateTime? STCDateTime { get; set; }
        [Column(Storage = "_POBDateTime", DbType = "DateTime")]
        public DateTime? POBDateTime { get; set; }
        [Column(Storage = "_AcceptedDateTime", DbType = "DateTime")]
        public DateTime? AcceptedDateTime { get; set; }
        [Column(Storage = "_ArrivalDateTime", DbType = "DateTime")]
        public DateTime? ArrivalDateTime { get; set; }
        [Column(Storage = "_AuthCode", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string AuthCode { get; set; }
        [Column(Storage = "_DriverCommissionType", DbType = "VarChar(20)")]
        public string DriverCommissionType { get; set; }
        [Column(Storage = "_DriverCommission", DbType = "Decimal(18,2)")]
        public decimal? DriverCommission { get; set; }
        [Column(Storage = "_IsCommissionWise", DbType = "Bit")]
        public bool? IsCommissionWise { get; set; }
        [Column(Storage = "_PupilNo", DbType = "VarChar(MAX)")]
        public string PupilNo { get; set; }
        [Column(Storage = "_OrderNo", DbType = "VarChar(50)")]
        public string OrderNo { get; set; }
        [Column(Storage = "_NoofHandLuggages", DbType = "Int")]
        public int? NoofHandLuggages { get; set; }
        [Column(Storage = "_NoofLuggages", DbType = "Int")]
        public int? NoofLuggages { get; set; }
        [Column(Storage = "_NoofPassengers", DbType = "Int")]
        public int? NoofPassengers { get; set; }
        [Column(Storage = "_ToStreet", DbType = "VarChar(200)")]
        public string ToStreet { get; set; }
        [Column(Storage = "_FromStreet", DbType = "VarChar(200)")]
        public string FromStreet { get; set; }
        [Column(Storage = "_SpecialRequirements", DbType = "VarChar(MAX)")]
        public string SpecialRequirements { get; set; }
        [Column(Storage = "_Despatchby", DbType = "VarChar(100)")]
        public string Despatchby { get; set; }
        [Column(Storage = "_ReturnDriverFullName", DbType = "VarChar(50)")]
        public string ReturnDriverFullName { get; set; }
        [Column(Storage = "_AgentCommissionPercent", DbType = "Int")]
        public int? AgentCommissionPercent { get; set; }
        [Column(Storage = "_JobTakenByCompany", DbType = "Bit")]
        public bool? JobTakenByCompany { get; set; }
        [Column(Storage = "_FleetMasterId", DbType = "Int")]
        public int? FleetMasterId { get; set; }
        [Column(Storage = "_SurchargeAmount", DbType = "VarChar(20)")]
        public string SurchargeAmount { get; set; }
        [Column(Storage = "_ReceiptTotal", DbType = "Decimal(19,2)")]
        public decimal? ReceiptTotal { get; set; }
        [Column(Storage = "_CreditCardNumber", DbType = "VarChar(44)")]
        public string CreditCardNumber { get; set; }
        [Column(Storage = "_CardNumber", DbType = "VarChar(30) NOT NULL", CanBeNull = false)]
        public string CardNumber { get; set; }
        [Column(Storage = "_CompanyVatNumber", DbType = "VarChar(50)")]
        public string CompanyVatNumber { get; set; }
        [Column(Storage = "_PaymentComments", DbType = "VarChar(MAX)")]
        public string PaymentComments { get; set; }
        [Column(Storage = "_JourneyType", DbType = "VarChar(50)")]
        public string JourneyType { get; set; }
        [Column(Storage = "_AccountTotalCharges", DbType = "Decimal(20,2)")]
        public decimal? AccountTotalCharges { get; set; }
        [Column(Storage = "_DriverTotalCharges", DbType = "Decimal(20,2)")]
        public decimal? DriverTotalCharges { get; set; }
        [Column(Storage = "_NotesString", DbType = "VarChar(1) NOT NULL", CanBeNull = false)]
        public string NotesString { get; set; }
        [Column(Storage = "_CustomerEmail", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string CustomerEmail { get; set; }
        [Column(Storage = "_Via1", DbType = "VarChar(1) NOT NULL", CanBeNull = false)]
        public string Via1 { get; set; }
        [Column(Storage = "_CompanyGroupId", DbType = "Int")]
        public int? CompanyGroupId { get; set; }
        [Column(Storage = "_InvoiceDate", DbType = "DateTime")]
        public DateTime? InvoiceDate { get; set; }
        [Column(Storage = "_InvoiceNo", DbType = "VarChar(20)")]
        public string InvoiceNo { get; set; }
        [Column(Storage = "_MasterJobId", DbType = "BigInt")]
        public long? MasterJobId { get; set; }
        [Column(Storage = "_CustomerPrice", DbType = "Decimal(18,2)")]
        public decimal? CustomerPrice { get; set; }
        [Column(Storage = "_CompanyPrice", DbType = "Decimal(18,2)")]
        public decimal? CompanyPrice { get; set; }
        [Column(Storage = "_AgentCommission", DbType = "Decimal(18,2)")]
        public decimal? AgentCommission { get; set; }
        [Column(Storage = "_ReturnDriverId", DbType = "Int")]
        public int? ReturnDriverId { get; set; }
        [Column(Storage = "_DriverAddress", DbType = "VarChar(200) NOT NULL", CanBeNull = false)]
        public string DriverAddress { get; set; }
        [Column(Storage = "_DriverName", DbType = "VarChar(100)")]
        public string DriverName { get; set; }
        [Column(Storage = "_ToLocType", DbType = "Int")]
        public int? ToLocType { get; set; }
        [Column(Storage = "_FromLocType", DbType = "Int")]
        public int? FromLocType { get; set; }
        [Column(Storage = "_CostCenterName", DbType = "VarChar(1) NOT NULL", CanBeNull = false)]
        public string CostCenterName { get; set; }
        [Column(Storage = "_CostCenterId", DbType = "Int")]
        public int? CostCenterId { get; set; }
        [Column(Storage = "_DepartmentName", DbType = "VarChar(100)")]
        public string DepartmentName { get; set; }
        [Column(Storage = "_DepartmentId", DbType = "BigInt")]
        public long? DepartmentId { get; set; }
        [Column(Storage = "_VehicleType", DbType = "VarChar(100)")]
        public string VehicleType { get; set; }
        [Column(Storage = "_VehicleTypeId", DbType = "Int")]
        public int? VehicleTypeId { get; set; }
        [Column(Storage = "_BookingTypeId", DbType = "Int")]
        public int? BookingTypeId { get; set; }
        [Column(Storage = "_IsAgent", DbType = "Bit")]
        public bool? IsAgent { get; set; }
        [Column(Storage = "_CompanyAddress", DbType = "VarChar(200)")]
        public string CompanyAddress { get; set; }
        [Column(Storage = "_AccountTypeId", DbType = "Int")]
        public int? AccountTypeId { get; set; }
        [Column(Storage = "_CompanyCode", DbType = "VarChar(20)")]
        public string CompanyCode { get; set; }
        [Column(Storage = "_CompanyName", DbType = "VarChar(100)")]
        public string CompanyName { get; set; }
        [Column(Storage = "_CompanyId", DbType = "Int")]
        public int? CompanyId { get; set; }
        [Column(Storage = "_BookedBy", DbType = "VarChar(100)")]
        public string BookedBy { get; set; }
        [Column(Storage = "_BookingDate", DbType = "DateTime")]
        public DateTime? BookingDate { get; set; }
        [Column(Storage = "_BookingNo", DbType = "VarChar(50)")]
        public string BookingNo { get; set; }
        [Column(Storage = "_Id", DbType = "BigInt NOT NULL")]
        public long Id { get; set; }
        [Column(Storage = "_CustomerName", DbType = "VarChar(100)")]
        public string CustomerName { get; set; }
        [Column(Storage = "_CustomerMobileNo", DbType = "VarChar(50)")]
        public string CustomerMobileNo { get; set; }
        [Column(Storage = "_CustomerPhoneNo", DbType = "VarChar(50)")]
        public string CustomerPhoneNo { get; set; }
        [Column(Storage = "_PickupDateTime", DbType = "DateTime")]
        public DateTime? PickupDateTime { get; set; }
        [Column(Storage = "_DriverFullName", DbType = "VarChar(133)")]
        public string DriverFullName { get; set; }
        [Column(Storage = "_DriverNo", DbType = "VarChar(30)")]
        public string DriverNo { get; set; }
        [Column(Storage = "_DriverId", DbType = "Int")]
        public int? DriverId { get; set; }
        [Column(Storage = "_PaymentTypeId", DbType = "Int")]
        public int? PaymentTypeId { get; set; }
        [Column(Storage = "_PaymentType", DbType = "VarChar(50)")]
        public string PaymentType { get; set; }
        [Column(Storage = "_StatusName", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string StatusName { get; set; }
        [Column(Storage = "_BookingStatusId", DbType = "Int")]
        public int? BookingStatusId { get; set; }
        [Column(Storage = "_TotalCharges", DbType = "Decimal(18,2) NOT NULL")]
        public decimal TotalCharges { get; set; }
        [Column(Storage = "_CongtionCharges", DbType = "Decimal(18,2) NOT NULL")]
        public decimal CongtionCharges { get; set; }
        [Column(Storage = "_FleetMasterVehicleNo", DbType = "VarChar(20)")]
        public string FleetMasterVehicleNo { get; set; }
        [Column(Storage = "_MeetAndGreetCharges", DbType = "Decimal(18,2) NOT NULL")]
        public decimal MeetAndGreetCharges { get; set; }
        [Column(Storage = "_WaitingCharges", DbType = "Decimal(18,2) NOT NULL")]
        public decimal WaitingCharges { get; set; }
        [Column(Storage = "_ParkingCharges", DbType = "Decimal(18,2)")]
        public decimal? ParkingCharges { get; set; }
        [Column(Storage = "_FareRate", DbType = "Decimal(18,2)")]
        public decimal? FareRate { get; set; }
        [Column(Storage = "_ToDoorNo", DbType = "VarChar(100)")]
        public string ToDoorNo { get; set; }
        [Column(Storage = "_FromDoorNo", DbType = "VarChar(100)")]
        public string FromDoorNo { get; set; }
        [Column(Storage = "_ToAddress", DbType = "VarChar(401)")]
        public string ToAddress { get; set; }
        [Column(Storage = "_FromAddress", DbType = "VarChar(401)")]
        public string FromAddress { get; set; }
        [Column(Storage = "_ReturnFareRate", DbType = "Decimal(18,2)")]
        public decimal? ReturnFareRate { get; set; }
        [Column(Storage = "_ReturnPickupDateTime", DbType = "DateTime")]
        public DateTime? ReturnPickupDateTime { get; set; }
        [Column(Storage = "_ExtraDropCharges", DbType = "Decimal(18,2)")]
        public decimal? ExtraDropCharges { get; set; }
        [Column(Storage = "_ServiceCharges", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ServiceCharges { get; set; }

        [Column(Storage = "_DriverWaitingMins", DbType = "Int")]
        public int? DriverWaitingMins { get; set; }

        [Column(Storage = "_OperatorId", DbType = "Int")]
        public int? OperatorId { get; set; }

        [Column(Storage = "_Operator", DbType = "VarChar(100)")]
        public string Operator { get; set; }

        [Column(Storage = "_EscortName", DbType = "VarChar(100)")]
        public string EscortName { get; set; }

        [Column(Storage = "_EscortPrice", DbType = "Decimal(18,2)")]
        public decimal EscortPrice { get; set; }

        [Column(Storage = "_EscortNo", DbType = "VarChar(100)")]
        public string EscortNo { get; set; }
    }



}