using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
   public class Random_Access_Memory
    {
        [Key]
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }
        public string memory_type { get; set; }
        public string Form_factor { get; set; }
        public string Memory_module_key { get; set; }
        public string Volume { get; set; }
        public string Clock_frequency { get; set; }
        public string Timing { get; set; }

    }
}
