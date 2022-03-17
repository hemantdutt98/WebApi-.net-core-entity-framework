using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class MentorDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
