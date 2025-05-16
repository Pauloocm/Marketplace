using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Orders;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Customers;

public class Customer : BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public Address? Address { get; set; }
    public List<Order>? OrdersHistory { get; private set; }
    public List<Product>? WishList { get; private set; }

    public void UpdateAddress(Address address)
    {
        address.EnsureIsValid();

        Address = address;
    }

    public void UpdateOrderHistory(Order order)
    {
        order.EnsureIsValid();

        OrdersHistory ??= [];

        //TODO create customException for this case
        if (OrdersHistory.Exists(o => o.Id == order.Id))
            throw new InvalidOperationException($"Order with id {order.Id} already exists.");

        OrdersHistory.Add(order);
    }

    public void UpdateWishList(List<Product> products)
    {
        products.EnsureIsValid();

        foreach (var product in products)
            UpdateWishList(product);
    }

    private void UpdateWishList(Product product)
    {
        product.EnsureIsValid();

        WishList ??= [];

        //TODO Is really necessary to throw a exception for this case? 
        if (WishList.Exists(p => p.Id == product.Id)) return;

        WishList.Add(product);
    }
}