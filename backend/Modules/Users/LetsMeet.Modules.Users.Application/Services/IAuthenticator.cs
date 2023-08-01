using LetsMeet.Modules.Users.Domain.Entities;

namespace LetsMeet.Modules.Users.Application.Services;

public interface IAuthenticator
{
    string CreateToken(UserId userId);
}