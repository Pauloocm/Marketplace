using Microsoft.Extensions.Logging;
using ServerlessMarketplace.Domain.Categorys;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.Products.Exceptions;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;
using ServerlessMarketplace.Platform.Infrastructure.Queue;
using ServerlessMarketplace.Platform.Message;

namespace ServerlessMarketplace.Platform.Application
{
    public class MarketplaceAppService(IProductRepository prodRepo, ISqsPublisher sqsPublisher) : IMarketplaceAppService
    {
        private readonly IProductRepository productRepository = prodRepo ?? throw new ArgumentNullException(nameof(prodRepo));
        private readonly ISqsPublisher publisher = sqsPublisher ?? throw new ArgumentNullException(nameof(sqsPublisher));

        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price, command.CategoryId);

            var test = Category.GetById(command.CategoryId)?.Name;

            await productRepository.Add(product, cancellationToken);

            await publisher.PublishMessage(new ProductCreated(product.Id, product.Name, product.Description,
                product.Price, Category.GetById(command.CategoryId)?.Name), cancellationToken);

            return product.Id;
        }
        public async Task<ProductRecordDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await productRepository.GetBy(filter.Id, cancellationToken) ?? throw new ProductNotFoundException();

            return product.ToRecordDto();
        }

        public async Task Update(UpdateProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = await productRepository.GetBy(command.Id, cancellationToken) ?? throw new ProductNotFoundException();

            product.Update(command.Name, command.Description, command.Price, command.CategoryId);

            await productRepository.Commit(cancellationToken);
        }

        public async Task<List<ProductDto?>?> Search(SearchProductsFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var products = await productRepository.Search(filter.Term, filter.SortColumn, filter.SortOrder, filter.Page, filter
                .PageSize, cancellationToken);

            return products.ToDto();
        }

        public async Task Delete(GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await productRepository.GetBy(filter.Id, cancellationToken) ?? throw new ProductNotFoundException();

            await productRepository.Delete(product, cancellationToken);
        }
    }
}
