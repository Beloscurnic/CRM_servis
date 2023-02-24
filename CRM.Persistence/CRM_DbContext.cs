
using Microsoft.EntityFrameworkCore;
using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Persistence.Entity_Type_Configurations;
namespace CRM.Persistence
{
   public class CRM_DbContext: DbContext, ICRM_DbContext
    {
      //  public DbSet<Personnel_Data> Personnel_Datas { get; set; }

        public DbSet<Order_Client> Order_Clients { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Accessories> Accessoriess { get; set; }
        public DbSet<Personnel_Data> Personnel_Datas { get; set; }
        public DbSet<Central_processing> Central_processings { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
        public DbSet<Services_rendered> Services_Rendereds { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Random_Access_Memory> Random_Access_Memorys { get; set; }
        public DbSet<Radio_component> Radio_components { get; set; }
        public CRM_DbContext(DbContextOptions<CRM_DbContext> options) 
            : base(options) { }
        //метод вызывается платформой при первом создании контекста для построения модели и ее отображений в памяти определеные в ModelBuilder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CRM_Configuration());
            builder.ApplyConfiguration(new Personall_Configuration());
            builder.ApplyConfiguration(new Equipment_Configuration());
            base.OnModelCreating(builder);
        }
    }
}
