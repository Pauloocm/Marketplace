using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Orders;

public static class OrderFactory
{
    public static Order Create(Guid customerId, List<OrderItem> itens)
    {
        ArgumentNullException.ThrowIfNull(itens);

        var order = new Order() { CustomerId = customerId };

        order.AddOrderItems(itens);

        order.EnsureIsValid();

        return order;
    }
}