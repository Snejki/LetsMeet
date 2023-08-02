using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Shared.Abstractions.Kernel;

namespace LetsMeet.Modules.Users.Application.Services;

public interface IAuthenticator
{
    string CreateToken(UserId userId);
}