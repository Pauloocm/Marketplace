using ServerlessMarketplace.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMarketplace.Platform.Dtos
{
    public static class DtoExtensions
    {
        public static ProductDto? ToDto(this Product product)
        {
            if (product is null) return null;

            var dto = new ProductDto()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.Category.Id
            };

            return dto;            
        }
    }
}
