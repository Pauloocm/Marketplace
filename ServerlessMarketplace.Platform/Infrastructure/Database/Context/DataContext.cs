using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=marketplace;Username=postgres;Password=root");
        }

        public DbSet<Product> Products { get; set; }

    }
}
