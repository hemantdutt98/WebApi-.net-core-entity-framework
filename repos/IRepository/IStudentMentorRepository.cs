using Dtos;
using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IStudentMentorRepository
    {
        public Task<List<StudentMentorDto>> GetStudentMentordata();
    }
}
