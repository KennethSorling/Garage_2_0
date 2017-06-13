namespace Garage_2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnparkedVehicleViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegCode = c.String(),
                        Type = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        Color = c.Int(nullable: false),
                        NumberOfWheels = c.Int(nullable: false),
                        DateCheckedIn = c.DateTime(nullable: false),
                        DateCheckedOut = c.DateTime(nullable: false),
                        HourlyRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnparkedVehicleViewModels");
        }
    }
}
