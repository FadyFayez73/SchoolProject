using Core.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class CreateStudentCommand : IRequest<(bool, Guid)>
    {
        public CreateStudentCommand(CreateStudentDto createStudentDto)
        {
            CreateStudentDto = createStudentDto;
        }

        public CreateStudentDto? CreateStudentDto { get; set; }
    }
}
