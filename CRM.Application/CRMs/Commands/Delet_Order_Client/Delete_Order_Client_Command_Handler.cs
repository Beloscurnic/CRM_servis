using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRM.Application.Interfaces;
using CRM.Application.Common.Exceptions;
using CRM.Domain;

namespace CRM.Application.CRMs.Commands.Delet_Order_Client
{
    public class Delete_Order_Client_Command_Handler
        : IRequestHandler<Delete_Order_Client_Command>
    {
        private readonly ICRM_DbContext _DbContext;

        public Delete_Order_Client_Command_Handler(ICRM_DbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(Delete_Order_Client_Command request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Order_Clients
                 .FindAsync(new object[] { request.ID_Order }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order_Client), request.ID_Order);
            }
            _DbContext.Order_Clients.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
