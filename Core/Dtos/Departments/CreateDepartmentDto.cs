using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Department
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;
        public List<Guid> SubjectIDs { get; set; } = new List<Guid>();
    }
}
