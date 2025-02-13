using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories
{
    public class ProductRepository(DataContext context) : IProductRepository
    {
        private readonly DataContext dataContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task Add(Product product, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(nameof(product));

            await dataContext.Products.AddAsync(product, cancellationToken);
        }

        public async Task<Product?> GetBy(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
            {
                await Task.FromResult<Product>(null!);
            }
            var product = await dataContext.Products.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

            return product;
        }

        public async Task<List<Product?>> Search(string? term, int page = 1, int pageSize = 1,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Product?> productsQuery = dataContext.Products;

            if (!string.IsNullOrWhiteSpace(term))
            {
                productsQuery = productsQuery.Where(p =>
                p!.Name.Contains(term) ||
                p.Description.Contains(term));
            }

            var products = await productsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return products;
        }

        public void Delete(Product product)
        {
            ArgumentNullException.ThrowIfNull(nameof(product));

            dataContext.Products.Remove(product);
        }

        public async Task Commit(CancellationToken cancellationToken = default)
        {
            await dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
