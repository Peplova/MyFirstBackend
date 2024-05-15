using FluentValidation;
using MyFirstBackend.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.Business.Validation;

public class UserCreateRequestValidation: AbstractValidator<CreateUserRequest>
{
    public UserCreateRequestValidation()
    {
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.Age).InclusiveBetween(18, 99);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
