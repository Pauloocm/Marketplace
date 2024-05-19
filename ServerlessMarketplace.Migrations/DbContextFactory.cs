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

            optionsBuilder.UseNpgsql("Server=localhost;Database=marketplace;Username=postgres;Password=root;TrustServerCertificate=True", 
                b => b.MigrationsAssembly("ServerlessMarketplace.Migrations"));

            return new DataContext();
        }
    }
}
