using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerlessMarketplace.Platform.Application.BaseCommands;

namespace ServerlessMarketplace.CustomBinder
{
    public class CustomerIdRouteModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (typeof(CustomerBaseCommand).IsAssignableFrom(context.Metadata.ModelType))
                return new CustomerIdRouteModelBinder();

            return null!;
        }
    }
}
