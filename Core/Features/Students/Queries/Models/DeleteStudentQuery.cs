using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Modles
{
    public class DeleteStudentQuery : IRequest<bool>
    {
        public DeleteStudentQuery(Guid id)
        {
            this.StudID = id;
        }

        public Guid StudID { get; set; }
    }
}
