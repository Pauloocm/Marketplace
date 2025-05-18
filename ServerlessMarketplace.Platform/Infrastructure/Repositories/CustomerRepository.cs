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

        var query = await dataContext.Customers.AsSplitQuery()
            .Include(includes)
            .FirstOrDefaultAsync(customer => customer.Id == costumerId, ct);

        //if (!string.IsNullOrWhiteSpace(includes))
        //    query.Include(includes);

        return query;
    }
}