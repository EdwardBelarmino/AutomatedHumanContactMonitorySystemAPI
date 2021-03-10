namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttendanceTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "LocationId", c => c.Int(nullable: false));
        }
    }
}
