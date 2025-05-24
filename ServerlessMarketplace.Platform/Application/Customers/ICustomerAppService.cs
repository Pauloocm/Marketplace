using ServerlessMarketplace.Platform.Application.Customers.Commands;

namespace ServerlessMarketplace.Platform.Application.Customers;

public interface ICustomerAppService
{
    Task<Guid> CreateOrUpdate(CreateOrUpdateCustomerCommand command, CancellationToken ct = default);
    //Task AddOrder(AddOrderCommand command, CancellationToken ct = default);
    Task UpdateWishList(UpdateWishListCommand command, CancellationToken ct = default);
    Task UpdateAddress(UpdateAddressCommand command, CancellationToken ct = default);
}