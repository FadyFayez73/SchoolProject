using AutoMapper;
using Core.Dtos.Student;
using Core.Features.Students.Queries.Modles;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Handlers
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        #endregion


        #region Constructor
        public GetAllStudentHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }
        #endregion

        
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentServices.GetAllStudentsAsync());
        }
    }
}
