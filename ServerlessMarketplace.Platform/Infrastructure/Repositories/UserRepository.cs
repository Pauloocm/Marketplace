using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.User;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        private readonly DataContext dataContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<User?> GetBasicInformation(Guid userId, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(userId);

            return await dataContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId, ct);
        }

        public async Task<User?> GetBy(Guid userId, string? include = null!, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(userId);

            return await dataContext.Users.FirstOrDefaultAsync(u => u.Id == userId, ct);
        }


    }
}
