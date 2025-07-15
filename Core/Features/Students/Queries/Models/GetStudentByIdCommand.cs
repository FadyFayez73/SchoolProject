using Core.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class GetStudentByIdCommand : IRequest<StudentDto>
    {
        public Guid Id { get; set; }
    }
} 