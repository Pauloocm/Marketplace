using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerlessMarketplace.Platform.Application.BaseFilters;

namespace ServerlessMarketplace.CustomBinder
{
    public class UserIdRouteModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (typeof(BaseFilter).IsAssignableFrom(context.Metadata.ModelType))
                return new UserIdModelBinder();

            return null!;
        }
    }
}
