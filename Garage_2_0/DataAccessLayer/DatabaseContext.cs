﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage_2_0.Models;

namespace Garage_2_0.DataAccessLayer
{
    public class GarageContext: DbContext
    {
        public GarageContext() : base("Garage2.5") { }
        public DbSet<ParkedVehicle> Vehicles { get; set;}
        public DbSet<Member> Members { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
