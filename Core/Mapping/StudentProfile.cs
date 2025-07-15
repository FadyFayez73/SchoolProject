using AutoMapper;
using AutoMapper.Internal.Mappers;
using Core.Dtos.Student;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            //CreateMap<CreateStudentDto, Student>()
            //.ForMember(dest => dest.Subjects, opt => opt.MapFrom(src =>
            //    src.SubjectIDs != null
            //        ? src.SubjectIDs.Select(id => new Subject { SubjectID = id }).ToList()
            //        : new List<Subject>()
            //))
            //.ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
        }
    }
}
