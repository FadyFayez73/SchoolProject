using AutoMapper;
using Core.Features.Subjects.Queries.Models;
using Domain.Interfaces;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Subjects.Queries.Handlers
{
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectQuery, bool>
    {
        private readonly ISubjectServices _subjectServices;

        public DeleteSubjectHandler(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        public async Task<bool> Handle(DeleteSubjectQuery request, CancellationToken cancellationToken)
        {
            return await _subjectServices.DeleteAsync(request.Id);
        }
    }
}
