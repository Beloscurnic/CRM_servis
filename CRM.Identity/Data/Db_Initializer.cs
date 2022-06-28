using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(Identity_Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}
