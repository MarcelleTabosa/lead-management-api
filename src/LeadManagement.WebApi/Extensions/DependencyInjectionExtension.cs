using LeadManagement.Application.Interfaces.Services;
using LeadManagement.Application.Services;
using LeadManagement.Domain.Interfaces.Repositories;
using LeadManagement.Infrastructure.Context;
using LeadManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.WebApi.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        return services;
    }

    public static IServiceCollection AddARepository(this IServiceCollection services)
    {
        services.AddScoped<IJobCategoryService, JobCategoryService>();
        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        return services;
    }
}
