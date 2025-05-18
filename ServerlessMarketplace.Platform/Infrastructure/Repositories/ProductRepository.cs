using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;
using System.Linq.Expressions;

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

        public async Task<Product?> GetBy(int id, CancellationToken cancellationToken = default)
        {
            var product = await dataContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return product;
        }

        public async Task<List<Product>?> GetBy(Expression<Func<Product, bool>> byIds,
            CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(byIds);

            return await dataContext.Products.Where(byIds).ToListAsync(ct);
        }

        public async Task<List<Product?>> Search(string? term, int page = 1, int pageSize = 1,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Product?> productsQuery = dataContext.Products;

            if (!string.IsNullOrWhiteSpace(term))
            {
                productsQuery = productsQuery.Where(p =>
                    p!.Name.ToLower().Contains(term.ToLower()) ||
                    p.Description.ToLower().Contains(term.ToLower()));
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