using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Interfaces
{
    public interface ICRM_DbContext
    {
      //  DbSet <Personnel_Data> Personnel_Datas { get; set; }
        DbSet<Order_Client> Order_Clients { get; set; }
        DbSet<Personnel_Data> Personnel_Datas { get; set; }
        DbSet<Equipment> Equipments { get; set; }
        DbSet<Provider> Providers { get; set; }
        DbSet<Accessories> Accessoriess { get; set; }
        DbSet<Central_processing> Central_processings { get; set; }
        DbSet<Delivery> Deliverys { get; set; }
        DbSet<Services_rendered> Services_Rendereds { get; set; }
        DbSet<Motherboard> Motherboards { get; set; }
        DbSet<Random_Access_Memory> Random_Access_Memorys { get; set; }
        DbSet<Radio_component>Radio_components { get; set; }
        //Асинхронно сохраняет все изменения, сделанные в этом контексте, в базовой базе данных.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
