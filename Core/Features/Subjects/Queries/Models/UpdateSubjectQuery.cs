using Core.Dtos.Subject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Models
{
    public class UpdateSubjectQuery : IRequest<bool>
    {
        public UpdateSubjectQuery(UpdateSubjectDto updateSubjectDto) 
        {
            UpdateSubjectDto = updateSubjectDto;
        }

        public UpdateSubjectDto UpdateSubjectDto { get; set; }
    }
}
