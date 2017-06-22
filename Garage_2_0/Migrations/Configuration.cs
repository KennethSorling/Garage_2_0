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
            var currentTime = DateTime.Now;
            var anHourAgo = currentTime.AddMinutes(-65);
            var yesterdayNoon = new DateTime(2017, currentTime.Month, currentTime.Day - 1, 12, 0, 0, DateTimeKind.Local);

            var airplane = new VehicleType { Id = 1, TypeName = "Airplane" };
            var boat = new VehicleType { Id = 2, TypeName = "Boat" };
            var bus = new VehicleType { Id = 3, TypeName = "Bus" };
            var car = new VehicleType { Id = 4, TypeName = "Car" };
            var motorbike = new VehicleType { Id = 5, TypeName = "Motorcycle" };
            context.VehicleTypes.

            context.Vehicles.AddOrUpdate(
                p => p.RegCode,
                new ParkedVehicle { RegCode = "ABC123", Type = airplane, Model = "747", Brand = "Boeing", NumberOfWheels = 3, Color = VehicleColor.White, DateCheckedIn = currentTime},
                new ParkedVehicle { RegCode = "117", Type= car, Brand="Ford", Model="T", Color = VehicleColor.Black, NumberOfWheels=4, DateCheckedIn = anHourAgo},
                new ParkedVehicle { RegCode = "QWE546", Type = car, Brand = "Renault", Model = "Clio", Color = VehicleColor.Red, NumberOfWheels = 4, DateCheckedIn = anHourAgo },
                new ParkedVehicle { RegCode = "GHI789", Type = motorbike, Brand = "Harley-Davidson", Model = "Sportster", NumberOfWheels = 2, Color = VehicleColor.Red, DateCheckedIn = yesterdayNoon },
                new ParkedVehicle { RegCode = "MNO012", Type = boat, Brand = "Yamaha", Model = "242 Limited S", Color=VehicleColor.White, NumberOfWheels = 0, DateCheckedIn = DateTime.Now.AddHours(-0.5) },
                new ParkedVehicle { RegCode = "DEF456", Type= bus, Color = VehicleColor.Red, Brand="SL", Model = "Blåbuss", NumberOfWheels=8, DateCheckedIn = DateTime.Now.AddMinutes(-15)},
                new ParkedVehicle { RegCode = "FED654", Type = bus, Color = VehicleColor.Red, Brand = "London Doubledecker", Model = "Bendy", NumberOfWheels = 8, DateCheckedIn = DateTime.Now.AddMinutes(-125) }
                );
        }
    }
}
