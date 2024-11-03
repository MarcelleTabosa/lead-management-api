using FluentValidation;
using LeadManagement.Application.Models.Requests;
using LeadManagement.Application.Models.Requests.Job;
using LeadManagement.Application.Models.Requests.JobCategory;
using LeadManagement.Application.Models.Requests.Lead;

namespace LeadManagement.WebApi.Extensions;

public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IdRequest>();
        services.AddValidatorsFromAssemblyContaining<CreateJobCategoryRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateJobCategoryRequest>();
        services.AddValidatorsFromAssemblyContaining<CreateJobRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateJobRequest>();
        services.AddValidatorsFromAssemblyContaining<CreateLeadRequest>();
        services.AddValidatorsFromAssemblyContaining<UpdateLeadRequest>();
        return services;
    }
}
