using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Common.Exceptions;

using CRM.Test.Common;
using Xunit;
using CRM.Application.CRMs.Commands.Update_Ored_Client;

namespace CRM.Test.CRMs.Commands
{
    public class Update_Order_Client_Command_Handler_Test : Test_Command_Base
    {
        [Fact]
        public async Task Update_Order_Client_Command_Handler_Ok()
        {
            var handler = new Update_Order_Client_Command_Handler(DbContext);
            var status_order = "Сборка";

            await handler.Handle(new Update_Order_Client_Command
            {
                ID_Order = Guid.Parse("de0c8625-d2ec-4f58-8129-a3da9f90c4d1"),
                Status_Order = status_order
            }, CancellationToken.None);
            Assert.NotNull(await DbContext.Order_Clients.SingleOrDefaultAsync(order =>
            order.ID_Order == Guid.Parse("de0c8625-d2ec-4f58-8129-a3da9f90c4d1") && order.Status_Order == status_order));
        }

        [Fact]
        public async Task Update_Order_Client_Command_Handler_IdOrder()
        {
            var handler = new Update_Order_Client_Command_Handler(DbContext);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new Update_Order_Client_Command
                    {
                        ID_Order = Guid.NewGuid(),
                        Status_Order = "Обновление"
                    }, CancellationToken.None));
        }
    }
}
