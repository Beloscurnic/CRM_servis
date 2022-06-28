using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace CRM.Application.CRMs.Commands.Create_Provider
{
    public partial class Create_Provider
    {
       public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(create => create.FIO_Director).MaximumLength(255);
            }
        }
    }
}
