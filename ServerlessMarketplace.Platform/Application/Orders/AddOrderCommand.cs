namespace ServerlessMarketplace.Platform.Application.Orders;

public class AddOrderCommand
{
    public Guid CustomerId { get; set; }
    public List<int> ProductIds { get; set; } = null!;
}