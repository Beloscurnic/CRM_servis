using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_Motherboard
{
    public partial class Get_List_Motherboard
    {
        public class List_MotherboardVm
        {
            public IList<Get_List_Motherboard> Get_List_Motherboards { get; set; }
        }
    }
}
