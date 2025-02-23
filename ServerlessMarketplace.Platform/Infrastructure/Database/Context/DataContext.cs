using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Maps;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Context
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItemMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
        }

        public DbSet<Product> Products { get; set; }
    }
}
