using LetsMeet.Modules.Users.Application.Exceptions;
using LetsMeet.Modules.Users.Application.Features.CreateUser;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Repositories;

namespace LetsMeet.Modules.Users.Infrastructure.Features.CreateUser;

// ReSharper disable once UnusedType.Global
public class CreateUserHandler
{
    // ReSharper disable once UnusedMember.Global
    public static async Task Handle(
        CreateUserCommand command,
        IUserRepository userRepository) 
    {
        var user = await userRepository.GetByEmail(Email.Create(command.Email));
        if (user is not null)
        {
            throw new UserWithProvidedEmailAlreadyExists();
        }

        var userId = UserId.Create(Guid.NewGuid());
        var email = Email.Create(command.Email);
        var firstName = FirstName.Create(command.FirstName);
        var lastname = LastName.Create(command.Lastname);
        var password = Password.Create(command.Password);

        user = User.Create(userId, email, firstName, lastname, password);

        await userRepository.Create(user);
    }
}