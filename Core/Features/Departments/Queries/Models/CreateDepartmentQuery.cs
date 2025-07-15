using Core.Dtos.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Models
{
    public class CreateDepartmentCommand : IRequest<(bool, Guid)>
    {
        public CreateDepartmentCommand(CreateDepartmentDto createDepartmentDto)
        {
            CreateDepartmentDto = createDepartmentDto;
        }
        public CreateDepartmentDto? CreateDepartmentDto { get; set; }
    }
}
