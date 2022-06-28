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

namespace CRM.Application.CRMs.Queries.Get_List_Equipment
{
    public partial class Get_List_Equipment
    {
        public class Handler : IRequestHandler<Query, List_EquipmentVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);

            public async Task<List_EquipmentVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Equipments
               .Where(u => u.ID_Order == request.ID_Order)
               .ProjectTo<List_Equipment>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
                return new List_EquipmentVm { List_Equipments = entity };
            }
        }
    }
}
