using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;
using System.Linq.Expressions;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    private readonly DataContext dataContext = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Customer customer, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(customer);

        await dataContext.Customers.AddAsync(customer, ct);
    }

    public async Task Commit(CancellationToken ct = default)
    {
        await dataContext.SaveChangesAsync(ct);
    }

    public async Task<Customer?> GetBy(Expression<Func<Customer, bool>> byId, string include = null!, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(byId);

        return await dataContext.Customers.Include(include).SingleOrDefaultAsync(byId, ct);
    }
}