using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Accessories
{
    public partial class Get_Accessories_CPU
    {
        public class Query : IRequest<Accessories_CPUVm>
        {
            public int ID_Accessories { get; set; }
           
        }
    }
}
