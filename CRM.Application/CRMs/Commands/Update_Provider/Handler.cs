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
    public partial class Update_Provider
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
         _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Providers
               .FirstOrDefaultAsync(provider => provider.Name_Company == request.Name_Company, cancellationToken);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Provider), request.Name_Company);
                }
                entity.Status = request.Status;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
