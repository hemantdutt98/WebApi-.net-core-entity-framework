using Dtos;
using IManager;
using IRepository;
using IRepository.Data;
using IRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRespository;
        public StudentManager(IStudentRepository studentRepository,IStudentMentorRepository studentMentorRepository)
        {
            _studentRespository = studentRepository;
        }

        public async Task<List<StudentDto>> AddStudent(StudentDto student)
        {

            return await _studentRespository.AddStudentAsync(student);
        }

        public async Task<List<StudentDto>> DeleteStudent(int id)
        {
            return await _studentRespository.DeleteStudentAsync(id);
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            return await _studentRespository.GetAllStudentsAsync();
        }
        public async Task<StudentDto> GetStudent(int id)
        {
            var result = await _studentRespository.GetStudentAsync(id);
            return result;
        }

        public async Task<List<StudentDto>> UpdateStudent(StudentDto student)
        {
            return await _studentRespository.UpdateStudentAsync(student);
        }
    }
}
