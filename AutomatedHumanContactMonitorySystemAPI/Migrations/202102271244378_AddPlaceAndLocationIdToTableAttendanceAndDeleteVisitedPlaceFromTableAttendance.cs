namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlaceAndLocationIdToTableAttendanceAndDeleteVisitedPlaceFromTableAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "Place_Id", c => c.Int());
            CreateIndex("dbo.Attendances", "Place_Id");
            AddForeignKey("dbo.Attendances", "Place_Id", "dbo.Places", "Id");
            DropColumn("dbo.Attendances", "VisitedPlace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "VisitedPlace", c => c.String());
            DropForeignKey("dbo.Attendances", "Place_Id", "dbo.Places");
            DropIndex("dbo.Attendances", new[] { "Place_Id" });
            DropColumn("dbo.Attendances", "Place_Id");
            DropColumn("dbo.Attendances", "LocationId");
        }
    }
}
