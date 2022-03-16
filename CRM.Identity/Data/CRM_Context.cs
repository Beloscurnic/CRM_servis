using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Identity.Data
{
    public class CRM_Context : DbContext
    {
        public DbSet<Personnel_Data> Personnel_Datas { get; set; }
        public CRM_Context(DbContextOptions<CRM_Context> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
       
    }
}
