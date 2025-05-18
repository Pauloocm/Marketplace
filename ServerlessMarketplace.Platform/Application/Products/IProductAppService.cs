using ServerlessMarketplace.Platform.Dtos;

namespace ServerlessMarketplace.Platform.Application.Products
{
    public interface IProductAppService
    {
        Task<ProductDetailDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default);
        Task<List<ProductCardDto?>?> Search(SearchProductsFilter filter, CancellationToken cancellationToken = default);
        Task<int> Add(AddProductCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateProductCommand command, CancellationToken cancellationToken = default);
        Task Delete(GetProductFilter filter, CancellationToken cancellationToken = default);
    }
}
