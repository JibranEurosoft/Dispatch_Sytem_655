using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_AppMain.Classes
{
    public class ClsDriverOnlineStats
    {
        
		private string _DriverNo;
		
		private string _DriverName;
		
		private string _Surname;
		
		private string _VehicleRegistration;
		
		private string _VehicleType;
		
		private string _WaitingSince;
		
		private string _LoginDateTime;
		
		private System.Nullable<int> _NoOfCashJobs;
		
		private System.Nullable<int> _NoOfCCardJobs;
		
		private System.Nullable<int> _NoOfAccountJobs;
		
		private System.Nullable<int> _NoOfRecoveredJobs;
		
		private System.Nullable<int> _NoOfRejectedJobs;
		
		private System.Nullable<decimal> _TotalCashJobs;
		
		private System.Nullable<decimal> _TotalCCardJobs;
		
		private System.Nullable<decimal> _TotalAccountJobs;
		
		private System.Nullable<decimal> _TotalMileage;

        public ClsDriverOnlineStats()
		{
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
					this._DriverName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(200)")]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this._Surname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleRegistration", DbType="VarChar(50)")]
		public string VehicleRegistration
		{
			get
			{
				return this._VehicleRegistration;
			}
			set
			{
				if ((this._VehicleRegistration != value))
				{
					this._VehicleRegistration = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleType", DbType="VarChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WaitingSince", DbType="VarChar(37)")]
		public string WaitingSince
		{
			get
			{
				return this._WaitingSince;
			}
			set
			{
				if ((this._WaitingSince != value))
				{
					this._WaitingSince = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoginDateTime", DbType="Time")]
		public string LoginDateTime
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfCashJobs", DbType="Int")]
		public System.Nullable<int> NoOfCashJobs
		{
			get
			{
				return this._NoOfCashJobs;
			}
			set
			{
				if ((this._NoOfCashJobs != value))
				{
					this._NoOfCashJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfCCardJobs", DbType="Int")]
		public System.Nullable<int> NoOfCCardJobs
		{
			get
			{
				return this._NoOfCCardJobs;
			}
			set
			{
				if ((this._NoOfCCardJobs != value))
				{
					this._NoOfCCardJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfAccountJobs", DbType="Int")]
		public System.Nullable<int> NoOfAccountJobs
		{
			get
			{
				return this._NoOfAccountJobs;
			}
			set
			{
				if ((this._NoOfAccountJobs != value))
				{
					this._NoOfAccountJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfRecoveredJobs", DbType="Int")]
		public System.Nullable<int> NoOfRecoveredJobs
		{
			get
			{
				return this._NoOfRecoveredJobs;
			}
			set
			{
				if ((this._NoOfRecoveredJobs != value))
				{
					this._NoOfRecoveredJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoOfRejectedJobs", DbType="Int")]
		public System.Nullable<int> NoOfRejectedJobs
		{
			get
			{
				return this._NoOfRejectedJobs;
			}
			set
			{
				if ((this._NoOfRejectedJobs != value))
				{
					this._NoOfRejectedJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalCashJobs", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> TotalCashJobs
		{
			get
			{
				return this._TotalCashJobs;
			}
			set
			{
				if ((this._TotalCashJobs != value))
				{
					this._TotalCashJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalCCardJobs", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> TotalCCardJobs
		{
			get
			{
				return this._TotalCCardJobs;
			}
			set
			{
				if ((this._TotalCCardJobs != value))
				{
					this._TotalCCardJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalAccountJobs", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> TotalAccountJobs
		{
			get
			{
				return this._TotalAccountJobs;
			}
			set
			{
				if ((this._TotalAccountJobs != value))
				{
					this._TotalAccountJobs = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalMileage", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> TotalMileage
		{
			get
			{
				return this._TotalMileage;
			}
			set
			{
				if ((this._TotalMileage != value))
				{
					this._TotalMileage = value;
				}
			}
		}
    }
}
