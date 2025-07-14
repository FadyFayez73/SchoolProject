using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectServices(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Subject entity)
        {
            return await _subjectRepository.AddSubjectAsync(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _subjectRepository.DeleteSubjectAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllSubjectAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(Guid id)
        {
            return await _subjectRepository.GetSubjectByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Subject entity)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(entity.SubjectID);

            if (subject == null) return false;

            subject.Name = entity.Name;
            subject.Period = entity.Period;

            return await _subjectRepository.SaveChangesAsync();
        }
    }
}
