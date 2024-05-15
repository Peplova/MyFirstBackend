using FluentValidation;
using MyFirstBackend.Business.Models.Requests;

namespace MyFirstBackend.Business.Validation;

public class UserCreateRequestValidation : AbstractValidator<CreateUserRequest>
{
    public UserCreateRequestValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.Age).InclusiveBetween(18, 99);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
