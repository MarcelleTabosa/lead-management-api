using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infrastructure.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");
        builder.Property(j => j.Description).IsRequired().HasMaxLength(200);
        builder.Property(j => j.Suburb).IsRequired().HasMaxLength(200);
        builder.Property(j => j.Price).IsRequired();
        builder.Property(j => j.JobCategoryId).IsRequired();
        builder.Property(j => j.LeadId).IsRequired();
        builder.HasOne(j => j.Lead).WithMany(l => l.Jobs).HasForeignKey(j => j.LeadId).IsRequired();
        builder.HasOne(j => j.JobCategory).WithMany(c => c.Jobs).HasForeignKey(j => j.JobCategoryId).IsRequired();
    }
}