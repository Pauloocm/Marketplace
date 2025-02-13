
namespace ServerlessMarketplace.Platform.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; } = null!;
    }
}
