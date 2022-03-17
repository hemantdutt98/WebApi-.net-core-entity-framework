using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRepository.Models
{
    public partial class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int? Teacher { get; set; }

        [ForeignKey(nameof(Teacher))]
        [InverseProperty(nameof(Mentor.Student))]
        public virtual Mentor TeacherNavigation { get; set; }
    }
}
