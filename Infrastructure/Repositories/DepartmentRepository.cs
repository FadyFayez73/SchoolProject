using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool, Guid)> AddDepartmentAsync(Department Department)
        {
            Department.DepartmentID = Guid.NewGuid();
            _context.Departments.Add(Department);
            var result = _context.SaveChangesAsync();

            return await result.ContinueWith(task =>
            {
                if (task.Result > 0)
                {
                    return (true, Department.DepartmentID);
                }
                return (false, Guid.Empty);
            });
        }

        public async Task<bool> DeleteDepartmentAsync(Guid id)
        {
            var Department = await GetDepartmentByIdAsync(id);

            if (Department == null)
                return await Task
                    .FromResult(false);

            _context.Departments
                .Remove(Department);

            var result = await _context
                .SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            var Departments = _context.Departments
                .AsEnumerable();

            return await Task.FromResult(Departments);
        }

        public Task<Department?> GetDepartmentByIdAsync(Guid id)
        {
            var Department = _context.Departments
                .FirstOrDefault(s => s.DepartmentID == id);

            return Task.FromResult(Department);
        }

        public async Task<Department?> GetDepartmentByIdWithSubjectsAsync(Guid id)
        {
            return await _context.Departments
                .Include(d => d.Subjects)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            var result = await _context
                .SaveChangesAsync();

            return result > 0;
        }
    }
}
