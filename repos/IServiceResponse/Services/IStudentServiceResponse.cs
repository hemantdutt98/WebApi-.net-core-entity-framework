using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IServiceResponse.Services
{
    public interface IStudentServiceResponse
    {
        public List<Student> responseData { get; set; }
        public bool status { get; set; }
    }
}
