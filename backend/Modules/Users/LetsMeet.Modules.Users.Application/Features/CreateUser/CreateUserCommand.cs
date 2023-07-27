using LetsMeet.Shared.Infrastructure.Wolverine;
using Wolverine;

namespace LetsMeet.Modules.Users.Application.Features.CreateUser;

public record CreateUserCommand(string Email, string FirstName, string Lastname, string Password) : ICommand;