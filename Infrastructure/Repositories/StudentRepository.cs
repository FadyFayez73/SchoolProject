using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool, Guid)> AddStudentAsync(Student student)
        {
            student.StudID = Guid.NewGuid();
            _context.Students.Add(student);
            var result = _context.SaveChangesAsync();

            return await result.ContinueWith(task =>
            {
                if (task.Result > 0)
                {
                    return (true, student.StudID);
                }
                return (false, Guid.Empty);
            });
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var student = await GetStudentByIdAsync(id);

            if (student == null)
                return await Task
                    .FromResult(false);

            _context.Students
                .Remove(student);

            var result = await _context
                .SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            var students = _context.Students
                .AsEnumerable();

            return await Task.FromResult(students);
        }

        public Task<Student?> GetStudentByIdAsync(Guid id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.StudID == id);

            return Task.FromResult(student);
        }

        public Task<IEnumerable<Student>> GetStudentsByIdsAsync(List<Guid> ids)
        {
            var students = _context.Students
                .Where(s => ids.Contains(s.StudID))
                .AsEnumerable();

            return Task.FromResult(students);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var stud = await GetStudentByIdAsync(student.StudID);
            if (stud != null)
            {
                stud.Address = student.Address;
                stud.Phone = student.Phone;
                stud.Name = student.Name;

                _context.Students
                    .Update(stud);

                var result = _context
                .SaveChangesAsync();

                return await result.ContinueWith(task =>
                {
                    return task.Result > 0;
                });
            }
            return await Task.FromResult(false);
        }
    }
}
