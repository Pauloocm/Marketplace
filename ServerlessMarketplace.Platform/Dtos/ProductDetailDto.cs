namespace ServerlessMarketplace.Platform.Dtos
{
    public record ProductDetailDto(int Id, string Title, string Description, decimal Price, string Image, CategoryDto Category);
}
