﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_AppMain
{
    public class ClsDrivers
    {

        public int? DriverId;
        public string DriverNo;
        public string LocationName;
        public double Distance;
        public int? VehicleTypeId;
        public int? NoOfPassenger;

        public double? DrvLatitude;
        public double? DrvLongitude;
    }
    public class clsETA
    {
        public double? originLat;
        public double? originLng;
        public double? destLat;
        public double? destLng;
        public string keys;
        public string defaultclientid;
        public string token;

    }
}
