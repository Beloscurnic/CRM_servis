using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
    public class Equipment
    {
        [Key]
        public Guid ID_Equipment { get; set; }

        [ForeignKey("Order_Client")]
        public int ID_Order { get; set; }
        public int ID_Accessories { get; set; }
        public string Type_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public int Price_Сomponent { get; set; }
        public Order_Client Order_Client { get; set; }

        [ForeignKey("Provider")]
        public int ID_Provider { get; set; }
        public string Name_Company { get; set; }
        public Provider Provider { get; set; }
    }
}
