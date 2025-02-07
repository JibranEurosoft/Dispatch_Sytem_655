using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_GetPendingInvoicesEx
    {
     

        [Column(Storage = "_CreditNoteId", DbType = "BigInt")]
        public long? CreditNoteId { get; set; }
        [Column(Storage = "_CreditNoteTotal", DbType = "Decimal(20,2)")]
        public decimal? CreditNoteTotal { get; set; }
        [Column(Storage = "_DiscountAmount", DbType = "Decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(Storage = "_Vat", DbType = "Bit")]
        public bool? Vat { get; set; }
        [Column(Storage = "_ContactName", DbType = "VarChar(100)")]
        public string ContactName { get; set; }
        [Column(Storage = "_CompanyName", DbType = "VarChar(100)")]
        public string CompanyName { get; set; }
        [Column(Storage = "_CompanyCode", DbType = "VarChar(20)")]
        public string CompanyCode { get; set; }
        [Column(Storage = "_InvoicePaymentTypeID", DbType = "Int")]
        public int? InvoicePaymentTypeID { get; set; }
        [Column(Storage = "_CreditNoteAmount", DbType = "Decimal(18,2)")]
        public decimal? CreditNoteAmount { get; set; }
        [Column(Storage = "_CompanyId", DbType = "Int")]
        public int? CompanyId { get; set; }
        [Column(Storage = "_OldBalance", DbType = "Decimal(18,2)")]
        public decimal? OldBalance { get; set; }
        [Column(Storage = "_CurrentBalance", DbType = "Decimal(18,2)")]
        public decimal? CurrentBalance { get; set; }
        [Column(Storage = "_TotalInvoiceAmount", DbType = "Decimal(18,2)")]
        public decimal? TotalInvoiceAmount { get; set; }
        [Column(Storage = "_InvoiceTotal", DbType = "Decimal(20,2)")]
        public decimal? InvoiceTotal { get; set; }
        [Column(Storage = "_DueDate", DbType = "DateTime")]
        public DateTime? DueDate { get; set; }
        [Column(Storage = "_InvoiceDate", DbType = "DateTime")]
        public DateTime? InvoiceDate { get; set; }
        [Column(Storage = "_InvoiceNo", DbType = "VarChar(20)")]
        public string InvoiceNo { get; set; }
        [Column(Storage = "_Id", DbType = "BigInt NOT NULL")]
        public long Id { get; set; }
        [Column(Storage = "_PaidAmount", DbType = "Decimal(18,2)")]
        public decimal? PaidAmount { get; set; }
        [Column(Storage = "_TelephoneNo", DbType = "VarChar(30)")]
        public string TelephoneNo { get; set; }


        [Column(Storage = "_NetTotal", DbType = "Decimal(18,2)")]
       public decimal? NetTotal { get; set; }


        [Column(Storage = "_AdminFees", DbType = "Int")]
        public int? AdminFees { get; set; }


        [Column(Storage = "_AdminFeeType", DbType = "VarChar(30)")]
        public string AdminFeeType { get; set; }



        [Column(Storage = "_VatOnlyOnAdminFees", DbType = "Bit")]
        public bool? VatOnlyOnAdminFees { get; set; }


        [Column(Storage = "_DiscountPercentage", DbType = "Decimal(18,2)")]
        public decimal? DiscountPercentage { get; set; }

       

    }
}
