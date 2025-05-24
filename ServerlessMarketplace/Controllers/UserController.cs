using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Customers;
using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Resources.Extensions;
using System.Security.Claims;

namespace ServerlessMarketplace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController(ICustomerAppService customerAppService) : ControllerBase()
    {
        private readonly ICustomerAppService customerAppService =
            customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrUpdateCustomerCommand command, CancellationToken ct = default)
        {
            command.EnsureIsValid();

            ClaimsPrincipal current = this.User;

            var customerId = await customerAppService.CreateOrUpdate(command, ct);

            return Ok(customerId);
        }
    }
}