using FluentValidation;
using LetsMeet.Modules.Users.Application.Features.CreateUser;

namespace LetsMeet.Modules.Users.Infrastructure.Features.CreateUser;


// ReSharper disable once UnusedType.Global
public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}