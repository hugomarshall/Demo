using DemoCore.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            
            builder.Property(x => x.DateCreated).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.DateLastUpdate).HasColumnName("LastUpdate").HasColumnType("datetime").ValueGeneratedOnUpdate();
            builder.Property(x => x.EntityState).HasColumnName("EntityState").HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Ignore(x => x.HasChanges);
            builder.Ignore(x => x.IsNew);
            builder.Ignore(x => x.IsValid);
        }
    }
}
