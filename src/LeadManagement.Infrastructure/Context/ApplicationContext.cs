using LeadManagement.Domain.Entities;
using LeadManagement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Lead> Leads { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<Job> Jobs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LeadConfiguration());
        modelBuilder.ApplyConfiguration(new JobCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new JobConfiguration());
    }
}
