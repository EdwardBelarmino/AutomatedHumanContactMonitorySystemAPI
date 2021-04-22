namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactNumberToAttendeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendees", "ContactNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendees", "ContactNumber");
        }
    }
}
