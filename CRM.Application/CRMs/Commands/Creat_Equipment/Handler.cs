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

namespace CRM.Application.CRMs.Commands.Creat_Equipment
{
    public partial class Create_Equipment
    {
       public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {
                var accessories = _dbContext.Accessoriess
                        .Where(p => p.ID_Accessories == request.ID_Accessories)
                        .FirstOrDefault();
                var provider = _dbContext.Providers
                       .Where(p => p.Name_Company == request.Name_Company)
                       .FirstOrDefault();

                Guid ID_Equipment;
                ID_Equipment = Guid.NewGuid();

                var providerinfo = new Equipment
                {
                    ID_Equipment= ID_Equipment,
                    ID_Order=request.ID_Order,
                    ID_Accessories=request.ID_Accessories,
                    Name_Сomponent= accessories.Name_Сomponent,
                    Type_Сomponent=accessories.Type_Сomponent,
                    Price_Сomponent=accessories.Price_Сomponent,
                    ID_Provider=provider.ID_Provider,
                    Name_Company=request.Name_Company
                };

                    await _dbContext.Equipments.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                var entity = await _dbContext.Accessoriess
              .FirstOrDefaultAsync(provider => provider.ID_Accessories == request.ID_Accessories, cancellationToken);
                entity.Quantity_Сomponent -= 1;
                await _dbContext.SaveChangesAsync(cancellationToken);

                var entity2 = await _dbContext.Order_Clients
           .FirstOrDefaultAsync(provider => provider.ID_Order == request.ID_Order, cancellationToken);
                entity2.Price += accessories.Price_Сomponent;
                await _dbContext.SaveChangesAsync(cancellationToken);

                DateTime localDate = DateTime.Now;
                DateTime third = new DateTime(localDate.Year, localDate.Month, localDate.Day);
                var delivery = new Delivery
                {
                    ID_Accessories = request.ID_Accessories,
                    ID_Сomponent = accessories.ID_Сomponent,
                    Name_Сomponent = accessories.Name_Сomponent,
                    Type_Сomponent = accessories.Type_Сomponent,
                    Price_Сomponent = accessories.Price_Сomponent,
                    Quantity_Сomponent = 1,
                    Summa = accessories.Price_Сomponent,
                    Status="Экспорт",
                    Receipt_date=third,
                    ID_Provider = provider.ID_Provider,
                    Name_Company = request.Name_Company
                };

                await _dbContext.Deliverys.AddAsync(delivery, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return providerinfo.ID_Accessories;
            }
        }
    }
}
