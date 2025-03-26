using System.ComponentModel.DataAnnotations;
using ServerlessMarketplace.Platform.Application.Extensions;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class UpdateWishListCommand : IValidatableObject
{
    public Guid CustomerId { get; init; }
    public List<int> Items { get; init; } = [];
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CustomerId.IsEmpty())
            yield return new ValidationResult("The Customer Id is required.", [nameof(CustomerId)]);

        if (!Items.Any())
            yield return new ValidationResult("No new wish item to update.", [nameof(Items)]);
    }
}