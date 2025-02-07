using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class stp_AddAllDriverRentResultEx
    {
        public stp_AddAllDriverRentResultEx()
        {

        }

     
        public bool? UseCompanyVehicle { get; set; }
     
        public decimal PrimeCompanyRent { get; set; }
  
        public decimal CarInsuranceRent { get; set; }

        public decimal CarRent { get; set; }
    
        public long RentId { get; set; }

        public decimal RentDue { get; set; }
     
        public bool? IsPrimeCompanyDriver { get; set; }

        public decimal JobsTotal { get; set; }
      
        public decimal OldBalance { get; set; }

        public decimal? PDARent { get; set; }
      
        public decimal? DriverMonthlyRent { get; set; }
      
        public string DriverName { get; set; }

        public string DriverNo { get; set; }

        public int Id { get; set; }
     
        public decimal InitialBalance { get; set; }

        public decimal VAT { get; set; }
        //public decimal BookingFee { get; set; }
        //public decimal AccBookingFee { get; set; }
    }
}
