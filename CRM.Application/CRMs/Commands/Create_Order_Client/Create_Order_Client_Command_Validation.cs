using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.CRMs.Commands.Create_Order;
using FluentValidation;

namespace CRM.Application.CRMs.Commands.Create_Order_Client
{
   public class Create_Order_Client_Command_Validation: AbstractValidator<Create_Order_Client_Command>
    {
       public Create_Order_Client_Command_Validation()
        {
            RuleFor(create_Order_Coomand => create_Order_Coomand.ID_Client).NotEqual(Guid.Empty);
            RuleFor(create_Order_Coomand => create_Order_Coomand.ID_Personnel).NotEqual(Guid.Empty);
            RuleFor(create_Order_Coomand => create_Order_Coomand.Name_Client).MaximumLength(255);
            RuleFor(create_Order_Coomand => create_Order_Coomand.LastName_Client).MaximumLength(255);
            RuleFor(create_Order_Coomand => create_Order_Coomand.Model_technology).MaximumLength(255);
            RuleFor(create_Order_Coomand => create_Order_Coomand.Status_Order).MaximumLength(255);
        }
    }
}
