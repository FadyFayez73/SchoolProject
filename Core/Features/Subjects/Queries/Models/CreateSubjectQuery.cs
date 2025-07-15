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
    public class CreateSubjectCommand : IRequest<(bool, Guid)>
    {
        public CreateSubjectCommand(CreateSubjectDto createSubjectQuery)
        {
            CreateSubjectDto = createSubjectQuery;
        }

        public CreateSubjectDto CreateSubjectDto { get; set; }
    }
}
