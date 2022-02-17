
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Persistence.Entity_Type_Configurations;
namespace CRM.Persistence
{
   public class CRM_DbContext: DbContext, ICRM_DbContext
    {
        public DbSet<Personnel_Data> Personnel_Datas { get; set; }
        public DbSet<Order_Client> Order_Clients { get; set; }

        public CRM_DbContext(DbContextOptions<CRM_DbContext> options) 
            : base(options) { }
        //метод вызывается платформой при первом создании контекста для построения модели и ее отображений в памяти определеные в ModelBuilder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CRM_Configuration());
            base.OnModelCreating(builder);
        }
    }
}
