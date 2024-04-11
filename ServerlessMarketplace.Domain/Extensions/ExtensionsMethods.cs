using ServerlessMarketplace.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerlessMarketplace.Domain.Extensions
{
    public static class ExtensionsMethods
    {
        public static string ToJson(this Product product)
        {
            if (product is null) return "";

            return JsonSerializer.Serialize(product);
        }
    }
}
