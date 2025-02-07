using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public partial class stp_CustomerDetailResult
    {

        private string _Name;

        private string _MobileNo;

        private string _Address1;

        public stp_CustomerDetailResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "VarChar(100)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address1", DbType = "VarChar(200)")]
        public string Address1
        {
            get
            {
                return this._Address1;
            }
            set
            {
                if ((this._Address1 != value))
                {
                    this._Address1 = value;
                }
            }
        }
    }
}
