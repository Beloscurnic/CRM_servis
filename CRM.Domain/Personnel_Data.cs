using System;

namespace CRM.Domain
{
    public class Personnel_Data
    {
        //get; set; аксессоры
        public Guid ID_Personnal { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime Appointment_Date { get; set; }
        public DateTime? Dismissal_Date { get; set; }
        public string Policy_Number { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }


    }
}
