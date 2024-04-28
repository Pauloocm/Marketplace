using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Dtos
{
    public static class DtoExtensions
    {
        public static ProductDto? ToDto(this Product? product)
        {
            if (product is null) return null;

            var dto = new ProductDto()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                //CategoryId = product.Category.Id
            };

            return dto;            
        }

        public static List<ProductDto?>? ToDto(this List<Product?>? productS)
        {
            return productS?.Select(ToDto).ToList();
        }
    }
}
