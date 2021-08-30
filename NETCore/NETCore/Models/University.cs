using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}
