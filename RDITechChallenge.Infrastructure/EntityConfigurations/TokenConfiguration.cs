using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Infrastructure.EntityConfigurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(p => p.TokenId);
            builder.Property(p => p.TokenId).ValueGeneratedOnAdd();
        }
    }
}
