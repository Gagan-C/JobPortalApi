using Microsoft.AspNetCore.Identity;

namespace Jobpost.API.Model
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? CreatedBy { get; set; }
    }
}
