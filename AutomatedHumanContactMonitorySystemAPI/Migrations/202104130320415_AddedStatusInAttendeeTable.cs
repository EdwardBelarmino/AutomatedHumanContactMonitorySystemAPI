namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusInAttendeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "Status");
        }
    }
}
