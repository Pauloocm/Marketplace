using System.Linq.Expressions;

namespace ServerlessMarketplace.Domain.Products
{
    public interface IProductRepository
    {
        Task Add(Product product, CancellationToken cancellationToken = default);
        Task<Product?> GetBy(int id, CancellationToken cancellationToken = default);
        Task<List<Product>?> GetBy(Expression<Func<Product, bool>> byIds, CancellationToken ct = default);

        Task<List<Product?>> Search(string? term, int page = 1, int pageSize = 5,
            CancellationToken cancellationToken = default);

        void Delete(Product product);
        Task Commit(CancellationToken cancellationToken = default);
    }
}