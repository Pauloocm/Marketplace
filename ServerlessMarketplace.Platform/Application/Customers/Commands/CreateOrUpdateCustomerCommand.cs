using ServerlessMarketplace.Platform.Application.BaseCommands;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class CreateOrUpdateCustomerCommand : CustomerBaseCommand
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateTime? Birthday { get; init; }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            yield return new ValidationResult("First name is required.", [nameof(FirstName)]);

        if (string.IsNullOrWhiteSpace(LastName))
            yield return new ValidationResult("Last name is required.", [nameof(LastName)]);
    }
}