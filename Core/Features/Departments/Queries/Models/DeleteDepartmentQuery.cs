using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departments.Queries.Models
{
    public class DeleteDepartmentQuery : IRequest<bool>
    {
        public DeleteDepartmentQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
