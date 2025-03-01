using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobportal.Model
{
    public class Jobpost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? JobTile { get; set; }
        public string? JobDescription { get; set; }
        public Employer? Employer { get; set; }
    }
}
