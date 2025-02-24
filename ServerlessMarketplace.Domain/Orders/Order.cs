using ServerlessMarketplace.Domain.Customers;

namespace ServerlessMarketplace.Domain.Orders;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<OrderItem> Products { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public decimal Total => Products.Sum(x => x.Price * x.Quantity);
}


// public AddProduct(Product product)
// {
//     ArgumentNullException.ThrowIfNull(product);
//
//     product.EnsureIsValid();
//
//     Products ??= [];
//
//     Products.Add(product);
// }
