using FluentValidation;
using LetsMeet.Modules.Users.Application.Features.LoginUser;

namespace LetsMeet.Modules.Users.Infrastructure.Features.LoginUser;

// ReSharper disable once UnusedType.Global
public class LoginUserValidator : AbstractValidator<LoginUserQuery>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
    }
}