using FluentValidation;
using LeadManagement.Application.Models.Requests.Job;

namespace LeadManagement.Application.Validators.Job;

public class CreateJobValidator : AbstractValidator<CreateJobRequest>
{
    public CreateJobValidator()
    {
        RuleFor(x => x.Suburb).NotEmpty().WithMessage("Suburb is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Invalid price.");
        RuleFor(x => x.JobCategoryId).GreaterThan(0).WithMessage("Invalid Category.");
        RuleFor(x => x.LeadId).GreaterThan(0).WithMessage("Invalid Lead.");
    }
}
