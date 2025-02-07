using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Taxi_AppMain
{
    public class ClsAgentCommissionSummary
    {
        public int? CompanyId { get; set; }
        public string ClientName { get; set; }
        public string Period { get; set; }
        public int? Job { get; set; }
        public decimal? Amount { get; set; }

    }
}