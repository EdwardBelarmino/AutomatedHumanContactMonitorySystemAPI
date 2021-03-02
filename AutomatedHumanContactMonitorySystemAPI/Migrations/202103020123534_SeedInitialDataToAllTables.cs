namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedInitialDataToAllTables : DbMigration
    {
        public override void Up()
        {
            //Sql($"INSERT INTO Attendances (AttendeeId, VisitedDateTime, Temperature, PlaceId) VALUES (1, {DateTime.Now}, 37, 1)"); //Seed Attendances table
            Sql("INSERT INTO Attendees (Name, Age, Address) VALUES ('Ravni Arador', 20, 'Tarlac City')"); //Seed Attendees table
            Sql("INSERT INTO Places (Location) VALUES ('SM Tarlac')"); //Seed Places table
        }
        
        public override void Down()
        {
        }
    }
}
