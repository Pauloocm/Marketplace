using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Orders;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.OrderId).ValueGeneratedNever();
            builder.Property(p => p.ProductId).ValueGeneratedNever();

            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId);

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}