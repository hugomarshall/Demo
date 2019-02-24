using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeConfiguration : BaseConfiguration<Knowledge>
    {
        public override void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();
            builder.Ignore(x => x.People);

            builder.HasAlternateKey(x => x.PeopleId);

            builder.Property(x => x.Other).HasColumnName("Other").HasColumnType("nvarchar(500)").HasMaxLength(500);
            
            
            
            base.Configure(builder);
        }
    }
}
