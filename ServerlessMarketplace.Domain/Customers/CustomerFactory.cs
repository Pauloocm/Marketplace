using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Customers;

public static class CustomerFactory
{
    public static Customer Create(User.User owner, string firstName, string lastName, int age)
    {
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        if (age < 18) throw new ArgumentException("Age must be at least 18");

        var customer = new Customer()
        {
            Owner = owner,
            Name = $"{firstName} {lastName}",
            Age = age
        };

        customer.EnsureIsValid();

        return customer;
    }
}