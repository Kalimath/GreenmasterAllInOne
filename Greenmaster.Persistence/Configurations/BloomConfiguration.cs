using Greenmaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Greenmaster.Persistence.Configurations;

public class BloomConfiguration : IEntityTypeConfiguration<Bloom>
{
    public void Configure(EntityTypeBuilder<Bloom> builder)
    {
        builder.Property(b => b.Period)
            .IsRequired()
            .HasMaxLength(100);
    }
}