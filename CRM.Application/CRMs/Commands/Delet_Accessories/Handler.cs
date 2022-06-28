using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRM.Application.Interfaces;
using CRM.Application.Common.Exceptions;
using CRM.Domain;

namespace CRM.Application.CRMs.Commands.Delet_Accessories
{
    public partial class Delet_Accessories
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _DbContext;

            public Handler(ICRM_DbContext dbContext) =>
                _DbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Accessoriess
                     .FindAsync(new object[] { request.ID_Accessories }, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.ID_Accessories);
                }
                _DbContext.Accessoriess.Remove(entity);
                await _DbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }

}
