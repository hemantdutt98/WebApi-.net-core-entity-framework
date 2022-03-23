using AutoMapper;
using Dtos;
using IRepository.Models;
using StudentApi.Dtos;

namespace AutoMapperProfile
{
    public class AutoMapperSetProfile : Profile 
    {
        public AutoMapperSetProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Mentor, MentorDto>();
            CreateMap<StudentMentorModel, StudentMentorDto>();
            CreateMap<object, ProjectReleaseDto>();

            CreateMap<StudentDto, Student>();
            CreateMap<MentorDto, Mentor>();
            CreateMap<StudentMentorDto, StudentMentorModel>();
            CreateMap<ProjectReleaseDto, object>();
        }
    }
}
