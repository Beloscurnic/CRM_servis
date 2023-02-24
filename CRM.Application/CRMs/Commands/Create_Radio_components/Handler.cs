﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Create_Radio_components
{
    public partial class Create_Radio_components
    {
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
               
                var provider = _dbContext.Accessoriess
                         .Where(p => p.ID_Accessories == request.ID_Accessories)
                         .Select(c => c.ID_Accessories)
                         .FirstOrDefault();
                var id_provider = _dbContext.Providers
                       .Where(p => p.Name_Company == request.Name_Company)
                       .Select(c => c.ID_Provider)
                       .FirstOrDefault();
                if (provider != null)
                {
                    Guid iD_Сomponent;
                    iD_Сomponent = Guid.NewGuid();
          
                    var providerinfo = new Accessories
                    {
                        ID_Сomponent = iD_Сomponent,
                        Type_Сomponent= "Radio_component",
                        Name_Сomponent=request.Name_Сomponent,
                        Сharacteristics_info="Активный",
                        Price_Сomponent=request.Price,
                        Name_Company=request.Name_Company,
                        ID_Provider=id_provider
                    };
                    
                    await _dbContext.Accessoriess.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return providerinfo.ID_Accessories;
                }
                else return 0;
            }
        }
    }
}
