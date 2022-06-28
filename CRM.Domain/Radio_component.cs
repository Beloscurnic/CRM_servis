using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
   public class Radio_component
    {
        [Key]
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }
        public string options { get; set; }

    }
}
