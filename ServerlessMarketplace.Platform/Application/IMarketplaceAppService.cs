using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Dtos;

namespace ServerlessMarketplace.Platform.Application
{
    public interface IMarketplaceAppService
    {
        Task<ProductDto?> Get(GetProductFilter filter, CancellationToken cancellationToken = default);
        Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default);
        Task Update(UpdateProductCommand command, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);

        
    }
}
