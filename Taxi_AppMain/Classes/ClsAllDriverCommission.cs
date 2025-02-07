using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public partial class clsstp_AddAllDriverCommissionResult
    {

        private int _Id;

        private string _Driver;

        private decimal _PDARent;

        private System.Nullable<decimal> _DriverCommissionPerBooking;

        private string _Email;

        private decimal _OldBalance;

        private decimal _InitialBalance;

        private decimal _JobsTotal;

        private decimal _RentDue;

        private long _CommissionId;

        private System.Nullable<decimal> _CollectionCharges;

        private decimal _VAT;

        private System.Nullable<int> _SubcompanyId;


        private System.Nullable<decimal> _PromotionDiscount;

        public clsstp_AddAllDriverCommissionResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL")]
        public int Id
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Driver", DbType = "VarChar(131)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PDARent", DbType = "Decimal(18,2) NOT NULL")]
        public decimal PDARent
        {
            get
            {
                return this._PDARent;
            }
            set
            {
                if ((this._PDARent != value))
                {
                    this._PDARent = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverCommissionPerBooking", DbType = "Decimal(18,0)")]
        public System.Nullable<decimal> DriverCommissionPerBooking
        {
            get
            {
                return this._DriverCommissionPerBooking;
            }
            set
            {
                if ((this._DriverCommissionPerBooking != value))
                {
                    this._DriverCommissionPerBooking = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "VarChar(50)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this._Email = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OldBalance", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OldBalance
        {
            get
            {
                return this._OldBalance;
            }
            set
            {
                if ((this._OldBalance != value))
                {
                    this._OldBalance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InitialBalance", DbType = "Decimal(18,2) NOT NULL")]
        public decimal InitialBalance
        {
            get
            {
                return this._InitialBalance;
            }
            set
            {
                if ((this._InitialBalance != value))
                {
                    this._InitialBalance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_JobsTotal", DbType = "Decimal(18,2) NOT NULL")]
        public decimal JobsTotal
        {
            get
            {
                return this._JobsTotal;
            }
            set
            {
                if ((this._JobsTotal != value))
                {
                    this._JobsTotal = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RentDue", DbType = "Decimal(18,2) NOT NULL")]
        public decimal RentDue
        {
            get
            {
                return this._RentDue;
            }
            set
            {
                if ((this._RentDue != value))
                {
                    this._RentDue = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CommissionId", DbType = "BigInt NOT NULL")]
        public long CommissionId
        {
            get
            {
                return this._CommissionId;
            }
            set
            {
                if ((this._CommissionId != value))
                {
                    this._CommissionId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CollectionCharges", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> CollectionCharges
        {
            get
            {
                return this._CollectionCharges;
            }
            set
            {
                if ((this._CollectionCharges != value))
                {
                    this._CollectionCharges = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VAT", DbType = "Decimal(18,2) NOT NULL")]
        public decimal VAT
        {
            get
            {
                return this._VAT;
            }
            set
            {
                if ((this._VAT != value))
                {
                    this._VAT = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubcompanyId", DbType = "Int")]
        public System.Nullable<int> SubcompanyId
        {
            get
            {
                return this._SubcompanyId;
            }
            set
            {
                if ((this._SubcompanyId != value))
                {
                    this._SubcompanyId = value;
                }
            }
        }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PromotionDiscount", DbType = "Decimal(18,2) NOT NULL")]
        public decimal? PromotionDiscount
        {
            get
            {
                return this._PromotionDiscount;
            }
            set
            {
                if ((this._PromotionDiscount != value))
                {
                    this._PromotionDiscount = value;
                }
            }
        }
    }
}
