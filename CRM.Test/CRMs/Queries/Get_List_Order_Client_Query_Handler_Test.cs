using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.CRMs.Queries.Get_List_Order_Client;
using CRM.Persistence;
using CRM.Test.Common;
using System.Threading;
using Xunit;
using Shouldly;

namespace CRM.Test.CRMs.Queries
{
    [Collection("QueryRequests")]
    public class Get_List_Order_Client_Query_Handler_Test
    {
        public CRM_DbContext Dbcontext;
        public IMapper Mapper;

        public Get_List_Order_Client_Query_Handler_Test(Query_Test_Mapper test_Mapper)
        {
            Dbcontext = test_Mapper.dbcontext;
            Mapper = test_Mapper.mapper;
        }

        [Fact]
        public async Task Get_List_Order_Client_Query_Handler_Ok()
        {
            var hendler = new Get_List_Order_Client_Query_Handler(Dbcontext,Mapper);

            var result = await hendler.Handle(
               new Get_List_Order_Client_Query
               {
                   ID_Personnel_dispatcher = CRM_Context_Factory.Perssonal_1_ID
               }, CancellationToken.None);
            result.ShouldBeOfType<List_Order_ClientVm>();
            result.Orders.Count.ShouldBe(3);
        }
    }
}
