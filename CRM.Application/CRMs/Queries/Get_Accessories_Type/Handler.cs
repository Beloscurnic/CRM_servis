﻿using System;
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

namespace CRM.Application.CRMs.Queries.Get_Accessories_Type
{
    public partial class Get_Type_Accessories
    {
        public class Handler : IRequestHandler<Query, Type_AccessoriesVm>
        {
            private readonly ICRM_DbContext _DbContext;
            private readonly IMapper _mapper;
            public Handler(ICRM_DbContext dbContext, IMapper mapper) =>
                (_DbContext, _mapper) = (dbContext, mapper);
            public async Task<Type_AccessoriesVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Accessoriess
                     .FirstOrDefaultAsync(personnal => personnal.ID_Accessories == request.ID_Accessories, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.ID_Accessories);
                }
                return _mapper.Map<Type_AccessoriesVm>(entity);
            }
        }
    }
}