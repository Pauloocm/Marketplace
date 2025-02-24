using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Domain.Extensions;

public static class DomainExtensions
{
    public static void EnsureIsValid<T>(this T obj) where T : class
    {
        ArgumentNullException.ThrowIfNull(obj);

        var results = new List<ValidationResult>();
        var context = new ValidationContext(obj);

        if (Validator.TryValidateObject(obj, context, results, true)) return;

        var errorMessage = "Object is invalid:\n";
        foreach (var result in results)
        {
            errorMessage += $"{result.ErrorMessage}\n";

            errorMessage = result.MemberNames.Aggregate(errorMessage,
                (current, memberName) => current + $"  Property: {memberName}\n");
        }

        throw new ValidationException(errorMessage);
    }
}