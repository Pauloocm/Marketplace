using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Maps;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=marketplace;Username=postgres;Password=root",
                b => b.MigrationsAssembly("ServerlessMarketplace.Migrations"));

            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
        }

        public DbSet<Product> Products { get; set; }

    }
}
