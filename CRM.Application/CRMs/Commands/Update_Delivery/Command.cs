using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;


namespace CRM.Application.CRMs.Commands.Update_Provider
{
    public partial class Update_Delivery
    {
       public class Command : IRequest
        {
            public int ID_Delevery { get; set; }
        }
    }
}
