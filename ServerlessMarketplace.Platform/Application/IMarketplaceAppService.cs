using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;

namespace ServerlessMarketplace.Platform.Application
{
    public interface IMarketplaceAppService
    {
        Task<ProductRecordDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default);
        Task<List<ProductDto?>?> Search(SearchProductsFilter filter, CancellationToken cancellationToken = default);
        Task<int> Add(AddProductCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateProductCommand command, CancellationToken cancellationToken = default);
        Task Delete(GetProductFilter filter, CancellationToken cancellationToken = default);

        
    }
}
