using Microsoft.EntityFrameworkCore;
using Sale_With_Maui.Shared.Entities;

namespace Sale_With_Maui.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
        }
    }
}
