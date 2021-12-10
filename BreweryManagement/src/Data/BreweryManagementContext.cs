using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<WholesalerStock> WholesalerStock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .HasOne(b => b.Brewery)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<WholesalerStock>()
                .HasKey(ws => new { ws.BeerId, ws.WholesalerId });
            modelBuilder.Entity<WholesalerStock>()
                .HasOne(ws => ws.Beer)
                .WithMany(b => b.WholesalerStocks)
                .HasForeignKey(ws => ws.BeerId);
            modelBuilder.Entity<WholesalerStock>()
                .HasOne(ws => ws.Wholesaler)
                .WithMany(b => b.WholesalerStocks)
                .HasForeignKey(ws => ws.WholesalerId);

            // add sample on database
            DataSample.GetWholesalers().ForEach(wholesaler =>
            {
                modelBuilder.Entity<Wholesaler>().HasData(wholesaler);
            });
            DataSample.GetBreweries().ForEach(brewery =>
            {
                modelBuilder.Entity<Brewery>().HasData(brewery);
            });
            DataSample.GetBeers().ForEach(beer =>
            {
                modelBuilder.Entity<Beer>().HasData(beer);
            });
            DataSample.GetWholesalerStocks().ForEach(wholesalerStock =>
            {
                modelBuilder.Entity<WholesalerStock>().HasData(wholesalerStock);
            });
        }

    }
}
