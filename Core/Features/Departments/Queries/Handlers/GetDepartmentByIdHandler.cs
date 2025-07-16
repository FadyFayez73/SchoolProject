using AutoMapper;
using Core.Dtos.Department;
using Core.Features.Departments.Queries.Models;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Handlers
{
    public class GetDepartmentByIdCommandHandler : IRequestHandler<GetDepartmentByIdCommand, DepartmentDto>
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        public GetDepartmentByIdCommandHandler(IDepartmentServices departmentServices, IMapper mapper)
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DepartmentDto>(await _departmentServices
                .GetDepartmentByIdAsync(request.DepartmentID));
        }
    }
}
