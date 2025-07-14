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
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectQuery, bool>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public UpdateSubjectHandler(ISubjectServices subjectServices, IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSubjectQuery request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request.UpdateSubjectDto);
            return await _subjectServices.UpdateAsync(subject);
        }
    }
}
