using Dtos;
using IRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IManager
{
    public interface IStudentManager
    {
        Task<List<StudentDto>> GetAllStudents();
        Task<StudentDto> GetStudent(int id);
        Task<List<StudentDto>> AddStudent(StudentDto student);
        Task<List<StudentDto>> UpdateStudent(StudentDto student);
        Task<List<StudentDto>> DeleteStudent(int id);
    }
}
