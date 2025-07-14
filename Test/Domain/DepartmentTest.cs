using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class DepartmentTest
    {
        [Fact]
        public void Department()
        {
            var id = Guid.NewGuid();
            var students = new List<Student>
            {
                new Student { StudID = Guid.NewGuid(), Name = "Alice", Address = "456 Elm St", Phone = "555-5678" },
                new Student { StudID = Guid.NewGuid(), Name = "Bob", Address = "789 Oak St", Phone = "555-8765" }
            };

            var subjects = new List<Subject>
            {
                new Subject { SubjectID = Guid.NewGuid(), Name = "Physics", Period = 4 },
                new Subject { SubjectID = Guid.NewGuid(), Name = "Chemistry", Period = 3 }
            };

            var department = new Department
            {
                DepartmentID = id,
                Name = "Computer Science",
                Students = students,
                Subjects = subjects

            };
            Assert.NotNull(department);
            Assert.True(department.DepartmentID == id);
            Assert.True(department.Name == "Computer Science");

            Assert.NotNull(department.Students);
            Assert.Equal(2, department.Students.Count);
            Assert.Contains(department.Students, s => students.Select(s => s.StudID).Contains(s.StudID));
            Assert.Contains(department.Students, s => students.Select(s => s.Name).Contains(s.Name));
            Assert.Contains(department.Students, s => students.Select(s => s.Address).Contains(s.Address));
            Assert.Contains(department.Students, s => students.Select(s => s.Phone).Contains(s.Phone));


            Assert.NotNull(department.Subjects);
            Assert.Equal(2, department.Subjects.Count);
            Assert.Contains(department.Subjects, s => subjects.Select(s => s.SubjectID).Contains(s.SubjectID));
            Assert.Contains(department.Subjects, s => subjects.Select(s => s.Name).Contains(s.Name));
            Assert.Contains(department.Subjects, s => subjects.Select(s => s.Period).Contains(s.Period));
        }
    }
}
