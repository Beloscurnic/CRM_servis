using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CRM.Application.CRMs.Commands.Delet_Order_Client
{
  public  class Delete_Order_Client_Command_Validation: AbstractValidator<Delete_Order_Client_Command>
    {
        public Delete_Order_Client_Command_Validation()
        {
         
        }
    }
}
