using Microsoft.AspNetCore.Identity;

namespace Persistence.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string EmailConfirmed { get; set; }
    }
}
