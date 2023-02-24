using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Domain
{
   public class Provider
    {
        [Key]
        public int ID_Provider { get; set; }
        public string Name_Company { get; set; }
        public string Identification_Number { get; set; }
        public string Supplier_Address { get; set; }
        public string FIO_Director { get; set; }
        public string Telefon { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public List <Equipment> Equipments { get; set; }
        public List<Accessories> Accessoriess { get; set; }
    }
}
