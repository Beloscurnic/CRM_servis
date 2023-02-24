using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Radio_components
{
    public partial class Get_Accessories_Radio_components
    {
        public class Query : IRequest<Radio_componentsVm>
        {
            public int ID_Accessories { get; set; }
           
        }
    }
}
