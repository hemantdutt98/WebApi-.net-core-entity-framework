using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IRepository.Models
{
    public class StudentMentorModel
    {
        public int MentorId { get; set; }
        public string MentorName { get; set; }
        public string Subject { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }

    }
}
