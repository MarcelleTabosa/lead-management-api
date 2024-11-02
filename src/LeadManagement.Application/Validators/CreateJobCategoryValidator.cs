using FluentValidation;
using LeadManagement.Application.Models.Requests.JobCategory;

namespace LeadManagement.Application.Validators;

public class CreateJobCategoryValidator : AbstractValidator<CreateJobCategoryRequest>
{
    public CreateJobCategoryValidator()
    {
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category name is required.");
    }
}
