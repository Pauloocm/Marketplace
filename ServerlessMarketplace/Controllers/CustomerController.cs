﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerlessMarketplace.Platform.Application.Customers;
using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ICustomerAppService customerAppService) : ControllerBase()
    {
        private readonly ICustomerAppService customerAppService =
            customerAppService ?? throw new ArgumentNullException(nameof(customerAppService));

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CreateOrUpdateCustomerCommand command, CancellationToken ct = default)
        {
            command.EnsureIsValid();

            var customerId = await customerAppService.CreateOrUpdate(command, ct);

            return Ok(customerId);
        }

        //[HttpGet("{productId:guid}")]
        //public async Task<IActionResult> Order([FromBody] AddOrderCommand command, CancellationToken ct = default)
        //{
        //    ArgumentNullException.ThrowIfNull(command);

        //    await customerAppService.AddOrder(command, ct);

        //    return Ok();
        //}

        [HttpPut("{customerId:guid}/WishList")]
        public async Task<IActionResult> UpdateWishList([FromBody] UpdateWishListCommand command,
            CancellationToken ct = default)
        {
            command.EnsureIsValid();

            await customerAppService.UpdateWishList(command, ct);

            return Ok();
        }

        [HttpPut("{customerId:guid}/Address")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command,
            CancellationToken ct = default)
        {
            command.EnsureIsValid();

            await customerAppService.UpdateAddress(command, ct);

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