namespace ServerlessMarketplace.Domain.Customers;

public interface ICustomerRepository
{
    Task Add(Customer customer, CancellationToken ct = default);
    Task<Customer?> GetBy(Guid customerId, string? includes = null!, CancellationToken ct = default);
    Task<Customer?> GetByOwnerId(Guid userId, CancellationToken ct = default);
    Task Commit(CancellationToken ct = default);
}