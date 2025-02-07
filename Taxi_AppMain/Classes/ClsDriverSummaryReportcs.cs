using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_AppMain
{

     public  class ClsDriverSummaryReportcs
    {

        

             private System.Nullable<System.DateTime> _PickupDateTime;

             private System.Nullable<int> _DriverId;

        private string _RefNo;

        private string _FromAddress;

             private string _ToAddress;

             private System.Nullable<int> _VehicleTypeId;

             private System.Nullable<decimal> _FareRate;


             private System.Nullable<decimal> _CongtionCharges;

             private System.Nullable<decimal> _ParkingCharges;

             private System.Nullable<decimal> _WaitingCharges;

             private System.Nullable<decimal> _ExtraDropCharges;

         
         
      

             private System.Nullable<int> _PaymentTypeId;

             private System.Nullable<int> _BookingStatusId;

             private string _DriverName;

             private string _DriverNo;

             private string _VehicleType;

             private string _PaymentType;

             private string _StatusName;

             public ClsDriverSummaryReportcs()
             {
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverId", DbType = "Int")]
             public System.Nullable<int> DriverId
             {
                 get
                 {
                     return this._DriverId;
                 }
                 set
                 {
                     if ((this._DriverId != value))
                     {
                         this._DriverId = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PickupDateTime", DbType = "DateTime")]
             public System.Nullable<System.DateTime> PickupDateTime
             {
                 get
                 {
                     return this._PickupDateTime;
                 }
                 set
                 {
                     if ((this._PickupDateTime != value))
                     {
                         this._PickupDateTime = value;
                     }
                 }
             }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RefNo", DbType = "VarChar(200)")]
        public string RefNo
        {
            get
            {
                return this._RefNo;
            }
            set
            {
                if ((this._RefNo != value))
                {
                    this._RefNo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FromAddress", DbType = "VarChar(200)")]
             public string FromAddress
             {
                 get
                 {
                     return this._FromAddress;
                 }
                 set
                 {
                     if ((this._FromAddress != value))
                     {
                         this._FromAddress = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ToAddress", DbType = "VarChar(200)")]
             public string ToAddress
             {
                 get
                 {
                     return this._ToAddress;
                 }
                 set
                 {
                     if ((this._ToAddress != value))
                     {
                         this._ToAddress = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VehicleTypeId", DbType = "Int")]
             public System.Nullable<int> VehicleTypeId
             {
                 get
                 {
                     return this._VehicleTypeId;
                 }
                 set
                 {
                     if ((this._VehicleTypeId != value))
                     {
                         this._VehicleTypeId = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FareRate", DbType = "Decimal(18,2)")]
             public System.Nullable<decimal> FareRate
             {
                 get
                 {
                     return this._FareRate;
                 }
                 set
                 {
                     if ((this._FareRate != value))
                     {
                         this._FareRate = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CongtionCharges", DbType = "Decimal(18,2)")]
             public System.Nullable<decimal> CongtionCharges
             {
                 get
                 {
                     return this._CongtionCharges;
                 }
                 set
                 {
                     if ((this._CongtionCharges != value))
                     {
                         this._CongtionCharges = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParkingCharges", DbType = "Decimal(18,2)")]
             public System.Nullable<decimal> ParkingCharges
             {
                 get
                 {
                     return this._ParkingCharges;
                 }
                 set
                 {
                     if ((this._ParkingCharges != value))
                     {
                         this._ParkingCharges = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WaitingCharges", DbType = "Decimal(18,2)")]
             public System.Nullable<decimal> WaitingCharges
             {
                 get
                 {
                     return this._WaitingCharges;
                 }
                 set
                 {
                     if ((this._WaitingCharges != value))
                     {
                         this._WaitingCharges = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ExtraDropCharges", DbType = "Decimal(18,2)")]
             public System.Nullable<decimal> ExtraDropCharges
             {
                 get
                 {
                     return this._ExtraDropCharges;
                 }
                 set
                 {
                     if ((this._ExtraDropCharges != value))
                     {
                         this._ExtraDropCharges = value;
                     }
                 }
             }





         


         //--------------------------

















             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PaymentTypeId", DbType = "Int")]
             public System.Nullable<int> PaymentTypeId
             {
                 get
                 {
                     return this._PaymentTypeId;
                 }
                 set
                 {
                     if ((this._PaymentTypeId != value))
                     {
                         this._PaymentTypeId = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingStatusId", DbType = "Int")]
             public System.Nullable<int> BookingStatusId
             {
                 get
                 {
                     return this._BookingStatusId;
                 }
                 set
                 {
                     if ((this._BookingStatusId != value))
                     {
                         this._BookingStatusId = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverName", DbType = "VarChar(100)")]
             public string DriverName
             {
                 get
                 {
                     return this._DriverName;
                 }
                 set
                 {
                     if ((this._DriverName != value))
                     {
                         this._DriverName = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverNo", DbType = "VarChar(30)")]
             public string DriverNo
             {
                 get
                 {
                     return this._DriverNo;
                 }
                 set
                 {
                     if ((this._DriverNo != value))
                     {
                         this._DriverNo = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VehicleType", DbType = "VarChar(100)")]
             public string VehicleType
             {
                 get
                 {
                     return this._VehicleType;
                 }
                 set
                 {
                     if ((this._VehicleType != value))
                     {
                         this._VehicleType = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PaymentType", DbType = "VarChar(50)")]
             public string PaymentType
             {
                 get
                 {
                     return this._PaymentType;
                 }
                 set
                 {
                     if ((this._PaymentType != value))
                     {
                         this._PaymentType = value;
                     }
                 }
             }

             [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StatusName", DbType = "VarChar(50)")]
             public string StatusName
             {
                 get
                 {
                     return this._StatusName;
                 }
                 set
                 {
                     if ((this._StatusName != value))
                     {
                         this._StatusName = value;
                     }
                 }
             }
         }
    
}
