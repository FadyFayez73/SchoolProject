using AutoMapper;
using Core.Dtos.Department;
using Core.Features.Departments.Queries.Models;
using Domain.Entities;
using MediatR;
using Services.Contracts;

namespace Core.Features.Departments.Queries.Handlers
{
    public class GetAllDepartmentCommandHandler : IRequestHandler<GetAllDepartmentsCommand, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;

        public GetAllDepartmentCommandHandler(IDepartmentServices departmentServices, IMapper mapper)
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<DepartmentDto>>(await _departmentServices
                .GetAllDepartmentsAsync());
        }
    }
}