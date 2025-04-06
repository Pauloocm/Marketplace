using ServerlessMarketplace.Platform.Application.BaseCommands;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class UpdateWishListCommand : CustomerBaseCommand
{
    public List<int> Items { get; init; } = null!;

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CustomerId == Guid.Empty)
            yield return new ValidationResult("The Customer Id is required.", [nameof(CustomerId)]);

        if (!Items.Any())
            yield return new ValidationResult("No new wish item to update.", [nameof(Items)]);
    }
}