using Dtos;
using IManager;
using IRepository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi
{
    [ApiController]
    [Route("[controller]")]
    
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager; 
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<List<StudentDto>> Get()
        {
            return  await _studentManager.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<StudentDto> GetId([FromRoute] int id)
        {
            var result = await _studentManager.GetStudent(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StudentDto student)
        {
            return Ok(await _studentManager.AddStudent(student));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] StudentDto student)
        {
            return Ok(await _studentManager.UpdateStudent(student));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _studentManager.DeleteStudent(id));
        }
    }
}
