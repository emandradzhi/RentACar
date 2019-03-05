using Microsoft.EntityFrameworkCore;
using RentACar.Models.Car;
using RentACar.Models.Place;
using RentACar.Models.User;

namespace RentACar.Data
{
    public class AppDbContext:DbContext
    {
        private string connection;

        public AppDbContext()
        {
            this.connection = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=RentACar;Integrated Security=True;MultipleActiveResultSets=true;";
        }

        public DbSet<RentACar.Models.Car.Car> Cars { get; set; }
        public DbSet<RentACar.Models.Place.Place> Places { get; set; }
        public DbSet<RentACar.Models.User.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Place>().ToTable("Place");
            modelBuilder.Entity<User>().ToTable("User");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
