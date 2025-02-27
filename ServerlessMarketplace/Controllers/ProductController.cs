using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Products;

namespace ServerlessMarketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductAppService appService) : ControllerBase()
    {
        private readonly IProductAppService _productAppService = appService ?? throw new ArgumentNullException(nameof(appService));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var productId = await _productAppService.Add(command, cancellationToken);

            return Ok(productId);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid productId, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await _productAppService.Get(filter.SetId(productId), cancellationToken);

            return Ok(product);
        }

        [HttpGet("/Search")]
        public async Task<IActionResult> Search([FromQuery] SearchProductsFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var products = await _productAppService.Search(filter, cancellationToken);

            return Ok(products);
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid productId, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            await _productAppService.Update(command.SetId(productId), cancellationToken);

            return Ok();
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid productId, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            await _productAppService.Delete(filter.SetId(productId), cancellationToken);

            return Ok();
        }
    }
}
