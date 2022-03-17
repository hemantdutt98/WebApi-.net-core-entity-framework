using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class StudentMentorDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int Teacher { get; set; }

        [Required]
        public string MentorName { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
