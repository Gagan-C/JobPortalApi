using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace jobportal.Model
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? CreatedBy { get; set; }
    }
}
