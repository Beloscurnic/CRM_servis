using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_CPU
{
    public partial class Get_List_CPU
    {
        public class List_CPUVm
        {
            public IList<List_CPU> List_CPUs { get; set; }
        }
    }
}
