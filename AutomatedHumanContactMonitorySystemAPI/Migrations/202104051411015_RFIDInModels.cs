namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RFIDInModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "RFID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "RFID");
        }
    }
}
