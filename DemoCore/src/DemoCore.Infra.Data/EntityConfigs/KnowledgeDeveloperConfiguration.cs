using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeDeveloperConfiguration : IEntityTypeConfiguration<KnowledgeDeveloper>
    {
        public void Configure(EntityTypeBuilder<KnowledgeDeveloper> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.DeveloperId);
            builder.HasAlternateKey(x => x.KnowledgeId);

            builder.Property(x => x.DeveloperId).IsRequired();
            builder.Property(x => x.KnowledgeId).IsRequired();
            builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Developer).WithMany(x => x.Knowledge).HasForeignKey(x => x.DeveloperId);
            builder.HasOne(x => x.Knowledge).WithMany(x => x.KnowledgeDeveloper).HasForeignKey(x => x.KnowledgeId);
        }
    }
}
