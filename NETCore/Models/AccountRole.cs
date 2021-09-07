using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class AccountRole
    {
        [Key] 
        public int Id { get; set; }
        [ForeignKey("NIK")]
        public string NIK { get; set; }
        [ForeignKey("Role_Id")]
        public int Role_Id { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
