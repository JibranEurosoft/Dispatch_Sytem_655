using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public class ClsExportInvoiceBookings
    {      

            private long _Id;

            private System.Nullable<long> _BookingId;

            private long _InvoiceId;

            private System.Nullable<int> _InvoicePaymentTypeId;

            private System.Nullable<System.DateTime> _PickupDateTime;

            private string _OrderNo;

            private string _PupilNo;

            private System.Nullable<int> _VehicleTypeId;

            private string _BookingNo;

            private System.Nullable<decimal> _CompanyPrice;

            private System.Nullable<decimal> _ParkingCharges;

            private System.Nullable<decimal> _WaitingCharges;

            private System.Nullable<decimal> _ExtraDropCharges;

            private string _FromAddress;

            private string _ToAddress;

            private System.Nullable<decimal> _TotalCharges;

            private string _CustomerName;

            private System.Nullable<int> _PaymentTypeId;

            private System.Nullable<int> _BookingStatusId;

            private string _VehicleType;

            private string _DepartmentName;

            private System.Nullable<decimal> _TipAmount;

            private string _PassengerType;

            private string _BookerEmail;

        private string _CompanyCode;


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "BigInt NOT NULL")]
            public long Id
            {
                get
                {
                    return this._Id;
                }
                set
                {
                    if ((this._Id != value))
                    {
                        this._Id = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingId", DbType = "BigInt")]
            public System.Nullable<long> BookingId
            {
                get
                {
                    return this._BookingId;
                }
                set
                {
                    if ((this._BookingId != value))
                    {
                        this._BookingId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoiceId", DbType = "BigInt NOT NULL")]
            public long InvoiceId
            {
                get
                {
                    return this._InvoiceId;
                }
                set
                {
                    if ((this._InvoiceId != value))
                    {
                        this._InvoiceId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoicePaymentTypeId", DbType = "Int")]
            public System.Nullable<int> InvoicePaymentTypeId
            {
                get
                {
                    return this._InvoicePaymentTypeId;
                }
                set
                {
                    if ((this._InvoicePaymentTypeId != value))
                    {
                        this._InvoicePaymentTypeId = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OrderNo", DbType = "VarChar(50)")]
            public string OrderNo
            {
                get
                {
                    return this._OrderNo;
                }
                set
                {
                    if ((this._OrderNo != value))
                    {
                        this._OrderNo = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PupilNo", DbType = "VarChar(10)")]
            public string PupilNo
            {
                get
                {
                    return this._PupilNo;
                }
                set
                {
                    if ((this._PupilNo != value))
                    {
                        this._PupilNo = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingNo", DbType = "VarChar(50)")]
            public string BookingNo
            {
                get
                {
                    return this._BookingNo;
                }
                set
                {
                    if ((this._BookingNo != value))
                    {
                        this._BookingNo = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyPrice", DbType = "Decimal(18,2)")]
            public System.Nullable<decimal> CompanyPrice
            {
                get
                {
                    return this._CompanyPrice;
                }
                set
                {
                    if ((this._CompanyPrice != value))
                    {
                        this._CompanyPrice = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalCharges", DbType = "Decimal(18,2)")]
            public System.Nullable<decimal> TotalCharges
            {
                get
                {
                    return this._TotalCharges;
                }
                set
                {
                    if ((this._TotalCharges != value))
                    {
                        this._TotalCharges = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustomerName", DbType = "VarChar(100)")]
            public string CustomerName
            {
                get
                {
                    return this._CustomerName;
                }
                set
                {
                    if ((this._CustomerName != value))
                    {
                        this._CustomerName = value;
                    }
                }
            }

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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DepartmentName", DbType = "VarChar(100)")]
            public string DepartmentName
            {
                get
                {
                    return this._DepartmentName;
                }
                set
                {
                    if ((this._DepartmentName != value))
                    {
                        this._DepartmentName = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TipAmount", DbType = "Decimal(18,2)")]
            public System.Nullable<decimal> TipAmount
            {
                get
                {
                    return this._TipAmount;
                }
                set
                {
                    if ((this._TipAmount != value))
                    {
                        this._TipAmount = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PassengerType", DbType = "VarChar(50)")]
            public string PassengerType
            {
                get
                {
                    return this._PassengerType;
                }
                set
                {
                    if ((this._PassengerType != value))
                    {
                        this._PassengerType = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookerEmail", DbType = "VarChar(100)")]
            public string BookerEmail
            {
                get
                {
                    return this._BookerEmail;
                }
                set
                {
                    if ((this._BookerEmail != value))
                    {
                        this._BookerEmail = value;
                    }
                }
            }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyCode", DbType = "VarChar(100)")]
        public string CompanyCode
        {
            get
            {
                return this._CompanyCode;
            }
            set
            {
                if ((this._CompanyCode != value))
                {
                    this._CompanyCode = value;
                }
            }
        }
    }

    
}
