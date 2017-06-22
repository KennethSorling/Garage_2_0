using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Garage_2_0.Enum;

namespace Garage_2_0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        [ForeignKey("MemberId")]
        public int OwnerId { get; set; }
        public int VehicleTypeId { get; set; }
        [Display(Name = "Registration Code")]
        public string RegCode { get; set; }
        [Display(Name = "Vehicle Type")]
        public string Brand { get; set; }
        public string Model { get; set; }
        public VehicleColor Color { get; set; }
        [Display(Name = "Number of Wheels")]
        [Range(0, Int32.MaxValue)]
        public int NumberOfWheels { get; set; }
        [Display(Name = "Time of Parking")]
        public DateTime? DateCheckedIn { get; set; }

        public VehicleType Type { get; set; }
        public Member Owner { get; set; }
    }

    //public class ParkedVehicle
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Registration Code")]
    //    public string RegCode { get; set; }
    //    [Display(Name = "Vehicle Type")]
    //    public VehicleType Type { get; set; }
    //    public string Brand { get; set; }
    //    public string Model { get; set; }
    //    public VehicleColor Color { get; set; }
    //    [Display(Name = "Number of Wheels")]
    //    [Range(0, Int32.MaxValue)]
    //    public int NumberOfWheels { get; set; }
    //    [Display(Name = "Time of Parking")]
    //    public DateTime? DateCheckedIn { get; set; }
    //}
}