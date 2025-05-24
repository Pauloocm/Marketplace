using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Products;
using System.Security.Claims;

namespace ServerlessMarketplace.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductController(IProductAppService appService) : ControllerBase()
    {
        private readonly IProductAppService productAppService = appService ?? throw new ArgumentNullException(nameof(appService));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var productId = await productAppService.Add(command, cancellationToken);

            return Ok(productId);
        }

        [HttpGet("{productId:int}/Detail")]
        public async Task<IActionResult> Detail([FromRoute] int productId, CancellationToken cancellationToken = default)
        {
            //ArgumentNullException.ThrowIfNull(filter);

            var filter = new GetProductFilter() { Id = productId };

            ClaimsPrincipal current = this.User;

            var product = await productAppService.Get(filter.SetId(productId), cancellationToken);

            return Ok(product);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] SearchProductsFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var user = this.User;

            var products = await productAppService.Search(filter, cancellationToken);

            return Ok(products);
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            await productAppService.Update(command.SetId(productId), cancellationToken);

            return Ok();
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] int productId, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            await productAppService.Delete(filter.SetId(productId), cancellationToken);

            return Ok();
        }
    }
}
