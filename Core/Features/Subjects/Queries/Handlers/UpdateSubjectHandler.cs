using AutoMapper;
using Core.Features.Subjects.Queries.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Handlers
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, bool>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public UpdateSubjectCommandHandler(ISubjectServices subjectServices, IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request.UpdateSubjectDto);
            return await _subjectServices.UpdateAsync(subject);
        }
    }
}
