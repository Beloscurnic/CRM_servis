using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;


namespace CRM.Application.CRMs.Commands.Update_status_order
{
    public partial class Update_status
    {
       public class Command : IRequest
        {
            public int ID_Order { get; set; }
        }
    }
}
