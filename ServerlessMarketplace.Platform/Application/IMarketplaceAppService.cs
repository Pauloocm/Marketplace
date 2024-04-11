using ServerlessMarketplace.Platform.Application.Products;

namespace ServerlessMarketplace.Platform.Application
{
    public interface IMarketplaceAppService
    {
        Task<Guid> Add(AddProductCommand command, CancellationToken cancellationToken = default);
    }
}
