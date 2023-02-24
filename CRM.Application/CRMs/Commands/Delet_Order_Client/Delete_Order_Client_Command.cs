using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Delet_Order_Client
{
   public class Delete_Order_Client_Command: IRequest
    {
        public int ID_Order { get; set; }
    }
}
