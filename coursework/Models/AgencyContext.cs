using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace coursework.Models
{
    public class AgencyContext : DbContext
    {
        public AgencyContext() : base("DefaultConnection")
        {
            //Database.SetInitializer(new DbInitializer());
        }


        public DbSet<Country> Countries { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Tourist> Tourists { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelService>()
            .HasKey(h => new { h.HotelId, h.ServiceId });

            modelBuilder.Entity<HotelService>()
                .HasRequired(hs => hs.Hotel)
                .WithMany(h => h.HotelServices)
                .HasForeignKey(hs => hs.HotelId);

            modelBuilder.Entity<HotelService>()
                .HasRequired(hs => hs.Service)
                .WithMany(s => s.HotelServices)
                .HasForeignKey(hs => hs.ServiceId);
        }
    }
}