using System;
using MediatR;

namespace CRM.Application.CRMs.Queries.Get_Order_Client_Details
{
   public class Get_Order_Client_Details_Query : IRequest<Order_Client_DetailsVm>
    {
        public Guid ID_Order { get; set; }
     //   public string Email { get; set; }
    }

}
