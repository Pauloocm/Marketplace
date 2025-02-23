using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Orders;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Maps;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Context
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
