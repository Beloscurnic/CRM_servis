using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Application.Common.Exceptions;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Update_Accessories
{
    public partial class Update_Accessories
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
         _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Accessoriess
               .FirstOrDefaultAsync(provider => provider.ID_Accessories == request.ID_Accessories, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Accessories), request.Сharacteristics_info);
                }
                entity.Сharacteristics_info = request.Сharacteristics_info;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
