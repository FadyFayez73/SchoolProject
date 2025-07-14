using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Departments
{
    public class UpdateDepartmentDto
    {
        public Guid DepartmentID { get; set; }
        public string? Name { get; set; }
        public List<Guid> SubjectIds { get; set; } = new List<Guid>();
    }
}
