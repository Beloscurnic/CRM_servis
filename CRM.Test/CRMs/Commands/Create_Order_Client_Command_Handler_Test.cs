using CRM.Test.Common;
using System;
using System.Threading;
using CRM.Application.CRMs.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CRM.Application.CRMs.Commands.Create_Order;
using Microsoft.EntityFrameworkCore;

namespace CRM.Test.CRMs.Commands
{
    public class Create_Order_Client_Command_Handler_Test: Test_Command_Base
    {
        [Fact]
        public async Task Create_Order_Client_Command_Handler_OK()
        {
            var handler = new Create_Order_Client_Command_Handler(DbContext);
            Guid id_client = Guid.Parse("f0c36cfb-58e2-4777-b6db-f6cdde1efa9c");
            
            var name_client = "Dan_Creat";
            var lastName_client = "Beloscurnic_Creat";
            var email_client = "wegwfrw@mail.ru";
            var telefon = "45634652";
            var type_technology = "Планшет";
            var model_technology = "ewtwtre";
            var breaking_info = "";
          
            var status_order = "Диагностика";

            var OrderId = await handler.Handle(
                new Create_Order_Client_Command
                {
                    ID_Personnel_dispatcher = CRM_Context_Factory.Perssonal_1_ID,
                    ID_Client = id_client,
                    Name_Client = name_client,
                    LastName_Client=lastName_client,
                    Email_Client =email_client,
                    Telefon=telefon,
                    Type_technology=type_technology,
                    Model_technology=model_technology,
                    Breaking_info=breaking_info,
                 
                    Status_Order=status_order
                },
                  CancellationToken.None);
            Assert.NotNull(
                await DbContext.Order_Clients.SingleOrDefaultAsync(order =>
                order.ID_Client == OrderId && order.Name_Client==name_client && order.LastName_Client==lastName_client));

    }
    }
}
