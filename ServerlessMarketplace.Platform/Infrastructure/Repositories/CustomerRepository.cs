using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext dataContext = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Customer customer, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(customer);

        await dataContext.Customers.AddAsync(customer, ct);
    }

    public async Task Commit(CancellationToken cancellationToken = default)
    {
        await dataContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Customer?> GetBy(Expression<Func<Customer, bool>> byId, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(byId);

        return await dataContext.Customers.SingleOrDefaultAsync(byId, ct);
    }
}