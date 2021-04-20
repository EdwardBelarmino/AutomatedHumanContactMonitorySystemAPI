namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAdminColumnInAppUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "IsAdmin");
        }
    }
}
