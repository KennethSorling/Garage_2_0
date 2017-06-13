using Garage_2_0.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2_0.Models
{
    public class UnparkedVehicleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Registration Code")]
        public string RegCode { get; set; }
        [Display(Name = "Vehicle Type")]
        public VehicleType Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public VehicleColor Color { get; set; }
        [Display(Name = "Number of Wheels")]
        public int NumberOfWheels { get; set; }
        [Display(Name = "Parked")]
        public DateTime DateCheckedIn { get; set; }
        [Display(Name = "Checked Out")]
        public DateTime DateCheckedOut { get; set; }
        [Display(Name = "Hourly Parking Rate")]
        public Single HourlyRate { get; set; }
        [Display(Name = "Time Parked")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan TimeParked
        {
            get {
                return DateCheckedOut - DateCheckedIn;
            }
        }
        [Display(Name = "Total Charge")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double TotalCharge
        {
            get {
                TimeSpan parkedTime = this.TimeParked;
                double totalMinutes = parkedTime.TotalMinutes;
                double intervals = Math.Ceiling(totalMinutes / 5.0f);
                double pricePerInterval = 5 * (HourlyRate / 60);
                return Math.Floor(intervals * pricePerInterval);
            }
        }
        public UnparkedVehicleViewModel()
        {
            HourlyRate = 65.0f;
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
            HourlyRate = 65.0f;
        }
    }
}