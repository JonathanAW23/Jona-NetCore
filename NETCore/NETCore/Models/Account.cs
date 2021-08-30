using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace NETCore.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("Person")]
        public string NIK { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        public virtual Profiling Profiling { get; set; }
    }
}
