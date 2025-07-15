using Core.Dtos.Subject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Models
{
    public class GetAllSubjectsCommand : IRequest<IEnumerable<SubjectDto>>
    {
    }
}
