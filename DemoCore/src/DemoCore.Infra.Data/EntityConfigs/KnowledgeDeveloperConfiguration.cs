using DemoCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCore.Infra.Data.EntityConfigs
{
    public class KnowledgeDeveloperConfiguration : IEntityTypeConfiguration<KnowledgeDeveloper>
    {
        public void Configure(EntityTypeBuilder<KnowledgeDeveloper> builder)
        {
            builder.HasKey(x => new { x.KnowledgeId, x.DeveloperId });

            //builder.HasAlternateKey(x => x.DeveloperId);
            //builder.HasAlternateKey(x => x.KnowledgeId);
            
            builder.Property(x => x.DeveloperId).IsRequired();
            builder.Property(x => x.KnowledgeId).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Knowledge);
            builder.HasOne(x => x.Developer);
        }
    }
}
