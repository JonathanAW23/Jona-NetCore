using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class GetPersonVM
    {
        [Required]
        public string NIK { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string GPA { get; set; }
    }
}
