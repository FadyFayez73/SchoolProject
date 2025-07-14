using Core.Dtos.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Models
{
    public class CreateDepartmentQuery : IRequest<(bool, Guid)>
    {
        public CreateDepartmentQuery(CreateDepartmentDto createDepartmentDto)
        {
            CreateDepartmentDto = createDepartmentDto;
        }
        public CreateDepartmentDto? CreateDepartmentDto { get; set; }
    }
}
