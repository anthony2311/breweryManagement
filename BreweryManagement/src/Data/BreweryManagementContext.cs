using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class BreweryManagementContext : DbContext
    {
        public BreweryManagementContext(DbContextOptions<BreweryManagementContext> options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Brewery { get; set; }
        public DbSet<Wholesaler> Wholesaler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().HasData(new Beer()
            {
                Id = 1,
                Name = "Leffe Blonde",
                AlcoholDegree = 6.6,
                Price = 2.20
            });

            modelBuilder.Entity<Brewery>().HasData(new Brewery()
            {
                Id = 1,
                Name = "Abbaye de Leffe"
            });

            modelBuilder.Entity<Wholesaler>().HasData(new Wholesaler()
            {
                Id = 1,
                Name = "GeneDrinks"
            });

        }
    }
}
