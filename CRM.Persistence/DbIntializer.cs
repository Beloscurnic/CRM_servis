using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Persistence
{
    //проверяет если созжана база данных если нет то создает на основе CRM_Configuration
    public class DbIntializer
    {
        public static void Initialize (CRM_DbContext context)
        {
            //При вызове метода Database.EnsureCreated(), который создает БД при ее отсутствии
            context.Database.EnsureCreated();
        }
    }
}
