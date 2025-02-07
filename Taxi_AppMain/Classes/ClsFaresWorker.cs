using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi_Model;

namespace Taxi_AppMain
{
    public class clsfaresworker
    {
        public int? returnActualVehicleTypeId;
        public int? returnVehicleTypeId;
        public int? vehicleTypeId;
        public bool IsMoreFareWise;
        public int defaultVehicleId;
        public int fromZoneId;
        public int toZoneId;
        public string tempFromPostCode = "";
        public string tempToPostCode = "";
        public string fromAddress = "";
        public string toAddress = "";
        public decimal distance;
        public string distancestring;
        public decimal fareVal;
        public decimal returnfares;
        public decimal companyPrice;
        public decimal agentPrice;
        public decimal agentcharge;

        public decimal agentPercent;
        public bool IsAmountWiseAgentFees;
        public bool IsAirportAgentFares;
        public bool IsAgent;
        public bool hasVia;
        public int? fromLocTypeId;
        public int? toLocTypeId;
        public int? fromLocationId;
        public int? toLocationId;
        public string[] viaList;
        public int tempToLocId;
        public int tempFromLocId;
        public string fromLocName;
        public string toLocName;
        public string fromPostCode;
        public string toPostCode;
        public int? CompanyId;
        public decimal airportPickupChrgs = 0;
        public decimal airportDropOffChrgs = 0;

        public DateTime? pickupDateTime;
        public DateTime? returnpickupdateTime;
        public int SubCompanyId;
        public bool IsReverse;
        public decimal dd;
        public int PaymentTypeId;
        public int JourneyTypeId;
        public decimal TotalSurcharge;
        public decimal TotalSurchargeParking;
        public decimal TotalSurchargeExtra;
        public decimal ExtraViaCharges = 0.00m;
        public decimal Congestion = 0.00m;
        public decimal peakFactorX = 0.00m;
        public Gen_ServiceCharge objServiceCharge;
        public List<ClsViaLocations> ViaLocations = null;

        public decimal ReturnOtherParking;
        public decimal OtherParking;

        public decimal manualMiles;
    }


    public class ChargesList
    {
        public decimal driverPrice;
        public decimal accountPrice;
        public bool IsFixedFare;
        public decimal mileage;
        public string pickup;
        public string destination;


    }

    public class ClsViaLocations
    {
        public int OrderNo;
        public int? LocId;
        public int LocTypeId;
        public string ViaLocValue;


    }
}
