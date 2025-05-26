using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerlessMarketplace.Platform.Application.BaseFilters;
using System.Security.Claims;
using System.Text.Json;

namespace ServerlessMarketplace.CustomBinder
{
    public class UserIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            if (!ValidateModelType(bindingContext))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.FromResult(bindingContext.Result);
            }

            try
            {
                var model = (BaseFilter)Activator.CreateInstance(bindingContext.ModelType)!;

                if (Guid.TryParse(bindingContext.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var userId))
                {
                    model.UserId = userId;
                }

                bindingContext.Result = ModelBindingResult.Success(model);
                return Task.FromResult(bindingContext.Result);
            }
            catch (JsonException)
            {
                bindingContext.ModelState.AddModelError(string.Empty, "Invalid JSON format in request body.");
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.FromResult(bindingContext.Result);
            }
        }

        private static bool ValidateModelType(ModelBindingContext bindingContext)
        {
            return typeof(BaseFilter).IsAssignableFrom(bindingContext.ModelType);
        }
    }
}