using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Update_status_order
{
    public partial class Update_status
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
         _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                DateTime localDate = DateTime.Now;
                DateTime third = new DateTime(localDate.Year, localDate.Month, localDate.Day);
                var entity = await _dbContext.Order_Clients
                 .FirstOrDefaultAsync(order => order.ID_Order == request.ID_Order, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Order_Client), request.ID_Order);
                }
                entity.Issue_date = third;

                entity.Status_Order = "Выдано";
                // entity.Status_Order = request.Status_Order;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
