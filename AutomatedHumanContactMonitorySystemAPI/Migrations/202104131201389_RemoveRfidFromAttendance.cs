namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRfidFromAttendance : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "RFID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "RFID", c => c.Long(nullable: false));
        }
    }
}
