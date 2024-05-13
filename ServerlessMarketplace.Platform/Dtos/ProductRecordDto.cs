namespace ServerlessMarketplace.Platform.Dtos
{
    public record ProductRecordDto( string Name, string Description, decimal Price, CategoryDto Category);
}
