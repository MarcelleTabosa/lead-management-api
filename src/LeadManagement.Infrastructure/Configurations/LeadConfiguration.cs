using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infrastructure.Configurations;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads");
        builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Email).IsRequired().HasMaxLength(100);
        builder.Property(l => l.PhoneNumber).IsRequired().HasMaxLength(15);
    }
}