using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRM.Application.Interfaces;
using CRM.Application.Common.Exceptions;
using CRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRMs.Commands.Delet_services
{
    public partial class Delet_Services
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _DbContext;

            public Handler(ICRM_DbContext dbContext) =>
                _DbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Services_Rendereds
                     .FindAsync(new object[] { request.ID_Services }, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Services_rendered), request.ID_Services);
                }
                _DbContext.Services_Rendereds.Remove(entity);
                await _DbContext.SaveChangesAsync(cancellationToken);

                var entity2 = await _DbContext.Order_Clients
           .FirstOrDefaultAsync(provider => provider.ID_Order == entity.ID_Order, cancellationToken);
                entity2.Price -= entity.Price_services;
                await _DbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

}
