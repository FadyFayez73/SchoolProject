using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public Guid SubjectID { get; set; }
        public string? Name { get; set; }
        public int Period { get; set; }

        public ICollection<Department>? Departments { get; set; }
    }
}
