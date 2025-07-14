using AutoMapper;
using Core.Dtos.Student;
using Core.Features.Students.Queries.Modles;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Handlers
{
    public class GatStudentByIDHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public GatStudentByIDHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentDto>(await _studentServices.GetStudentByIdAsync(request.Id));
        }
    }
}
