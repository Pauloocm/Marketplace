﻿using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Infrastructure.DataBase;

namespace ServerlessMarketplace.Platform.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dataContext;
        public async Task Add(Product product, CancellationToken cancellationToken = default)
        {
            if(product == null)
            {
                await Task.CompletedTask;
            }
            await dataContext.Products.AddAsync(product, cancellationToken);
            await dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetBy(Guid id, CancellationToken cancellationToken = default)
        {
            if(id == Guid.Empty)
            {
                await Task.FromResult<Product>(null);
            }
            var product = await dataContext.Products.FindAsync(id, cancellationToken);

            return product;
        }
    }
}
