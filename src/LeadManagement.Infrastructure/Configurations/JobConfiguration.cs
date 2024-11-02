using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infrastructure.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");
        builder.Property("Description").IsRequired().HasMaxLength(200);
        builder.Property("Suburb").IsRequired().HasMaxLength(200);
        builder.Property("Price").IsRequired();
        builder.Property("JobCategoryId").IsRequired();
        builder.Property("LeadId").IsRequired();

    }
}
