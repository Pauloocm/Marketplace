using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Domain.Orders;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    private List<Product> Products { get; set; } = null!;
    public DateTime Created { get; set; }
    public decimal Total => Products.Count == 0 ? 0 : Products.Sum(x => x.Price);

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
}