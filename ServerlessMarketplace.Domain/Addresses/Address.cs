namespace ServerlessMarketplace.Domain.Addresses;

public class Address
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Complement { get; set; } = null!;
}