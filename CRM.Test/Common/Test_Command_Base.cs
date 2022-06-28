using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Persistence;

namespace CRM.Test.Common
{
   public abstract class Test_Command_Base: IDisposable
    {
        protected readonly CRM_DbContext DbContext;

        public Test_Command_Base()
        {
            DbContext = CRM_Context_Factory.Create();
        }
        public void Dispose()
        {
            CRM_Context_Factory.Destroy(DbContext);
        }
    }
}
