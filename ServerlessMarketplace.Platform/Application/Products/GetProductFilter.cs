
namespace ServerlessMarketplace.Platform.Application.Products
{
    public class GetProductFilter
    {
        public Guid Id { get; set; }

        public GetProductFilter SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
