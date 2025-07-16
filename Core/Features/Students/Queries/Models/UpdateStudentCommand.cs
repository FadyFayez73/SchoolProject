using Core.Dtos.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public UpdateStudentCommand(UpdateStudentDto updateStudentDto) 
        {
            this.UpdateStudentDto = updateStudentDto;
        }

        public UpdateStudentDto? UpdateStudentDto { get; set; }
    }
} 