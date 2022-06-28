using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
   public class Services_rendered
    {
        [Key]
        public int ID_Services { get; set; }
        public int ID_Order { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public string Warranty { get; set; }
        public int Price_services { get; set; }
    }
}
