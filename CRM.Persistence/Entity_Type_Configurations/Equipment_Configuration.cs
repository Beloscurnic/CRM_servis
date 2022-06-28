using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Persistence.Entity_Type_Configurations
{
    public class Equipment_Configuration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(equipment => equipment.ID_Equipment);
            builder.HasIndex(equipment => equipment.ID_Equipment).IsUnique();
        }

    }
}
