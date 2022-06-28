using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_Delivery
{
    public partial class Get_List_Delivery
    {
        public class List_DeliveryVm
        {
            public IList<List_Delivery> List_Deliverys { get; set; }
        }
    }
}
