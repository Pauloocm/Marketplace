using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Domain.Orders;

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public decimal Price { get; set; }

    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}