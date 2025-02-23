using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Categorys;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(400).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            
            builder.Property(p => p.Category).HasConversion(c => c.Id, id => Category.GetById(id)!);
        }
    }
}