using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Shared.Abstractions.Kernel;

namespace LetsMeet.Modules.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(UserId userId);

    Task<User?> GetByEmail(Email email);

    Task Create(User user);

    Task Update(User user);
}