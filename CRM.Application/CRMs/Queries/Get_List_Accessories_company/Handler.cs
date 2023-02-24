using CRM.Application.CRMs.Queries.Get_Provider;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;

namespace CRM.Application.CRMs.Queries.Get_List_Accessories_company
{
    public partial class Get_List_Accessories2
    {
        public class Handler : IRequestHandler<Query, List_Accessories2Vm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_Accessories2Vm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Accessoriess
               .Where(p => p.Name_Company == request.Name_Company)
               .ProjectTo<List_Accessories2>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
                return new List_Accessories2Vm { List_Accessories2s = entity };
            }
        }
    }
}
