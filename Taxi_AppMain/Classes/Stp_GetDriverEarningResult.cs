using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public partial class stp_GetDriverEarningResult_Template3
    {

        private int _DriverId;

        private string _DriverNo;

        private string _Name;

        private System.Nullable<decimal> _Account;

        private System.Nullable<decimal> _BookingFee;

        private System.Nullable<decimal> _Account1;

        private System.Nullable<decimal> _Cash;

        private System.Nullable<decimal> _Cash1;

        private System.Nullable<decimal> _Commission;

        private System.Nullable<int> _Earning;

        private System.Nullable<int> _Decline;

        private System.Nullable<int> _JobsDone;

        private System.Nullable<int> _Noshow;

        private System.Nullable<decimal> _Total;

        private System.Nullable<int> _TotalDays;

        private System.Nullable<int> _TotalHrs;

        private System.Nullable<int> _Avgday;

        private System.Nullable<int> _Avghour;

        private System.Nullable<int> _AvgJob;

        private System.Nullable<int> _LoginHour;

        private System.Nullable<int> _LoginDateTime;

        private System.Nullable<decimal> _Expenses;

        private System.Nullable<decimal> _Parking;

        private System.Nullable<decimal> _Waiting;

        private System.Nullable<decimal> _ExtraDropCharges;

        private System.Nullable<decimal> _PDARent;

        private System.Nullable<decimal> _DriverCommissionPerBooking;

        private int _Break;

        private int _BreakTime;

        public stp_GetDriverEarningResult_Template3()
        {
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "VarChar(301)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Account
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BookingFee", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> BookingFee
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account1", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Account1
        {
            get
            {
                return this._Account1;
            }
            set
            {
                if ((this._Account1 != value))
                {
                    this._Account1 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Cash", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Cash
        {
            get
            {
                return this._Cash;
            }
            set
            {
                if ((this._Cash != value))
                {
                    this._Cash = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Cash1", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Cash1
        {
            get
            {
                return this._Cash1;
            }
            set
            {
                if ((this._Cash1 != value))
                {
                    this._Cash1 = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Commission", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> Commission
        {
            get
            {
                return this._Commission;
            }
            set
            {
                if ((this._Commission != value))
                {
                    this._Commission = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Earning", DbType = "Int")]
        public System.Nullable<int> Earning
        {
            get
            {
                return this._Earning;
            }
            set
            {
                if ((this._Earning != value))
                {
                    this._Earning = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Decline", DbType = "Int")]
        public System.Nullable<int> Decline
        {
            get
            {
                return this._Decline;
            }
            set
            {
                if ((this._Decline != value))
                {
                    this._Decline = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_JobsDone", DbType = "Int")]
        public System.Nullable<int> JobsDone
        {
            get
            {
                return this._JobsDone;
            }
            set
            {
                if ((this._JobsDone != value))
                {
                    this._JobsDone = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Noshow", DbType = "Int")]
        public System.Nullable<int> Noshow
        {
            get
            {
                return this._Noshow;
            }
            set
            {
                if ((this._Noshow != value))
                {
                    this._Noshow = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Total", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Total
        {
            get
            {
                return this._Total;
            }
            set
            {
                if ((this._Total != value))
                {
                    this._Total = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalDays", DbType = "Int")]
        public System.Nullable<int> TotalDays
        {
            get
            {
                return this._TotalDays;
            }
            set
            {
                if ((this._TotalDays != value))
                {
                    this._TotalDays = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalHrs", DbType = "Int")]
        public System.Nullable<int> TotalHrs
        {
            get
            {
                return this._TotalHrs;
            }
            set
            {
                if ((this._TotalHrs != value))
                {
                    this._TotalHrs = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Avgday", DbType = "Int")]
        public System.Nullable<int> Avgday
        {
            get
            {
                return this._Avgday;
            }
            set
            {
                if ((this._Avgday != value))
                {
                    this._Avgday = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Avghour", DbType = "Int")]
        public System.Nullable<int> Avghour
        {
            get
            {
                return this._Avghour;
            }
            set
            {
                if ((this._Avghour != value))
                {
                    this._Avghour = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AvgJob", DbType = "Int")]
        public System.Nullable<int> AvgJob
        {
            get
            {
                return this._AvgJob;
            }
            set
            {
                if ((this._AvgJob != value))
                {
                    this._AvgJob = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LoginHour", DbType = "Int")]
        public System.Nullable<int> LoginHour
        {
            get
            {
                return this._LoginHour;
            }
            set
            {
                if ((this._LoginHour != value))
                {
                    this._LoginHour = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LoginDateTime", DbType = "Int")]
        public System.Nullable<int> LoginDateTime
        {
            get
            {
                return this._LoginDateTime;
            }
            set
            {
                if ((this._LoginDateTime != value))
                {
                    this._LoginDateTime = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Expenses", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Expenses
        {
            get
            {
                return this._Expenses;
            }
            set
            {
                if ((this._Expenses != value))
                {
                    this._Expenses = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Parking", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Parking
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waiting", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> Waiting
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ExtraDropCharges", DbType = "Decimal(38,2)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PDARent", DbType = "Decimal(18,2)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DriverCommissionPerBooking", DbType = "Decimal(18,2)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[Break]", Storage = "_Break", DbType = "Int NOT NULL")]
        public int Break
        {
            get
            {
                return this._Break;
            }
            set
            {
                if ((this._Break != value))
                {
                    this._Break = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BreakTime", DbType = "Int NOT NULL")]
        public int BreakTime
        {
            get
            {
                return this._BreakTime;
            }
            set
            {
                if ((this._BreakTime != value))
                {
                    this._BreakTime = value;
                }
            }
        }
    }
}
