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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool, Guid)> AddSubjectAsync(Subject Subject)
        {
            Subject.SubjectID = Guid.NewGuid();
            _context.Subjects.Add(Subject);
            var result = _context.SaveChangesAsync();

            return await result.ContinueWith(task =>
            {
                if (task.Result > 0)
                {
                    return (true, Subject.SubjectID);
                }
                return (false, Guid.Empty);
            });
        }

        public async Task<bool> DeleteSubjectAsync(Guid id)
        {
            var Subject = await GetSubjectByIdAsync(id);

            if (Subject == null)
                return await Task
                    .FromResult(false);

            _context.Subjects
                .Remove(Subject);

            var result = await _context
                .SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectAsync()
        {
            var Subjects = _context.Subjects
                .AsEnumerable();

            return await Task.FromResult(Subjects);
        }

        public Task<Subject?> GetSubjectByIdAsync(Guid id)
        {
            var Subject = _context.Subjects
                .FirstOrDefault(s => s.SubjectID == id);

            return Task.FromResult(Subject);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByIdsAsync(List<Guid> ids)
        {
            var subjects = await _context.Subjects
                .Where(s => ids.Contains(s.SubjectID))
                .ToListAsync();

            return subjects;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateSubjectAsync(Subject Subject)
        {
            _context.Subjects
                .Update(Subject);

            var result = await _context
                .SaveChangesAsync();

            return result > 0;
        }
    }
}
