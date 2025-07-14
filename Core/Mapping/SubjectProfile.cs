using AutoMapper;
using Core.Dtos.Subject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>()
                .ReverseMap();

            CreateMap<Subject, CreateSubjectDto>()
                .ReverseMap();

            CreateMap<Subject, UpdateSubjectDto>()
                .ReverseMap();
        }
    }
}
