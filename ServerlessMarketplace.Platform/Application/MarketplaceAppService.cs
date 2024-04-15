using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Platform.Application
{
    public class MarketplaceAppService(ISqsService sqs, IProductRepository prodRepo) : IMarketplaceAppService
    {
        private readonly ISqsService sQSService = sqs ?? throw new ArgumentNullException(nameof(sqs));
        private readonly IProductRepository productRepository = prodRepo ?? throw new ArgumentNullException(nameof(prodRepo));
        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price, command.CategoryId);

            await productRepository.Add(product, cancellationToken);

            await sQSService.SendProductCreatedMessage(product.ToJson(), cancellationToken);

            return product.Id;
        }
        public async Task<ProductDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await productRepository.GetBy(filter.Id, cancellationToken);

            if(product is null) new ArgumentNullException(nameof(product));

            return product?.ToDto();
        }

        public Task Update(UpdateProductCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
