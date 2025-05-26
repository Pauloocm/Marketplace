using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Users;
using ServerlessMarketplace.Platform.Application.Users.Filters;

namespace ServerlessMarketplace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserAppService userService) : ControllerBase()
    {
        private readonly IUserAppService userAppService =
            userService ?? throw new ArgumentNullException(nameof(userService));

        [HttpGet]
        public async Task<IActionResult> GetBasicInformation([FromQuery] GetUserBasicInformationFilter? filter, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var basicInformation = await userAppService.GetBasicInformation(filter, ct);

            return Ok(basicInformation);
        }
    }
}