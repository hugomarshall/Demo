using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class OccupationWorkAvailabilityConfiguration : IEntityTypeConfiguration<OccupationWorkAvailability>
    {
        public void Configure(EntityTypeBuilder<OccupationWorkAvailability> builder)
        {
            builder.HasKey(x => new { x.OccupationId, x.WorkAvailabilityId });
            //builder.HasAlternateKey(x => x.OccupationId);
            //builder.HasAlternateKey(x => x.WorkAvailabilityId);
            builder.Property(x => x.WorkAvailabilityId).IsRequired();
            builder.Property(x => x.OccupationId).IsRequired();

            builder.HasOne(x => x.Occupation);
            builder.HasOne(x => x.WorkAvailability);
        }
    }
}
