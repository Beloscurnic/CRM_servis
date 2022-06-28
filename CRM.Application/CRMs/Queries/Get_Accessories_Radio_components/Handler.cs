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

namespace CRM.Application.CRMs.Queries.Get_Accessories_Radio_components
{
    public partial class Get_Accessories_Radio_components
    {
        public class Handler : IRequestHandler<Query, Radio_componentsVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<Radio_componentsVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var id_component = _DbContext.Accessoriess
                         .Where(p => p.ID_Accessories == request.ID_Accessories)
                         .Select(c => c.ID_Сomponent)
                         .FirstOrDefault();

                var entity = await _DbContext.Radio_components
                     .FirstOrDefaultAsync(entity => entity.ID_Сomponent == id_component, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.ID_Accessories);
                }
                return _mapper.Map<Radio_componentsVm>(entity);
            }
        }
    }
}
