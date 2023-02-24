using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CRM.Application.CRMs.Queries.Get_Order_Client_Details
{
    public class Get_Order_Client_Details_Query_Validation: AbstractValidator<Get_Order_Client_Details_Query>
    {
        public Get_Order_Client_Details_Query_Validation()
        {
         //   RuleFor(Get_Order_Details_Validatiom=> Get_Order_Details_Validatiom.ID_Order).NotEqual(int);
        }
    }
}
