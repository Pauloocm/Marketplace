using Marketplace.Domain.Events;
using Marketplace.Domain.Events.Events;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.Products.Exceptions;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;

namespace ServerlessMarketplace.Platform.Application
{
    public class MarketplaceAppService(IProductRepository prodRepo, IEventPublisher eventPublisher) : IMarketplaceAppService
    {
        private readonly IProductRepository productRepository = prodRepo ?? throw new ArgumentNullException(nameof(prodRepo));
        private readonly IEventPublisher eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));

        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price, command.CategoryId);


            await productRepository.Add(product, cancellationToken);

            await productRepository.Commit(cancellationToken);

            await eventPublisher.Publish(new ProductCreated()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            }, cancellationToken);

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

            await eventPublisher.Publish(new ProductUpdated() { Id = product.Id, }, cancellationToken);
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

            productRepository.Delete(product);

            await productRepository.Commit(cancellationToken);

            await eventPublisher.Publish(new ProductDeleted() { Id = product.Id, }, cancellationToken);
        }
    }
}
