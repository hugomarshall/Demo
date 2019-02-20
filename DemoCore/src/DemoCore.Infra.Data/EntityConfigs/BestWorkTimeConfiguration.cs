using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class BestWorkTimeConfiguration : BaseConfiguration<BestWorkTime>
    {
        public override void Configure(EntityTypeBuilder<BestWorkTime> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();


            builder.Property(x => x.DescriptionEN).HasColumnName("DescriptionEN").HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.DescriptionPT).HasColumnName("DescriptionPT").HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.EntityState).HasColumnName("EntityState").HasColumnType("integer").IsRequired();
            builder.Property(x => x.DateCreated).HasColumnName("Created").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DateLastUpdate).HasColumnName("LastUpdate").HasColumnType("datetime");

            base.Configure(builder);
        }
    }
}
