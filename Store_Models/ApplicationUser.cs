using Microsoft.AspNetCore.Identity;

namespace Store_Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
