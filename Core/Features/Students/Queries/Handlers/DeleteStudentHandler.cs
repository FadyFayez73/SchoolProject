using AutoMapper;
using Core.Features.Students.Queries.Modles;
using Domain.Entities;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Students.Queries.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentQuery, bool>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public DeleteStudentHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteStudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentServices.DeleteAsync(request.StudID);
        }
    }
}
