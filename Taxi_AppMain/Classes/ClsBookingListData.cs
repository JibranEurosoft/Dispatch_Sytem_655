using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public class ClsBookingListData
    {
       
            private long _Id;

            private string _Token;

            private string _RefNumber;

            private System.Nullable<System.DateTime> _BookingDate;

            private System.Nullable<System.DateTime> _PickupDate;

            private string _Passenger;

            private string _MobileNo;

            private string _From;

            private string _FromPostCode;

            private string _To;

            private string _ToPostCode;

            private System.Nullable<decimal> _Fare;

            private string _PaymentMethod;

            private System.Nullable<decimal> _AccountFare;

            private System.Nullable<decimal> _CustomerFare;

            private string _Account;
        private string _PaymentComments;

        private string _Driver;

            private System.Nullable<int> _DriverId;

            private string _Vehicle;

            private string _Status;

            private string _StatusColor;

            private System.Nullable<int> _BookingTypeId;

            private string _VehicleBgColor;

            private string _VehicleTextColor;

            private string _BackgroundColor1;

            private string _TextColor1;

            private System.Nullable<int> _FromLocTypeId;

            private System.Nullable<int> _ToLocTypeId;

            private System.Nullable<int> _SubCompanyBgColor;

            private System.Nullable<int> _StatusId;

            private System.Nullable<int> _BookingBackgroundColor;

            private System.Nullable<int> _FromLocBgColor;

            private System.Nullable<int> _ToLocBgColor;

            private System.Nullable<int> _FromLocTextColor;

            private System.Nullable<int> _ToLocTextColor;

            private System.Nullable<bool> _IsAutoDespatch;

            private System.Nullable<bool> _IsBidding;

            public ClsBookingListData()
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Token", DbType = "VarChar(10)")]
            public string Token
            {
                get
                {
                    return this._Token;
                }
                set
                {
                    if ((this._Token != value))
                    {
                        this._Token = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RefNumber", DbType = "VarChar(50)")]
            public string RefNumber
            {
                get
                {
                    return this._RefNumber;
                }
                set
                {
                    if ((this._RefNumber != value))
                    {
                        this._RefNumber = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PickupDate", DbType = "DateTime")]
            public System.Nullable<System.DateTime> PickupDate
            {
                get
                {
                    return this._PickupDate;
                }
                set
                {
                    if ((this._PickupDate != value))
                    {
                        this._PickupDate = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Passenger", DbType = "NVarChar(MAX)")]
            public string Passenger
            {
                get
                {
                    return this._Passenger;
                }
                set
                {
                    if ((this._Passenger != value))
                    {
                        this._Passenger = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MobileNo", DbType = "VarChar(50)")]
            public string MobileNo
            {
                get
                {
                    return this._MobileNo;
                }
                set
                {
                    if ((this._MobileNo != value))
                    {
                        this._MobileNo = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[From]", Storage = "_From", DbType = "NVarChar(MAX)")]
            public string From
            {
                get
                {
                    return this._From;
                }
                set
                {
                    if ((this._From != value))
                    {
                        this._From = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[To]", Storage = "_To", DbType = "NVarChar(MAX)")]
            public string To
            {
                get
                {
                    return this._To;
                }
                set
                {
                    if ((this._To != value))
                    {
                        this._To = value;
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Fare", DbType = "Decimal(24,2)")]
            public System.Nullable<decimal> Fare
            {
                get
                {
                    return this._Fare;
                }
                set
                {
                    if ((this._Fare != value))
                    {
                        this._Fare = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PaymentMethod", DbType = "VarChar(50)")]
            public string PaymentMethod
            {
                get
                {
                    return this._PaymentMethod;
                }
                set
                {
                    if ((this._PaymentMethod != value))
                    {
                        this._PaymentMethod = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountFare", DbType = "Decimal(18,2)")]
            public System.Nullable<decimal> AccountFare
            {
                get
                {
                    return this._AccountFare;
                }
                set
                {
                    if ((this._AccountFare != value))
                    {
                        this._AccountFare = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustomerFare", DbType = "Decimal(18,2)")]
            public System.Nullable<decimal> CustomerFare
            {
                get
                {
                    return this._CustomerFare;
                }
                set
                {
                    if ((this._CustomerFare != value))
                    {
                        this._CustomerFare = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "VarChar(153)")]
            public string Account
            {
                get
                {
                    return this._Account;
                }
                set
                {
                    if ((this._Account != value))
                    {
                        this._Account = value;
                    }
                }
            }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PaymentComments", DbType = "VarChar(500)")]
        public string PaymentComments
        {
            get
            {
                return this._PaymentComments;
            }
            set
            {
                if ((this._PaymentComments != value))
                {
                    this._PaymentComments = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Driver", DbType = "VarChar(30)")]
            public string Driver
            {
                get
                {
                    return this._Driver;
                }
                set
                {
                    if ((this._Driver != value))
                    {
                        this._Driver = value;
                    }
                }
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

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vehicle", DbType = "VarChar(100)")]
            public string Vehicle
            {
                get
                {
                    return this._Vehicle;
                }
                set
                {
                    if ((this._Vehicle != value))
                    {
                        this._Vehicle = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Status", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
            public string Status
            {
                get
                {
                    return this._Status;
                }
                set
                {
                    if ((this._Status != value))
                    {
                        this._Status = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StatusColor", DbType = "VarChar(30)")]
            public string StatusColor
            {
                get
                {
                    return this._StatusColor;
                }
                set
                {
                    if ((this._StatusColor != value))
                    {
                        this._StatusColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingTypeId", DbType = "Int")]
            public System.Nullable<int> BookingTypeId
            {
                get
                {
                    return this._BookingTypeId;
                }
                set
                {
                    if ((this._BookingTypeId != value))
                    {
                        this._BookingTypeId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VehicleBgColor", DbType = "VarChar(30)")]
            public string VehicleBgColor
            {
                get
                {
                    return this._VehicleBgColor;
                }
                set
                {
                    if ((this._VehicleBgColor != value))
                    {
                        this._VehicleBgColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VehicleTextColor", DbType = "VarChar(30)")]
            public string VehicleTextColor
            {
                get
                {
                    return this._VehicleTextColor;
                }
                set
                {
                    if ((this._VehicleTextColor != value))
                    {
                        this._VehicleTextColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BackgroundColor1", DbType = "VarChar(50)")]
            public string BackgroundColor1
            {
                get
                {
                    return this._BackgroundColor1;
                }
                set
                {
                    if ((this._BackgroundColor1 != value))
                    {
                        this._BackgroundColor1 = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TextColor1", DbType = "VarChar(20)")]
            public string TextColor1
            {
                get
                {
                    return this._TextColor1;
                }
                set
                {
                    if ((this._TextColor1 != value))
                    {
                        this._TextColor1 = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FromLocTypeId", DbType = "Int")]
            public System.Nullable<int> FromLocTypeId
            {
                get
                {
                    return this._FromLocTypeId;
                }
                set
                {
                    if ((this._FromLocTypeId != value))
                    {
                        this._FromLocTypeId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ToLocTypeId", DbType = "Int")]
            public System.Nullable<int> ToLocTypeId
            {
                get
                {
                    return this._ToLocTypeId;
                }
                set
                {
                    if ((this._ToLocTypeId != value))
                    {
                        this._ToLocTypeId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubCompanyBgColor", DbType = "Int")]
            public System.Nullable<int> SubCompanyBgColor
            {
                get
                {
                    return this._SubCompanyBgColor;
                }
                set
                {
                    if ((this._SubCompanyBgColor != value))
                    {
                        this._SubCompanyBgColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StatusId", DbType = "Int")]
            public System.Nullable<int> StatusId
            {
                get
                {
                    return this._StatusId;
                }
                set
                {
                    if ((this._StatusId != value))
                    {
                        this._StatusId = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingBackgroundColor", DbType = "Int")]
            public System.Nullable<int> BookingBackgroundColor
            {
                get
                {
                    return this._BookingBackgroundColor;
                }
                set
                {
                    if ((this._BookingBackgroundColor != value))
                    {
                        this._BookingBackgroundColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FromLocBgColor", DbType = "Int")]
            public System.Nullable<int> FromLocBgColor
            {
                get
                {
                    return this._FromLocBgColor;
                }
                set
                {
                    if ((this._FromLocBgColor != value))
                    {
                        this._FromLocBgColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ToLocBgColor", DbType = "Int")]
            public System.Nullable<int> ToLocBgColor
            {
                get
                {
                    return this._ToLocBgColor;
                }
                set
                {
                    if ((this._ToLocBgColor != value))
                    {
                        this._ToLocBgColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FromLocTextColor", DbType = "Int")]
            public System.Nullable<int> FromLocTextColor
            {
                get
                {
                    return this._FromLocTextColor;
                }
                set
                {
                    if ((this._FromLocTextColor != value))
                    {
                        this._FromLocTextColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ToLocTextColor", DbType = "Int")]
            public System.Nullable<int> ToLocTextColor
            {
                get
                {
                    return this._ToLocTextColor;
                }
                set
                {
                    if ((this._ToLocTextColor != value))
                    {
                        this._ToLocTextColor = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsAutoDespatch", DbType = "Bit")]
            public System.Nullable<bool> IsAutoDespatch
            {
                get
                {
                    return this._IsAutoDespatch;
                }
                set
                {
                    if ((this._IsAutoDespatch != value))
                    {
                        this._IsAutoDespatch = value;
                    }
                }
            }

            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBidding", DbType = "Bit")]
            public System.Nullable<bool> IsBidding
            {
                get
                {
                    return this._IsBidding;
                }
                set
                {
                    if ((this._IsBidding != value))
                    {
                        this._IsBidding = value;
                    }
                }
            }
        
    }
}
