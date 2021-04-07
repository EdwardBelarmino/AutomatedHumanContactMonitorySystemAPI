namespace AutomatedHumanContactMonitorySystemAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedHumanContactMonitorySystemAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutomatedHumanContactMonitorySystemAPI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Places.Add(new Models.Place { Location = "SM Tarlac City" });

            context.Attendees.Add(new Models.Attendee { Name = "Juan Pinas", 
                                                        Address = "Quezon City", 
                                                         });

            //context.Attendances.Add(new Models.Attendance { AttendeeId = 1, 
            //                                                VisitedDateTime = DateTime.Now, 
            //                                                Temperature = 37, 
            //                                                PlaceId = 1 });
        }
    }
}
