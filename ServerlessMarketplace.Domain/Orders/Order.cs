using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Orders;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> Products { get; set; } = null!;
    public Address ShippingAddress { get; set; } = null!;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public decimal Total => Products.Sum(x => x.Price * x.Quantity);

    public void AddOrderItems(List<OrderItem> orderItems)
    {
        orderItems.EnsureIsValid();

        foreach (var item in orderItems)
            AddOrderItem(item);
    }

    public void AddOrderItem(OrderItem item)
    {
        item.EnsureIsValid();

        Products ??= [];

        if (Products.Any(p => p.ProductId == item.ProductId))
            throw new InvalidOperationException($"Product {item.ProductId} already exists");

        Products.Add(item);
    }

    public void UpdateAddress(Address address)
    {
        address.EnsureIsValid();

        if (address.CustomerId != CustomerId)
            throw new InvalidOperationException($"Customer {address.CustomerId} does not match");

        ShippingAddress = address;
    }
}