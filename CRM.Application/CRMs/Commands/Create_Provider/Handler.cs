using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Create_Provider
{
    public partial class Create_Provider
    {
       public class Handler:IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
             
                var provider = _dbContext.Providers
                         .Where(p=>p.Identification_Number ==request.Identification_Number)
                         .Select(c => c.ID_Provider)
                         .FirstOrDefault();
                if (provider != null)
                {
                    var providerinfo = new Provider
                    {
                        Name_Company = request.Name_Company,
                        Identification_Number = request.Identification_Number,
                        Supplier_Address = request.Supplier_Address,
                        FIO_Director = request.FIO_Director,
                        Telefon=request.Telefon,
                        Status = request.Status,
                        Comments = request.Comments
                    };
                    await _dbContext.Providers.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return providerinfo.ID_Provider;
                }
                else return 0;
            }
       }
    }
}
