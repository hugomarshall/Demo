﻿using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(x=>x.Id).ForSqlServerIsClustered();
            
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Skype).HasColumnName("Skype").HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnName("Celular").HasColumnType("nvarchar(15)").HasMaxLength(15).IsRequired();
            builder.Property(x => x.LinkedIn).HasColumnType("nvarchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(x => x.City).HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.State).HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Portfolio).HasColumnType("nvarchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDeveloper).HasColumnName("IsDeveloper").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsDesigner).HasColumnName("IsDesigner").IsRequired();
            

            builder.Property(x => x.DateCreated).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.DateLastUpdate).HasColumnName("LastUpdate").HasColumnType("datetime").ValueGeneratedOnUpdate();
            builder.Property(x => x.EntityState).HasColumnName("EntityState").HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Ignore(x => x.HasChanges);
            builder.Ignore(x => x.IsNew);
            builder.Ignore(x => x.IsValid);
            
            
            builder.HasOne(x => x.Occupation).WithOne(x=>x.People);
            builder.HasOne(x => x.Knowledge).WithOne(x=>x.People);
            
        }
    }
}
