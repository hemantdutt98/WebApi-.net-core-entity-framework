using IRepository;
using IRepository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace Repository
{
    public class StudentMentorRepository : IStudentMentorRepository
    {
        private readonly TestDbContext _testDbContext;

        public StudentMentorRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public async Task<List<StudentMentorDto>> GetStudentMentordata()
        {
            var newList = await (from student in _testDbContext.Student.AsNoTracking()
                           join mentor in _testDbContext.Mentor.AsNoTracking()
                     on student.Teacher equals mentor.Id
                           select new StudentMentorDto
                           {
                               Teacher = (int)student.Teacher,
                               MentorName = mentor.Name,
                               Subject = mentor.Subject,
                               Id = student.Id,
                               Name = student.Name
                           }).ToListAsync();

            return newList;
        }

        //public Task<List<StudentMentorModel>> IStudentMentorRepository.GetStudentMentordata()
        //{
        //    return  (from student in _testDbContext.Student.AsNoTracking()
        //                  join mentor in _testDbContext.Mentor.AsNoTracking()
        //            on student.Teacher equals mentor.Id
        //            select new
        //            {
        //                MentorId = student.Teacher,
        //                MentorName = mentor.Name,
        //                Subject = mentor.Subject,
        //                StudentId = student.Id,
        //                StudentName = student.Name
        //            }).ToList();
        //}
    }
}
