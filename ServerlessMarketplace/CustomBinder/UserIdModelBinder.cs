using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerlessMarketplace.Platform.Application.BaseFilters;
using System.Security.Claims;
using System.Text.Json;

namespace ServerlessMarketplace.CustomBinder
{
    public class UserIdModelBinder : IModelBinder
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            if (!ValidateModelType(bindingContext))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            //var requestBody = await reader.ReadToEndAsync();

            //if (string.IsNullOrEmpty(requestBody))
            //{
            //    bindingContext.Result = ModelBindingResult.Failed();
            //    return;
            //}

            try
            {
                //if (JsonSerializer.Deserialize(requestBody, bindingContext.ModelType, JsonOptions) is not BaseFilter model)
                //{
                //    bindingContext.Result = ModelBindingResult.Failed();
                //    return;
                //}

                var model = (BaseFilter)Activator.CreateInstance(bindingContext.ModelType)!;

                if (Guid.TryParse(bindingContext.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var userId))
                {
                    model.UserId = userId;
                }

                bindingContext.Result = ModelBindingResult.Success(model);
            }
            catch (JsonException)
            {
                bindingContext.ModelState.AddModelError(string.Empty, "Invalid JSON format in request body.");
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }

        private static bool ValidateModelType(ModelBindingContext bindingContext)
        {
            return typeof(BaseFilter).IsAssignableFrom(bindingContext.ModelType);
        }
    }
}