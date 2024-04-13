using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMarketplace.Domain.Products
{
    public interface IProductRepository
    {
        Task Add(Product product, CancellationToken cancellationToken = default);
        Task<Product?> GetBy(Guid id, CancellationToken cancellationToken = default);
    }
}
