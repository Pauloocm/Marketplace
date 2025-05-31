using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.BaseFilters
{
    public class BaseFilter : IValidatableObject
    {
        public Guid UserId { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserId == Guid.Empty)
                yield return new ValidationResult("The User Id is required.", [nameof(UserId)]);
        }
    }
}
