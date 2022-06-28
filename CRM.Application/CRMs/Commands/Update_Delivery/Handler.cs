using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Update_Provider
{
    public partial class Update_Delivery
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
         _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Deliverys
               .FirstOrDefaultAsync(provider => provider.ID_Delevery == request.ID_Delevery, cancellationToken);
                string status = entity.Status;
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Provider), request.ID_Delevery);
                }
                entity.Status = "Закрыт";

                await _dbContext.SaveChangesAsync(cancellationToken);

                var entity2 = await _dbContext.Accessoriess
                .FirstOrDefaultAsync(provider => provider.ID_Accessories == entity.ID_Accessories, cancellationToken);
                if (status=="")
                entity2.Quantity_Сomponent += entity.Quantity_Сomponent;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
