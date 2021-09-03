using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        [ForeignKey("University_Id")]
        public int University_Id { get; set; }
        [JsonIgnore]
        public virtual University University { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profilings { get; set; }
    }
}
