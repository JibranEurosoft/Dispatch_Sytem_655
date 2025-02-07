using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
     public class ClsDriverAccountBookings
    {
       

            private long _Id;

            private string _BookingNo;

            private System.Nullable<System.DateTime> _BookingDate;

            private System.Nullable<System.DateTime> _PickupDateTime;

            private string _FromAddress;

            private string _ToAddress;

            private decimal _FareRate;

            private decimal _CompanyPrice;

            private System.Nullable<decimal> _TotalCharges;

            private decimal _ParkingCharges;

            private decimal _WaitingCharges;

            private decimal _ExtraDropCharges;

            private string _FromPostCode;

            private string _ToPostCode;

            private string _JourneyType;

            private System.Nullable<int> _PaymentTypeId;

            private string _PaymentType;

            private string _IsVat;

            private decimal _AgentCommission;

            private int _AgentCommissionPercent;

            private string _BookedBy;

            private string _OrderNo;

            private int _DriverId;

            private string _DriverNo;

            private string _DriverNo1;

            private string _DriverName;

            private string _Address;

            private string _VehicleType;

            public ClsDriverAccountBookings()
            {
            }

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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingDate", DbType = "DateTime")]
            public System.Nullable<System.DateTime> BookingDate
            {
                get
                {
                    return this._BookingDate;
                }
                set
                {
                    if ((this._BookingDate != value))
                    {
                        this._BookingDate = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FareRate", DbType = "Decimal(18,2) NOT NULL")]
            public decimal FareRate
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyPrice", DbType = "Decimal(18,2) NOT NULL")]
            public decimal CompanyPrice
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalCharges", DbType = "Decimal(20,2)")]
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParkingCharges", DbType = "Decimal(18,2) NOT NULL")]
            public decimal ParkingCharges
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_WaitingCharges", DbType = "Decimal(18,2) NOT NULL")]
            public decimal WaitingCharges
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ExtraDropCharges", DbType = "Decimal(18,2) NOT NULL")]
            public decimal ExtraDropCharges
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FromPostCode", DbType = "VarChar(50)")]
            public string FromPostCode
            {
                get
                {
                    return this._FromPostCode;
                }
                set
                {
                    if ((this._FromPostCode != value))
                    {
                        this._FromPostCode = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ToPostCode", DbType = "VarChar(50)")]
            public string ToPostCode
            {
                get
                {
                    return this._ToPostCode;
                }
                set
                {
                    if ((this._ToPostCode != value))
                    {
                        this._ToPostCode = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_JourneyType", DbType = "VarChar(50)")]
            public string JourneyType
            {
                get
                {
                    return this._JourneyType;
                }
                set
                {
                    if ((this._JourneyType != value))
                    {
                        this._JourneyType = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsVat", DbType = "VarChar(1) NOT NULL", CanBeNull = false)]
            public string IsVat
            {
                get
                {
                    return this._IsVat;
                }
                set
                {
                    if ((this._IsVat != value))
                    {
                        this._IsVat = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AgentCommission", DbType = "Decimal(18,2) NOT NULL")]
            public decimal AgentCommission
            {
                get
                {
                    return this._AgentCommission;
                }
                set
                {
                    if ((this._AgentCommission != value))
                    {
                        this._AgentCommission = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AgentCommissionPercent", DbType = "Int NOT NULL")]
            public int AgentCommissionPercent
            {
                get
                {
                    return this._AgentCommissionPercent;
                }
                set
                {
                    if ((this._AgentCommissionPercent != value))
                    {
                        this._AgentCommissionPercent = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookedBy", DbType = "VarChar(100)")]
            public string BookedBy
            {
                get
                {
                    return this._BookedBy;
                }
                set
                {
                    if ((this._BookedBy != value))
                    {
                        this._BookedBy = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverId", DbType = "Int NOT NULL")]
            public int DriverId
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverNo1", DbType = "VarChar(30)")]
            public string DriverNo1
            {
                get
                {
                    return this._DriverNo1;
                }
                set
                {
                    if ((this._DriverNo1 != value))
                    {
                        this._DriverNo1 = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address", DbType = "VarChar(200)")]
            public string Address
            {
                get
                {
                    return this._Address;
                }
                set
                {
                    if ((this._Address != value))
                    {
                        this._Address = value;
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
        }
    

}
