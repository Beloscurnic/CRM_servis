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

namespace CRM.Application.CRMs.Queries.Get_Provider
{
    public partial class Get_Provider2
    {
        public class Handler : IRequestHandler<Query, ProviderVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<ProviderVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Providers
                     .FirstOrDefaultAsync(personnal => personnal.Name_Company == request.Name_Company, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Personnel_Data), request.Name_Company);
                }
                return _mapper.Map<ProviderVm>(entity);
            }
        }
    }
}
