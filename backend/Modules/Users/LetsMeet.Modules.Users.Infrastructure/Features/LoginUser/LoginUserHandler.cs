using LetsMeet.Modules.Users.Application.Exceptions;
using LetsMeet.Modules.Users.Application.Features.LoginUser;
using LetsMeet.Modules.Users.Application.Services;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Repositories;

namespace LetsMeet.Modules.Users.Infrastructure.Features.LoginUser;

// ReSharper disable once UnusedType.Global
public class LoginUserHandler
{
    public static async Task<LoginUserResponseDto> Handle(
        LoginUserQuery query,
        IUserRepository userRepository,
        IPasswordEncrypter passwordEncrypter)
    {
        var user = await userRepository.GetByEmail((Email) query.Email);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        if (passwordEncrypter.IsValidPassword(query.Password, user.HashedPassword))
        {
            throw new UserNotFoundException();
        }

        return new LoginUserResponseDto(user.Id, "::::::");
    }
}