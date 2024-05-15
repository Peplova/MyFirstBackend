using FluentValidation;
using MyFirstBackend.Business.Models.Requests;

namespace MyFirstBackend.Business.Validation;

public class LoginUserRequestsValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestsValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}
