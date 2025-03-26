using System.Linq.Expressions;

namespace ServerlessMarketplace.Domain.Customers;

public interface ICustomerRepository
{
    Task Add(Customer customer, CancellationToken ct = default);
    Task Commit(CancellationToken ct = default);
    Task<Customer?> GetBy(Expression<Func<Customer, bool>> byId, CancellationToken ct = default);
}