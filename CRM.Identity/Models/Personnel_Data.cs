using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Identity.Models
{
    public class Personnel_Data
    {
        //get; set; аксессоры
        [Key]
        public Guid ID_Personnal { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Position { get; set; }
    }
}
