﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLayerProject.Data.Configurations
{
    class PersonConfiguration:IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(255);
            builder.ToTable("People");
        }
    }
}
