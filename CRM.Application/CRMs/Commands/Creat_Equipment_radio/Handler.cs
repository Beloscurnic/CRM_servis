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

namespace CRM.Application.CRMs.Commands.Creat_Equipment_radio
{
    public partial class Creat_Equipment_radio
    {
       public class Handler : IRequestHandler<Command, int>
        {
            private readonly ICRM_DbContext _dbContext;
            public Handler(ICRM_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<int> Handle(Command request,
          CancellationToken cancellationToken)
            {

                Guid ID_Equipment;
                ID_Equipment = Guid.NewGuid();

                var providerinfo = new Equipment
                {
                    ID_Equipment= ID_Equipment,
                    ID_Order=request.ID_Order,
                    ID_Accessories=0,
                    Name_Сomponent= request.Name_Сomponent,
                    Type_Сomponent= "Radio_component",
                    Price_Сomponent=0,
                    ID_Provider=1,
                    Name_Company="Склад"
                };

                    await _dbContext.Equipments.AddAsync(providerinfo, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);


                var entity2 = await _dbContext.Order_Clients
           .FirstOrDefaultAsync(provider => provider.ID_Order == request.ID_Order, cancellationToken);
                entity2.Price += 0;
                await _dbContext.SaveChangesAsync(cancellationToken);

                DateTime localDate = DateTime.Now;
                DateTime third = new DateTime(localDate.Year, localDate.Month, localDate.Day);
                var delivery = new Delivery
                {
                    ID_Accessories = 0,
                    ID_Сomponent = ID_Equipment,
                    Name_Сomponent = request.Name_Сomponent,
                    Type_Сomponent = "Radio_component",
                    Price_Сomponent = 0,
                    Quantity_Сomponent = request.quintity,
                    Summa =0,
                    Status="Экспорт",
                    Receipt_date=third,
                    ID_Provider = 1,
                    Name_Company = "Склад"
                };

                await _dbContext.Deliverys.AddAsync(delivery, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return request.ID_Order;
            }
        }
    }
}
