using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_GetDriversListResultEx
    {







        public stp_GetDriversListResultEx() { }


        
        public int Id { get; set; }



       

      
        public string No { get; set; }


      
        public string Name { get; set; }
        public string SurName { get; set; }


        public string DriverType { get; set; }


        public string VehicleNo { get; set; }

     
        public string VehicleType { get; set; }

      
        public string DrvBadge { get; set; }

        public string VehBadge { get; set; }
       



      
        public string NI { get; set; }

     
        public DateTime? MOTExpiry { get; set; }


       
        public DateTime? MOT2Expiry { get; set; }


      
        public DateTime? PCOVehicleExpiry { get; set; }



      
        public DateTime? InsuranceExpiry { get; set; }


      
        public DateTime? PCODriverExpiry { get; set; }


      
        public DateTime? LicenseExpiry { get; set; }


    
        public DateTime? RoadTaxExpiry { get; set; }



       
        public string MobileNo { get; set; }





    
        public DateTime? EndDate { get; set; }
    
        

      
       
     
        public int? DriverTypeId { get; set; }

    
    }
}
