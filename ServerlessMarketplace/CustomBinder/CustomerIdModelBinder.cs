using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerlessMarketplace.Platform.Application.BaseCommands;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ServerlessMarketplace.CustomBinder
{
    public class CustomerIdRouteModelBinder : IModelBinder
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

            using var reader = new StreamReader(bindingContext.HttpContext.Request.Body, Encoding.UTF8);

            var requestBody = await reader.ReadToEndAsync();

            if (string.IsNullOrEmpty(requestBody))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            try
            {
                if (JsonSerializer.Deserialize(requestBody, bindingContext.ModelType, JsonOptions) is not CustomerBaseCommand model)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }

                if (bindingContext.ActionContext.RouteData.Values.TryGetValue("customerId", out var customerIdValue) &&
                    Guid.TryParse(customerIdValue?.ToString(), out var customerId))
                {
                    model.CustomerId = customerId;
                }

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
            return typeof(CustomerBaseCommand).IsAssignableFrom(bindingContext.ModelType);
        }
    }
}