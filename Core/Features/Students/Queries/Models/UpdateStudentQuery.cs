using Core.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Modles
{
    public class UpdateStudentQuery : IRequest<bool>
    {
        public UpdateStudentQuery(UpdateStudentDto updateStudentDto) 
        {
            this.UpdateStudentDto = updateStudentDto;
        }

        public UpdateStudentDto? UpdateStudentDto { get; set; }
    }
}
