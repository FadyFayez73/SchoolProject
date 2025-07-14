using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Subject
{
    public class UpdateSubjectDto
    {
        public Guid SubjectID { get; set; }
        public string? Name { get; set; }
        public int Period { get; set; }
    }
}
