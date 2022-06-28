using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CRM.Application.CRMs.Queries.Get_List_Order_Master
{
    public class Get_List_Order_Master_Query_Validation : AbstractValidator<Get_List_Order_Master_Query>
    {
        public Get_List_Order_Master_Query_Validation()
        {
            RuleFor(Get_Order_Details_Validatiom => Get_Order_Details_Validatiom.ID_Personnel_master).NotEqual(Guid.Empty);
        }
    }
}
