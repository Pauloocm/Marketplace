using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;

namespace ServerlessMarketplace.Migrations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseNpgsql("Server=localhost:5433;Database=Product;Username=postgres;Password=root", 
                b => b.MigrationsAssembly("ServerlessMarketplace.Migrations"));

            return new DataContext(optionsBuilder.Options);
        }
    }
}
