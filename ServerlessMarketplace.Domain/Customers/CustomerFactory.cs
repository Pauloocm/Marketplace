using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Customers;

public static class CustomerFactory
{
    public static Customer Create(User.User owner, string firstName, string lastName, DateTime? birthday)
    {
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);


        var customer = new Customer()
        {
            Owner = owner,
            Name = $"{firstName} {lastName}",
            Birthday = birthday
        };

        customer.EnsureIsValid();

        return customer;
    }
}