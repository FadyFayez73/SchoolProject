using AutoMapper;
using Core.Features.Departments.Queries.Models;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Handlers
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentQuery, bool>
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;

        public UpdateDepartmentHandler(IDepartmentServices departmentServices, IMapper mapper)
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request.UpdateDepartmentDto);
            return await _departmentServices.UpdateAsync(department);
        }
    }
}
