using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Type
{
    public partial class Get_Type_Accessories
    {
        public class Query: IRequest<Type_AccessoriesVm>
        {
            public int ID_Accessories { get; set; }
        }
    }
}
