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
    public async Task Commit(CancellationToken ct = default)
    {
        await dataContext.SaveChangesAsync(ct);
    }


    public async Task<Customer?> GetBy(Guid costumerId, string? includes = null!, CancellationToken ct = default)
    {
        if (costumerId == Guid.Empty) throw new ArgumentNullException(nameof(costumerId));

        if (includes is not null)
        {
            return await dataContext.Customers
            .AsSplitQuery()
            .Include(includes)
            .SingleOrDefaultAsync(c => c.Id == costumerId, cancellationToken: ct);
        }
        else
        {
            return await dataContext.Customers
                .AsSplitQuery()
                .SingleOrDefaultAsync(c => c.Id == costumerId, cancellationToken: ct);
        }
    }
}