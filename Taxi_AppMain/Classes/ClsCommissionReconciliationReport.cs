using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Taxi_AppMain.Classes
{
    public class ClsCommissionReconciliationReport
    {
       private int _Id;
		
		private string _DriverNo;
		
		private string _TransNo;
		
		private System.Nullable<System.DateTime> _TransDate;
		
		private string _DriverName;
		
		private System.Nullable<decimal> _DriverMonthlyRent;
		
		private System.Nullable<decimal> _PDARent;
		
		private System.Nullable<decimal> _DriverCommision;
        private System.Nullable<decimal> _BookingFeeTotal;
        private decimal _OldBalance;
		
		private decimal _InitialBalance;
		
		private decimal _JobsTotal;
		
		private decimal _Balance;
		
		private long _RentId;
		
		private decimal _AccountJobsTotal;
		
		private decimal _CashJobsTotal;
		
		private decimal _DriverRent;
		
		private decimal _NetMoney;
		
		private System.Nullable<decimal> _Owed;
		
		private decimal _PaidAmount;
		
		private System.Nullable<decimal> _Others;
		
		private decimal _Credit;
		
		private decimal _Debit;
		
		private System.Nullable<System.DateTime> _PaidDate;
		
		private System.Nullable<bool> _IsPrimeCompanyDriver;
		
		private int _NoOfJobs;
		
		
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriverNo", DbType="VarChar(30)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransNo", DbType="VarChar(20)")]
		public string TransNo
		{
			get
			{
				return this._TransNo;
			}
			set
			{
				if ((this._TransNo != value))
				{
					this._TransNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> TransDate
		{
			get
			{
				return this._TransDate;
			}
			set
			{
				if ((this._TransDate != value))
				{
					this._TransDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriverName", DbType="VarChar(100)")]
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
                    //
					this._DriverName = value;
				}
			}
		}



        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingFeeTotal", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> BookingFeeTotal
        {
            get
            {
                return this._BookingFeeTotal;
            }
            set
            {
                if ((this._BookingFeeTotal != value))
                {
                    this._BookingFeeTotal = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriverMonthlyRent", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> DriverMonthlyRent
		{
			get
			{
				return this._DriverMonthlyRent;
			}
			set
			{
				if ((this._DriverMonthlyRent != value))
				{
					this._DriverMonthlyRent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PDARent", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> PDARent
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriverCommision", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> DriverCommision
		{
			get
			{
				return this._DriverCommision;
			}
			set
			{
				if ((this._DriverCommision != value))
				{
					this._DriverCommision = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OldBalance", DbType="Decimal(18,2) NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InitialBalance", DbType="Decimal(18,2) NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JobsTotal", DbType="Decimal(18,2) NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Decimal(18,2) NOT NULL")]
		public decimal Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this._Balance = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RentId", DbType="BigInt NOT NULL")]
		public long RentId
		{
			get
			{
				return this._RentId;
			}
			set
			{
				if ((this._RentId != value))
				{
					this._RentId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountJobsTotal", DbType="Decimal(18,2) NOT NULL")]
		public decimal AccountJobsTotal
		{
			get
			{
				return this._AccountJobsTotal;
			}
			set
			{
				if ((this._AccountJobsTotal != value))
				{
					this._AccountJobsTotal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CashJobsTotal", DbType="Decimal(18,2) NOT NULL")]
		public decimal CashJobsTotal
		{
			get
			{
				return this._CashJobsTotal;
			}
			set
			{
				if ((this._CashJobsTotal != value))
				{
					this._CashJobsTotal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DriverRent", DbType="Decimal(18,2) NOT NULL")]
		public decimal DriverRent
		{
			get
			{
				return this._DriverRent;
			}
			set
			{
				if ((this._DriverRent != value))
				{
					this._DriverRent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetMoney", DbType="Decimal(18,2) NOT NULL")]
		public decimal NetMoney
		{
			get
			{
				return this._NetMoney;
			}
			set
			{
				if ((this._NetMoney != value))
				{
					this._NetMoney = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Owed", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> Owed
		{
			get
			{
				return this._Owed;
			}
			set
			{
				if ((this._Owed != value))
				{
					this._Owed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaidAmount", DbType="Decimal(38,2) NOT NULL")]
		public decimal PaidAmount
		{
			get
			{
				return this._PaidAmount;
			}
			set
			{
				if ((this._PaidAmount != value))
				{
					this._PaidAmount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Others", DbType="Decimal(19,2)")]
		public System.Nullable<decimal> Others
		{
			get
			{
				return this._Others;
			}
			set
			{
				if ((this._Others != value))
				{
					this._Others = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Credit", DbType= "Decimal(18,2) NOT NULL")]
		public decimal Credit
		{
			get
			{
				return this._Credit;
			}
			set
			{
				if ((this._Credit != value))
				{
					this._Credit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Debit", DbType= "Decimal(18,2) NOT NULL")]
		public decimal Debit
		{
			get
			{
				return this._Debit;
			}
			set
			{
				if ((this._Debit != value))
				{
					this._Debit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaidDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PaidDate
		{
			get
			{
				return this._PaidDate;
			}
			set
			{
				if ((this._PaidDate != value))
				{
					this._PaidDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPrimeCompanyDriver", DbType="Bit")]
		public System.Nullable<bool> IsPrimeCompanyDriver
		{
			get
			{
				return this._IsPrimeCompanyDriver;
			}
			set
			{
				if ((this._IsPrimeCompanyDriver != value))
				{
					this._IsPrimeCompanyDriver = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfJobs", DbType="Int NOT NULL")]
		public int NoOfJobs
		{
			get
			{
				return this._NoOfJobs;
			}
			set
			{
				if ((this._NoOfJobs != value))
				{
					this._NoOfJobs = value;
				}
			}
		}

    }
}
