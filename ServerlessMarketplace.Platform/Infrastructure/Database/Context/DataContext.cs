using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Orders;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.User;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
