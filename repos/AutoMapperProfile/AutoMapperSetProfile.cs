using AutoMapper;
using Dtos;
using IRepository.Models;

namespace AutoMapperProfile
{
    public class AutoMapperSetProfile : Profile 
    {
        public AutoMapperSetProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Mentor, MentorDto>();
            CreateMap<StudentMentorModel, StudentMentorDto>();

            CreateMap<StudentDto, Student>();
            CreateMap<MentorDto, Mentor>();
            CreateMap<StudentMentorDto, StudentMentorModel>();
        }
    }
}
