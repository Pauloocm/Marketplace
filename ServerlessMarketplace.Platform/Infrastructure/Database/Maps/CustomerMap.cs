using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(p => p.Name).HasMaxLength(210).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(150).IsRequired();

            builder.HasOne(c => c.Owner)
                .WithOne()
                .HasForeignKey<Customer>(c => c.OwnerId)
                .IsRequired(false);

            builder.HasMany(c => c.OrdersHistory)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            builder.HasMany(c => c.WishList)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerWishList",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    j => j.HasOne<Customer>().WithMany().HasForeignKey("CustomerId")
                );
        }
    }
}