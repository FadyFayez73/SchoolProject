using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubjectRepository : IBaseRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjectAsync();
        Task<Subject?> GetSubjectByIdAsync(Guid id);
        Task<(bool, Guid)> AddSubjectAsync(Subject Subject);
        Task<bool> UpdateSubjectAsync(Subject Subject);
        Task<bool> DeleteSubjectAsync(Guid id);
        Task<IEnumerable<Subject>> GetSubjectsByIdsAsync(List<Guid> ids);
    }
}
