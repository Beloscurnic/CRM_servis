using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Persistence.Entity_Type_Configurations
{
    class CRM_Configuration: IEntityTypeConfiguration<Order_Client>
    {
        public void Configure (EntityTypeBuilder<Order_Client> builder)
        {
            builder.HasKey(person => person.ID_Order);
            builder.HasIndex(person => person.ID_Order).IsUnique();
            builder.Property(person => person.Name_Client).HasMaxLength(20);
        }
    }
}
