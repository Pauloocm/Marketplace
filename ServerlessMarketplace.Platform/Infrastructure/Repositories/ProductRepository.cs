using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.DataBase;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories
{
    public class ProductRepository(DataContext context) : IProductRepository
    {
        private readonly DataContext dataContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task Add(Product product, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(product));

            await dataContext.Products.AddAsync(product, cancellationToken);
            await dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetBy(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                await Task.FromResult<Product>(null);
            }
            var product = await dataContext.Products.FindAsync(id, cancellationToken);

            return product;
        }

        public async Task<List<Product?>> Search(string? term, string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            IQueryable<Product?> productsQuery = dataContext.Products;

            if (!string.IsNullOrWhiteSpace(term))
            {
                productsQuery = productsQuery.Where(p =>
                p.Name.Contains(term) ||
                p.Description.Contains(term));
            }

            var products = await productsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return products;
        }
    }
}
