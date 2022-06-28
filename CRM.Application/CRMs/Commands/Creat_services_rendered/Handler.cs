using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRMs.Commands.Creat_services_rendered
{
    public partial class Creat_services
    {
       public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
              
                var service_rendered = new Services_rendered
                    {
                     ID_Order=request.ID_Order,
                     Name=request.Name,
                     Description=request.Description,
                     Price_services=request.Price_services,
                     Warranty=request.Warranty
                };
                await _dbContext.Services_Rendereds.AddAsync(service_rendered, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var entity2 = await _dbContext.Order_Clients
                 .FirstOrDefaultAsync(provider => provider.ID_Order == request.ID_Order, cancellationToken);
                entity2.Price += request.Price_services;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return service_rendered.ID_Services;
            }
        }
    }
}
