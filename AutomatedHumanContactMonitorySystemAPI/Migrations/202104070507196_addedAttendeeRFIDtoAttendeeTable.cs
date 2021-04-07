namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAttendeeRFIDtoAttendeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "AttendeeRFID", c => c.Long(nullable: false));
            AddColumn("dbo.Attendees", "AttendeeRFID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "AttendeeRFID");
            DropColumn("dbo.Attendances", "AttendeeRFID");
        }
    }
}
