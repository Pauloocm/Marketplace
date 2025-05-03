using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Customers.Exceptions;
using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Domain.Products.Exceptions;
using ServerlessMarketplace.Platform.Application.Customers.Commands;
using ServerlessMarketplace.Platform.Application.Orders;

namespace ServerlessMarketplace.Platform.Application.Customers;

public class CustomerAppService(ICustomerRepository customerRepo, IProductRepository productRepo) : ICustomerAppService
{
    private readonly ICustomerRepository customerRepository = customerRepo
                                                              ?? throw new ArgumentNullException(nameof(customerRepo));

    private readonly IProductRepository productRepository = productRepo
                                                            ?? throw new ArgumentNullException(nameof(productRepo));

    public async Task<Guid> Add(AddCustomerCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var customer = CustomerFactory.Create(command.Email, command.Name, command.Age);

        await customerRepository.Add(customer, ct);

        await customerRepository.Commit(ct);

        return customer.Id;
    }

    public async Task AddOrder(AddOrderCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        IsCustomerValid(command.CustomerId);

        //var items = await productRepository.

        //var order = OrderFactory.Create(command.CustomerId, command.ProductIds);
    }

    public async Task UpdateWishList(UpdateWishListCommand command, CancellationToken ct = default)
    {
        command.EnsureIsValid();

        var customer = await customerRepository.GetBy(ExpressionTrees.ById(command.CustomerId), ct: ct)
                       ?? throw new CustomerNotFoundException();

        var wishedProducts = await productRepository.GetBy(ExpressionTrees.ByIds(command.Items), ct: ct)
                             ?? throw new ProductNotFoundException();

        customer.UpdateWishList(wishedProducts);

        await customerRepository.Commit(ct);
    }

    private bool IsCustomerValid(Guid customerId)
    {
        _ = customerRepository.GetBy(ExpressionTrees.ById(customerId), ct: CancellationToken.None)
            ?? throw new CustomerNotFoundException();

        return true;
    }
}