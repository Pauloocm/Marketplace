using ServerlessMarketplace.Domain.User;
using ServerlessMarketplace.Platform.Application.Users.Filters;
using ServerlessMarketplace.Platform.Dtos;
using ServerlessMarketplace.Platform.Dtos.Users;

namespace ServerlessMarketplace.Platform.Application.Users
{
    public class UserAppService(IUserRepository userRepo) : IUserAppService
    {
        private readonly IUserRepository userRepository =
            userRepo ?? throw new ArgumentNullException(nameof(userRepo));

        public async Task<UserBasicInformationDto> GetBasicInformation(GetUserBasicInformationFilter filter, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var user = await userRepository.GetBasicInformation(filter.UserId, ct);

            return user.ToDto();
        }
    }
}
