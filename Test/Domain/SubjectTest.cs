using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class SubjectTest
    {
        [Fact]
        public void Subject()
        {
            var id = Guid.NewGuid();
            var departments = new List<Department>
            {
                new Department { DepartmentID = Guid.NewGuid(), Name = "Science" },
                new Department { DepartmentID = Guid.NewGuid(), Name = "Arts" }
            };
            var subject = new Subject
            {
                SubjectID = id,
                Name = "Mathematics",
                Period = 3,
                Departments = departments
            };

            Assert.NotNull(subject);
            Assert.True(subject.SubjectID == id);
            Assert.True(subject.Name == "Mathematics");
            Assert.True(subject.Period == 3);

            Assert.NotNull(subject.Departments);
            Assert.Equal(2, subject.Departments.Count);
            Assert.Contains(subject.Departments, d => departments.Select(d => d.DepartmentID).Contains(d.DepartmentID));
            Assert.Contains(subject.Departments, d => departments.Select(d => d.Name).Contains(d.Name));
        }
    }
}
