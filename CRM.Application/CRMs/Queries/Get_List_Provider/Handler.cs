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

namespace CRM.Application.CRMs.Queries.Get_Provider
{
    public partial class Get_Provider
    {
        public class Handler : IRequestHandler<Query, List_ProviderVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_ProviderVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Providers
                 .Where(p => p.Name_Company != "Склад")
                 .ProjectTo<List_Provider>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                return new List_ProviderVm { List_Providers = entity };
            }
        }
    }
}

