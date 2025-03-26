using ServerlessMarketplace.Platform.Application.Customers.Commands;

namespace ServerlessMarketplace.Platform.Application.Customers;

public interface ICustomerAppService
{
    Task<Guid> Add(AddCustomerCommand command, CancellationToken ct = default);
    Task UpdateWishList(UpdateWishListCommand command, CancellationToken ct = default);
}