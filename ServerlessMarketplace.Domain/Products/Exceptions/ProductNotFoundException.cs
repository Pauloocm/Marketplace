using ServerlessMarketplace.Resources;

namespace ServerlessMarketplace.Domain.Products.Exceptions
{
    public class ProductNotFoundException() : Exception(Messages.ProductNotFoundException)
    {
    }
}