namespace ServerlessMarketplace.Message.ConsumerApi.Messages
{
    public record ProductUpdated(Guid Id, string Name, string Description, decimal Price, string? Category)
    {
    }
}
