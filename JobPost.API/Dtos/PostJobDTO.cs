using System.ComponentModel.DataAnnotations;

namespace Jobpost.API.Dtos
{
    public class PostJobDTO
    {
        public int EmployerId { get; set; }
        [Required]
        public string? JobDescription { get; set; }
        [Required]
        public string? JobTitle { get; set; }
    }
}
