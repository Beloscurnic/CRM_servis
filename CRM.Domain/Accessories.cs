using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
   public class Accessories
    {
        [Key]
        public int ID_Accessories { get; set; }
        public Guid ID_Сomponent { get; set; }
        public string Type_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public string Сharacteristics_info { get; set; }
        public int Quantity_Сomponent { get; set; }
        public int Price_Сomponent { get; set; }
        [ForeignKey("Provider")]
        public int ID_Provider { get; set; }
        public string Name_Company { get; set; }
        public Provider Provider { get; set; }
    }
}
