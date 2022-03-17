using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IServiceResponse.Services
{
    public class StudentServiceResponse : IStudentServiceResponse
    {
        public List<Student> responseData { get; set; } = null;
        public bool status { get; set; } = false;
    }
}
