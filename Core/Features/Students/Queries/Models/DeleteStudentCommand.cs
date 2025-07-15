using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Models
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public DeleteStudentCommand(Guid id)
        {
            this.StudID = id;
        }

        public Guid StudID { get; set; }
    }
}
