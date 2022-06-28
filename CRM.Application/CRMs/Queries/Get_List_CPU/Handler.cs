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

namespace CRM.Application.CRMs.Queries.Get_List_CPU
{
    public partial class Get_List_CPU
    {
        public class Handler : IRequestHandler<Query, List_CPUVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_CPUVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Central_processings
               .ProjectTo<List_CPU>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
                return new List_CPUVm { List_CPUs = entity };
            }
        }
    }
}
