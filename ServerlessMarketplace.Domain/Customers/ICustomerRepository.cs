namespace ServerlessMarketplace.Domain.Customers;

public interface ICustomerRepository
{
    Task Add(Customer customer, CancellationToken ct = default);
    Task Commit(CancellationToken cancellationToken = default);
}