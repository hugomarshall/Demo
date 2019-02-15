using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeDesignerConfiguration : IEntityTypeConfiguration<KnowledgeDesigner>
    {
        public void Configure(EntityTypeBuilder<KnowledgeDesigner> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered();
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.DesignerId);
            builder.HasAlternateKey(x => x.KnowledgeId);

            builder.Property(x => x.DesignerId).IsRequired();
            builder.Property(x => x.KnowledgeId).IsRequired();
            builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Designer).WithMany(x => x.Knowledge).HasForeignKey(x => x.DesignerId);
            builder.HasOne(x => x.Knowledge).WithMany(x => x.KnowledgeDesigner).HasForeignKey(x => x.KnowledgeId);
        }
    }
}
