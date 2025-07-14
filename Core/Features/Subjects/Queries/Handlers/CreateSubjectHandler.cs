using AutoMapper;
using Core.Dtos.Subject;
using Core.Features.Subjects.Queries.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Services.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Handlers
{
    public class CreateSubjectHandler : IRequestHandler<CreateSubjectQuery, (bool, Guid)>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public CreateSubjectHandler(ISubjectServices subjectServices, IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }

        public async Task<(bool, Guid)> Handle(CreateSubjectQuery request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request.CreateSubjectDto);
            return await _subjectServices.AddAsync(subject);
        }
    }
}
