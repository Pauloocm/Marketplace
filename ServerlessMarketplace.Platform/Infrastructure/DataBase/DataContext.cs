using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Infrastructure.DataBase
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SplanDb");
        }

        public DbSet<Product> Products { get; set; }

    }
}
