using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class StudentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Teacher { get; set; }
    }
}
