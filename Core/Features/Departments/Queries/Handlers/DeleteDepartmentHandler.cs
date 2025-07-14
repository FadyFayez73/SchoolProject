using AutoMapper;
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
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentQuery, bool>
    {
        private readonly IDepartmentServices _departmentServices;

        public DeleteDepartmentHandler(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        public async Task<bool> Handle(DeleteDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _departmentServices.DeleteAsync(request.Id);
        }
    }
}
