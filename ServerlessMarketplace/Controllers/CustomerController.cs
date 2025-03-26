using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Customers;
using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Platform.Application.Orders;

namespace ServerlessMarketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ICustomerAppService customerAppService) : ControllerBase()
    {
        private readonly ICustomerAppService customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand command, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var customerId = await customerAppService.Add(command, ct);
        
            return Ok(customerId);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> Order([FromBody] AddOrderCommand command,  CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(command);
        
            // var product = await customerAppService.AddOrder(command, ct);
        
            return Ok();
        }
        //
        // [HttpGet("/Search")]
        // public async Task<IActionResult> Search([FromQuery] SearchProductsFilter filter, CancellationToken cancellationToken = default)
        // {
        //     ArgumentNullException.ThrowIfNull(filter);
        //
        //     var products = await marketplaceAppService.Search(filter, cancellationToken);
        //
        //     return Ok(products);
        // }
        //
        // [HttpPut("{productId:guid}")]
        // public async Task<IActionResult> Update([FromRoute] Guid productId, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
        // {
        //     ArgumentNullException.ThrowIfNull(command);
        //
        //     await marketplaceAppService.Update(command.SetId(productId), cancellationToken);
        //
        //     return Ok();
        // }
        //
        // [HttpDelete("{productId:guid}")]
        // public async Task<IActionResult> Delete([FromRoute] Guid productId, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        // {
        //     ArgumentNullException.ThrowIfNull(filter);
        //
        //     await marketplaceAppService.Delete(filter.SetId(productId), cancellationToken);
        //
        //     return Ok();
        // }
    }
}
