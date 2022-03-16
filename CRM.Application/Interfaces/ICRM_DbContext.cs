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

        //Асинхронно сохраняет все изменения, сделанные в этом контексте, в базовой базе данных.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
