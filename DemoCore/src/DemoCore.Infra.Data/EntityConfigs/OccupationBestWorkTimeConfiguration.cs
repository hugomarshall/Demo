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
            builder.HasKey(x => new { x.OccupationId, x.BestWorkTimeId });
            //builder.HasAlternateKey(x => x.OccupationId);
            //builder.HasAlternateKey(x => x.BestWorkTimeId);

            builder.Property(x => x.BestWorkTimeId).IsRequired();
            builder.Property(x => x.OccupationId).IsRequired();

            builder.HasOne(x => x.Occupation);
            builder.HasOne(x => x.BestWorkTime);
            
            
        }
    }
}
