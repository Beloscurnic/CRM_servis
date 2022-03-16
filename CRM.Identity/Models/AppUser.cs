using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Identity.Models
{
    public class AppUser: IdentityUser
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Telefon { get; set; }
        [Column(TypeName = "date")]
        public DateTime Appointment_Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Dismissal_Date { get; set; }
        public string Policy_Number { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
    }
}
