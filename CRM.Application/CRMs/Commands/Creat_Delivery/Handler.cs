using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Common.Exceptions;

namespace CRM.Application.CRMs.Commands.Creat_Delivery
{
    public partial class Create_Delivery
    {
       public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
                var provider = _dbContext.Deliverys
                         .Where(p => p.ID_Accessories == request.ID_Accessories)
                         .Select(c => c.ID_Accessories)
                         .FirstOrDefault();
                var id_provider = _dbContext.Providers
                       .Where(p => p.Name_Company == request.Name_Company)
                       .Select(c => c.ID_Provider)
                       .FirstOrDefault();

                    //Guid iD_Сomponent;
                    //iD_Сomponent = Guid.NewGuid();

                    DateTime localDate = DateTime.Now;
                    DateTime third = new DateTime(localDate.Year, localDate.Month, localDate.Day);


                var providerinfo = new Delivery
                    {
                        ID_Accessories= request.ID_Accessories,
                        ID_Сomponent= request.ID_Сomponent,

                        Type_Сomponent = request.Type_Сomponent,
                        Name_Сomponent = request.Name_Сomponent,
                        Price_Сomponent = request.Price_Сomponent,
                        Quantity_Сomponent=request.Quantity_Сomponent,
                        Summa= request.Price_Сomponent*request.Quantity_Сomponent,
                        Status ="Импорт",
                        Receipt_date= third,
                        Issue_date = request.Issue_date,
                        Name_Company = request.Name_Company,
                        ID_Provider = id_provider
                    };
                    await _dbContext.Deliverys.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

               
                return providerinfo.ID_Accessories;

            }
        }
    }
}
