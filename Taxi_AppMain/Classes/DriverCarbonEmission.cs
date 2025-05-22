using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain.Classes
{
    public class DriverCarbonEmission
    {       
            public string Id { get; set; }                   
            public string JobDateTime { get; set; }     
            public string DriverId { get; set; }            
            public string DistanceInMiles { get; set; }   
            public string JobNo { get; set; }             
            public string PONumber { get; set; }          
            public string VehicleMake { get; set; }       
            public string VehicleModel { get; set; }      
            public string FuelType { get; set; }          
            public string PickupPoint { get; set; }       
            public string Destination { get; set; }       
            public string CO2GramPerMile { get; set; }  
            public string TotalCO2Kg { get; set; }      
    }
}
