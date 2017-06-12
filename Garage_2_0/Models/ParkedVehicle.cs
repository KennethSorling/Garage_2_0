using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage_2_0.Enum;

namespace Garage_2_0.Models
{
    public class ParkedVehicle
    {
        public string RegCode { get; set; }
        public VehicleType Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public VehicleColor Color { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime DateCheckedIn { get; set; }
    }
}