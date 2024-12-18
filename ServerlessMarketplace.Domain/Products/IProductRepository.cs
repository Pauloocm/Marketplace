namespace ServerlessMarketplace.Domain.Products
{
    public interface IProductRepository
    {
        Task Add(Product product, CancellationToken cancellationToken = default);
        Task<Product?> GetBy(Guid id, CancellationToken cancellationToken = default);
        Task<List<Product?>> Search(string? term, string? sortColumn, string? sortOrder, int page = 1, int pageSize = 5, CancellationToken cancellationToken = default);
        void Delete(Product product);
        Task Commit(CancellationToken cancellationToken = default);
    }
}
