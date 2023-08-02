using LetsMeet.Shared.Abstractions.Auth;

namespace LetsMeet.Modules.Users.Application.Features.ChangeUserPassword;

public record ChangeUserPasswordCommand(string CurrentPassword, string NewPassword) : IWithCurrentUser;