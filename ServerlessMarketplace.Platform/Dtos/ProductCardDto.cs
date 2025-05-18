
namespace ServerlessMarketplace.Platform.Dtos
{
    public class ProductCardDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Image { get; set; } = "";
        public decimal Price { get; set; }
    }
}
