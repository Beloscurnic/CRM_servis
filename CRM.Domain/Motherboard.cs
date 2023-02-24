using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
   public class Motherboard
    {
        [Key]
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }

        public string Motherboard_socket { get; set; }
        public string Motherboard_chipset { get; set; }
        public string RAM { get; set; }
        public string Disk_controllers { get; set; }
        public string Expansion_slots { get; set; }
        public string Net { get; set; }
        public string audio_and_video { get; set; }
        public string Form_factor { get; set; }
    }
}
