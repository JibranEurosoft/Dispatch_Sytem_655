using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi_AppMain.Classes
{
    public class ClsInvoicePayment
    {

        private long _Id;

        private string _InvoiceNo;

        private System.Nullable<System.DateTime> _InvoiceDate;

        private System.Nullable<decimal> _CreditNoteTotal;

        private System.Nullable<decimal> _InvoiceTotal;

        private System.Nullable<decimal> _InvoicePayment;

        private System.Nullable<decimal> _Balance;

        private System.Nullable<decimal> _TotalBalance;

        private System.Nullable<System.DateTime> _CreditNoteDate;

        private System.Nullable<System.DateTime> _PaymentDate;

        private string _CompanyName;

        private string _CreditNoteNo;

        private string _Address;

        public ClsInvoicePayment()
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoiceNo", DbType = "VarChar(20)")]
        public string InvoiceNo
        {
            get
            {
                return this._InvoiceNo;
            }
            set
            {
                if ((this._InvoiceNo != value))
                {
                    this._InvoiceNo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoiceDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> InvoiceDate
        {
            get
            {
                return this._InvoiceDate;
            }
            set
            {
                if ((this._InvoiceDate != value))
                {
                    this._InvoiceDate = value;
                }
            }
        }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CreditNoteTotal", DbType = "Decimal(26,6)")]
        public System.Nullable<decimal> CreditNoteTotal
        {
            get
            {
                return this._CreditNoteTotal;
            }
            set
            {
                if ((this._CreditNoteTotal != value))
                {
                    this._CreditNoteTotal = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoiceTotal", DbType = "Decimal(26,6)")]
        public System.Nullable<decimal> InvoiceTotal
        {
            get
            {
                return this._InvoiceTotal;
            }
            set
            {
                if ((this._InvoiceTotal != value))
                {
                    this._InvoiceTotal = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InvoicePayment", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> InvoicePayment
        {
            get
            {
                return this._InvoicePayment;
            }
            set
            {
                if ((this._InvoicePayment != value))
                {
                    this._InvoicePayment = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> Balance
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TotalBalance", DbType = "Decimal(27,6)")]
        public System.Nullable<decimal> TotalBalance
        {
            get
            {
                return this._TotalBalance;
            }
            set
            {
                if ((this._TotalBalance != value))
                {
                    this._TotalBalance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PaymentDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> PaymentDate
        {
            get
            {
                return this._PaymentDate;
            }
            set
            {
                if ((this._PaymentDate != value))
                {
                    this._PaymentDate = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CreditNoteDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreditNoteDate
        {
            get
            {
                return this._CreditNoteDate;
            }
            set
            {
                if ((this._CreditNoteDate != value))
                {
                    this._CreditNoteDate = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyName", DbType = "VarChar(100)")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                if ((this._CompanyName != value))
                {
                    this._CompanyName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CreditNoteNo", DbType = "VarChar(20)")]
        public string CreditNoteNo
        {
            get
            {
                return this._CreditNoteNo;
            }
            set
            {
                if ((this._CreditNoteNo != value))
                {
                    this._CreditNoteNo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Address", DbType = "VarChar(Max)")]
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
    }
}
