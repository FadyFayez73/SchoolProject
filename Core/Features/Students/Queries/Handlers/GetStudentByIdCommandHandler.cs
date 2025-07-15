using AutoMapper;
using Core.Dtos.Student;
using Core.Features.Students.Queries.Models;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Handlers
{
    public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdCommand, StudentDto>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public GetStudentByIdCommandHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentByIdCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentDto>(await _studentServices.GetStudentByIdAsync(request.Id));
        }
    }
} 