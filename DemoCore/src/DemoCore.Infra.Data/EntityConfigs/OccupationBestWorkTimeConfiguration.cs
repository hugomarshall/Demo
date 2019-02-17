using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class OccupationBestWorkTimeConfiguration : IEntityTypeConfiguration<OccupationBestWorkTime>
    {
        public void Configure(EntityTypeBuilder<OccupationBestWorkTime> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.BestWorkTimeId);
            builder.HasAlternateKey(x => x.OccupationId);

            builder.Property(x => x.BestWorkTimeId).IsRequired();
            builder.Property(x => x.OccupationId).IsRequired();

            builder.HasOne(x => x.Occupation).WithMany(x => x.BestWorkTimes).HasForeignKey(x=>x.BestWorkTimeId);
            builder.HasOne(x => x.BestWorkTime).WithMany(x=>x.Occupation).HasForeignKey(x=>x.OccupationId);
            
            
        }
    }
}
