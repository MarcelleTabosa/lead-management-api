using FluentValidation;
using LeadManagement.Application.Models.Requests;

namespace LeadManagement.Application.Validators;

public class IdValidator : AbstractValidator<IdRequest>
{
    public IdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id.");
    }
}
