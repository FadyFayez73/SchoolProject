using Core.Dtos.Student;
using Core.Dtos.Subject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdCommand : IRequest<SubjectDto>
    {
        public GetSubjectByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
