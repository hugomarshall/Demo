using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeDesignerConfiguration : IEntityTypeConfiguration<KnowledgeDesigner>
    {
        public void Configure(EntityTypeBuilder<KnowledgeDesigner> builder)
        {
            builder.HasKey(x => new { x.KnowledgeId, x.DesignerId });

            //builder.HasAlternateKey(x => x.KnowledgeId);
            //builder.HasAlternateKey(x => x.DesignerId);
            builder.Property(x => x.DesignerId).IsRequired();
            builder.Property(x => x.KnowledgeId).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Knowledge);
            builder.HasOne(x => x.Designer);
        }
    }
}

