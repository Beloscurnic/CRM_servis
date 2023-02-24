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

namespace CRM.Application.CRMs.Queries.Get_List_Services
{
    public partial class Get_List_services
    {
        public class Handler : IRequestHandler<Query, List_ServicesVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_ServicesVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Services_Rendereds
               .ProjectTo<List_Services>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
                return new List_ServicesVm { List_Servicess = entity };
            }
        }
    }
}
