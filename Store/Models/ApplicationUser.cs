using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
