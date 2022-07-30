using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(p => p.CustomerId).ValueGeneratedOnAdd();

            builder.HasData(new Customer
            {
                CustomerId = 1,
                Cards = { }
            });
        }
    }
}
