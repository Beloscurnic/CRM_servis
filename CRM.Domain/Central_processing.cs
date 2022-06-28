using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Central_processing
    {
        [Key]
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public int Price_CPU { get; set; }
        public int Quantity_CPU { get; set; }
        public int Number_Cores { get; set; }
        public string Purity_CPU { get; set; }

    }
}
