using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Update_Ored_Client
{
    public class Update_Order_Client_Command_Handler
        : IRequestHandler<Update_Order_Client_Command>
    {
        private readonly ICRM_DbContext _dbContext;

        public Update_Order_Client_Command_Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(Update_Order_Client_Command request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Order_Clients
                .FirstOrDefaultAsync(order => order.ID_Order == request.ID_Order, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order_Client), request.ID_Order);
            }
            entity.Status_Order = request.Status_Order;
     
            entity.Status_Order = request.Status_Order;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
