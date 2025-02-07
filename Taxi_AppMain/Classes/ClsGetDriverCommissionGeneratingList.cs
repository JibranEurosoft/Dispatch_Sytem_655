using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public partial class stp_getDriverListForGeneratingCommResult
    {

        private long _Id;

        private System.Nullable<int> _Driverid;

        private System.Nullable<decimal> _TotalFare;

        private System.Nullable<int> _CompanyId;

        private int _AccountTypeId;

        private System.Nullable<decimal> _DriverCommissionAmount;

        private string _DriverCommissionType;

        private System.Nullable<bool> _IsCommissionWise;

        private System.Nullable<decimal> _AgentCommission;

        private int _DropOffCharge;

        private int _PickupCharge;

        private decimal _Parking;



        private decimal _BookingFee;

        private decimal _ExtraDropCharges;

        private string _PickupPlot;

        private string _DropOffPlot;

        private System.Nullable<int> _PaymentTypeId;

        private System.Nullable<decimal> _Promotion;

        private decimal _Waiting;
        private decimal _FareRate;

        public stp_getDriverListForGeneratingCommResult()
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Driverid", DbType = "Int")]
        public System.Nullable<int> Driverid
        {
            get
            {
                return this._Driverid;
            }
            set
            {
                if ((this._Driverid != value))
                {
                    this._Driverid = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalFare", DbType = "Decimal(20,2)")]
        public System.Nullable<decimal> TotalFare
        {
            get
            {
                return this._TotalFare;
            }
            set
            {
                if ((this._TotalFare != value))
                {
                    this._TotalFare = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "Int")]
        public System.Nullable<int> CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountTypeId", DbType = "Int NOT NULL")]
        public int AccountTypeId
        {
            get
            {
                return this._AccountTypeId;
            }
            set
            {
                if ((this._AccountTypeId != value))
                {
                    this._AccountTypeId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverCommissionAmount", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> DriverCommissionAmount
        {
            get
            {
                return this._DriverCommissionAmount;
            }
            set
            {
                if ((this._DriverCommissionAmount != value))
                {
                    this._DriverCommissionAmount = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverCommissionType", DbType = "VarChar(20)")]
        public string DriverCommissionType
        {
            get
            {
                return this._DriverCommissionType;
            }
            set
            {
                if ((this._DriverCommissionType != value))
                {
                    this._DriverCommissionType = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsCommissionWise", DbType = "Bit")]
        public System.Nullable<bool> IsCommissionWise
        {
            get
            {
                return this._IsCommissionWise;
            }
            set
            {
                if ((this._IsCommissionWise != value))
                {
                    this._IsCommissionWise = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AgentCommission", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> AgentCommission
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DropOffCharge", DbType = "Int NOT NULL")]
        public int DropOffCharge
        {
            get
            {
                return this._DropOffCharge;
            }
            set
            {
                if ((this._DropOffCharge != value))
                {
                    this._DropOffCharge = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PickupCharge", DbType = "Int NOT NULL")]
        public int PickupCharge
        {
            get
            {
                return this._PickupCharge;
            }
            set
            {
                if ((this._PickupCharge != value))
                {
                    this._PickupCharge = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Parking", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Parking
        {
            get
            {
                return this._Parking;
            }
            set
            {
                if ((this._Parking != value))
                {
                    this._Parking = value;
                }
            }
        }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waiting", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Waiting
        {
            get
            {
                return this._Waiting;
            }
            set
            {
                if ((this._Waiting != value))
                {
                    this._Waiting = value;
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingFee", DbType = "Decimal(18,2) NOT NULL")]
        public decimal BookingFee
        {
            get
            {
                return this._BookingFee;
            }
            set
            {
                if ((this._BookingFee != value))
                {
                    this._BookingFee = value;
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PickupPlot", DbType = "VarChar(MAX) NOT NULL", CanBeNull = false)]
        public string PickupPlot
        {
            get
            {
                return this._PickupPlot;
            }
            set
            {
                if ((this._PickupPlot != value))
                {
                    this._PickupPlot = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DropOffPlot", DbType = "VarChar(MAX) NOT NULL", CanBeNull = false)]
        public string DropOffPlot
        {
            get
            {
                return this._DropOffPlot;
            }
            set
            {
                if ((this._DropOffPlot != value))
                {
                    this._DropOffPlot = value;
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Promotion", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> Promotion
        {
            get
            {
                return this._Promotion;
            }
            set
            {
                if ((this._Promotion != value))
                {
                    this._Promotion = value;
                }
            }
        }
    }
}

