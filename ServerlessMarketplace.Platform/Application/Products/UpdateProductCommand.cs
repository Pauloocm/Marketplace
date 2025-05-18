namespace ServerlessMarketplace.Platform.Application.Products
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public UpdateProductCommand SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
