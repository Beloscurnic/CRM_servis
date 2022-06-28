using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRM.Application.CRMs.Queries.Get_Provider.Get_Provider;

namespace CRM.Application.CRMs.Queries.Get_Provider
{
   public class List_ProviderVm
    {
        public IList<List_Provider> List_Providers { get; set; }
    }
}
