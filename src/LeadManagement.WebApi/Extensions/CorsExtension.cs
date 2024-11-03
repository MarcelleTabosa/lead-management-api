namespace LeadManagement.WebApi.Extensions;

public static class CorsExtension
{
    public static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin() 
                           .AllowAnyMethod() 
                           .AllowAnyHeader();
                });
        });
        return services;
    }
}
