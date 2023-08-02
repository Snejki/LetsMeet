using LetsMeet.Shared.Abstractions.Kernel;

namespace LetsMeet.Shared.Abstractions.Auth;

public class CurrentUser
{
    public UserId UserId { get; set; }

    public CurrentUser(UserId userId)
    {
        UserId = userId;
    }
}