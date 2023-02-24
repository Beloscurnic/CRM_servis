using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Domain
{
  public class Delivery
    {
        [Key]
        public int ID_Delevery { get; set; }
        public int ID_Accessories { get; set; }
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }

        public string Type_Сomponent { get; set; }
        public int Price_Сomponent { get; set; }
        public int Quantity_Сomponent { get; set; }
        public int Summa { get; set; }
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime Receipt_date { get; set; }
        public string Issue_date { get; set; }
        [ForeignKey("Provider")]
        public int ID_Provider { get; set; }
        public string Name_Company { get; set; }
        public Provider Provider { get; set; }

    }
}
