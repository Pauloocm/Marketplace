
using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Customers.Exceptions;
using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.Products.Exceptions;
using ServerlessMarketplace.Domain.User;
using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Platform.Application.Customers;

public class CustomerAppService(ICustomerRepository customerRepo, IUserRepository userRepository, IProductRepository productRepo) : ICustomerAppService
{
    private readonly ICustomerRepository customerRepository = customerRepo
        ?? throw new ArgumentNullException(nameof(customerRepo));

    private readonly IProductRepository productRepository = productRepo
        ?? throw new ArgumentNullException(nameof(productRepo));

    public async Task<Guid> CreateOrUpdate(CreateOrUpdateCustomerCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var owner = await userRepository.GetBy(command.UserId, ct: ct)
                ?? throw new UserNotFoundException();

        var customer = await GetCustomerByOwnerId(owner.Id, ct);

        if (customer is null)
        {
            customer = CustomerFactory.Create(owner, command.FirstName, command.LastName, command.Age);

            await customerRepository.Add(customer, ct);
        }
        else
        {
            customer.UpdateBasicInformations(command.FirstName, command.LastName, command.Age);
        }

        await customerRepository.Commit(ct);

        return customer.Id;
    }

    public async Task UpdateAddress(UpdateAddressCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var customer = await GetCustomerByOwnerId(command.UserId);

        var address = AddressFactory.Create(command.Country, command.State, command.City,
            command.ZipCode, command.Street, command.Number, command.Complement);

        customer.UpdateAddress(address);

        await customerRepository.Commit(ct);
    }

    public async Task UpdateWishList(UpdateWishListCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var customer = await customerRepository.GetBy(command.CustomerId, "WishList", ct)
                       ?? throw new CustomerNotFoundException();

        var wishedProducts = await productRepository.GetBy(ExpressionTrees.ByIds(command.Items), ct: ct)
                             ?? throw new ProductNotFoundException();

        customer.UpdateWishList(wishedProducts);

        await customerRepository.Commit(ct);
    }

    private async Task<Customer?> GetCustomerByOwnerId(Guid userId, CancellationToken ct = default)
    {
        return await customerRepository.GetByOwnerId(userId, ct);
    }
}