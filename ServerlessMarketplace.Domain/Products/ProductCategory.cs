using ServerlessMarketplace.Domain.Categorys;

namespace ServerlessMarketplace.Domain.Products
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

    }
}
