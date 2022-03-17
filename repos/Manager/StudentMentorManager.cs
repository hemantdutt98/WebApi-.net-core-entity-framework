using IRepository;
using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IManager;
using Dtos;

namespace Manager
{
    public class StudentMentorManager : IStudentMentorManager
    {
        private readonly IStudentMentorRepository _studentMentorRepository;

        public StudentMentorManager(IStudentMentorRepository studentMentorRepository)
        {
            _studentMentorRepository = studentMentorRepository;
        }
        public async Task<List<StudentMentorDto>> GetStudentMentor()
        {

            return await _studentMentorRepository.GetStudentMentordata();
        }
    }
}
