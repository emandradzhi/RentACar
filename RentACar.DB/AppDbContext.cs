using Microsoft.EntityFrameworkCore;
using RentACar.Models;
using System;

namespace RentACar.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<RentACar.Models.Car> Cars { get; set; }
        public DbSet<RentACar.Models.Place> Places { get; set; }
        public DbSet<RentACar.Models.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Place>().ToTable("Place");
            modelBuilder.Entity<User>().ToTable("User");
        }

    }
}
