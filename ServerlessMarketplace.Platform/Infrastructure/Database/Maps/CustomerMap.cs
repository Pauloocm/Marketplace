using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Customer;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Age).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(150).IsRequired();
            //TODO finalizar mapeamento
            // builder.HasMany(p => p.OrdersHistory).map
        }
    }
}