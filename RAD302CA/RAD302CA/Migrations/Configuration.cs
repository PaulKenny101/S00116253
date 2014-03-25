using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using RAD302CA.Models;

namespace RAD302CA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD302CA.DAL.TravelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RAD302CA.DAL.TravelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
   
            var guests1 = new List<Guest>
                          {
                              new Guest {GuestName = "Franky"},
                              new Guest {GuestName = "Gareth"},
                              new Guest {GuestName = "Zlatan"}

                          };
            var guests2 = new List<Guest>
                          {
                              new Guest {GuestName = "Paul"},
                                new Guest {GuestName = "Leo"},
                                 new Guest {GuestName = "Chris"}
                          };
            var guests3 = new List<Guest>
                          {
                             new Guest {GuestName = "conor"},
                             new Guest {GuestName = "Sean"},
                              new Guest {GuestName = "tom"}

                          };
            var guests4 = new List<Guest>
                          {
                              new Guest {GuestName = "tommy"},
                             new Guest {GuestName = "matt"},
                              new Guest {GuestName = "aidan"}

                          };
            guests1.ForEach(g => context.Guests.Add(g));
            guests2.ForEach(g => context.Guests.Add(g));
            guests3.ForEach(g => context.Guests.Add(g));
            guests4.ForEach(g => context.Guests.Add(g));

            
            
                           

           context.Trips.AddOrUpdate(
               t => t.TripName,
               new Models.Trip { TripName = "Longford Lookabout", StartDate = DateTime.Parse("01/03/14"), EndDate = DateTime.Parse("06/03/14"), TripComplete = true, TripViable = true, TripId = 1},
               new Models.Trip { TripName = "Cork Lookabout", StartDate = DateTime.Parse("20/03/14"), EndDate = DateTime.Parse("27/03/14"), TripComplete = false, TripViable = true, TripId = 2},
               new Models.Trip { TripName = "Sligo Lookabout", StartDate = DateTime.Parse("27/03/14"), EndDate = DateTime.Parse("06/03/14"), TripComplete = true, TripViable = false, TripId = 3},
               new Models.Trip { TripName = "Leitrim Lookabout", StartDate = DateTime.Parse("01/03/14"), EndDate = DateTime.Parse("06/03/14"), TripComplete = true, TripViable = true, TripId = 4},
               new Models.Trip { TripName = "Wicklow Lookabout", StartDate = DateTime.Parse("01/03/14"), EndDate = DateTime.Parse("06/03/14"), TripComplete = true, TripViable = true, TripId = 5}


               );

            context.Legs.AddOrUpdate(
                l => l.LegId,
                new Leg { TripId = 1, StartDate = DateTime.Parse("01/03/14"), StartLocation = "Legan", EndDate = DateTime.Parse("03/03/14"), EndLocation = "Ballymahon", Guests = guests1},
                new Leg { TripId = 1, StartDate = DateTime.Parse("04/03/14"), StartLocation = "Ballymahon", EndDate = DateTime.Parse("05/03/14"), EndLocation = "Killoe", Guests = guests1},
                new Leg { TripId = 1, StartDate = DateTime.Parse("05/03/14"), StartLocation = "Farnagh", EndDate = DateTime.Parse("06/03/14"), EndLocation = "Demense", Guests = guests1},
                new Leg { TripId = 2, StartDate = DateTime.Parse("20/03/14"), StartLocation = "Clonakility", EndDate = DateTime.Parse("24/03/14"), EndLocation = "Mallow", Guests = guests2 },
                new Leg { TripId = 2, StartDate = DateTime.Parse("25/03/14"), StartLocation = "Youghal", EndDate = DateTime.Parse("27/03/14"), EndLocation = "", Guests = guests1 }


               

                );
        }
    }
}
