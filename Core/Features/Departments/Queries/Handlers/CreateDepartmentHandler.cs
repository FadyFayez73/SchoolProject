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
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentQuery, (bool, Guid)>
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;

        public CreateDepartmentHandler(IDepartmentServices departmentServices, IMapper mapper)
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
        }

        public Task<(bool, Guid)> Handle(CreateDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request.CreateDepartmentDto);
            return _departmentServices.AddAsync(department);
        }
    }
}
