using System.ComponentModel.DataAnnotations;

namespace jobportal.Dtos
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
