using ServerlessMarketplace.Domain.Products;
using System.Text.Json;

namespace ServerlessMarketplace.Domain.Extensions
{
    public static class ExtensionsMethods
    {
        public static string ToJson(this Product product)
        {
            if (product is null) return string.Empty;

            return JsonSerializer.Serialize(product);
        }
    }
}
