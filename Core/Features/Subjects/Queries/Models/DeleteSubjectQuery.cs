using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Models
{
    public class DeleteSubjectQuery : IRequest<bool>
    {
        public DeleteSubjectQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
