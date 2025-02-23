using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.Products;

namespace ServerlessMarketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(IMarketplaceAppService appService) : ControllerBase()
    {
        // private readonly IMarketplaceAppService marketplaceAppService = appService ?? throw new ArgumentNullException(nameof(appService));

        // [HttpPost]
        // public Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
        // {
        //     ArgumentNullException.ThrowIfNull(command);
        //     
        //     
        //
        //     return Ok();
        // }

        // [HttpGet("{productId:guid}")]
        // public async Task<IActionResult> Get([FromRoute] Guid productId, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        // {
        //     ArgumentNullException.ThrowIfNull(filter);
        //
        //     var product = await marketplaceAppService.Get(filter.SetId(productId), cancellationToken);
        //
        //     return Ok(product);
        // }
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
