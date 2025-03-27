using ServerlessMarketplace.Platform.Application.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class UpdateWishListCommand
{
    public Guid CustomerId { get; set; }
    public List<int> Items { get; init; } = [];

    public UpdateWishListCommand SetCustomerId(Guid customerId)
    {
        CustomerId = customerId;

        return this;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CustomerId.IsEmpty())
            yield return new ValidationResult("The Customer Id is required.", [nameof(CustomerId)]);

        if (!Items.Any())
            yield return new ValidationResult("No new wish item to update.", [nameof(Items)]);
    }
}