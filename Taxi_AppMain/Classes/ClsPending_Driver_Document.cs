using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class ClsPending_Driver_Document
    {   
        public long Id {get;set;}
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        //public int DriverId {get;set;}
        public string DriverNo { get; set; }        
        //public int DocumentId { get; set; }        
        public string DocumentName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? ExpiryDate { get; set; }        
        //public string FileName { get; set; }
        //public string FilePath { get; set; }
        public string BadgeNumber { get; set; }
        public string Status { get; set; }
        //public DateTime UploadDate { get; set; }
        //public DateTime ApprovedDate { get; set; }
        //public DateTime RejectedDate { get; set; }
    }
}
