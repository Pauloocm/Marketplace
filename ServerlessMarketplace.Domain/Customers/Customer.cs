using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Orders;

namespace ServerlessMarketplace.Domain.Customers;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public List<Order>? OrdersHistory { get; private set; }

    public void UpdateOrderHistory(Order order)
    {
        //TODO create order.IsValid() method
        ArgumentNullException.ThrowIfNull(order);

        OrdersHistory ??= [];

        //TODO create customException for this case
        if (OrdersHistory.Exists(o => o.Id == order.Id))
            throw new InvalidOperationException($"Order with id {order.Id} already exists.");

        OrdersHistory.Add(order);
    }
}