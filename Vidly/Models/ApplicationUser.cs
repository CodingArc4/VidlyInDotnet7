using Microsoft.AspNetCore.Identity;

namespace Vidly.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
