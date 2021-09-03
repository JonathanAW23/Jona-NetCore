using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class Person
    {
        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public enum Gender { 
            Male,
            Female
        }
        public Gender gender { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }

    }
}
