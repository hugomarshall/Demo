using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.HasAlternateKey(x => x.PeopleId);

            builder.Property(x => x.DateCreated).HasColumnName("Created").HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.DateLastUpdate).HasColumnName("LastUpdate").HasColumnType("datetime").ValueGeneratedOnUpdate();
            builder.Property(x => x.EntityState).HasColumnName("EntityState").HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Other).HasColumnName("Other").HasColumnType("nvarchar(500)").HasMaxLength(500);
            builder.Ignore(x => x.HasChanges);
            builder.Ignore(x => x.IsNew);
            builder.Ignore(x => x.IsValid);

            builder.HasOne(x => x.People).WithOne(x=>x.Knowledge);
            builder.HasMany(x => x.KnowledgeDesigner);
            builder.HasMany(x => x.KnowledgeDeveloper);
        }
    }
}
