using Dtos;
using IRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository.Data
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAllStudentsAsync();

        Task<StudentDto> GetStudentAsync(int id);

        Task<List<StudentDto>> AddStudentAsync(StudentDto student);

        Task<List<StudentDto>> UpdateStudentAsync(StudentDto student);

        Task<List<StudentDto>> DeleteStudentAsync(int i);
    }
}
