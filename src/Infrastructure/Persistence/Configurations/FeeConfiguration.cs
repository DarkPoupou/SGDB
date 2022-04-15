using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;
public class FeeConfiguration : IEntityTypeConfiguration<Fee>
{
    public void Configure(EntityTypeBuilder<Fee> builder)
    {
        builder
            .HasOne(f => f.Depot1)
            .WithMany(d => d.Depot1)
            .HasForeignKey(f => f.Depot1Id);
        builder
            .HasOne(f => f.Depot2)
            .WithMany(d => d.Depot2)
            .HasForeignKey(f => f.Depot2Id);

        builder.HasIndex(f => new { f.Depot1Id, f.Depot2Id }).IsUnique();
    }
}
