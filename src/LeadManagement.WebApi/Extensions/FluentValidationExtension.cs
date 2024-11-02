using FluentValidation;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.WebApi.Extensions;

public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateJobCategoryRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateJobCategoryRequest>();
        return services;
    }
}
