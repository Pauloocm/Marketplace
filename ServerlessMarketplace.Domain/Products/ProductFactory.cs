using ServerlessMarketplace.Domain.Categorys;

namespace ServerlessMarketplace.Domain.Products
{
    public static class ProductFactory
    {
        public static Product Create(string name, string description, decimal price, int categoryId)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Category = Category.GetById(categoryId)!
            };

            return product;
        }
    }
}
