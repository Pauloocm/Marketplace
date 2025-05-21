using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.BaseCommands;

public class CustomerBaseCommand : IValidatableObject
{
    public Guid UserId { get; set; }
    public Guid CustomerId { get; set; }

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CustomerId == Guid.Empty)
            yield return new ValidationResult("The Customer Id is required.", [nameof(CustomerId)]);

        if (UserId == Guid.Empty)
            yield return new ValidationResult("The User Id is required.", [nameof(UserId)]);
    }
}