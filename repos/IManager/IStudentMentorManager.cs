using Dtos;
using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IManager
{
    public interface IStudentMentorManager
    {
        Task<List<StudentMentorDto>> GetStudentMentor();
    }
}
