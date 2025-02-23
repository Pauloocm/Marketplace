using ServerlessMarketplace.Domain.Categorys;

namespace ServerlessMarketplace.Domain.Products
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; private set; }
        
        private readonly Category category = null!;
        public Category Category 
        {
            get => category;
            set
            {
                if (value != null)
                    CategoryId = value.Id;
            }
        }

        public void Update(string name, string description, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
