using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Infrastructure.EntityConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(p => p.CardId);
            builder.Property(p => p.CardId).ValueGeneratedOnAdd();
            builder.Property(p => p.CardId).HasMaxLength(16).IsRequired();
            builder.Property(p => p.CVV).HasMaxLength(5).IsRequired();
        }
    }
}
