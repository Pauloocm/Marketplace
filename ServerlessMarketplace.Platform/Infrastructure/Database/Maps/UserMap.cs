using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerlessMarketplace.Domain.User;

namespace ServerlessMarketplace.Platform.Infrastructure.Database.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired(false);
        }
    }
}