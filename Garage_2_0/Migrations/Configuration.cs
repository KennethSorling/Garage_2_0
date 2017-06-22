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

            context.VehicleTypes.AddOrUpdate(
                v => v.TypeName,
                new VehicleType { TypeName = "AirPlane"},
                new VehicleType { TypeName = "Boat"},
                new VehicleType { TypeName = "Bus"},
                new VehicleType { TypeName = "Car"},
                new VehicleType { TypeName = "Motorcycle"}
                );
            context.SaveChanges();

            context.Members.AddOrUpdate(
                  m => m.LastName,
                  new Member { LastName = "Fazzula", FirstName="Manggia", Age = 65, Phone ="070-0707070" },
                  new Member { LastName = "Karlsson", FirstName = "Bert", Age = 45, Phone = "08-0808080" },
                  new Member { LastName = "Svenssson", FirstName="Ronny", Age= 49, Phone="073-777 33 22" },
                  new Member { LastName = "Persson", FirstName = "Axel", Age = 32, Phone = "073-777 33 22" },
                  new Member { LastName = "Jönsson", FirstName = "Jöns", Age=25, Phone="0771-222 33 44"}
                );
            context.SaveChanges();

            var airplaneTypeId  = context.VehicleTypes.Where(p => p.TypeName == "Airplane").FirstOrDefault().Id;
            var boatTypeId = context.VehicleTypes.Where(p => p.TypeName == "Boat").FirstOrDefault().Id;
            var busTypeId = context.VehicleTypes.Where(p => p.TypeName == "Bus").FirstOrDefault().Id;
            var carTypeId = context.VehicleTypes.Where(p => p.TypeName == "Car").FirstOrDefault().Id;
            var motorbikeTypeId = context.VehicleTypes.Where(p => p.TypeName == "Motorcycle").FirstOrDefault().Id;
            var ownerId = context.Members.Where(p => p.LastName == "Fazzula").FirstOrDefault().MemberId;

            context.Vehicles.AddOrUpdate(
                p => p.RegCode,
                new ParkedVehicle { RegCode = "ABC123", VehicleTypeId = airplaneTypeId, Model = "747", Brand = "Boeing", NumberOfWheels = 3, Color = VehicleColor.White, DateCheckedIn = currentTime, MemberId = 1 },
                new ParkedVehicle { RegCode = "117",    VehicleTypeId = carTypeId, Brand = "Ford", Model = "T", Color = VehicleColor.Black, NumberOfWheels = 4, DateCheckedIn = anHourAgo, MemberId = 2 },
                new ParkedVehicle { RegCode = "QWE546", VehicleTypeId = carTypeId, Brand = "Renault", Model = "Clio", Color = VehicleColor.Red, NumberOfWheels = 4, DateCheckedIn = anHourAgo, MemberId = 3 },
                new ParkedVehicle { RegCode = "GHI789", VehicleTypeId = motorbikeTypeId,  Brand = "Harley-Davidson", Model = "Sportster", NumberOfWheels = 2, Color = VehicleColor.Red, DateCheckedIn = yesterdayNoon, MemberId = 5 },
                new ParkedVehicle { RegCode = "MNO012", VehicleTypeId = boatTypeId, Brand = "Yamaha", Model = "242 Limited S", Color = VehicleColor.White, NumberOfWheels = 0, DateCheckedIn = DateTime.Now.AddHours(-0.5), MemberId = 4 },
                new ParkedVehicle { RegCode = "DEF456", VehicleTypeId = busTypeId, Color = VehicleColor.Red, Brand = "SL", Model = "Blåbuss", NumberOfWheels = 8, DateCheckedIn = DateTime.Now.AddMinutes(-15), MemberId = 3 },
                new ParkedVehicle { RegCode = "FED654", VehicleTypeId = busTypeId, Color = VehicleColor.Red, Brand = "London Doubledecker", Model = "Bendy", NumberOfWheels = 8, DateCheckedIn = DateTime.Now.AddMinutes(-125), MemberId = 1 }
                );
        }
    }
}
