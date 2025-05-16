using ServerlessMarketplace.Platform.Application.BaseCommands;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Platform.Application.Customers.Commands;

public class UpdateAddressCommand : CustomerBaseCommand
{
    public string Country { get; set; } = null!;
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Complement { get; set; } = null!;

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Country))
            yield return new ValidationResult("Country field is required.", [nameof(Country)]);

        if (string.IsNullOrWhiteSpace(State))
            yield return new ValidationResult("State field is required.", [nameof(State)]);

        if (string.IsNullOrWhiteSpace(City))
            yield return new ValidationResult("City field is required.", [nameof(City)]);
    }
}