using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class Profiling
    {
        [Key]
        [ForeignKey("Account")]
        public string NIK { get; set; }
        [ForeignKey("Education_Id")]
        public int Education_Id { get; set; }

        public virtual Account Account { get; set; }
        public virtual Education Education { get; set; }
    }
}
