﻿using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Platform.Application
{
    public class MarketplaceAppService(ISqsService sqs) : IMarketplaceAppService
    {
        private readonly ISqsService sQSService = sqs ?? throw new ArgumentNullException(nameof(sqs));
        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price, command.CategoryId);

            await sQSService.SendProductCreatedMessage(product.ToJson(), cancellationToken);

            return product.Id;
        }
    }
}