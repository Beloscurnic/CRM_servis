using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Application.CRMs.Queries.Get_List_Order_Client;

namespace CRM.Application.CRMs.Queries.Get_List_Personnal
{
    public partial class Get_List_Personnal
    {
        public class Handler : IRequestHandler<Query, List_PersonnalVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<List_PersonnalVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Personnel_Datas
                   .ProjectTo<List_Personnal>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                return new List_PersonnalVm { List_Personnals = entity };
            }
        }
    }
    
}
