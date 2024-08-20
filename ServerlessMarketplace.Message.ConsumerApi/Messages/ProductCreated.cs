namespace ServerlessMarketplace.Message.ConsumerApi.Messages
{
    public record ProductCreated(Guid Id, string Name, string Description, decimal Price, string? Category)
    {
    }
}
