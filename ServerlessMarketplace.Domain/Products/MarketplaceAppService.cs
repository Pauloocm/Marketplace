using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Domain.Products
{
    public class MarketplaceAppService(ISQSService sqs) : IMarketplaceAppService
    {
        private readonly ISQSService sQSService = sqs ?? throw new ArgumentNullException(nameof(sqs));
        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price);

            await sQSService.SendProductCreatedMessage(product.ToJson(), cancellationToken);

            return product.Id;
        }
    }
}
