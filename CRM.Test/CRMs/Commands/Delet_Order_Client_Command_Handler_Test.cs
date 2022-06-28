using CRM.Test.Common;
using System;
using System.Threading;
using CRM.Application.CRMs.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CRM.Application.CRMs.Commands.Delet_Order_Client;
using Microsoft.EntityFrameworkCore;
using CRM.Application.Common.Exceptions;

namespace CRM.Test.CRMs.Commands
{
    public class Delet_Order_Client_Command_Handler_Test:Test_Command_Base
    {
        [Fact]
        public async Task Delete_Order_Client_Command_Handler_OK()
        {
            var handler = new Delete_Order_Client_Command_Handler(DbContext);

            await handler.Handle(new Delete_Order_Client_Command
            {
                ID_Order= 1
            }, CancellationToken.None);

            Assert.Null(DbContext.Order_Clients.SingleOrDefault(order =>
            order.ID_Order == 1));
        }

        [Fact]
        public async Task Delete_Order_Client_Command_Handler_IdOrder()
        {
            var handler = new Delete_Order_Client_Command_Handler(DbContext);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new Delete_Order_Client_Command
                    {
                        ID_Order =10
                    }, CancellationToken.None));
        }
    }
}
