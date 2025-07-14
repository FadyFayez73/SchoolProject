using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student?> GetStudentByIdAsync(Guid id);
        Task<(bool, Guid)> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Guid id);
        Task<IEnumerable<Student>> GetStudentsByIdsAsync(List<Guid> ids);
    }
}
