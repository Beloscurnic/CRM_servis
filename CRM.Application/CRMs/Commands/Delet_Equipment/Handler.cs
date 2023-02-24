using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRM.Application.Interfaces;
using CRM.Application.Common.Exceptions;
using CRM.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRMs.Commands.Delet_Equipment
{
    public partial class Delet_Equipment
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _DbContext;

            public Handler(ICRM_DbContext dbContext) =>
                _DbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var price_Сomponent = _DbContext.Accessoriess
                       .Where(p => p.ID_Accessories == request.ID_Accessories)
                       .Select(c => c.Price_Сomponent)
                       .FirstOrDefault();

                var entity = await _DbContext.Equipments
                .FirstOrDefaultAsync(provider => provider.ID_Accessories == request.ID_Accessories && provider.ID_Order == request.ID_Order, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.ID_Accessories);
                }
                _DbContext.Equipments.Remove(entity);
                await _DbContext.SaveChangesAsync(cancellationToken);



                var entity2 = await _DbContext.Accessoriess
                .FirstOrDefaultAsync(provider => provider.ID_Accessories == request.ID_Accessories, cancellationToken);
                entity2.Quantity_Сomponent +=1;
                await _DbContext.SaveChangesAsync(cancellationToken);

                var entity3 = await _DbContext.Order_Clients
                .FirstOrDefaultAsync(provider => provider.ID_Order == request.ID_Order, cancellationToken);
                entity3.Price -= price_Сomponent;
                await _DbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }

}
