using Garage_2_0.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2_0.Models
{
    public class UnparkedVehicleViewModel
    {
        public int Id { get; set; }
        public string RegCode { get; set; }
        public VehicleType Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public VehicleColor Color { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime DateCheckedIn { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public Single HourlyRate { get; set; }
        public double TotalCharge()
        {
            TimeSpan parkedTime = DateCheckedOut - DateCheckedIn;
            double totalHours = parkedTime.TotalHours;
            return totalHours * HourlyRate;
        }
        public UnparkedVehicleViewModel()
        {
            HourlyRate = 125.0f;
        }

        public UnparkedVehicleViewModel(ParkedVehicle v)
        {
            Id = v.Id;
            Type = v.Type;
            RegCode = v.RegCode;
            Brand = v.Brand;
            Model = v.Model;
            NumberOfWheels = v.NumberOfWheels;
            DateCheckedIn = (DateTime)v.DateCheckedIn;
            DateCheckedOut = DateTime.Now;
            HourlyRate = 125.0f;
        }
    }
}