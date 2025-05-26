using ServerlessMarketplace.Platform.Application.Users.Filters;
using ServerlessMarketplace.Platform.Dtos.Users;

namespace ServerlessMarketplace.Platform.Application.Users
{
    public interface IUserAppService
    {
        Task<UserBasicInformationDto> GetBasicInformation(GetUserBasicInformationFilter filter, CancellationToken ct = default);
    }
}
