namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAttendanceRfidAndAddStatusInAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Status", c => c.String());
            DropColumn("dbo.Attendances", "AttendeeRFID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "AttendeeRFID", c => c.Long(nullable: false));
            DropColumn("dbo.Attendances", "Status");
        }
    }
}
