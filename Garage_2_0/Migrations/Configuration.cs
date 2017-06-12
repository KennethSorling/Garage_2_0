namespace Garage_2_0.Migrations
{
    using Enum;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Garage_2_0.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage_2_0.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Vehicles.AddOrUpdate(
                p => p.RegCode,
                new ParkedVehicle { RegCode = "ABC123", Type = VehicleType.Airplane, Model = "747", Brand = "Boeing", NumberOfWheels = 3, Color = VehicleColor.White, DateCheckedIn = DateTime.Now },
                new ParkedVehicle { RegCode = "117", Type= VehicleType.Car, Brand="Ford", Model="T", Color = VehicleColor.Black, NumberOfWheels=4, DateCheckedIn = DateTime.Now},
                new ParkedVehicle { RegCode = "GHI789", Type = VehicleType.Motorcycle, Brand = "Harley-Davidson", Model = "Sportster", NumberOfWheels = 2, Color = VehicleColor.Red, DateCheckedIn = DateTime.Now },
                new ParkedVehicle { RegCode = "MNO012", Type = VehicleType.Boat, Brand = "Yamaha", Model = "242 Limited S", Color=VehicleColor.White, NumberOfWheels = 0, DateCheckedIn = DateTime.Now },
                new ParkedVehicle { RegCode = "DEF456", Type= VehicleType.Bus, Color = VehicleColor.Red, Brand="SL", Model = "Blåbuss", NumberOfWheels=8, DateCheckedIn = DateTime.Now}

                );
        }
    }
}
