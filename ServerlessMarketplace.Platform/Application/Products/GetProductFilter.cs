namespace ServerlessMarketplace.Platform.Application.Products
{
    public class GetProductFilter
    {
        public int Id { get; set; }

        public GetProductFilter SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
