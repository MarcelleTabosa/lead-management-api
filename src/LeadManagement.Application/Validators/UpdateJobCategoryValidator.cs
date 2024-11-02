using FluentValidation;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Validators;

public class UpdateJobCategoryValidator : AbstractValidator<UpdateJobCategoryRequest>
{
    public UpdateJobCategoryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id.");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category name is required.");
    }
}
