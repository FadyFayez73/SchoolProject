using AutoMapper;
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
    public class CreateStudentHandler : IRequestHandler<CreateStudentQuery, (bool, Guid)>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateStudentQuery request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.CreateStudentDto);
            return await _studentServices.AddAsync(student);
        }
    }
}
