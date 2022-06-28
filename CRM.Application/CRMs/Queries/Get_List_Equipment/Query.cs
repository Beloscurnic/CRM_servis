using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_Equipment
{
    public partial class Get_List_Equipment
    {
        public class Query : IRequest<List_EquipmentVm>
        {
            public int ID_Order { get; set; }
        }
    }
}
