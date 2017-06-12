namespace Garage_2_0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddatebugIthink : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "DateCheckedIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "DateCheckedIn", c => c.DateTime(nullable: false));
        }
    }
}
