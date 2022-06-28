using System;
using System.Collections.Generic;
using System.Text;
using CRM.Application.CRMs.Queries.Get_List_Order_Client;
using MediatR;

namespace CRM.Application.CRMs.Queries.Get_List_Order_Master
{
    public class Get_List_Order_Master_Query : IRequest<List_Master_ClientVm>
    {
        public Guid ID_Personnel_master { get; set; }
    }
}
