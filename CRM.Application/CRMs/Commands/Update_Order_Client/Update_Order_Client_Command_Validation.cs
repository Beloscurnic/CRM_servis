using CRM.Application.CRMs.Commands.Update_Ored_Client;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Commands.Update_Order_Client
{
    public class Update_Order_Client_Command_Validation : AbstractValidator<Update_Order_Client_Command>
    {
        public Update_Order_Client_Command_Validation()
        {
            //RuleFor(create_Order_Coomand => create_Order_Coomand.ID_Order).NotEqual(Guid.Empty);
            RuleFor(create_Order_Coomand => create_Order_Coomand.Status_Order).NotEmpty().MaximumLength(255);
        }
    }
}
