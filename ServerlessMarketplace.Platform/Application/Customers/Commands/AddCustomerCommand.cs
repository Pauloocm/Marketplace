using System.ComponentModel.DataAnnotations;
using ServerlessMarketplace.Platform.Application.Extensions;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class AddCustomerCommand : IValidatableObject
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;
    public int Age { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new ValidationResult("Name is required.", [nameof(Name)]);
        
        if (!Email.IsValidEmail())
            yield return new ValidationResult("Email is invalid.", [nameof(Email)]);

        if (Age < 18)
            yield return new ValidationResult("Age must be at least 18.", [nameof(Age)]);
    }
}