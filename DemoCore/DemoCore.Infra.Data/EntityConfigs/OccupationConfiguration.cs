using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class OccupationConfiguration : BaseConfiguration<Occupation>
    {
        public override void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.PeopleId);

            builder.HasOne(x => x.People).WithOne(x => x.Occupation);
            builder.HasMany(x => x.BestWorkTimes);
            builder.HasMany(x => x.WorkAvailabilities);
        }
    }
}
