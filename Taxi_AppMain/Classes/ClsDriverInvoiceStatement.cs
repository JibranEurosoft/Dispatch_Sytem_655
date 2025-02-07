using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class ClsDriverInvoiceStatement
    {


//        create proc[dbo].[stp_DriverInvoiceStatement]

//        @subCompanyId int,                  
                  
//@driverId int                  
                  
//as                  
         
      
//Select* from

// (
//select Id = inv.Id, INV_P.Id PaymentId, INV.TransNo, INV.TransDate
//, InvoiceTotal = (inv.CommissionTotal + inv.PDARent + inv.OldBalance) - inv.AccJobsTotal, INV_P.CommissionId
//, Payment= INV_P.Amount, inv_p.Credit, inv_p.Debit, inv_p.Description, inv_p.AddBy,
//  INV_P.Date , c.DriverName as Driver  , c.DriverNo, c.Address as Address
//  , OrderNo= ROW_NUMBER() OVER(PARTITION BY INV.Id Order BY INV.Id)
//from Fleet_DriverCommision INV
//left join Fleet_DriverCommissionExpenses INV_P on INV.Id = INV_P.CommissionId
//inner join Fleet_Driver c on c.Id  = INV.DriverId
//where(@driverId= 0 or inv.DriverId= @driverId)
//) as tbl




        public long Id;

        public long? TransId;


        public long? PaymentId;

        public string TransNo;

        public string Driver;

        public string DriverNo;
        public string Address;
        public long OrderNo;
        public string PaymentBy;
        public string PaymentDescription;

        public System.Nullable<System.DateTime> TransDate;
        public System.Nullable<decimal> InvoiceTotal;
        public System.Nullable<System.DateTime> PaymentDate;


        public System.Nullable<decimal> Payment;

        public System.Nullable<decimal> Credit;

        public System.Nullable<decimal> Debit;

        public System.Nullable<decimal> Balance;



    }
}
