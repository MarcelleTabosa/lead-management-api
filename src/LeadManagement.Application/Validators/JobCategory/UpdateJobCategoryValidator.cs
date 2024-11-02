using FluentValidation;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Validators.JobCategory;

public class UpdateJobValidator : AbstractValidator<UpdateJobCategoryRequest>
{
    public UpdateJobValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id.");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category name is required.");
    }
}
