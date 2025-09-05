using AutoMapper;
using LanoiraM_6th.Dtos;
using LanoiraM_6th.Models;

namespace LanoiraM_6th.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
        }
    }
}
