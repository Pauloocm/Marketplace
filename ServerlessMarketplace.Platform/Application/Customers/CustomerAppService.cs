using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Platform.Application.Customers.Commands;

namespace ServerlessMarketplace.Platform.Application.Customers;

public class CustomerAppService(ICustomerRepository customerRepo) : ICustomerAppService
{
    private readonly ICustomerRepository customerRepository = customerRepo
                                                              ?? throw new ArgumentNullException(nameof(customerRepo));

    public async Task<Guid> Add(AddCustomerCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var customer = CustomerFactory.Create(command.Email, command.Name, command.Age);
        
        await customerRepository.Add(customer, ct);
        
        await customerRepository.Commit(ct);

        return customer.Id;
    }
}