namespace ServerlessMarketplace.Platform.Application.Products
{
    public class UpdateProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public UpdateProductCommand SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
