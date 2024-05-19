using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p =>p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p =>p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p =>p.Price).IsRequired();
            builder.Ignore(p => p.Category);
        }
    }
}
