using ServerlessMarketplace.Domain.Extensions;
using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Customers;

public static class CustomerFactory
{
    public static Customer Create(string email, string name, int age)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (age < 18) throw new ArgumentException("Age must be at least 18");

        var customer = new Customer()
        {
            Email = email,
            Name = name,
            Age = age
        };

        customer.EnsureIsValid();

        return customer;
    }
}