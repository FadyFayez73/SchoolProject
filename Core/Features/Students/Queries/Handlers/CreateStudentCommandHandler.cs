using AutoMapper;
using Core.Features.Students.Queries.Models;
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
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, (bool, Guid)>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.CreateStudentDto);
            return await _studentServices.AddAsync(student);
        }
    }
} 