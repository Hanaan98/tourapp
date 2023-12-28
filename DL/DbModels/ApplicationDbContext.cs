using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
        public DbSet<PlaceDbDto> Places { get; set; }
        public DbSet<ReviewDbDto> Reviews { get; set; }
        public DbSet<TourDbDto> Tours { get; set; }
        public DbSet<BookingDbDto> Bookings { get; set; }
        public DbSet<UserDbDto> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Primary Keys
            builder.Entity<UserDbDto>().HasKey(user => user.Id);
            builder.Entity<PlaceDbDto>().HasKey(pl => pl.Id);
            builder.Entity<TourDbDto>().HasKey(tr => tr.Id);
            builder.Entity<ReviewDbDto>().HasKey(rv => rv.Id);
            builder.Entity<BookingDbDto>().HasKey(b => b.Id);


            // Relations
            builder.Entity<TourDbDto>().HasOne(tr => tr.Place)
            .WithMany(pl => pl.Tours)
            .HasForeignKey(tr => tr.PlaceId);

            builder.Entity<BookingDbDto>()
            .HasOne(b => b.Tour)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TourId);

            builder.Entity<BookingDbDto>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

            //Index
            builder.Entity<UserDbDto>().HasIndex(u => u.Email).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
