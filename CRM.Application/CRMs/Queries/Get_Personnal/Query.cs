using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Personnal
{
    public partial class Get_Personnal
    {
        public class Query: IRequest<PersonnalVm>
        {
            public Guid ID_Personnal { get; set; }
        }
    }
}
