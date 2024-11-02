using FluentValidation;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Validators;

public class JobCategoryIdValidator : AbstractValidator<JobCategoryIdRequest>
{
    public JobCategoryIdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id.");
    }
}
