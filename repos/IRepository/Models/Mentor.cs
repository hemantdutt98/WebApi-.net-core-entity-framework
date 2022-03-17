using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class Mentor
    {
        public Mentor()
        {
            Student = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Subject { get; set; }

        [InverseProperty("TeacherNavigation")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
