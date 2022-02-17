using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.Domain;
using MediatR;
using CRM.Application.Interfaces;

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
            var order = new Order_Client
            {

                ID_Client = request.ID_Client,
                Name_Client = request.Name_Client,
                LastName_Client = request.LastName_Client,
                Email_Client = request.Email_Client,
                Type_technology = request.Type_technology,
                Model_technology = request.Model_technology,
                ID_Order = Guid.NewGuid(),
                Receipt_date = DateTime.Now,
                Issue_date = null
            };
            await _dbContext.Order_Clients.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.ID_Client;
        }
    }
}
