using ServerlessMarketplace.Platform.Application.BaseCommands;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class CreateOrUpdateCustomerCommand : CustomerBaseCommand
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateTime? BirthDay { get; init; }
    public int Age { get; set; }


    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            yield return new ValidationResult("First name is required.", [nameof(FirstName)]);

        if (string.IsNullOrWhiteSpace(LastName))
            yield return new ValidationResult("Last name is required.", [nameof(LastName)]);

        if (Age < 18)
            yield return new ValidationResult("Age must be at least 18.", [nameof(Age)]);
    }
}