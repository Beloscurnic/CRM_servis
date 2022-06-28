using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Motherboard
{
    public partial class Get_Motherboard
    {
        public class Handler : IRequestHandler<Query, MotherboardVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<MotherboardVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var id_component = _DbContext.Accessoriess
                         .Where(p => p.ID_Accessories == request.ID_Accessories)
                         .Select(c => c.ID_Сomponent)
                         .FirstOrDefault();

                var entity = await _DbContext.Motherboards
                     .FirstOrDefaultAsync(entity => entity.ID_Сomponent == id_component, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.ID_Accessories);
                }
                return _mapper.Map<MotherboardVm>(entity);
            }
        }
    }
}
