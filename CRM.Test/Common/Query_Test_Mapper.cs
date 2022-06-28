using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Common.Mapping;
using CRM.Persistence;
using Xunit;
namespace CRM.Test.Common
{
    public class Query_Test_Mapper : IDisposable
    {
        public CRM_DbContext dbcontext;
        public IMapper mapper;
        public Query_Test_Mapper()
        {
            dbcontext = CRM_Context_Factory.Create();
            var configuration = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new AssemblyMappingProfile(typeof(ICRM_DbContext).Assembly));
            });
            mapper = configuration.CreateMapper();
        }
        public void Dispose()
        {
            CRM_Context_Factory.Destroy(dbcontext);
        }
        [CollectionDefinition("QueryRequests")]
        public class QueryRequests: ICollectionFixture<Query_Test_Mapper>
        {

        }
    }
}
