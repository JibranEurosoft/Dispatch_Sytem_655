using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public class ClsDriverBankDetail
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string SortCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountTitle { get; set; }
        public string BankName { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyVatNumber { get; set; }
        public string IbanNumber { get; set; }
        public string BlcNumber { get; set; }
    }
}
