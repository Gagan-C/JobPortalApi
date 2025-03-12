using System.ComponentModel.DataAnnotations;

namespace Jobpost.API.Dtos
{
    public class EmployerOnboardingDTO
    {
        [Required]
        public string? EmployerFirstName { get; set; }
        [Required]
        public string? EmployerLastName { get; set; }
        [Required]
        public string? EmployerEmail { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? CompanyAddress{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password  { get; set; }
    }
}
