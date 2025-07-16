using AutoMapper;
using Core.Dtos.Subject;
using Core.Features.Subjects.Queries.Models;
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
    public class GetSubjectByIdCommandHandler : IRequestHandler<GetSubjectByIdCommand, SubjectDto>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public GetSubjectByIdCommandHandler(ISubjectServices subjectServices, IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }

        public async Task<SubjectDto> Handle(GetSubjectByIdCommand request, CancellationToken cancellationToken)
        {
            var subject = await _subjectServices.GetSubjectByIdAsync(request.Id);
            return _mapper.Map<SubjectDto>(subject);
        }
    }
}
