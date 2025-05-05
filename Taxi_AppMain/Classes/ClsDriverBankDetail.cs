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
        public string CompanyNo { get; set; }
        public string CompanyVatNo { get; set; }
        public string IbanNo { get; set; }
        public string BlcNo { get; set; }
    }
}
