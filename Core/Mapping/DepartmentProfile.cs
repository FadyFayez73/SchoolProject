using AutoMapper;
using Core.Dtos.Department;
using Core.Dtos.Departments;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();

            // Create Mapping
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.Subjects,
                    opt => opt.MapFrom((src, dest, _, context) =>
                        src.SubjectIDs?.Select(id => new Subject { SubjectID = id }).ToList()
                    ));

            CreateMap<Department, CreateDepartmentDto>()
                .ForMember(dest => dest.SubjectIDs, opt => opt.MapFrom(src =>
                   src.Subjects != null
                    ? src.Subjects.Select(s => s.SubjectID)
                    : new List<Guid>()
                ));

            // Update Mapping
            CreateMap<UpdateDepartmentDto, Department>()
                .ForMember(dest => dest.Subjects,
                   opt => opt.MapFrom((src, dest, _, context) =>
                   src.SubjectIds?.Select(id => new Subject { SubjectID = id }).ToList()
                ));

            CreateMap<Department, UpdateDepartmentDto>()
                .ForMember(dest => dest.SubjectIds, opt => opt.MapFrom(src =>
                   src.Subjects != null
                    ? src.Subjects.Select(s => s.SubjectID)
                    : new List<Guid>()
                ));
        }
    }
}
