using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class OccupationConfiguration : BaseConfiguration<Occupation>
    {
        public override void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();
            builder.Ignore(x => x.People);

            builder.HasAlternateKey(x => x.PeopleId);

            builder.HasMany(x => x.BestWorkTimes);
            builder.HasMany(x => x.WorkAvailabilities);
            
        }
    }
}
