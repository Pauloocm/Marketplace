using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Platform.Application.Orders;

namespace ServerlessMarketplace.Platform.Application.Customers;

public interface ICustomerAppService
{
    Task<Guid> Add(AddCustomerCommand command, CancellationToken ct = default);
    Task<Guid> AddOrder(AddOrderCommand command, CancellationToken ct = default);
}