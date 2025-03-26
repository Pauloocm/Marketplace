using System.Linq.Expressions;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Domain.Extensions;

public static class ExpressionTrees
{
    public static Expression<Func<Customer, bool>> ById(Guid id) => c => c.Id == id;

    public static Expression<Func<Product, bool>> ByIds(List<int> ids) => product => ids.Contains(product.Id);
}