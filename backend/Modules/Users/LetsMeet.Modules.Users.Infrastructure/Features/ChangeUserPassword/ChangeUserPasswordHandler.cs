using LetsMeet.Modules.Users.Application.Exceptions;
using LetsMeet.Modules.Users.Application.Features.ChangeUserPassword;
using LetsMeet.Modules.Users.Application.Services;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Repositories;
using LetsMeet.Shared.Abstractions.Auth;

namespace LetsMeet.Modules.Users.Infrastructure.Features.ChangeUserPassword;

// ReSharper disable once UnusedType.Global
public class ChangeUserPasswordHandler
{
    // ReSharper disable once UnusedMember.Global
    public async Task Handle(
        ChangeUserPasswordCommand command, 
        CurrentUser currentUser,
        IUserRepository userRepository,
        IPasswordEncrypter passwordEncrypter)
    {
        var user = await userRepository.GetById(currentUser.UserId);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var isCurrentPasswordCorrect = passwordEncrypter.IsValidPassword(command.CurrentPassword, user.HashedPassword);
        if (!isCurrentPasswordCorrect)
        {
            throw new WrongPasswordException();
        }

        var newPassword = HashedPassword.Create(passwordEncrypter.HashPassword(command.NewPassword));
        
        user.ChangePassword(newPassword);
        await userRepository.Update(user);
    }
}