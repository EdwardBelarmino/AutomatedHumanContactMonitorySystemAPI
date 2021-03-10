namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLocationIdToPlaceIdInAttendanceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Place_Id", "dbo.Places");
            DropIndex("dbo.Attendances", new[] { "Place_Id" });
            RenameColumn(table: "dbo.Attendances", name: "Place_Id", newName: "PlaceId");
            AlterColumn("dbo.Attendances", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendances", "PlaceId");
            AddForeignKey("dbo.Attendances", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
            DropColumn("dbo.Attendances", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Attendances", "PlaceId", "dbo.Places");
            DropIndex("dbo.Attendances", new[] { "PlaceId" });
            AlterColumn("dbo.Attendances", "PlaceId", c => c.Int());
            RenameColumn(table: "dbo.Attendances", name: "PlaceId", newName: "Place_Id");
            CreateIndex("dbo.Attendances", "Place_Id");
            AddForeignKey("dbo.Attendances", "Place_Id", "dbo.Places", "Id");
        }
    }
}
