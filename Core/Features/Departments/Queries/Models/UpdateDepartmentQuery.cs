using Core.Dtos.Departments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Models
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public UpdateDepartmentCommand(UpdateDepartmentDto updateDepartmentDto)
        {
            UpdateDepartmentDto = updateDepartmentDto;
        }

        public UpdateDepartmentDto? UpdateDepartmentDto { get; set; }
    }
}
