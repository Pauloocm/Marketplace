namespace ServerlessMarketplace.Domain.Products
{
    public static class ProductFactory
    {
        public static Product Create(string name, string description, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                Price = price
            };

            return product;
        }
    }
}
