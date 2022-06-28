using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_Services
{
    public partial class Get_List_services
    {
        public class Query : IRequest<List_ServicesVm>
        {

        }
    }
}
