using ServerlessMarketplace.Resources.Extensions;

namespace ServerlessMarketplace.Domain.Addresses
{
    public static class AddressFactory
    {
        public static Address Create(string country, string state, string city, string zipCode, string street,
            string number, string complement)
        {
            var address = new Address()
            {
                Country = country,
                State = state,
                City = city,
                ZipCode = zipCode,
                Street = street,
                Number = number,
                Complement = complement
            };

            address.EnsureIsValid();

            return address;
        }
    }
}
