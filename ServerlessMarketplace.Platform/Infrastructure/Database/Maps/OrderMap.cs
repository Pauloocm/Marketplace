using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Orders;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.CustomerId).ValueGeneratedNever();

            builder.Property(p => p.CreatedAt);

            builder.Ignore(p => p.Total);

            builder.HasOne(p => p.Customer)
               .WithMany(c => c.OrdersHistory)
               .HasForeignKey(p => p.CustomerId);

            builder.HasMany(p => p.Products)
               .WithOne(o => o.Order)
               .HasForeignKey(o => o.OrderId);
        }
    }
}