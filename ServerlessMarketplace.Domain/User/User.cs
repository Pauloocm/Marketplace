using Microsoft.AspNetCore.Identity;

namespace ServerlessMarketplace.Domain.User
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Name => $"{FirstName} {LastName}";
    }
}
