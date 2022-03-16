using System;

namespace CRM.Domain
{
    public class Personnel_Data
    {
        //get; set; аксессоры
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
