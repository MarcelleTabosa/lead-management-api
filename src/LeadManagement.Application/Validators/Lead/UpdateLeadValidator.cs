using FluentValidation;
using LeadManagement.Application.Models.Requests.Lead;

namespace LeadManagement.Application.Validators.Lead;

public class UpdateLeadValidator : AbstractValidator<UpdateLeadRequest>
{
    public UpdateLeadValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid Id.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
    }
}
