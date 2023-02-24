using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Commands.Update_Ored_Client
{
   public class Update_Order_Client_Command: IRequest
    {
        public int ID_Order { get; set; }
        public string Status_Order { get; set; }
      
    }
}
