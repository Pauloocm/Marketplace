using ServerlessMarketplace.Platform.Application.BaseCommands;

namespace ServerlessMarketplace.Platform.Application.Orders;

public class AddOrderCommand : CustomerBaseCommand
{
    public List<int> ProductIds { get; set; } = null!;
}