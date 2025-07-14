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
    public class StudentServices : IStudentServices
    {
        public readonly IStudentRepository _studentRepository;
        public readonly IDepartmentRepository _departmentRepository;

        public StudentServices(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task<(bool, Guid)> AddAsync(Student student)
        {
            return await _studentRepository.AddStudentAsync(student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var existingStudent = await _studentRepository
                .GetStudentByIdAsync(student.StudID);

            if (existingStudent == null) return false;

            if (student.DepartmentID != existingStudent.DepartmentID)
            {
                if (student.DepartmentID.HasValue && student.DepartmentID.Value != Guid.Empty)
                {
                    var department = await _departmentRepository
                        .GetDepartmentByIdAsync(student.DepartmentID.Value);
                    if (department == null) return false;
                    existingStudent.Department = student.Department;
                }
            }

            existingStudent.Name = student.Name;
            existingStudent.Address = student.Address;
            existingStudent.Phone = student.Phone;

            return await _studentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
