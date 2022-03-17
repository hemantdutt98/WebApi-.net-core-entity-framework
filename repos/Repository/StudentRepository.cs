using AutoMapper;
using Dtos;
using IRepository.Data;
using IRepository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TestDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(TestDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> AddStudentAsync(StudentDto student)
        {
            _context.Student.Add(_mapper.Map<Student>(student));
            _context.SaveChanges();
            return await _context.Student.Select(student => _mapper.Map<StudentDto>(student)).ToListAsync();
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            return await _context.Student.Select(student => _mapper.Map<StudentDto>(student)).ToListAsync();
            //return await _context.Student.ToListAsync();
        }
            
        public async Task<StudentDto> GetStudentAsync(int id)
        {
            return _mapper.Map<StudentDto>(_context.Student.Find(id));
        }

        public async Task<List<StudentDto>> UpdateStudentAsync(StudentDto student)
        {
            var updateStudent = _mapper.Map<Student>(student);
            _context.Student.Attach(updateStudent);
            _context.Entry(updateStudent).Property("Name").IsModified = true;
            _context.Entry(updateStudent).Property("Teacher").IsModified = true;
            _context.SaveChanges();
            return await _context.Student.Select(student => _mapper.Map<StudentDto>(student)).ToListAsync();
        }

        public async Task<List<StudentDto>> DeleteStudentAsync(int id)
        {
            var recordToDelete = _context.Student.Find(id);
            _context.Remove(recordToDelete);
            _context.SaveChanges();
            return await _context.Student.Select(student => _mapper.Map<StudentDto>(student)).ToListAsync();
        }
    }
}
