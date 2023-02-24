using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain;
using CRM.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRM.Test.Common
{
   public class CRM_Context_Factory
    {
        public static Guid Perssonal_1_ID = Guid.NewGuid();
        public static Guid Perssonal_2_ID = Guid.NewGuid();

        public static Guid OrderId_Delet = Guid.NewGuid();
        public static Guid OrderId_Update = Guid.NewGuid();

        public static CRM_DbContext Create()
        {
            var options = new DbContextOptionsBuilder<CRM_DbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CRM_DbContext(options);
            context.Database.EnsureCreated();
            context.Order_Clients.AddRange(
                new Order_Client
                {
                     ID_Order = 1,
                     ID_Client = Guid.Parse("ab123880-4623-412e-a1ff-ccf603acb24e"),
                    ID_Personnel_dispatcher = Perssonal_1_ID,
                     Name_Client ="Dan1",
                     LastName_Client="Beloscurnic1",
                     Email_Client ="fewwrtr@mail.ru",
                     Telefon ="45834897",
                     Type_technology ="Планшет",
                     Model_technology ="Laptop HP",
                     Breaking_info ="",
                    // Quipment_info ="",
                     Status_Order="Диагностика",

                     Receipt_date = DateTime.Today,
                     Issue_date =null, 
                     Price =2001 
                },
                new Order_Client
                {
                  ID_Order =2,
                  ID_Client = Guid.Parse("0bda8748-01cd-4651-883b-a3407deb04fd"),
                    ID_Personnel_dispatcher = Perssonal_2_ID,
                  Name_Client = "Dan1",
                  LastName_Client = "Beloscurnic1",
                  Email_Client = "fewwrtr@mail.ru",
                  Telefon = "45834897",
                  Type_technology = "Планшет",
                  Model_technology = "Laptop HP",
                  Breaking_info = "",
             //     Quipment_info = "",
                  Status_Order = "Диагностика",

                  Receipt_date = DateTime.Today,
                  Issue_date = null,
                  Price = 2001
                },
                new Order_Client
                {
                    ID_Order = 3,
                    ID_Client = Guid.Parse("dfb80e5f-5d26-4bee-8a03-f7a12a92a5fd"),
                    ID_Personnel_dispatcher = Perssonal_1_ID,
                    Name_Client = "Dan1",
                    LastName_Client = "Beloscurnic1",
                    Email_Client = "fewwrtr@mail.ru",
                    Telefon = "45834897",
                    Type_technology = "Планшет",
                    Model_technology = "Laptop HP",
                    Breaking_info = "",
                  //  Quipment_info = "",
                    Status_Order = "Диагностика",

                    Receipt_date = DateTime.Today,
                    Issue_date = null,
                    Price = 2001
                }
                );
            context.SaveChanges();
            return context;
        }
        public static void Destroy(CRM_DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
