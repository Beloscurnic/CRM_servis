using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Commands.Create_Accessories
{
    public partial class Create_CPU
    {
       public class Validation: AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(create => create.Name_Сomponent).MaximumLength(255);
            }
        }
    }
}
