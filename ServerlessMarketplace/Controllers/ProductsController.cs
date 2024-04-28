﻿using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.Products;

namespace ServerlessMarketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IMarketplaceAppService appService) : ControllerBase()
    {
        private readonly IMarketplaceAppService marketplaceAppService = appService ?? throw new ArgumentNullException(nameof(appService));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var productId = await marketplaceAppService.Add(command, cancellationToken);

            return Ok(productId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromRoute] GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await marketplaceAppService.Get(filter.SetId(id), cancellationToken);

            return Ok(product);
        }
    }
}
