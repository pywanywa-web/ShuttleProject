using Microsoft.AspNetCore.Identity;

namespace ShuttleProject.Models.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
