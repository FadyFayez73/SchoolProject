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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.UpdateStudentDto);
            return await _studentServices.UpdateAsync(student);
        }
    }
} 