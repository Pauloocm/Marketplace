using ServerlessMarketplace.Domain.Categorys;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Platform.Dtos
{
    public static class DtoExtensions
    {
        public static ProductCardDto? ToDto(this Product? product)
        {
            if (product is null) return null;

            var dto = new ProductCardDto()
            {

                Id = product.Id,
                Title = product.Name,
                Price = product.Price,
            };

            return dto;
        }

        public static ProductDetailDto? ToRecordDto(this Product? product)
        {
            if (product is null) return null;

            return new ProductDetailDto(product.Id, product.Name, product.Description, product.Price, "", Category.GetById(product.CategoryId).ToDto());
        }

        public static CategoryDto ToDto(this Category? category)
        {
            if (category is null) return new CategoryDto();

            var dto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return dto;
        }

        public static List<ProductCardDto?>? ToDto(this List<Product?>? productS)
        {
            return productS?.Select(ToDto).ToList();
        }
    }
}
