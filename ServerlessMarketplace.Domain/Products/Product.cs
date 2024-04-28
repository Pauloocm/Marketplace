using ServerlessMarketplace.Domain.Categorys;

namespace ServerlessMarketplace.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategorytId { get; private set; }
        private Category category;
        public Category Category
        {
            get => category;
            set
            {
                if(value != null)
                    CategorytId = value.Id;
            }
        }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
