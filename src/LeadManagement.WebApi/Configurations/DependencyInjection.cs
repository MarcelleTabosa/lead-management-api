using LeadManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.WebApi.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddARepository(this IServiceCollection services)
    {
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
