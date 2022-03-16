using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using CRM.Application.CRMs.Queries.Get_List_Order_Client_Details;
using CRM.Persistence;
using CRM.Test.Common;
using CRM.Application.CRMs.Queries.Get_List_Order_Client;
using CRM.Application.CRMs.Queries.Get_Order_Client_Details;

namespace CRM.Test.CRMs.Queries
{
    [Collection("QueryRequests")]
    public class Get_Order_Client_Query_Handler_Test
    {
        private readonly CRM_DbContext DbContext;
        private readonly IMapper Mapper;

        public Get_Order_Client_Query_Handler_Test(Query_Test_Mapper test_mapper)
        {
            DbContext = test_mapper.dbcontext;
            Mapper = test_mapper.mapper;
        }
        [Fact]
        public async Task Get_Order_Client_Details_Query_Handler_Ok()
        {
            var handler = new Get_Order_Client_Query_Handler(DbContext, Mapper);

            var result = await handler.Handle(
                new Get_Order_Client_Details_Query
                {
                    ID_Order = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825")
                }, CancellationToken.None);

            result.ShouldBeOfType<Order_Client_DetailsVm>();
            result.Name_Client.ShouldBe("Dan1");
            result.Receipt_date.ShouldBe(DateTime.Today);
        }
    }
}
