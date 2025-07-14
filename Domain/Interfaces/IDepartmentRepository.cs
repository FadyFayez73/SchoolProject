using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department?> GetDepartmentByIdAsync(Guid id);
        Task<(bool, Guid)> AddDepartmentAsync(Department Department);
        Task<bool> UpdateDepartmentAsync(Department Department);
        Task<bool> DeleteDepartmentAsync(Guid id);
        Task<Department?> GetDepartmentByIdWithSubjectsAsync(Guid id);
    }
}
