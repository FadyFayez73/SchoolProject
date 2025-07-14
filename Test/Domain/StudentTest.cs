using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class StudentTest
    {
        [Fact]
        public void Student()
        {
            var id = Guid.NewGuid();
            var department = new Department
            {
                DepartmentID = Guid.NewGuid(),
                Name = "Computer Science",
            };

            var student = new Student
            {
                StudID = id,
                Name = "John Doe",
                Address = "123 Main St",
                Phone = "555-1234",
                DepartmentID = Guid.NewGuid(),
                Department = department
            };

            Assert.NotNull(student);
            Assert.True(student.StudID == id);
            Assert.True(student.Name == "John Doe");
            Assert.True(student.Address == "123 Main St");
            Assert.True(student.Phone == "555-1234");

            Assert.NotNull(student.Department);
            Assert.True(student.Department.DepartmentID == department.DepartmentID);
            Assert.True(student.Department.Name == department.Name);
        }
    }
}
