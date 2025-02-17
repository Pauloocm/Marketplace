using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Orders;

namespace ServerlessMarketplace.Domain.Customer;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public List<Order>? OrdersHistory { get; set; }
}