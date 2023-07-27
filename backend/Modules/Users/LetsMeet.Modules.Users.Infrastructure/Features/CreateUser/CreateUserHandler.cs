using LetsMeet.Modules.Users.Application.Exceptions;
using LetsMeet.Modules.Users.Application.Features.CreateUser;
using LetsMeet.Modules.Users.Application.Services;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Repositories;

namespace LetsMeet.Modules.Users.Infrastructure.Features.CreateUser;

// ReSharper disable once UnusedType.Global
public class CreateUserHandler
{
    // ReSharper disable once UnusedMember.Global
    public static async Task Handle(
        CreateUserCommand command,
        IUserRepository userRepository, 
        IPasswordEncrypter passwordEncrypter) 
    {
        var user = await userRepository.GetByEmail(Email.Create(command.Email));
        if (user is not null)
        {
            throw new UserWithProvidedEmailAlreadyExists();
        }

        var userId = (UserId) Guid.NewGuid();
        var email = (Email) command.Email;
        var firstName = (FirstName) command.FirstName;
        var lastname = (LastName) command.Lastname;
        var password = (HashedPassword) passwordEncrypter.HashPassword(command.Password);

        user = User.Create(userId, email, firstName, lastname, password);

        await userRepository.Create(user);
    }
}