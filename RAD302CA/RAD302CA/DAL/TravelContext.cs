using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using RAD302CA.Models;

namespace RAD302CA.DAL
{
    public class TravelContext:DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}