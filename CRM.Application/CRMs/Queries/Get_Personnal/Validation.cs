using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Personnal
{
    public partial class Get_Personnal
    {
      public class Validation: AbstractValidator<Query>
        {
            public Validation()
            {
                   RuleFor(Validation => Validation.ID_Personnal).NotEqual(Guid.Empty);
            }
        }
    }
}
