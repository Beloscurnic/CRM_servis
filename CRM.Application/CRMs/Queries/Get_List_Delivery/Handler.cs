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

namespace CRM.Application.CRMs.Queries.Get_List_Delivery
{
    public partial class Get_List_Delivery
    {
        public class Handler : IRequestHandler<Query, List_DeliveryVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_DeliveryVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Deliverys
               .ProjectTo<List_Delivery>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
                return new List_DeliveryVm { List_Deliverys = entity };
            }
        }
    }
}
