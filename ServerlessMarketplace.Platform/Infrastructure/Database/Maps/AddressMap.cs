using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.Addresses;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.CustomerId).ValueGeneratedNever();
            
            builder.Property(p => p.Country).HasMaxLength(100).IsRequired();
            builder.Property(p => p.State).HasMaxLength(100).IsRequired();
            builder.Property(p => p.City).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Street).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Number).HasMaxLength(10).IsRequired();
            builder.Property(p => p.ZipCode).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Complement).HasMaxLength(200);
            
            builder.HasOne(p => p.Customer)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.CustomerId);
        }
    }
}