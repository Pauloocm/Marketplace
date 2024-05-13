using ServerlessMarketplace.Domain.Categorys;
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
                Category = Category.GetById(product.CategorytId).ToDto(),
            };

            return dto;
        }

        public static ProductRecordDto? ToRecordDto(this Product? product)
        {
            if (product is null) return null;

            return new ProductRecordDto(product.Name, product.Description, product.Price, Category.GetById(product.CategorytId).ToDto());
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

        public static List<ProductDto?>? ToDto(this List<Product?>? productS)
        {
            return productS?.Select(ToDto).ToList();
        }
    }
}
