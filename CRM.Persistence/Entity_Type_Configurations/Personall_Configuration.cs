using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Persistence.Entity_Type_Configurations
{
   public  class Personall_Configuration : IEntityTypeConfiguration<Personnel_Data>
    {
        public void Configure(EntityTypeBuilder<Personnel_Data> builder)
        {
            builder.HasKey(person => person.ID_Personnal);
            builder.HasIndex(person => person.ID_Personnal).IsUnique();
            
        }

    }
}

