using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Appointment_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Dismissal_Date { get; set; }
        [Required]
        public string Policy_Number { get; set; }
        public int Salary { get; set; }
        public string ReturnUrl { get; set; }
    }
}
