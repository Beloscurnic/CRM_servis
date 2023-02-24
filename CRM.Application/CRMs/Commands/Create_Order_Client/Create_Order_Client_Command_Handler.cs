using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;
using System.Linq;

namespace CRM.Application.CRMs.Commands.Create_Order
{
  public  class Create_Order_Client_Command_Handler
        :IRequestHandler<Create_Order_Client_Command, Guid>
    {
        private readonly ICRM_DbContext _dbContext;
        public Create_Order_Client_Command_Handler(ICRM_DbContext dbContext) =>
             _dbContext = dbContext;
        public async Task <Guid> Handle(Create_Order_Client_Command request,
            CancellationToken cancellationToken)
        {
            Guid id_client;
            var client =  _dbContext.Order_Clients
                          .Where(p => p.Telefon == request.Telefon)
                          .Select(c => c.ID_Client)
                          .FirstOrDefault();

            if (client != null)
            {
                id_client = Guid.NewGuid();
                DateTime localDate = DateTime.Now;
                DateTime third = new DateTime(localDate.Year, localDate.Month, localDate.Day);

                var order = new Order_Client
                {

                    ID_Client = id_client,
                    Name_Client = request.Name_Client,
                    LastName_Client = request.LastName_Client,
                    Email_Client = request.Email_Client,
                    Telefon = request.Telefon,

                    Type_technology = request.Type_technology,
                    Model_technology = request.Model_technology,
                    Breaking_info = request.Breaking_info,

                    ID_Personnel_dispatcher = request.ID_Personnel_dispatcher,
                    ID_Personnel_master = request.ID_Personnel_master,
                    Status_Order = "Диагностика",
                    Receipt_date = third,
                    Issue_date = null,

                    Price = 0
                };
                await _dbContext.Order_Clients.AddAsync(order, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return order.ID_Client;
            } else return Guid.Empty; 
        }
    }
}
