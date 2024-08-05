namespace ServerlessMarketplace.Platform.Message
{
    public record ProductCreated(Guid Id, string Name, string Description, decimal Price, string? Category)
    {
    }
}
