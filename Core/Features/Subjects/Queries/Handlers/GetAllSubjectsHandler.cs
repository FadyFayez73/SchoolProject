using AutoMapper;
using Core.Dtos.Subject;
using Core.Features.Subjects.Queries.Models;
using Domain.Interfaces;
using MediatR;
using Services.Contracts;

namespace Core.Features.Subjects.Queries.Handlers
{
    public class GetAllSubjectsCommandHandler : IRequestHandler<GetAllSubjectsCommand, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public GetAllSubjectsCommandHandler(ISubjectServices subjectServices, IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjectsCommand request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectServices.GetAllSubjectsAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
    }
}