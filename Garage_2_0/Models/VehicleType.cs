using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_2_0.Models
{
    public class VehicleType
    {
        public int Id {get; set;}
        [Display(Name="Vehicle Type")]
        public string TypeName { get; set; }
    }
}