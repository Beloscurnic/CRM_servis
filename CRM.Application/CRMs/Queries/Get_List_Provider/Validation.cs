using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Provider
{
    public partial class Get_Provider
    {
       public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
               
            }
        }
    }
}
