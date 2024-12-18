using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Products
{
    public class AddProductCommand
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
