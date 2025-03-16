using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPost.API.Dtos
{
    public class LoginDto
    {
        [Required]
        public required string  Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public required string Password { get; set; }
    }
}
