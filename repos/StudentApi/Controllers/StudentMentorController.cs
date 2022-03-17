using Dtos;
using IManager;
using IRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentMentorController : ControllerBase
    {
        private readonly IStudentMentorManager _studentMentorManager;

        public StudentMentorController(IStudentMentorManager studentMentorManager)
        {
            _studentMentorManager = studentMentorManager;
        }

        [HttpGet]
        public Task<List<StudentMentorDto>> GetStudentMentor()
        {
            return _studentMentorManager.GetStudentMentor();
        }
    }
}
