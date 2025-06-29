using ServerlessMarketplace.Domain.Addresses;
using ServerlessMarketplace.Domain.Orders;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Customers;

public class Customer : BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public User.User Owner { get; set; } = null!;
    public Guid OwnerId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? Birthday { get; set; }
    public Address? Address { get; set; }
    public List<Order>? OrdersHistory { get; private set; }
    public List<Product>? WishList { get; private set; }

    public void UpdateAddress(Address address)
    {
        address.EnsureIsValid();

        Address = address;
    }

    public void UpdateBasicInformations(string firstName, string lastName, DateTime? birthDay)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);

        Name = $"{firstName} {lastName}";
        Birthday = birthDay;
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