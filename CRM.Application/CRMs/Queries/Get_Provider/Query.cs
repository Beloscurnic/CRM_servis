using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.Application.CRMs.Queries.Get_Provider
{
    public partial class Get_Provider2
    {
        public class Query : IRequest<ProviderVm>
        {
            public string Name_Company { get; set; }
        }
    }
}
