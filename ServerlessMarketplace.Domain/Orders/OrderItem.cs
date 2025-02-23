using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Domain.Orders;

public class OrderItem
{

    public OrderItem()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
    
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; set; }
    
    public DateTime CreatedAt { get; private set; }

    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}