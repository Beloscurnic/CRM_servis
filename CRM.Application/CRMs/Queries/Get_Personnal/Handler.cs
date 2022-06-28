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

namespace CRM.Application.CRMs.Queries.Get_Personnal
{
    public partial class Get_Personnal
    {
        public class Handler : IRequestHandler<Query, PersonnalVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<PersonnalVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Personnel_Datas
                     .FirstOrDefaultAsync(personnal => personnal.ID_Personnal == request.ID_Personnal, cancellationToken);
                if(entity ==null)
                {
                    throw new NotFoundException(nameof(Personnel_Data), request.ID_Personnal);
                }
                return _mapper.Map<PersonnalVm>(entity);
            }
        }
    }
}
