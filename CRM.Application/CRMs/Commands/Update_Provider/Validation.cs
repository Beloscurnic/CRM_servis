
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Commands.Update_Provider
{
    public partial class Update_Provider
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                //RuleFor(create_Order_Coomand => create_Order_Coomand.ID_Order).NotEqual(Guid.Empty);
                RuleFor(update => update.Status).NotEmpty().MaximumLength(255);
            }
        }
    }
}
