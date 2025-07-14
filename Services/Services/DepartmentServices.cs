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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository, ISubjectRepository subjectRepository)
        {
            _departmentRepository = departmentRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Department entity)
        {
            if(entity.Subjects != null)
            {
                var subjectsIds = entity.Subjects.Select(s => s.SubjectID).ToList();
                var subjects = await _subjectRepository.GetSubjectsByIdsAsync(subjectsIds);
                entity.Subjects = subjects.ToList();
            }

            return await _departmentRepository.AddDepartmentAsync(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(Guid id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Department entity)
        {
            var department = await _departmentRepository
                .GetDepartmentByIdWithSubjectsAsync(entity.DepartmentID);

            if (department == null) return false;

            var subjectsIds = entity.Subjects.Select(s => s.SubjectID).ToList();
            var subjects = await _subjectRepository.GetSubjectsByIdsAsync(subjectsIds);

            department.Subjects.Clear();
            foreach (var subject in subjects)
            {
                department.Subjects.Add(subject);
            }

            department.Name = entity.Name;

            return await _departmentRepository.SaveChangesAsync();
        }
    }
}
