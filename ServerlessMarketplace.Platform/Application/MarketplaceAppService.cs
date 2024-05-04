using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.Products.Exceptions;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;

namespace ServerlessMarketplace.Platform.Application
{
    public class MarketplaceAppService(IProductRepository prodRepo) : IMarketplaceAppService
    {
        private readonly IProductRepository productRepository = prodRepo ?? throw new ArgumentNullException(nameof(prodRepo));
        public async Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(command);

            var product = ProductFactory.Create(command.Name, command.Description, command.Price, command.CategoryId);

            await productRepository.Add(product, cancellationToken);

            return product.Id;
        }
        public async Task<ProductDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            var product = await productRepository.GetBy(filter.Id, cancellationToken) ?? throw new ProductNotFoundException();

            return product?.ToDto();
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
