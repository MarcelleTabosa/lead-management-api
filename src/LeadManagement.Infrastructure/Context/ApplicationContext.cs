using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Lead> Leads { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    public DbSet<Job> Jobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=127.0.0.1,1433;Database=LeadManagementBD;User ID=sa;Password=Sql@2022;Trusted_Connection=False; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Lead>().Property("Name").IsRequired().HasMaxLength(100);
        model.Entity<Lead>().Property("Email").IsRequired().HasMaxLength(100);
        model.Entity<Lead>().Property("PhoneNumber").IsRequired().HasMaxLength(15);

        model.Entity<JobCategory>().Property("Category").IsRequired().HasMaxLength(20);

        model.Entity<Job>().Property("Description").IsRequired().HasMaxLength(200);
        model.Entity<Job>().Property("Suburb").IsRequired().HasMaxLength(200);
        model.Entity<Job>().Property("Price").IsRequired();
        model.Entity<Job>().Property("JobCategoryId").IsRequired();
        model.Entity<Job>().Property("LeadId").IsRequired();

    }
}
