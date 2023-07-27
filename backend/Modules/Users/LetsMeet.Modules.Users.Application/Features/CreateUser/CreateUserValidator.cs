using FluentValidation;

namespace LetsMeet.Modules.Users.Application.Features.CreateUser;


// ReSharper disable once UnusedType.Global
public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}