using Core.Dtos.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdCommand : IRequest<DepartmentDto>
    {
        public GetDepartmentByIdCommand(Guid departmentID)
        {
            DepartmentID = departmentID;
        }

        public Guid DepartmentID { get; set; }
    }
}
